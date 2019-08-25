using App.Data.Infrastructure;
using App.Data.Repositories;
using App.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IProductRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Product> AddProduct(Product product)
        {
            _repository.Add(product);
            await _unitOfWork.Commit();
            return product;
        }

        public async Task<bool> DeleteProduct(Guid id)
        {
            _repository.Remove(id);
           return await _unitOfWork.Commit();
        }

        public async Task<Product> GetProductById(Guid id)
        {
           var product = await _repository.GetById(id);
            return product;
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            var products = await _repository.GetAll();
            return products;
        }

        public async Task<Product> UpdateProduct(Product product)
        {
            _repository.Update(product);
            await _unitOfWork.Commit();
            return product;
        }
    }

    public interface IProductService
    {
        Task<IEnumerable<Product>> GetProducts();
        Task<Product> AddProduct(Product product);
        Task<Product> GetProductById(Guid id);
        Task<Product> UpdateProduct(Product product);
        Task<bool> DeleteProduct(Guid id);
    }
}
