using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyOrg.Forms.Core.DataTemplates;
using MyOrg.Forms.Core.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyOrg.Forms.Core.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
   public partial class MyOrgCollectionView : ILoading
    {
        public static readonly BindableProperty RealItemsSourceProperty =
            BindableProperty.Create(
                nameof(RealItemsSource),
                typeof(IEnumerable),
                typeof(MyOrgCollectionView),
                defaultValue: null,
                propertyChanged: OnRealItemsSourceChanged);

        public static readonly BindableProperty IsLoadingProperty =
            BindableProperty.Create(
                nameof(IsLoading),
                typeof(bool),
                typeof(MyOrgCollectionView),
                propertyChanged: IsLoadingPropertyChanged);

        public static readonly BindableProperty SkeletonViewNumberProperty =
            BindableProperty.Create(
                nameof(SkeletonViewNumber),
                typeof(int),
                typeof(MyOrgCollectionView),
                defaultValue: 3);

        public MyOrgCollectionView()
        {
            InitializeComponent();
        }
        
        public IEnumerable FinalItemsSource
        {
            get
            {
                if (IsLoading)
                {
                    var list = new List<LoadingItemSkeletonViewModel>();
                    for (int i = 0; i < SkeletonViewNumber; i++)
                    {
                        list.Add(new LoadingItemSkeletonViewModel());
                    }

                    return list;
                }
                else
                {
                    return RealItemsSource;
                }
            }
        }

        public IEnumerable RealItemsSource
        {
            get => (IEnumerable)GetValue(RealItemsSourceProperty);
            set
            {
                SetValue(RealItemsSourceProperty, value);
            }
        }

        public bool IsLoading
        {
            get => (bool)GetValue(IsLoadingProperty);
            set
            {
                SetValue(IsLoadingProperty, value);
            }
        }

        public int SkeletonViewNumber
        {
            get => (int)GetValue(SkeletonViewNumberProperty);
            set
            {
                SetValue(SkeletonViewNumberProperty, value);
            }
        }
        
        private static void OnRealItemsSourceChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var casted = (MyOrgCollectionView)bindable;

            if (newValue != oldValue)
            {
                casted.OnPropertyChanged(nameof(FinalItemsSource));
            }
        }

        private static void IsLoadingPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var casted = (MyOrgCollectionView)bindable;

            if (!newValue.Equals(oldValue))
            {
                casted.OnPropertyChanged(nameof(FinalItemsSource));
            }
        }
    }
}