using MyOrg.Core;
using Unity;

namespace MyOrg.Storage.Secure
{
    [MyOrg.Core.Preserve(AllMembers=true)]
    public class Startup : IStartup
    {
        public void RegisterDependency()
        {
            MyOrgContainer.RegisterType<IMyOrgSecureStorage, MyOrgSecureStorage>();
        }

        public void OnAppStart()
        {
        }
    }
}