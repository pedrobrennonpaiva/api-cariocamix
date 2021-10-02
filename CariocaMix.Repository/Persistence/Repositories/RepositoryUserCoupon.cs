using CariocaMix.Domain.Entities;
using CariocaMix.Domain.Interfaces.Repositories;
using CariocaMix.Repository.Persistence.Repositories.Base;

namespace CariocaMix.Repository.Persistence.Repositories
{
    public class RepositoryUserCoupon : RepositoryBase<UserCoupon, long>, IRepositoryUserCoupon
    {
        public RepositoryUserCoupon(Context context) : base(context) { }
    }
}
