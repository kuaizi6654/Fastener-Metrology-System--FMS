namespace vx_01
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblSystemTime = new System.Windows.Forms.Label();
            this.lblDeviceStatus = new System.Windows.Forms.Label();
            this.lblStatusDot = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.pnlViewerContainer = new System.Windows.Forms.Panel();
            this.pnlHalcon = new System.Windows.Forms.Panel();
            this.pnlViewerToolbar = new System.Windows.Forms.Panel();
            this.btnClearView = new System.Windows.Forms.Button();
            this.btnFitView = new System.Windows.Forms.Button();
            this.lblViewTip = new System.Windows.Forms.Label();
            this.tabBottom = new System.Windows.Forms.TabControl();
            this.tabHistory = new System.Windows.Forms.TabPage();
            this.dgvHistory = new System.Windows.Forms.DataGridView();
            this.colIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colImage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCenter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDistPx = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDistMm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlGridTool = new System.Windows.Forms.Panel();
            this.btnClearHistory = new System.Windows.Forms.Button();
            this.btnExportCsv = new System.Windows.Forms.Button();
            this.tabLogs = new System.Windows.Forms.TabPage();
            this.rtbLogs = new System.Windows.Forms.RichTextBox();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.pnlConfig = new System.Windows.Forms.Panel();
            this.btnSaveConfig = new System.Windows.Forms.Button();
            this.numThreshold = new System.Windows.Forms.NumericUpDown();
            this.lblThreshold = new System.Windows.Forms.Label();
            this.numScale = new System.Windows.Forms.NumericUpDown();
            this.lblScale = new System.Windows.Forms.Label();
            this.btnBrowseDir = new System.Windows.Forms.Button();
            this.txtImageDir = new System.Windows.Forms.TextBox();
            this.lblDir = new System.Windows.Forms.Label();
            this.lblConfigHeader = new System.Windows.Forms.Label();
            this.pnlControls = new System.Windows.Forms.Panel();
            this.btnLoadImage = new System.Windows.Forms.Button();
            this.btnSingleTrigger = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.lblCtrlHeader = new System.Windows.Forms.Label();
            this.pnlStatistics = new System.Windows.Forms.Panel();
            this.lblMinDist = new System.Windows.Forms.Label();
            this.lblMaxDist = new System.Windows.Forms.Label();
            this.btnResetStat = new System.Windows.Forms.Button();
            this.lblAvgDist = new System.Windows.Forms.Label();
            this.lblTotalCount = new System.Windows.Forms.Label();
            this.lblStatHeader = new System.Windows.Forms.Label();
            this.pnlMeasureValue = new System.Windows.Forms.Panel();
            this.lblCenterCoord = new System.Windows.Forms.Label();
            this.lblDistMmVal = new System.Windows.Forms.Label();
            this.lblCostTime = new System.Windows.Forms.Label();
            this.lblValHeader = new System.Windows.Forms.Label();
            this.pnlMainDisplayCard = new System.Windows.Forms.Panel();
            this.lblUnitPx = new System.Windows.Forms.Label();
            this.lblMainDistancePx = new System.Windows.Forms.Label();
            this.lblCardSubtitle = new System.Windows.Forms.Label();
            this.timerClock = new System.Windows.Forms.Timer(this.components);
            this.timerCycle = new System.Windows.Forms.Timer(this.components);
            this.pnlTop.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.pnlViewerContainer.SuspendLayout();
            this.pnlViewerToolbar.SuspendLayout();
            this.tabBottom.SuspendLayout();
            this.tabHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistory)).BeginInit();
            this.pnlGridTool.SuspendLayout();
            this.tabLogs.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.pnlConfig.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numThreshold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numScale)).BeginInit();
            this.pnlControls.SuspendLayout();
            this.pnlStatistics.SuspendLayout();
            this.pnlMeasureValue.SuspendLayout();
            this.pnlMainDisplayCard.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(28)))));
            this.pnlTop.Controls.Add(this.lblSystemTime);
            this.pnlTop.Controls.Add(this.lblDeviceStatus);
            this.pnlTop.Controls.Add(this.lblStatusDot);
            this.pnlTop.Controls.Add(this.lblTitle);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1380, 52);
            this.pnlTop.TabIndex = 0;
            // 
            // lblSystemTime
            // 
            this.lblSystemTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSystemTime.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSystemTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(170)))));
            this.lblSystemTime.Location = new System.Drawing.Point(1140, 15);
            this.lblSystemTime.Name = "lblSystemTime";
            this.lblSystemTime.Size = new System.Drawing.Size(225, 20);
            this.lblSystemTime.TabIndex = 3;
            this.lblSystemTime.Text = "2026-10-13 19:30:00";
            this.lblSystemTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDeviceStatus
            // 
            this.lblDeviceStatus.AutoSize = true;
            this.lblDeviceStatus.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblDeviceStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.lblDeviceStatus.Location = new System.Drawing.Point(438, 16);
            this.lblDeviceStatus.Name = "lblDeviceStatus";
            this.lblDeviceStatus.Size = new System.Drawing.Size(100, 19);
            this.lblDeviceStatus.TabIndex = 2;
            this.lblDeviceStatus.Text = "系统状态: 待机";
            // 
            // lblStatusDot
            // 
            this.lblStatusDot.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.lblStatusDot.Location = new System.Drawing.Point(420, 20);
            this.lblStatusDot.Name = "lblStatusDot";
            this.lblStatusDot.Size = new System.Drawing.Size(12, 12);
            this.lblStatusDot.TabIndex = 1;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(164)))), ((int)(((byte)(239)))));
            this.lblTitle.Location = new System.Drawing.Point(16, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(370, 26);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "工业机器视觉圆心到直线距离测量系统";
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.pnlViewerContainer);
            this.pnlLeft.Controls.Add(this.tabBottom);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLeft.Location = new System.Drawing.Point(0, 52);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Padding = new System.Windows.Forms.Padding(10, 10, 5, 10);
            this.pnlLeft.Size = new System.Drawing.Size(960, 798);
            this.pnlLeft.TabIndex = 1;
            // 
            // pnlViewerContainer
            // 
            this.pnlViewerContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(34)))));
            this.pnlViewerContainer.Controls.Add(this.pnlHalcon);
            this.pnlViewerContainer.Controls.Add(this.pnlViewerToolbar);
            this.pnlViewerContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlViewerContainer.Location = new System.Drawing.Point(10, 10);
            this.pnlViewerContainer.Name = "pnlViewerContainer";
            this.pnlViewerContainer.Size = new System.Drawing.Size(945, 538);
            this.pnlViewerContainer.TabIndex = 0;
            // 
            // pnlHalcon
            // 
            this.pnlHalcon.BackColor = System.Drawing.Color.Black;
            this.pnlHalcon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlHalcon.Location = new System.Drawing.Point(0, 36);
            this.pnlHalcon.Name = "pnlHalcon";
            this.pnlHalcon.Size = new System.Drawing.Size(945, 502);
            this.pnlHalcon.TabIndex = 1;
            // 
            // pnlViewerToolbar
            // 
            this.pnlViewerToolbar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(46)))));
            this.pnlViewerToolbar.Controls.Add(this.btnClearView);
            this.pnlViewerToolbar.Controls.Add(this.btnFitView);
            this.pnlViewerToolbar.Controls.Add(this.lblViewTip);
            this.pnlViewerToolbar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlViewerToolbar.Location = new System.Drawing.Point(0, 0);
            this.pnlViewerToolbar.Name = "pnlViewerToolbar";
            this.pnlViewerToolbar.Size = new System.Drawing.Size(945, 36);
            this.pnlViewerToolbar.TabIndex = 0;
            // 
            // btnClearView
            // 
            this.btnClearView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(60)))));
            this.btnClearView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearView.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btnClearView.ForeColor = System.Drawing.Color.White;
            this.btnClearView.Location = new System.Drawing.Point(852, 4);
            this.btnClearView.Name = "btnClearView";
            this.btnClearView.Size = new System.Drawing.Size(85, 28);
            this.btnClearView.TabIndex = 2;
            this.btnClearView.Text = "清空画布";
            this.btnClearView.UseVisualStyleBackColor = false;
            this.btnClearView.Click += new System.EventHandler(this.btnClearView_Click);
            // 
            // btnFitView
            // 
            this.btnFitView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFitView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(60)))));
            this.btnFitView.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFitView.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.btnFitView.ForeColor = System.Drawing.Color.White;
            this.btnFitView.Location = new System.Drawing.Point(760, 4);
            this.btnFitView.Name = "btnFitView";
            this.btnFitView.Size = new System.Drawing.Size(85, 28);
            this.btnFitView.TabIndex = 1;
            this.btnFitView.Text = "自适应居中";
            this.btnFitView.UseVisualStyleBackColor = false;
            this.btnFitView.Click += new System.EventHandler(this.btnFitView_Click);
            // 
            // lblViewTip
            // 
            this.lblViewTip.AutoSize = true;
            this.lblViewTip.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblViewTip.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(170)))));
            this.lblViewTip.Location = new System.Drawing.Point(10, 9);
            this.lblViewTip.Name = "lblViewTip";
            this.lblViewTip.Size = new System.Drawing.Size(306, 17);
            this.lblViewTip.TabIndex = 0;
            this.lblViewTip.Text = "交互提示: 鼠标滚轮缩放，鼠标右键/中键拖拽，双击全图复位";
            // 
            // tabBottom
            // 
            this.tabBottom.Controls.Add(this.tabHistory);
            this.tabBottom.Controls.Add(this.tabLogs);
            this.tabBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tabBottom.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabBottom.Location = new System.Drawing.Point(10, 548);
            this.tabBottom.Name = "tabBottom";
            this.tabBottom.SelectedIndex = 0;
            this.tabBottom.Size = new System.Drawing.Size(945, 240);
            this.tabBottom.TabIndex = 1;
            // 
            // tabHistory
            // 
            this.tabHistory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(36)))));
            this.tabHistory.Controls.Add(this.dgvHistory);
            this.tabHistory.Controls.Add(this.pnlGridTool);
            this.tabHistory.Location = new System.Drawing.Point(4, 26);
            this.tabHistory.Name = "tabHistory";
            this.tabHistory.Padding = new System.Windows.Forms.Padding(3);
            this.tabHistory.Size = new System.Drawing.Size(937, 210);
            this.tabHistory.TabIndex = 0;
            this.tabHistory.Text = "  历史距离测量记录  ";
            // 
            // dgvHistory
            // 
            this.dgvHistory.AllowUserToAddRows = false;
            this.dgvHistory.AllowUserToDeleteRows = false;
            this.dgvHistory.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(32)))));
            this.dgvHistory.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHistory.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvHistory.ColumnHeadersHeight = 28;
            this.dgvHistory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIndex,
            this.colTime,
            this.colImage,
            this.colCenter,
            this.colDistPx,
            this.colDistMm,
            this.colCost});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(34)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvHistory.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvHistory.EnableHeadersVisualStyles = false;
            this.dgvHistory.Location = new System.Drawing.Point(3, 35);
            this.dgvHistory.Name = "dgvHistory";
            this.dgvHistory.ReadOnly = true;
            this.dgvHistory.RowHeadersVisible = false;
            this.dgvHistory.RowTemplate.Height = 24;
            this.dgvHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHistory.Size = new System.Drawing.Size(931, 172);
            this.dgvHistory.TabIndex = 0;
            // 
            // colIndex
            // 
            this.colIndex.HeaderText = "序号";
            this.colIndex.Name = "colIndex";
            this.colIndex.ReadOnly = true;
            this.colIndex.Width = 55;
            // 
            // colTime
            // 
            this.colTime.HeaderText = "测量时间";
            this.colTime.Name = "colTime";
            this.colTime.ReadOnly = true;
            this.colTime.Width = 145;
            // 
            // colImage
            // 
            this.colImage.HeaderText = "图片名称";
            this.colImage.Name = "colImage";
            this.colImage.ReadOnly = true;
            this.colImage.Width = 150;
            // 
            // colCenter
            // 
            this.colCenter.HeaderText = "圆心坐标 (Row, Col)";
            this.colCenter.Name = "colCenter";
            this.colCenter.ReadOnly = true;
            this.colCenter.Width = 180;
            // 
            // colDistPx
            // 
            this.colDistPx.HeaderText = "点线距离 (像素 px)";
            this.colDistPx.Name = "colDistPx";
            this.colDistPx.ReadOnly = true;
            this.colDistPx.Width = 150;
            // 
            // colDistMm
            // 
            this.colDistMm.HeaderText = "物理尺寸 (mm)";
            this.colDistMm.Name = "colDistMm";
            this.colDistMm.ReadOnly = true;
            this.colDistMm.Width = 130;
            // 
            // colCost
            // 
            this.colCost.HeaderText = "CT耗时 (ms)";
            this.colCost.Name = "colCost";
            this.colCost.ReadOnly = true;
            this.colCost.Width = 105;
            // 
            // pnlGridTool
            // 
            this.pnlGridTool.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(42)))));
            this.pnlGridTool.Controls.Add(this.btnClearHistory);
            this.pnlGridTool.Controls.Add(this.btnExportCsv);
            this.pnlGridTool.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlGridTool.Location = new System.Drawing.Point(3, 3);
            this.pnlGridTool.Name = "pnlGridTool";
            this.pnlGridTool.Size = new System.Drawing.Size(931, 32);
            this.pnlGridTool.TabIndex = 1;
            // 
            // btnClearHistory
            // 
            this.btnClearHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearHistory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(60)))));
            this.btnClearHistory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearHistory.ForeColor = System.Drawing.Color.White;
            this.btnClearHistory.Location = new System.Drawing.Point(839, 3);
            this.btnClearHistory.Name = "btnClearHistory";
            this.btnClearHistory.Size = new System.Drawing.Size(88, 26);
            this.btnClearHistory.TabIndex = 1;
            this.btnClearHistory.Text = "清空表格";
            this.btnClearHistory.UseVisualStyleBackColor = false;
            this.btnClearHistory.Click += new System.EventHandler(this.btnClearHistory_Click);
            // 
            // btnExportCsv
            // 
            this.btnExportCsv.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportCsv.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(60)))));
            this.btnExportCsv.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportCsv.ForeColor = System.Drawing.Color.White;
            this.btnExportCsv.Location = new System.Drawing.Point(745, 3);
            this.btnExportCsv.Name = "btnExportCsv";
            this.btnExportCsv.Size = new System.Drawing.Size(88, 26);
            this.btnExportCsv.TabIndex = 0;
            this.btnExportCsv.Text = "导出 CSV";
            this.btnExportCsv.UseVisualStyleBackColor = false;
            this.btnExportCsv.Click += new System.EventHandler(this.btnExportCsv_Click);
            // 
            // tabLogs
            // 
            this.tabLogs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(36)))));
            this.tabLogs.Controls.Add(this.rtbLogs);
            this.tabLogs.Location = new System.Drawing.Point(4, 26);
            this.tabLogs.Name = "tabLogs";
            this.tabLogs.Padding = new System.Windows.Forms.Padding(3);
            this.tabLogs.Size = new System.Drawing.Size(937, 210);
            this.tabLogs.TabIndex = 1;
            this.tabLogs.Text = "  系统运行日志  ";
            // 
            // rtbLogs
            // 
            this.rtbLogs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(26)))));
            this.rtbLogs.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbLogs.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbLogs.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(230)))));
            this.rtbLogs.Location = new System.Drawing.Point(3, 3);
            this.rtbLogs.Name = "rtbLogs";
            this.rtbLogs.ReadOnly = true;
            this.rtbLogs.Size = new System.Drawing.Size(931, 204);
            this.rtbLogs.TabIndex = 0;
            this.rtbLogs.Text = "";
            // 
            // pnlRight
            // 
            this.pnlRight.AutoScroll = true;
            this.pnlRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(32)))));
            this.pnlRight.Controls.Add(this.pnlConfig);
            this.pnlRight.Controls.Add(this.pnlControls);
            this.pnlRight.Controls.Add(this.pnlStatistics);
            this.pnlRight.Controls.Add(this.pnlMeasureValue);
            this.pnlRight.Controls.Add(this.pnlMainDisplayCard);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlRight.Location = new System.Drawing.Point(960, 52);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.pnlRight.Size = new System.Drawing.Size(420, 798);
            this.pnlRight.TabIndex = 2;
            // 
            // pnlConfig
            // 
            this.pnlConfig.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(46)))));
            this.pnlConfig.Controls.Add(this.btnSaveConfig);
            this.pnlConfig.Controls.Add(this.numThreshold);
            this.pnlConfig.Controls.Add(this.lblThreshold);
            this.pnlConfig.Controls.Add(this.numScale);
            this.pnlConfig.Controls.Add(this.lblScale);
            this.pnlConfig.Controls.Add(this.btnBrowseDir);
            this.pnlConfig.Controls.Add(this.txtImageDir);
            this.pnlConfig.Controls.Add(this.lblDir);
            this.pnlConfig.Controls.Add(this.lblConfigHeader);
            this.pnlConfig.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlConfig.Location = new System.Drawing.Point(6, 420);
            this.pnlConfig.Margin = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.pnlConfig.Name = "pnlConfig";
            this.pnlConfig.Padding = new System.Windows.Forms.Padding(12, 8, 12, 8);
            this.pnlConfig.Size = new System.Drawing.Size(408, 160);
            this.pnlConfig.TabIndex = 4;
            // 
            // btnSaveConfig
            // 
            this.btnSaveConfig.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnSaveConfig.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveConfig.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold);
            this.btnSaveConfig.ForeColor = System.Drawing.Color.White;
            this.btnSaveConfig.Location = new System.Drawing.Point(12, 114);
            this.btnSaveConfig.Name = "btnSaveConfig";
            this.btnSaveConfig.Size = new System.Drawing.Size(384, 34);
            this.btnSaveConfig.TabIndex = 12;
            this.btnSaveConfig.Text = "✔  应用并保存参数配置";
            this.btnSaveConfig.UseVisualStyleBackColor = false;
            this.btnSaveConfig.Click += new System.EventHandler(this.btnSaveConfig_Click);
            // 
            // numThreshold
            // 
            this.numThreshold.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(30)))));
            this.numThreshold.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.numThreshold.ForeColor = System.Drawing.Color.White;
            this.numThreshold.Location = new System.Drawing.Point(314, 78);
            this.numThreshold.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numThreshold.Name = "numThreshold";
            this.numThreshold.Size = new System.Drawing.Size(82, 23);
            this.numThreshold.TabIndex = 9;
            this.numThreshold.Value = new decimal(new int[] {
            90,
            0,
            0,
            0});
            // 
            // lblThreshold
            // 
            this.lblThreshold.AutoSize = true;
            this.lblThreshold.Font = new System.Drawing.Font("微软雅黑", 8.5F);
            this.lblThreshold.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(210)))));
            this.lblThreshold.Location = new System.Drawing.Point(216, 80);
            this.lblThreshold.Name = "lblThreshold";
            this.lblThreshold.Size = new System.Drawing.Size(95, 17);
            this.lblThreshold.TabIndex = 8;
            this.lblThreshold.Text = "分割阈值(0-255):";
            // 
            // numScale
            // 
            this.numScale.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(30)))));
            this.numScale.DecimalPlaces = 4;
            this.numScale.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.numScale.ForeColor = System.Drawing.Color.White;
            this.numScale.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.numScale.Location = new System.Drawing.Point(138, 78);
            this.numScale.Name = "numScale";
            this.numScale.Size = new System.Drawing.Size(70, 23);
            this.numScale.TabIndex = 7;
            this.numScale.Value = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.numScale.ValueChanged += new System.EventHandler(this.numScale_ValueChanged);
            // 
            // lblScale
            // 
            this.lblScale.AutoSize = true;
            this.lblScale.Font = new System.Drawing.Font("微软雅黑", 8.5F);
            this.lblScale.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(210)))));
            this.lblScale.Location = new System.Drawing.Point(12, 80);
            this.lblScale.Name = "lblScale";
            this.lblScale.Size = new System.Drawing.Size(122, 17);
            this.lblScale.TabIndex = 6;
            this.lblScale.Text = "像素标定 (mm/px):";
            // 
            // btnBrowseDir
            // 
            this.btnBrowseDir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(60)))));
            this.btnBrowseDir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowseDir.Font = new System.Drawing.Font("微软雅黑", 8.5F);
            this.btnBrowseDir.ForeColor = System.Drawing.Color.White;
            this.btnBrowseDir.Location = new System.Drawing.Point(328, 46);
            this.btnBrowseDir.Name = "btnBrowseDir";
            this.btnBrowseDir.Size = new System.Drawing.Size(68, 25);
            this.btnBrowseDir.TabIndex = 3;
            this.btnBrowseDir.Text = "浏览...";
            this.btnBrowseDir.UseVisualStyleBackColor = false;
            this.btnBrowseDir.Click += new System.EventHandler(this.btnBrowseDir_Click);
            // 
            // txtImageDir
            // 
            this.txtImageDir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(30)))));
            this.txtImageDir.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtImageDir.Font = new System.Drawing.Font("微软雅黑", 8.5F);
            this.txtImageDir.ForeColor = System.Drawing.Color.White;
            this.txtImageDir.Location = new System.Drawing.Point(14, 47);
            this.txtImageDir.Name = "txtImageDir";
            this.txtImageDir.Size = new System.Drawing.Size(308, 22);
            this.txtImageDir.TabIndex = 2;
            this.txtImageDir.Text = "D:\\zz-mv-2603\\Halcon\\第十天\\测量";
            // 
            // lblDir
            // 
            this.lblDir.AutoSize = true;
            this.lblDir.Font = new System.Drawing.Font("微软雅黑", 8.5F);
            this.lblDir.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(210)))));
            this.lblDir.Location = new System.Drawing.Point(12, 28);
            this.lblDir.Name = "lblDir";
            this.lblDir.Size = new System.Drawing.Size(95, 17);
            this.lblDir.TabIndex = 1;
            this.lblDir.Text = "图片文件夹路径:";
            // 
            // lblConfigHeader
            // 
            this.lblConfigHeader.AutoSize = true;
            this.lblConfigHeader.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblConfigHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(164)))), ((int)(((byte)(239)))));
            this.lblConfigHeader.Location = new System.Drawing.Point(12, 8);
            this.lblConfigHeader.Name = "lblConfigHeader";
            this.lblConfigHeader.Size = new System.Drawing.Size(139, 19);
            this.lblConfigHeader.TabIndex = 0;
            this.lblConfigHeader.Text = "测量参数与环境配置";
            // 
            // pnlControls
            // 
            this.pnlControls.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(46)))));
            this.pnlControls.Controls.Add(this.btnLoadImage);
            this.pnlControls.Controls.Add(this.btnSingleTrigger);
            this.pnlControls.Controls.Add(this.btnStop);
            this.pnlControls.Controls.Add(this.btnStart);
            this.pnlControls.Controls.Add(this.lblCtrlHeader);
            this.pnlControls.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlControls.Location = new System.Drawing.Point(6, 302);
            this.pnlControls.Margin = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.pnlControls.Name = "pnlControls";
            this.pnlControls.Padding = new System.Windows.Forms.Padding(12, 8, 12, 8);
            this.pnlControls.Size = new System.Drawing.Size(408, 115);
            this.pnlControls.TabIndex = 3;
            // 
            // btnLoadImage
            // 
            this.btnLoadImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(58)))), ((int)(((byte)(72)))));
            this.btnLoadImage.FlatAppearance.BorderSize = 0;
            this.btnLoadImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoadImage.Font = new System.Drawing.Font("微软雅黑", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnLoadImage.ForeColor = System.Drawing.Color.White;
            this.btnLoadImage.Location = new System.Drawing.Point(208, 70);
            this.btnLoadImage.Name = "btnLoadImage";
            this.btnLoadImage.Size = new System.Drawing.Size(180, 32);
            this.btnLoadImage.TabIndex = 4;
            this.btnLoadImage.Text = "📂  载入单张图片";
            this.btnLoadImage.UseVisualStyleBackColor = false;
            this.btnLoadImage.Click += new System.EventHandler(this.btnLoadImage_Click);
            // 
            // btnSingleTrigger
            // 
            this.btnSingleTrigger.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.btnSingleTrigger.FlatAppearance.BorderSize = 0;
            this.btnSingleTrigger.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSingleTrigger.Font = new System.Drawing.Font("微软雅黑", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnSingleTrigger.ForeColor = System.Drawing.Color.White;
            this.btnSingleTrigger.Location = new System.Drawing.Point(14, 70);
            this.btnSingleTrigger.Name = "btnSingleTrigger";
            this.btnSingleTrigger.Size = new System.Drawing.Size(180, 32);
            this.btnSingleTrigger.TabIndex = 3;
            this.btnSingleTrigger.Text = "⚡  单次触发测量";
            this.btnSingleTrigger.UseVisualStyleBackColor = false;
            this.btnSingleTrigger.Click += new System.EventHandler(this.btnSingleTrigger_Click);
            // 
            // btnStop
            // 
            this.btnStop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.btnStop.Enabled = false;
            this.btnStop.FlatAppearance.BorderSize = 0;
            this.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStop.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            this.btnStop.ForeColor = System.Drawing.Color.White;
            this.btnStop.Location = new System.Drawing.Point(208, 30);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(180, 34);
            this.btnStop.TabIndex = 2;
            this.btnStop.Text = "⏹  停止设备";
            this.btnStop.UseVisualStyleBackColor = false;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(124)))), ((int)(((byte)(65)))));
            this.btnStart.FlatAppearance.BorderSize = 0;
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            this.btnStart.ForeColor = System.Drawing.Color.White;
            this.btnStart.Location = new System.Drawing.Point(14, 30);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(180, 34);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "▶  启动连续测量";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lblCtrlHeader
            // 
            this.lblCtrlHeader.AutoSize = true;
            this.lblCtrlHeader.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblCtrlHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(164)))), ((int)(((byte)(239)))));
            this.lblCtrlHeader.Location = new System.Drawing.Point(12, 8);
            this.lblCtrlHeader.Name = "lblCtrlHeader";
            this.lblCtrlHeader.Size = new System.Drawing.Size(113, 19);
            this.lblCtrlHeader.TabIndex = 0;
            this.lblCtrlHeader.Text = "测量操作控制台";
            // 
            // pnlStatistics
            // 
            this.pnlStatistics.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(46)))));
            this.pnlStatistics.Controls.Add(this.lblMinDist);
            this.pnlStatistics.Controls.Add(this.lblMaxDist);
            this.pnlStatistics.Controls.Add(this.btnResetStat);
            this.pnlStatistics.Controls.Add(this.lblAvgDist);
            this.pnlStatistics.Controls.Add(this.lblTotalCount);
            this.pnlStatistics.Controls.Add(this.lblStatHeader);
            this.pnlStatistics.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlStatistics.Location = new System.Drawing.Point(6, 210);
            this.pnlStatistics.Margin = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.pnlStatistics.Name = "pnlStatistics";
            this.pnlStatistics.Padding = new System.Windows.Forms.Padding(12, 8, 12, 8);
            this.pnlStatistics.Size = new System.Drawing.Size(408, 92);
            this.pnlStatistics.TabIndex = 2;
            // 
            // lblMinDist
            // 
            this.lblMinDist.AutoSize = true;
            this.lblMinDist.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.lblMinDist.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(210)))));
            this.lblMinDist.Location = new System.Drawing.Point(145, 58);
            this.lblMinDist.Name = "lblMinDist";
            this.lblMinDist.Size = new System.Drawing.Size(117, 17);
            this.lblMinDist.TabIndex = 8;
            this.lblMinDist.Text = "最小距离: 0.00 px";
            // 
            // lblMaxDist
            // 
            this.lblMaxDist.AutoSize = true;
            this.lblMaxDist.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.lblMaxDist.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(210)))));
            this.lblMaxDist.Location = new System.Drawing.Point(12, 58);
            this.lblMaxDist.Name = "lblMaxDist";
            this.lblMaxDist.Size = new System.Drawing.Size(117, 17);
            this.lblMaxDist.TabIndex = 7;
            this.lblMaxDist.Text = "最大距离: 0.00 px";
            // 
            // btnResetStat
            // 
            this.btnResetStat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnResetStat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(60)))));
            this.btnResetStat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResetStat.Font = new System.Drawing.Font("微软雅黑", 8.5F);
            this.btnResetStat.ForeColor = System.Drawing.Color.White;
            this.btnResetStat.Location = new System.Drawing.Point(308, 48);
            this.btnResetStat.Name = "btnResetStat";
            this.btnResetStat.Size = new System.Drawing.Size(84, 28);
            this.btnResetStat.TabIndex = 6;
            this.btnResetStat.Text = "重置统计";
            this.btnResetStat.UseVisualStyleBackColor = false;
            this.btnResetStat.Click += new System.EventHandler(this.btnResetStat_Click);
            // 
            // lblAvgDist
            // 
            this.lblAvgDist.AutoSize = true;
            this.lblAvgDist.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold);
            this.lblAvgDist.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(230)))), ((int)(((byte)(118)))));
            this.lblAvgDist.Location = new System.Drawing.Point(145, 33);
            this.lblAvgDist.Name = "lblAvgDist";
            this.lblAvgDist.Size = new System.Drawing.Size(118, 17);
            this.lblAvgDist.TabIndex = 4;
            this.lblAvgDist.Text = "平均距离: 0.00 px";
            // 
            // lblTotalCount
            // 
            this.lblTotalCount.AutoSize = true;
            this.lblTotalCount.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.lblTotalCount.ForeColor = System.Drawing.Color.White;
            this.lblTotalCount.Location = new System.Drawing.Point(12, 33);
            this.lblTotalCount.Name = "lblTotalCount";
            this.lblTotalCount.Size = new System.Drawing.Size(99, 17);
            this.lblTotalCount.TabIndex = 1;
            this.lblTotalCount.Text = "累计测量: 0 次";
            // 
            // lblStatHeader
            // 
            this.lblStatHeader.AutoSize = true;
            this.lblStatHeader.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblStatHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(164)))), ((int)(((byte)(239)))));
            this.lblStatHeader.Location = new System.Drawing.Point(12, 8);
            this.lblStatHeader.Name = "lblStatHeader";
            this.lblStatHeader.Size = new System.Drawing.Size(126, 19);
            this.lblStatHeader.TabIndex = 0;
            this.lblStatHeader.Text = "测量数据统计看板";
            // 
            // pnlMeasureValue
            // 
            this.pnlMeasureValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(46)))));
            this.pnlMeasureValue.Controls.Add(this.lblCenterCoord);
            this.pnlMeasureValue.Controls.Add(this.lblDistMmVal);
            this.pnlMeasureValue.Controls.Add(this.lblCostTime);
            this.pnlMeasureValue.Controls.Add(this.lblValHeader);
            this.pnlMeasureValue.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMeasureValue.Location = new System.Drawing.Point(6, 118);
            this.pnlMeasureValue.Margin = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.pnlMeasureValue.Name = "pnlMeasureValue";
            this.pnlMeasureValue.Padding = new System.Windows.Forms.Padding(12, 8, 12, 8);
            this.pnlMeasureValue.Size = new System.Drawing.Size(408, 92);
            this.pnlMeasureValue.TabIndex = 1;
            // 
            // lblCenterCoord
            // 
            this.lblCenterCoord.AutoSize = true;
            this.lblCenterCoord.Font = new System.Drawing.Font("微软雅黑", 8.5F);
            this.lblCenterCoord.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(210)))));
            this.lblCenterCoord.Location = new System.Drawing.Point(12, 60);
            this.lblCenterCoord.Name = "lblCenterCoord";
            this.lblCenterCoord.Size = new System.Drawing.Size(163, 17);
            this.lblCenterCoord.TabIndex = 6;
            this.lblCenterCoord.Text = "圆心坐标: Row: ---, Col: ---";
            // 
            // lblDistMmVal
            // 
            this.lblDistMmVal.AutoSize = true;
            this.lblDistMmVal.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblDistMmVal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(230)))), ((int)(((byte)(118)))));
            this.lblDistMmVal.Location = new System.Drawing.Point(12, 32);
            this.lblDistMmVal.Name = "lblDistMmVal";
            this.lblDistMmVal.Size = new System.Drawing.Size(162, 19);
            this.lblDistMmVal.TabIndex = 5;
            this.lblDistMmVal.Text = "物理尺寸: 0.000 mm";
            // 
            // lblCostTime
            // 
            this.lblCostTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCostTime.Font = new System.Drawing.Font("微软雅黑", 8.5F);
            this.lblCostTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(190)))));
            this.lblCostTime.Location = new System.Drawing.Point(260, 34);
            this.lblCostTime.Name = "lblCostTime";
            this.lblCostTime.Size = new System.Drawing.Size(135, 17);
            this.lblCostTime.TabIndex = 4;
            this.lblCostTime.Text = "CT耗时: 0.0 ms";
            this.lblCostTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblValHeader
            // 
            this.lblValHeader.AutoSize = true;
            this.lblValHeader.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblValHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(164)))), ((int)(((byte)(239)))));
            this.lblValHeader.Location = new System.Drawing.Point(12, 8);
            this.lblValHeader.Name = "lblValHeader";
            this.lblValHeader.Size = new System.Drawing.Size(126, 19);
            this.lblValHeader.TabIndex = 0;
            this.lblValHeader.Text = "特征测量详细数据";
            // 
            // pnlMainDisplayCard
            // 
            this.pnlMainDisplayCard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(36)))), ((int)(((byte)(48)))));
            this.pnlMainDisplayCard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlMainDisplayCard.Controls.Add(this.lblUnitPx);
            this.pnlMainDisplayCard.Controls.Add(this.lblMainDistancePx);
            this.pnlMainDisplayCard.Controls.Add(this.lblCardSubtitle);
            this.pnlMainDisplayCard.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMainDisplayCard.Location = new System.Drawing.Point(6, 8);
            this.pnlMainDisplayCard.Name = "pnlMainDisplayCard";
            this.pnlMainDisplayCard.Size = new System.Drawing.Size(408, 110);
            this.pnlMainDisplayCard.TabIndex = 0;
            // 
            // lblUnitPx
            // 
            this.lblUnitPx.AutoSize = true;
            this.lblUnitPx.Font = new System.Drawing.Font("微软雅黑", 14F, System.Drawing.FontStyle.Bold);
            this.lblUnitPx.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.lblUnitPx.Location = new System.Drawing.Point(318, 48);
            this.lblUnitPx.Name = "lblUnitPx";
            this.lblUnitPx.Size = new System.Drawing.Size(35, 26);
            this.lblUnitPx.TabIndex = 2;
            this.lblUnitPx.Text = "px";
            // 
            // lblMainDistancePx
            // 
            this.lblMainDistancePx.Font = new System.Drawing.Font("Consolas", 34F, System.Drawing.FontStyle.Bold);
            this.lblMainDistancePx.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.lblMainDistancePx.Location = new System.Drawing.Point(10, 32);
            this.lblMainDistancePx.Name = "lblMainDistancePx";
            this.lblMainDistancePx.Size = new System.Drawing.Size(305, 54);
            this.lblMainDistancePx.TabIndex = 1;
            this.lblMainDistancePx.Text = "---";
            this.lblMainDistancePx.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCardSubtitle
            // 
            this.lblCardSubtitle.AutoSize = true;
            this.lblCardSubtitle.Font = new System.Drawing.Font("微软雅黑", 10F, System.Drawing.FontStyle.Bold);
            this.lblCardSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(164)))), ((int)(((byte)(239)))));
            this.lblCardSubtitle.Location = new System.Drawing.Point(12, 8);
            this.lblCardSubtitle.Name = "lblCardSubtitle";
            this.lblCardSubtitle.Size = new System.Drawing.Size(188, 19);
            this.lblCardSubtitle.TabIndex = 0;
            this.lblCardSubtitle.Text = "当前圆心到直线距离 (实时)";
            // 
            // timerClock
            // 
            this.timerClock.Enabled = true;
            this.timerClock.Interval = 1000;
            this.timerClock.Tick += new System.EventHandler(this.timerClock_Tick);
            // 
            // timerCycle
            // 
            this.timerCycle.Interval = 800;
            this.timerCycle.Tick += new System.EventHandler(this.timerCycle_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(24)))));
            this.ClientSize = new System.Drawing.Size(1380, 850);
            this.Controls.Add(this.pnlLeft);
            this.Controls.Add(this.pnlRight);
            this.Controls.Add(this.pnlTop);
            this.MinimumSize = new System.Drawing.Size(1100, 680);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "工业机器视觉圆心到直线距离测量上位机系统";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlLeft.ResumeLayout(false);
            this.pnlViewerContainer.ResumeLayout(false);
            this.pnlViewerToolbar.ResumeLayout(false);
            this.pnlViewerToolbar.PerformLayout();
            this.tabBottom.ResumeLayout(false);
            this.tabHistory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistory)).EndInit();
            this.pnlGridTool.ResumeLayout(false);
            this.tabLogs.ResumeLayout(false);
            this.pnlRight.ResumeLayout(false);
            this.pnlConfig.ResumeLayout(false);
            this.pnlConfig.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numThreshold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numScale)).EndInit();
            this.pnlControls.ResumeLayout(false);
            this.pnlControls.PerformLayout();
            this.pnlStatistics.ResumeLayout(false);
            this.pnlStatistics.PerformLayout();
            this.pnlMeasureValue.ResumeLayout(false);
            this.pnlMeasureValue.PerformLayout();
            this.pnlMainDisplayCard.ResumeLayout(false);
            this.pnlMainDisplayCard.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblStatusDot;
        private System.Windows.Forms.Label lblDeviceStatus;
        private System.Windows.Forms.Label lblSystemTime;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Panel pnlViewerContainer;
        private System.Windows.Forms.Panel pnlViewerToolbar;
        private System.Windows.Forms.Label lblViewTip;
        private System.Windows.Forms.Button btnFitView;
        private System.Windows.Forms.Button btnClearView;
        private System.Windows.Forms.Panel pnlHalcon;
        private System.Windows.Forms.TabControl tabBottom;
        private System.Windows.Forms.TabPage tabHistory;
        private System.Windows.Forms.DataGridView dgvHistory;
        private System.Windows.Forms.Panel pnlGridTool;
        private System.Windows.Forms.Button btnExportCsv;
        private System.Windows.Forms.Button btnClearHistory;
        private System.Windows.Forms.TabPage tabLogs;
        private System.Windows.Forms.RichTextBox rtbLogs;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.Panel pnlMainDisplayCard;
        private System.Windows.Forms.Label lblCardSubtitle;
        private System.Windows.Forms.Label lblMainDistancePx;
        private System.Windows.Forms.Label lblUnitPx;
        private System.Windows.Forms.Panel pnlMeasureValue;
        private System.Windows.Forms.Label lblValHeader;
        private System.Windows.Forms.Label lblDistMmVal;
        private System.Windows.Forms.Label lblCenterCoord;
        private System.Windows.Forms.Label lblCostTime;
        private System.Windows.Forms.Panel pnlStatistics;
        private System.Windows.Forms.Label lblStatHeader;
        private System.Windows.Forms.Label lblTotalCount;
        private System.Windows.Forms.Label lblAvgDist;
        private System.Windows.Forms.Label lblMaxDist;
        private System.Windows.Forms.Label lblMinDist;
        private System.Windows.Forms.Button btnResetStat;
        private System.Windows.Forms.Panel pnlControls;
        private System.Windows.Forms.Label lblCtrlHeader;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnSingleTrigger;
        private System.Windows.Forms.Button btnLoadImage;
        private System.Windows.Forms.Panel pnlConfig;
        private System.Windows.Forms.Label lblConfigHeader;
        private System.Windows.Forms.Label lblDir;
        private System.Windows.Forms.TextBox txtImageDir;
        private System.Windows.Forms.Button btnBrowseDir;
        private System.Windows.Forms.Label lblScale;
        private System.Windows.Forms.NumericUpDown numScale;
        private System.Windows.Forms.Label lblThreshold;
        private System.Windows.Forms.NumericUpDown numThreshold;
        private System.Windows.Forms.Button btnSaveConfig;
        private System.Windows.Forms.Timer timerClock;
        private System.Windows.Forms.Timer timerCycle;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIndex;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colImage;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCenter;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDistPx;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDistMm;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCost;
    }
}
