using AutoMapper;
using CariocaMix.Domain.Entities;
using CariocaMix.Domain.Models.Image;

namespace CariocaMix.Service.Profiles
{
    public class ImageProfile : Profile
    {
        public ImageProfile()
        {
            CreateMap<Image, ImageDetailsModel>();
            CreateMap<ImageAddModel, Image>();
            CreateMap<ImageUpdateModel, Image>();
        }
    }
}
