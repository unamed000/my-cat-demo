using System;
using System.Net.Http;
using System.Threading.Tasks;
using MyOrg.Api.Cats.Contract;
using MyOrg.Api.Core;
using Newtonsoft.Json;

namespace MyOrg.Api.Cats.Client
{
    public class CatsClient : ICatsClient
    {
        public const string KEY = "cats";
        
        private readonly IHttpClientProvider _httpClientProvider;

        public CatsClient(IHttpClientProvider httpClientProvider)
        {
            _httpClientProvider = httpClientProvider;
        }

        private HttpClient GetHttpClient()
        {
            return _httpClientProvider.GetHttpClient(KEY);
        }
        
        public async Task<CatBreedDTO[]> GetCatBreeds()
        {
            var response = await GetHttpClient().GetAsync("/v1/breeds").ConfigureAwait(false);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            return JsonConvert.DeserializeObject<CatBreedDTO[]>(result);
        }

        public async Task<CatBreedDetailsDTO> GetCatBreedById(string id)
        {
            var response = await GetHttpClient().GetAsync($"/v1/images/search?breed_ids={id}").ConfigureAwait(false);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            return JsonConvert.DeserializeObject<CatBreedDetailsDTO[]>(result)?[0];
        }
    }
}