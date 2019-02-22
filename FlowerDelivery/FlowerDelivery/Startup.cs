using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FlowerDelivery.Startup))]
namespace FlowerDelivery
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
