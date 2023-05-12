using Business_Layer.Abstract_Factory.AbstractFactoryInterfaces;

namespace Business_Layer.Abstract_Factory
{
    class GroceryValidity : IValidity
    {
        public string getValidity()
        {
            return "5 days";
        }
    }
}
