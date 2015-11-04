using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(BDSA2015.Lecture09.WebApi.Startup))]

namespace BDSA2015.Lecture09.WebApi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }
}
