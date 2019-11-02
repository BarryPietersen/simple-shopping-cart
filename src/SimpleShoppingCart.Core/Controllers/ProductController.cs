using Microsoft.AspNetCore.Mvc;
using SimpleShoppingCart.Core.Services;
using System.Collections.Generic;

namespace SimpleShoppingCart.Core.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        // Dependencies would be resolved through an IOC framework such as Castle Windsor
        private IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("{id}")]
        public Product Get(int id)
        {
            return _productService.Get(id);
        }

        [HttpGet]
        [Route("[action]")]
        public IEnumerable<Product> GetAll()
        {
            return _productService.Get();
        }
    }
}
