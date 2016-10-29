using System.Globalization;
using System.IO;
using System.Text;
using System.Xml;

namespace AmarothLauncher.Core
{
    /// <summary>
    /// Singleton responsible for getting config settings or generating default ones.
    /// </summary>
    public class Config
    {
        private static Config instance;

        // Launcher's version.
        public double version = 1.1;
        public bool isDefaultConfigUsed { get; private set; }
        XmlDocument xml = new XmlDocument();
        XmlDocument defaultXml = new XmlDocument();
        OutputWriter o = OutputWriter.Instance;

        private Config()
        {
            Initialize();
        }

        public static Config Instance
        {
            get
            {
                if (instance == null)
                    instance = new Config();
                return instance;
            }
        }
        /// <summary>
        /// Generates object XML structure of LauncherConfig.xml.
        /// If reading of XML failes, default settings are used.
        /// </summary>
        private void Initialize()
        {
            isDefaultConfigUsed = false;
            GenerateDefault();
            if (!File.Exists("LauncherConfig.xml"))
                UseDefault();
            else
            {
                StreamReader sr = new StreamReader("LauncherConfig.xml");
                string xmlString = sr.ReadToEnd();
                sr.Close();
                xml.LoadXml(xmlString);
            }
        }

        /// <summary>
        /// Use default config XML as current config XML.
        /// </summary>
        private void UseDefault()
        {
            xml = defaultXml;
            o.Messagebox(SubElText("Messages", "XmlNotOpened"));

            // Save default config as a new config XML. Use for generating XML to be able to edit it afterwards, do NOT have this uncommented in releases!
            // SaveDefault();

            isDefaultConfigUsed = true;
        }

        /// <summary>
        /// Outputs whole config content. For debugging only.
        /// </summary>
        public void OutputContent()
        {
            o.Output("Outputing all values set in Config for debugging purpouses. * marks attributes (followed by their names), \"\" mark values.");
            foreach (XmlNode node in xml.DocumentElement.ChildNodes)
            {
                o.Output(node.Name, true);
                foreach (XmlNode att in node.ChildNodes)
                    o.Output("* " + att.Name + " - \"" + att.InnerText + "\"");
            }
        }

        /// <summary>
        /// Returns an inner text of given subelement of given element. If anything isn't found, error message is shown and an empty string returned.
        /// </summary>
        public string SubElText(string elementName, string subElementName)
        {
            if (xml.GetElementsByTagName(elementName).Count > 0)
            {
                foreach (XmlNode node in xml.GetElementsByTagName(elementName)[0].ChildNodes)
                    if (node.Name == subElementName)
                        return node.InnerText;
            }
            else
                o.Output(elementName + " element was not found in config. This may cause critical errors.");

            o.Output(subElementName + " attribute was not found in config. This may cause critical errors.");
            return "";
        }

        /// <summary>
        /// Return an inner text of given element in config XML. If not found, return empty string and output error.
        /// </summary>
        public string InnText(string elementName)
        {
            if (xml.GetElementsByTagName(elementName).Count > 0)
                return xml.GetElementsByTagName(elementName)[0].InnerText;
            else
            {
                o.Output(elementName + " element was not found in config. This may cause critical errors.");
                return "";
            }
        }

        #region Default config generation...
        /// <summary>
        /// Generate a new default config. Will be used only if no config is found.
        /// </summary>
        private void GenerateDefault()
        {
            XmlDeclaration declaration = defaultXml.CreateXmlDeclaration("1.0", "UTF-8", null);
            XmlElement root = defaultXml.DocumentElement;
            defaultXml.InsertBefore(declaration, root);
            XmlElement configs = defaultXml.CreateElement("Config");
            XmlComment comment = defaultXml.CreateComment("This is a config file for Launcher. Feel free to edit whatever you want or even translate Launcher to your native language. Pay close attention to comments and documentation.");
            defaultXml.AppendChild(comment);
            defaultXml.AppendChild(configs);

            MainSettingsDefault();
            PathConfigDefault();
            MainWindowDefault();
            ChangelogEditorDefault();
            ChangelogBrowserDefault();
            FTPLoginWindowDefault();
            MessagesDefault();
        }

        /// <summary>
        /// Adds a new subnode under a node, with given name and inner text.
        /// </summary>
        private void AddSubnodeDefault(XmlNode node, string name, string value)
        {
            AddSubnodeDefault(node, name, value, "");
        }

        /// <summary>
        /// Adds a new subnode under a node, with given name and inner text. Also creates a given comment, if it isn't empty.
        /// </summary>
        private void AddSubnodeDefault(XmlNode node, string name, string value, string comment)
        {
            XmlNode newNode = defaultXml.CreateElement(name);
            if (comment != "" && comment != null)
            {
                XmlComment newComment = defaultXml.CreateComment(name + ": " + comment);
                node.AppendChild(newComment);
            }
            newNode.InnerText = value;
            node.AppendChild(newNode);
        }

        /// <summary>
        /// Default configuration of paths to web.
        /// </summary>
        private void MainSettingsDefault()
        {
            XmlComment comment = defaultXml.CreateComment("Main settings of an application.");
            XmlNode node = defaultXml.CreateElement("Main");

            AddSubnodeDefault(node, "DeleteCache", "1", "1 or 0. If 1, Cache folder is always deleted.");
            AddSubnodeDefault(node, "KeepBackups", "1", "1 or 0. If 1, .ext_ files are being kept as backups. Recommended 1.");
            AddSubnodeDefault(node, "KeepBlizzlikeMPQs", "1", "1 or 0. If 1, blizzlike MPQs in Data are ignored by Launcher. Otherwise they are handled in a same manner as custom one. Recommended 1.");
            AddSubnodeDefault(node, "ForcedRealmlist", "1", "1 or 0. If 1, realmlist.wtf will always be updated to match realmlist.wtf in FilesRootPath.");
            AddSubnodeDefault(node, "FileProcessingOutputs", "1", "1 or 0. If 1, messages about downloading and unziping files will be shown.");

            defaultXml.DocumentElement.AppendChild(comment);
            defaultXml.DocumentElement.AppendChild(node);
        }

        /// <summary>
        /// Default configuration of paths to web.
        /// </summary>
        private void PathConfigDefault()
        {
            XmlComment comment = defaultXml.CreateComment("Paths to files and folders Launcher will work with. They are commonly all !CASE SENSITIVE!");
            XmlNode node = defaultXml.CreateElement("Paths");

            AddSubnodeDefault(node, "FilelistPath", "http://www.example.com/files/filelist.conf", "Path to text filelist.");
            AddSubnodeDefault(node, "VersionPath", "http://www.example.com/files/launcherversion.conf", "Path to text file which contains your Lancher's current version (version is a double value with . as separator!");
            AddSubnodeDefault(node, "LauncherPath", "http://www.exeample.com/files/Launcher.zip", "Path to a zip file with Launcher files - used if Launcher finds itself outdated.");
            AddSubnodeDefault(node, "FilesRootPath", "http://www.example.com/files/", "Path to folder with files. Paths in filelist are relative to this path.");
            AddSubnodeDefault(node, "ChangelogPath", "http://www.example.com/files/changelog.xml", "!HTTP! path to changelog XML file.");
            AddSubnodeDefault(node, "ChangelogFTPPath", "ftp://ftp.example.com//www/files/", "!Full! !FTP! path to folder in which changelog is. Notice that //www/ part. You may want to use an IP instead of a domain name.");
            AddSubnodeDefault(node, "Webpage", "http://www.example.com", "URL which is to be opened when user clicks on Project webpage button.");
            AddSubnodeDefault(node, "Registration", "http://reg.example.com", "URL which is to be opened when user clicks on Registration button.");
            AddSubnodeDefault(node, "Instructions", "http://www.example.com/launchermanual/", "URL which is to be opened when user clicks on Launcher manual button.");
            AddSubnodeDefault(node, "HelloImage", "http://www.example.com/files/hello.jpg", "URL to image which is to be displayed in Main window (latest news image). Clicking on it opens a changelog browser.");

            defaultXml.DocumentElement.AppendChild(comment);
            defaultXml.DocumentElement.AppendChild(node);
        }

        /// <summary>
        /// Default configuration of main window.
        /// </summary>
        private void MainWindowDefault()
        {
            XmlComment comment = defaultXml.CreateComment("Visual settings for Main Window.");
            XmlNode node = defaultXml.CreateElement("MainWindow");

            AddSubnodeDefault(node, "WindowName", "Amaroth's Launcher " + version.ToString("F", CultureInfo.InvariantCulture), "Name of main window. Change this to match your project's name.");
            AddSubnodeDefault(node, "OutputBox", "Text output:");
            AddSubnodeDefault(node, "OptionalBox", "Optional files:");
            AddSubnodeDefault(node, "CheckForUpdatesButton", "Check for updates");
            AddSubnodeDefault(node, "UpdateButton", "Update");
            AddSubnodeDefault(node, "WebpageButton", "Project webpage");
            AddSubnodeDefault(node, "RegistrationButton", "Registration");
            AddSubnodeDefault(node, "LauncherInstructionsButton", "Launcher manual");
            AddSubnodeDefault(node, "DeleteBackupsButton", "Delete .ext_ backups");
            AddSubnodeDefault(node, "ChangelogEditorButton", "Changelog editor");
            AddSubnodeDefault(node, "ChangelogBrowserButton", "Changelog browser");
            AddSubnodeDefault(node, "LaunchButton", "Launch");
            AddSubnodeDefault(node, "ProgressText", "Downloading: ");
            AddSubnodeDefault(node, "ProgressSeparator", " / ");
            AddSubnodeDefault(node, "DownloadSpeedUnits", "/s, ");
            AddSubnodeDefault(node, "remaining", "remaining");
            AddSubnodeDefault(node, "downloaded", "downloaded, ");
            AddSubnodeDefault(node, "ToolTipTotalSize", "Total size: ");
            AddSubnodeDefault(node, "PanelTotalSize", "Total size of outdated:");
            AddSubnodeDefault(node, "LabelTotalSizeOpt", "Chosen optionals: ");
            AddSubnodeDefault(node, "LabelTotalSizeNonOpt", "Non-optionals: ");
            AddSubnodeDefault(node, "second", " s ");
            AddSubnodeDefault(node, "minute", " m ");
            AddSubnodeDefault(node, "hour", " h ");
            AddSubnodeDefault(node, "Complete", "Download complete!");
            AddSubnodeDefault(node, "Errors", "Errors occured!");

            defaultXml.DocumentElement.AppendChild(comment);
            defaultXml.DocumentElement.AppendChild(node);
        }

        /// <summary>
        /// Default configuration of changelog editor.
        /// </summary>
        private void ChangelogEditorDefault()
        {
            XmlComment comment = defaultXml.CreateComment("Visual settings for Changelog Editor. A lot of those are used by Changelog Browser as well.");
            XmlNode node = defaultXml.CreateElement("ChangelogEditor");

            AddSubnodeDefault(node, "WindowName", "Changelog Editor");
            AddSubnodeDefault(node, "ChangelogEntries", "Changelog entries:");
            AddSubnodeDefault(node, "DateColumn", "Date");
            AddSubnodeDefault(node, "HeadingColumn", "Heading");
            AddSubnodeDefault(node, "Date", "Date:");
            AddSubnodeDefault(node, "DateFormat", "dd.MM.yyyy hh:mm", "Carefully with this. MM for months, mm for minutes. You can use your own format, but it must be correct. Changelog's data must also be compatible with this, if your changelog isn't empty when this is being changed!");
            AddSubnodeDefault(node, "PictureURL", "Picture URL:");
            AddSubnodeDefault(node, "Heading", "Heading:");
            AddSubnodeDefault(node, "PicturePreview", "Picture preview:");
            AddSubnodeDefault(node, "Description", "Description:");
            AddSubnodeDefault(node, "EditEntryButton", "Edit entry");
            AddSubnodeDefault(node, "DeleteEntryButton", "Delete entry");
            AddSubnodeDefault(node, "CreateEntryButton", "Create entry");
            AddSubnodeDefault(node, "SaveEntryButton", "Save entry");
            AddSubnodeDefault(node, "TestPictureButton", "Test picture");
            AddSubnodeDefault(node, "CancelButton", "Cancel changes");
            AddSubnodeDefault(node, "SaveButton", "Save changelog");

            defaultXml.DocumentElement.AppendChild(comment);
            defaultXml.DocumentElement.AppendChild(node);
        }

        /// <summary>
        /// Default configuration of changelog browser. A lot of settings are being used from changelog editor.
        /// </summary>
        private void ChangelogBrowserDefault()
        {
            XmlComment comment = defaultXml.CreateComment("Visual settings for Changelog Browser.");
            XmlNode node = defaultXml.CreateElement("ChangelogBrowser");

            AddSubnodeDefault(node, "WindowName", "Changelog Browser");
            AddSubnodeDefault(node, "InfoText", "Click on an entry in entries list in order to display it.");
            AddSubnodeDefault(node, "Picture", "Picture:");

            defaultXml.DocumentElement.AppendChild(comment);
            defaultXml.DocumentElement.AppendChild(node);
        }

        /// <summary>
        /// Default configuration of FTP login window.
        /// </summary>
        private void FTPLoginWindowDefault()
        {
            XmlComment comment = defaultXml.CreateComment("Visual settings for authentization dialog window for Changelog Editor.");
            XmlNode node = defaultXml.CreateElement("FTPLoginWindow");

            AddSubnodeDefault(node, "WindowName", "Login to FTP");
            AddSubnodeDefault(node, "Login", "Login:");
            AddSubnodeDefault(node, "Password", "Password:");
            AddSubnodeDefault(node, "OKButton", "OK");
            AddSubnodeDefault(node, "CancelButton", "Cancel");

            defaultXml.DocumentElement.AppendChild(comment);
            defaultXml.DocumentElement.AppendChild(node);
        }

        /// <summary>
        /// Error (and other) messages. Leave space behind message if you want to ouput something directly behind it (like file's name).
        /// </summary>
        private void MessagesDefault()
        {
            XmlComment comment = defaultXml.CreateComment("Various messages which can be output by Launcher.");
            XmlNode node = defaultXml.CreateElement("Messages");

            AddSubnodeDefault(node, "HelloMessage", "This Launcher was coded by Amaroth from www.model-changing.net.", "Please, leave this here. If you want to add anything, add it behind original message.");
            AddSubnodeDefault(node, "XmlNotOpened", "Default settings are being used, because LauncherConfig.xml could not be loaded. Launcher can't continue. Get a new config file!");
            AddSubnodeDefault(node, "ChangelogNotOpened", "Failed to open a changelog file on web.");
            AddSubnodeDefault(node, "ChangelogNotLoaded", "Failed to load changelog data. Please, contact support.");
            AddSubnodeDefault(node, "ChangelogEmpty", "Warning: changelog is empty. You are currently creating a new one.");
            AddSubnodeDefault(node, "InvalidFtpPassword", "Incorrect login - password combination, or incorrect FTP path to changelog.");
            AddSubnodeDefault(node, "PictureNotOpened", "Picture from given URL could not be opened. URL seems to be invalid.");
            AddSubnodeDefault(node, "ChangelogNotUploaded", "Changelog could not be uploaded. Backup XML file can be found in Launcher's directory.");
            AddSubnodeDefault(node, "ChangelogUploadOK", "Changelog was succesfully updated.");
            AddSubnodeDefault(node, "UnZipingFileError", "Failed to unzip file: ");
            AddSubnodeDefault(node, "DownloadingFrom", "Downloading file from: ");
            AddSubnodeDefault(node, "DownloadingTo", "To: ");
            AddSubnodeDefault(node, "UnzipingFile", "Unziping file: ");
            AddSubnodeDefault(node, "FileDeletingError", "Failed to delete file: ");
            AddSubnodeDefault(node, "WowExeMissing", "WoW.exe was not found!");
            AddSubnodeDefault(node, "DataDirMissing", "Data directory was not found!");
            AddSubnodeDefault(node, "BlizzlikeMpqMissing", "Failed to find essential file: ");
            AddSubnodeDefault(node, "LauncherNotInWowDir", "Your WoW client is either damaged, or Launcher is not in WoW root directory.");
            AddSubnodeDefault(node, "FilelistOpeningFailed", "Launcher could not open filelist on web. Check your internet connection, or contact your support team. Error message: ");
            AddSubnodeDefault(node, "FilelistReadingFailed", "Filelist on web is invalid. Contact your support team.");
            AddSubnodeDefault(node, "FileOnsWebMissing", "File's size could not be found. File is probably missing on web server. ");
            AddSubnodeDefault(node, "WebRealmlistMissing", "File realmlist.wtf could not be found on web. Realmlist could not be verified.");
            AddSubnodeDefault(node, "RealmlistMissing", "It appears local realmlist.wtf is missing. Create a new one if it is so.");
            AddSubnodeDefault(node, "OptionalsPresetLoadFailed", "You don't have saved optional groups selection, or list of them has changed. Please, pay attention optional files checkbox list before you click on an Update button.");
            AddSubnodeDefault(node, "DownloadError", "Error occured while followin file was being downloaded: ");
            AddSubnodeDefault(node, "FileDownloadError", "Some files apparently weren't succesfully downloaded. Re-run Check for updates and Update.");
            AddSubnodeDefault(node, "HelloImageNotLoaded", "News image could not be loaded.");
            AddSubnodeDefault(node, "VersionNotVerified", "Launcher could not verify wheter it is up to date. It will proceed as normal, but notify your support team about this issue if it persists.");
            AddSubnodeDefault(node, "CouldNotBeUpdated", "Launcher has attempted an update of itself, but it was not successful. Try to re-run a Launcher and contact your support team if issue persists.");
            AddSubnodeDefault(node, "OutdatedLauncher", "There seems to be a new version of Launcher on web. Launcher will attempt an update and then restart.");
            AddSubnodeDefault(node, "LauncherUpdated", "Launcher has been succesfully updated. Please, run Launcher again.");
            AddSubnodeDefault(node, "Removing", "Removing file: ");

            defaultXml.DocumentElement.AppendChild(comment);
            defaultXml.DocumentElement.AppendChild(node);
        }

        /// <summary>
        /// Save default XML as new LauncherConfig.xml, overwrite an old one.
        /// </summary>
        private void SaveDefault()
        {
            TextWriter tw = new StreamWriter("LauncherConfig.xml", false, Encoding.UTF8);
            defaultXml.Save(tw);
            tw.Close();
        }
        #endregion
    }
}