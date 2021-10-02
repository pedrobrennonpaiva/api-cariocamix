using CariocaMix.Domain.Entities;
using CariocaMix.Domain.Interfaces.Repositories.Base;

namespace CariocaMix.Domain.Interfaces.Repositories
{
    public interface IRepositoryStore: IRepositoryBase<Store, long>
    {
    }
}
