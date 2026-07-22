using SolidApiDemo.Interfaces;

namespace SolidApiDemo.Services
{
    public class EmailService : IMessageService
    {
        public void Send(string customer, string message)
        {
            Console.WriteLine($"Email para {customer}: {message}");
        }
    }
}
