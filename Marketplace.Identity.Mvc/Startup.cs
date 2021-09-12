using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Marketplace.Identity.Mvc.Startup))]
namespace Marketplace.Identity.Mvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
