using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AmarothLauncher.Core
{
    /// <summary>
    /// FileHandler is responsible for getting information about both local and server side files, for creating optional groups
    /// and for creating a download list and finally for downloading files in it.
    /// </summary>
    public class FileHandler
    {
        // For outputing messages and getting configuration settings.
        OutputWriter o = OutputWriter.Instance;
        Config c = Config.Instance;

        List<string> blizzlikeMPQs = new List<string>(); // Paths to local blizzlike MPQs (they are to be ignored, if config says so)
        List<HandledFile> serverSideFiles = new List<HandledFile>(); // List of all files which are mentioned in filelist on web
        public List<OptionalGroup> optionalGroups = new List<OptionalGroup>(); // List of all optional groups

        List<string> outdated = new List<string>(); // List of MPQs in Data folder, which aren't in filelist (or their optional group isn't checked anymore) and are to be removed
        public List<HandledFile> toBeDownloaded = new List<HandledFile>(); // List of files which are missing or outdated and should be downloaded

        // For progress output purpouses
        public int filesRemaining = 0;
        public int filesDownloaded = 0;
        public string nonOptionalOutdatedSize;

        // For communication with GUI optional list
        public ListView optionalsListView;

        // To avoid typing this everywhere
        string cwd = Directory.GetCurrentDirectory().ToLower();

        #region Control and misc methods...
        /// <summary>
        /// Checks if Launcher is in actual WoW directory. Checks WoW.exe, Data and optionaly blizzlike MPQs.
        /// </summary>
        /// <returns>Are essential files OK?</returns>
        public bool IsInWowDir()
        {
            // Check if WoW.exe and Data directory can be found to make sure Launcher is in client's root directory.
            bool result = true;
            if (!File.Exists("wow.exe"))
            {
                o.Output(c.SubElText("Messages", "WowExeMissing"));
                result = false;
            }
            if (!Directory.Exists("data"))
            {
                o.Output(c.SubElText("Messages", "DataDirMissing"));
                result = false;
            }
            // If Blizzlike MPQs are to be kept, check if they are all here as well.
            else if (c.SubElText("Main", "KeepBlizzlikeMPQs") == "1")
            {
                blizzlikeMPQs.Add(cwd + @"\data\common.mpq");
                blizzlikeMPQs.Add(cwd + @"\data\common-2.mpq");
                blizzlikeMPQs.Add(cwd + @"\data\expansion.mpq");
                blizzlikeMPQs.Add(cwd + @"\data\lichking.mpq");
                blizzlikeMPQs.Add(cwd + @"\data\patch.mpq");
                blizzlikeMPQs.Add(cwd + @"\data\patch-2.mpq");
                blizzlikeMPQs.Add(cwd + @"\data\patch-3.mpq");

                foreach (string mpqFile in blizzlikeMPQs)
                    if (!File.Exists(mpqFile))
                    {
                        o.Output(c.SubElText("Messages", "BlizzlikeMpqMissing") + mpqFile.Substring(mpqFile.LastIndexOf('\\') + 1));
                        result = false;
                    }
            }
            return result;
        }

        /// <summary>
        /// Outputs full contents of generated server side file list. For debugging purpouses.
        /// </summary>
        public void OutputServerFilelist()
        {
            foreach (HandledFile hf in serverSideFiles)
            {
                o.Output("-----RelativeServerPath: " + hf.serverPath, true);
                o.Output("FullServerPath: " + hf.fullServerPath);
                if (hf.optional)
                    o.Output("Optional: TRUE");
                else
                    o.Output("Optional: FALSE");
                o.Output("Size: " + hf.size);
                o.Output("RelativeLocalPath: " + hf.localPath);
                o.Output("FullLocalPath: " + hf.fullLocalPath);
                o.Output("First comment: " + hf.firstComment);
                o.Output("LinkedList: " + hf.linked);
                foreach (HandledFile linked in hf.linkedList)
                {
                    o.Output("---LinkedRelativeServerPath: " + linked.serverPath);
                    o.Output("FullServerPath: " + linked.fullServerPath);
                    if (linked.optional)
                        o.Output("Optional: TRUE");
                    else
                        o.Output("Optional: FALSE");
                    o.Output("Size: " + linked.size);
                    o.Output("RelativeLocalPath: " + linked.localPath);
                    o.Output("FullLocalPath: " + linked.fullLocalPath);
                    o.Output("First comment: " + linked.firstComment);
                    o.Output("LinkedList: " + linked.linked);
                }
            }
        }

        /// <summary>
        /// Outputs full contents of optional groups list. For debugging purpouses.
        /// </summary>
        public void OutputOptionalGroups()
        {
            foreach (OptionalGroup og in optionalGroups)
            {
                o.Output("-----GroupName: " + og.name, true);
                foreach (HandledFile linked in og.files)
                {
                    o.Output("---LinkedRelativeServerPath: " + linked.serverPath);
                    o.Output("FullServerPath: " + linked.fullServerPath);
                    if (linked.optional)
                        o.Output("Optional: TRUE");
                    else
                        o.Output("Optional: FALSE");
                    o.Output("Size: " + linked.size);
                    o.Output("RelativeLocalPath: " + linked.localPath);
                    o.Output("FullLocalPath: " + linked.fullLocalPath);
                    o.Output("First comment: " + linked.firstComment);
                    o.Output("LinkedList: " + linked.linked);
                }
            }
        }

        /// <summary>
        /// Checks if given file was completely downloaded.
        /// </summary>
        private bool IsFileOK(HandledFile hf)
        {
            if (File.Exists(hf.fullLocalPath))
                return (new FileInfo(hf.fullLocalPath).Length == hf.size);
            else
                return false;
        }

        /// <summary>
        /// Returns given size in the most appropriate unit (chooses B, KB, MB, or GB, depending on given size), rounded to 3 decimal places. Units are part of returned string.
        /// </summary>
        public string Size(long size)
        {
            if (size < 1024)
                return "" + size + " B";
            else if (size < 1024 * 1024)
                return "" + Math.Round(size / 1024.0, 3) + " KB";
            else if (size < 1024 * 1024 * 1024)
                return "" + Math.Round(size / 1024.0 / 1024.0, 3) + " MB";
            else
                return "" + Math.Round(size / 1024.0 / 1024.0 / 1024.0, 3) + " GB";
        }

        /// <summary>
        /// Returns exact size of all files which are currently in download list.
        /// </summary>
        public long SizeToBeDownloaded()
        {
            long totalSize = 0;
            foreach (HandledFile hf in toBeDownloaded)
                totalSize += hf.size;
            return totalSize;
        }
        #endregion

        #region Check for updates...
        /// <summary>
        /// Checks local files and filelist to get list of files which need to be downloaded and to give user list of optional files to choose from.
        /// </summary>
        /// <returns>Was everything OK?</returns>
        public bool CheckForUpdates()
        {
            if (!BuildFilelist())
                return false;
            BuildOptionals();
            PreBuildDownloadList();
            return true;
        }

        /// <summary>
        /// Attempts to build List of server-side files based on patchlist.
        /// </summary>
        /// <returns>Was build succesful?</returns>
        private bool BuildFilelist()
        {
            // Attempt to download filelist's content.
            string filelistString = null;
            try { filelistString = (new AmWebClient(3000)).DownloadString(c.SubElText("Paths", "FilelistPath")); }
            catch (WebException e)
            {
                o.Messagebox(c.SubElText("Messages", "FilelistOpeningFailed"), e);
                return false;
            }

            // Attempt to read filelist's content (without comments, only first comments on rows with filelist entries are being kept for getting optional group names).
            List<string> filelistContent = new List<string>();
            List<string> comments = new List<string>();
            if (filelistString != null)
            {
                // Read only lines which have at least 6 characters. Save first found comments of each correct line as well.
                foreach (string s in filelistString.Split('\n'))
                {
                    string firstComment = "";
                    if (s.Split('#').Length > 1)
                        firstComment = s.Split('#')[1].Trim();
                    string tmp = Regex.Replace(s, @"\s+", "");
                    if (tmp.Split('#')[0].Length >= 6)
                    {
                        filelistContent.Add(tmp.Split('#')[0]);
                        comments.Add(firstComment);
                    }
                }

                // Verify that filelist is correct and readable, and save its data as objects. Otherwise end for safety reasons. 
                int index = 0;
                foreach (string s in filelistContent)
                {
                    bool isCorrect = true;
                    var arr = s.Split(';');
                    if (arr.Length == 4                         // Name;Optional?;LocalPath;LinkedList - 4 pieces of information.
                        && arr[0].Length > 0                    // Name can't be empty.
                        && (arr[1] == "0" || arr[1] == "1")     // Optional? must be either 0 or 1.
                        && arr[2].Length > 0)                   // LocalPath must always be at least '/'.
                        foreach (string a in arr[3].Split(',')) // No element in LinkedList should be empty.
                            if (a.Length == 0)
                                isCorrect = false;
                    if (arr[3].Length == 0)                     // However, if whole LinkedList is empty, its OK.
                        isCorrect = true;

                    if (!isCorrect)
                    {
                        o.Output(c.SubElText("Messages", "FilelistReadingFailed"));
                        return false;
                    }
                    else
                    {
                        string serverPath;
                        if (arr[0][0] == '/')
                            serverPath = arr[0].Substring(1);
                        else
                            serverPath = arr[0];

                        string localPath = "";
                        if (arr[2][0] != '/')
                            localPath += '/';
                        localPath += arr[2];
                        if (localPath[localPath.Length - 1] != '/')
                            localPath += '/';

                        serverSideFiles.Add(new HandledFile(serverPath, 0, arr[1], localPath, arr[3], comments[index]));
                    }
                    index++;
                }

                // Build lists of linked files for every file on server.
                List<HandledFile> linked = new List<HandledFile>();
                foreach (HandledFile hf in serverSideFiles)
                {
                    if (hf.linked != "")
                    {
                        foreach (string s in hf.linked.Split(','))
                        {
                            var namePathArr = s.Split('|');
                            string localPath = "";

                            // Use specified LocalPath behind | character. If its not set or empty, use LocalPath of file its linked from.
                            if (namePathArr.Length == 2)
                            {
                                if (namePathArr[1] != "")
                                {
                                    if (namePathArr[1][0] != '/')
                                        localPath += '/';
                                    localPath += namePathArr[1];
                                }
                                else
                                    localPath = hf.localPath;
                            }
                            else
                            {
                                localPath = hf.localPath;
                            }
                            string serverPath;
                            if (namePathArr[0][0] == '/')
                                serverPath = namePathArr[0].Substring(1);
                            else
                                serverPath = namePathArr[0];

                            HandledFile linkedFile = new HandledFile(serverPath, 0, "1", localPath, "", "");
                            linkedFile.optional = hf.optional; // LinkedLists should still be used ONLY for optional files though.
                            linked.Add(linkedFile);
                            hf.linkedList.Add(linkedFile);
                        }
                    }
                }

                // Add all files which are linked in LinkedLists to server side file list as well.
                // If any of linked files is already in server side file list, remove its previous version. LinkedList is preffered over filelist.
                foreach (HandledFile link in linked)
                {
                    HandledFile alreadyThere = null;
                    foreach (HandledFile hf in serverSideFiles)
                        if (hf.serverPath == link.serverPath)
                            alreadyThere = hf;
                    if (alreadyThere != null)
                        serverSideFiles.Remove(alreadyThere);
                    serverSideFiles.Add(link);
                }

                // Check if all files in filelist exist and get their sizes.
                bool filesOK = true;
                foreach (HandledFile hf in serverSideFiles)
                {
                    if (!SetFileSize(hf))
                        filesOK = false;
                }
                if (!filesOK)
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Gets size of given file from web and sets its value to it and checks if file actually exists and is reachable at the same time.
        /// </summary>
        /// /// <returns>Was size acquired?</returns>
        private bool SetFileSize(HandledFile hf)
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(hf.fullServerPath);
            req.Method = "HEAD";
            req.Timeout = 3000;
            try
            {
                using (HttpWebResponse resp = (HttpWebResponse)req.GetResponse())
                {
                    long contentLength;
                    if (long.TryParse(resp.Headers.Get("Content-Length"), out contentLength))
                        hf.size = contentLength;
                }
            }
            catch (WebException e)
            {
                o.Output(c.SubElText("Messages", "FileOnsWebMissing") + hf.fullServerPath, e);
                return false;
            }
            return true;
        }
        #endregion

        #region Optional list handling...
        /// <summary>
        /// Creates a list of groups of optional files and places it into optional checkbox list.
        /// </summary>
        private void BuildOptionals()
        {
            // Take a look at every server side file.
            foreach (HandledFile hf in serverSideFiles)
            {
                // Ignore files which aren't optional.
                if (hf.optional)
                {
                    // Check if an optional file is already linked from different group.
                    bool alreadyInDifferentGroup = false;
                    OptionalGroup group = null;
                    foreach (OptionalGroup og in optionalGroups)
                    {
                        if (og.Contains(hf.fullServerPath))
                        {
                            alreadyInDifferentGroup = true;
                            group = og;
                        }
                    }
                    // If an optional isn't in any group yet, create a new one for it. Use main file's first comment as a name.
                    if (!alreadyInDifferentGroup)
                    {
                        group = new OptionalGroup();
                        group.name = hf.firstComment;
                        group.Add(hf);
                        optionalGroups.Add(group);
                    }
                    // Add into group optional file was added into (or was found in) file's linked files, if they aren't there already.
                    // Note that while it is possible to chain-group files, I wouldn't really recommend it.
                    foreach (HandledFile linked in hf.linkedList)
                    {
                        bool found = false;
                        foreach (HandledFile grouped in group.files)
                        {
                            if (grouped.fullServerPath == linked.fullServerPath)
                                found = true;
                        }
                        if (!found)
                            group.Add(linked);
                    }
                }
            }

            // Check all optional groups. If any ended up without name (no first comment was set), generated one will be used. Add them into optional list.
            foreach (OptionalGroup og in optionalGroups)
            {
                if (og.name == "")
                    og.name = og.GenerateName();
                optionalsListView.Items.Add(og.name);
            }

            // Assign tooltips with optional group names, list of included file names and total size of group to optionals list.
            foreach (ListViewItem lvi in optionalsListView.Items)
            {
                lvi.ToolTipText = optionalGroups[lvi.Index].name + ":\n\n";
                foreach (HandledFile hf in optionalGroups[lvi.Index].files)
                    lvi.ToolTipText += hf.name + "\n";
                lvi.ToolTipText += "\n" + c.SubElText("MainWindow", "ToolTipTotalSize") + Size(optionalGroups[lvi.Index].GetTotalSize());
            }
            LoadOptionalSettings();
        }

        /// <summary>
        /// Attempts to loads answers user has given to the checkbox list last time.
        /// </summary>
        private void LoadOptionalSettings()
        {
            if (File.Exists("LauncherOptionalSettings.conf"))
            {
                StreamReader sr = new StreamReader("LauncherOptionalSettings.conf");
                string line;
                int notFound = optionalsListView.Items.Count;

                while ((line = sr.ReadLine()) != null)
                {
                    int id = 0;
                    List<int> toBeChecked = new List<int>();

                    foreach (ListViewItem item in optionalsListView.Items)
                    {
                        if (line.Split('#').Length == 2)
                        {
                            // Note that (only) names of optional groups are being saved and compared with current list.
                            if (line.Split('#')[0] == item.SubItems[0].Text)
                            {
                                notFound--;
                                if (line.Split('#')[1] == "1")
                                    toBeChecked.Add(id);
                            }
                            id++;
                        }
                    }
                    foreach (int index in toBeChecked)
                        optionalsListView.Items[index].Checked = true;
                }

                sr.Close();
                if (notFound != 0)
                    o.Output(c.SubElText("Messages", "OptionalsPresetLoadFailed"));
            }
            else
                o.Output(c.SubElText("Messages", "OptionalsPresetLoadFailed"));
        }

        /// <summary>
        /// Saves answers user has given to the checkbox list into LauncherOptionalSettings.conf
        /// </summary>
        public void SaveOptionalSettings()
        {
            StreamWriter sw = new StreamWriter("LauncherOptionalSettings.conf");
            foreach (ListViewItem item in optionalsListView.Items)
            {
                if (item.Checked)
                    sw.WriteLine(item.SubItems[0].Text + "#1");
                else
                    sw.WriteLine(item.SubItems[0].Text + "#0");
            }
            sw.Close();
        }
        #endregion

        #region Download list buildings methods...
        /// <summary>
        /// Checks which files need to be downloaded. Ignores optional flag.
        /// Optional files which aren't chosen are being removed from download list in FinalizeDownloadList method.
        /// </summary>
        private void PreBuildDownloadList()
        {
            // Get all MPQs in Data directory.
            var MPQFiles = Directory.GetFiles(cwd + @"\data\", "*.mpq", SearchOption.TopDirectoryOnly);
            // Check all MPQs in Data directory.
            foreach (string mpqFile in MPQFiles)
            {
                // Ignore blizzlike MPQs. Note that if KeepBlizzlikeMPQs in config is 0, blizzlikeMPQs list is empty and thus no files are ignored.
                if (!blizzlikeMPQs.Contains(mpqFile.ToLower()))
                {
                    HandledFile onServer = null;
                    // Find server side file which matches this file.
                    foreach (HandledFile hf in serverSideFiles)
                        if (hf.fullLocalPath.ToLower() == mpqFile.ToLower())
                            onServer = hf;
                    // If no matching server side file is found, this file should be deleted, its outdated or from different project.
                    if (onServer == null)
                        outdated.Add(mpqFile);
                    // If matching file on server side was found, but its size is different, new version will be downloaded.
                    else
                        if (onServer.size != new FileInfo(mpqFile).Length)
                        toBeDownloaded.Add(onServer);
                }
            }

            // Check files on server side. If they are missing or outdated in local files, add them into download list.
            foreach (HandledFile hf in serverSideFiles)
            {
                if (File.Exists(hf.fullLocalPath))
                {
                    if (new FileInfo(hf.fullLocalPath).Length != hf.size)
                        toBeDownloaded.Add(hf);
                }
                else
                    toBeDownloaded.Add(hf);
                // If a directory with zip's name doesn't exist, download a zip file as well.
                if (hf.name.Contains('.'))
                    if (hf.name.Substring(hf.name.LastIndexOf('.')).ToLower() == ".zip")
                        if (!Directory.Exists(hf.fullLocalPath.Substring(0, hf.fullLocalPath.LastIndexOf('.'))))
                            toBeDownloaded.Add(hf);
            }

            // Get total size of outdated non-optional content.
            long totalSize = 0;
            foreach (HandledFile hf in toBeDownloaded)
            {
                if (!hf.optional)
                    totalSize += hf.size;
            }
            nonOptionalOutdatedSize = Size(totalSize);
        }

        /// <summary>
        /// Finalizes download list.
        /// </summary>
        public void PrepareUpdate()
        {
            CleanDownloadList();
            FinalizeDownloadList();
        }

        /// <summary>
        /// Cleans any possible duplicates from download list. The ones which have been added into list as the first are being kept.
        /// </summary>
        private void CleanDownloadList()
        {
            List<HandledFile> duplicates = new List<HandledFile>();
            for (int i = 0; i < toBeDownloaded.Count; i++)
            {
                for (int j = i + 1; j < toBeDownloaded.Count; j++)
                {
                    if (toBeDownloaded[i].fullServerPath == toBeDownloaded[j].fullServerPath && !duplicates.Contains(toBeDownloaded[j]))
                        duplicates.Add(toBeDownloaded[j]);
                }
            }
            foreach (HandledFile hf in duplicates)
                toBeDownloaded.Remove(hf);
        }

        /// <summary>
        /// Checks which optional files need to be downloaded, based on optional checkbox list.
        /// </summary>
        private void FinalizeDownloadList()
        {
            // If any optional group isn't checked, remove its elements from download list.
            foreach (OptionalGroup og in optionalGroups)
                if (!og.isChecked)
                    foreach (HandledFile hf in og.files)
                    {
                        HandledFile matching = null;
                        foreach (HandledFile file in toBeDownloaded)
                            if (file.serverPath == hf.serverPath)
                                matching = file;
                        if (matching != null)
                            toBeDownloaded.Remove(matching);
                        // MPQ files which were downloaded as optional and are no longer wanted should be deleted as well.
                        if (File.Exists(hf.fullLocalPath))
                            if (hf.name.Contains('.'))
                                if (hf.name.Substring(hf.name.LastIndexOf('.')).ToLower() == ".mpq")
                                    outdated.Add(hf.fullLocalPath);
                    }
        }
        #endregion

        #region Update methods...
        /// <summary>
        /// Starts downloading files in download list asynchronously. Also calls cleanup methods.
        /// </summary>
        public async Task Update()
        {
            filesDownloaded = 0;

            // If realmlist is to be enforced, try to do so.
            EnforceRealmlist();
            SaveOptionalSettings();

            // Delete Cache, if you are supposed to do so.
            if (c.SubElText("Main", "DeleteCache") == "1" && Directory.Exists(cwd + "\\Cache"))
                Directory.Delete(cwd + "\\Cache", true);

            // Remove all outdated (or foreign) files which aren't to be updated. Ignore backups though.
            foreach (string s in outdated)
            {
                if (s[s.Length - 1] != '_')
                {
                    o.Output(c.SubElText("Messages", "Removing") + s);
                    if (File.Exists(s) && File.Exists(s + "_") && c.SubElText("Main", "KeepBackups") == "1")
                        File.Delete(s + "_");
                    if (File.Exists(s) && c.SubElText("Main", "KeepBackups") == "1")
                        File.Move(s, s + "_");
                    if (File.Exists(s) && c.SubElText("Main", "KeepBackups") != "1")
                        File.Delete(s);
                }
                else if (File.Exists(s) && c.SubElText("Main", "KeepBackups") != "1")
                {
                    o.Output(c.SubElText("Messages", "Removing") + s);
                    File.Delete(s);
                }
            }

            // Download all files in a download list.
            foreach (HandledFile hf in toBeDownloaded)
            {
                await Task.WhenAll(DownloadFile(hf));
            }

            // Check if everything went OK.
            if (filesDownloaded != toBeDownloaded.Count)
                o.Messagebox(c.SubElText("Messages", "FileDownloadError"));
        }

        /// <summary>
        /// Downloads given file asynchronously.
        /// </summary>
        private async Task DownloadFile(HandledFile hf)
        {
            if (c.SubElText("Main", "FileProcessingOutputs") == "1")
            {
                o.Output(c.SubElText("Messages", "DownloadingFrom") + hf.fullServerPath, true);
                o.Output(c.SubElText("Messages", "DownloadingTo") + hf.fullLocalPath);
            }

            try
            {
                using (var client = new AmWebClient(3000))
                {
                    if (!Directory.Exists(cwd + hf.localPath))
                        Directory.CreateDirectory(cwd + hf.localPath);
                    if (File.Exists(hf.fullLocalPath) && File.Exists(hf.fullLocalPath + "_") && c.SubElText("Main", "KeepBackups") == "1")
                        File.Delete(hf.fullLocalPath + "_");
                    if (File.Exists(hf.fullLocalPath))
                        File.Move(hf.fullLocalPath, hf.fullLocalPath + "_");
                    await client.DownloadFileTaskAsync(hf.fullServerPath, hf.fullLocalPath);
                    if (IsFileOK(hf))
                    {
                        UnZip(hf.fullLocalPath);
                        filesDownloaded++;
                    }
                }
            }
            catch (WebException e) { o.Output(c.SubElText("Messages", "DownloadError") + hf.name, e); }
        }

        /// <summary>
        /// Sets player's realmlist to realmlist placed in FilesRootPath. Can be turned off in config's ForcedRealmlist attribute.
        /// </summary>
        private void EnforceRealmlist()
        {
            string correctRealmlist = "";
            if (c.SubElText("Main", "ForcedRealmlist") == "1")
            {
                // Attempt to get data from realmlist.wtf on web.
                try { correctRealmlist = (new AmWebClient(3000)).DownloadString(c.SubElText("Paths", "FilesRootPath") + "realmlist.wtf"); }
                catch { o.Output(c.SubElText("Messages", "WebRealmlistMissing")); }

                // Attempt to find local realmlist.wtf. If it is found, update it.
                if (correctRealmlist != "")
                {
                    var realmlists = Directory.GetFiles(Directory.GetCurrentDirectory() + @"\data\", "realmlist.wtf", SearchOption.AllDirectories);
                    if (realmlists.Length != 0)
                    {
                        StreamWriter sw = new StreamWriter(realmlists[0]);
                        sw.Write(correctRealmlist);
                        sw.Close();
                    }
                    else
                        o.Output(c.SubElText("Messages", "RealmlistMissing"));
                }
            }
        }

        /// <summary>
        /// Unzips a file in given path, if it is a .zip file.
        /// Room for improvement - implementing RAR and 7z support.
        /// </summary>
        private void UnZip(string filePath)
        {
            if (File.Exists(filePath) && filePath.Substring(filePath.LastIndexOf('.')) == ".zip")
            {
                try
                {
                    if (c.SubElText("Main", "FileProcessingOutputs") == "1")
                        o.Output(c.SubElText("Messages", "UnzipingFile") + filePath);
                    Shell32.Shell objShell = new Shell32.Shell();
                    Shell32.Folder destinationFolder = objShell.NameSpace(filePath.Substring(0, filePath.LastIndexOf('\\') + 1));
                    Shell32.Folder sourceFile = objShell.NameSpace(filePath);

                    // Change to destinationFolder.CopyHere(zipFile, 4 | 16) if you don't want to see untipping windows appearing
                    foreach (var zipFile in sourceFile.Items())
                    {
                        destinationFolder.CopyHere(zipFile, 16);
                    }
                }
                catch (Exception e) { o.Output(c.SubElText("Messages", "UnZipingFileError") + filePath, e); }
            }
        }

        /// <summary>
        /// Deletes all .extension_ backup files in client.
        /// </summary>
        public void DeleteBackups()
        {
            var backups = Directory.GetFiles(cwd, "*_", SearchOption.AllDirectories);
            foreach (string s in backups)
                if (File.Exists(s))
                    File.Delete(s);
        }
        #endregion
    }

    /// <summary>
    /// Container for file lists handling.
    /// </summary>
    public class HandledFile
    {
        // Data obtained from filelist
        public string serverPath;             // Path relative to FilesRootPath
        public long size = 0;                 // Size of a file
        public bool optional = false;         // Is file optional?
        public string localPath = "";         // Path relative to WoW root directory
        public string linked = "";            // String of LinkedList
        public string firstComment = "";      // First comment found on a line behind a file in a filelist
        // Generated data for easier work.
        public List<HandledFile> linkedList = new List<HandledFile>(); // List of HandledFile instances which are reffered in LinkedList
        public string name;                   // Name of a file (without any relative path in front of it)
        public string fullLocalPath;          // Full local path.
        public string fullServerPath;         // Full URL to file.

        public HandledFile(string serverPath, long size, string optional, string localPath, string linked, string firstComment)
        {
            // Save data obtained from filelist.
            this.serverPath = serverPath;
            this.size = size;
            if (optional == "0")
                this.optional = false;
            else
                this.optional = true;
            this.localPath = Regex.Replace(localPath, "/", "\\");
            this.linked = linked;
            this.firstComment = firstComment;

            // Save other data based on data obtained from filelist.
            if (serverPath.Contains('/'))
                name = serverPath.Substring(serverPath.LastIndexOf('/') + 1);
            else
                name = serverPath;
            fullLocalPath = Directory.GetCurrentDirectory() + this.localPath + name;
            fullServerPath = Config.Instance.SubElText("Paths", "FilesRootPath") + serverPath;
        }
    }

    /// <summary>
    /// Group of optional files which are linked together.
    /// </summary>
    public class OptionalGroup
    {
        public List<HandledFile> files = new List<HandledFile>(); // List of HandledFile instances which are contained in a group.
        public string name = "";                                  // Name of optional group for display purpouses in optional list.
        public bool isChecked = false;                            // Is optional group checked in optional list?

        /// <summary>
        /// Generates and returns a name of group based on elements it has in at the moment. Used if no name (from main file's first comment) is set.
        /// </summary>
        public string GenerateName()
        {
            string generatedName = "";
            foreach (HandledFile hf in files)
            {
                if (hf.serverPath.Contains('/'))
                    generatedName += hf.serverPath.Substring(hf.serverPath.LastIndexOf('/') + 1) + ", ";
                else
                    generatedName += hf.serverPath + ", ";
            }
            generatedName = generatedName.Substring(0, generatedName.LastIndexOf(','));
            return generatedName;
        }

        /// <summary>
        /// Returns wheter given file name can be found in a group.
        /// </summary>
        public bool Contains(string fullServerPath)
        {
            foreach (HandledFile hf in files)
                if (hf.fullServerPath == fullServerPath)
                    return true;
            return false;
        }

        /// <summary>
        /// Adds a file into optional group.
        /// </summary>
        public void Add(HandledFile file)
        {
            files.Add(file);
        }

        /// <summary>
        /// Returns amount of elements in optional group.
        /// </summary>
        public int Count()
        {
            return files.Count;
        }

        /// <summary>
        /// Returns total size of an optional group.
        /// </summary>
        public long GetTotalSize()
        {
            long result = 0;
            foreach (HandledFile hf in files)
                result += hf.size;
            return result;
        }

        /// <summary>
        /// Returns a total size of files in an optional group, but only of those files, which aren't up to date.
        /// </summary>
        public long GetSizeForDownload(List<HandledFile> toBeDownloaded)
        {
            long result = 0;
            foreach (HandledFile hf in files)
            {
                foreach (HandledFile file in toBeDownloaded)
                    if (file.serverPath == hf.serverPath)
                        result += hf.size;
            }
            return result;
        }
    }
}