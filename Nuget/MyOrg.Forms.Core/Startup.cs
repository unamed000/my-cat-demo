using MyOrg.Core;
using MyOrg.Forms.Core.Navigation;

namespace MyOrg.Forms.Core
{
    public class Startup : IStartup
    {
        public void RegisterDependency()
        {
            MyOrgContainer.RegisterSingleton<INavigationService, NavigationService>();
        }

        public void OnAppStart()
        {
        }
    }
}