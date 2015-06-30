namespace ITTF_TrainStation
{
    partial class ITTF_TrainStationForm
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
            this.Lbl = new System.Windows.Forms.Label();
            this.ServerLbl = new System.Windows.Forms.Label();
            this.SendMessageBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.messageTextBox = new System.Windows.Forms.TextBox();
            this.addressLabel = new System.Windows.Forms.Label();
            this.tbAddress = new System.Windows.Forms.TextBox();
            this.lbWhoAmI = new System.Windows.Forms.Label();
            this.tbWhoAmI = new System.Windows.Forms.TextBox();
            this.messagesBox = new System.Windows.Forms.RichTextBox();
            this.labelMessages = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Lbl
            // 
            this.Lbl.AutoSize = true;
            this.Lbl.Location = new System.Drawing.Point(3, 39);
            this.Lbl.Name = "Lbl";
            this.Lbl.Size = new System.Drawing.Size(36, 13);
            this.Lbl.TabIndex = 15;
            this.Lbl.Text = "server";
            // 
            // ServerLbl
            // 
            this.ServerLbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ServerLbl.Location = new System.Drawing.Point(54, 38);
            this.ServerLbl.Name = "ServerLbl";
            this.ServerLbl.Size = new System.Drawing.Size(289, 22);
            this.ServerLbl.TabIndex = 17;
            // 
            // SendMessageBtn
            // 
            this.SendMessageBtn.Location = new System.Drawing.Point(222, 18);
            this.SendMessageBtn.Name = "SendMessageBtn";
            this.SendMessageBtn.Size = new System.Drawing.Size(122, 23);
            this.SendMessageBtn.TabIndex = 12;
            this.SendMessageBtn.Text = "Send a Message";
            this.SendMessageBtn.UseVisualStyleBackColor = true;
            this.SendMessageBtn.Click += new System.EventHandler(this.SendMessageBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "message";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // messageTextBox
            // 
            this.messageTextBox.Location = new System.Drawing.Point(54, 0);
            this.messageTextBox.Name = "messageTextBox";
            this.messageTextBox.Size = new System.Drawing.Size(289, 20);
            this.messageTextBox.TabIndex = 10;
            // 
            // addressLabel
            // 
            this.addressLabel.AutoSize = true;
            this.addressLabel.Location = new System.Drawing.Point(3, 22);
            this.addressLabel.Name = "addressLabel";
            this.addressLabel.Size = new System.Drawing.Size(16, 13);
            this.addressLabel.TabIndex = 19;
            this.addressLabel.Text = "to";
            // 
            // tbAddress
            // 
            this.tbAddress.Location = new System.Drawing.Point(54, 19);
            this.tbAddress.MinimumSize = new System.Drawing.Size(4, 4);
            this.tbAddress.Name = "tbAddress";
            this.tbAddress.Size = new System.Drawing.Size(169, 20);
            this.tbAddress.TabIndex = 20;
            // 
            // lbWhoAmI
            // 
            this.lbWhoAmI.AutoSize = true;
            this.lbWhoAmI.Location = new System.Drawing.Point(3, 62);
            this.lbWhoAmI.Name = "lbWhoAmI";
            this.lbWhoAmI.Size = new System.Drawing.Size(48, 13);
            this.lbWhoAmI.TabIndex = 21;
            this.lbWhoAmI.Text = "WhoAmI";
            // 
            // tbWhoAmI
            // 
            this.tbWhoAmI.Location = new System.Drawing.Point(54, 59);
            this.tbWhoAmI.Name = "tbWhoAmI";
            this.tbWhoAmI.ReadOnly = true;
            this.tbWhoAmI.Size = new System.Drawing.Size(289, 20);
            this.tbWhoAmI.TabIndex = 22;
            // 
            // messagesBox
            // 
            this.messagesBox.Location = new System.Drawing.Point(-1, 95);
            this.messagesBox.Name = "messagesBox";
            this.messagesBox.ReadOnly = true;
            this.messagesBox.Size = new System.Drawing.Size(345, 130);
            this.messagesBox.TabIndex = 23;
            this.messagesBox.Text = "";
            // 
            // labelMessages
            // 
            this.labelMessages.AutoSize = true;
            this.labelMessages.Location = new System.Drawing.Point(3, 82);
            this.labelMessages.Name = "labelMessages";
            this.labelMessages.Size = new System.Drawing.Size(55, 13);
            this.labelMessages.TabIndex = 24;
            this.labelMessages.Text = "Messages";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(222, 39);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(122, 21);
            this.button1.TabIndex = 25;
            this.button1.Text = "Random Led Colors";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ITTF_TrainStationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(343, 224);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.labelMessages);
            this.Controls.Add(this.messagesBox);
            this.Controls.Add(this.tbWhoAmI);
            this.Controls.Add(this.lbWhoAmI);
            this.Controls.Add(this.tbAddress);
            this.Controls.Add(this.addressLabel);
            this.Controls.Add(this.Lbl);
            this.Controls.Add(this.ServerLbl);
            this.Controls.Add(this.SendMessageBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.messageTextBox);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ITTF_TrainStationForm";
            this.Text = "Train station ";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ITTF_TrainStationForm_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Lbl;
        private System.Windows.Forms.Label ServerLbl;
        private System.Windows.Forms.Button SendMessageBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox messageTextBox;
		private System.Windows.Forms.Label addressLabel;
		private System.Windows.Forms.TextBox tbAddress;
		private System.Windows.Forms.Label lbWhoAmI;
		private System.Windows.Forms.TextBox tbWhoAmI;
        private System.Windows.Forms.RichTextBox messagesBox;
        private System.Windows.Forms.Label labelMessages;
        private System.Windows.Forms.Button button1;
    }
}

