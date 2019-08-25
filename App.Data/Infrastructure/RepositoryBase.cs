using MongoDB.Bson;
using MongoDB.Driver;
using ServiceStack;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Infrastructure
{
    public abstract class RepositoryBase<T> : IRepository<T> where T : class
    {
        private readonly IApplicationDbContext _context;
        private readonly IMongoCollection<T> DbSet;
        public RepositoryBase(IApplicationDbContext context)
        {
            _context = context;
            DbSet = _context.GetCollection<T>(typeof(T).Name);
            
        }
        public void Add(T obj)
        {
            _context.AddCommand(() => DbSet.InsertOneAsync(obj));
        }
        public virtual async Task<IEnumerable<T>> GetAll()
        {
            var all = await DbSet.FindAsync(Builders<T>.Filter.Empty);
            return all.ToList();
        }

        public virtual async Task<T> GetById(Guid id)
        {
            var data = await DbSet.FindAsync(Builders<T>.Filter.Eq("_id", id));
            return data.FirstOrDefault();
        }

        public virtual async Task<T> GetById(ObjectId id)
        {
            var data = await DbSet.FindAsync(Builders<T>.Filter.Eq("_id", id));
            return data.FirstOrDefault();
        }

        public void Remove(Guid id) => _context.AddCommand(() => DbSet.DeleteOneAsync(Builders<T>.Filter.Eq("_id", id)));

        public void Remove(ObjectId id) => _context.AddCommand(() => DbSet.DeleteOneAsync(Builders<T>.Filter.Eq("_id", id)));


        public virtual void Update(T obj)
        {
            _context.AddCommand(() => DbSet.ReplaceOneAsync(Builders<T>.Filter.Eq("_id", obj.GetId()), obj));
        }
        public void Dispose()
        {
            _context?.Dispose();
        }

        public  virtual async Task<IEnumerable<T>> GetByFilter(FilterDefinition<T> filter)
        {
            filter = filter ?? new BsonDocument();
            var list =  await DbSet.FindAsync(filter);
            return list.ToList();

        }

        public virtual async Task<T> GetFirstByFilter(FilterDefinition<T> filter)
        {
            filter = filter ?? new BsonDocument();
            var obj = await DbSet.FindAsync(filter);
            return obj.FirstOrDefault();
        }
    }
}
