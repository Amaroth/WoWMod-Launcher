using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using AmarothLauncher.Core;
using AmarothLauncher.GUI;
using System.IO;
using System.Globalization;

namespace AmarothLauncher
{
    public partial class MainWindow : Form
    {
        // For sending outputs and gettng config settings.
        OutputWriter o = OutputWriter.Instance;
        Config c = Config.Instance;
        FileHandler handler;

        public bool ftpCredsCorrect = false;
        public string login;
        public string password;

        public ChangelogBrowser changelogBrowser;
        public ChangelogEditor changelogEditor;
        public FTPLoginWindow ftpLoginWindow;

        string cwd = Directory.GetCurrentDirectory();

        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Sets values of window elements to values set in config.
        /// </summary>
        private void LoadConfig()
        {
            try { Icon = new Icon("LauncherIcon.ico"); } catch { }
            Text = c.SubElText("MainWindow", "WindowName");
            panelOutput.Text = c.SubElText("MainWindow", "OutputBox");
            panelOptional.Text = c.SubElText("MainWindow", "OptionalBox");
            checkUpdatesButt.Text = c.SubElText("MainWindow", "CheckForUpdatesButton");
            updateButt.Text = c.SubElText("MainWindow", "UpdateButton");
            webButt.Text = c.SubElText("MainWindow", "WebpageButton");
            regButt.Text = c.SubElText("MainWindow", "RegistrationButton");
            launcherInfoButt.Text = c.SubElText("MainWindow", "LauncherInstructionsButton");
            delBackButt.Text = c.SubElText("MainWindow", "DeleteBackupsButton");
            changelogEditButt.Text = c.SubElText("MainWindow", "ChangelogEditorButton");
            changelogBrowserButt.Text = c.SubElText("MainWindow", "ChangelogBrowserButton");
            launchButt.Text = c.SubElText("MainWindow", "LaunchButton");
            panelTotalSize.Text = c.SubElText("MainWindow", "PanelTotalSize");
            try { newsPictureBox.LoadAsync(c.SubElText("Paths", "HelloImage")); }
            catch { o.Output(c.SubElText("Messages", "HelloImageNotLoaded")); }
            progressLabel.Text = "";
            speedLabel.Text = "";
            percentLabel.Text = "";
            totalSizeLabel.Text = "";
        }

        #region Self-update methods...
        /// <summary>
        /// Checks if version from Output.cs is same/newer than version from VersionPath file. Also deletes possible backup of older Launcher version.
        /// </summary>
        private bool IsUpToDate()
        {
            string versionOnWeb = null;
            try
            {
                using (var client = new AmWebClient(3000))
                    versionOnWeb = client.DownloadString(c.SubElText("Paths", "VersionPath"));
            }
            catch
            {
                o.Messagebox(c.SubElText("Messages", "VersionNotVerified"));
                return true;
            }
            double webVersion;
            if (Double.TryParse(versionOnWeb.Trim(), NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out webVersion))
                return webVersion <= c.version;
            else
            {
                o.Messagebox(c.SubElText("Messages", "VersionNotVerified"));
                return true;
            }
        }

        /// <summary>
        /// Renames Launcher's files and downloads new ones. Unzips them and restarts a Launcher.
        /// </summary>
        private void UpdateSelf()
        {
            string cwd = Directory.GetCurrentDirectory();
            string exeName = cwd + "\\" + AppDomain.CurrentDomain.FriendlyName;
            MessageBox.Show(c.SubElText("Messages", "OutdatedLauncher"));

            // Clean up possible mess in the way.
            if (File.Exists(cwd + "\\OldLauncher.exe"))
                File.Delete(cwd + "\\OldLauncher.exe");
            if (File.Exists(cwd + "\\OldLauncherConfig.xml"))
                File.Delete(cwd + "\\OldLauncherConfig.xml");
            if (File.Exists(cwd + "\\OldLauncherIcon.ico"))
                File.Delete(cwd + "\\OldLauncherIcon.ico");

            // Backup current files.
            if (File.Exists(exeName))
                File.Move(exeName, cwd + "\\OldLauncher.exe");
            if (File.Exists(cwd + "\\LauncherConfig.xml"))
                File.Move(cwd + "\\LauncherConfig.xml", cwd + "\\OldLauncherConfig.xml");
            if (File.Exists(cwd + "\\LauncherIcon.ico"))
                File.Move(cwd + "\\LauncherIcon.ico", cwd + "\\OldLauncherIcon.ico");
            try
            {
                if (File.Exists(cwd + "\\Launcher.zip"))
                    File.Delete(cwd + "\\Launcher.zip");
                // Download new Launcher.
                using (var client = new AmWebClient(3000))
                {
                    client.DownloadFile(c.SubElText("Paths", "LauncherPath"), cwd + "\\Launcher.zip");
                }

                // Unzip new Launcher.
                Shell32.Shell objShell = new Shell32.Shell();
                Shell32.Folder destinationFolder = objShell.NameSpace(cwd);
                Shell32.Folder sourceFile = objShell.NameSpace(cwd + "\\Launcher.zip");
                foreach (var zipFile in sourceFile.Items())
                {
                    destinationFolder.CopyHere(zipFile, 4 | 16);
                }

                // Remove zip.
                File.Delete(cwd + "\\Launcher.zip");

                // Start a new Launcher.
                Process.Start(exeName);
                newsPictureBox.CancelAsync();
                Close();
            }
            catch (Exception e)
            {
                // Return things to previous state.
                if (File.Exists(cwd + "\\OldLauncher.exe"))
                    File.Move(cwd + "\\OldLauncher.exe", exeName);
                if (File.Exists(cwd + "\\OldLauncherConfig.xml"))
                    File.Move(cwd + "\\OldLauncherConfig.xml", cwd + "\\LauncherConfig.xml");
                if (File.Exists(cwd + "\\OldLauncherIcon.ico"))
                    File.Move(cwd + "\\OldLauncherIcon.ico", cwd + "\\LauncherIcon.ico");
                o.Messagebox("CouldNotBeUpdated", e);
                updateButt.Enabled = false;
                launchButt.Enabled = false;
            }
        }
        #endregion

        #region Progress and size labels updates...
        /// <summary>
        /// When download is running, call UI updates of speed and progress.
        /// </summary>
        private void timer_Tick(object sender, EventArgs e)
        {
            UpdateProgressLabel();
            UpdateSpeedAndTime();
            UpdatePercentage();
        }

        /// <summary>
        /// Sets progress label to match amount of files have been already downloaded.
        /// </summary>
        private void UpdateProgressLabel()
        {
            progressLabel.Text = c.SubElText("MainWindow", "ProgressText") + (handler.filesDownloaded + 1) +
                c.SubElText("MainWindow", "ProgressSeparator") + handler.toBeDownloaded.Count;
        }

        long previousSize;
        long actualSize;
        long neededSize;
        long downloadSpeed;
        /// <summary>
        /// Sets speed label to current download speed and estimated time remaining.
        /// Download speed measuring isn't done in a very effective and accurate way though.
        /// </summary>
        private void UpdateSpeedAndTime()
        {
            previousSize = actualSize;
            actualSize = 0;
            foreach (HandledFile hf in handler.toBeDownloaded)
                if (File.Exists(hf.fullLocalPath))
                    actualSize += new FileInfo(hf.fullLocalPath).Length;
            downloadSpeed = actualSize - previousSize;
            speedLabel.Text = handler.Size(downloadSpeed) + c.SubElText("MainWindow", "DownloadSpeedUnits")
                + TimeRemaining();
        }

        /// <summary>
        /// Updates label with % downloaded, size downloaded and size left.
        /// </summary>
        private void UpdatePercentage()
        {
            if (neededSize > 0)
            {
                percentLabel.Text = (int)(100.0 * actualSize / neededSize) + "% (" + handler.Size(actualSize) + " " +
                    c.SubElText("MainWindow", "downloaded") + handler.Size(neededSize - actualSize) + " " +
                    c.SubElText("MainWindow", "remaining") + ")";
                if (100.0 * actualSize / neededSize <= 100)
                    progressBar.Value = (int)(100.0 * actualSize / neededSize);
            }
        }

        /// <summary>
        /// Returns a string version of remaining time in most reasonable units.
        /// </summary>
        private string TimeRemaining()
        {
            if (downloadSpeed > 0)
            {
                string result = "";
                long remainingTime = (neededSize - actualSize) / downloadSpeed;
                if (remainingTime < 60)
                    result += remainingTime + c.SubElText("MainWindow", "second");
                else if (remainingTime < 3600)
                    result += (remainingTime / 60) + c.SubElText("MainWindow", "minute") + (remainingTime % 60) + c.SubElText("MainWindow", "second");
                else
                    result += (remainingTime / 3600) + c.SubElText("MainWindow", "hour") + (remainingTime % 3600) + c.SubElText("MainWindow", "minute");

                return result + c.SubElText("MainWindow", "remaining");
            }
            else
                return "? " + c.SubElText("MainWindow", "remaining");
        }

        /// <summary>
        /// Updates a label with sizes of outdated/missing & selected optional and non-optional sizes.
        /// </summary>
        private void UpdateOptionalSizeLabel()
        {
            long totalOptionalSize = 0;
            foreach (OptionalGroup og in handler.optionalGroups)
            {
                if (og.isChecked)
                    totalOptionalSize += og.GetSizeForDownload(handler.toBeDownloaded);
            }
            totalSizeLabel.Text = c.SubElText("MainWindow", "LabelTotalSizeOpt") + handler.Size(totalOptionalSize);
            totalSizeLabel.Text += "\n" + c.SubElText("MainWindow", "LabelTotalSizeNonOpt") + handler.nonOptionalOutdatedSize;
        }
        #endregion

        #region Event handlers...
        private void checkUpdatesButt_Click(object sender, EventArgs e)
        {
            if (File.Exists(cwd + "\\OldLauncher.exe"))
                File.Delete(cwd + "\\OldLauncher.exe");
            if (File.Exists(cwd + "\\OldLauncherConfig.xml"))
                File.Delete(cwd + "\\OldLauncherConfig.xml");
            if (File.Exists(cwd + "\\OldLauncherIcon.ico"))
                File.Delete(cwd + "\\OldLauncherIcon.ico");
            progressLabel.Text = "";
            speedLabel.Text = "";
            percentLabel.Text = "";
            totalSizeLabel.Text = "";
            o.Reset();
            optionalsListView.Clear();
            handler = new FileHandler();
            handler.optionalsListView = optionalsListView;
            updateButt.Enabled = false;
            launchButt.Enabled = false;
            if (handler.IsInWowDir())
            {
                if (!c.isDefaultConfigUsed)
                    if (handler.CheckForUpdates())
                    {
                        updateButt.Enabled = true;
                        UpdateOptionalSizeLabel();
                    }
                // Outputs for debugging purpouses. Keep them commented in releases.
                // handler.OutputServerFilelist();
                // handler.OutputOptionalGroups();
            }
            else
                o.Messagebox(c.SubElText("Messages", "LauncherNotInWowDir"));
        }

        private async void updateButt_Click(object sender, EventArgs e)
        {
            neededSize = 0;
            actualSize = 0;
            previousSize = 0;
            downloadSpeed = 0;
            updateButt.Enabled = false;
            checkUpdatesButt.Enabled = false;
            handler.PrepareUpdate();
            neededSize = handler.SizeToBeDownloaded();
            timer.Start();
            await handler.Update();
            progressBar.Value = 100;
            timer.Stop();
            if (handler.filesDownloaded == handler.toBeDownloaded.Count)
            {
                launchButt.Enabled = true;
                progressLabel.Text = c.SubElText("MainWindow", "Complete");
            }
            else
                progressLabel.Text = c.SubElText("MainWindow", "Errors");
            checkUpdatesButt.Enabled = true;
            speedLabel.Text = "";
            percentLabel.Text = "";
            totalSizeLabel.Text = "";
        }

        private void launchButt_Click(object sender, EventArgs e)
        {
            if (File.Exists("wow.exe"))
            {
                Process.Start("wow.exe");
                Close();
            }
            else
                o.Messagebox(c.SubElText("Messages", "WowExeMissing"));
        }

        private void webButt_Click(object sender, EventArgs e)
        {
            Process.Start(c.SubElText("Paths", "Webpage"));
        }

        private void regButt_Click(object sender, EventArgs e)
        {
            Process.Start(c.SubElText("Paths", "Registration"));
        }

        private void launcherInfoButt_Click(object sender, EventArgs e)
        {
            Process.Start(c.SubElText("Paths", "Instructions"));
        }

        private void delBackButt_Click(object sender, EventArgs e)
        {
            handler.DeleteBackups();
        }

        /// <summary>
        /// Checks if login and password for FTP were already succesfully entried.
        /// If they were, opens Changelog Editor. Otherwise login dialog is created/shown.
        /// </summary>
        public void changelogEditButt_Click(object sender, EventArgs e)
        {
            if (ftpCredsCorrect)
            {
                if (changelogEditor == null)
                    changelogEditor = new ChangelogEditor();
                if (changelogEditor.WindowState == FormWindowState.Minimized)
                    changelogEditor.WindowState = FormWindowState.Normal;
                else
                    changelogEditor.Show();
                changelogEditor.BringToFront();
                changelogEditor.mainWindow = this;
            }
            else
            {
                if (ftpLoginWindow == null)
                    ftpLoginWindow = new FTPLoginWindow();
                if (ftpLoginWindow.WindowState == FormWindowState.Minimized)
                    ftpLoginWindow.WindowState = FormWindowState.Normal;
                else
                    ftpLoginWindow.Show();
                ftpLoginWindow.BringToFront();
                ftpLoginWindow.mainWindow = this;
            }
        }

        private void changelogBrowserButt_Click(object sender, EventArgs e)
        {
            if (changelogBrowser == null)
                changelogBrowser = new ChangelogBrowser();
            if (changelogBrowser.WindowState == FormWindowState.Maximized)
                changelogBrowser.WindowState = FormWindowState.Normal;
            else
                changelogBrowser.Show();
            changelogBrowser.BringToFront();
            changelogBrowser.mainWindow = this;
        }

        private void output_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            Process.Start(e.LinkText);
        }

        private void optionalsListView_MouseClick(object sender, MouseEventArgs e)
        {
            if (optionalsListView.GetItemAt(e.X, e.Y) != null && e.X > 14)
            {
                optionalsListView.GetItemAt(e.X, e.Y).Checked = !optionalsListView.GetItemAt(e.X, e.Y).Checked;
                handler.optionalGroups[optionalsListView.GetItemAt(e.X, e.Y).Index].isChecked = optionalsListView.GetItemAt(e.X, e.Y).Checked;
            }
        }

        private void optionalsListView_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            handler.optionalGroups[e.Item.Index].isChecked = optionalsListView.Items[e.Item.Index].Checked;
            UpdateOptionalSizeLabel();
        }

        private void newsPictureBox_Click(object sender, EventArgs e)
        {
            changelogBrowserButt_Click(null, null);
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            OutputWriter.outputBox = output;
            LoadConfig();
            if (IsUpToDate())
                checkUpdatesButt_Click(null, null);
            else
                UpdateSelf();
            // c.OutputContent();
        }
        #endregion
    }
}
