using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(proyectoClub.Startup))]
namespace proyectoClub
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
