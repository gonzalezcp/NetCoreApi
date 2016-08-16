using DataModel;
using DataModel.Core.Repositories;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace DataModel.Persistence.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(WebApiDbEntities context) : base(context)
        {
        }


        public WebApiDbEntities WebApiDbEntities
        {
            get { return Context as WebApiDbEntities; }
        }

        public Product GetProduct(int id)
        {
            return WebApiDbEntities.Products.SingleOrDefault(a => a.ProductId == id);
        }

        public IEnumerable<Product> GetAllsProduct()
        {
            return WebApiDbEntities.Products.Include(c => c.ProductName).ToList();
        }


    }
}