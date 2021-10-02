using CariocaMix.Domain.Models.Returns;
using CariocaMix.Domain.Models.OrderProductItem;
using System.Collections.Generic;

namespace CariocaMix.Domain.Interfaces.Services
{
    public interface IServiceOrderProductItem
    {
        Result Add(OrderProductItemAddModel request);

        Result Update(OrderProductItemUpdateModel request);

        List<OrderProductItemDetailsModel> List();

        Result Delete(long id);

        Result GetById(long id);
    }
}
