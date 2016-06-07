using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Backpack.Site.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewData["ipaddress"] = Request.ServerVariables["REMOTE_ADDR"];
            
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Hello Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}