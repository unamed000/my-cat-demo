using System.ComponentModel;
using Xamarin.Forms;
using MyCats.ViewModels;
using MyOrg.Core;

namespace MyCats.Views
{
    public partial class CatDetailPage
    {
        public CatDetailPage()
        {
            InitializeComponent();
        }

        protected override CatDetailsViewModel BuildViewModel()
        {
            return MyOrgContainer.Resolve<CatDetailsViewModel>();
        }
    }
}