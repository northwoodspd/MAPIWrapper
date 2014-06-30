using MAPIWrapper;
using NUnit.Framework;
using Should.Fluent;

namespace MAPITests
{
    [TestFixture]
    public class MailMessageTests
    {
        private MailMessage _mailMessage;

        [SetUp]
        public void Before()
        {
            _mailMessage = new MailMessage();
        }

        [Test]
        public void ConstructorInitalizesCollections()
        {
            _mailMessage.ToAddresses.Should().Not.Be.Null();
            _mailMessage.CCAddresses.Should().Not.Be.Null();
            _mailMessage.BCCAddresses.Should().Not.Be.Null();
            _mailMessage.AttachmentFilePaths.Should().Not.Be.Null();

            _mailMessage.ToAddresses.Count.Should().Equal(0);
            _mailMessage.CCAddresses.Count.Should().Equal(0);
            _mailMessage.BCCAddresses.Count.Should().Equal(0);
            _mailMessage.AttachmentFilePaths.Count.Should().Equal(0);
        }

        [Test]
        public void AddingToAddressWorks()
        {
            _mailMessage.AddToAddress("TestAddress");
            _mailMessage.ToAddresses.Count.Should().Equal(1);
            _mailMessage.ToAddresses[0].Should().Equal("TestAddress");
        }
        [Test]
        public void AddingBlankToAddressDoesntAddAnAddress()
        {
            _mailMessage.AddToAddress("");
            _mailMessage.ToAddresses.Count.Should().Equal(0);
        }
        [Test]
        public void AddingMultipleToAddressAddsAllAddresses()
        {
            _mailMessage.AddToAddress("TestAddress");
            _mailMessage.AddToAddress("TestAddress2");
            _mailMessage.ToAddresses.Count.Should().Equal(2);
        }


        [Test]
        public void AddingCCAddressWorks()
        {
            _mailMessage.AddCCAddress("TestAddress");
            _mailMessage.CCAddresses.Count.Should().Equal(1);
            _mailMessage.CCAddresses[0].Should().Equal("TestAddress");
        }
        [Test]
        public void AddingBlankCCAddressDoesntAddAnAddress()
        {
            _mailMessage.AddCCAddress("");
            _mailMessage.CCAddresses.Count.Should().Equal(0);
        }

        [Test]
        public void AddingBCCAddressWorks()
        {
            _mailMessage.AddBCCAddress("TestAddress");
            _mailMessage.BCCAddresses.Count.Should().Equal(1);
            _mailMessage.BCCAddresses[0].Should().Equal("TestAddress");
        }
        [Test]
        public void AddingBlankBCCAddressDoesntAddAnAddress()
        {
            _mailMessage.AddBCCAddress("");
            _mailMessage.BCCAddresses.Count.Should().Equal(0);
        }

        [Test]
        public void AddingAttachmentWorks()
        {
            _mailMessage.AddAttachment("TestAttachment");
            _mailMessage.AttachmentFilePaths.Count.Should().Equal(1);
            _mailMessage.AttachmentFilePaths[0].Should().Equal("TestAttachment");
        }
        [Test]
        public void AddingBlankAttachmentDoesntAddAnAttachment()
        {
            _mailMessage.AddAttachment("");
            _mailMessage.AttachmentFilePaths.Count.Should().Equal(0);
        }

        [Test]
        public void SettingSubjectWorks()
        {
            _mailMessage.Subject("TestSubject");

            _mailMessage.Subject().Should().Equal("TestSubject");
        }
        [Test]
        public void OverwriteSubject()
        {
            _mailMessage.Subject("TestSubject");
            _mailMessage.Subject("DifferentSubject");

            _mailMessage.Subject().Should().Equal("DifferentSubject");
        }

        [Test]
        public void SettingBodyWorks()
        {
            _mailMessage.Body("TestBody");

            _mailMessage.Body().Should().Equal("TestBody");
        }
        [Test]
        public void OverwriteBody()
        {
            _mailMessage.Body("TestBody");
            _mailMessage.Body("DifferentBody");

            _mailMessage.Body().Should().Equal("DifferentBody");
        }
    }
}
