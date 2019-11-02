using Microsoft.AspNetCore.Mvc;
using SimpleShoppingCart.Core.Models;
using SimpleShoppingCart.Core.Services;
using System.Collections.Generic;

namespace SimpleShoppingCart.Core.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        // Dependencies would be resolved through an IOC framework such as Castle Windsor
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        [Route("[action]")]
        public OrderSummary CalculateOrderSummary([FromBody] IEnumerable<LineItem> items) 
        {
            return _orderService.CalulateOrderSummary(items);
        }

        [HttpPost]
        [Route("[action]")]
        public OrderSummary PlaceOrder([FromBody] IEnumerable<LineItem> items)
        {
            return _orderService.PlaceOrder(items);
        }
    }
}
