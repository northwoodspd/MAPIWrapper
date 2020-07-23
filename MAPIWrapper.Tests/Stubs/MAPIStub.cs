namespace MAPITests.Stubs
{
    public class MAPIStub:MAPIWrapper.MAPI
    {
        public bool SendMailWasCalled { get; private set; }
        public override MAPIWrapper.MAPI SendMail(MAPIWrapper.MailMessage mailMessage)
        {
            SendMailWasCalled = true;
            return this;
        }
    }
}
