using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using MyOrg.Forms.Core.Navigation;

namespace MyOrg.Forms.Core.ViewModels
{
    public class AbstractViewModel : INotifyPropertyChanged
    {
        protected INavigationService NavigationService;
        
        public AbstractViewModel(INavigationService navigationService)
        {
            NavigationService = navigationService;
        }
        
        
        public virtual string Title => string.Empty;

        
        private bool _isBusy;

        public bool IsBusy
        {
            get => _isBusy;
            set
            {
                _isBusy = value;
                OnPropertyChanged(nameof(IsBusy));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected async Task ExecuteService(Func<Task> action, Action<Exception> onFailure)
        {
            try
            {
                await action();
            }
            catch (Exception e)
            {
                // TODO: This is the place we should write some logging to our server or a third party service (Raygun) for example
                onFailure(e);
            }
        }
    }
}