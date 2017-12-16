using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(PosturerAPI.Startup))]

namespace PosturerAPI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}