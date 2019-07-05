using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Infrastructure
{
    public interface IUnitOfWork : IDisposable
    {
        Task<bool> Commit();
    }
}
