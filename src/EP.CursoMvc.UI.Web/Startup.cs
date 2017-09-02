using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EP.CursoMvc.UI.Web.Startup))]
namespace EP.CursoMvc.UI.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
