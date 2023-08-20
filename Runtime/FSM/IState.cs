namespace Dre0Dru.FSM
{
    public interface IState
    {
        bool CanEnterState<TState>(TState from, IStateMachine<TState> stateMachine)
            where TState : class, IState;

        bool CanExitState<TState>(TState to, IStateMachine<TState> stateMachine)
            where TState : class, IState;

        void OnStateEntered<TState>(TState from, IStateMachine<TState> stateMachine)
            where TState : class, IState;

        void OnStateExited<TState>(TState to, IStateMachine<TState> stateMachine)
            where TState : class, IState;
    }
}
