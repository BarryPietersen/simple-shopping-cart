using System.Collections.Generic;

namespace SimpleShoppingCart.Core.Models
{
    public class OrderSummary
    {
        public double Total { get; set; }
        public double Shipping { get; set; }
        public double GrandTotal { get; set; }
        public IEnumerable<LineItem> LineItems { get; set; }
    }
}
