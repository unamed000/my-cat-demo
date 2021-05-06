using Xamarin.Forms;
using MyOrg.Forms.Core;

namespace MyCats
{
    public partial class App : MyOrgFormsApplication
    {
        protected override string[] IncludeAssemblyNames => new[]
        {
            nameof(MyCats)
        };

        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}
