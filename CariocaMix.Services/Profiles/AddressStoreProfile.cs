using AutoMapper;
using CariocaMix.Domain.Entities;
using CariocaMix.Domain.Models.AddressStore;

namespace CariocaMix.Service.Profiles
{
    public class AddressStoreProfile : Profile
    {
        public AddressStoreProfile()
        {
            CreateMap<AddressStore, AddressStoreDetailsModel>();
            CreateMap<AddressStoreAddModel, AddressStore>();
            CreateMap<AddressStoreUpdateModel, AddressStore>();
        }
    }
}
