using System;
using System.Collections.Generic;
using MyCats.ViewModels;
using MyCats.Views;
using Xamarin.Forms;

namespace MyCats
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

    }
}
