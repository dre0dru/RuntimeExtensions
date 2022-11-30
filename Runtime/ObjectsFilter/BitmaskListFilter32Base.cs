using System.Collections.Generic;
using Dre0Dru.Collections;

namespace Dre0Dru.ObjectsFilter
{
    public class BitmaskListFilter32Base<TObject> : IBitmaskObjectFilter32<TObject>
    {
        private readonly List<TObject> _filteredObjects;
        
        public BitmaskFilter32 BitmaskFilter { get; }

        protected IReadOnlyList<TObject> FilteredObjects => _filteredObjects;
        
        protected BitmaskListFilter32Base(BitmaskFilter32 bitmaskFilter)
        {
            BitmaskFilter = bitmaskFilter;
            _filteredObjects = new List<TObject>();
        }

        protected virtual void OnObjectAdded(TObject obj)
        {
        }

        protected virtual void OnObjectRemoved(TObject obj)
        {
        }
        
        void IBitmaskObjectFilter32<TObject>.Add(TObject obj)
        {
            _filteredObjects.Add(obj);
            OnObjectAdded(obj);
        }

        bool IBitmaskObjectFilter32<TObject>.Remove(TObject obj)
        {
            if (_filteredObjects.Remove(obj))
            {
                OnObjectRemoved(obj);
                return true;
            }

            return false;
        }
    }
}
