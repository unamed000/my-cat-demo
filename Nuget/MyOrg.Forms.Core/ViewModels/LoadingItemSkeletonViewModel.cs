using MyOrg.Forms.Core.DataTemplates;

namespace MyOrg.Forms.Core.ViewModels
{
    public class LoadingItemSkeletonViewModel : ILoading
    {
        public bool IsLoading { get; } = true;
    }
}