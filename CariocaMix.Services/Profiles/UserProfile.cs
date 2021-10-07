using AutoMapper;
using CariocaMix.Domain.Entities;
using CariocaMix.Domain.Models.User;

namespace CariocaMix.Service.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDetailsModel>();
            CreateMap<UserAddModel, User>();
            CreateMap<UserUpdateModel, User>();
        }
    }
}
