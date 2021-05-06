using MyOrg.Core;
using Unity;

namespace MyOrg.Storage.Secure
{
    [Preserve(AllMembers=true)]
    public class Startup : IStartup
    {
        public static void LinkMePlease() {}
        public void RegisterDependency()
        {
            MyOrgContainer.RegisterType<IMyOrgSecureStorage, MyOrgSecureStorage>();
        }

        public void OnAppStart()
        {
        }
    }
}