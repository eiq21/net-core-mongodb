using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IMongoContext _context;
        public UnitOfWork(IMongoContext context)
        {
            _context = context;
        }
        public async Task<bool> Commit()
        {
            var result = await _context.SaveChanges();
            return result > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
