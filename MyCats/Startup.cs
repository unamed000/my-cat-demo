using MyCats.UseCases;
using MyOrg.Core;

namespace MyCats
{
    public class Startup : IStartup
    {
        public void RegisterDependency()
        {
            MyOrgContainer.RegisterType<IGetAllBreedUseCase, GetAllBreedUseCase>();
            MyOrgContainer.RegisterType<IGetBreedByIdUseCase, GetBreedByIdUseCase>();
        }

        public void OnAppStart()
        {
        }
    }
}