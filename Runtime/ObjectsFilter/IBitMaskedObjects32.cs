using Dre0Dru.Collections;

namespace Dre0Dru.ObjectsFilter
{
    public interface IBitMaskedObjects32<TObject>
    {
        void AddObject(Bitmask32 bitmask, TObject obj);
        bool RemoveObject(Bitmask32 bitmask, TObject obj);
        bool UpdateObjectMask(Bitmask32 oldBitmask, Bitmask32 newBitmask, TObject obj);
        void AddFilter(IBitmaskObjectFilter32<TObject> objectFilter);
        bool RemoveFilter(IBitmaskObjectFilter32<TObject> objectFilter);
    }
}
