using SimpleShoppingCart.Core.Models;
using System.Collections.Generic;

namespace SimpleShoppingCart.Core.Services
{
    public interface IOrderService
    {
        OrderSummary CalulateOrderSummary(IEnumerable<LineItem> items);
        OrderSummary PlaceOrder(IEnumerable<LineItem> items);
    }
}
