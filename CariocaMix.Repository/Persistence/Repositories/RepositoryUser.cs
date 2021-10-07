using CariocaMix.Domain.Entities;
using CariocaMix.Domain.Interfaces.Repositories;
using CariocaMix.Repository.Persistence.Repositories.Base;
using System;

namespace CariocaMix.Repository.Persistence.Repositories
{
    public class RepositoryUser : RepositoryBase<User, long>, IRepositoryUser
    {
        public RepositoryUser(Context context) : base(context) { }
    }
}
