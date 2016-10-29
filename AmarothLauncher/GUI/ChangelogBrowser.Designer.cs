namespace AmarothLauncher.GUI
{
    partial class ChangelogBrowser
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            "12.10.2016 10:45",
            "Test"}, -1);
            this.panelMain = new System.Windows.Forms.SplitContainer();
            this.panelList = new System.Windows.Forms.GroupBox();
            this.listBox = new System.Windows.Forms.ListView();
            this.date = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.heading = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panelRight = new System.Windows.Forms.SplitContainer();
            this.panelTopRight = new System.Windows.Forms.TableLayoutPanel();
            this.panelDescription = new System.Windows.Forms.GroupBox();
            this.descriptionBox = new System.Windows.Forms.RichTextBox();
            this.panelDate = new System.Windows.Forms.GroupBox();
            this.dateBox = new System.Windows.Forms.DateTimePicker();
            this.panelHeading = new System.Windows.Forms.GroupBox();
            this.headingBox = new System.Windows.Forms.TextBox();
            this.panelBottomRight = new System.Windows.Forms.Panel();
            this.panelPicture = new System.Windows.Forms.GroupBox();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.panelMain)).BeginInit();
            this.panelMain.Panel1.SuspendLayout();
            this.panelMain.Panel2.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.panelList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelRight)).BeginInit();
            this.panelRight.Panel1.SuspendLayout();
            this.panelRight.Panel2.SuspendLayout();
            this.panelRight.SuspendLayout();
            this.panelTopRight.SuspendLayout();
            this.panelDescription.SuspendLayout();
            this.panelDate.SuspendLayout();
            this.panelHeading.SuspendLayout();
            this.panelBottomRight.SuspendLayout();
            this.panelPicture.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
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
            this.panelMain.Panel1.Controls.Add(this.panelList);
            // 
            // panelMain.Panel2
            // 
            this.panelMain.Panel2.Controls.Add(this.panelRight);
            this.panelMain.Size = new System.Drawing.Size(884, 562);
            this.panelMain.SplitterDistance = 294;
            this.panelMain.TabIndex = 12;
            // 
            // panelList
            // 
            this.panelList.Controls.Add(this.listBox);
            this.panelList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelList.Location = new System.Drawing.Point(0, 0);
            this.panelList.Name = "panelList";
            this.panelList.Size = new System.Drawing.Size(290, 558);
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
            this.listBox.Size = new System.Drawing.Size(284, 539);
            this.listBox.TabIndex = 0;
            this.listBox.UseCompatibleStateImageBehavior = false;
            this.listBox.View = System.Windows.Forms.View.Details;
            this.listBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.listBox_ItemCheck);
            this.listBox.SelectedIndexChanged += new System.EventHandler(this.listBox_SelectedIndexChanged);
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
            // panelRight
            // 
            this.panelRight.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRight.Location = new System.Drawing.Point(0, 0);
            this.panelRight.Name = "panelRight";
            this.panelRight.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // panelRight.Panel1
            // 
            this.panelRight.Panel1.Controls.Add(this.panelTopRight);
            // 
            // panelRight.Panel2
            // 
            this.panelRight.Panel2.Controls.Add(this.panelBottomRight);
            this.panelRight.Size = new System.Drawing.Size(586, 562);
            this.panelRight.SplitterDistance = 309;
            this.panelRight.TabIndex = 0;
            // 
            // panelTopRight
            // 
            this.panelTopRight.ColumnCount = 2;
            this.panelTopRight.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panelTopRight.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panelTopRight.Controls.Add(this.panelDescription, 0, 1);
            this.panelTopRight.Controls.Add(this.panelDate, 1, 0);
            this.panelTopRight.Controls.Add(this.panelHeading, 0, 0);
            this.panelTopRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTopRight.Location = new System.Drawing.Point(0, 0);
            this.panelTopRight.Name = "panelTopRight";
            this.panelTopRight.RowCount = 2;
            this.panelTopRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.panelTopRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelTopRight.Size = new System.Drawing.Size(582, 305);
            this.panelTopRight.TabIndex = 0;
            // 
            // panelDescription
            // 
            this.panelTopRight.SetColumnSpan(this.panelDescription, 2);
            this.panelDescription.Controls.Add(this.descriptionBox);
            this.panelDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDescription.Location = new System.Drawing.Point(3, 53);
            this.panelDescription.Name = "panelDescription";
            this.panelDescription.Size = new System.Drawing.Size(576, 249);
            this.panelDescription.TabIndex = 4;
            this.panelDescription.TabStop = false;
            this.panelDescription.Text = "Description:";
            // 
            // descriptionBox
            // 
            this.descriptionBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.descriptionBox.Location = new System.Drawing.Point(3, 16);
            this.descriptionBox.Name = "descriptionBox";
            this.descriptionBox.Size = new System.Drawing.Size(570, 230);
            this.descriptionBox.TabIndex = 2;
            this.descriptionBox.Text = "Click on an entry in entries list in order to display it.";
            this.descriptionBox.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.descriptionBox_LinkClicked);
            // 
            // panelDate
            // 
            this.panelDate.Controls.Add(this.dateBox);
            this.panelDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDate.Location = new System.Drawing.Point(294, 3);
            this.panelDate.Name = "panelDate";
            this.panelDate.Size = new System.Drawing.Size(285, 44);
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
            this.dateBox.Size = new System.Drawing.Size(279, 20);
            this.dateBox.TabIndex = 0;
            // 
            // panelHeading
            // 
            this.panelHeading.Controls.Add(this.headingBox);
            this.panelHeading.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelHeading.Location = new System.Drawing.Point(3, 3);
            this.panelHeading.Name = "panelHeading";
            this.panelHeading.Size = new System.Drawing.Size(285, 44);
            this.panelHeading.TabIndex = 6;
            this.panelHeading.TabStop = false;
            this.panelHeading.Text = "Heading:";
            // 
            // headingBox
            // 
            this.headingBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headingBox.Location = new System.Drawing.Point(3, 16);
            this.headingBox.Name = "headingBox";
            this.headingBox.Size = new System.Drawing.Size(279, 20);
            this.headingBox.TabIndex = 0;
            // 
            // panelBottomRight
            // 
            this.panelBottomRight.Controls.Add(this.panelPicture);
            this.panelBottomRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBottomRight.Location = new System.Drawing.Point(0, 0);
            this.panelBottomRight.Name = "panelBottomRight";
            this.panelBottomRight.Padding = new System.Windows.Forms.Padding(3);
            this.panelBottomRight.Size = new System.Drawing.Size(582, 245);
            this.panelBottomRight.TabIndex = 9;
            // 
            // panelPicture
            // 
            this.panelPicture.Controls.Add(this.pictureBox);
            this.panelPicture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPicture.Location = new System.Drawing.Point(3, 3);
            this.panelPicture.Name = "panelPicture";
            this.panelPicture.Size = new System.Drawing.Size(576, 239);
            this.panelPicture.TabIndex = 8;
            this.panelPicture.TabStop = false;
            this.panelPicture.Text = "Picture:";
            // 
            // pictureBox
            // 
            this.pictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox.InitialImage = null;
            this.pictureBox.Location = new System.Drawing.Point(3, 16);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(570, 220);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox.TabIndex = 7;
            this.pictureBox.TabStop = false;
            this.pictureBox.Click += new System.EventHandler(this.pictureBox_Click);
            // 
            // ChangelogBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 562);
            this.Controls.Add(this.panelMain);
            this.MinimumSize = new System.Drawing.Size(900, 600);
            this.Name = "ChangelogBrowser";
            this.Text = "Changelog Browser";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ChangelogBrowser_FormClosing);
            this.Load += new System.EventHandler(this.ChangelogBrowser_Load);
            this.panelMain.Panel1.ResumeLayout(false);
            this.panelMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelMain)).EndInit();
            this.panelMain.ResumeLayout(false);
            this.panelList.ResumeLayout(false);
            this.panelRight.Panel1.ResumeLayout(false);
            this.panelRight.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelRight)).EndInit();
            this.panelRight.ResumeLayout(false);
            this.panelTopRight.ResumeLayout(false);
            this.panelDescription.ResumeLayout(false);
            this.panelDate.ResumeLayout(false);
            this.panelHeading.ResumeLayout(false);
            this.panelHeading.PerformLayout();
            this.panelBottomRight.ResumeLayout(false);
            this.panelPicture.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer panelMain;
        private System.Windows.Forms.GroupBox panelList;
        private System.Windows.Forms.ListView listBox;
        private System.Windows.Forms.ColumnHeader date;
        private System.Windows.Forms.ColumnHeader heading;
        private System.Windows.Forms.SplitContainer panelRight;
        private System.Windows.Forms.TableLayoutPanel panelTopRight;
        private System.Windows.Forms.GroupBox panelDescription;
        private System.Windows.Forms.RichTextBox descriptionBox;
        private System.Windows.Forms.GroupBox panelDate;
        private System.Windows.Forms.DateTimePicker dateBox;
        private System.Windows.Forms.GroupBox panelHeading;
        private System.Windows.Forms.TextBox headingBox;
        private System.Windows.Forms.Panel panelBottomRight;
        private System.Windows.Forms.GroupBox panelPicture;
        private System.Windows.Forms.PictureBox pictureBox;
    }
}