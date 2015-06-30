namespace ITTF_Server
{
    partial class ServerGUI
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
			this.infoText = new System.Windows.Forms.RichTextBox();
			this.SuspendLayout();
			// 
			// infoText
			// 
			this.infoText.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.infoText.Dock = System.Windows.Forms.DockStyle.Fill;
			this.infoText.Location = new System.Drawing.Point(0, 0);
			this.infoText.Margin = new System.Windows.Forms.Padding(0);
			this.infoText.Name = "infoText";
			this.infoText.ReadOnly = true;
			this.infoText.Size = new System.Drawing.Size(630, 447);
			this.infoText.TabIndex = 0;
			this.infoText.Text = "";
			// 
			// ServerGUI
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(630, 447);
			this.Controls.Add(this.infoText);
			this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
			this.Name = "ServerGUI";
			this.Text = "Server GUI";
			this.ResumeLayout(false);

        }

        #endregion

		public System.Windows.Forms.RichTextBox infoText;
    }
}

