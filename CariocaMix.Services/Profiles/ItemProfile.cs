using AutoMapper;
using CariocaMix.Domain.Entities;
using CariocaMix.Domain.Models.Item;

namespace CariocaMix.Service.Profiles
{
    public class ItemProfile : Profile
    {
        public ItemProfile()
        {
            CreateMap<Item, ItemDetailsModel>();
            CreateMap<ItemAddModel, Item>();
            CreateMap<ItemUpdateModel, Item>();
        }
    }
}
