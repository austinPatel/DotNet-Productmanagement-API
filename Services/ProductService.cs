using ProductManagementApi.DTOs;
using ProductManagementApi.Interfaces;
using AutoMapper;
using ProductManagementApi.Models;

namespace ProductManagementApi.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository) { 
        _repository = repository;
        }
        public async Task<IEnumerable<Product>> GetAll()
        {
            return await _repository.GetAll();
        }
        public async Task<int> Add(ProductCreateDto dto)
        {
            var product = new Product
            {
                Name = dto.Name,
                Price = dto.Price,
                CreatedDate = dto.CreatedDate,
                Category = dto.Category,

            };
            return await _repository.Add(product);
        }

        public async Task<bool> Update(int id,ProductUpdateDto dto)
        {
            var product = new Product
            {
                //Id = id,
                Name = dto.Name,
                Price = dto.Price,
                CreatedDate = dto.CreatedDate,
                Category = dto.Category,

            };
            return await _repository.Update(id,product);
        }
        public async Task<bool> Delete(int id)
        {
            return await _repository.Delete(id);

        }
    }
}
