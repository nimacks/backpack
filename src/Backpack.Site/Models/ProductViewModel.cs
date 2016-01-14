using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Backpack.Site.Core.Entities;

namespace Backpack.Site.Models
{
    public class ProductViewModel
    {
        public List<ProductModel> Products { get; set; }
        public List<CategoryModel> Categories { get; set; }

        /// <summary>
        /// Populates Products and Categories List
        /// </summary>
        /// <param name="products"></param>
        /// <param name="categories"></param>
        public void Build(IEnumerable<Product> products, IEnumerable<Category> categories)
        {
            Products = products.Select(n => new ProductModel
            {
                ProductName = n.ProductName,
                Price = n.UnitPrice.ToString(),
                Available = n.Discontinued
            }).ToList();

            Categories= categories.Select(n => new CategoryModel
            {

                Id = n.CategoryID,
                Name = n.CategoryName,
                Description = n.Description
            }).ToList();
        }
    }
}