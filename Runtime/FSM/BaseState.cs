using System;

namespace Dre0Dru.FSM
{
    [Serializable]
    public class BaseState : IState
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
    
    public class BaseState<TBaseState> : IState
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
            OnStateEntered(from as TBaseState, stateMachine as IStateMachine<TBaseState>);
        }

        void IState.OnStateExited<TState>(TState to, IStateMachine<TState> stateMachine)
        {
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
    }
    
    public class BaseState<TBaseState, TStateMachine> : IState
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
            OnStateEntered(from as TBaseState, stateMachine as TStateMachine);
        }

        void IState.OnStateExited<TState>(TState to, IStateMachine<TState> stateMachine)
        {
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
    }
}
