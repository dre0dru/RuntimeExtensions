using UnityEngine;
using UnityEngine.Timeline;

namespace Dre0Dru.Timeline
{
    public class TimePointMarker : Marker
    {
    }
    
    public abstract class TimePointMarker<TData> : Marker
    {
        [SerializeField]
        public TData Data;
    }
}
