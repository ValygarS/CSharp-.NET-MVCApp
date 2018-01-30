using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CA1_MVCApp.Startup))]
namespace CA1_MVCApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
