using System;

namespace Dre0Dru.FSM
{
    [Serializable]
    public class State : IState<State>
    {
        public virtual bool CanEnterState(State from)
        {
            return true;
        }

        public virtual bool CanExitState(State to)
        {
            return false;
        }

        public virtual void OnStateEntered(State from)
        {
        }

        public virtual void OnStateExited(State to)
        {
        }
    }
    
    [Serializable]
    public class State<TBaseState> : IState<TBaseState>
        where TBaseState : IState<TBaseState>
    {
        public virtual bool CanEnterState(TBaseState from)
        {
            return true;
        }

        public virtual bool CanExitState(TBaseState to)
        {
            return false;
        }

        public virtual void OnStateEntered(TBaseState from)
        {
        }

        public virtual void OnStateExited(TBaseState to)
        {
        }
    }
}
