using App.Data.Infrastructure;
using App.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Data.Repositories
{
    public class ProductRepository : RepositoryBase<Product>,IProductRepository
    {
        public ProductRepository(IApplicationDbContext context):base(context)
        {

        }
    }

    public interface IProductRepository : IRepository<Product> { }
}
