using AutoMapper;
using CariocaMix.Domain.Entities;
using CariocaMix.Domain.Models.DeliveryStatus;

namespace CariocaMix.Service.Profiles
{
    public class DeliveryStatusProfile : Profile
    {
        public DeliveryStatusProfile()
        {
            CreateMap<DeliveryStatus, DeliveryStatusDetailsModel>();
            CreateMap<DeliveryStatusAddModel, DeliveryStatus>();
            CreateMap<DeliveryStatusUpdateModel, DeliveryStatus>();
        }
    }
}
