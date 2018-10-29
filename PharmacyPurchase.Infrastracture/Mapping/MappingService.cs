namespace PharmacyPurchase.Infrastracture.Mapping
{
    using AutoMapper;
    using PharmancyPurchase.Crosscutting;

    public class MappingService : IMappingService
    {
        public TEntity Map<TEntity>(object value)
        {
            return Mapper.Map<TEntity>(value);
        }

        public TDestination Map<TSource, TDestination>(TSource source, TDestination destination)
        {
            return Mapper.Map<TSource, TDestination>(source, destination);
        }
    }
}