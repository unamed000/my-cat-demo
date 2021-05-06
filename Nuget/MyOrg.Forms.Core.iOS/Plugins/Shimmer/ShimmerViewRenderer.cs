#pragma  warning disable

using MyOrg.Forms.Core.iOS.Plugins.Shimmer;
using MyOrg.Forms.Core.Plugins.Shimmer;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(ShimmerView), typeof(ShimmerViewRenderer))]
namespace MyOrg.Forms.Core.iOS.Plugins.Shimmer
{
    internal class ShimmerViewRenderer : ViewRenderer
    {
    }
}
