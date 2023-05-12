using Business_Layer.Abstract_Factory.AbstractFactoryInterfaces;

namespace Business_Layer.Abstract_Factory
{
    public class GroceryFactory : IFactory
    {
        public string getDiscount()
        {
            return new GroceryDiscount().getDiscount();
        }

        public string getValidity()
        {
            return new GroceryValidity().getValidity();
        }
    }
}
