using System.Collections.Generic;
using System.Linq;
using UnityEngine.Timeline;

namespace Dre0Dru.Timeline
{
    public static partial class TimelineExtensions
    {
        public static IEnumerable<TMarker> GetMarkers<TMarker>(this TrackAsset track)
            where TMarker : class, IMarker
        {
            return track.GetMarkers().OfType<TMarker>();
        }

        public static IEnumerable<TMarker> GetMarkers<TMarker>(this IEnumerable<TrackAsset> tracks)
            where TMarker : class, IMarker
        {
            return tracks.SelectMany(track => track.GetMarkers<TMarker>());
        }
    }
}
