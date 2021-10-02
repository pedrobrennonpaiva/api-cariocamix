using CariocaMix.Domain.Models.Returns;
using CariocaMix.Domain.Models.Product;
using System.Collections.Generic;

namespace CariocaMix.Domain.Interfaces.Services
{
    public interface IServiceProduct
    {
        Result Add(ProductAddModel request);

        Result Update(ProductUpdateModel request);

        List<ProductDetailsModel> List();

        Result Delete(long id);

        Result GetById(long id);
    }
}
