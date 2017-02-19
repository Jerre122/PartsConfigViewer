using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Viewer
{
    class ConfigTreeNode : TreeNode
    {
        private ConfigNode data;

        public ConfigTreeNode(ConfigNode data) : base(data.name)
        {
            this.data = data;
        }

        public ConfigTreeNode(ConfigNode data, string name) : base(name)
        {
            this.data = data;
        }

        public ConfigNode Data { get { return data; } }
    }
}
