using AutoMapper;
using CariocaMix.Domain.Entities;
using CariocaMix.Domain.Models.ProductItem;

namespace CariocaMix.Service.Profiles
{
    public class ProductItemProfile : Profile
    {
        public ProductItemProfile()
        {
            CreateMap<ProductItem, ProductItemDetailsModel>();
            CreateMap<ProductItemAddModel, ProductItem>();
            CreateMap<ProductItemUpdateModel, ProductItem>();
        }
    }
}
