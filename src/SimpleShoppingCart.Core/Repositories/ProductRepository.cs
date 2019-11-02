using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using SimpleShoppingCart.Core.Repositories;

public class ProductRepository : IProductRepository
{
    // Dependencies would be resolved through an IOC framework such as Castle Windsor
    private IQueryable<Product> _data;

	public ProductRepository()
	{
        _data = GenData().AsQueryable();
	}

    public IEnumerable<Product> Get()
    {
        return _data;
    }

    public Product Get(long id)
    {
        return _data.Where(p => p.Id == id).FirstOrDefault();
    }

    public IEnumerable<Product> Get(Expression<Func<Product, bool>> predicate) 
    {
        return _data.Where(predicate);
    }

    //
    // remaining crud operations can be used to extend this assignment
    //

    public void Delete(long id)
    {
        throw new NotImplementedException();
    }

    public Product Save(Product data)
    {
        throw new NotImplementedException();
    }

    public Product Update(Product data)
    {
        throw new NotImplementedException();
    }

    private List<Product> GenData() 
    {
        return new List<Product>
        {
            new Product
            {
                Id = 1,
                Category = "movie",
                Name = "The Matrix",
                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s",
                Price = 18.80,
                Image = "m.jpg"
            },
            new Product
            {
                Id = 2,
                Category = "movie",
                Name = "Resivoir Dogs",
                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s",
                Price = 18.80,
                Image = "m.jpg"
            },
            new Product
            {
                Id = 3,
                Category = "music",
                Name = "The Red Hot Chilli Peppers",
                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s",
                Price = 12.20,
                Image = "rhcp.jpg"
            },
            new Product
            {
                Id = 4,
                Category = "music",
                Name = "Rufus Du Sol",
                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s",
                Price = 16.50,
                Image = "rds.jpg"
            },
            new Product
            {
                Id = 5,
                Category = "book",
                Name = "The Lord of the Rings",
                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s",
                Price = 14.50,
                Image = "lr.jpg"
            },
            new Product
            {
                Id = 6,
                Category = "book",
                Name = "Harry Potter",
                Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s",
                Price = 12.50,
                Image = "hp.jpg"
            },
        };
    }
}