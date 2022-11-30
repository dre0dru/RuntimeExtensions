using Dre0Dru.Collections;

namespace Dre0Dru.ObjectsFilter
{
    public interface IBitmaskObjectFilter32<in TObject>
    {
        BitmaskFilter32 BitmaskFilter { get; }
        
        void Add(TObject obj);

        bool Remove(TObject obj);
    }
}
