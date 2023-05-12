using Business_Layer.Abstract_Factory.AbstractFactoryInterfaces;

namespace Business_Layer.Abstract_Factory
{
    public class GroceryDiscount : IDiscount
    {
        public string getDiscount()
        {
            return "10%";
        }
    }
}
