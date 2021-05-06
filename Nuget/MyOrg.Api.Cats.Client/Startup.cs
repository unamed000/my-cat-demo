using System;
using System.Net.Http;
using MyOrg.Api.Cats.Contract;
using MyOrg.Api.Core;
using MyOrg.Core;

namespace MyOrg.Api.Cats.Client
{
    [Preserve(AllMembers = true)]
    public class Startup : IStartup
    {
        public static void LinkMePlease() {}
        public void RegisterDependency()
        {
            MyOrgContainer.RegisterType<ICatsClient, CatsClient>();
        }

        public void OnAppStart()
        {
            SetupCatsHttpClient();
        }

        private void SetupCatsHttpClient()
        {
            var catHttpClient = new HttpClient()
            {
                BaseAddress = new Uri(Const.BASE_URL)
            };

            catHttpClient.DefaultRequestHeaders.Add("x-api-key", Const.API_KEY);
            
            MyOrgContainer.Resolve<IHttpClientProvider>()
                .SetHttpClient(CatsClient.KEY, catHttpClient);
        }
    }
}