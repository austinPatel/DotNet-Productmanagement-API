using ProductManagementApi.Models;

namespace ProductManagementApi.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAll();
        Task<int> Add(Product product);
        Task<bool> Update(int id,Product product);
        Task<bool> Delete(int id);

    }
}
