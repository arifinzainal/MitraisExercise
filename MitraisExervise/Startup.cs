using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MitraisExervise.Startup))]
namespace MitraisExervise
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
