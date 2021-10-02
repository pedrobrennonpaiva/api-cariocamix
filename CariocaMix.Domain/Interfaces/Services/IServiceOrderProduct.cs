using CariocaMix.Domain.Models.Returns;
using CariocaMix.Domain.Models.OrderProduct;
using System.Collections.Generic;

namespace CariocaMix.Domain.Interfaces.Services
{
    public interface IServiceOrderProduct
    {
        Result Add(OrderProductAddModel request);

        Result Update(OrderProductUpdateModel request);

        List<OrderProductDetailsModel> List();

        Result Delete(long id);

        Result GetById(long id);
    }
}
