using AutoMapper;
using CariocaMix.Domain.Entities;
using CariocaMix.Domain.Models.DeliveryRemoveArea;

namespace CariocaMix.Service.Profiles
{
    public class DeliveryRemoveAreaProfile : Profile
    {
        public DeliveryRemoveAreaProfile()
        {
            CreateMap<DeliveryRemoveArea, DeliveryRemoveAreaDetailsModel>();
            CreateMap<DeliveryRemoveAreaAddModel, DeliveryRemoveArea>();
            CreateMap<DeliveryRemoveAreaUpdateModel, DeliveryRemoveArea>();
        }
    }
}
