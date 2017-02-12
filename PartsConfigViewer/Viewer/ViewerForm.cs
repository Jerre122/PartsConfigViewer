using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Viewer
{
    public partial class ViewerForm : Form
    {
        private string outputLogFile = @"D:\Program Files (x86)\Kerbal Space Program - Development\KSP_x64_Data\output_log.txt";
        private string configCacheFile = @"D:\Program Files (x86)\Kerbal Space Program - Development\GameData\ModuleManager.ConfigCache";

        public ViewerForm()
        {
            InitializeComponent();
            loadFiles();
        }

        private void configurationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfigurationsForm configForm = new ConfigurationsForm(outputLogFile, configCacheFile);
            DialogResult result = configForm.ShowDialog();
            Console.WriteLine("Modal form result = " + result.ToString());
            if (result == DialogResult.OK)
            {
                configCacheFile = configForm.ConfigCacheFile;
                outputLogFile = configForm.OutputLogFile;
            } 
        }

        private void loadFiles()
        {
            //TODO verify existence of files before loading
            File out
        }
    }
}
