using Data_Layer.DbContextFile;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data_Layer.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ProductContext _context;
        

        public UnitOfWork(ProductContext context)
        {
            _context = context;
        }

        public IProductRepository ProductRepository => new ProductRepository(_context);

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

       


    }
}
