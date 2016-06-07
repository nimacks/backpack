using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Backpack.WebForms.Startup))]
namespace Backpack.WebForms
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
