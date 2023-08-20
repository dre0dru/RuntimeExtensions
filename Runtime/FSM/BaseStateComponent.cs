using UnityEngine;

namespace Dre0Dru.FSM
{
    public class BaseStateComponent : MonoBehaviour, IState
    {
        bool IState.CanEnterState<TState>(TState from, IStateMachine<TState> stateMachine)
        {
            return CanEnterState(from as BaseStateComponent, stateMachine as IStateMachine<BaseStateComponent>);
        }

        bool IState.CanExitState<TState>(TState to, IStateMachine<TState> stateMachine)
        {
            return CanExitState(to as BaseStateComponent, stateMachine as IStateMachine<BaseStateComponent>);
        }

        void IState.OnStateEntered<TState>(TState from, IStateMachine<TState> stateMachine)
        {
            enabled = true;
            
            OnStateEntered(from as BaseStateComponent, stateMachine as IStateMachine<BaseStateComponent>);
        }

        void IState.OnStateExited<TState>(TState to, IStateMachine<TState> stateMachine)
        {
            enabled = false;
            
            OnStateExited(to as BaseStateComponent, stateMachine as IStateMachine<BaseStateComponent>);
        }

        protected virtual bool CanEnterState(BaseStateComponent from, IStateMachine<BaseStateComponent> stateMachine)
        {
            return true;
        }
        
        protected virtual bool CanExitState(BaseStateComponent to, IStateMachine<BaseStateComponent> stateMachine)
        {
            return true;
        }

        protected virtual void OnStateEntered(BaseStateComponent from, IStateMachine<BaseStateComponent> stateMachine)
        {
        }
        
        protected virtual void OnStateExited(BaseStateComponent to, IStateMachine<BaseStateComponent> stateMachine)
        {
        }
    }
    
    public class BaseStateComponent<TBaseState> : MonoBehaviour, IState
        where TBaseState : BaseStateComponent<TBaseState>
    {
        bool IState.CanEnterState<TState>(TState from, IStateMachine<TState> stateMachine)
        {
            return CanEnterState(from as TBaseState, stateMachine as IStateMachine<TBaseState>);
        }

        bool IState.CanExitState<TState>(TState to, IStateMachine<TState> stateMachine)
        {
            return CanExitState(to as TBaseState, stateMachine as IStateMachine<TBaseState>);
        }

        void IState.OnStateEntered<TState>(TState from, IStateMachine<TState> stateMachine)
        {
            enabled = true;
            
            OnStateEntered(from as TBaseState, stateMachine as IStateMachine<TBaseState>);
        }

        void IState.OnStateExited<TState>(TState to, IStateMachine<TState> stateMachine)
        {
            enabled = false;
            
            OnStateExited(to as TBaseState, stateMachine as IStateMachine<TBaseState>);
        }

        protected virtual bool CanEnterState(TBaseState from, IStateMachine<TBaseState> stateMachine)
        {
            return true;
        }
        
        protected virtual bool CanExitState(TBaseState to, IStateMachine<TBaseState> stateMachine)
        {
            return true;
        }

        protected virtual void OnStateEntered(TBaseState from, IStateMachine<TBaseState> stateMachine)
        {
        }
        
        protected virtual void OnStateExited(TBaseState to, IStateMachine<TBaseState> stateMachine)
        {
        }
        
        #if UNITY_EDITOR
        protected virtual void OnValidate()
        {
            if (UnityEditor.EditorApplication.isPlayingOrWillChangePlaymode)
                return;

            enabled = false;
        }
        #endif
    }
    
    public class BaseStateComponent<TBaseState, TStateMachine> : MonoBehaviour, IState
        where TBaseState : BaseStateComponent<TBaseState, TStateMachine>
        where TStateMachine : class, IStateMachine<TBaseState>
    {
        bool IState.CanEnterState<TState>(TState from, IStateMachine<TState> stateMachine)
        {
            return CanEnterState(from as TBaseState, stateMachine as TStateMachine);
        }

        bool IState.CanExitState<TState>(TState to, IStateMachine<TState> stateMachine)
        {
            return CanExitState(to as TBaseState, stateMachine as TStateMachine);
        }

        void IState.OnStateEntered<TState>(TState from, IStateMachine<TState> stateMachine)
        {
            enabled = true;
            
            OnStateEntered(from as TBaseState, stateMachine as TStateMachine);
        }

        void IState.OnStateExited<TState>(TState to, IStateMachine<TState> stateMachine)
        {
            enabled = false;
            
            OnStateExited(to as TBaseState, stateMachine as TStateMachine);
        }

        protected virtual bool CanEnterState(TBaseState from, TStateMachine stateMachine)
        {
            return true;
        }
        
        protected virtual bool CanExitState(TBaseState to, TStateMachine stateMachine)
        {
            return true;
        }

        protected virtual void OnStateEntered(TBaseState from, TStateMachine stateMachine)
        {
        }
        
        protected virtual void OnStateExited(TBaseState to, TStateMachine stateMachine)
        {
        }
        
        #if UNITY_EDITOR
        protected virtual void OnValidate()
        {
            if (UnityEditor.EditorApplication.isPlayingOrWillChangePlaymode)
                return;

            enabled = false;
        }
        #endif
    }
}
