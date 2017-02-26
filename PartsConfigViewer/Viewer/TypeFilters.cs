using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Viewer
{
    class TypeFilters
    {
        private TypeFilter[] filters;

        public TypeFilters(TypeFilter[] filters)
        {
            this.filters = filters;
        }

        public int Count { get { return filters.Length; } }

        internal TypeFilter GetFilter(int i)
        {
            if (0 <= i && i < filters.Length)
                return filters[i];
            return null;
        }

        internal bool IsActive(string type)
        {
            foreach(TypeFilter filter in filters)
                if (filter.HasType(type))
                    return filter.IsActive();
            return true; //TODO default true or false?
        }
    }
}
