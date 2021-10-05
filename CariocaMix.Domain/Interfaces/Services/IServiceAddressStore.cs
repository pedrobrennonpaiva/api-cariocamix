using CariocaMix.Domain.Models.Returns;
using CariocaMix.Domain.Models.AddressStore;
using System.Collections.Generic;

namespace CariocaMix.Domain.Interfaces.Services
{
    public interface IServiceAddressStore
    {
        Result Add(AddressStoreAddModel request);

        Result Update(long id, AddressStoreUpdateModel request);

        List<AddressStoreDetailsModel> List();

        Result Delete(long id);

        Result GetById(long id);
    }
}
