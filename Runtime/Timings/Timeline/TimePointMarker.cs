using UnityEngine.Timeline;

namespace Dre0Dru.Timings.Timeline
{
    public class TimePointMarker : Marker
    {
    }
    
    public abstract class TimePointMarker<TData> : Marker
    {
        public TData Data;
    }
}
