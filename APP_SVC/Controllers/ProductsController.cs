using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Http;

using APP_SVC.Models;

namespace APP_SVC.Controllers
{
    public class ProductsController : ApiController
    {
        Product[] products = new Product[] 
        { 
            new Product { Id = 1, Name = "Tomato Soup", Category = "Groceries", Price = 1 }, 
            new Product { Id = 2, Name = "Yo-yo", Category = "Toys", Price = 3.75M }, 
            new Product { Id = 3, Name = "Hammer", Category = "Hardware", Price = 16.99M } 
        };

        public IEnumerable<Product> GetAllProducts()
        {
            return products;
        }

        /*
        public IEnumerable<Product> GetAllProducts2()
        {
            return (IEnumerable<Product>)products.Select(p => p.Price > 2);
        }
        */

        public IHttpActionResult GetProduct(int id)
        {
            var product = products.FirstOrDefault((p) => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        public IHttpActionResult SaveProduct(Product product)
        {
            if (product.Price == 0)
            {
                product.Price = 10;
            }

            return Ok(product);
        }

        public IHttpActionResult DeleteProduct(int id)
        {
            var product = products.FirstOrDefault((p) => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
    }

}