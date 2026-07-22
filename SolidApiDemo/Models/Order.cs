namespace SolidApiDemo.Models
{
    public class Order
    {
        public int Id { get; set; }

        public string Customer { get; set; } = "";

        public decimal Total { get; set; }
    }
}
