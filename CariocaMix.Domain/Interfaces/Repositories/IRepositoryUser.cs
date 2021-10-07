using CariocaMix.Domain.Entities;
using CariocaMix.Domain.Interfaces.Repositories.Base;
using System;

namespace CariocaMix.Domain.Interfaces.Repositories
{
    public interface IRepositoryUser: IRepositoryBase<User, long>
    {
    }
}
