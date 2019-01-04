using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VMApp2.Startup))]
namespace VMApp2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
