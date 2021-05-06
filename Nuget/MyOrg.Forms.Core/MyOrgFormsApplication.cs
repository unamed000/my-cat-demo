using System;
using System.Diagnostics;
using System.Linq;
using MyOrg.Core;
using Xamarin.Forms;

namespace MyOrg.Forms.Core
{
    public abstract class MyOrgFormsApplication : Application
    {
        protected virtual string[] IncludeAssemblyNames => null;
        
        public MyOrgFormsApplication()
        {
            StartupAttributeReader.ExecuteAction(startup => startup.RegisterDependency(), IncludeAssemblyNames);
        }

        protected override void OnStart()
        {
            base.OnStart();
            StartupAttributeReader.ExecuteAction(startup => startup.OnAppStart(), IncludeAssemblyNames);
        }
    }
}
