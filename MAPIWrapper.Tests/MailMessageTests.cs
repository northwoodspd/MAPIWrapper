using MAPITests.Stubs;
using MAPIWrapper;
using NUnit.Framework;
using Should.Fluent;

namespace MAPITests
{
    [TestFixture]
    public class MailMessageTests
    {
        private MailMessage _mailMessage;
        private MAPIStub _mapiStub;
 
        [SetUp]
        public void Before()
        {
            _mapiStub = new MAPIStub();
            _mailMessage = new MailMessage(_mapiStub);
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
        public void BlankAddressesShouldNotBeSaved()
        {
            _mailMessage.AddAddress("", AddressType.To);
            _mailMessage.ToAddresses.Should().Not.Be.Null();
            _mailMessage.ToAddresses.Count.Should().Equal(0);
        }

        [Test]
        public void AddingToAddressWorks()
        {
            _mailMessage.AddToAddress("TestAddress");
            _mailMessage.ToAddresses.Count.Should().Equal(1);
            _mailMessage.ToAddresses[0].Should().Equal("TestAddress");
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
        public void AddingBCCAddressWorks()
        {
            _mailMessage.AddBCCAddress("TestAddress");
            _mailMessage.BCCAddresses.Count.Should().Equal(1);
            _mailMessage.BCCAddresses[0].Should().Equal("TestAddress");
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

        [Test]
        public void MailMessageSendCallsMAPISend()
        {
            _mailMessage.Send();
            _mapiStub.SendMailWasCalled.Should().Be.True();

        }
    }
}
