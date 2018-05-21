using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace T7_P2_1.Controllers
{
    [RoutePrefix("api/products")]
    public class ProductsController : ApiController
    {
        private IEnumerable<Product> GetDummyDb()
        {
            List<Product> products = new List<Product>();
            products.Add(new Product() { Id = 1, Name = "Product 1" });
            products.Add(new Product() { Id = 2, Name = "Product 2" });
            return products;
        }
        [Authorize(Roles = "admins")]
        [Route("admin")]
        public IEnumerable<Product> GetAll()
        {
            return GetDummyDb();
        }
        [Authorize(Roles = "users")]
        [Route("public")]
        public IEnumerable<Product> GetAllPublic()
        {
            return GetDummyDb();
        }
    }

    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }

}
