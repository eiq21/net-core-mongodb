using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Infrastructure
{
    public interface IRepository<T> :IDisposable where T:class 
    {
        void Add(T obj);
        Task<T> GetById(Guid id);
        Task<T> GetById(ObjectId id);
        Task<IEnumerable<T>> GetAll();
        void Update(T obj);
        void Remove(Guid id);
        void Remove(ObjectId id);
        Task<IEnumerable<T>> GetByFilter(FilterDefinition<T> filter);
        Task<T> GetFirstByFilter(FilterDefinition<T> filter);
    }
}
