using System;
using System.Reflection;

namespace MyOrg.Core
{
    public static class StartupAttributeReader
    {
        public static void ExecuteAction(Assembly assembly, Action<IStartup> execute)
        {
            var startupInterface = typeof(IStartup);
            foreach(Type type in assembly.GetTypes()) {
                if (startupInterface.IsAssignableFrom(type)) {
                    // TODO: We could store the instance somewhere else for avoiding reinitialize everytime
                    var instance = Activator.CreateInstance(type) as IStartup;
                    execute.Invoke(instance);
                }
            }
        }
    }
}