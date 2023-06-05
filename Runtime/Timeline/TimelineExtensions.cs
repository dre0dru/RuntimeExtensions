using System.Collections.Generic;
using System.Linq;
using UnityEngine;
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

        public static (TimelineClip timelineClip, TPlayableAsset playableAsset) GetClip<TPlayableAsset>(
            this TrackAsset track)
            where TPlayableAsset : PlayableAsset
        {
            var timelineClip = track.GetClips().Single(clip => clip.asset is TPlayableAsset);

            return (timelineClip, timelineClip.asset as TPlayableAsset);
        }

        public static IEnumerable<(TimelineClip timelineClip, TPlayableAsset playableAsset)> GetClips<TPlayableAsset>(
            this TrackAsset track)
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

        public static GameObject ResolveSource(this ControlPlayableAsset controlPlayableAsset,
            PlayableDirector playableDirector)
        {
            return controlPlayableAsset.sourceGameObject.Resolve(playableDirector);
        }

        public static TComponent ResolveSource<TComponent>(this ControlPlayableAsset controlPlayableAsset,
            PlayableDirector playableDirector)
            where TComponent : Component
        {
            return controlPlayableAsset.ResolveSource(playableDirector).GetComponent<TComponent>();
        }

        public static bool TryResolveSource<TComponent>(this ControlPlayableAsset controlPlayableAsset,
            PlayableDirector playableDirector, out TComponent component)
            where TComponent : Component
        {
            return controlPlayableAsset.ResolveSource(playableDirector).TryGetComponent<TComponent>(out component);
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
