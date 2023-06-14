using System.Collections.Generic;
using System.Linq;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace Dre0Dru.Timeline
{
    public static partial class TimelineExtensions
    { 
        public static (TimelineClip timelineClip, TPlayableAsset playableAsset) GetSingleClip<TPlayableAsset>(
            this TrackAsset track)
            where TPlayableAsset : PlayableAsset
        {
            var timelineClip = track.GetClips().Single(clip => clip.asset is TPlayableAsset);

            return (timelineClip, timelineClip.asset as TPlayableAsset);
        }

        public static IEnumerable<(TimelineClip timelineClip, TPlayableAsset playableAsset)> GetClips<TPlayableAsset>(
            this TimelineAsset timelineAsset)
            where TPlayableAsset : PlayableAsset
        {
            return timelineAsset.GetOutputTracks().SelectMany(track => track.GetClips<TPlayableAsset>());
        }

        public static IEnumerable<(TimelineClip timelineClip, TPlayableAsset playableAsset)> GetClips<TPlayableAsset>(
            this TrackAsset track)
            where TPlayableAsset : PlayableAsset
        {
            return track.GetClips().Where(clip => clip.asset is TPlayableAsset).Select(clip =>
                (clip, clip.asset as TPlayableAsset));
        }

        public static (double normalizedStart, double normalizedEnd) ToNormalizedRelativeTo(
            this TimelineClip timelineClip, TimelineClip relativeTo)
        {
            return (timelineClip.NormalizedStartRelativeTo(relativeTo), 
                timelineClip.NormalizedEndRelativeTo(relativeTo));
        }
        
        public static double NormalizedStartRelativeTo(
            this TimelineClip timelineClip, TimelineClip relativeTo)
        {
            return relativeTo.RelativeNormalizedTime(timelineClip.start);
        }
        
        public static double NormalizedEndRelativeTo(
            this TimelineClip timelineClip, TimelineClip relativeTo)
        {
            return relativeTo.RelativeNormalizedTime(timelineClip.end);
        }

        public static double RelativeNormalizedTime(this TimelineClip relativeTo, double time)
        {
            return (time - relativeTo.start) / relativeTo.duration;
        }
    }
}
