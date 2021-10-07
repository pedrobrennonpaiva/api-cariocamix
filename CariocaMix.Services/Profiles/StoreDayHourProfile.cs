using AutoMapper;
using CariocaMix.Domain.Entities;
using CariocaMix.Domain.Models.StoreDayHour;

namespace CariocaMix.Service.Profiles
{
    public class StoreDayHourProfile : Profile
    {
        public StoreDayHourProfile()
        {
            CreateMap<StoreDayHour, StoreDayHourDetailsModel>();
            CreateMap<StoreDayHourAddModel, StoreDayHour>();
            CreateMap<StoreDayHourUpdateModel, StoreDayHour>();
        }
    }
}
