using NUnit.Framework;

namespace MyCats.UnitTests
{
    // TODO: Maybe we should have something like MyOrg.UnitTest.Core
    public abstract class AbstractTest<T> where T : class
    {
        [SetUp]
        protected virtual void BeforeEachTest()
        {
            Imp = GetImp();
        }

        protected T Imp;

        protected abstract T GetImp();
    }
}