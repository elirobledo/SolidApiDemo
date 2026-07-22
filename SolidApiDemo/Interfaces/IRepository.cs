using SolidApiDemo.Models;

namespace SolidApiDemo.Interfaces
{
    public interface IRepository
    {
        void Save(Order order);
    }
}
