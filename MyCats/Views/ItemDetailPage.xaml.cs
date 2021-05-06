using System.ComponentModel;
using Xamarin.Forms;
using MyCats.ViewModels;

namespace MyCats.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}