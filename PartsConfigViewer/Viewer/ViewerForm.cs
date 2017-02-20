using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Viewer
{
    public partial class ViewerForm : Form
    {
        private const string URLCONFIG = "UrlConfig";
        private TypeFilter[] filters;
        private bool ignoreFilterUpdate = false;

        private string outputLogFile = @"D:\Program Files (x86)\Kerbal Space Program - Development\KSP_x64_Data\output_log.txt";
        private string configCacheFile = @"D:\Program Files (x86)\Kerbal Space Program - Development\GameData\ModuleManager.ConfigCache";

        //private string outputLogFile = @"G:\Program Files (x86)\Steam\steamapps\common\Kerbal Space Program - Non Steam\KSP_x64_Data\output_log.txt";
        //private string configCacheFile = @"G:\Program Files (x86)\Steam\steamapps\common\Kerbal Space Program - Non Steam\GameData\ModuleManager.ConfigCache";

        /*
            Celestial body (CELESTIAL_BODY)
            Contract
                -Definition (CONTRACT_DEFINITION)
                -Type (CONTRACT_TYPE)
        */

        private ConfigNode topNode;

        public ViewerForm()
        {
            InitializeComponent();
            loadFilters();
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

        private void loadFilters()
        {
            //TODO load from file;
            ignoreFilterUpdate = true;
            filters = new TypeFilter[]{
                new TypeFilter("Resources", new string[] { "RESOURCE_DEFINITION", "BIOME_RESOURCE" }),
                new TypeFilter("Parts", new string[] {"PART"}),
                new TypeFilter("Contact", new string[] {"CONTRACT_TYPE", "CONTRACT_GROUP", "AGENT"}),
                new TypeFilter("Other", null)
            };

            for(int i = 0; i < filters.Length; i++)
            {
                TypeFilter filter = filters[i];
                filter.SetActive(true);
                int k = i;
                ToolStripButton toolStripButton = new ToolStripButton(filter.Name, null, (sender, e) => clickFilter(sender, e, k));
                toolStripButton.Checked = true;
                filterTreeToolStripMenuItem.DropDownItems.Add(toolStripButton);

            }

            filterTreeToolStripMenuItem.DropDownItems.Add(new ToolStripButton("Check All", null, (sender, e) => checkAll(sender, e)));
            ignoreFilterUpdate = false;
        }

        private void clickFilter(object sender, EventArgs e, int index)
        {
            ToolStripButton filterButton = (ToolStripButton)filterTreeToolStripMenuItem.DropDownItems[index];
            filterButton.Checked = filters[index].Toggle();
            if(!ignoreFilterUpdate)
                rebuildConfigTree();
        }

        private void checkAll(object sender, EventArgs e)
        {
            ignoreFilterUpdate = true;
            bool update = false;
            for (int i = 0; i < filters.Length; i++)
            {
                if (filters[i].IsActive())
                {
                    update = true;
                    ((ToolStripButton)filterTreeToolStripMenuItem.DropDownItems[i]).Checked = true;
                }
            }
            ignoreFilterUpdate = false;
            if(update)
                rebuildConfigTree();
        }

        private void loadFiles()
        {
            bool failed = false;
            if(outputLogFile == null || !File.Exists(outputLogFile))
            {
                Console.WriteLine("Outputlog file (" + outputLogFile + ") does not exist.");
                failed |= true;
            }

            if (configCacheFile == null || !File.Exists(configCacheFile))
            {
                Console.WriteLine("ConfigCache file (" + configCacheFile + ") does not exist.");
                failed |= true;
            }

            if (failed)
                return;
        
            topNode = ConfigNode.Load(configCacheFile);            
            Console.WriteLine(topNode.CountNodes + " nodes loaded.");
            if((topNode?.CountNodes ?? 0) > 0)
            {
                populateConfigTree(topNode);
            }
            return;
        }        

        private void populateConfigTree(ConfigNode topNode, string searchWord = null)
        {
            //TODO root has attributes

            configTree.Nodes.Clear();
            configTree.BeginUpdate();
            ConfigTreeNode root = new ConfigTreeNode(topNode);
            foreach (ConfigNode node in topNode.nodes.GetNodes())
            {
                ConfigTreeNode treeNode = getChildren(node, searchWord);
                if(treeNode != null)
                {
                    root.Nodes.Add(treeNode);
                    //configTree.Nodes.Add(treeNode);
                }                    
            }
            configTree.Nodes.Add(root);
            root.Expand();
            configTree.EndUpdate();
        }

        private ConfigTreeNode makeTreeNode(ConfigNode node)
        {            
            if(node.name.Equals(URLCONFIG, StringComparison.InvariantCultureIgnoreCase) && node.HasValue("name")){
                return new ConfigTreeNode(node, node.GetValue("name"));
            }

            return new ConfigTreeNode(node);
        }

        private ConfigTreeNode getChildren(ConfigNode node, string searchWord)
        {
            //Check attributes      
            bool wordFound = false;      
            ConfigTreeNode treeNode = null;
            foreach (ConfigNode.Value value in node.values)
            {
                if(searchWord == null || CultureInfo.CurrentCulture.CompareInfo.IndexOf(value.value, searchWord, CompareOptions.IgnoreCase) >= 0)
                {
                    //match found
                    wordFound = true;
                    treeNode = makeTreeNode(node);
                    break;
                }
            }
                        
            if(node.CountNodes > 0)            
            {
                foreach (ConfigNode childNode in node.nodes.GetNodes())
                {
                    ConfigTreeNode childTreeNode = getChildren(childNode, wordFound ? null : searchWord);
                    if(childTreeNode != null)
                    {
                        //Child contains searchWord
                        if (treeNode == null)
                            treeNode = makeTreeNode(node);
                        treeNode.Nodes.Add(childTreeNode);
                    }
                }
            }
            return treeNode;
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            rebuildConfigTree();
        }

        private void rebuildConfigTree()
        {
            string searchWord = searchTextBox.Text.Trim();
            populateConfigTree(topNode, searchWord.Length > 0 ? searchWord : null);
        }

        private void configTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if(e.Action == TreeViewAction.ByMouse || e.Action == TreeViewAction.ByKeyboard)
            {
                ConfigTreeNode selected = (ConfigTreeNode)e.Node;
                ConfigNode configNode = selected.Data;
                if(configNode.name == URLCONFIG)
                {
                    configView.SetData(configNode);
                }
            }
        }
    }
}
