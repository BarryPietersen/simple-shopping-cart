using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleShoppingCart.Core.Models
{
    public class LineItem
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
