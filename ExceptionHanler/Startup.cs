using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ExceptionHanler.Startup))]
namespace ExceptionHanler
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
