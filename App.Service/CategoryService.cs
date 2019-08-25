using App.Data.Infrastructure;
using App.Data.Repositories;
using App.Model;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(ICategoryRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }
        public async Task<Category> AddCategory(Category category)
        {
            _repository.Add(category);
            await _unitOfWork.Commit();
            return category;
        }

        public async Task<bool> DeleteCategory(Guid id)
        {
            _repository.Remove(id);
            return await _unitOfWork.Commit();
        }

        public async Task<bool> DeleteCategory(ObjectId id)
        {
            _repository.Remove(id);
            return await _unitOfWork.Commit();
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            var categories = await _repository.GetAll();
            return categories;

        }

        public async Task<Category> GetCategoryById(Guid id)
        {
            var category = await _repository.GetById(id);
            return category;
        }
        public async Task<Category> GetCategoryById(ObjectId id)
        {
            var category = await _repository.GetById(id);
            return category;
        }

        public async Task<Category> UpdateCategory(Category category)
        {
            _repository.Update(category);
            await _unitOfWork.Commit();
            return category;
        }
    }

    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetCategories();
        Task<Category> AddCategory(Category category);
        Task<Category> GetCategoryById(Guid id);
        Task<Category> GetCategoryById(ObjectId id);
        Task<Category> UpdateCategory(Category category);
        Task<bool> DeleteCategory(Guid id);
        Task<bool> DeleteCategory(ObjectId id);
    }
}

