using NUnit.Framework;

namespace BurningPlate.Tests.Services
{
    [TestFixture]
    public class ServiceTests<T> : TestBase
    {
        protected T Service { get; set; }

        [SetUp]
        public override void SetUp()
        {

        }
    }
}