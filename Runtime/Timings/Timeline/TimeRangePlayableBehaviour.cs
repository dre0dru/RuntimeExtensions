using UnityEngine.Playables;

namespace Dre0Dru.Timings.Timeline
{
    public class TimeRangePlayableBehaviour : PlayableBehaviour
    {
    }
    
    public class TimeRangePlayableBehaviour<TData> : TimeRangePlayableBehaviour
    {
        public TData Data;
    }
}
