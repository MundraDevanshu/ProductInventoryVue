using Business_Layer.Abstract_Factory.AbstractFactoryInterfaces;

namespace Business_Layer.Abstract_Factory
{
    class ElectronicValidity : IValidity
    {
        public string getValidity()
        {
            return " 2 Days";
        }
    }
}
