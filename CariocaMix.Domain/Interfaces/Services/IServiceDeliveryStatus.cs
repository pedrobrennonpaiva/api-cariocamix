using CariocaMix.Domain.Models.Returns;
using CariocaMix.Domain.Models.DeliveryStatus;
using System.Collections.Generic;

namespace CariocaMix.Domain.Interfaces.Services
{
    public interface IServiceDeliveryStatus
    {
        Result Add(DeliveryStatusAddModel request);

        Result Update(DeliveryStatusUpdateModel request);

        List<DeliveryStatusDetailsModel> List();

        Result Delete(long id);

        Result GetById(long id);
    }
}
