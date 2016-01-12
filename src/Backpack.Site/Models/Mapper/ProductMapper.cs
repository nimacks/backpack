using System.Collections.Generic;
using System.Linq;
using Backpack.Site.Core.Entities;

namespace Backpack.Site.Models.Mapper
{
    public static class ProductMapper
    {
        public static ProductViewModel ToProductViewModel(this IEnumerable<Product> products)
        {
            var model = new ProductViewModel();
            model.Products = products.Select(n => new ProductModel()
            {
                ProductName = n.ProductName,
                Price = n.UnitPrice.ToString(),
                Available = n.Discontinued
            }).ToList();


            return model;
        }

        public static List<CategoryModel> ToCategoriesViewModel(this IEnumerable<Category> categories)
        {
            return categories.Select(n => new CategoryModel() {

                Id = n.CategoryID,
                Name = n.CategoryName,
                Description = n.Description
            }).ToList();
        }
    }
}