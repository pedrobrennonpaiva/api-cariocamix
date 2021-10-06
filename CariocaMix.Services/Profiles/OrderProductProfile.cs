using AutoMapper;
using CariocaMix.Domain.Entities;
using CariocaMix.Domain.Models.OrderProduct;

namespace CariocaMix.Service.Profiles
{
    public class OrderProductProfile : Profile
    {
        public OrderProductProfile()
        {
            CreateMap<OrderProduct, OrderProductDetailsModel>();
            CreateMap<OrderProductAddModel, OrderProduct>();
            CreateMap<OrderProductUpdateModel, OrderProduct>();
        }
    }
}
