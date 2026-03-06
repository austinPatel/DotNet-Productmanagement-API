using Dapper;
using ProductManagementApi.Data;
using ProductManagementApi.Interfaces;
using ProductManagementApi.Models;

namespace ProductManagementApi.Repositories
{
    public class ProductRepository : IProductRepository 
    {
        private readonly ApplicationDbContext _context;
        public ProductRepository(ApplicationDbContext context) { 
            _context = context;
        }
        public async Task<IEnumerable<Product>> GetAll()
        {
            using var connection = _context.CreateConnection();

            var query = "SELECT * FROM Products ORDER BY Id DESC";

            return await connection.QueryAsync<Product>(query);
        }

        public async Task<int> Add(Product product )
        {
            using var connection = _context.CreateConnection();

            var query = @"Insert into Products(Name,Price,Category,CreatedDate) values(@Name,@Price,@Category,@CreatedDate);SELECT CAST(SCOPE_IDENTITY() as int)";

            return await connection.ExecuteScalarAsync<int>(query, product);
        }

        public async Task<bool> Update(int id,Product product)
        {
            using var connection = _context.CreateConnection();

            var query = @"Update Products set Name=@Name," +
                "Price=@Price," +
                "Category=@Category," +
                "CreatedDate=@CreatedDate" +
                " where Id=@Id";

            var rows=  await connection.ExecuteAsync(query, new
            {
                Id=id,
                product.Name,
                product.Price,
                product.Category,
                product.CreatedDate
            });
            return rows > 0;
        }


        public async Task<bool> Delete(int id)
        {
            //using var connection = _context.CreateConnection();
            //var query = "@Delete from Products where Id=@Id";
            //return await connection.ExecuteAsync<bool>(query, new {Id= id});
            using var connection = _context.CreateConnection();
            var rows = await connection.ExecuteAsync(
                "DELETE FROM Products WHERE Id=@Id",
                new { Id = id });

            return rows > 0;
        }
    }

}
