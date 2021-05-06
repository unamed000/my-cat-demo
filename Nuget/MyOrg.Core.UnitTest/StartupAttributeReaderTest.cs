using NUnit.Framework;

namespace MyOrg.Core.UnitTest
{
    public class StartupAttributeReaderTest
    {
        public static int RegisterDependency = 0;
        public static int OnAppStart = 0;

        [SetUp]
        public void Setup()
        {
            RegisterDependency = 0;
            OnAppStart = 0;
        }

        [Test]
        public void ExecuteActionTest()
        {
            StartupAttributeReader.ExecuteAction(GetType().Assembly, startup => startup.RegisterDependency());
            StartupAttributeReader.ExecuteAction(GetType().Assembly, startup => startup.RegisterDependency());
            
            StartupAttributeReader.ExecuteAction(GetType().Assembly, startup => startup.OnAppStart());
            StartupAttributeReader.ExecuteAction(GetType().Assembly, startup => startup.OnAppStart());
            StartupAttributeReader.ExecuteAction(GetType().Assembly, startup => startup.OnAppStart());

            Assert.AreEqual(2, RegisterDependency);
            Assert.AreEqual(3, OnAppStart);
        }
    }

    public class MockStartup : IStartup
    {
        public void RegisterDependency()
        {
            StartupAttributeReaderTest.RegisterDependency++;
        }

        public void OnAppStart()
        {
            StartupAttributeReaderTest.OnAppStart++;

        }
    }
}