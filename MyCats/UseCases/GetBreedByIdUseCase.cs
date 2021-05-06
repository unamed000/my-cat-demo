using System;
using System.Linq;
using System.Threading.Tasks;
using MyCats.Models;
using MyCats.Models.Cat;
using MyOrg.Api.Cats.Contract;
using MyOrg.Core.UseCase;

namespace MyCats.UseCases
{
    public interface IGetBreedByIdUseCase : IAsynchronousUseCase<IGetBreedByIdUseCase.Param, CatBreedDetailsItem>
    {
        public class Param
        {
            public string CatId { get; set; }
        }
    }
    
    public class GetBreedByIdUseCase : AsynchronousUseCase<IGetBreedByIdUseCase.Param, CatBreedDetailsItem>, IGetBreedByIdUseCase
    {
        private readonly ICatsClient _catsClient;

        public GetBreedByIdUseCase(ICatsClient catsClient)
        {
            _catsClient = catsClient;
        }
        
        public override async Task<CatBreedDetailsItem> Execute(IGetBreedByIdUseCase.Param args)
        {
            if (args.CatId == "aege")
            {
                throw new Exception("By purpose");
            }
            var item = await _catsClient.GetCatBreedById(args.CatId);

            var result = TransformToCatBreed(item);
            return result;
        }

        private CatBreedDetailsItem TransformToCatBreed(CatBreedDetailsDTO dto)
        {
            var breed = dto.breeds[0];
            return new CatBreedDetailsItem()
            {
                Id = breed.id,
                Name = breed.name,
                Description = breed.description,
                ImageUrl = dto.url
            };
        }
    }
}