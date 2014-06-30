using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.IO;
using System.Collections.Generic;

namespace MAPIWrapper
{
    public class MAPI : IDisposable
    {
        [DllImport("MAPI32.DLL", CharSet = CharSet.Ansi)]
        public static extern uint MAPISendMail(IntPtr lhSession, IntPtr ulUIParam, ref MapiMessage lpMessage, uint flFlags, uint ulReserved);

        private MapiMessage _message;
        
        public virtual MAPI SendMail(MailMessage mailMessage)
        {
            const int mapiLogonUi = 0x00000001;
            const int mapiDialog = 0x00000008;
            const int how = mapiLogonUi | mapiDialog;

            _message = new MapiMessage { subject = mailMessage.Subject(), noteText = mailMessage.Body() };

            _message.recips = GetRecipients(mailMessage, out _message.recipCount);
            _message.files = GetAttachments(mailMessage, out _message.fileCount);

            var errorId = MAPISendMail(new IntPtr(0), new IntPtr(0), ref _message, how, 0);
            if (errorId > 1)
                throw new MAPIException(errorId);

            return this;
        }

        static IntPtr GetRecipients(MailMessage mailMessage, out int recipCount)
        {
            recipCount = 0;

            var recipients = new List<MapiRecipDesc>();
            recipients.AddRange(mailMessage.ToAddresses.Select(toAddress => new MapiRecipDesc { recipClass = (int)AddressType.To, name = toAddress }));
            recipients.AddRange(mailMessage.CCAddresses.Select(ccAddress => new MapiRecipDesc { recipClass = (int)AddressType.CC, name = ccAddress }));
            recipients.AddRange(mailMessage.BCCAddresses.Select(bccAddress => new MapiRecipDesc { recipClass = (int)AddressType.BCC, name = bccAddress }));

            if (recipients.Count == 0)
                return IntPtr.Zero;

            var size = Marshal.SizeOf(typeof(MapiRecipDesc));
            var intPtr = Marshal.AllocHGlobal(recipients.Count * size);

            var ptr = (int)intPtr;
            foreach (var mapiDesc in recipients)
            {
                Marshal.StructureToPtr(mapiDesc, (IntPtr)ptr, false);
                ptr += size;
            }

            recipCount = recipients.Count;
            return intPtr;
        }

        static IntPtr GetAttachments(MailMessage mailMessage, out int fileCount)
        {
            fileCount = 0;
            if (mailMessage.AttachmentFilePaths == null || mailMessage.AttachmentFilePaths.Count == 0)
                return IntPtr.Zero;

            var size = Marshal.SizeOf(typeof(MapiFileDesc));
            var intPtr = Marshal.AllocHGlobal(mailMessage.AttachmentFilePaths.Count * size);

            var mapiFileDesc = new MapiFileDesc { position = -1 };
            var ptr = (int)intPtr;

            foreach (string strAttachment in mailMessage.AttachmentFilePaths)
            {
                mapiFileDesc.name = Path.GetFileName(strAttachment);
                mapiFileDesc.path = strAttachment;
                Marshal.StructureToPtr(mapiFileDesc, (IntPtr)ptr, false);
                ptr += size;
            }

            fileCount = mailMessage.AttachmentFilePaths.Count;
            return intPtr;
        }

        public void Dispose()
        {
            var size = Marshal.SizeOf(typeof(MapiRecipDesc));
            int ptr;

            if (_message.recips != IntPtr.Zero)
            {
                ptr = (int)_message.recips;
                for (var i = 0; i < _message.recipCount; i++)
                {
                    Marshal.DestroyStructure((IntPtr)ptr, typeof(MapiRecipDesc));
                    ptr += size;
                }
                Marshal.FreeHGlobal(_message.recips);
            }

            if (_message.files != IntPtr.Zero)
            {
                size = Marshal.SizeOf(typeof(MapiFileDesc));

                ptr = (int)_message.files;
                for (var i = 0; i < _message.fileCount; i++)
                {
                    Marshal.DestroyStructure((IntPtr)ptr, typeof(MapiFileDesc));
                    ptr += size;
                }
                Marshal.FreeHGlobal(_message.files);
            }
        }
    }
}
