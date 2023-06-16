using System.Collections.Generic;
using System.Linq;
using UnityEngine.Timeline;

namespace Dre0Dru.Timeline
{
    public static partial class TimelineExtensions
    {
        public static TTrack GetSingleTrack<TTrack>(this TimelineAsset timelineAsset)
            where TTrack : TrackAsset
        {
            return timelineAsset.GetOutputTracks().Single(track => track is TTrack) as TTrack;
        }

        public static TTrack GetSingleTrack<TTrack>(this TimelineAsset timelineAsset, string name)
            where TTrack : TrackAsset
        {
            return timelineAsset.GetOutputTracks()
                .Single(track => track is TTrack && track.name.Equals(name)) as TTrack;
        }

        public static TTrack GetFirstTrack<TTrack>(this TimelineAsset timelineAsset)
            where TTrack : TrackAsset
        {
            return timelineAsset.GetOutputTracks().First(track => track is TTrack) as TTrack;
        }

        public static IEnumerable<TTrack> GetAllTracks<TTrack>(this TimelineAsset timelineAsset)
            where TTrack : TrackAsset
        {
            return timelineAsset.GetOutputTracks().OfType<TTrack>();
        }

        public static IEnumerable<TTrack> IgnoreMuted<TTrack>(this IEnumerable<TTrack> tracks)
            where TTrack : TrackAsset
        {
            return tracks.Where(track => !track.muted);
        }
    }
}
