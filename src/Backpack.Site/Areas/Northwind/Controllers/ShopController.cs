using System.Web.Mvc;
using Backpack.Site.Core.Products;
using Backpack.Site.Models;


namespace Backpack.Site.Areas.Northwind.Controllers
{
    /// <summary>
    /// Shop Controller
    /// </summary>
    public class ShopController : Controller
    {
        #region Construction
        private readonly IProductCatalogService _productCatalog;
        public ShopController(IProductCatalogService productCatalog)
        {
            _productCatalog = productCatalog;
        }
        #endregion


        [Route("northwind/shop")]
        public ActionResult Index()
        {
            ProductViewModel model = new ProductViewModel();
            model.Build(_productCatalog.GetProducts(), _productCatalog.GetCategories());
            return View(model);
        }

        [Route("northwind/shop/category/{id}")]
        public ActionResult Category(int id)
        {
            ProductViewModel model = new ProductViewModel();
            model.Build(_productCatalog.GetProductsByCategory(id), _productCatalog.GetCategories());
            return View(model);
        }

        
    }
}
