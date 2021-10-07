using CariocaMix.Domain.Models.Returns;
using CariocaMix.Domain.Models.Address;
using System.Collections.Generic;

namespace CariocaMix.Domain.Interfaces.Services
{
    public interface IServiceAddress
    {
        Result Add(AddressAddModel request);

        Result Update(long id, AddressUpdateModel request);

        List<AddressDetailsModel> List();

        Result Delete(long id);

        Result GetById(long id);
    }
}
