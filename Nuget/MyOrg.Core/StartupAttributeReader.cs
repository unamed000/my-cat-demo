using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace MyOrg.Core
{
    public static class StartupAttributeReader
    {
        public static void ExecuteAction(Action<IStartup> execute, string[] includeAssemblyNames = null)
        {
            var startupInterface = typeof(IStartup);
            foreach (var type in AppDomain.CurrentDomain.GetAssemblies())
            {
                Debug.WriteLine("Types:" + type.FullName);
            }
            foreach(Type type in AppDomain.CurrentDomain.GetAssemblies()
                .Where(ass => ass.FullName.StartsWith("MyOrg") || includeAssemblyNames.Any(iass => ass.FullName.StartsWith(iass)))
                .SelectMany(x => x.GetTypes().Where(type => type.IsClass))) {
                try
                {
                    if (startupInterface.IsAssignableFrom(type)) {
                        Debug.WriteLine("Accepted Types:" + type.ToString());
                        // TODO: We could store the instance somewhere else for avoiding reinitialize everytime
                        var instance = Activator.CreateInstance(type) as IStartup;
                        execute.Invoke(instance);
                    }
                }
                catch
                {
                    Debug.WriteLine("Can not load type: " + type.ToString());
                    continue;
                }
            }
        }
    }
}