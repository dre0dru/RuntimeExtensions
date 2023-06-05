using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace Dre0Dru.Timeline
{
    public class TimeRangeClipPlayableAsset: PlayableAsset, ITimelineClipAsset
    {
        public virtual ClipCaps clipCaps => ClipCaps.None;

        public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
        {
            var playable = ScriptPlayable<TimeRangePlayableBehaviour>.Create(graph);

            return playable;
        }
    }
    
    public class TimeRangeClipPlayableAsset<TData, TBehaviour> : TimeRangeClipPlayableAsset
        where TBehaviour : TimeRangePlayableBehaviour<TData>, new()
    {
        public TData Data;

        public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
        {
            var playable = ScriptPlayable<TBehaviour>.Create(graph);
            var behaviour = playable.GetBehaviour();
            behaviour.Data = Data;

            return playable;
        }
    }
}
