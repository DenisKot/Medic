namespace PharmancyPurchase.Crosscutting
{
    public interface IMappingService
    {
        TEntity Map<TEntity>(object value);

        TDestination Map<TSource, TDestination>(TSource source, TDestination destination);
    }
}