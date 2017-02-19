using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Viewer
{
    public partial class ConfigView : UserControl
    {
        public ConfigView()
        {
            InitializeComponent();
        }

        internal void SetData(ConfigNode configNode)
        {
            configTreeView.BeginUpdate();
            configTreeView.Nodes.Clear();
            addNodes(configTreeView.Nodes, configNode);
            configTreeView.ExpandAll();
            configTreeView.EndUpdate();

        }

        private void addNodes(TreeNodeCollection treeNodeCollection, ConfigNode configNode)
        {
            foreach (ConfigNode.Value val in configNode.values)
            {
                string valueText = val.name + ": " + val.value;
                treeNodeCollection.Add(valueText);
            }

            foreach (ConfigNode nextNode in configNode.nodes)
            {
                TreeNode nextTreeNode = new TreeNode(nextNode.name);
                addNodes(nextTreeNode.Nodes, nextNode);
                treeNodeCollection.Add(nextTreeNode);
            }
        }
    }
}
