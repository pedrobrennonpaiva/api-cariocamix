using AutoMapper;
using CariocaMix.Domain.Entities;
using CariocaMix.Domain.Models.Admin;

namespace CariocaMix.Service.Profiles
{
    public class AdminProfile : Profile
    {
        public AdminProfile()
        {
            CreateMap<Admin, AdminDetailsModel>();
            CreateMap<AdminAddModel, Admin>();
            CreateMap<AdminUpdateModel, Admin>();
        }
    }
}
