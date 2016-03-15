using System.Web.Mvc;
using Backpack.Site.Areas.Bootstrap.Models;

namespace Backpack.Site.Areas.Bootstrap.Controllers
{
    public class MVCHelperSamplesController : Controller
    {


        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Helper01()
        {
            return View();
        }

        public ActionResult Helper02()
        {
            UserData model = new UserData();

            return View(model);
        }

        public ActionResult Helper03()
        {
            UserData model = new UserData();

            return View(model);
        }

        public ActionResult Helper04()
        {
            UserData model = new UserData();

            return View(model);
        }

        public ActionResult Helper05()
        {
            UserData model = new UserData();

            return View(model);
        }

        public ActionResult Helper06()
        {
            UserData model = new UserData();

            return View(model);
        }
    }
}