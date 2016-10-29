using AmarothLauncher.Core;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace AmarothLauncher.GUI
{
    public partial class ChangelogEditor : Form
    {
        OutputWriter o = OutputWriter.Instance;
        Config c = Config.Instance;
        public MainWindow mainWindow;

        Changelog changelog;
        int editedID = -1;
        bool isEditedDeleted = false;

        bool wasUploadSucces = false;

        public ChangelogEditor()
        {
            InitializeComponent();
        }

        #region Methods...
        /// <summary>
        /// Sets values of window elements to values set in config.
        /// </summary>
        private void LoadConfig()
        {
            Icon = new Icon("LauncherIcon.ico");
            Text = c.SubElText("ChangelogEditor", "WindowName");
            panelList.Text = c.SubElText("ChangelogEditor", "ChangelogEntries");
            listBox.Columns[0].Text = c.SubElText("ChangelogEditor", "DateColumn");
            listBox.Columns[1].Text = c.SubElText("ChangelogEditor", "HeadingColumn");
            panelDate.Text = c.SubElText("ChangelogEditor", "Date");
            dateBox.CustomFormat = c.SubElText("ChangelogEditor", "DateFormat");
            panelPictureURL.Text = c.SubElText("ChangelogEditor", "PictureURL");
            panelHeading.Text = c.SubElText("ChangelogEditor", "Heading");
            panelPicturePreveiw.Text = c.SubElText("ChangelogEditor", "PicturePreview");
            panelDescription.Text = c.SubElText("ChangelogEditor", "Description");
            editEntryButt.Text = c.SubElText("ChangelogEditor", "EditEntryButton");
            contextMenu.Items[0].Text = c.SubElText("ChangelogEditor", "EditEntryButton");
            delEntryButt.Text = c.SubElText("ChangelogEditor", "DeleteEntryButton");
            contextMenu.Items[1].Text = c.SubElText("ChangelogEditor", "DeleteEntryButton");
            createEntryButt.Text = c.SubElText("ChangelogEditor", "CreateEntryButton");
            saveEntryButt.Text = c.SubElText("ChangelogEditor", "SaveEntryButton");
            testPictureButt.Text = c.SubElText("ChangelogEditor", "TestPictureButton");
            cancelButt.Text = c.SubElText("ChangelogEditor", "CancelButton");
            saveButt.Text = c.SubElText("ChangelogEditor", "SaveButton");
        }

        /// <summary>
        /// Updates a list by getting current changelog version.
        /// </summary>
        private void UpdateListView()
        {
            listBox.Items.Clear();
            changelog.SortXml(dateBox.CustomFormat);
            for (int i = 0; i < changelog.GetAmount(); i++)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = changelog.GetDate(i);
                lvi.ToolTipText = changelog.GetText(i);
                lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, changelog.GetHeading(i)));
                listBox.Items.Add(lvi);
            }
        }

        /// <summary>
        /// Uploads saved changelog.xml to FTP.
        /// </summary>
        private void UploadChangelog()
        {
            FtpWebRequest ftpRequest = null;
            Stream ftpStream = null;
            int bufferSize = 2048;

            try
            {
                ftpRequest = (FtpWebRequest)WebRequest.Create(c.SubElText("Paths", "ChangelogFTPPath") + "changelog.xml");
                ftpRequest.Credentials = new NetworkCredential(mainWindow.login, mainWindow.password);
                ftpRequest.UseBinary = true;
                ftpRequest.UsePassive = true;
                ftpRequest.KeepAlive = true;
                ftpRequest.Method = WebRequestMethods.Ftp.UploadFile;
                ftpStream = ftpRequest.GetRequestStream();
                FileStream localFileStream = new FileStream(Directory.GetCurrentDirectory() + @"\changelog.xml", FileMode.Open);
                byte[] byteBuffer = new byte[bufferSize];
                int bytesSent = localFileStream.Read(byteBuffer, 0, bufferSize);
                try
                {
                    while (bytesSent != 0)
                    {
                        ftpStream.Write(byteBuffer, 0, bytesSent);
                        bytesSent = localFileStream.Read(byteBuffer, 0, bufferSize);
                    }
                }
                catch (Exception ex) { o.Messagebox(ex.Message); }
                localFileStream.Close();
                ftpStream.Close();
                ftpRequest = null;
                wasUploadSucces = true;
            }
            catch (Exception ex) { o.Messagebox(c.SubElText("Messages", "ChangelogNotUploaded"), ex); }
        }
        #endregion

        #region Event handlers...
        /// <summary>
        /// Opens changelog entry and ensures that when its saved, it overwrites original entry.
        /// </summary>
        private void editEntryButt_Click(object sender, EventArgs e)
        {
            if (listBox.SelectedItems.Count == 1)
            {
                dateBox.Value = DateTime.ParseExact(changelog.GetDate(listBox.SelectedItems[0].Index), dateBox.CustomFormat, null);
                pictureURLBox.Text = changelog.GetPicture(listBox.SelectedItems[0].Index);
                descriptionBox.Text = changelog.GetText(listBox.SelectedItems[0].Index);
                headingBox.Text = changelog.GetHeading(listBox.SelectedItems[0].Index);
                editedID = listBox.SelectedItems[0].Index;
                isEditedDeleted = false;
            }
        }

        /// <summary>
        /// Deletes changelog entry.
        /// </summary>
        private void delEntryButt_Click(object sender, EventArgs e)
        {
            if (listBox.SelectedItems.Count == 1)
            {
                if (listBox.SelectedItems[0].Index == editedID)
                    isEditedDeleted = true;
                changelog.RemoveElement(listBox.SelectedItems[0].Index);
                UpdateListView();
            }
        }

        /// <summary>
        /// Resets all fields to default, and ensures that new entry will be saved as a new entry afterwards.
        /// </summary>
        private void addEntryButt_Click(object sender, EventArgs e)
        {
            dateBox.Value = DateTime.Now;
            pictureURLBox.Text = "";
            descriptionBox.Text = "";
            headingBox.Text = "";
            picturePreviewBox.Image = null;
            editedID = -1;
        }

        /// <summary>
        /// Saves changelog entry into changelog. Overwrites an old one in case it was supposed to be edited.
        /// If an old one was deleted previously, changelog entry is added as a new entry.
        /// </summary>
        private void saveEntryButt_Click(object sender, EventArgs e)
        {
            if (editedID == -1 || isEditedDeleted)
                changelog.AddElement(descriptionBox.Text, pictureURLBox.Text, dateBox.Value.ToString(dateBox.CustomFormat), headingBox.Text);
            else
                changelog.UpdateElement(editedID, descriptionBox.Text, pictureURLBox.Text, dateBox.Value.ToString(dateBox.CustomFormat), headingBox.Text);
            UpdateListView();
        }

        private void testPictureButt_Click(object sender, EventArgs e)
        {
            try { picturePreviewBox.Load(pictureURLBox.Text); }
            catch { o.Messagebox(c.SubElText("Messages", "PictureNotOpened")); }
        }

        private void cancelButt_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void saveButt_Click(object sender, EventArgs e)
        {
            changelog.SaveXml();
            UploadChangelog();
            if (wasUploadSucces)
            {
                MessageBox.Show(c.SubElText("Messages", "ChangelogUploadOK"));
                Close();
            }
        }

        private void ChangelogEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            mainWindow.changelogEditor = null;
        }

        private void descriptionBox_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            Process.Start(e.LinkText);
        }

        private void listBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            editEntryButt_Click(sender, null);
        }

        private void listBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (listBox.FocusedItem.Bounds.Contains(e.Location) == true)
                {
                    contextMenu.Show(Cursor.Position);
                }
                else
                {
                    contextMenu.Hide();
                }
            }
            else
                contextMenu.Hide();
        }

        private void listBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                editEntryButt_Click(sender, e);
            if (e.KeyCode == Keys.Delete)
                delEntryButt_Click(sender, e);
        }

        private void pictureURLBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                testPictureButt_Click(sender, e);
        }

        private void picturePreviewBox_Click(object sender, EventArgs e)
        {
            if (listBox.SelectedItems.Count != 0)
                try { Process.Start(pictureURLBox.Text); }
                catch { }
        }

        private void ChangelogEditor_Load(object sender, EventArgs e)
        {
            LoadConfig();
            contextMenu.Items[0].Click += new EventHandler(editEntryButt_Click);
            contextMenu.Items[1].Click += new EventHandler(delEntryButt_Click);
            dateBox.Value = DateTime.Now;
            changelog = new Changelog();
            UpdateListView();
        }
        #endregion
    }
}
