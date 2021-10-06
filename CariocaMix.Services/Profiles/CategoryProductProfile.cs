using AutoMapper;
using CariocaMix.Domain.Entities;
using CariocaMix.Domain.Models.CategoryProduct;

namespace CariocaMix.Service.Profiles
{
    public class CategoryProductProfile : Profile
    {
        public CategoryProductProfile()
        {
            CreateMap<CategoryProduct, CategoryProductDetailsModel>();
            CreateMap<CategoryProductAddModel, CategoryProduct>();
            CreateMap<CategoryProductUpdateModel, CategoryProduct>();
        }
    }
}
