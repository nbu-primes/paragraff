using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Paragraff.Startup))]
namespace Paragraff
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
