using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Synkron.UI.Startup))]
namespace Synkron.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
