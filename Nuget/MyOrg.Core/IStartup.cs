using Unity;

namespace MyOrg.Core
{
    /// <summary>
    /// This will intercept the life cycle of the application, we will use reflect to call the corresponding method of a library inside a Xam Forms app
    /// TODO: We will have troubles if later there are a lot of packages reference this, and if we upgrade the core package, we might need to upgrade ALL of the package which is references to this, so we might need to make each method into an object istead
    /// </summary>
    public interface IStartup
    {
        void RegisterDependency();

        void OnAppStart();
    }
}