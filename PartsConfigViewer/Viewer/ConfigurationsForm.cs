using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Viewer
{
    public partial class ConfigurationsForm : Form
    {
        private string outputLogFile = null;
        private string configCacheFile = null;

        public ConfigurationsForm(string outputLogFile, string configCacheFile)
        {
            InitializeComponent();
            if(outputLogFile != null && File.Exists(outputLogFile))
            {
                this.outputLogFile = outputLogFile;
                outputLogTextBox.Text = outputLogFile;
            }

            if (configCacheFile != null && File.Exists(configCacheFile))
            {
                this.configCacheFile = configCacheFile;
                configCacheTextBox.Text = configCacheFile;
            }
        }

        private bool filesExist()
        {
            if (outputLogFile != null && File.Exists(outputLogFile))
                if (configCacheFile != null && File.Exists(configCacheFile))
                    return true;
            return false;
        }

        public string OutputLogFile { get { return outputLogFile; } }
        public string ConfigCacheFile { get { return configCacheFile; } }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void OkBtn_Click(object sender, EventArgs e)
        {
            configCacheFile = configCacheTextBox.Text;
            outputLogFile = outputLogTextBox.Text;
            DialogResult = filesExist() ? DialogResult.OK : DialogResult.Cancel;
            Close();
        }

        private void browseOutputBtn_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "output_log.txt"; //TODO fix
            string startDirectory = outputLogTextBox.Text;
            openFileDialog.InitialDirectory = startDirectory;
            if(openFileDialog.ShowDialog() == DialogResult.OK)
                outputLogTextBox.Text = openFileDialog.FileName;
        }

        private void browseConfigCacheBtn_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "ModuleManager.ConfigCache"; //TODO fix
            string startDirectory = configCacheTextBox.Text;
            openFileDialog.InitialDirectory = startDirectory;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
                configCacheTextBox.Text = openFileDialog.FileName;
        }
    }
}
