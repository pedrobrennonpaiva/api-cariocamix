using CariocaMix.Domain.Models.Returns;
using CariocaMix.Domain.Models.Order;
using System.Collections.Generic;

namespace CariocaMix.Domain.Interfaces.Services
{
    public interface IServiceOrder
    {
        Result Add(OrderAddModel request);

        Result Update(OrderUpdateModel request);

        List<OrderDetailsModel> List();

        Result Delete(long id);

        Result GetById(long id);
    }
}
