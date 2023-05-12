using Business_Layer.Abstract_Factory.AbstractFactoryInterfaces;

namespace Business_Layer.Abstract_Factory
{
    public class ElectronicDiscount : IDiscount
    {
        public string getDiscount()
        {
            return "50%";
        }
    }
}
