using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace Dre0Dru.Timeline
{
    public static partial class TimelineExtensions
    {
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
    }
}
