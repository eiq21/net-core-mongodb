using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Data.Infrastructure;
using App.Model;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace App.Data
{
    public class ApplicationDbContext : IMongoContext
    {
        private IMongoDatabase Database { get; set; }
        private readonly List<Func<Task>> _commands;
        public ApplicationDbContext(IOptions<Settings> options)
            :base()
        {
            var client = new MongoClient(options.Value.ConnectionString);
            if (client != null)
                Database = client.GetDatabase(options.Value.Database);
        }

        public void AddCommand(Func<Task> func)
        {
            _commands.Add(func);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public IMongoCollection<T> GetCollection<T>(string name)
        {
            return Database.GetCollection<T>(name);
        }

        public async Task<int> SaveChanges()
        {
            var cmdTask = _commands.Select(c => c());
            await Task.WhenAll(cmdTask);
            return _commands.Count();
        }
    }
}
