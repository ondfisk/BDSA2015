using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BDSA2015.Lecture11.Web.Startup))]
namespace BDSA2015.Lecture11.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
