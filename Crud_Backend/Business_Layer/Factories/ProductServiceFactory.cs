using Business_Layer.repository;
using Data_Layer.DbContextFile;
using Data_Layer.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace Business_Layer.Factories
{
    public class ProductServiceFactory : IProductServiceFactory
    {
        private readonly DbContextOptions<ProductContext> _dbContextOptions;

        public ProductServiceFactory(DbContextOptions<ProductContext> dbContextOptions)
        {
            _dbContextOptions = dbContextOptions;
        }

        public IProductService Create()
        {
            var unitOfWork = new UnitOfWork(new ProductContext(_dbContextOptions));
            return new ProductService(unitOfWork);
        }
    }
}
