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
        private ConfigNode lastParent = null;

        public ConfigView()
        {
            InitializeComponent();
        }

        internal void SetData(ConfigNode parentNode, ConfigNode ensureVisible = null)
        {            
            configTreeView.BeginUpdate();
            TreeNode ensureVisibleTreeNode = null;
            if (lastParent != parentNode) //TODO equals method
            {
                configTreeView.Nodes.Clear();
                //TODO ensure 4 values and 1 node
                nameTxtBox.Text = parentNode.GetValue("name") ?? "";
                typeTxtBox.Text = parentNode.GetValue("type") ?? "";
                parentUrlTxtBox.Text = parentNode.GetValue("parentUrl") ?? "";
                urlTxtBox.Text = parentNode.GetValue("url") ?? "";
                ensureVisibleTreeNode = addNodes(configTreeView.Nodes, null, parentNode.nodes[0], ensureVisible);
                lastParent = parentNode;
                configTreeView.ExpandAll();                
            } else
            {
                Console.WriteLine("TODO: ensureVisible on treeNode in existing treeView.");                
            }
            
            configTreeView.EndUpdate();

            if (ensureVisibleTreeNode != null)
            {
                configTreeView.SelectedNode = ensureVisibleTreeNode;
                //ensureVisibleTreeNode.EnsureVisible();
                //TODO shift focus                
            } else
            {
                configTreeView.Nodes[0]?.EnsureVisible();
            }


        }

        /*private TreeNode findConfigNode(ConfigNode searchNode, TreeNodeCollection collection)
        {            
            TreeNode foundTreeNode = null;
            foreach (TreeNode node in configTreeView.Nodes)
            {
                if (node. == searchNode)
                    return node;
            }
        }*/

        private TreeNode addNodes(TreeNodeCollection treeNodeCollection, TreeNode parentTreeNode, ConfigNode configNode, ConfigNode ensureVisible)
        {
            TreeNode ensureVisibleTreeNode = null;
            if (configNode == ensureVisible)
                ensureVisibleTreeNode = parentTreeNode;
                        
            foreach (ConfigNode.Value val in configNode.values)
            {
                string valueText = val.name + ": " + val.value;
                treeNodeCollection.Add(valueText);
            }

            foreach (ConfigNode nextNode in configNode.nodes)
            {
                TreeNode nextTreeNode = new TreeNode(nextNode.name);                
                ensureVisibleTreeNode = addNodes(nextTreeNode.Nodes, nextTreeNode, nextNode, ensureVisible) ?? ensureVisibleTreeNode;
                treeNodeCollection.Add(nextTreeNode);
            }
            return ensureVisibleTreeNode;
        }
    }
}
