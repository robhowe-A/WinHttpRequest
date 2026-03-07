//--Copyright (c) 2024-2026 Robert A. Howell

using HttpRequest.Models;
using System.Drawing;
using System.Windows.Forms;

namespace HttpRequest
{
    internal partial class HTTPRequest
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HTTPRequest));
            txtboxUrl = new TextBox();
            label1 = new Label();
            btnFetch = new Button();
            btnExit = new Button();
            label3 = new Label();
            label2 = new Label();
            methodCombo = new ComboBox();
            btnJSON = new Button();
            richTxtData = new RichTextBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            flowLayoutPanel2 = new FlowLayoutPanel();
            btnTest = new Button();
            btnCancel = new Button();
            flowLayoutPanel3 = new FlowLayoutPanel();
            toolStrip1 = new ToolStrip();
            toolStripSeparator1 = new ToolStripSeparator();
            toolStripSplitOptions = new ToolStripSplitButton();
            toolStripMenuItemShowContentHeaders = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            splitContainerMain = new SplitContainer();
            panel1 = new Panel();
            richtxtBody = new TextBox();
            splitContainerFetchData = new SplitContainer();
            flowLayoutPanel1 = new FlowLayoutPanel();
            btnFull = new Button();
            btnClear = new Button();
            btnCopy = new Button();
            tableLayoutPanel1.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            flowLayoutPanel3.SuspendLayout();
            toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainerMain).BeginInit();
            splitContainerMain.Panel1.SuspendLayout();
            splitContainerMain.Panel2.SuspendLayout();
            splitContainerMain.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainerFetchData).BeginInit();
            splitContainerFetchData.Panel1.SuspendLayout();
            splitContainerFetchData.Panel2.SuspendLayout();
            splitContainerFetchData.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // txtboxUrl
            // 
            txtboxUrl.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtboxUrl.Location = new Point(36, 3);
            txtboxUrl.Margin = new Padding(0);
            txtboxUrl.MinimumSize = new Size(375, 0);
            txtboxUrl.Name = "txtboxUrl";
            txtboxUrl.Size = new Size(425, 23);
            txtboxUrl.TabIndex = 2;
            txtboxUrl.TextChanged += urlTextBox_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(9, 6);
            label1.Margin = new Padding(0);
            label1.Name = "label1";
            label1.Size = new Size(22, 15);
            label1.TabIndex = 1;
            label1.Text = "&Url";
            // 
            // btnFetch
            // 
            btnFetch.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnFetch.Location = new Point(19, 157);
            btnFetch.Margin = new Padding(1);
            btnFetch.Name = "btnFetch";
            btnFetch.Size = new Size(58, 23);
            btnFetch.TabIndex = 9;
            btnFetch.Text = "&Fetch";
            btnFetch.UseVisualStyleBackColor = true;
            btnFetch.Click += btnFetch_Click;
            // 
            // btnExit
            // 
            btnExit.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnExit.Location = new Point(585, 628);
            btnExit.Margin = new Padding(10);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(39, 23);
            btnExit.TabIndex = 14;
            btnExit.Text = "E&xit";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(9, 60);
            label3.Margin = new Padding(0);
            label3.Name = "label3";
            label3.Size = new Size(34, 15);
            label3.TabIndex = 7;
            label3.Text = "Body";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(9, 33);
            label2.Margin = new Padding(0);
            label2.Name = "label2";
            label2.Size = new Size(49, 15);
            label2.TabIndex = 3;
            label2.Text = "Method";
            // 
            // methodCombo
            // 
            methodCombo.FormattingEnabled = true;
            methodCombo.Items.AddRange(new object[] { "GET" });
            methodCombo.Location = new Point(63, 30);
            methodCombo.Margin = new Padding(0);
            methodCombo.Name = "methodCombo";
            methodCombo.Size = new Size(121, 23);
            methodCombo.TabIndex = 4;
            methodCombo.SelectedIndexChanged += methodCombo_SelectedIndexChanged;
            // 
            // btnJSON
            // 
            btnJSON.Location = new Point(0, 0);
            btnJSON.Name = "btnJSON";
            btnJSON.Size = new Size(75, 23);
            btnJSON.TabIndex = 0;
            // 
            // richTxtData
            // 
            richTxtData.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            richTxtData.DetectUrls = false;
            richTxtData.HideSelection = false;
            richTxtData.Location = new Point(0, 0);
            richTxtData.Margin = new Padding(0);
            richTxtData.Name = "richTxtData";
            richTxtData.ReadOnly = true;
            richTxtData.ScrollBars = RichTextBoxScrollBars.Vertical;
            richTxtData.Size = new Size(572, 397);
            richTxtData.TabIndex = 10;
            richTxtData.Text = "";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.AutoSize = true;
            tableLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 21.05263F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 78.94737F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 58F));
            tableLayoutPanel1.Controls.Add(flowLayoutPanel2, 1, 3);
            tableLayoutPanel1.Controls.Add(flowLayoutPanel3, 0, 0);
            tableLayoutPanel1.Controls.Add(splitContainerMain, 0, 1);
            tableLayoutPanel1.Controls.Add(btnExit, 2, 3);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 27F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 70F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            tableLayoutPanel1.Size = new Size(634, 661);
            tableLayoutPanel1.TabIndex = 1001;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            flowLayoutPanel2.AutoSize = true;
            flowLayoutPanel2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel2.Controls.Add(btnTest);
            flowLayoutPanel2.Controls.Add(btnCancel);
            flowLayoutPanel2.Location = new Point(122, 611);
            flowLayoutPanel2.Margin = new Padding(1);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(452, 49);
            flowLayoutPanel2.TabIndex = 8;
            // 
            // btnTest
            // 
            btnTest.Enabled = false;
            btnTest.Location = new Point(1, 1);
            btnTest.Margin = new Padding(1);
            btnTest.Name = "btnTest";
            btnTest.Size = new Size(60, 46);
            btnTest.TabIndex = 1;
            btnTest.Text = "Test";
            btnTest.UseVisualStyleBackColor = true;
            btnTest.Visible = false;
            btnTest.Click += btnPing_Click;
            // 
            // btnCancel
            // 
            btnCancel.Enabled = false;
            btnCancel.Location = new Point(63, 1);
            btnCancel.Margin = new Padding(1);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(60, 46);
            btnCancel.TabIndex = 2;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Visible = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // flowLayoutPanel3
            // 
            flowLayoutPanel3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            flowLayoutPanel3.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tableLayoutPanel1.SetColumnSpan(flowLayoutPanel3, 3);
            flowLayoutPanel3.Controls.Add(toolStrip1);
            flowLayoutPanel3.Location = new Point(1, 1);
            flowLayoutPanel3.Margin = new Padding(1);
            flowLayoutPanel3.Name = "flowLayoutPanel3";
            flowLayoutPanel3.Size = new Size(632, 25);
            flowLayoutPanel3.TabIndex = 100;
            // 
            // toolStrip1
            // 
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripSeparator1, toolStripSplitOptions, toolStripSeparator2 });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(89, 25);
            toolStrip1.TabIndex = 1;
            toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 25);
            // 
            // toolStripSplitOptions
            // 
            toolStripSplitOptions.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripSplitOptions.DropDownItems.AddRange(new ToolStripItem[] { toolStripMenuItemShowContentHeaders });
            toolStripSplitOptions.Image = (Image)resources.GetObject("toolStripSplitOptions.Image");
            toolStripSplitOptions.ImageTransparentColor = Color.Magenta;
            toolStripSplitOptions.Name = "toolStripSplitOptions";
            toolStripSplitOptions.Size = new Size(65, 22);
            toolStripSplitOptions.Text = "&Options";
            toolStripSplitOptions.ButtonClick += toolStripSplitButton1_ButtonClick;
            // 
            // toolStripMenuItemShowContentHeaders
            // 
            toolStripMenuItemShowContentHeaders.CheckOnClick = true;
            toolStripMenuItemShowContentHeaders.Name = "toolStripMenuItemShowContentHeaders";
            toolStripMenuItemShowContentHeaders.Size = new Size(195, 22);
            toolStripMenuItemShowContentHeaders.Text = "Show Content Headers";
            toolStripMenuItemShowContentHeaders.Click += toolStripMenuItemShowContentHeaders_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 25);
            // 
            // splitContainerMain
            // 
            splitContainerMain.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.SetColumnSpan(splitContainerMain, 3);
            splitContainerMain.Location = new Point(1, 28);
            splitContainerMain.Margin = new Padding(1);
            splitContainerMain.Name = "splitContainerMain";
            splitContainerMain.Orientation = Orientation.Horizontal;
            // 
            // splitContainerMain.Panel1
            // 
            splitContainerMain.Panel1.Controls.Add(panel1);
            splitContainerMain.Panel1MinSize = 135;
            // 
            // splitContainerMain.Panel2
            // 
            splitContainerMain.Panel2.Controls.Add(splitContainerFetchData);
            splitContainerMain.Panel2MinSize = 60;
            tableLayoutPanel1.SetRowSpan(splitContainerMain, 2);
            splitContainerMain.Size = new Size(632, 581);
            splitContainerMain.SplitterDistance = 180;
            splitContainerMain.TabIndex = 0;
            splitContainerMain.TabStop = false;
            // 
            // panel1
            // 
            panel1.AutoSize = true;
            panel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel1.Controls.Add(richtxtBody);
            panel1.Controls.Add(btnFetch);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(methodCombo);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(txtboxUrl);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(0);
            panel1.MinimumSize = new Size(0, 130);
            panel1.Name = "panel1";
            panel1.Size = new Size(632, 180);
            panel1.TabIndex = 1002;
            // 
            // richtxtBody
            // 
            richtxtBody.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            richtxtBody.Location = new Point(63, 60);
            richtxtBody.MinimumSize = new Size(350, 0);
            richtxtBody.Multiline = true;
            richtxtBody.Name = "richtxtBody";
            richtxtBody.ScrollBars = ScrollBars.Vertical;
            richtxtBody.Size = new Size(400, 94);
            richtxtBody.TabIndex = 8;
            richtxtBody.TextChanged += richtxtBody_TextChanged;
            // 
            // splitContainerFetchData
            // 
            splitContainerFetchData.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            splitContainerFetchData.BackColor = SystemColors.Control;
            splitContainerFetchData.FixedPanel = FixedPanel.Panel2;
            splitContainerFetchData.Location = new Point(0, 0);
            splitContainerFetchData.Margin = new Padding(0);
            splitContainerFetchData.Name = "splitContainerFetchData";
            // 
            // splitContainerFetchData.Panel1
            // 
            splitContainerFetchData.Panel1.Controls.Add(richTxtData);
            // 
            // splitContainerFetchData.Panel2
            // 
            splitContainerFetchData.Panel2.Controls.Add(flowLayoutPanel1);
            splitContainerFetchData.Size = new Size(632, 397);
            splitContainerFetchData.SplitterDistance = 572;
            splitContainerFetchData.TabIndex = 0;
            splitContainerFetchData.TabStop = false;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.BackColor = SystemColors.Control;
            flowLayoutPanel1.Controls.Add(btnFull);
            flowLayoutPanel1.Controls.Add(btnClear);
            flowLayoutPanel1.Controls.Add(btnCopy);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Location = new Point(0, 0);
            flowLayoutPanel1.Margin = new Padding(0);
            flowLayoutPanel1.MaximumSize = new Size(58, 0);
            flowLayoutPanel1.MinimumSize = new Size(58, 0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Padding = new Padding(1);
            flowLayoutPanel1.Size = new Size(58, 397);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // btnFull
            // 
            btnFull.Location = new Point(1, 2);
            btnFull.Margin = new Padding(0, 1, 1, 1);
            btnFull.Name = "btnFull";
            btnFull.Size = new Size(50, 46);
            btnFull.TabIndex = 11;
            btnFull.Text = "FULL";
            btnFull.UseVisualStyleBackColor = true;
            btnFull.Click += btnFull_Click;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(1, 50);
            btnClear.Margin = new Padding(0, 1, 1, 1);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(50, 46);
            btnClear.TabIndex = 12;
            btnClear.Text = "&CLEAR";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // btnCopy
            // 
            btnCopy.Location = new Point(1, 98);
            btnCopy.Margin = new Padding(0, 1, 1, 1);
            btnCopy.Name = "btnCopy";
            btnCopy.Size = new Size(50, 46);
            btnCopy.TabIndex = 13;
            btnCopy.Text = "C&OPY";
            btnCopy.UseVisualStyleBackColor = true;
            btnCopy.Click += btnCopy_Click;
            // 
            // HTTPRequest
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(634, 661);
            Controls.Add(tableLayoutPanel1);
            MaximumSize = new Size(1920, 1920);
            MinimumSize = new Size(450, 225);
            Name = "HTTPRequest";
            Text = "HTTP Request";
            ResizeEnd += HTTPRequest_ResizeEnd;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            flowLayoutPanel2.ResumeLayout(false);
            flowLayoutPanel3.ResumeLayout(false);
            flowLayoutPanel3.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            splitContainerMain.Panel1.ResumeLayout(false);
            splitContainerMain.Panel1.PerformLayout();
            splitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainerMain).EndInit();
            splitContainerMain.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            splitContainerFetchData.Panel1.ResumeLayout(false);
            splitContainerFetchData.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainerFetchData).EndInit();
            splitContainerFetchData.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtboxUrl;
        private Label label1;
        private Button btnFetch;
        private Button btnExit;
        private Label label2;
        private ComboBox methodCombo;
        private Label label3;

        public ToolTip urlToolTip = new();
        public ToolTip dataToolTip = new();
        private ControlException _controlException = new ();
        private Button btnJSON;
        private RichTextBox richTxtData;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel1;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button btnCopy;
        private FlowLayoutPanel flowLayoutPanel2;
        private Button btnTest;
        private Button btnCancel;
        private Button btnClear;
        private FlowLayoutPanel flowLayoutPanel3;
        private SplitContainer splitContainerMain;
        private SplitContainer splitContainerFetchData;
        private Button btnFull;
        private TextBox richtxtBody;
        private ToolStrip toolStrip1;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripSplitButton toolStripSplitOptions;
        private ToolStripMenuItem toolStripMenuItemShowContentHeaders;
        private ToolStripSeparator toolStripSeparator2;
    };
}
