using Data_Layer.DbContextFile;
using Data_Layer.Entity;
using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data_Layer
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductContext _dbContext;
       
        public ProductRepository(ProductContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> CountAsync()
        {
            return await _dbContext.Products.CountAsync();
        }
        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _dbContext.Products.ToListAsync();
        }


        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _dbContext.Products.FindAsync(id);
        }

        public async Task AddAsync(Product product)
        {
            await _dbContext.Products.AddAsync(product);
        }

        public async Task UpdateAsync(Product product)
        {
            _dbContext.Entry(product).State = EntityState.Modified;
        }

        public async Task DeleteAsync(int id)
        {
            var product = await _dbContext.Products.FindAsync(id);
            if(product != null)
            {
                _dbContext.Products.Remove(product);
            }
            
        }
        public async Task<List<Product>> GetProductByTitleAsync(string title)
        {
            return await _dbContext.Products
                .Where(ti => ti.Title.Contains(title))
                .ToListAsync();
        }
    }
}
