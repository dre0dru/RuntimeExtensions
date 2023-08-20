using System;
using UnityEngine;

namespace Dre0Dru.FSM
{
    [Serializable]
    public class StateMachine<TState> : IStateMachine<TState>
        where TState : class, IState
    {
        [SerializeField]
        private TState _currentState;

        public TState CurrentState => _currentState;

        public virtual bool CanEnterState(TState state)
        {
            ThrowIfNull(state);

            return (_currentState == null || _currentState.CanExitState(state, this)) &&
                   state.CanEnterState(_currentState, this);
        }

        public virtual bool TryEnterState(TState state)
        {
            ThrowIfNull(state);

            if (!CanEnterState(state))
            {
                return false;
            }

            ForceEnterState(state);
            return true;
        }

        public virtual void ForceEnterState(TState state)
        {
            ThrowIfNull(state);

            var previousState = _currentState;
            previousState?.OnStateExited(state, this);

            _currentState = state;
            _currentState.OnStateEntered(previousState, this);
        }

        private void ThrowIfNull(TState state)
        {
            if (state == null)
            {
                throw new ArgumentNullException(nameof(state));
            }
        }
    }
}
