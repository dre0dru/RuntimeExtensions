using UnityEngine.Timeline;

namespace Dre0Dru.Timings.Timeline
{
    [TrackClipType(typeof(TimeRangeClipPlayableAsset))]
    [TrackClipType(typeof(TimeRangeClipPlayableAsset<,>))]
    public class TimeRangeTrack: TrackAsset
    {
        
    }
    
    public class TimeRangeTrack<TData>: TrackAsset
    {
        public TData Data;
    }
}
