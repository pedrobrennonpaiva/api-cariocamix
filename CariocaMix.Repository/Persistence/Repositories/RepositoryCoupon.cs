using CariocaMix.Domain.Entities;
using CariocaMix.Domain.Interfaces.Repositories;
using CariocaMix.Repository.Persistence.Repositories.Base;

namespace CariocaMix.Repository.Persistence.Repositories
{
    public class RepositoryCoupon : RepositoryBase<Coupon, long>, IRepositoryCoupon
    {
        public RepositoryCoupon(Context context) : base(context) { }
    }
}
