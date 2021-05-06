using MyCats.ViewModels;
using MyOrg.Core;
using Xamarin.Forms;

namespace MyCats.Views
{
    public partial class CatBreedsPage
    {
        public CatBreedsPage()
        {
            InitializeComponent();
            ViewModel.RefreshData();
        }

        protected override CatBreedsViewModel BuildViewModel()
        {
            return MyOrgContainer.Resolve<CatBreedsViewModel>();
        }
    }
}