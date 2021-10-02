using CariocaMix.Domain.Entities;
using CariocaMix.Domain.Interfaces.Repositories.Base;

namespace CariocaMix.Domain.Interfaces.Repositories
{
    public interface IRepositoryOrder: IRepositoryBase<Order, long>
    {
    }
}
