using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LangBlogs.Startup))]
namespace LangBlogs
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
