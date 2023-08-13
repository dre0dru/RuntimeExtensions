namespace Dre0Dru.Filters
{
    //TODO composite filter?
    public interface IFilter<in TFiltered, out TResult>
    {
        TResult Filter(TFiltered filtered);
    }

    public interface IFilter<in TFiltered> : IFilter<TFiltered, bool>
    {
    }
}
