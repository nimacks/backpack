using System.Collections.Generic;
using System.Linq;
using Backpack.Site.Core.Entities;

namespace Backpack.Site.Core.Products
{
    public class ProductCatalogRepository : IProductCatalogService
    {
        private readonly NorthwindEntities _northwindEntities;
        public ProductCatalogRepository()
        {
            _northwindEntities = new NorthwindEntities();
        }

        public IEnumerable<Product> GetProducts()
        {
            return _northwindEntities.Products.ToList();
        }
    }
}