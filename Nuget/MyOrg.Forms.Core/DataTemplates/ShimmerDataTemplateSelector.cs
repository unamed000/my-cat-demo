using Xamarin.Forms;

namespace MyOrg.Forms.Core.DataTemplates
{
    public class ShimmerDataTemplateSelector : Xamarin.Forms.DataTemplateSelector
    {
        public Xamarin.Forms.DataTemplate Skeleton { get; set; }

        public Xamarin.Forms.DataTemplate Content { get; set; }

        protected sealed override Xamarin.Forms.DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            if (container is ILoading loadingView && loadingView.IsLoading)
            {
                return Skeleton;
            }
            else if (item is ILoading loadingModel && loadingModel.IsLoading)
            {
                return Skeleton;
            }
            else
            {
                return GetContentTemplate(item, container);
            }
        }

        protected virtual Xamarin.Forms.DataTemplate GetContentTemplate(object item, BindableObject container)
        {
            return Content;
        }
    }
}