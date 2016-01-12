using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Backpack.Site.Models
{
    public class ProductViewModel
    {
        public List<ProductModel> Products { get; set; }
        public List<CategoryModel> Categories { get; set; }
    }
}