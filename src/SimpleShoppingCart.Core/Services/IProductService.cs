using System.Collections.Generic;

namespace SimpleShoppingCart.Core.Services
{
    public interface IProductService
    {
        IEnumerable<Product> Get();
        Product Get(long id);
    }
}
