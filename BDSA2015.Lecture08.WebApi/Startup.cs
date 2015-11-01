using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(BDSA2015.Lecture08.WebApi.Startup))]

namespace BDSA2015.Lecture08.WebApi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }
}
