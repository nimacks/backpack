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
        private readonly IProductCatalogService _catalogRepository;
        public ShopController(IProductCatalogService catalogRepository)
        {
            _catalogRepository = catalogRepository;
        }

        // GET: Northwind/Shop
        public ActionResult Index()
        {
            var model = _catalogRepository.GetProducts().ToProductViewModel();
            model.Categories = _catalogRepository.GetCategories().ToCategoriesViewModel();

            return View(model);
        }


        public ActionResult Category(int id)
        {
            //var model = _catalogRepository.GetProductsByCategory(id);
            throw new NotImplementedException();
        }

        // GET: Northwind/Shop/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Northwind/Shop/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Northwind/Shop/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Northwind/Shop/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Northwind/Shop/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Northwind/Shop/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Northwind/Shop/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
