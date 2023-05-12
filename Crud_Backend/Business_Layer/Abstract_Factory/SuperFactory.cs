using Business_Layer.Abstract_Factory.AbstractFactoryInterfaces;

namespace Business_Layer.Abstract_Factory
{
    public class SuperFactory
    {
        public IFactory create(string category)
        {
            if(category== "Electronics")
            {
                return new ElectronicFactory();
            }
            else{
                return new GroceryFactory();
            }
        }
    }
}
