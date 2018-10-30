namespace PharmacyPurchase.Presentation.Services
{
    using Microsoft.Extensions.Configuration;
    using PharmancyPurchase.Crosscutting;

    public class ConfigurationService : IConfigurationService
    {
        private readonly IConfiguration configuration;

        public ConfigurationService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public string ExternalOrderServiceUrl => this.configuration["ExternalOrderServiceUrl"];
    }
}