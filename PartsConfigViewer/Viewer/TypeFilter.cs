using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Viewer
{
    class TypeFilter
    {
        public TypeFilter(string filterName, string[] typeNames) {
            this.filterName = filterName;
            this.typeNames = typeNames;
        }

        private string filterName;
        private string[] typeNames;
        private bool active;

        public bool HasType(string type)
        {
            if (typeNames == null)
                return true;
            foreach (string typeName in typeNames)
                if (typeName.Equals(type, StringComparison.InvariantCultureIgnoreCase))
                    return true;
            return false;
        }

        public bool Toggle()
        {
            active = !active;
            return active;
        }

        public void SetActive(bool active)
        {
            this.active = active;
        }

        public bool IsActive()
        {
            return active;
        }

        public string Name { get { return filterName; } }
        public string[] Types { get { return typeNames; } }
    }
}
