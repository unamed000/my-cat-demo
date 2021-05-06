using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using MyCats.Models.Cat;
using MyCats.UseCases;
using MyOrg.Forms.Core.Navigation;
using MyOrg.Forms.Core.ViewModels;
using Xamarin.Forms;

namespace MyCats.ViewModels
{
    public class CatDetailsViewModel : AbstractViewModel, IQueryAttributable
    {
        private string _catId;
        private CatBreedDetailsItem _cat;
        private readonly IGetBreedByIdUseCase _getBreedByIdUseCase;
        private bool _isLoadingError;

        public bool LoadingError
        {
            get => _isLoadingError;
            set
            {
                _isLoadingError = value;
                OnPropertyChanged(nameof(LoadingError));
            }
        }

        public CatBreedDetailsItem Cat
        {
            get => _cat;
            set
            {
                _cat = value;
                OnPropertyChanged(nameof(Cat));
            }
        }

        public ICommand RefreshCommand => new Command(() => LoadData());

        public CatDetailsViewModel(
            IGetBreedByIdUseCase getBreedByIdUseCase,
            INavigationService navigationService) : base(navigationService)
        {
            _getBreedByIdUseCase = getBreedByIdUseCase;
        }

        public void ApplyQueryAttributes(IDictionary<string, string> query)
        {
            _catId = query["catId"];
            LoadData();
        }

        public async Task LoadData()
        {
            await ExecuteService(async () =>
            {
                LoadingError = false;
                IsBusy = true;
                Cat = await _getBreedByIdUseCase.Execute(new IGetBreedByIdUseCase.Param()
                {
                    CatId = _catId
                });
                IsBusy = false;
            }, (exception) =>
            {
                // TODO: Show some UI here that indicate failure
                LoadingError = true;
                IsBusy = false;
            });
        }
    }
}