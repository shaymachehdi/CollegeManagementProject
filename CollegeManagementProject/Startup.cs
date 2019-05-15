using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CollegeManagementProject.Startup))]
namespace CollegeManagementProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
