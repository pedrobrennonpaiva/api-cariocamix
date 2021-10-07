using AutoMapper;
using CariocaMix.Domain.Entities;
using CariocaMix.Domain.Models.OrderProductItem;

namespace CariocaMix.Service.Profiles
{
    public class OrderProductItemProfile : Profile
    {
        public OrderProductItemProfile()
        {
            CreateMap<OrderProductItem, OrderProductItemDetailsModel>();
            CreateMap<OrderProductItemAddModel, OrderProductItem>();
            CreateMap<OrderProductItemUpdateModel, OrderProductItem>();
        }
    }
}
