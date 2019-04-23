using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CharacterDevelopment.WebMVC.Startup))]
namespace CharacterDevelopment.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
