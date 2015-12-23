using System.Collections.Generic;
using System.Linq;
using Backpack.Site.Core.Entities;

namespace Backpack.Site.Models.Mapper
{
    public static class ProductMapper
    {
        public static IEnumerable<ProductViewModel> ToProductViewModel(this IEnumerable<Product> products)
        {
            return products.Select(n => new ProductViewModel()
            {
                ProductName = n.ProductName,
                Price = n.UnitPrice.ToString(),
                Available = n.Discontinued
            });
        } 
    }
}