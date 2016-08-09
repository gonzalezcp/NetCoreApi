using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EFDbFirst.Startup))]
namespace EFDbFirst
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
