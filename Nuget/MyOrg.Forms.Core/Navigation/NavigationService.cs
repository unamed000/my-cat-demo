using System.Threading.Tasks;
using Xamarin.Forms;

namespace MyOrg.Forms.Core.Navigation
{
    public interface INavigationService
    {
        Task NavigateToUrl(string url, object param = null);
    }

    public class NavigationService : INavigationService
    {
        public async Task NavigateToUrl(string url, object param = null)
        {
            if (param != null)
            {
                url += "?" + NavigationParamBuilder.ConvertObjectToQueryUrl(param);
            }
            await Shell.Current.GoToAsync(url);
        }
    }
}