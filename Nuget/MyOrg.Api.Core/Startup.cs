using System;
using MyOrg.Core;
using Unity;

namespace MyOrg.Api.Core
{
    [Preserve(AllMembers = true)]
    public class Startup : IStartup
    {
        public void RegisterDependency()
        {
            MyOrgContainer.RegisterType<IHttpClientProvider, HttpClientProvider>();
        }

        public void OnAppStart()
        {
        }
    }
}
