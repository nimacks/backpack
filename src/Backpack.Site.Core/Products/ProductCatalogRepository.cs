using System;
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

        public IEnumerable<Category> GetCategories()
        {
           return _northwindEntities.Categories.ToList();
        }

        public IEnumerable<Product> GetProductsByCategory(int categoryId)
        {
            return _northwindEntities.Products.Where(x => x.CategoryID == categoryId);
        }

        public IEnumerable<Product> GetProducts()
        {
            return _northwindEntities.Products.ToList();
        }
    }
}