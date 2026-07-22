using SolidApiDemo.Interfaces;
using SolidApiDemo.Models;

namespace SolidApiDemo.Services
{
    public class OrderService
    {
        private readonly IRepository repository;

        private readonly IMessageService message;

        private readonly IDiscount discount;

        public OrderService(
            IRepository repository,
            IMessageService message,
            IDiscount discount)
        {
            this.repository = repository;
            this.message = message;
            this.discount = discount;
        }

        public Order Process(Order order)
        {
            order.Total = discount.Apply(order.Total);

            repository.Save(order);

            message.Send(order.Customer,
                $"Total {order.Total}");

            return order;
        }
    }
}
