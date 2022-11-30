namespace Dre0Dru.Contextual
{
    //TODO split to read/write interfaces? or at least as set property
    public interface IContextual<in TContext>
    {
        void SetContext(TContext context);
    }
}
