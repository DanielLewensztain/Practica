using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AdmPractica1.Startup))]
namespace AdmPractica1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
