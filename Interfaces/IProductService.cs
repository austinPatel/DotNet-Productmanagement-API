using ProductManagementApi.DTOs;
using ProductManagementApi.Models;

namespace ProductManagementApi.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAll();
        Task<int> Add(ProductCreateDto dto);
        Task<bool> Update(int id, ProductUpdateDto dto);
        Task<bool> Delete(int id);

    }
}
