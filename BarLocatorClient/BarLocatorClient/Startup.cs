using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BarLocatorClient.Startup))]
namespace BarLocatorClient
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }
}
