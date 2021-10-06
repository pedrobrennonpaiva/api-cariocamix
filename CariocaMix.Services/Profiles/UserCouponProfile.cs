using AutoMapper;
using CariocaMix.Domain.Entities;
using CariocaMix.Domain.Models.UserCoupon;

namespace CariocaMix.Service.Profiles
{
    public class UserCouponProfile : Profile
    {
        public UserCouponProfile()
        {
            CreateMap<UserCoupon, UserCouponDetailsModel>();
            CreateMap<UserCouponAddModel, UserCoupon>();
            CreateMap<UserCouponUpdateModel, UserCoupon>();
        }
    }
}
