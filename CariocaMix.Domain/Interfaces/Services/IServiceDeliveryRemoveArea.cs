using CariocaMix.Domain.Models.Returns;
using CariocaMix.Domain.Models.DeliveryRemoveArea;
using System.Collections.Generic;

namespace CariocaMix.Domain.Interfaces.Services
{
    public interface IServiceDeliveryRemoveArea
    {
        Result Add(DeliveryRemoveAreaAddModel request);

        Result Update(long id, DeliveryRemoveAreaUpdateModel request);

        List<DeliveryRemoveAreaDetailsModel> List();

        Result Delete(long id);

        Result GetById(long id);
    }
}
