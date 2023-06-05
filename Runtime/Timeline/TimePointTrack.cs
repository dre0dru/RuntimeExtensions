using UnityEngine.Timeline;

namespace Dre0Dru.Timeline
{
    [TrackClipType(typeof(TimePointMarker))]
    [TrackClipType(typeof(TimePointMarker<>))]
    public class TimePointTrack : TrackAsset
    {
    }
}
