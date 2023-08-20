using System.Collections.Generic;

namespace Dre0Dru.FSM
{
    public static class FsmExtensions
    {
        public static bool TryEnterStateIfNotCurrent<TState>(this IStateMachine<TState> stateMachine, TState state)
            where TState : class, IState
        {
            if (stateMachine.CurrentState == state)
            {
                return false;
            }

            return stateMachine.TryEnterState(state);
        }

        public static bool TryEnterStates<TState>(this IStateMachine<TState> stateMachine, IEnumerable<TState> states, out TState enteredState)
            where TState : class, IState
        {
            enteredState = default;
            
            foreach (var state in states)
            {
                if (stateMachine.TryEnterState(state))
                {
                    enteredState = state;
                    return true;
                }
            }

            return false;
        }
        
        public static bool TryEnterStatesIfNotCurrent<TState>(this IStateMachine<TState> stateMachine, IEnumerable<TState> states, out TState enteredState)
            where TState : class, IState
        {
            enteredState = default;
            
            foreach (var state in states)
            {
                if (stateMachine.TryEnterStateIfNotCurrent(state))
                {
                    enteredState = state;
                    return true;
                }
            }

            return false;
        }
    }
}
