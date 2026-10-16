using System;
using System.Drawing;
using System.Windows.Forms;
using HalconDotNet;

namespace vx_01
{
    /// <summary>
    /// 工业级 Halcon 交互式图像查看控制器
    /// 依托 WinForm Panel 渲染，支持鼠标滚轮缩放、拖拽平移、一键复位和高对比度叠加标注
    /// </summary>
    public class HalconViewer : IDisposable
    {
        private Panel targetPanel;
        private HTuple hv_WindowHandle = null;
        private HObject currentImage = null;
        private MeasureResult lastResult = null;

        // 视口与缩放坐标
        private double imgWidth = 0;
        private double imgHeight = 0;
        private double row1, col1, row2, col2;

        // 拖拽状态
        private bool isDragging = false;
        private double startX, startY;

        public bool IsWindowOpen
        {
            get { return hv_WindowHandle != null; }
        }

        public HalconViewer(Panel panel)
        {
            this.targetPanel = panel;
            this.targetPanel.Paint += TargetPanel_Paint;
            this.targetPanel.SizeChanged += TargetPanel_SizeChanged;
            this.targetPanel.MouseWheel += TargetPanel_MouseWheel;
            this.targetPanel.MouseDown += TargetPanel_MouseDown;
            this.targetPanel.MouseMove += TargetPanel_MouseMove;
            this.targetPanel.MouseUp += TargetPanel_MouseUp;
            this.targetPanel.MouseDoubleClick += TargetPanel_MouseDoubleClick;
        }

        /// <summary>
        /// 初始化打开 Halcon 窗口
        /// </summary>
        public void InitWindow()
        {
            if (hv_WindowHandle != null) return;
            if (targetPanel.Width <= 0 || targetPanel.Height <= 0) return;

            try
            {
                HOperatorSet.SetCheck("~father");
                HOperatorSet.OpenWindow(0, 0, targetPanel.Width, targetPanel.Height, 
                    targetPanel.Handle, "visible", "", out hv_WindowHandle);
                HOperatorSet.SetCheck("father");

                HOperatorSet.SetPart(hv_WindowHandle, 0, 0, targetPanel.Height - 1, targetPanel.Width - 1);
                HOperatorSet.SetColor(hv_WindowHandle, "red");
                HOperatorSet.SetDraw(hv_WindowHandle, "margin");
                HOperatorSet.SetLineWidth(hv_WindowHandle, 2);

                try
                {
                    HOperatorSet.SetFont(hv_WindowHandle, "Arial-Bold-14");
                }
                catch { }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Halcon OpenWindow Error: " + ex.Message);
            }
        }

        private void TargetPanel_Paint(object sender, PaintEventArgs e)
        {
            if (hv_WindowHandle == null)
            {
                InitWindow();
            }
        }

        private void TargetPanel_SizeChanged(object sender, EventArgs e)
        {
            if (hv_WindowHandle != null && targetPanel.Width > 0 && targetPanel.Height > 0)
            {
                HOperatorSet.SetWindowExtents(hv_WindowHandle, 0, 0, targetPanel.Width, targetPanel.Height);
                FitImage();
            }
        }

        /// <summary>
        /// 显示图像并自适应视口
        /// </summary>
        public void DisplayImage(HObject image)
        {
            if (hv_WindowHandle == null) InitWindow();
            if (hv_WindowHandle == null || image == null || !image.IsInitialized()) return;

            lastResult = null;

            if (currentImage != null && currentImage.IsInitialized())
            {
                currentImage.Dispose();
            }
            HOperatorSet.CopyObj(image, out currentImage, 1, 1);

            HTuple w, h;
            HOperatorSet.GetImageSize(currentImage, out w, out h);
            imgWidth = w.D;
            imgHeight = h.D;

            FitImage();
        }

        /// <summary>
        /// 自适应居中缩放
        /// </summary>
        public void FitImage()
        {
            if (hv_WindowHandle == null || currentImage == null || !currentImage.IsInitialized()) return;

            row1 = 0;
            col1 = 0;
            row2 = imgHeight - 1;
            col2 = imgWidth - 1;

            RenderCurrent();
        }

        /// <summary>
        /// 叠加渲染测量结果 (直线、圆、垂线、十字叉和文本)
        /// </summary>
        public void DisplayResult(MeasureResult result)
        {
            lastResult = result;
            RenderCurrent();
        }

        /// <summary>
        /// 刷新当前视口内容及所有特征标注层
        /// </summary>
        public void RenderCurrent()
        {
            if (hv_WindowHandle == null || currentImage == null || !currentImage.IsInitialized()) return;

            HOperatorSet.ClearWindow(hv_WindowHandle);
            HOperatorSet.SetPart(hv_WindowHandle, (int)row1, (int)col1, (int)row2, (int)col2);
            HOperatorSet.DispObj(currentImage, hv_WindowHandle);

            if (lastResult != null)
            {
                DrawOverlays(lastResult);
            }
        }

        /// <summary>
        /// 绘制高对比度测量标注（针对白底/浅色工件全面优化对比度）
        /// </summary>
        private void DrawOverlays(MeasureResult result)
        {
            if (hv_WindowHandle == null || result == null) return;

            if (!result.Success)
            {
                try
                {
                    HTuple pNames = new HTuple("box", "box_color", "shadow");
                    HTuple pVals = new HTuple("true", "#2B0B0E", "false");
                    HOperatorSet.DispText(hv_WindowHandle, "测量失败: " + result.Message, "window", 20, 20, "#FF4D4F", pNames, pVals);
                }
                catch { }
                return;
            }

            // 1. 绘制拟合基准直线 (高对比度深蓝/皇家蓝，3像素粗线，在白色/浅灰工件背景上极度清晰醒目)
            if (result.LineContour != null && result.LineContour.IsInitialized())
            {
                HOperatorSet.SetColor(hv_WindowHandle, "blue");
                HOperatorSet.SetLineWidth(hv_WindowHandle, 3);
                HOperatorSet.DispObj(result.LineContour, hv_WindowHandle);
            }

            // 2. 绘制拟合特征圆 (高对比度品红/洋红，2像素)
            if (result.CircleContour != null && result.CircleContour.IsInitialized())
            {
                HOperatorSet.SetColor(hv_WindowHandle, "magenta");
                HOperatorSet.SetLineWidth(hv_WindowHandle, 2);
                HOperatorSet.DispObj(result.CircleContour, hv_WindowHandle);
            }

            // 3. 绘制测量距离垂线 (高对比度大红，3像素加粗)
            if (result.MeasureLine != null && result.MeasureLine.IsInitialized())
            {
                HOperatorSet.SetColor(hv_WindowHandle, "red");
                HOperatorSet.SetLineWidth(hv_WindowHandle, 3);
                HOperatorSet.DispObj(result.MeasureLine, hv_WindowHandle);
            }

            // 4. 绘制圆心与垂足十字叉 (高对比度大红，3像素加粗)
            if (result.CenterCross != null && result.CenterCross.IsInitialized())
            {
                HOperatorSet.SetColor(hv_WindowHandle, "red");
                HOperatorSet.SetLineWidth(hv_WindowHandle, 3);
                HOperatorSet.DispObj(result.CenterCross, hv_WindowHandle);
            }

            // 5. 绘制浮动距离文字标签 (左上角深色 HUD 胶囊卡片 + 亮青色文字，无视任何底色反差，字迹清晰锐利)
            try
            {
                HTuple textList = new HTuple();
                textList = textList.TupleConcat(string.Format("点线距离: {0:F2} px  ({1:F3} mm)", result.DistancePixel, result.DistanceMm));
                textList = textList.TupleConcat(string.Format("圆心坐标: ({0:F1}, {1:F1})", result.CenterRow, result.CenterCol));

                HTuple genParamNames = new HTuple("box", "box_color", "shadow");
                HTuple genParamValues = new HTuple("true", "#10141D", "false");

                // 使用 DispText 窗口坐标固定在左上角 (20, 20)，字号与卡片自动适配
                HOperatorSet.DispText(hv_WindowHandle, textList, "window", 20, 20, "#00E5FF", genParamNames, genParamValues);
            }
            catch
            {
                // 兼容降级方案
                try
                {
                    string info = string.Format("Dist: {0:F2} px ({1:F3} mm)", result.DistancePixel, result.DistanceMm);
                    HOperatorSet.SetColor(hv_WindowHandle, "red");
                    HOperatorSet.SetTposition(hv_WindowHandle, 25, 25);
                    HOperatorSet.WriteString(hv_WindowHandle, info);
                }
                catch { }
            }
        }

        #region 鼠标缩放与拖拽平移事件

        private void TargetPanel_MouseWheel(object sender, MouseEventArgs e)
        {
            if (hv_WindowHandle == null || currentImage == null || !currentImage.IsInitialized()) return;

            // 获取当前鼠标在图像中的像素坐标
            double zoom = e.Delta > 0 ? 0.8 : 1.25;

            double mouseRow, mouseCol;
            try
            {
                HTuple r, c, b;
                HOperatorSet.GetMposition(hv_WindowHandle, out r, out c, out b);
                mouseRow = r.D;
                mouseCol = c.D;
            }
            catch
            {
                mouseRow = (row1 + row2) / 2;
                mouseCol = (col1 + col2) / 2;
            }

            double newRow1 = mouseRow - (mouseRow - row1) * zoom;
            double newCol1 = mouseCol - (mouseCol - col1) * zoom;
            double newRow2 = mouseRow + (row2 - mouseRow) * zoom;
            double newCol2 = mouseCol + (col2 - mouseCol) * zoom;

            // 保护缩放范围
            if (Math.Abs(newRow2 - newRow1) > 5 && Math.Abs(newCol2 - newCol1) > 5)
            {
                row1 = newRow1;
                col1 = newCol1;
                row2 = newRow2;
                col2 = newCol2;

                RenderCurrent();
            }
        }

        private void TargetPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left || e.Button == MouseButtons.Right)
            {
                isDragging = true;
                startX = e.X;
                startY = e.Y;
            }
        }

        private void TargetPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (!isDragging || hv_WindowHandle == null || currentImage == null || !currentImage.IsInitialized()) return;

            double scaleX = (col2 - col1) / targetPanel.Width;
            double scaleY = (row2 - row1) / targetPanel.Height;

            double deltaX = (e.X - startX) * scaleX;
            double deltaY = (e.Y - startY) * scaleY;

            row1 -= deltaY;
            row2 -= deltaY;
            col1 -= deltaX;
            col2 -= deltaX;

            startX = e.X;
            startY = e.Y;

            RenderCurrent();
        }

        private void TargetPanel_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
        }

        private void TargetPanel_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FitImage();
        }

        #endregion

        public void Clear()
        {
            lastResult = null;
            if (hv_WindowHandle != null)
            {
                HOperatorSet.ClearWindow(hv_WindowHandle);
            }
        }

        public void Dispose()
        {
            lastResult = null;

            if (currentImage != null && currentImage.IsInitialized())
            {
                currentImage.Dispose();
                currentImage = null;
            }

            if (hv_WindowHandle != null)
            {
                try
                {
                    HOperatorSet.CloseWindow(hv_WindowHandle);
                    hv_WindowHandle = null;
                }
                catch { }
            }
        }
    }
}
