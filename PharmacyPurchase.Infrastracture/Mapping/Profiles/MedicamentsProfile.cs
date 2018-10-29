namespace PharmacyPurchase.Infrastracture.Mapping.Profiles
{
    using AutoMapper;
    using PharmancyPurchase.Communication;
    using PharmancyPurchase.Core.Domain.Entities;

    public class MedicamentsProfile : Profile
    {
        public MedicamentsProfile()
        {
            this.CreateMap<Medicament, OrderDto>();
        }
    }
}