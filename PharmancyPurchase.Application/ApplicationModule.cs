namespace PharmancyPurchase.Application
{
    using Core.Domain.Entities;
    using Microsoft.Extensions.DependencyInjection;
    using Orders;
    using Service;

    public class ApplicationModule
    {
        public static void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IService<Sale>, Service<Sale>>();
            serviceCollection.AddScoped<IService<Medicament>, Service<Medicament>>();
            serviceCollection.AddScoped<IService<MedicamentSale>, Service<MedicamentSale>>();
            serviceCollection.AddScoped<IOrdersAppService, OrdersAppService>();
        }
    }
}