using System;
using System.IO;
using System.Windows.Forms;

namespace FileWatcher
{
    public partial class ConfigFrm : Form
    {
        public ConfigFrm()
        {
            InitializeComponent();
            InitializeForm();
        }

        private void InitializeForm()
        {
            destinationPathTxt.Text = ConfigManager.GetDestinationPath();
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            string newPath = destinationPathTxt.Text.Trim();

            if (IsValidPath(newPath))
            {
                ConfigManager.SetDestinationPath(newPath);
                MessageBox.Show("Destination path saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            else
            {
                MessageBox.Show("Please enter a valid destination path.", "Invalid Path", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool IsValidPath(string path)
        {
            return !string.IsNullOrWhiteSpace(path) && (Directory.Exists(path) || File.Exists(path));
        }

        private void browseBtn_Click(object sender, EventArgs e)
        {
            using (var folderBrowser = new FolderBrowserDialog())
            {
                if (folderBrowser.ShowDialog() == DialogResult.OK)
                {
                    destinationPathTxt.Text = folderBrowser.SelectedPath;
                }
            }
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }

    public static class ConfigManager
    {
        public static string GetDestinationPath()
        {
            return Properties.Settings.Default.DestinationPath;
        }

        public static void SetDestinationPath(string path)
        {
            Properties.Settings.Default.DestinationPath = path;
            Properties.Settings.Default.Save();
        }
    }
}
