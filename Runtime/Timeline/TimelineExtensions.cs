using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

        public static T GetPlayableBehaviour<T>(this Playable playable)
            where T : class, IPlayableBehaviour
        {
            var handle = playable.GetHandle();
            
            var method = typeof(PlayableHandle).GetMethod("GetObject", BindingFlags.Instance | BindingFlags.NonPublic);
            var generic = method.MakeGenericMethod(typeof(T));

            return generic.Invoke(handle, null) as T;
        }

        public static bool TryGetPlayableInputOfType<T>(this Playable playable, out Playable playableInput)
            where T : class, IPlayableBehaviour
        {
            playableInput = default;
            
            for (int i = 0; i < playable.GetInputCount(); i++)
            {
                var input = playable.GetInput(i);

                if (input.GetPlayableType() == typeof(T))
                {
                    playableInput = input;
                    return true;
                }
            }

            return false;
        }
    }
}
