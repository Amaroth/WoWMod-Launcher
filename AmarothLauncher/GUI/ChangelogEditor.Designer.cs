namespace AmarothLauncher.GUI
{
    partial class ChangelogEditor
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            "12.10.2016 10:45",
            "Test"}, -1);
            this.panelMain = new System.Windows.Forms.SplitContainer();
            this.leftPanel = new System.Windows.Forms.TableLayoutPanel();
            this.createEntryButt = new System.Windows.Forms.Button();
            this.delEntryButt = new System.Windows.Forms.Button();
            this.editEntryButt = new System.Windows.Forms.Button();
            this.panelList = new System.Windows.Forms.GroupBox();
            this.listBox = new System.Windows.Forms.ListView();
            this.date = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.heading = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.rightSplitter = new System.Windows.Forms.SplitContainer();
            this.rightTopPanel = new System.Windows.Forms.TableLayoutPanel();
            this.panelDate = new System.Windows.Forms.GroupBox();
            this.dateBox = new System.Windows.Forms.DateTimePicker();
            this.saveEntryButt = new System.Windows.Forms.Button();
            this.panelPictureURL = new System.Windows.Forms.GroupBox();
            this.pictureURLBox = new System.Windows.Forms.TextBox();
            this.testPictureButt = new System.Windows.Forms.Button();
            this.panelPicturePreveiw = new System.Windows.Forms.GroupBox();
            this.picturePreviewBox = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panelDescription = new System.Windows.Forms.GroupBox();
            this.descriptionBox = new System.Windows.Forms.RichTextBox();
            this.panelHeading = new System.Windows.Forms.GroupBox();
            this.headingBox = new System.Windows.Forms.TextBox();
            this.rightBotPanel = new System.Windows.Forms.TableLayoutPanel();
            this.saveButt = new System.Windows.Forms.Button();
            this.cancelButt = new System.Windows.Forms.Button();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.panelMain)).BeginInit();
            this.panelMain.Panel1.SuspendLayout();
            this.panelMain.Panel2.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.leftPanel.SuspendLayout();
            this.panelList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rightSplitter)).BeginInit();
            this.rightSplitter.Panel1.SuspendLayout();
            this.rightSplitter.Panel2.SuspendLayout();
            this.rightSplitter.SuspendLayout();
            this.rightTopPanel.SuspendLayout();
            this.panelDate.SuspendLayout();
            this.panelPictureURL.SuspendLayout();
            this.panelPicturePreveiw.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picturePreviewBox)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panelDescription.SuspendLayout();
            this.panelHeading.SuspendLayout();
            this.rightBotPanel.SuspendLayout();
            this.contextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.IsSplitterFixed = true;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            // 
            // panelMain.Panel1
            // 
            this.panelMain.Panel1.Controls.Add(this.leftPanel);
            // 
            // panelMain.Panel2
            // 
            this.panelMain.Panel2.Controls.Add(this.rightSplitter);
            this.panelMain.Size = new System.Drawing.Size(884, 562);
            this.panelMain.SplitterDistance = 294;
            this.panelMain.TabIndex = 11;
            // 
            // leftPanel
            // 
            this.leftPanel.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.leftPanel.ColumnCount = 1;
            this.leftPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.leftPanel.Controls.Add(this.createEntryButt, 0, 3);
            this.leftPanel.Controls.Add(this.delEntryButt, 0, 2);
            this.leftPanel.Controls.Add(this.editEntryButt, 0, 1);
            this.leftPanel.Controls.Add(this.panelList, 0, 0);
            this.leftPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.leftPanel.Location = new System.Drawing.Point(0, 0);
            this.leftPanel.Name = "leftPanel";
            this.leftPanel.RowCount = 4;
            this.leftPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.leftPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.leftPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.leftPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.leftPanel.Size = new System.Drawing.Size(290, 558);
            this.leftPanel.TabIndex = 0;
            // 
            // createEntryButt
            // 
            this.createEntryButt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.createEntryButt.Location = new System.Drawing.Point(4, 525);
            this.createEntryButt.Name = "createEntryButt";
            this.createEntryButt.Size = new System.Drawing.Size(282, 29);
            this.createEntryButt.TabIndex = 1;
            this.createEntryButt.Text = "Create entry";
            this.createEntryButt.UseVisualStyleBackColor = true;
            this.createEntryButt.Click += new System.EventHandler(this.addEntryButt_Click);
            // 
            // delEntryButt
            // 
            this.delEntryButt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.delEntryButt.Location = new System.Drawing.Point(4, 489);
            this.delEntryButt.Name = "delEntryButt";
            this.delEntryButt.Size = new System.Drawing.Size(282, 29);
            this.delEntryButt.TabIndex = 5;
            this.delEntryButt.Text = "Delete entry";
            this.delEntryButt.UseVisualStyleBackColor = true;
            this.delEntryButt.Click += new System.EventHandler(this.delEntryButt_Click);
            // 
            // editEntryButt
            // 
            this.editEntryButt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editEntryButt.Location = new System.Drawing.Point(4, 453);
            this.editEntryButt.Name = "editEntryButt";
            this.editEntryButt.Size = new System.Drawing.Size(282, 29);
            this.editEntryButt.TabIndex = 0;
            this.editEntryButt.Text = "Edit entry";
            this.editEntryButt.UseVisualStyleBackColor = true;
            this.editEntryButt.Click += new System.EventHandler(this.editEntryButt_Click);
            // 
            // panelList
            // 
            this.panelList.Controls.Add(this.listBox);
            this.panelList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelList.Location = new System.Drawing.Point(4, 4);
            this.panelList.Name = "panelList";
            this.panelList.Size = new System.Drawing.Size(282, 442);
            this.panelList.TabIndex = 4;
            this.panelList.TabStop = false;
            this.panelList.Text = "Changelog entries:";
            // 
            // listBox
            // 
            this.listBox.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.date,
            this.heading});
            this.listBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox.FullRowSelect = true;
            this.listBox.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.listBox.Location = new System.Drawing.Point(3, 16);
            this.listBox.MultiSelect = false;
            this.listBox.Name = "listBox";
            this.listBox.ShowItemToolTips = true;
            this.listBox.Size = new System.Drawing.Size(276, 423);
            this.listBox.TabIndex = 1;
            this.listBox.UseCompatibleStateImageBehavior = false;
            this.listBox.View = System.Windows.Forms.View.Details;
            this.listBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.listBox_KeyUp);
            this.listBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listBox_MouseClick);
            this.listBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBox_MouseDoubleClick);
            // 
            // date
            // 
            this.date.Text = "Date";
            this.date.Width = 104;
            // 
            // heading
            // 
            this.heading.Text = "Heading";
            this.heading.Width = 159;
            // 
            // rightSplitter
            // 
            this.rightSplitter.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.rightSplitter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rightSplitter.IsSplitterFixed = true;
            this.rightSplitter.Location = new System.Drawing.Point(0, 0);
            this.rightSplitter.Name = "rightSplitter";
            this.rightSplitter.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // rightSplitter.Panel1
            // 
            this.rightSplitter.Panel1.Controls.Add(this.rightTopPanel);
            // 
            // rightSplitter.Panel2
            // 
            this.rightSplitter.Panel2.Controls.Add(this.rightBotPanel);
            this.rightSplitter.Size = new System.Drawing.Size(586, 562);
            this.rightSplitter.SplitterDistance = 499;
            this.rightSplitter.TabIndex = 0;
            // 
            // rightTopPanel
            // 
            this.rightTopPanel.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.rightTopPanel.ColumnCount = 2;
            this.rightTopPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.rightTopPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.rightTopPanel.Controls.Add(this.panelDate, 0, 0);
            this.rightTopPanel.Controls.Add(this.saveEntryButt, 0, 2);
            this.rightTopPanel.Controls.Add(this.panelPictureURL, 1, 0);
            this.rightTopPanel.Controls.Add(this.testPictureButt, 1, 2);
            this.rightTopPanel.Controls.Add(this.panelPicturePreveiw, 1, 1);
            this.rightTopPanel.Controls.Add(this.tableLayoutPanel1, 0, 1);
            this.rightTopPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rightTopPanel.Location = new System.Drawing.Point(0, 0);
            this.rightTopPanel.Name = "rightTopPanel";
            this.rightTopPanel.RowCount = 3;
            this.rightTopPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.rightTopPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.rightTopPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.rightTopPanel.Size = new System.Drawing.Size(582, 495);
            this.rightTopPanel.TabIndex = 0;
            // 
            // panelDate
            // 
            this.panelDate.Controls.Add(this.dateBox);
            this.panelDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDate.Location = new System.Drawing.Point(4, 4);
            this.panelDate.Name = "panelDate";
            this.panelDate.Size = new System.Drawing.Size(283, 44);
            this.panelDate.TabIndex = 1;
            this.panelDate.TabStop = false;
            this.panelDate.Text = "Date:";
            // 
            // dateBox
            // 
            this.dateBox.CustomFormat = "dd.MM.yyyy hh:mm";
            this.dateBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dateBox.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateBox.Location = new System.Drawing.Point(3, 16);
            this.dateBox.Name = "dateBox";
            this.dateBox.Size = new System.Drawing.Size(277, 20);
            this.dateBox.TabIndex = 0;
            // 
            // saveEntryButt
            // 
            this.saveEntryButt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.saveEntryButt.Location = new System.Drawing.Point(4, 462);
            this.saveEntryButt.Name = "saveEntryButt";
            this.saveEntryButt.Size = new System.Drawing.Size(283, 29);
            this.saveEntryButt.TabIndex = 9;
            this.saveEntryButt.Text = "Save entry";
            this.saveEntryButt.UseVisualStyleBackColor = true;
            this.saveEntryButt.Click += new System.EventHandler(this.saveEntryButt_Click);
            // 
            // panelPictureURL
            // 
            this.panelPictureURL.Controls.Add(this.pictureURLBox);
            this.panelPictureURL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPictureURL.Location = new System.Drawing.Point(294, 4);
            this.panelPictureURL.Name = "panelPictureURL";
            this.panelPictureURL.Size = new System.Drawing.Size(284, 44);
            this.panelPictureURL.TabIndex = 0;
            this.panelPictureURL.TabStop = false;
            this.panelPictureURL.Text = "Picture URL:";
            // 
            // pictureURLBox
            // 
            this.pictureURLBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureURLBox.Location = new System.Drawing.Point(3, 16);
            this.pictureURLBox.Name = "pictureURLBox";
            this.pictureURLBox.Size = new System.Drawing.Size(278, 20);
            this.pictureURLBox.TabIndex = 0;
            this.pictureURLBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.pictureURLBox_KeyUp);
            // 
            // testPictureButt
            // 
            this.testPictureButt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.testPictureButt.Location = new System.Drawing.Point(294, 462);
            this.testPictureButt.Name = "testPictureButt";
            this.testPictureButt.Size = new System.Drawing.Size(284, 29);
            this.testPictureButt.TabIndex = 6;
            this.testPictureButt.Text = "Test picture";
            this.testPictureButt.UseVisualStyleBackColor = true;
            this.testPictureButt.Click += new System.EventHandler(this.testPictureButt_Click);
            // 
            // panelPicturePreveiw
            // 
            this.panelPicturePreveiw.Controls.Add(this.picturePreviewBox);
            this.panelPicturePreveiw.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPicturePreveiw.Location = new System.Drawing.Point(294, 55);
            this.panelPicturePreveiw.Name = "panelPicturePreveiw";
            this.panelPicturePreveiw.Size = new System.Drawing.Size(284, 400);
            this.panelPicturePreveiw.TabIndex = 8;
            this.panelPicturePreveiw.TabStop = false;
            this.panelPicturePreveiw.Text = "Picture preview:";
            // 
            // picturePreviewBox
            // 
            this.picturePreviewBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picturePreviewBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picturePreviewBox.InitialImage = null;
            this.picturePreviewBox.Location = new System.Drawing.Point(3, 16);
            this.picturePreviewBox.Name = "picturePreviewBox";
            this.picturePreviewBox.Size = new System.Drawing.Size(278, 381);
            this.picturePreviewBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picturePreviewBox.TabIndex = 7;
            this.picturePreviewBox.TabStop = false;
            this.picturePreviewBox.Click += new System.EventHandler(this.picturePreviewBox_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panelDescription, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panelHeading, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(4, 55);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 87F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(283, 400);
            this.tableLayoutPanel1.TabIndex = 10;
            // 
            // panelDescription
            // 
            this.panelDescription.Controls.Add(this.descriptionBox);
            this.panelDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDescription.Location = new System.Drawing.Point(3, 55);
            this.panelDescription.Name = "panelDescription";
            this.panelDescription.Size = new System.Drawing.Size(277, 342);
            this.panelDescription.TabIndex = 4;
            this.panelDescription.TabStop = false;
            this.panelDescription.Text = "Description:";
            // 
            // descriptionBox
            // 
            this.descriptionBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.descriptionBox.Location = new System.Drawing.Point(3, 16);
            this.descriptionBox.Name = "descriptionBox";
            this.descriptionBox.Size = new System.Drawing.Size(271, 323);
            this.descriptionBox.TabIndex = 2;
            this.descriptionBox.Text = "";
            this.descriptionBox.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.descriptionBox_LinkClicked);
            // 
            // panelHeading
            // 
            this.panelHeading.Controls.Add(this.headingBox);
            this.panelHeading.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelHeading.Location = new System.Drawing.Point(3, 3);
            this.panelHeading.Name = "panelHeading";
            this.panelHeading.Size = new System.Drawing.Size(277, 46);
            this.panelHeading.TabIndex = 6;
            this.panelHeading.TabStop = false;
            this.panelHeading.Text = "Heading:";
            // 
            // headingBox
            // 
            this.headingBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headingBox.Location = new System.Drawing.Point(3, 16);
            this.headingBox.Name = "headingBox";
            this.headingBox.Size = new System.Drawing.Size(271, 20);
            this.headingBox.TabIndex = 0;
            // 
            // rightBotPanel
            // 
            this.rightBotPanel.ColumnCount = 2;
            this.rightBotPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.rightBotPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.rightBotPanel.Controls.Add(this.saveButt, 1, 0);
            this.rightBotPanel.Controls.Add(this.cancelButt, 0, 0);
            this.rightBotPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rightBotPanel.Location = new System.Drawing.Point(0, 0);
            this.rightBotPanel.Name = "rightBotPanel";
            this.rightBotPanel.RowCount = 1;
            this.rightBotPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.rightBotPanel.Size = new System.Drawing.Size(582, 55);
            this.rightBotPanel.TabIndex = 0;
            // 
            // saveButt
            // 
            this.saveButt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.saveButt.Location = new System.Drawing.Point(294, 3);
            this.saveButt.Name = "saveButt";
            this.saveButt.Size = new System.Drawing.Size(285, 49);
            this.saveButt.TabIndex = 11;
            this.saveButt.Text = "Save changelog";
            this.saveButt.UseVisualStyleBackColor = true;
            this.saveButt.Click += new System.EventHandler(this.saveButt_Click);
            // 
            // cancelButt
            // 
            this.cancelButt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cancelButt.Location = new System.Drawing.Point(3, 3);
            this.cancelButt.Name = "cancelButt";
            this.cancelButt.Size = new System.Drawing.Size(285, 49);
            this.cancelButt.TabIndex = 12;
            this.cancelButt.Text = "Cancel changes";
            this.cancelButt.UseVisualStyleBackColor = true;
            this.cancelButt.Click += new System.EventHandler(this.cancelButt_Click);
            // 
            // contextMenu
            // 
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editItem,
            this.deleteItem});
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.Size = new System.Drawing.Size(138, 48);
            this.contextMenu.Text = "Záznam";
            // 
            // editItem
            // 
            this.editItem.Name = "editItem";
            this.editItem.Size = new System.Drawing.Size(137, 22);
            this.editItem.Text = "Edit entry";
            // 
            // deleteItem
            // 
            this.deleteItem.Name = "deleteItem";
            this.deleteItem.Size = new System.Drawing.Size(137, 22);
            this.deleteItem.Text = "Delete entry";
            // 
            // ChangelogEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 562);
            this.Controls.Add(this.panelMain);
            this.MinimumSize = new System.Drawing.Size(900, 600);
            this.Name = "ChangelogEditor";
            this.Text = "Changelog Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ChangelogEditor_FormClosing);
            this.Load += new System.EventHandler(this.ChangelogEditor_Load);
            this.panelMain.Panel1.ResumeLayout(false);
            this.panelMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelMain)).EndInit();
            this.panelMain.ResumeLayout(false);
            this.leftPanel.ResumeLayout(false);
            this.panelList.ResumeLayout(false);
            this.rightSplitter.Panel1.ResumeLayout(false);
            this.rightSplitter.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rightSplitter)).EndInit();
            this.rightSplitter.ResumeLayout(false);
            this.rightTopPanel.ResumeLayout(false);
            this.panelDate.ResumeLayout(false);
            this.panelPictureURL.ResumeLayout(false);
            this.panelPictureURL.PerformLayout();
            this.panelPicturePreveiw.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picturePreviewBox)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panelDescription.ResumeLayout(false);
            this.panelHeading.ResumeLayout(false);
            this.panelHeading.PerformLayout();
            this.rightBotPanel.ResumeLayout(false);
            this.contextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer panelMain;
        private System.Windows.Forms.TableLayoutPanel leftPanel;
        private System.Windows.Forms.Button createEntryButt;
        private System.Windows.Forms.Button delEntryButt;
        private System.Windows.Forms.Button editEntryButt;
        private System.Windows.Forms.GroupBox panelList;
        private System.Windows.Forms.SplitContainer rightSplitter;
        private System.Windows.Forms.TableLayoutPanel rightTopPanel;
        private System.Windows.Forms.GroupBox panelDate;
        private System.Windows.Forms.DateTimePicker dateBox;
        private System.Windows.Forms.Button saveEntryButt;
        private System.Windows.Forms.GroupBox panelPictureURL;
        private System.Windows.Forms.TextBox pictureURLBox;
        private System.Windows.Forms.Button testPictureButt;
        private System.Windows.Forms.GroupBox panelPicturePreveiw;
        private System.Windows.Forms.PictureBox picturePreviewBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox panelDescription;
        private System.Windows.Forms.RichTextBox descriptionBox;
        private System.Windows.Forms.GroupBox panelHeading;
        private System.Windows.Forms.TextBox headingBox;
        private System.Windows.Forms.TableLayoutPanel rightBotPanel;
        private System.Windows.Forms.Button saveButt;
        private System.Windows.Forms.Button cancelButt;
        private System.Windows.Forms.ListView listBox;
        private System.Windows.Forms.ColumnHeader date;
        private System.Windows.Forms.ColumnHeader heading;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem editItem;
        private System.Windows.Forms.ToolStripMenuItem deleteItem;
    }
}