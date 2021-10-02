using CariocaMix.Domain.Models.Returns;
using CariocaMix.Domain.Models.Item;
using System.Collections.Generic;

namespace CariocaMix.Domain.Interfaces.Services
{
    public interface IServiceItem
    {
        Result Add(ItemAddModel request);

        Result Update(ItemUpdateModel request);

        List<ItemDetailsModel> List();

        Result Delete(long id);

        Result GetById(long id);
    }
}
