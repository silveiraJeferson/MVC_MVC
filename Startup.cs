using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC_MVC.Startup))]
namespace MVC_MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
