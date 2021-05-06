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

        public ICommand RefreshCommand => new Command(() => RefreshData());

        public  ICommand OnCatClickedCommand => new Command(() => CatClick(SelectedCat));

        public CatBreedItem SelectedCat { get; set; }

        private void CatClick(CatBreedItem cat)
        {
            NavigationService.NavigateToUrl(nameof(CatDetailPage), new { catId = cat.Id });
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
    }
}