using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EventForte.Startup))]
namespace EventForte
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
