using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleShoppingCart.Core.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        // additional behaviors can be requested here
    }
}
