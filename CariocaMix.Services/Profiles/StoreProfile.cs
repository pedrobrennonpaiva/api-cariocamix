using AutoMapper;
using CariocaMix.Domain.Entities;
using CariocaMix.Domain.Models.Store;

namespace CariocaMix.Service.Profiles
{
    public class StoreProfile : Profile
    {
        public StoreProfile()
        {
            CreateMap<Store, StoreDetailsModel>();
            CreateMap<StoreAddModel, Store>();
            CreateMap<StoreUpdateModel, Store>();
        }
    }
}
