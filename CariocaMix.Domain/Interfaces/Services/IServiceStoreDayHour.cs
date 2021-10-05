using CariocaMix.Domain.Models.Returns;
using CariocaMix.Domain.Models.StoreDayHour;
using System.Collections.Generic;

namespace CariocaMix.Domain.Interfaces.Services
{
    public interface IServiceStoreDayHour
    {
        Result Add(StoreDayHourAddModel request);

        Result Update(long id, StoreDayHourUpdateModel request);

        List<StoreDayHourDetailsModel> List();

        Result Delete(long id);

        Result GetById(long id);
    }
}
