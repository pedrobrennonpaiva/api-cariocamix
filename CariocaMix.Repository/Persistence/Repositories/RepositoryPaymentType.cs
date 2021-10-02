using CariocaMix.Domain.Entities;
using CariocaMix.Domain.Interfaces.Repositories;
using CariocaMix.Repository.Persistence.Repositories.Base;

namespace CariocaMix.Repository.Persistence.Repositories
{
    public class RepositoryPaymentType : RepositoryBase<PaymentType, long>, IRepositoryPaymentType
    {
        public RepositoryPaymentType(Context context) : base(context) { }
    }
}
