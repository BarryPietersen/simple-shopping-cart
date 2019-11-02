using System.Collections.Generic;
using SimpleShoppingCart.Core.Repositories;

namespace SimpleShoppingCart.Core.Services
{
    public class ProductService : IProductService
    {
        // Dependencies would be resolved through an IOC framework such as Castle Windsor
        private IProductRepository _repo;

        public ProductService(IProductRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<Product> Get()
        {
            return _repo.Get();
        }

        public Product Get(long id)
        {
            return _repo.Get(id);
        }
    }
}
