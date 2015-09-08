using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Log4NetDbTest.Startup))]
namespace Log4NetDbTest
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
