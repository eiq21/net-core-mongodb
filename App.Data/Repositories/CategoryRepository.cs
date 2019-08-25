using App.Data.Infrastructure;
using App.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Data.Repositories
{
    public class CategoryRepository: RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(IApplicationDbContext context): base(context)
        {

        }
    }
    public interface ICategoryRepository : IRepository<Category> { }
}
