using UnityEngine;

namespace Dre0Dru.FSM
{
    public class StateComponent : MonoBehaviour, IState<StateComponent>
    {
        public virtual bool CanEnterState(StateComponent from)
        {
            return true;
        }

        public virtual bool CanExitState(StateComponent to)
        {
            return true;
        }

        public virtual void OnStateEntered(StateComponent from)
        {
            enabled = true;
        }

        public virtual void OnStateExited(StateComponent to)
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
    
    public class StateComponent<TBaseState> : MonoBehaviour, IState<TBaseState>
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
