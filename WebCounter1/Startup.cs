using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebCounter1.Startup))]
namespace WebCounter1
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
