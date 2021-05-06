using Unity;

namespace MyOrg.Core
{
    public static class MyOrgContainer
    {
        private static UnityContainer _container = new UnityContainer();
        
        public static T Resolve<T>()
            where T : class {
            return Resolve<T>(null);
        }

        public static T Resolve<T>(params object[] parameters)
            where T : class {
            var instance = _container?.Resolve<T>();

            return instance;
        }
        
        public static void RegisterType<T, TF>()
            where TF : class, T {
            _container.RegisterType<T, TF>();
        }

    }
}