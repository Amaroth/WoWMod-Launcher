using System;
using System.Drawing;
using System.Net;
using System.Windows.Forms;
using AmarothLauncher.Core;
using AmarothLauncher.GUI;

namespace AmarothLauncher.GUI
{
    public partial class FTPLoginWindow : Form
    {
        public MainWindow mainWindow;
        Config c = Config.Instance;
        OutputWriter o = OutputWriter.Instance;

        public FTPLoginWindow()
        {
            InitializeComponent();
            LoadConfig();
        }

        #region Methods...
        /// <summary>
        /// Sets values of window elements to values set in config.
        /// </summary>
        private void LoadConfig()
        {
            Icon = new Icon("LauncherIcon.ico");
            Text = c.SubElText("FTPLoginWindow", "WindowName");
            panelLogin.Text = c.SubElText("FTPLoginWindow", "Login");
            panelPassword.Text = c.SubElText("FTPLoginWindow", "Password");
            okButt.Text = c.SubElText("FTPLoginWindow", "OKButton");
            cancelButt.Text = c.SubElText("FTPLoginWindow", "CancelButton");
        }

        private bool isValidConnection(string url, string user, string password)
        {
            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(url);
                request.Method = WebRequestMethods.Ftp.ListDirectory;
                request.Credentials = new NetworkCredential(user, password);
                request.GetResponse();
            }
            catch (WebException ex)
            {
                o.Messagebox(c.SubElText("Messages", "InvalidFtpPassword"), ex);
                return false;
            }
            return true;
        }
        #endregion

        #region Event handlers...
        private void okButt_Click(object sender, EventArgs e)
        {
            if (isValidConnection(c.SubElText("Paths", "ChangelogFTPPath"), loginBox.Text, passwordBox.Text))
            {
                mainWindow.ftpCredsCorrect = true;
                mainWindow.login = loginBox.Text;
                mainWindow.password = passwordBox.Text;
                mainWindow.changelogEditButt_Click(null, null);
                Close();
            }
        }

        private void cancelButt_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FTPLoginWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            mainWindow.ftpLoginWindow = null;
        }
        #endregion
    }
}
