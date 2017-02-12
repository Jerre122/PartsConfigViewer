using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Viewer.configCache
{
    class Attribute
    {
        public Attribute(string name, string value)
        {
            this.name = name;
            this.value = value;
        }

        private string name;
        private string value;
    }
}
