using App.Data.Infrastructure;
using App.Model;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Repositories
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context) {
            _context = context;
        }
            
    }

    public interface IUserRepository : IRepository<User>
    {
        
    }

}
