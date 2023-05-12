using Business_Layer.repository;

namespace Business_Layer.Factories
{
    public interface IProductServiceFactory
    {
        IProductService Create();
    }
}
