using System;
using System.Collections.Generic;

namespace MAPIWrapper
{
    public class MailMessage : IDisposable
    {
        private readonly MAPI _mapi;
        private string _subject;
        private string _body;
        public List<String> ToAddresses { get; set; }
        public List<String> CCAddresses { get; set; }
        public List<String> BCCAddresses { get; set; }
        public List<String> AttachmentFilePaths { get; set; }
        public string Subject()
        {
            return _subject;
        }
        public string Body()
        {
            return _body;
        }

        public MailMessage(MAPI mapi) : this()
        {
            _mapi = mapi;
        }

        public MailMessage()
        {
            _mapi = new MAPI();
            ToAddresses = new List<string>();
            CCAddresses = new List<string>();
            BCCAddresses = new List<string>();
            AttachmentFilePaths = new List<string>();        
        }

        public virtual MailMessage AddAddress(string address, AddressType addressType)
        {
            if (!string.IsNullOrEmpty(address))
            {
                switch (addressType)
                {
                    case AddressType.CC:
                        CCAddresses.Add(address);
                        break;
                    case AddressType.BCC:
                        BCCAddresses.Add(address);
                        break;
                    default:
                        ToAddresses.Add(address);
                        break;
                }
            }
            return this;
        }

        public MailMessage AddToAddress(string address)
        {
            return AddAddress(address, AddressType.To);
        }
        public MailMessage AddCCAddress(string address)
        {
            return AddAddress(address, AddressType.CC);
        }
        public MailMessage AddBCCAddress(string address)
        {
            return AddAddress(address, AddressType.BCC);
        }

        public MailMessage AddAttachment(string filePath)
        {
            if (!string.IsNullOrEmpty(filePath))
                AttachmentFilePaths.Add(filePath);

            return this;
        }

        public MailMessage Subject(string subject)
        {
            _subject = subject;
            return this;
        }

        public MailMessage Body(string body)
        {
            _body = body;
            return this;
        }

        public MailMessage Send()
        {
           _mapi.SendMail(this);
            return this;
        }

        public void Dispose()
        {
           _mapi.Dispose();
        }
    }
}
