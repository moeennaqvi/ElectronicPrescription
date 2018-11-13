using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ElectronicRX2._1.Startup))]
namespace ElectronicRX2._1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
