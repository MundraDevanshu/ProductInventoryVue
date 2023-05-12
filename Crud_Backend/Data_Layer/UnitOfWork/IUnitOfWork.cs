using System.Threading.Tasks;

namespace Data_Layer.UnitOfWork
{
    public interface IUnitOfWork
    {
        IProductRepository ProductRepository { get; }
        public Task SaveChangesAsync();
    }
}
