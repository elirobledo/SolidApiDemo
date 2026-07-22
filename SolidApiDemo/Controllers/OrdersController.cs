using Microsoft.AspNetCore.Mvc;
using SolidApiDemo.Models;
using SolidApiDemo.Services;

namespace SolidApiDemo.Controllers
{
    [ApiController]
    [Route("api/orders")]
    public class OrdersController : ControllerBase
    {
        private readonly OrderService service;

        public OrdersController(OrderService service)
        {
            this.service = service;
        }

        [HttpPost]
        public IActionResult Create(Order order)
        {
            var result = service.Process(order);

            return Ok(result);
        }
    }
}
