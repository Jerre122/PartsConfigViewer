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
        private TypeFilters filters;
        private bool ignoreFilterUpdate = false;

        //private string outputLogFile = @"D:\Program Files (x86)\Kerbal Space Program - Development\KSP_x64_Data\output_log.txt";
        //private string configCacheFile = @"D:\Program Files (x86)\Kerbal Space Program - Development\GameData\ModuleManager.ConfigCache";

        private string outputLogFile = @"G:\Program Files (x86)\Steam\steamapps\common\Kerbal Space Program - Non Steam\KSP_x64_Data\output_log.txt";
        private string configCacheFile = @"G:\Program Files (x86)\Steam\steamapps\common\Kerbal Space Program - Non Steam\GameData\ModuleManager.ConfigCache";

        /*
            Celestial body (CELESTIAL_BODY)
            Contract
                -Definition (CONTRACT_DEFINITION)
                -Type (CONTRACT_TYPE)
        */

        private ConfigNode topNode;
        private ConfigTreeNode typeFilteredRoot;

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


            TypeFilter[] tmpFilters = new TypeFilter[]{ //TODO load from external file
                new TypeFilter("Agents", new string[] {"AGENT"}),
                new TypeFilter("Character", new string[] {"EXPERIENCE_TRAITS", "STORY_DEF"}),
                new TypeFilter("Resources", new string[] { "RESOURCE_DEFINITION", "BIOME_RESOURCE", "PLANETARY_RESOURCE", "GLOBAL_RESOURCE"}),
                new TypeFilter("Scansat", new string[] {"SCANSAT_SENSOR", "SCAN_COLOR_CONFIG", "SCAN_COLOR_LOCALISATION" }),
                new TypeFilter("Parts", new string[] {"PART"}),
                new TypeFilter("Interior", new string[] {"INTERNAL"}),
                new TypeFilter("Contract", new string[] {"CONTRACT_TYPE", "CONTRACT_GROUP", "CONTRACT_DEFINITION", "DMCONTRACTS", "CONTRACTS"}),
                new TypeFilter("Experiments", new string[] {"CC_EXPERIMENT_DEFINITIONS", "EXPERIMENT_DEFINITION", "SCIENCECHECKLIST"}),
                new TypeFilter("Prop", new string[] {"PROP"}),
                new TypeFilter("Celestial", new string[] {"CELESTIAL_BODY", "CELESTIALBODYCOLOR", "PLANETSHINECELESTIALBODY", "PLANETSHINE"}),
                new TypeFilter("Strategies", new string[] {"STRATEGY", "STRATEGY_DEPARTMENT"}),
                new TypeFilter("Tech tree", new string[] {"TECHTREE" }),
                new TypeFilter("Tutorial", new string[] {"TUTORIAL" }),
                new TypeFilter("Other", null)
            };

            filters = new TypeFilters(tmpFilters);


            filterTreeToolStripMenuItem.DropDown.AutoClose = false;
            filterTreeToolStripMenuItem.DropDown.MouseLeave += new EventHandler(filterMenu_MouseLeave);
            for (int i = 0; i < filters.Count; i++)
            {
                TypeFilter filter = filters.GetFilter(i);
                filter.SetActive(true);
                int k = i;
                ToolStripMenuItem toolStripButton = new ToolStripMenuItem(filter.Name, null, (sender, e) => clickFilter(k));
                toolStripButton.Checked = true;
                filterTreeToolStripMenuItem.DropDownItems.Add(toolStripButton);

            }

            filterTreeToolStripMenuItem.DropDownItems.Add(new ToolStripMenuItem("Check All", null, (sender, e) => checkAll(true)));
            filterTreeToolStripMenuItem.DropDownItems.Add(new ToolStripMenuItem("Uncheck All", null, (sender, e) => checkAll(false)));
            ignoreFilterUpdate = false;
        }

        private void clickFilter(int index)
        {
            ToolStripMenuItem filterButton = (ToolStripMenuItem)filterTreeToolStripMenuItem.DropDownItems[index];
            filterButton.Checked = filters.GetFilter(index)?.Toggle() ?? false;
            if(!ignoreFilterUpdate)
                rebuildTypeFilteredConfigTree();
        }

        private void checkAll(bool check)
        {
            ignoreFilterUpdate = true;
            bool update = false;
            for (int i = 0; i < filters.Count; i++)
            {
                TypeFilter filter = filters.GetFilter(i);
                if (filter != null && (filter.IsActive() != check))
                {
                    update = true;
                    clickFilter(i);
                }
            }
            ignoreFilterUpdate = false;
            if(check)
                filterTreeToolStripMenuItem.DropDown.Close();
            if (update)
                rebuildTypeFilteredConfigTree();
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

        
        private void populateConfigTree(ConfigTreeNode topTreeNode, string searchWord = null)
        {
            //TODO root has attributes
            configTree.BeginUpdate();
            configTree.Nodes.Clear();

            ConfigTreeNode root = new ConfigTreeNode(topTreeNode.Data);
            bool searchFound = false;
            foreach (ConfigTreeNode node in topTreeNode.Nodes)
            {
                ConfigTreeNode treeNode = getChildren(node, searchWord);
                if (treeNode != null)
                {
                    searchFound = true;
                    root.Nodes.Add(treeNode);
                    //configTree.Nodes.Add(treeNode);
                }
            }
            if (searchFound)
            {
                configTree.Nodes.Add(root);
                root.Expand();
            }                
            configTree.EndUpdate();
        }

        private void populateConfigTree(ConfigNode topNode, string searchWord = null)
        {
            //TODO root has attributes

            configTree.BeginUpdate();
            configTree.Nodes.Clear();            
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
            if(node.name.Equals(URLCONFIG, StringComparison.InvariantCultureIgnoreCase))
            {
                if (!node.HasValue("name"))
                    Console.WriteLine("NoName");
                if (node.nodes.Count != 1)
                    Console.WriteLine("Count not 1");
                if(node.values.Count != 4)
                    Console.WriteLine("Values not 4");
            }
            if (node.name.Equals(URLCONFIG, StringComparison.InvariantCultureIgnoreCase)){

                string name = node.HasValue("name") ? node.GetValue("name") : null;

                if(node == null)
                    Console.WriteLine("URLCONFIG found without a name.");
                if (node.CountValues != 4)
                    Console.WriteLine("URLCONFIG confignode (" + node ?? "<no name found>" + ") should contain 4 values.");
                if (node.CountNodes != 1)
                    Console.WriteLine("URLCONFIG confignode (" + node ?? "<no name found>" + ") should contain 1 node.");

                if (name != null)
                    return new ConfigTreeNode(node, name);
                
                    
            }

            return new ConfigTreeNode(node);
        }

        private ConfigTreeNode getChildren(ConfigTreeNode node, string searchWord = null)
        {
            //Check attributes      
            bool wordFound = false;
            ConfigTreeNode treeNode = null;
            foreach (ConfigNode.Value value in node.Data.values)
            {
                if (searchWord == null || CultureInfo.CurrentCulture.CompareInfo.IndexOf(value.value, searchWord, CompareOptions.IgnoreCase) >= 0)
                {
                    //match found
                    wordFound = true;
                    treeNode = makeTreeNode(node.Data);
                    break;
                }
            }

            if (node.Data.CountNodes > 0)
            {
                foreach (ConfigNode childNode in node.Data.nodes.GetNodes()) //TODO probably not correct, also, doesn't copy existing treeNode
                {
                    ConfigTreeNode childTreeNode = getChildren(childNode, wordFound ? null : searchWord);
                    if (childTreeNode != null)
                    {
                        //Child contains searchWord
                        if (treeNode == null)
                            treeNode = makeTreeNode(node.Data);
                        treeNode.Nodes.Add(childTreeNode);
                    }
                }
            }
            return treeNode;
        }

        private ConfigTreeNode getChildren(ConfigNode node, string searchWord = null)
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

        private void rebuildTypeFilteredConfigTree()
        {            
            typeFilteredRoot = new ConfigTreeNode(topNode);
            foreach (ConfigNode node in topNode.nodes.GetNodes())
            {
                if(node.name.Equals(URLCONFIG, StringComparison.InvariantCultureIgnoreCase) && node.HasValue("type") && filters.IsActive(node.GetValue("type")))
                {
                    ConfigTreeNode treeNode = getChildren(node);
                    if (treeNode != null)
                    {
                        typeFilteredRoot.Nodes.Add(treeNode);
                        //configTree.Nodes.Add(treeNode);
                    }
                }                                                
            }            
            rebuildConfigTree();
        }

        private void rebuildConfigTree()
        {
            string searchWord = searchTextBox.Text.Trim();
            populateConfigTree(typeFilteredRoot, searchWord.Length > 0 ? searchWord : null);
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
                } else
                {
                    ConfigTreeNode urlConfigTreeNode = getUrlConfigTreeNode(selected);
                    if(urlConfigTreeNode != null)
                    {
                        configView.SetData(urlConfigTreeNode.Data, configNode);                        
                    }
                }
            }
        }

        private ConfigTreeNode getUrlConfigTreeNode(ConfigTreeNode treeNode)
        {
            if (treeNode == null)
                return null;
            if (treeNode.Data.name == URLCONFIG)
            {
                return treeNode;
            } else
            {
                return getUrlConfigTreeNode((ConfigTreeNode)treeNode.Parent);
            }
        }

        private void filterMenu_MouseLeave(object sender, EventArgs e)
        {
            filterTreeToolStripMenuItem.DropDown.Close();
        }
    }
}
