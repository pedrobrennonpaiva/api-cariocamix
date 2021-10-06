using AutoMapper;
using CariocaMix.Domain.Entities;
using CariocaMix.Domain.Models.PaymentStatus;

namespace CariocaMix.Service.Profiles
{
    public class PaymentStatusProfile : Profile
    {
        public PaymentStatusProfile()
        {
            CreateMap<PaymentStatus, PaymentStatusDetailsModel>();
            CreateMap<PaymentStatusAddModel, PaymentStatus>();
            CreateMap<PaymentStatusUpdateModel, PaymentStatus>();
        }
    }
}
