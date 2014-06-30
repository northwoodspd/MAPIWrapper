using NUnit.Framework;
using Should.Fluent;

namespace MAPITests
{
    [TestFixture]
   public class MAPIExceptionTests
    {
        [Test]
        public void GeneralEmailFailureTest()
        {
            MAPIWrapper.MAPIException.GetDescription(2).Should().Equal("General email failure [2]");
        }

        [Test]
        public void ExtenedEmailFailureTest()
        {
            MAPIWrapper.MAPIException.GetDescription(666).Should().Equal("MAPI error [666]");
        }

    }
}
