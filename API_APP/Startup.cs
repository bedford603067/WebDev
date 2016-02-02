using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(API_APP.Startup))]
namespace API_APP
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
