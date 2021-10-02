using CariocaMix.Domain.Models.Returns;
using CariocaMix.Domain.Models.DeliveryTax;
using System.Collections.Generic;

namespace CariocaMix.Domain.Interfaces.Services
{
    public interface IServiceDeliveryTax
    {
        Result Add(DeliveryTaxAddModel request);

        Result Update(DeliveryTaxUpdateModel request);

        List<DeliveryTaxDetailsModel> List();

        Result Delete(long id);

        Result GetById(long id);
    }
}
