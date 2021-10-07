using AutoMapper;
using CariocaMix.Domain.Entities;
using CariocaMix.Domain.Models.Order;

namespace CariocaMix.Service.Profiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderDetailsModel>();
            CreateMap<OrderAddModel, Order>();
            CreateMap<OrderUpdateModel, Order>();
        }
    }
}
