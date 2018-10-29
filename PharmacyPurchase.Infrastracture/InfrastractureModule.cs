namespace PharmacyPurchase.Infrastracture
{
    using AutoMapper;
    using Mapping;
    using Mapping.Profiles;
    using Microsoft.Extensions.DependencyInjection;
    using PharmancyPurchase.Crosscutting;

    public class InfrastractureModule
    {
        public static void ConfigureServices(IServiceCollection serviceCollection)
        {
            //// Mapping configuration
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<MedicamentsProfile>();
            });

            serviceCollection.AddSingleton<IMappingService, MappingService>();
        }
    }
}