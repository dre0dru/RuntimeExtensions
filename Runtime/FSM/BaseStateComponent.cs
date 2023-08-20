using UnityEngine;

namespace Dre0Dru.FSM
{
    public class BaseStateComponent : MonoBehaviour, IState
    {
        bool IState.CanEnterState<TState>(TState from, IStateMachine<TState> stateMachine)
        {
            return CanEnterState(from as BaseState, stateMachine as IStateMachine<BaseState>);
        }

        bool IState.CanExitState<TState>(TState to, IStateMachine<TState> stateMachine)
        {
            return CanExitState(to as BaseState, stateMachine as IStateMachine<BaseState>);
        }

        void IState.OnStateEntered<TState>(TState from, IStateMachine<TState> stateMachine)
        {
            OnStateEntered(from as BaseState, stateMachine as IStateMachine<BaseState>);
        }

        void IState.OnStateExited<TState>(TState to, IStateMachine<TState> stateMachine)
        {
            OnStateExited(to as BaseState, stateMachine as IStateMachine<BaseState>);
        }

        protected virtual bool CanEnterState(BaseState from, IStateMachine<BaseState> stateMachine)
        {
            return true;
        }
        
        protected virtual bool CanExitState(BaseState to, IStateMachine<BaseState> stateMachine)
        {
            return true;
        }

        protected virtual void OnStateEntered(BaseState from, IStateMachine<BaseState> stateMachine)
        {
        }
        
        protected virtual void OnStateExited(BaseState to, IStateMachine<BaseState> stateMachine)
        {
        }
    }
}
