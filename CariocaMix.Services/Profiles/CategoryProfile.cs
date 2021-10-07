using AutoMapper;
using CariocaMix.Domain.Entities;
using CariocaMix.Domain.Models.Category;

namespace CariocaMix.Service.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryDetailsModel>();
            CreateMap<CategoryAddModel, Category>();
            CreateMap<CategoryUpdateModel, Category>();
        }
    }
}
