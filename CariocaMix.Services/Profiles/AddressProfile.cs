using AutoMapper;
using CariocaMix.Domain.Entities;
using CariocaMix.Domain.Models.Address;

namespace CariocaMix.Service.Profiles
{
    public class AddressProfile : Profile
    {
        public AddressProfile()
        {
            CreateMap<Address, AddressDetailsModel>();
            CreateMap<AddressAddModel, Address>();
            CreateMap<AddressUpdateModel, Address>();
        }
    }
}
