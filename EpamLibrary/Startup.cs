using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EpamLibrary.Startup))]
namespace EpamLibrary
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
