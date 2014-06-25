using System;
using System.Collections.Generic;

namespace MAPIWrapper
{
    public class MailMessage
    {
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

        public MailMessage()
        {
            ToAddresses = new List<string>();
            CCAddresses = new List<string>();
            BCCAddresses = new List<string>();
            AttachmentFilePaths = new List<string>();
        }

        public MailMessage AddToAddress(string toAddress)
        {
            if (!string.IsNullOrEmpty(toAddress))
                ToAddresses.Add(toAddress);

            return this;
        }

        public MailMessage AddCCAddress(string ccAddress)
        {
            if (!string.IsNullOrEmpty(ccAddress))
                CCAddresses.Add(ccAddress);
            
            return this;
        }

        public MailMessage AddBCCAddress(string bccAddress)
        {
            if (!string.IsNullOrEmpty(bccAddress))
                BCCAddresses.Add(bccAddress);

            return this;
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
            new MAPI().SendMail(this); 
            return this;
        }
    }
}
