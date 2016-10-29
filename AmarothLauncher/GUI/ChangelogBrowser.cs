using AmarothLauncher.Core;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace AmarothLauncher.GUI
{
    public partial class ChangelogBrowser : Form
    {
        OutputWriter o = OutputWriter.Instance;
        Config c = Config.Instance;
        public MainWindow mainWindow;

        Changelog changelog;

        public ChangelogBrowser()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Sets values of window elements to values set in config.
        /// </summary>
        private void LoadConfig()
        {
            Icon = new Icon("LauncherIcon.ico");
            Text = c.SubElText("ChangelogBrowser", "WindowName");
            descriptionBox.Text = c.SubElText("ChangelogBrowser", "InfoText");
            panelPicture.Text = c.SubElText("ChangelogBrowser", "Picture");

            panelList.Text = c.SubElText("ChangelogEditor", "ChangelogEntries");
            listBox.Columns[0].Text = c.SubElText("ChangelogEditor", "DateColumn");
            listBox.Columns[1].Text = c.SubElText("ChangelogEditor", "HeadingColumn");
            panelDate.Text = c.SubElText("ChangelogEditor", "Date");
            dateBox.CustomFormat = c.SubElText("ChangelogEditor", "DateFormat");
            panelHeading.Text = c.SubElText("ChangelogEditor", "Heading");
            panelDescription.Text = c.SubElText("ChangelogEditor", "Description");
        }

        /// <summary>
        /// Updates a list by getting a new version of changelog.
        /// Hopefully its not too slowing for slow internet connection owners, feel free to comment its calling in listBox_ItemCheck event method.
        /// </summary>
        private void UpdateList()
        {
            changelog = new Changelog();
            listBox.Items.Clear();
            for (int i = 0; i < changelog.GetAmount(); i++)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = changelog.GetDate(i);
                lvi.ToolTipText = changelog.GetText(i);
                lvi.SubItems.Add(new ListViewItem.ListViewSubItem(lvi, changelog.GetHeading(i)));
                listBox.Items.Add(lvi);
            }
        }

        #region Event handlers...
        private void ChangelogBrowser_FormClosing(object sender, FormClosingEventArgs e)
        {
            mainWindow.changelogBrowser = null;
        }

        /// <summary>
        /// Displays detailed information about selected entry, if any entry is selected.
        /// </summary>
        private void listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox.SelectedItems.Count == 1)
            {
                dateBox.Value = DateTime.ParseExact(changelog.GetDate(listBox.SelectedItems[0].Index), dateBox.CustomFormat, null);
                try
                {
                    pictureBox.CancelAsync();
                    pictureBox.LoadAsync(changelog.GetPicture(listBox.SelectedItems[0].Index));
                }
                catch { }
                descriptionBox.Text = changelog.GetText(listBox.SelectedItems[0].Index);
                headingBox.Text = changelog.GetHeading(listBox.SelectedItems[0].Index);
            }
        }

        private void descriptionBox_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            Process.Start(e.LinkText);
        }

        private void listBox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            UpdateList();
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {
            if (listBox.SelectedItems.Count != 0)
                try { Process.Start(changelog.GetPicture(listBox.SelectedItems[0].Index)); }
                catch { }
        }

        private void ChangelogBrowser_Load(object sender, EventArgs e)
        {
            LoadConfig();
            UpdateList();
        }
        #endregion
    }
}
