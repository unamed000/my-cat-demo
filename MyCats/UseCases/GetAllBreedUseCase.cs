using System;
using System.Linq;
using System.Threading.Tasks;
using MyCats.Models;
using MyCats.Models.Cat;
using MyOrg.Api.Cats.Contract;
using MyOrg.Core.UseCase;
using Xamarin.Forms;

namespace MyCats.UseCases
{
    public interface IGetAllBreedUseCase : IAsynchronousUseCase<object, CatBreedItem[]>
    {
    }
    
    public class GetAllBreedUseCase : AsynchronousUseCase<object, CatBreedItem[]>, IGetAllBreedUseCase
    {
        private readonly ICatsClient _catsClient;

        public GetAllBreedUseCase(ICatsClient catsClient)
        {
            _catsClient = catsClient;
        }
        
        public override async Task<CatBreedItem[]> Execute(object obj)
        {
            var items = await _catsClient.GetCatBreeds();

            var result = items.Select(TransformToCatBreed).ToArray();
            return result;
        }

        private CatBreedItem TransformToCatBreed(CatBreedDTO dto)
        {
            return new CatBreedItem()
            {
                Id = dto.id,
                Name = dto.name,
                ImageUrl = dto.Image?.url
            };
        }
    }
}