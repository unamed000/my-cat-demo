using System.Windows.Input;
using MyCats.Views;
using MyOrg.Core;
using MyOrg.Forms.Core.Navigation;
using Xamarin.Forms;
using ImageSource = Xamarin.Forms.ImageSource;

namespace MyCats.Models.Cat
{
    public class CatBreedItem
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }

        public ICommand OnCatClickedCommand => new Command(OnCatClicked);

        private void OnCatClicked()
        {
            MyOrgContainer.Resolve<INavigationService>().NavigateToUrl(nameof(CatDetailPage), new { catId = Id });
        }
    }
}