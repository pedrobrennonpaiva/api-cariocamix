using AutoMapper;
using CariocaMix.Domain.Entities;
using CariocaMix.Domain.Models.Coupon;

namespace CariocaMix.Service.Profiles
{
    public class CouponProfile : Profile
    {
        public CouponProfile()
        {
            CreateMap<Coupon, CouponDetailsModel>();
            CreateMap<CouponAddModel, Coupon>();
            CreateMap<CouponUpdateModel, Coupon>();
        }
    }
}
