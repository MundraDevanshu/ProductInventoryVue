using Business_Layer.Abstract_Factory.AbstractFactoryInterfaces;

namespace Business_Layer.Abstract_Factory
{
    public class ElectronicFactory : IFactory
    {
        public string getDiscount()
        {
            return new ElectronicDiscount().getDiscount();
        }

        public string getValidity()
        {
            return new ElectronicValidity().getValidity();
        }
    }
}
