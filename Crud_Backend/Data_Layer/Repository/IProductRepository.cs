using Data_Layer.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data_Layer
{
    public interface IProductRepository
    {
        Task<int> CountAsync();
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product> GetProductByIdAsync(int id);
        Task AddAsync(Product product);
        Task UpdateAsync(Product product);
        Task DeleteAsync(int id);
        Task<List<Product>> GetProductByTitleAsync(string title);
    }
}
