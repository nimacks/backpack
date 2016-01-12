using System.Collections.Generic;
using Backpack.Site.Core.Entities;

namespace Backpack.Site.Core.Products
{
    public interface IProductCatalogService
    {
        IEnumerable<Product> GetProducts();
        IEnumerable<Category> GetCategories();
    }
}