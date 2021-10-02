using CariocaMix.Domain.Models.Returns;
using System;
using System.Collections.Generic;

namespace CariocaMix.Domain.Interfaces.Services.Base
{
    public interface IServiceBase<T>
    {
        Result Add(T request);

        Result Update(T request);

        IEnumerable<T> List();

        Result Delete(long id);

        T GetById(long id);
    }
}
