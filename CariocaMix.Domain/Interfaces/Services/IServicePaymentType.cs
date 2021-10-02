using CariocaMix.Domain.Models.Returns;
using CariocaMix.Domain.Models.PaymentType;
using System.Collections.Generic;

namespace CariocaMix.Domain.Interfaces.Services
{
    public interface IServicePaymentType
    {
        Result Add(PaymentTypeAddModel request);

        Result Update(PaymentTypeUpdateModel request);

        List<PaymentTypeDetailsModel> List();

        Result Delete(long id);

        Result GetById(long id);
    }
}
