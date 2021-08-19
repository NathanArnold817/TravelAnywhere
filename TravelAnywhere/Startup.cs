using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TravelAnywhere.Startup))]
namespace TravelAnywhere
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
