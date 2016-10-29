namespace AmarothLauncher
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("Test");
            this.panelMain = new System.Windows.Forms.SplitContainer();
            this.panelLeftMain = new System.Windows.Forms.TableLayoutPanel();
            this.panelBottomLeft = new System.Windows.Forms.TableLayoutPanel();
            this.panelProgress = new System.Windows.Forms.TableLayoutPanel();
            this.percentLabel = new System.Windows.Forms.Label();
            this.speedLabel = new System.Windows.Forms.Label();
            this.progressLabel = new System.Windows.Forms.Label();
            this.updateButt = new System.Windows.Forms.Button();
            this.checkUpdatesButt = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.newsPictureBox = new System.Windows.Forms.PictureBox();
            this.panelOutput = new System.Windows.Forms.GroupBox();
            this.output = new System.Windows.Forms.RichTextBox();
            this.panelRight = new System.Windows.Forms.TableLayoutPanel();
            this.changelogEditButt = new System.Windows.Forms.Button();
            this.delBackButt = new System.Windows.Forms.Button();
            this.launcherInfoButt = new System.Windows.Forms.Button();
            this.regButt = new System.Windows.Forms.Button();
            this.panelOptional = new System.Windows.Forms.GroupBox();
            this.optionalsListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.webButt = new System.Windows.Forms.Button();
            this.launchButt = new System.Windows.Forms.Button();
            this.changelogBrowserButt = new System.Windows.Forms.Button();
            this.panelTotalSize = new System.Windows.Forms.GroupBox();
            this.totalSizeLabel = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.panelMain)).BeginInit();
            this.panelMain.Panel1.SuspendLayout();
            this.panelMain.Panel2.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.panelLeftMain.SuspendLayout();
            this.panelBottomLeft.SuspendLayout();
            this.panelProgress.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.newsPictureBox)).BeginInit();
            this.panelOutput.SuspendLayout();
            this.panelRight.SuspendLayout();
            this.panelOptional.SuspendLayout();
            this.panelTotalSize.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            // 
            // panelMain.Panel1
            // 
            this.panelMain.Panel1.Controls.Add(this.panelLeftMain);
            // 
            // panelMain.Panel2
            // 
            this.panelMain.Panel2.Controls.Add(this.panelRight);
            this.panelMain.Size = new System.Drawing.Size(884, 562);
            this.panelMain.SplitterDistance = 659;
            this.panelMain.TabIndex = 11;
            this.panelMain.TabStop = false;
            // 
            // panelLeftMain
            // 
            this.panelLeftMain.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.panelLeftMain.ColumnCount = 1;
            this.panelLeftMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelLeftMain.Controls.Add(this.panelBottomLeft, 0, 2);
            this.panelLeftMain.Controls.Add(this.progressBar, 0, 1);
            this.panelLeftMain.Controls.Add(this.splitContainer1, 0, 0);
            this.panelLeftMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLeftMain.Location = new System.Drawing.Point(0, 0);
            this.panelLeftMain.Name = "panelLeftMain";
            this.panelLeftMain.RowCount = 3;
            this.panelLeftMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelLeftMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.panelLeftMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 56F));
            this.panelLeftMain.Size = new System.Drawing.Size(655, 558);
            this.panelLeftMain.TabIndex = 0;
            // 
            // panelBottomLeft
            // 
            this.panelBottomLeft.ColumnCount = 3;
            this.panelBottomLeft.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.panelBottomLeft.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.panelBottomLeft.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.panelBottomLeft.Controls.Add(this.panelProgress, 1, 0);
            this.panelBottomLeft.Controls.Add(this.updateButt, 2, 0);
            this.panelBottomLeft.Controls.Add(this.checkUpdatesButt, 0, 0);
            this.panelBottomLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBottomLeft.Location = new System.Drawing.Point(4, 504);
            this.panelBottomLeft.Name = "panelBottomLeft";
            this.panelBottomLeft.RowCount = 1;
            this.panelBottomLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelBottomLeft.Size = new System.Drawing.Size(647, 50);
            this.panelBottomLeft.TabIndex = 3;
            // 
            // panelProgress
            // 
            this.panelProgress.ColumnCount = 1;
            this.panelProgress.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelProgress.Controls.Add(this.percentLabel, 0, 2);
            this.panelProgress.Controls.Add(this.speedLabel, 0, 1);
            this.panelProgress.Controls.Add(this.progressLabel, 0, 0);
            this.panelProgress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelProgress.Location = new System.Drawing.Point(197, 3);
            this.panelProgress.Name = "panelProgress";
            this.panelProgress.RowCount = 3;
            this.panelProgress.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.panelProgress.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.panelProgress.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.34F));
            this.panelProgress.Size = new System.Drawing.Size(252, 44);
            this.panelProgress.TabIndex = 1;
            // 
            // percentLabel
            // 
            this.percentLabel.AutoSize = true;
            this.percentLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.percentLabel.Location = new System.Drawing.Point(3, 28);
            this.percentLabel.Name = "percentLabel";
            this.percentLabel.Size = new System.Drawing.Size(246, 16);
            this.percentLabel.TabIndex = 6;
            this.percentLabel.Text = "0% (0 MB downloaded, 0 MB remaining)";
            this.percentLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // speedLabel
            // 
            this.speedLabel.AutoSize = true;
            this.speedLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.speedLabel.Location = new System.Drawing.Point(3, 14);
            this.speedLabel.Name = "speedLabel";
            this.speedLabel.Size = new System.Drawing.Size(246, 14);
            this.speedLabel.TabIndex = 5;
            this.speedLabel.Text = "0 KB/s, 0 s remaining";
            this.speedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // progressLabel
            // 
            this.progressLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.progressLabel.Location = new System.Drawing.Point(3, 0);
            this.progressLabel.Name = "progressLabel";
            this.progressLabel.Size = new System.Drawing.Size(246, 14);
            this.progressLabel.TabIndex = 3;
            this.progressLabel.Text = "Downloading: 0 / 0";
            this.progressLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // updateButt
            // 
            this.updateButt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.updateButt.Location = new System.Drawing.Point(455, 3);
            this.updateButt.Name = "updateButt";
            this.updateButt.Size = new System.Drawing.Size(189, 44);
            this.updateButt.TabIndex = 1;
            this.updateButt.Text = "Update";
            this.updateButt.UseVisualStyleBackColor = true;
            this.updateButt.Click += new System.EventHandler(this.updateButt_Click);
            // 
            // checkUpdatesButt
            // 
            this.checkUpdatesButt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkUpdatesButt.Location = new System.Drawing.Point(3, 3);
            this.checkUpdatesButt.Name = "checkUpdatesButt";
            this.checkUpdatesButt.Size = new System.Drawing.Size(188, 44);
            this.checkUpdatesButt.TabIndex = 0;
            this.checkUpdatesButt.Text = "Check for updates";
            this.checkUpdatesButt.UseVisualStyleBackColor = true;
            this.checkUpdatesButt.Click += new System.EventHandler(this.checkUpdatesButt_Click);
            // 
            // progressBar
            // 
            this.progressBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.progressBar.Location = new System.Drawing.Point(7, 467);
            this.progressBar.Margin = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(641, 30);
            this.progressBar.TabIndex = 2;
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(4, 4);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.newsPictureBox);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panelOutput);
            this.splitContainer1.Size = new System.Drawing.Size(647, 456);
            this.splitContainer1.SplitterDistance = 363;
            this.splitContainer1.TabIndex = 12;
            this.splitContainer1.TabStop = false;
            // 
            // newsPictureBox
            // 
            this.newsPictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.newsPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.newsPictureBox.InitialImage = null;
            this.newsPictureBox.Location = new System.Drawing.Point(0, 0);
            this.newsPictureBox.Name = "newsPictureBox";
            this.newsPictureBox.Size = new System.Drawing.Size(643, 359);
            this.newsPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.newsPictureBox.TabIndex = 0;
            this.newsPictureBox.TabStop = false;
            this.newsPictureBox.Click += new System.EventHandler(this.newsPictureBox_Click);
            // 
            // panelOutput
            // 
            this.panelOutput.Controls.Add(this.output);
            this.panelOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelOutput.Location = new System.Drawing.Point(0, 0);
            this.panelOutput.Name = "panelOutput";
            this.panelOutput.Size = new System.Drawing.Size(643, 85);
            this.panelOutput.TabIndex = 14;
            this.panelOutput.TabStop = false;
            this.panelOutput.Text = "Text output:";
            // 
            // output
            // 
            this.output.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.output.Dock = System.Windows.Forms.DockStyle.Fill;
            this.output.Location = new System.Drawing.Point(3, 16);
            this.output.Name = "output";
            this.output.Size = new System.Drawing.Size(637, 66);
            this.output.TabIndex = 10;
            this.output.Text = "";
            this.output.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.output_LinkClicked);
            // 
            // panelRight
            // 
            this.panelRight.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.panelRight.ColumnCount = 1;
            this.panelRight.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelRight.Controls.Add(this.changelogEditButt, 0, 6);
            this.panelRight.Controls.Add(this.delBackButt, 0, 5);
            this.panelRight.Controls.Add(this.launcherInfoButt, 0, 4);
            this.panelRight.Controls.Add(this.regButt, 0, 3);
            this.panelRight.Controls.Add(this.panelOptional, 0, 0);
            this.panelRight.Controls.Add(this.webButt, 0, 2);
            this.panelRight.Controls.Add(this.launchButt, 0, 8);
            this.panelRight.Controls.Add(this.changelogBrowserButt, 0, 7);
            this.panelRight.Controls.Add(this.panelTotalSize, 0, 1);
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRight.Location = new System.Drawing.Point(0, 0);
            this.panelRight.Name = "panelRight";
            this.panelRight.RowCount = 9;
            this.panelRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.panelRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.panelRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.panelRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.panelRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.panelRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.panelRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.panelRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.panelRight.Size = new System.Drawing.Size(217, 558);
            this.panelRight.TabIndex = 0;
            // 
            // changelogEditButt
            // 
            this.changelogEditButt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.changelogEditButt.Location = new System.Drawing.Point(4, 408);
            this.changelogEditButt.Name = "changelogEditButt";
            this.changelogEditButt.Size = new System.Drawing.Size(209, 24);
            this.changelogEditButt.TabIndex = 8;
            this.changelogEditButt.Text = "Changelog editor";
            this.changelogEditButt.UseVisualStyleBackColor = true;
            this.changelogEditButt.Click += new System.EventHandler(this.changelogEditButt_Click);
            // 
            // delBackButt
            // 
            this.delBackButt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.delBackButt.Location = new System.Drawing.Point(4, 377);
            this.delBackButt.Name = "delBackButt";
            this.delBackButt.Size = new System.Drawing.Size(209, 24);
            this.delBackButt.TabIndex = 7;
            this.delBackButt.Text = "Delete .ext_ backups";
            this.delBackButt.UseVisualStyleBackColor = true;
            this.delBackButt.Click += new System.EventHandler(this.delBackButt_Click);
            // 
            // launcherInfoButt
            // 
            this.launcherInfoButt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.launcherInfoButt.Location = new System.Drawing.Point(4, 346);
            this.launcherInfoButt.Name = "launcherInfoButt";
            this.launcherInfoButt.Size = new System.Drawing.Size(209, 24);
            this.launcherInfoButt.TabIndex = 6;
            this.launcherInfoButt.Text = "Launcher manual";
            this.launcherInfoButt.UseVisualStyleBackColor = true;
            this.launcherInfoButt.Click += new System.EventHandler(this.launcherInfoButt_Click);
            // 
            // regButt
            // 
            this.regButt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.regButt.Location = new System.Drawing.Point(4, 315);
            this.regButt.Name = "regButt";
            this.regButt.Size = new System.Drawing.Size(209, 24);
            this.regButt.TabIndex = 5;
            this.regButt.Text = "Registration";
            this.regButt.UseVisualStyleBackColor = true;
            this.regButt.Click += new System.EventHandler(this.regButt_Click);
            // 
            // panelOptional
            // 
            this.panelOptional.Controls.Add(this.optionalsListView);
            this.panelOptional.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelOptional.Location = new System.Drawing.Point(4, 4);
            this.panelOptional.Name = "panelOptional";
            this.panelOptional.Size = new System.Drawing.Size(209, 212);
            this.panelOptional.TabIndex = 15;
            this.panelOptional.TabStop = false;
            this.panelOptional.Text = "Optional files:";
            // 
            // optionalsListView
            // 
            this.optionalsListView.CheckBoxes = true;
            this.optionalsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.optionalsListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.optionalsListView.FullRowSelect = true;
            this.optionalsListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            listViewItem1.StateImageIndex = 0;
            listViewItem1.ToolTipText = "!!!";
            this.optionalsListView.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.optionalsListView.Location = new System.Drawing.Point(3, 16);
            this.optionalsListView.MultiSelect = false;
            this.optionalsListView.Name = "optionalsListView";
            this.optionalsListView.ShowItemToolTips = true;
            this.optionalsListView.Size = new System.Drawing.Size(203, 193);
            this.optionalsListView.TabIndex = 10;
            this.optionalsListView.UseCompatibleStateImageBehavior = false;
            this.optionalsListView.View = System.Windows.Forms.View.List;
            this.optionalsListView.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.optionalsListView_ItemChecked);
            this.optionalsListView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.optionalsListView_MouseClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 1000;
            // 
            // webButt
            // 
            this.webButt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webButt.Location = new System.Drawing.Point(4, 284);
            this.webButt.Name = "webButt";
            this.webButt.Size = new System.Drawing.Size(209, 24);
            this.webButt.TabIndex = 4;
            this.webButt.Text = "Project webpage";
            this.webButt.UseVisualStyleBackColor = true;
            this.webButt.Click += new System.EventHandler(this.webButt_Click);
            // 
            // launchButt
            // 
            this.launchButt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.launchButt.Location = new System.Drawing.Point(4, 490);
            this.launchButt.Name = "launchButt";
            this.launchButt.Size = new System.Drawing.Size(209, 64);
            this.launchButt.TabIndex = 3;
            this.launchButt.Text = "Launch";
            this.launchButt.UseVisualStyleBackColor = true;
            this.launchButt.Click += new System.EventHandler(this.launchButt_Click);
            // 
            // changelogBrowserButt
            // 
            this.changelogBrowserButt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.changelogBrowserButt.Location = new System.Drawing.Point(4, 439);
            this.changelogBrowserButt.Name = "changelogBrowserButt";
            this.changelogBrowserButt.Size = new System.Drawing.Size(209, 44);
            this.changelogBrowserButt.TabIndex = 9;
            this.changelogBrowserButt.Text = "Changelog browser";
            this.changelogBrowserButt.UseVisualStyleBackColor = true;
            this.changelogBrowserButt.Click += new System.EventHandler(this.changelogBrowserButt_Click);
            // 
            // panelTotalSize
            // 
            this.panelTotalSize.Controls.Add(this.totalSizeLabel);
            this.panelTotalSize.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTotalSize.Location = new System.Drawing.Point(4, 223);
            this.panelTotalSize.Name = "panelTotalSize";
            this.panelTotalSize.Size = new System.Drawing.Size(209, 54);
            this.panelTotalSize.TabIndex = 13;
            this.panelTotalSize.TabStop = false;
            this.panelTotalSize.Text = "Total size of outdated:";
            // 
            // totalSizeLabel
            // 
            this.totalSizeLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.totalSizeLabel.Location = new System.Drawing.Point(3, 16);
            this.totalSizeLabel.Name = "totalSizeLabel";
            this.totalSizeLabel.Size = new System.Drawing.Size(203, 35);
            this.totalSizeLabel.TabIndex = 10;
            this.totalSizeLabel.Text = "Chosen optionals: \r\nNon-optionals: ";
            this.totalSizeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 562);
            this.Controls.Add(this.panelMain);
            this.MinimumSize = new System.Drawing.Size(800, 450);
            this.Name = "MainWindow";
            this.Text = "Amaroth\'s Launcher";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.panelMain.Panel1.ResumeLayout(false);
            this.panelMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelMain)).EndInit();
            this.panelMain.ResumeLayout(false);
            this.panelLeftMain.ResumeLayout(false);
            this.panelBottomLeft.ResumeLayout(false);
            this.panelProgress.ResumeLayout(false);
            this.panelProgress.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.newsPictureBox)).EndInit();
            this.panelOutput.ResumeLayout(false);
            this.panelRight.ResumeLayout(false);
            this.panelOptional.ResumeLayout(false);
            this.panelTotalSize.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer panelMain;
        private System.Windows.Forms.TableLayoutPanel panelLeftMain;
        private System.Windows.Forms.GroupBox panelOutput;
        private System.Windows.Forms.RichTextBox output;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.TableLayoutPanel panelBottomLeft;
        private System.Windows.Forms.TableLayoutPanel panelProgress;
        private System.Windows.Forms.Label percentLabel;
        private System.Windows.Forms.Label speedLabel;
        private System.Windows.Forms.Label progressLabel;
        private System.Windows.Forms.Button updateButt;
        private System.Windows.Forms.Button checkUpdatesButt;
        private System.Windows.Forms.TableLayoutPanel panelRight;
        private System.Windows.Forms.Button changelogBrowserButt;
        private System.Windows.Forms.Button delBackButt;
        private System.Windows.Forms.Button launcherInfoButt;
        private System.Windows.Forms.Button regButt;
        private System.Windows.Forms.GroupBox panelOptional;
        private System.Windows.Forms.Button webButt;
        private System.Windows.Forms.Button launchButt;
        private System.Windows.Forms.Button changelogEditButt;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.ListView optionalsListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Label totalSizeLabel;
        private System.Windows.Forms.GroupBox panelTotalSize;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.PictureBox newsPictureBox;
    }
}

