using UnityEngine;

namespace Dre0Dru.FSM
{
    public class BaseStateComponent<TBaseState> : MonoBehaviour, IState<TBaseState>
        where TBaseState : IState<TBaseState>
    {
        public virtual bool CanEnterState(TBaseState from)
        {
            return true;
        }

        public virtual bool CanExitState(TBaseState to)
        {
            return true;
        }

        public virtual void OnStateEntered(TBaseState from)
        {
            enabled = true;
        }

        public virtual void OnStateExited(TBaseState to)
        {
            enabled = false;
        }
        
        #if UNITY_EDITOR
        protected virtual void OnValidate()
        {
            if (UnityEditor.EditorApplication.isPlayingOrWillChangePlaymode)
            {
                return;
            }

            enabled = false;
        }
        #endif
    }
}
