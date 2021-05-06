using System;
using MyOrg.Core;
using Unity;

namespace MyOrg.Api.Core
{
    [Preserve(AllMembers=true)]
    public class Startup : IStartup
    {
        public static void LinkMePlease() {}
        public void RegisterDependency()
        {
            MyOrgContainer.RegisterSingleton<IHttpClientProvider, HttpClientProvider>();
        }

        public void OnAppStart()
        {
        }
    }
}
