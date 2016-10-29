using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Xml;

namespace AmarothLauncher.Core
{
    public class Changelog
    {
        string path;
        Config c = Config.Instance;
        OutputWriter o = OutputWriter.Instance;
        XmlDocument xml = new XmlDocument();

        /// <summary>
        /// Creates new changelog instance and gets up to date version of changelog from web.
        /// </summary>
        public Changelog()
        {
            path = c.SubElText("Paths", "ChangelogPath");
            Initialize();
        }

        /// <summary>
        /// Initialization. Tryes to open changelog from web and load it as XML.
        /// </summary>
        private void Initialize()
        {
            string xmlString = "";

            try { xmlString = (new AmWebClient(3000)).DownloadString(path); }
            catch (WebException e)
            {
                o.Messagebox(c.SubElText("Messages", "ChangelogNotOpened"), e);
                xml = null;
                return;
            }

            try { xml.LoadXml(xmlString); }
            catch (Exception e)
            {
                o.Messagebox(c.SubElText("Messages", "ChangelogNotLoaded"), e);
                xml = null;
                return;
            }
        }

        #region Data getters...
        /// <summary>
        /// Returns description text of given entry.
        /// </summary>
        public string GetText(int id)
        {
            return xml.DocumentElement.ChildNodes[id].InnerText;
        }

        /// <summary>
        /// Returns heading text of given entry.
        /// </summary>
        public string GetHeading(int id)
        {
            return xml.DocumentElement.ChildNodes[id].Attributes["heading"].Value;
        }

        /// <summary>
        /// Returns picture URL of given entry.
        /// </summary>
        public string GetPicture(int id)
        {
            return xml.DocumentElement.ChildNodes[id].Attributes["pictureURL"].Value;
        }

        /// <summary>
        /// Returns date string of given entry.
        /// </summary>
        public string GetDate(int id)
        {
            return xml.DocumentElement.ChildNodes[id].Attributes["date"].Value;
        }

        /// <summary>
        /// Returns amount of entries in changelog.
        /// </summary>
        public int GetAmount()
        {
            if (xml != null)
                return xml.DocumentElement.ChildNodes.Count;
            else
                return 0;
        }
        #endregion

        #region Methods for modifying changelog...
        /// <summary>
        /// Updates given element's description, picture URL, date string and heading.
        /// </summary>
        public void UpdateElement(int id, string description, string pictureURL, string date, string heading)
        {
            xml.DocumentElement.ChildNodes[id].InnerText = description;
            xml.DocumentElement.ChildNodes[id].Attributes["pictureURL"].Value = pictureURL;
            xml.DocumentElement.ChildNodes[id].Attributes["date"].Value = date;
            xml.DocumentElement.ChildNodes[id].Attributes["heading"].Value = heading;
        }

        /// <summary>
        /// Creates a new entry with given description, picture URL, date string and heading.
        /// </summary>
        public void AddElement(string description, string pictureURL, string date, string heading)
        {
            if (xml == null)
            {
                o.Messagebox(c.SubElText("Messages", "ChangelogEmpty"));
                NewXml();
            }
            XmlNode node = xml.CreateElement("release");

            XmlAttribute head = xml.CreateAttribute("heading");
            head.Value = heading;
            node.Attributes.Append(head);

            XmlAttribute entry = xml.CreateAttribute("date");
            entry.Value = date;
            node.Attributes.Append(entry);

            XmlAttribute url = xml.CreateAttribute("pictureURL");
            url.Value = pictureURL;
            node.Attributes.Append(url);

            node.InnerText = description;

            xml.DocumentElement.AppendChild(node);

        }

        /// <summary>
        /// Removes given entry from changelog.
        /// </summary>
        public void RemoveElement(int id)
        {
            if (xml.ChildNodes.Count > id)
                xml.DocumentElement.RemoveChild(xml.DocumentElement.ChildNodes[id]);
        }
        #endregion

        #region Misc stuff...
        /// <summary>
        /// Sorts changelog by date (descending).
        /// </summary>
        public void SortXml(string dateFormat)
        {
            if (xml.ChildNodes.Count > 0)
            {
                List<ChangelogEntry> releases = new List<ChangelogEntry>();
                foreach (XmlNode node in xml.DocumentElement.ChildNodes)
                {
                    releases.Add(new ChangelogEntry(node.Attributes["date"].Value, dateFormat, node.Attributes["heading"].Value, node.Attributes["pictureURL"].Value, node.InnerText));
                }
                releases.Sort((x, y) => x.date.CompareTo(y.date));
                releases.Reverse();
                NewXml();
                foreach (ChangelogEntry rel in releases)
                {
                    AddElement(rel.text, rel.pictureURL, rel.date.ToString(dateFormat), rel.heading);
                }
            }
        }

        /// <summary>
        /// Saves changelog as XML file.
        /// </summary>
        public void SaveXml()
        {
            TextWriter sw = new StreamWriter("changelog.xml", false, Encoding.UTF8);
            if (xml != null)
                xml.Save(sw);
            else
            {
                NewXml();
                xml.Save(sw);
            }
            sw.Close();
        }

        /// <summary>
        /// Re-creates a blank new changelog.
        /// </summary>
        private void NewXml()
        {
            XmlDocument newXml = new XmlDocument();

            XmlDeclaration declaration = newXml.CreateXmlDeclaration("1.0", "UTF-8", null);
            XmlElement root = newXml.DocumentElement;
            newXml.InsertBefore(declaration, root);

            XmlElement releases = newXml.CreateElement("releases");
            newXml.AppendChild(releases);

            xml = newXml;
        }
        #endregion
    }

    /// <summary>
    /// Container for easier management of changelog entries when they are being sorted.
    /// </summary>
    class ChangelogEntry
    {
        public DateTime date;
        public string heading;
        public string pictureURL;
        public string text;

        public ChangelogEntry(string date, string dateFormat, string heading, string pictureURL, string text)
        {
            this.date = DateTime.ParseExact(date, dateFormat, null);
            this.heading = heading;
            this.pictureURL = pictureURL;
            this.text = text;
        }
    }
}
