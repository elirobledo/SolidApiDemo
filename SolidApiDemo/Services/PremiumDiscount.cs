using SolidApiDemo.Interfaces;

namespace SolidApiDemo.Services
{
    public class PremiumDiscount : IDiscount
    {
        public decimal Apply(decimal total)
        {
            return total * 0.85m;
        }
    }
}
