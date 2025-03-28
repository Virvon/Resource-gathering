using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Sources.Infrastructure
{
    public class ResourcesBank : IEnumerable<ResourceCell> 
    {
        private readonly Dictionary<ResourceType, ResourceCell> _cells;

        public ResourcesBank(IEnumerable<ResourceCell> cells)
        {
            _cells = cells.ToDictionary(it => it.Type);
        }

        public ResourceCell GetCell(ResourceType type)
        {
            return _cells[type];
        }

        public IEnumerator<ResourceCell> GetEnumerator()
        {
            return _cells.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}