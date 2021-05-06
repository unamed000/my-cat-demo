using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using MyCats.Models;
using MyCats.Models.Cat;
using MyCats.UseCases;
using MyCats.Views;
using MyOrg.Forms.Core.Navigation;
using MyOrg.Forms.Core.ViewModels;
using Xamarin.Forms;

namespace MyCats.ViewModels
{
    public class CatBreedsViewModel : AbstractViewModel
    {
        public override string Title => "Breeds"; // TODO: We should have a package for localization for later as well. but for the scope of this demo (4-6 hours) i dont think i should bother this

        private readonly IGetAllBreedUseCase _getAllBreedsUseCase;
        private ObservableCollection<CatBreedItem> _items;
        private bool _firstLoading = true;
        private ICommand _refreshCommand;
        public CatBreedsViewModel(IGetAllBreedUseCase getAllBreedsUseCase, INavigationService navigationService) : base(navigationService)
        {
            _getAllBreedsUseCase = getAllBreedsUseCase;
        }

        public ObservableCollection<CatBreedItem> Items
        {
            get => _items;
            set
            {
                _items = value;
                OnPropertyChanged(nameof(Items));
            }
        }

        public ICommand RefreshCommand
        {
            get => _refreshCommand;
            set
            {
                _refreshCommand = value;
                OnPropertyChanged(nameof(RefreshCommand));
            }
        }

        public async Task RefreshData()
        {
            await ExecuteService(async () =>
            {
                IsBusy = true;
                Items = new ObservableCollection<CatBreedItem>(await _getAllBreedsUseCase.Execute(null));
                IsBusy = false;
            },
            (exception) =>
            {
                // TODO: Show some cool ui here?
                IsBusy = false;
            });
        }
        
        public override async void OnPageAppearing()
        {
            base.OnPageAppearing();

            if (_firstLoading)
            {
                await RefreshData();
                RefreshCommand = new Command(() => RefreshData());
                _firstLoading = false;
            }
        }
    }
}