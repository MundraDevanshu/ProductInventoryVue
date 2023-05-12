using Business_Layer.Dto;
using Data_Layer.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business_Layer.repository
{
    public interface IProductService
    {
        Task<PagedResult<Product>> GetProductAsync(int pageNumber , int pageSize);
        Task<ProductDto> GetProductById(int id);
        Task<ProductDto> AddProduct(ProductDto productDto);
        Task<ProductDto> UpdateProduct(ProductDto productDto);
        Task DeleteProduct(int id);
        Task<PagedResult<Product>> GetPagedProductAsync(string searchTerm, int pageNumber, int pageSize);
    }
}