namespace Dre0Dru.FSM
{
    //TODO as composition of different interfaces
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
