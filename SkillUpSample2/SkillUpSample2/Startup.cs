using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SkillUpSample2.Startup))]
namespace SkillUpSample2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
