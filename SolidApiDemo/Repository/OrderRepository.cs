using SolidApiDemo.Interfaces;
using SolidApiDemo.Models;

namespace SolidApiDemo.Repository
{
    public class OrderRepository : IRepository
    {
        public void Save(Order order)
        {
            Console.WriteLine($"Pedido {order.Id} guardado");
        }
    }
}
