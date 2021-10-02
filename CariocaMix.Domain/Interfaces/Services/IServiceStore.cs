using CariocaMix.Domain.Models.Returns;
using CariocaMix.Domain.Models.Store;
using System.Collections.Generic;

namespace CariocaMix.Domain.Interfaces.Services
{
    public interface IServiceStore
    {
        Result Add(StoreAddModel request);

        Result Update(StoreUpdateModel request);

        List<StoreDetailsModel> List();

        Result Delete(long id);

        Result GetById(long id);
    }
}
