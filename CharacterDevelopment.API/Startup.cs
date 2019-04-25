using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(CharacterDevelopment.API.Startup))]

namespace CharacterDevelopment.API
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            ConfigureAuth(app);
        }
    }
}
