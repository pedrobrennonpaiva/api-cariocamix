using CariocaMix.Domain.Models.Returns;
using CariocaMix.Domain.Models.ProductItem;
using System.Collections.Generic;

namespace CariocaMix.Domain.Interfaces.Services
{
    public interface IServiceProductItem
    {
        Result Add(ProductItemAddModel request);

        Result Update(long id, ProductItemUpdateModel request);

        List<ProductItemDetailsModel> List();

        Result Delete(long id);

        Result GetById(long id);
    }
}
