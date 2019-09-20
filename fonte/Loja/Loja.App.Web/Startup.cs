using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Loja.App.Web.Startup))]
namespace Loja.App.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
