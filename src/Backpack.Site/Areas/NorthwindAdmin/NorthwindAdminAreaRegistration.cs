using System.Web.Mvc;

namespace Backpack.Site.Areas.NorthwindAdmin
{
    public class NorthwindAdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "NorthwindAdmin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "NorthwindAdmin_default",
                "NorthwindAdmin/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}