namespace Dre0Dru.Contextual
{
    public static class ContextualExtensions
    {
        public static TContextual PassContext<TContextual, TContext>(this TContextual contextual, TContext context)
            where TContextual : IContextual<TContext>
        {
            contextual.SetContext(context);

            return contextual;
        }
    }
}
