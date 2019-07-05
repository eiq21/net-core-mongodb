using MongoDB.Driver;
using ServiceStack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace App.Data.Infrastructure
{
    public abstract class RepositoryBase<T> :IRepository<T> where T:class
    {
        protected readonly IMongoContext _context;
        protected readonly IMongoCollection<T> dbset;

        protected RepositoryBase(IMongoContext context)
        {
            _context = context;
            dbset = _context.GetCollection<T>(typeof(T).Name);
        }
        public virtual async Task<IEnumerable<T>> GetAll()
        {
            var result = await dbset.FindAsync(Builders<T>.Filter.Empty);
            return result.ToList();
        }
        public virtual async Task<T> GetById(Guid id)
        {
            var result = await dbset.FindAsync(Builders<T>.Filter.Eq("_id", id));
            return result.SingleOrDefault();
        }

        public virtual T Add(T entity)
        {
            _context.AddCommand(() => dbset.InsertOneAsync(entity));
            return entity;
        }
        public virtual void Update(T entity)
        {
            _context.AddCommand(() => dbset.ReplaceOneAsync(Builders<T>.Filter.Eq("_id", entity.GetId()), entity));
        }

        public virtual void Delete(Guid id)
        {
            _context.AddCommand(() => dbset.DeleteOneAsync(Builders<T>.Filter.Eq("_id", id)));
        }      

        public async Task<IEnumerable<T>> GetByFilter(FilterDefinition<T> filter)
        {
            var result = await dbset.FindAsync(filter);
            return result.ToList();
        }
    }
}
