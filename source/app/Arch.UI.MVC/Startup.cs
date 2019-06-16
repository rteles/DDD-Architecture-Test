using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Arch.UI.MVC.Startup))]
namespace Arch.UI.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
