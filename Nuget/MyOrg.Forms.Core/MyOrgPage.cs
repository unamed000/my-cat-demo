using Xamarin.Forms;

namespace MyOrg.Forms.Core
{
    public abstract class MyOrgPage<TViewModel> : ContentPage
    {
        public TViewModel ViewModel { get; private set; }

        public MyOrgPage()
        {
            BindingContext = ViewModel = BuildViewModel();
        }
        
        protected abstract TViewModel BuildViewModel();
    }
}