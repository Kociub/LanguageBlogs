using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LanguageBlogs.Startup))]
namespace LanguageBlogs
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {

        }
    }
}
