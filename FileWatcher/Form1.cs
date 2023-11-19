using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace FileWatcher
{
    public partial class Form1 : Form
    {
        private ConfigFrm configFrm;
        private FileSystemWatcher watcher;
        private bool isWatching = false;

        public Form1()
        {
            InitializeComponent();
            configFrm = new ConfigFrm();
            filePathTxt.Text = Properties.Settings.Default.FilePath;
        }

        private bool IsPathValid(string path)
        {
            return Directory.Exists(path) || File.Exists(path);
        }

        private void FileWatcherStart()
        {
            if (watcher != null)
            {
                watcher.Dispose();
            }

            watcher = new FileSystemWatcher();
            string filePath = filePathTxt.Text;
            string destinationPath = Properties.Settings.Default.DestinationPath;

            if (!IsPathValid(filePath))
            {
                MessageBox.Show("File path does not exist or is invalid.", "Invalid File Path", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!IsPathValid(destinationPath))
            {
                MessageBox.Show("Destination path does not exist or is invalid.", "Invalid Destination Path", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            watcher.Path = Path.GetDirectoryName(filePath);
            watcher.Filter = Path.GetFileName(filePath);
            watcher.NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.FileName;

            watcher.Changed += Watcher_Changed;
            watcher.Renamed += Watcher_Renamed;

            watcher.EnableRaisingEvents = true;
            isWatching = true;
            logTxt.Clear();
            logTxt.AppendText($"{DateTime.Now} - File watcher started...\r\n");
            watchBtn.Text = "Stop Watching";
        }

        private void Watcher_Changed(object sender, FileSystemEventArgs e)
        {
            ProcessFileChange(e.FullPath);
        }

        private void Watcher_Renamed(object sender, RenamedEventArgs e)
        {
            ProcessFileChange(e.FullPath);
        }

        private void ProcessFileChange(string fullPath)
        {
            if (File.Exists(fullPath))
            {
                try
                {
                    string destinationFilePath = Path.Combine(Properties.Settings.Default.DestinationPath, Path.GetFileName(fullPath));
                    File.Copy(fullPath, destinationFilePath, true);
                    logTxt.Invoke((MethodInvoker)delegate {
                        logTxt.AppendText($"{DateTime.Now} - File copied to: {destinationFilePath}\r\n");
                    });
                }
                catch (Exception ex)
                {
                    logTxt.Invoke((MethodInvoker)delegate {
                        logTxt.AppendText($"{DateTime.Now} - Error copying file: {ex.Message}\r\n");
                    });
                }
            }
        }

        private void FileWatcherStop()
        {
            if (watcher != null)
            {
                watcher.EnableRaisingEvents = false;
                watcher.Dispose();
                isWatching = false;
                watchBtn.Text = "Start Watching";
                logTxt.Clear();
                logTxt.AppendText($"{DateTime.Now} - File watcher stopped...\r\n");
            }
        }

        private void configBtn_Click(object sender, EventArgs e)
        {
            configFrm.ShowDialog();
            logTxt.AppendText($"{DateTime.Now} - Destination path: {Properties.Settings.Default.DestinationPath}\r\n");
        }

        private void watchBtn_Click(object sender, EventArgs e)
        {
            if (!isWatching)
            {
                Properties.Settings.Default.FilePath = filePathTxt.Text;
                Properties.Settings.Default.Save();
                FileWatcherStart();
            }
            else
            {
                FileWatcherStop();
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            FileWatcherStop();
        }

        private void filePathTxt_TextChanged(object sender, EventArgs e)
        {
            string filePath = filePathTxt.Text.Trim();

            if (!string.IsNullOrEmpty(filePath) && Path.HasExtension(filePath))
            {
                string fileExtension = Path.GetExtension(filePath);

                List<string> supportedExtensions = new List<string>
                {
                    ".exe", ".txt", ".dll", ".jpg", ".png", ".pdf", ".docx"
                };

                if (!string.IsNullOrEmpty(fileExtension) &&
                    supportedExtensions.Contains(fileExtension, StringComparer.OrdinalIgnoreCase))
                {
                    logTxt.AppendText($"{DateTime.Now} - File path: {filePath}\r\n");
                }
            }
        }
    }
}