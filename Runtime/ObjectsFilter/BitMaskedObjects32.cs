using System.Collections.Generic;
using Dre0Dru.Collections;

namespace Dre0Dru.ObjectsFilter
{
    public class BitMaskedObjects32<TObject> : IBitMaskedObjects32<TObject>
    {
        private readonly Dictionary<Bitmask32, HashSet<TObject>> _maskedObjects;
        private readonly HashSet<IBitmaskObjectFilter32<TObject>> _objectFilters;

        public BitMaskedObjects32()
        {
            _maskedObjects = new Dictionary<Bitmask32, HashSet<TObject>>();
            _objectFilters = new HashSet<IBitmaskObjectFilter32<TObject>>();
        }

        public void AddObject(Bitmask32 bitmask, TObject obj)
        {
            if (!_maskedObjects.TryGetValue(bitmask, out var collection))
            {
                collection = new HashSet<TObject>();
                _maskedObjects.Add(bitmask, collection);
            }

            if (collection.Add(obj))
            {
                UpdateFiltersAddedObject(bitmask, obj);
            }
        }

        public bool RemoveObject(Bitmask32 bitmask, TObject obj)
        {
            if (!_maskedObjects.TryGetValue(bitmask, out var collection))
            {
                return false;
            }

            if (collection.Remove(obj))
            {
                UpdateFiltersRemovedObject(bitmask, obj);
                return true;
            }

            return false;
        }

        public bool UpdateObjectMask(Bitmask32 oldBitmask, Bitmask32 newBitmask, TObject obj)
        {
            if (RemoveObject(oldBitmask, obj))
            {
                AddObject(newBitmask, obj);
                return true;
            }

            return false;
        }

        public void AddFilter(IBitmaskObjectFilter32<TObject> objectFilter)
        {
            if (!_objectFilters.Add(objectFilter))
            {
                return;
            }

            foreach (var kvp in _maskedObjects)
            {
                if (!objectFilter.BitmaskFilter.Matches(kvp.Key))
                {
                    continue;
                }

                foreach (var obj in kvp.Value)
                {
                    objectFilter.Add(obj);
                }
            }
        }

        public bool RemoveFilter(IBitmaskObjectFilter32<TObject> objectFilter) =>
            _objectFilters.Remove(objectFilter);

        private void UpdateFiltersAddedObject(Bitmask32 bitmask, TObject obj)
        {
            foreach (var objectFilter in _objectFilters)
            {
                if (!objectFilter.BitmaskFilter.Matches(bitmask))
                {
                    continue;
                }

                objectFilter.Add(obj);
            }
        }

        private void UpdateFiltersRemovedObject(Bitmask32 bitmask, TObject obj)
        {
            foreach (var objectFilter in _objectFilters)
            {
                if (!objectFilter.BitmaskFilter.Matches(bitmask))
                {
                    continue;
                }

                objectFilter.Remove(obj);
            }
        }
    }
}
