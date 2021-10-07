using CariocaMix.Domain.Entities;
using CariocaMix.Domain.Interfaces.Repositories;
using CariocaMix.Repository.Persistence.Repositories.Base;

namespace CariocaMix.Repository.Persistence.Repositories
{
    public class RepositoryPaymentStatus : RepositoryBase<PaymentStatus, long>, IRepositoryPaymentStatus
    {
        public RepositoryPaymentStatus(Context context) : base(context) { }
    }
}
