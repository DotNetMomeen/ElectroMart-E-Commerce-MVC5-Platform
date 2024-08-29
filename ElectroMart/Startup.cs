using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ElectroMart.Startup))]
namespace ElectroMart
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
