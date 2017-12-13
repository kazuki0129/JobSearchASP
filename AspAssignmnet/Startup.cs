using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AspAssignmnet.Startup))]
namespace AspAssignmnet
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
