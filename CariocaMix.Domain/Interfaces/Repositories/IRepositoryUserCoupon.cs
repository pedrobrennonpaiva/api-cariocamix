using CariocaMix.Domain.Entities;
using CariocaMix.Domain.Interfaces.Repositories.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CariocaMix.Domain.Interfaces.Repositories
{
    public interface IRepositoryUserCoupon: IRepositoryBase<UserCoupon, long>
    {
    }
}
