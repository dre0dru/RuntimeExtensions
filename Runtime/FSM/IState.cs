namespace Dre0Dru.FSM
{
    public interface IState<in TState>
        where TState : IState<TState>
    {
        bool CanEnterState(TState from);

        bool CanExitState(TState to);

        void OnStateEntered(TState from);

        void OnStateExited(TState to);
    }

    public interface IState : IState<IState>
    {
        
    }
}
