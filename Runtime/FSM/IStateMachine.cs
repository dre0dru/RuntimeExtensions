namespace Dre0Dru.FSM
{
    //TODO as composition of different interfaces?
    public interface IStateMachine<TState>
    {
        TState CurrentState { get; }

        bool CanEnterState(TState state);
        bool TryEnterState(TState state);
        void ForceEnterState(TState state);
    }
}
