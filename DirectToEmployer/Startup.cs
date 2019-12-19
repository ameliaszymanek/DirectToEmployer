using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DirectToEmployer.Startup))]
namespace DirectToEmployer
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
