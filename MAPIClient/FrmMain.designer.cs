namespace MAPIClient
{
    partial class FrmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.btnSend = new System.Windows.Forms.Button();
            this.txtSubject = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lvwAttachments = new System.Windows.Forms.ListView();
            this.imgIcons = new System.Windows.Forms.ImageList(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCC = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtBody = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(208, 404);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(91, 32);
            this.btnSend.TabIndex = 7;
            this.btnSend.Text = "Email";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // txtSubject
            // 
            this.txtSubject.Location = new System.Drawing.Point(14, 33);
            this.txtSubject.Name = "txtSubject";
            this.txtSubject.Size = new System.Drawing.Size(382, 20);
            this.txtSubject.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 14);
            this.label1.TabIndex = 9;
            this.label1.Text = "Subject";
            // 
            // lvwAttachments
            // 
            this.lvwAttachments.AllowDrop = true;
            this.lvwAttachments.LargeImageList = this.imgIcons;
            this.lvwAttachments.Location = new System.Drawing.Point(14, 276);
            this.lvwAttachments.Name = "lvwAttachments";
            this.lvwAttachments.Size = new System.Drawing.Size(382, 104);
            this.lvwAttachments.TabIndex = 6;
            this.lvwAttachments.UseCompatibleStateImageBehavior = false;
            this.lvwAttachments.DragDrop += new System.Windows.Forms.DragEventHandler(this.lvwAttachments_DragDrop);
            this.lvwAttachments.DragEnter += new System.Windows.Forms.DragEventHandler(this.lvwAttachments_DragEnter);
            // 
            // imgIcons
            // 
            this.imgIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgIcons.ImageStream")));
            this.imgIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.imgIcons.Images.SetKeyName(0, "MailAttach.png");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 258);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 14);
            this.label2.TabIndex = 15;
            this.label2.Text = "Attachments";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(305, 404);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(91, 32);
            this.btnClear.TabIndex = 8;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(18, 14);
            this.label3.TabIndex = 10;
            this.label3.Text = "To";
            // 
            // txtTo
            // 
            this.txtTo.Location = new System.Drawing.Point(14, 79);
            this.txtTo.Name = "txtTo";
            this.txtTo.Size = new System.Drawing.Size(382, 20);
            this.txtTo.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 109);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 14);
            this.label4.TabIndex = 12;
            this.label4.Text = "CC";
            // 
            // txtCC
            // 
            this.txtCC.Location = new System.Drawing.Point(14, 126);
            this.txtCC.Name = "txtCC";
            this.txtCC.Size = new System.Drawing.Size(382, 20);
            this.txtCC.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 154);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 14);
            this.label7.TabIndex = 14;
            this.label7.Text = "Body";
            // 
            // txtBody
            // 
            this.txtBody.Location = new System.Drawing.Point(14, 171);
            this.txtBody.Multiline = true;
            this.txtBody.Name = "txtBody";
            this.txtBody.Size = new System.Drawing.Size(382, 79);
            this.txtBody.TabIndex = 5;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(16, 386);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(179, 14);
            this.label8.TabIndex = 16;
            this.label8.Text = "Drag/Drop to add an attachment";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(409, 456);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtBody);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtCC);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtTo);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lvwAttachments);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSubject);
            this.Controls.Add(this.btnSend);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Email Tester";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox txtSubject;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView lvwAttachments;
        private System.Windows.Forms.ImageList imgIcons;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCC;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtBody;
        private System.Windows.Forms.Label label8;
    }
}

