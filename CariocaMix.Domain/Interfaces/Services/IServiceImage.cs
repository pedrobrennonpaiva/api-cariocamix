using CariocaMix.Domain.Models.Image;
using CariocaMix.Domain.Models.Returns;
using Microsoft.AspNetCore.Http;

namespace CariocaMix.Domain.Interfaces.Services
{
    public interface IServiceImage
    {
        Result Add(IFormFile file);

        Result Update(long id, ImageUpdateModel request);

        Result GetById(long id);

        Result GetByName(string name);
    }
}
