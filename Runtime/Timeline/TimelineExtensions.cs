using System.Collections.Generic;
using System.Linq;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace Dre0Dru.Timeline
{
    public static class TimelineExtensions
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

        public static (TimelineClip timelineClip, TPlayableAsset playableAsset) GetClip<TPlayableAsset>(this TrackAsset track)
            where TPlayableAsset : PlayableAsset
        {
            var timelineClip = track.GetClips().Single(clip => clip.asset is TPlayableAsset);

            return (timelineClip, timelineClip.asset as TPlayableAsset);
        }

        public static IEnumerable<(TimelineClip timelineClip, TPlayableAsset playableAsset)> GetClips<TPlayableAsset>(this TrackAsset track)
            where TPlayableAsset : PlayableAsset
        {
            return track.GetClips().Where(clip => clip.asset is TPlayableAsset).Select(clip =>
                (clip, clip.asset as TPlayableAsset));
        }

        public static IEnumerable<TMarker> GetMarkers<TMarker>(this TrackAsset trackAsset)
            where TMarker : class, IMarker
        {
            return trackAsset.GetMarkers().OfType<TMarker>();
        }
    }
}
