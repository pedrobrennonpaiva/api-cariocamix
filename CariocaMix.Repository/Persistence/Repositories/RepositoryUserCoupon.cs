using CariocaMix.Domain.Entities;
using CariocaMix.Domain.Interfaces.Repositories;
using CariocaMix.Repository.Persistence.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CariocaMix.Repository.Persistence.Repositories
{
    public class RepositoryUserCoupon : RepositoryBase<UserCoupon, long>, IRepositoryUserCoupon
    {
        public RepositoryUserCoupon(Context context) : base(context) 
        {
        }
    }
}
