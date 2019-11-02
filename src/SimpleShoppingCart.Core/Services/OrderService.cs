using SimpleShoppingCart.Core.Models;
using System.Collections.Generic;
using System.Linq;

namespace SimpleShoppingCart.Core.Services
{
    public class OrderService : IOrderService
    {
        private const double _minShipping = 10.0;
        private const double _maxShipping = 20.0;

        public OrderService() {}

        public OrderSummary CalulateOrderSummary(IEnumerable<LineItem> items) 
        {
            if (items.Count() == 0)
            {
                return null;
            }

            double total = items.Select(i => i.Product.Price * i.Quantity).Sum();
            double shipping = total <= 50 ? _minShipping : _maxShipping;

            return new OrderSummary
            {
                Total = total,
                Shipping = shipping,
                GrandTotal = total + shipping,
                LineItems = items
            };
        }

        public OrderSummary PlaceOrder(IEnumerable<LineItem> items) 
        {
            OrderSummary summary = CalulateOrderSummary(items);

            // 
            // save order
            //
            
            return summary;
        }
    }
}
