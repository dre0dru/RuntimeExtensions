using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dre0Dru.FSM
{
    public interface IStateMachine<TState>
        where TState : class, IState
    {
        TState CurrentState { get; }

        bool CanEnterState(TState state);
        bool TryEnterState(TState state);
        void ForceEnterState(TState state);
    }
}
