using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using HalconDotNet;

namespace vx_01
{
    public partial class Form1 : Form
    {
        private HalconViewer halconViewer;
        private VisionEngine visionEngine;

        // 图像序列管理
        private List<string> imageFileList = new List<string>();
        private int currentImageIndex = 0;

        // 统计数据
        private int totalCount = 0;
        private double sumDistancePx = 0.0;
        private double maxDistancePx = 0.0;
        private double minDistancePx = double.MaxValue;

        // 运行状态
        private bool isRunning = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // 1. 初始化 Halcon 视窗
            halconViewer = new HalconViewer(pnlHalcon);
            halconViewer.InitWindow();

            // 2. 初始化视觉测量引擎
            visionEngine = new VisionEngine();

            // 3. 同步配置参数到界面控件
            SyncConfigToUi();

            // 4. 加载默认图像目录
            LoadImageDirectory(txtImageDir.Text.Trim());

            AppendLog("系统初始化完成，圆心到直线测距引擎就绪。", Color.FromArgb(0, 230, 118));
            UpdateDeviceStatus(false);
        }

        private void SyncConfigToUi()
        {
            txtImageDir.Text = visionEngine.Config.ImageDirectory;
            numScale.Value = (decimal)visionEngine.Config.MmPerPixel;
            numThreshold.Value = visionEngine.Config.ThresholdGray;
        }

        private void LoadImageDirectory(string dirPath)
        {
            imageFileList.Clear();
            currentImageIndex = 0;

            if (Directory.Exists(dirPath))
            {
                string[] exts = new string[] { "*.bmp", "*.png", "*.jpg", "*.jpeg", "*.tif" };
                foreach (var ext in exts)
                {
                    string[] files = Directory.GetFiles(dirPath, ext);
                    imageFileList.AddRange(files);
                }

                AppendLog(string.Format("已加载图片目录: [{0}], 发现 {1} 张待测图片。", dirPath, imageFileList.Count), Color.FromArgb(0, 164, 239));

                // 默认加载第一张预览
                if (imageFileList.Count > 0)
                {
                    ExecuteSingleMeasure(imageFileList[0], false);
                }
            }
            else
            {
                AppendLog("指定的图片目录不存在: " + dirPath, Color.FromArgb(255, 61, 0));
            }
        }

        /// <summary>
        /// 核心测量处理流程
        /// </summary>
        private void ExecuteSingleMeasure(string imagePath, bool isStatistic = true)
        {
            if (string.IsNullOrEmpty(imagePath) || !File.Exists(imagePath))
            {
                AppendLog("未找到有效的待测图像文件。", Color.FromArgb(255, 61, 0));
                return;
            }

            HObject ho_Image = null;
            try
            {
                HOperatorSet.GenEmptyObj(out ho_Image);
                HOperatorSet.ReadImage(out ho_Image, imagePath);

                // 1. 在视窗中渲染底图
                halconViewer.DisplayImage(ho_Image);

                // 2. 调用核心算法引擎处理
                MeasureResult result = visionEngine.ProcessImage(ho_Image, imagePath);

                // 3. 叠加渲染特征线、圆心与垂线
                halconViewer.DisplayResult(result);

                // 4. 更新右侧测量数值看板
                UpdateMeasureDisplay(result);

                // 5. 计入历史与统计
                if (isStatistic && result.Success)
                {
                    AddRecordToHistory(result);
                    UpdateStatistics(result.DistancePixel);
                }

                // 6. 打印运行日志
                if (result.Success)
                {
                    string logText = string.Format("[{0}] 圆心: ({1:F1}, {2:F1}), 距离: {3:F2} px ({4:F3} mm), 耗时: {5:F1}ms",
                        result.ImageName, result.CenterRow, result.CenterCol, result.DistancePixel, result.DistanceMm, result.ExecutionTimeMs);
                    AppendLog(logText, Color.FromArgb(0, 230, 118));
                }
                else
                {
                    AppendLog(string.Format("[{0}] {1}", result.ImageName, result.Message), Color.FromArgb(255, 61, 0));
                }

                // 释放结果图形对象
                result.DisposeObjects();
            }
            catch (Exception ex)
            {
                AppendLog("测量过程发生异常: " + ex.Message, Color.FromArgb(255, 61, 0));
            }
            finally
            {
                if (ho_Image != null && ho_Image.IsInitialized())
                {
                    ho_Image.Dispose();
                }
            }
        }

        private void UpdateMeasureDisplay(MeasureResult result)
        {
            if (result == null) return;

            if (result.Success)
            {
                lblMainDistancePx.Text = result.DistancePixel.ToString("F2");
                lblDistMmVal.Text = string.Format("物理尺寸: {0:F3} mm", result.DistanceMm);
                lblCenterCoord.Text = string.Format("圆心坐标: Row: {0:F1}, Col: {1:F1}", result.CenterRow, result.CenterCol);
                lblCostTime.Text = string.Format("CT耗时: {0:F1} ms", result.ExecutionTimeMs);
            }
            else
            {
                lblMainDistancePx.Text = "---";
                lblDistMmVal.Text = "物理尺寸: --- mm";
                lblCenterCoord.Text = "圆心坐标: ---";
                lblCostTime.Text = "CT耗时: 0.0 ms";
            }
        }

        private void UpdateStatistics(double distancePx)
        {
            totalCount++;
            sumDistancePx += distancePx;

            if (distancePx > maxDistancePx) maxDistancePx = distancePx;
            if (distancePx < minDistancePx) minDistancePx = distancePx;

            double avgDist = sumDistancePx / totalCount;

            lblTotalCount.Text = "累计测量次数: " + totalCount;
            lblAvgDist.Text = string.Format("平均距离: {0:F2} px", avgDist);
            lblMaxDist.Text = string.Format("最大距离: {0:F2} px", maxDistancePx);
            lblMinDist.Text = string.Format("最小距离: {0:F2} px", minDistancePx);
        }

        private void AddRecordToHistory(MeasureResult result)
        {
            int rowIndex = dgvHistory.Rows.Add(
                dgvHistory.Rows.Count + 1,
                DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                result.ImageName,
                string.Format("({0:F1}, {1:F1})", result.CenterRow, result.CenterCol),
                result.DistancePixel.ToString("F2"),
                result.DistanceMm.ToString("F3"),
                result.ExecutionTimeMs.ToString("F1")
            );

            // 自动滚动到最新一行
            dgvHistory.FirstDisplayedScrollingRowIndex = rowIndex;

            // 限制最多保留 1000 条
            if (dgvHistory.Rows.Count > 1000)
            {
                dgvHistory.Rows.RemoveAt(0);
            }
        }

        private void AppendLog(string message, Color color)
        {
            if (rtbLogs.IsDisposed) return;

            string timeStr = DateTime.Now.ToString("[HH:mm:ss.fff] ");
            rtbLogs.SelectionStart = rtbLogs.TextLength;
            rtbLogs.SelectionLength = 0;

            rtbLogs.SelectionColor = Color.FromArgb(160, 160, 170);
            rtbLogs.AppendText(timeStr);

            rtbLogs.SelectionColor = color;
            rtbLogs.AppendText(message + Environment.NewLine);

            rtbLogs.ScrollToCaret();
        }

        private void UpdateDeviceStatus(bool running)
        {
            isRunning = running;
            btnStart.Enabled = !running;
            btnStop.Enabled = running;
            btnSingleTrigger.Enabled = !running;
            btnLoadImage.Enabled = !running;

            if (running)
            {
                lblStatusDot.BackColor = Color.FromArgb(0, 230, 118); // 运行绿
                lblDeviceStatus.Text = "系统状态: 连续测量中";
                lblDeviceStatus.ForeColor = Color.FromArgb(0, 230, 118);
            }
            else
            {
                lblStatusDot.BackColor = Color.FromArgb(160, 160, 160); // 待机灰
                lblDeviceStatus.Text = "系统状态: 设备待机";
                lblDeviceStatus.ForeColor = Color.FromArgb(200, 200, 200);
            }
        }

        #region 控制按钮事件

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (imageFileList.Count == 0)
            {
                MessageBox.Show("当前未找到任何待测图片，请先配置正确的图片路径！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            UpdateDeviceStatus(true);
            timerCycle.Start();
            AppendLog("已启动产线连续测量模式...", Color.FromArgb(0, 164, 239));
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            timerCycle.Stop();
            UpdateDeviceStatus(false);
            AppendLog("产线测量已停止。", Color.FromArgb(255, 185, 0));
        }

        private void btnSingleTrigger_Click(object sender, EventArgs e)
        {
            if (imageFileList.Count == 0)
            {
                MessageBox.Show("当前未找到待测图片！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 循环测试下一张
            string file = imageFileList[currentImageIndex];
            currentImageIndex = (currentImageIndex + 1) % imageFileList.Count;

            ExecuteSingleMeasure(file, true);
        }

        private void btnLoadImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "选择工件图像文件";
                ofd.Filter = "图像文件|*.bmp;*.png;*.jpg;*.jpeg;*.tif|所有文件|*.*";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    ExecuteSingleMeasure(ofd.FileName, true);
                }
            }
        }

        private void timerCycle_Tick(object sender, EventArgs e)
        {
            if (!isRunning || imageFileList.Count == 0) return;

            string file = imageFileList[currentImageIndex];
            currentImageIndex = (currentImageIndex + 1) % imageFileList.Count;

            ExecuteSingleMeasure(file, true);
        }

        private void timerClock_Tick(object sender, EventArgs e)
        {
            lblSystemTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        private void btnResetStat_Click(object sender, EventArgs e)
        {
            totalCount = 0;
            sumDistancePx = 0.0;
            maxDistancePx = 0.0;
            minDistancePx = double.MaxValue;

            lblTotalCount.Text = "累计测量次数: 0";
            lblAvgDist.Text = "平均距离: 0.00 px";
            lblMaxDist.Text = "最大距离: 0.00 px";
            lblMinDist.Text = "最小距离: 0.00 px";
            AppendLog("测量统计数据已重置清零。", Color.FromArgb(255, 185, 0));
        }

        private void btnBrowseDir_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                fbd.Description = "请选择产线待测图片目录";
                fbd.SelectedPath = txtImageDir.Text.Trim();
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    txtImageDir.Text = fbd.SelectedPath;
                    LoadImageDirectory(fbd.SelectedPath);
                }
            }
        }

        private void btnSaveConfig_Click(object sender, EventArgs e)
        {
            visionEngine.Config.ImageDirectory = txtImageDir.Text.Trim();
            visionEngine.Config.MmPerPixel = (double)numScale.Value;
            visionEngine.Config.ThresholdGray = (int)numThreshold.Value;

            if (txtImageDir.Text.Trim() != visionEngine.Config.ImageDirectory)
            {
                LoadImageDirectory(txtImageDir.Text.Trim());
            }

            AppendLog("测量环境与参数配置已成功更新并生效。", Color.FromArgb(0, 230, 118));
            MessageBox.Show("参数配置已成功保存！", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnFitView_Click(object sender, EventArgs e)
        {
            if (halconViewer != null) halconViewer.FitImage();
        }

        private void btnClearView_Click(object sender, EventArgs e)
        {
            if (halconViewer != null) halconViewer.Clear();
        }

        private void btnExportCsv_Click(object sender, EventArgs e)
        {
            if (dgvHistory.Rows.Count == 0)
            {
                MessageBox.Show("历史表格无数据可供导出！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Title = "导出历史距离测量报表";
                sfd.Filter = "CSV 文件 (*.csv)|*.csv";
                sfd.FileName = string.Format("圆心到直线距离报表_{0:yyyyMMdd_HHmmss}.csv", DateTime.Now);

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        StringBuilder sb = new StringBuilder();
                        // 写入表头
                        sb.AppendLine("序号,测量时间,图片名称,圆心坐标,点线距离(px),物理尺寸(mm),CT耗时(ms)");

                        foreach (DataGridViewRow row in dgvHistory.Rows)
                        {
                            sb.AppendLine(string.Format("{0},{1},{2},{3},{4},{5},{6}",
                                row.Cells[0].Value,
                                row.Cells[1].Value,
                                row.Cells[2].Value,
                                row.Cells[3].Value,
                                row.Cells[4].Value,
                                row.Cells[5].Value,
                                row.Cells[6].Value));
                        }

                        File.WriteAllText(sfd.FileName, sb.ToString(), Encoding.UTF8);
                        AppendLog("已成功导出 CSV 报表至: " + sfd.FileName, Color.FromArgb(0, 230, 118));
                        MessageBox.Show("距离测量报表导出成功！", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("导出 CSV 失败: " + ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnClearHistory_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定清空所有历史距离测量记录吗？", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                dgvHistory.Rows.Clear();
                AppendLog("历史距离测量表格已清空。", Color.FromArgb(255, 185, 0));
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            timerCycle.Stop();
            timerClock.Stop();
            if (halconViewer != null) halconViewer.Dispose();
            if (visionEngine != null) visionEngine.Dispose();
        }

        #endregion

        private void numScale_ValueChanged(object sender, EventArgs e)
        {
            if (visionEngine != null && visionEngine.Config != null)
            {
                visionEngine.Config.MmPerPixel = (double)numScale.Value;
            }
        }
    }
}
