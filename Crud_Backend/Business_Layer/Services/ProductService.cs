using Business_Layer.Abstract_Factory;
using Business_Layer.Abstract_Factory.AbstractFactoryInterfaces;
using Business_Layer.Dto;
using Data_Layer;
using Data_Layer.Entity;
using Data_Layer.UnitOfWork;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Business_Layer.repository
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<PagedResult<Product>> GetProductAsync(int pageNumber, int pageSize)
        {
            var totalProducts = await _unitOfWork.ProductRepository.GetAllProductsAsync();
            var totalCount = await _unitOfWork.ProductRepository.CountAsync();
            var pagedProducts = totalProducts.Skip((pageNumber - 1) * pageSize).Take(pageSize);
            return new PagedResult<Product>(pagedProducts, totalCount, pageNumber, pageSize);
        }
       
        public async Task<ProductDto> GetProductById(int id)
        { 
            var product = await _unitOfWork.ProductRepository.GetProductByIdAsync(id);
            return product.MapToProductDto();
        }

        public async Task<ProductDto> AddProduct(ProductDto productDto)
        {
            IFactory factory = new SuperFactory().create(productDto.Category);
            productDto.Discount = factory.getDiscount() + " Upto " + factory.getValidity();
            var product = productDto.MapToProduct();
            await _unitOfWork.ProductRepository.AddAsync(product);
            await _unitOfWork.SaveChangesAsync();
            return product.MapToProductDto();
        }

        public async Task<ProductDto> UpdateProduct(ProductDto productDto)
        {
            IFactory factory = new SuperFactory().create(productDto.Category);
            productDto.Discount = factory.getDiscount() + " Upto " + factory.getValidity();
            var product = productDto.MapToProduct();
            await _unitOfWork.ProductRepository.UpdateAsync(product);
            await _unitOfWork.SaveChangesAsync();
            return product.MapToProductDto();
        }

        public async Task DeleteProduct(int id)
        {
            await _unitOfWork.ProductRepository.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<PagedResult<Product>> GetPagedProductAsync(string searchTerm, int pageNumber, int pageSize)
        {
            var products = await _unitOfWork.ProductRepository.GetProductByTitleAsync(searchTerm);
            var totalProducts = products.Count();
            var pagedProducts = products.Skip((pageNumber - 1) * pageSize).Take(pageSize);
            return new PagedResult<Product>(pagedProducts.ToList(), totalProducts, pageNumber, pageSize);
        }
    }
}
