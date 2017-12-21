using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HISAB.ExpenseTracker.Startup))]
namespace HISAB.ExpenseTracker
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
