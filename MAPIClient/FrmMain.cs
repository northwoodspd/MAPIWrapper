using System;
using System.IO;
using System.Windows.Forms;
using MAPIWrapper;

namespace MAPIClient 
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                var mm =
                new MailMessage().AddToAddress(txtTo.Text)
                                             .AddCCAddress(txtCC.Text)
                                             .AddBCCAddress("Someone")
                                             .Subject(txtSubject.Text)
                                             .Body(txtBody.Text);

                foreach (ListViewItem item in lvwAttachments.Items)
                {
                    mm.AddAttachment(item.Tag.ToString());
                }

                mm.Send();
            }
            catch (MAPIException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void lvwAttachments_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void lvwAttachments_DragDrop(object sender, DragEventArgs e)
        {
            var files = (string[])e.Data.GetData(DataFormats.FileDrop);

            foreach (var file in files)
            {
                var item = lvwAttachments.Items.Add(Path.GetFileName(file));
                item.ImageIndex = 0;
                item.Tag = file;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lvwAttachments.Items.Clear();
            txtSubject.Text = string.Empty;
            txtTo.Text = string.Empty;

            txtCC.Text = string.Empty;
            txtBody.Text = string.Empty;
            txtSubject.Focus();
        }
    }
}
