using CariocaMix.Domain.Models.Returns;
using CariocaMix.Domain.Models.PaymentStatus;
using System.Collections.Generic;

namespace CariocaMix.Domain.Interfaces.Services
{
    public interface IServicePaymentStatus
    {
        Result Add(PaymentStatusAddModel request);

        Result Update(long id, PaymentStatusUpdateModel request);

        List<PaymentStatusDetailsModel> List();

        Result Delete(long id);

        Result GetById(long id);
    }
}
