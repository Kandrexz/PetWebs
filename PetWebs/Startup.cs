using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PetWebs.Startup))]
namespace PetWebs
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
