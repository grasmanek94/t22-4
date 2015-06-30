namespace ITTF_Server
{
    partial class ITTF_SERVER_CONTROL_FORM
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
            this.controlPictureBox = new System.Windows.Forms.PictureBox();
            this.controlTimer = new System.Windows.Forms.Timer(this.components);
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lastKeyPressLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.controlPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // controlPictureBox
            // 
            this.controlPictureBox.Image = global::ITTF_Server.Properties.Resources.right;
            this.controlPictureBox.Location = new System.Drawing.Point(33, 36);
            this.controlPictureBox.Name = "controlPictureBox";
            this.controlPictureBox.Size = new System.Drawing.Size(227, 188);
            this.controlPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.controlPictureBox.TabIndex = 0;
            this.controlPictureBox.TabStop = false;
            // 
            // controlTimer
            // 
            this.controlTimer.Tick += new System.EventHandler(this.controlTimer_Tick);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(12, 266);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(260, 21);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 240);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Last Key Press:";
            // 
            // lastKeyPressLabel
            // 
            this.lastKeyPressLabel.AutoSize = true;
            this.lastKeyPressLabel.Location = new System.Drawing.Point(95, 240);
            this.lastKeyPressLabel.Name = "lastKeyPressLabel";
            this.lastKeyPressLabel.Size = new System.Drawing.Size(0, 13);
            this.lastKeyPressLabel.TabIndex = 3;
            // 
            // ITTF_SERVER_CONTROL_FORM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 299);
            this.Controls.Add(this.lastKeyPressLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.controlPictureBox);
            this.Name = "ITTF_SERVER_CONTROL_FORM";
            this.Text = "ITTF_SERVER_CONTROL_FORM";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ITTF_SERVER_CONTROL_FORM_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ITTF_SERVER_CONTROL_FORM_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.controlPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox controlPictureBox;
        private System.Windows.Forms.Timer controlTimer;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lastKeyPressLabel;
    }
}