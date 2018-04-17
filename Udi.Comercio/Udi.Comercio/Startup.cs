using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Udi.Comercio.Startup))]
namespace Udi.Comercio
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
