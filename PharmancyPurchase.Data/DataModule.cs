namespace PharmancyPurchase.Data
{
    using Core;
    using Core.Domain.Entities;
    using Microsoft.Extensions.DependencyInjection;
    using Repositories;

    public class DataModule
    {
        public static void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IRepository<Medicament>, Repository<Medicament>>();
            serviceCollection.AddScoped<IRepository<Sale>, Repository<Sale>>();
            serviceCollection.AddScoped<IRepository<MedicamentSale>, Repository<MedicamentSale>>();
        }
    }
}