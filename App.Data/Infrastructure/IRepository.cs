using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.Data.Infrastructure
{
    public interface IRepository<T> where T : class
    {
        Task<T>  GetById(Guid id);
        Task<IEnumerable<T>> GetAll();
        Task<IEnumerable<T>> GetByFilter(FilterDefinition<T> filter);
        T Add(T entity);
        void Update(T entity);
        void Delete(Guid id);
    }
}
