using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BootFlixBC9.Startup))]
namespace BootFlixBC9
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
