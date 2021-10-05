using CariocaMix.Domain.Models.Returns;
using CariocaMix.Domain.Models.Category;
using System.Collections.Generic;

namespace CariocaMix.Domain.Interfaces.Services
{
    public interface IServiceCategory
    {
        Result Add(CategoryAddModel request);

        Result Update(long id, CategoryUpdateModel request);

        List<CategoryDetailsModel> List();

        Result Delete(long id);

        Result GetById(long id);
    }
}
