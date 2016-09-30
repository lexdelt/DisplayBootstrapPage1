using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DisplayBootstrapPage1.Startup))]
namespace DisplayBootstrapPage1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
