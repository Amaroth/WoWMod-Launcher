using System;
using System.Windows.Forms;

namespace AmarothLauncher.Core
{
    /// <summary>
    /// OutputWriter is a singleton responsible for writing outputs to debug window in main window.
    /// </summary>
    class OutputWriter
    {
        static int index = 1;
        public static RichTextBox outputBox;
        private static OutputWriter instance;
        static Config c = Config.Instance;

        private OutputWriter() { }

        public static OutputWriter Instance
        {
            get
            {
                if (instance == null)
                    instance = new OutputWriter();
                return instance;
            }
        }

        /// <summary>
        /// Empties output window and resets index.
        /// </summary>
        public void Reset()
        {
            outputBox.Text = c.SubElText("Messages", "HelloMessage") + "\n\n";
            if (c.isDefaultConfigUsed)
                outputBox.Text += c.SubElText("Messages", "XmlNotOpened");
            index = 1;
        }

        #region Standart text outputs...
        /// <summary>
        /// Writes a message into output window with message's ID.
        /// </summary>
        public void Output(string text)
        {
            if (outputBox != null)
                outputBox.Text += index + ": " + text + "\n";
            index++;
        }

        /// <summary>
        /// Writes a message into output window, followed by a line break and given exception's message.
        /// </summary>
        public void Output(string text, Exception e)
        {
            Output(text + "\n" + e.Message);
            index++;
        }

        /// <summary>
        /// Writes a message into output window with message's ID and optionally adds an indent in front of it.
        /// </summary>
        public void Output(string text, bool indent)
        {
            if (outputBox != null)
            {
                if (indent && index != 1)
                    outputBox.Text += "\n";
                Output(text);
            }
        }

        /// <summary>
        /// Writes TRUE or FALSE, depending on result of bool result. For debugging purpouses.
        /// </summary>
        public void Output(bool test)
        {
            if (test)
                Output("TRUE");
            else
                Output("FALSE");
        }
        #endregion

        #region MessageBox outputs, should be used for critical messages.
        /// <summary>
        /// Shows a message box with an error and also sends an error to output window. Used for critical errors.
        /// </summary>
        public void Messagebox(string text)
        {
            MessageBox.Show(text);
            Output(text);
        }

        /// <summary>
        /// Shows a message box with and error and given exception's message separated by a line break. Used for critical errors.
        /// </summary>
        public void Messagebox(string text, Exception e)
        {
            MessageBox.Show(text + "\n" + e.Message);
            Output(text, e);
        }
        #endregion
    }
}