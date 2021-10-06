using AutoMapper;
using CariocaMix.Domain.Entities;
using CariocaMix.Domain.Models.Product;

namespace CariocaMix.Service.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDetailsModel>();
            CreateMap<ProductAddModel, Product>();
            CreateMap<ProductUpdateModel, Product>();
        }
    }
}
