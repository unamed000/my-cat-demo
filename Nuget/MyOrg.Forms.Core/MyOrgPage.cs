using MyOrg.Forms.Core.ViewModels;
using Xamarin.Forms;

namespace MyOrg.Forms.Core
{
    public abstract class MyOrgPage<TViewModel> : ContentPage where TViewModel : AbstractViewModel
    {
        public TViewModel ViewModel { get; private set; }

        public MyOrgPage()
        {
            BindingContext = ViewModel = BuildViewModel();
        }
        
        protected override void OnAppearing()
        {
            base.OnAppearing();
            ViewModel.OnPageAppearing();
        }
        
        protected abstract TViewModel BuildViewModel();
    }
}