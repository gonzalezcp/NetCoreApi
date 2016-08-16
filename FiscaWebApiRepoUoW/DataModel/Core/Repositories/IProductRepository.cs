using System.Collections.Generic;

namespace DataModel.Core.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        Product GetProduct(int id);
        IEnumerable<Product> GetAllsProduct();
    }
}