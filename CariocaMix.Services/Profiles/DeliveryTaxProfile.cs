using AutoMapper;
using CariocaMix.Domain.Entities;
using CariocaMix.Domain.Models.DeliveryTax;

namespace CariocaMix.Service.Profiles
{
    public class DeliveryTaxProfile : Profile
    {
        public DeliveryTaxProfile()
        {
            CreateMap<DeliveryTax, DeliveryTaxDetailsModel>();
            CreateMap<DeliveryTaxAddModel, DeliveryTax>();
            CreateMap<DeliveryTaxUpdateModel, DeliveryTax>();
        }
    }
}
