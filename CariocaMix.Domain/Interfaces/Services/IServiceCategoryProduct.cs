using CariocaMix.Domain.Models.Returns;
using CariocaMix.Domain.Models.CategoryProduct;
using System.Collections.Generic;

namespace CariocaMix.Domain.Interfaces.Services
{
    public interface IServiceCategoryProduct
    {
        Result Add(CategoryProductAddModel request);

        Result Update(CategoryProductUpdateModel request);

        List<CategoryProductDetailsModel> List();

        Result Delete(long id);

        Result GetById(long id);
    }
}
