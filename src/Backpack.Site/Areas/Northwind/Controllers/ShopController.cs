using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Backpack.Site.Core.Products;
using Backpack.Site.Models.Mapper;

namespace Backpack.Site.Areas.Northwind.Controllers
{
    public class ShopController : Controller
    {
        private readonly IProductCatalogService _productCatalog;
        public ShopController(IProductCatalogService productCatalog)
        {
            _productCatalog = productCatalog;
        }

        // GET: Northwind/Shop
        public ActionResult Index()
        {
            var model = _productCatalog.GetProducts().ToProductViewModel();
            model.Categories = _productCatalog.GetCategories().ToCategoriesViewModel();

            return View(model);
        }


        public ActionResult Category(int id)
        {
            var model = _productCatalog.GetProductsByCategory(id).ToProductViewModel();
            model.Categories = _productCatalog.GetCategories().ToCategoriesViewModel();
            return View(model);
        }

        
    }
}
