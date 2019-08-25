using App.Data.Infrastructure;
using App.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Data.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(IApplicationDbContext context) : base(context)
        {

        }
    }

    public interface IUserRepository : IRepository<User>{ }
}
