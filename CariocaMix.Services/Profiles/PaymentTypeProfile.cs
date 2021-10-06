using AutoMapper;
using CariocaMix.Domain.Entities;
using CariocaMix.Domain.Models.PaymentType;

namespace CariocaMix.Service.Profiles
{
    public class PaymentTypeProfile : Profile
    {
        public PaymentTypeProfile()
        {
            CreateMap<PaymentType, PaymentTypeDetailsModel>();
            CreateMap<PaymentTypeAddModel, PaymentType>();
            CreateMap<PaymentTypeUpdateModel, PaymentType>();
        }
    }
}
