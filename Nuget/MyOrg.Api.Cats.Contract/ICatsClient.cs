using System;
using System.Threading.Tasks;

namespace MyOrg.Api.Cats.Contract
{
    public interface ICatsClient
    {
        Task<CatBreedDTO[]> GetCatBreeds();

        Task<CatBreedDetailsDTO> GetCatBreedById(string id);
    }
}
