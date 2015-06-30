namespace Communication
{
    partial class TrainDrukteForm
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
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.nup_start = new System.Windows.Forms.NumericUpDown();
			this.nup_to = new System.Windows.Forms.NumericUpDown();
			this.nup_red = new System.Windows.Forms.NumericUpDown();
			this.nup_green = new System.Windows.Forms.NumericUpDown();
			this.nup_blue = new System.Windows.Forms.NumericUpDown();
			this.nup_bright = new System.Windows.Forms.NumericUpDown();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.btn_apply = new System.Windows.Forms.Button();
			this.colorDialog1 = new System.Windows.Forms.ColorDialog();
			this.button3 = new System.Windows.Forms.Button();
			this.tabs = new System.Windows.Forms.TabControl();
			this.traintraffic = new System.Windows.Forms.TabPage();
			this.btSet2 = new System.Windows.Forms.Button();
			this.btSet1 = new System.Windows.Forms.Button();
			this.btClear = new System.Windows.Forms.Button();
			this.tb6 = new System.Windows.Forms.TrackBar();
			this.tb5 = new System.Windows.Forms.TrackBar();
			this.tb4 = new System.Windows.Forms.TrackBar();
			this.tb3 = new System.Windows.Forms.TrackBar();
			this.tb2 = new System.Windows.Forms.TrackBar();
			this.tb1 = new System.Windows.Forms.TrackBar();
			this.pictureBox6 = new System.Windows.Forms.PictureBox();
			this.pictureBox5 = new System.Windows.Forms.PictureBox();
			this.pictureBox4 = new System.Windows.Forms.PictureBox();
			this.pictureBox3 = new System.Windows.Forms.PictureBox();
			this.pictureBox2 = new System.Windows.Forms.PictureBox();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.messages = new System.Windows.Forms.TabPage();
			this.ledcontrol = new System.Windows.Forms.TabPage();
			this.cbCom = new System.Windows.Forms.ComboBox();
			this.label8 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.maxLedsNUP = new System.Windows.Forms.NumericUpDown();
			this.connectbutton = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.nup_start)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nup_to)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nup_red)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nup_green)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nup_blue)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nup_bright)).BeginInit();
			this.tabs.SuspendLayout();
			this.traintraffic.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.tb6)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tb5)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tb4)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tb3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tb2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.tb1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.messages.SuspendLayout();
			this.ledcontrol.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.maxLedsNUP)).BeginInit();
			this.SuspendLayout();
			// 
			// timer1
			// 
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// listBox1
			// 
			this.listBox1.FormattingEnabled = true;
			this.listBox1.Location = new System.Drawing.Point(6, 12);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(169, 355);
			this.listBox1.TabIndex = 5;
			this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
			// 
			// panel1
			// 
			this.panel1.Location = new System.Drawing.Point(181, 12);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(615, 355);
			this.panel1.TabIndex = 6;
			// 
			// nup_start
			// 
			this.nup_start.Location = new System.Drawing.Point(75, 78);
			this.nup_start.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
			this.nup_start.Name = "nup_start";
			this.nup_start.Size = new System.Drawing.Size(52, 20);
			this.nup_start.TabIndex = 7;
			// 
			// nup_to
			// 
			this.nup_to.Location = new System.Drawing.Point(75, 104);
			this.nup_to.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
			this.nup_to.Name = "nup_to";
			this.nup_to.Size = new System.Drawing.Size(52, 20);
			this.nup_to.TabIndex = 7;
			// 
			// nup_red
			// 
			this.nup_red.Location = new System.Drawing.Point(75, 130);
			this.nup_red.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
			this.nup_red.Name = "nup_red";
			this.nup_red.Size = new System.Drawing.Size(52, 20);
			this.nup_red.TabIndex = 7;
			// 
			// nup_green
			// 
			this.nup_green.Location = new System.Drawing.Point(75, 156);
			this.nup_green.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
			this.nup_green.Name = "nup_green";
			this.nup_green.Size = new System.Drawing.Size(52, 20);
			this.nup_green.TabIndex = 7;
			// 
			// nup_blue
			// 
			this.nup_blue.Location = new System.Drawing.Point(75, 182);
			this.nup_blue.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
			this.nup_blue.Name = "nup_blue";
			this.nup_blue.Size = new System.Drawing.Size(52, 20);
			this.nup_blue.TabIndex = 7;
			// 
			// nup_bright
			// 
			this.nup_bright.Location = new System.Drawing.Point(75, 208);
			this.nup_bright.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
			this.nup_bright.Name = "nup_bright";
			this.nup_bright.Size = new System.Drawing.Size(52, 20);
			this.nup_bright.TabIndex = 7;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(0, 80);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(29, 13);
			this.label1.TabIndex = 8;
			this.label1.Text = "Start";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(0, 106);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(20, 13);
			this.label2.TabIndex = 8;
			this.label2.Text = "To";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(0, 132);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(27, 13);
			this.label3.TabIndex = 8;
			this.label3.Text = "Red";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(-1, 158);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(36, 13);
			this.label4.TabIndex = 8;
			this.label4.Text = "Green";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(-1, 184);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(28, 13);
			this.label5.TabIndex = 8;
			this.label5.Text = "Blue";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(-2, 210);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(56, 13);
			this.label6.TabIndex = 8;
			this.label6.Text = "Brightness";
			// 
			// btn_apply
			// 
			this.btn_apply.Location = new System.Drawing.Point(1, 234);
			this.btn_apply.Name = "btn_apply";
			this.btn_apply.Size = new System.Drawing.Size(126, 23);
			this.btn_apply.TabIndex = 9;
			this.btn_apply.Text = "Apply";
			this.btn_apply.UseVisualStyleBackColor = true;
			this.btn_apply.Click += new System.EventHandler(this.btn_apply_Click);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(1, 263);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(126, 23);
			this.button3.TabIndex = 10;
			this.button3.Text = "Select Color";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// tabs
			// 
			this.tabs.Controls.Add(this.traintraffic);
			this.tabs.Controls.Add(this.messages);
			this.tabs.Controls.Add(this.ledcontrol);
			this.tabs.Location = new System.Drawing.Point(12, 12);
			this.tabs.Name = "tabs";
			this.tabs.SelectedIndex = 0;
			this.tabs.Size = new System.Drawing.Size(1008, 399);
			this.tabs.TabIndex = 11;
			// 
			// traintraffic
			// 
			this.traintraffic.Controls.Add(this.btSet2);
			this.traintraffic.Controls.Add(this.btSet1);
			this.traintraffic.Controls.Add(this.btClear);
			this.traintraffic.Controls.Add(this.tb6);
			this.traintraffic.Controls.Add(this.tb5);
			this.traintraffic.Controls.Add(this.tb4);
			this.traintraffic.Controls.Add(this.tb3);
			this.traintraffic.Controls.Add(this.tb2);
			this.traintraffic.Controls.Add(this.tb1);
			this.traintraffic.Controls.Add(this.pictureBox6);
			this.traintraffic.Controls.Add(this.pictureBox5);
			this.traintraffic.Controls.Add(this.pictureBox4);
			this.traintraffic.Controls.Add(this.pictureBox3);
			this.traintraffic.Controls.Add(this.pictureBox2);
			this.traintraffic.Controls.Add(this.pictureBox1);
			this.traintraffic.Location = new System.Drawing.Point(4, 22);
			this.traintraffic.Name = "traintraffic";
			this.traintraffic.Padding = new System.Windows.Forms.Padding(3);
			this.traintraffic.Size = new System.Drawing.Size(1000, 373);
			this.traintraffic.TabIndex = 1;
			this.traintraffic.Text = "Train Traffic";
			this.traintraffic.UseVisualStyleBackColor = true;
			// 
			// btSet2
			// 
			this.btSet2.Location = new System.Drawing.Point(87, 344);
			this.btSet2.Name = "btSet2";
			this.btSet2.Size = new System.Drawing.Size(75, 23);
			this.btSet2.TabIndex = 9;
			this.btSet2.Text = "Set 2";
			this.btSet2.UseVisualStyleBackColor = true;
			this.btSet2.Click += new System.EventHandler(this.btSet2_Click);
			// 
			// btSet1
			// 
			this.btSet1.Location = new System.Drawing.Point(6, 344);
			this.btSet1.Name = "btSet1";
			this.btSet1.Size = new System.Drawing.Size(75, 23);
			this.btSet1.TabIndex = 8;
			this.btSet1.Text = "Set 1";
			this.btSet1.UseVisualStyleBackColor = true;
			this.btSet1.Click += new System.EventHandler(this.btSet1_Click);
			// 
			// btClear
			// 
			this.btClear.Location = new System.Drawing.Point(919, 344);
			this.btClear.Name = "btClear";
			this.btClear.Size = new System.Drawing.Size(75, 23);
			this.btClear.TabIndex = 7;
			this.btClear.Text = "Clear";
			this.btClear.UseVisualStyleBackColor = true;
			this.btClear.Click += new System.EventHandler(this.btClear_Click);
			// 
			// tb6
			// 
			this.tb6.Location = new System.Drawing.Point(836, 49);
			this.tb6.Maximum = 2;
			this.tb6.Name = "tb6";
			this.tb6.Size = new System.Drawing.Size(160, 45);
			this.tb6.TabIndex = 6;
			// 
			// tb5
			// 
			this.tb5.Location = new System.Drawing.Point(670, 49);
			this.tb5.Maximum = 2;
			this.tb5.Name = "tb5";
			this.tb5.Size = new System.Drawing.Size(160, 45);
			this.tb5.TabIndex = 6;
			// 
			// tb4
			// 
			this.tb4.Location = new System.Drawing.Point(504, 49);
			this.tb4.Maximum = 2;
			this.tb4.Name = "tb4";
			this.tb4.Size = new System.Drawing.Size(160, 45);
			this.tb4.TabIndex = 6;
			// 
			// tb3
			// 
			this.tb3.Location = new System.Drawing.Point(338, 49);
			this.tb3.Maximum = 2;
			this.tb3.Name = "tb3";
			this.tb3.Size = new System.Drawing.Size(160, 45);
			this.tb3.TabIndex = 6;
			// 
			// tb2
			// 
			this.tb2.Location = new System.Drawing.Point(172, 49);
			this.tb2.Maximum = 2;
			this.tb2.Name = "tb2";
			this.tb2.Size = new System.Drawing.Size(160, 45);
			this.tb2.TabIndex = 6;
			// 
			// tb1
			// 
			this.tb1.Location = new System.Drawing.Point(6, 49);
			this.tb1.Maximum = 2;
			this.tb1.Name = "tb1";
			this.tb1.Size = new System.Drawing.Size(160, 45);
			this.tb1.TabIndex = 6;
			// 
			// pictureBox6
			// 
			this.pictureBox6.Image = global::Communication.Properties.Resources.trein_links;
			this.pictureBox6.Location = new System.Drawing.Point(6, 6);
			this.pictureBox6.Name = "pictureBox6";
			this.pictureBox6.Size = new System.Drawing.Size(160, 37);
			this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox6.TabIndex = 5;
			this.pictureBox6.TabStop = false;
			// 
			// pictureBox5
			// 
			this.pictureBox5.Image = global::Communication.Properties.Resources.trein_rechts;
			this.pictureBox5.Location = new System.Drawing.Point(836, 6);
			this.pictureBox5.Name = "pictureBox5";
			this.pictureBox5.Size = new System.Drawing.Size(160, 37);
			this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox5.TabIndex = 4;
			this.pictureBox5.TabStop = false;
			// 
			// pictureBox4
			// 
			this.pictureBox4.Image = global::Communication.Properties.Resources.trein_midden;
			this.pictureBox4.Location = new System.Drawing.Point(172, 6);
			this.pictureBox4.Name = "pictureBox4";
			this.pictureBox4.Size = new System.Drawing.Size(160, 37);
			this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox4.TabIndex = 3;
			this.pictureBox4.TabStop = false;
			// 
			// pictureBox3
			// 
			this.pictureBox3.Image = global::Communication.Properties.Resources.trein_midden;
			this.pictureBox3.Location = new System.Drawing.Point(670, 6);
			this.pictureBox3.Name = "pictureBox3";
			this.pictureBox3.Size = new System.Drawing.Size(160, 37);
			this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox3.TabIndex = 2;
			this.pictureBox3.TabStop = false;
			// 
			// pictureBox2
			// 
			this.pictureBox2.Image = global::Communication.Properties.Resources.trein_midden;
			this.pictureBox2.Location = new System.Drawing.Point(504, 6);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new System.Drawing.Size(160, 37);
			this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox2.TabIndex = 1;
			this.pictureBox2.TabStop = false;
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = global::Communication.Properties.Resources.trein_midden;
			this.pictureBox1.Location = new System.Drawing.Point(338, 6);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(160, 37);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			// 
			// messages
			// 
			this.messages.Controls.Add(this.listBox1);
			this.messages.Controls.Add(this.panel1);
			this.messages.Location = new System.Drawing.Point(4, 22);
			this.messages.Name = "messages";
			this.messages.Padding = new System.Windows.Forms.Padding(3);
			this.messages.Size = new System.Drawing.Size(1000, 373);
			this.messages.TabIndex = 0;
			this.messages.Text = "Messages";
			this.messages.UseVisualStyleBackColor = true;
			// 
			// ledcontrol
			// 
			this.ledcontrol.Controls.Add(this.cbCom);
			this.ledcontrol.Controls.Add(this.label8);
			this.ledcontrol.Controls.Add(this.label7);
			this.ledcontrol.Controls.Add(this.maxLedsNUP);
			this.ledcontrol.Controls.Add(this.connectbutton);
			this.ledcontrol.Controls.Add(this.button3);
			this.ledcontrol.Controls.Add(this.nup_start);
			this.ledcontrol.Controls.Add(this.btn_apply);
			this.ledcontrol.Controls.Add(this.nup_to);
			this.ledcontrol.Controls.Add(this.label6);
			this.ledcontrol.Controls.Add(this.nup_red);
			this.ledcontrol.Controls.Add(this.label5);
			this.ledcontrol.Controls.Add(this.nup_green);
			this.ledcontrol.Controls.Add(this.label4);
			this.ledcontrol.Controls.Add(this.nup_blue);
			this.ledcontrol.Controls.Add(this.label3);
			this.ledcontrol.Controls.Add(this.nup_bright);
			this.ledcontrol.Controls.Add(this.label2);
			this.ledcontrol.Controls.Add(this.label1);
			this.ledcontrol.Location = new System.Drawing.Point(4, 22);
			this.ledcontrol.Name = "ledcontrol";
			this.ledcontrol.Size = new System.Drawing.Size(1000, 373);
			this.ledcontrol.TabIndex = 2;
			this.ledcontrol.Text = "Led Control";
			this.ledcontrol.UseVisualStyleBackColor = true;
			// 
			// cbCom
			// 
			this.cbCom.FormattingEnabled = true;
			this.cbCom.Location = new System.Drawing.Point(74, 18);
			this.cbCom.Name = "cbCom";
			this.cbCom.Size = new System.Drawing.Size(53, 21);
			this.cbCom.TabIndex = 14;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(-1, 45);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(53, 13);
			this.label8.TabIndex = 13;
			this.label8.Text = "Max Leds";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(-1, 21);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(64, 13);
			this.label7.TabIndex = 13;
			this.label7.Text = "COM PORT";
			// 
			// maxLedsNUP
			// 
			this.maxLedsNUP.Location = new System.Drawing.Point(74, 43);
			this.maxLedsNUP.Name = "maxLedsNUP";
			this.maxLedsNUP.Size = new System.Drawing.Size(53, 20);
			this.maxLedsNUP.TabIndex = 11;
			this.maxLedsNUP.Value = new decimal(new int[] {
            45,
            0,
            0,
            0});
			// 
			// connectbutton
			// 
			this.connectbutton.Location = new System.Drawing.Point(133, 17);
			this.connectbutton.Name = "connectbutton";
			this.connectbutton.Size = new System.Drawing.Size(65, 46);
			this.connectbutton.TabIndex = 12;
			this.connectbutton.Text = "Connect";
			this.connectbutton.UseVisualStyleBackColor = true;
			this.connectbutton.Click += new System.EventHandler(this.connectbutton_Click);
			// 
			// TrainDrukteForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1028, 423);
			this.Controls.Add(this.tabs);
			this.Name = "TrainDrukteForm";
			this.Text = "Form1";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
			((System.ComponentModel.ISupportInitialize)(this.nup_start)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nup_to)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nup_red)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nup_green)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nup_blue)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nup_bright)).EndInit();
			this.tabs.ResumeLayout(false);
			this.traintraffic.ResumeLayout(false);
			this.traintraffic.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.tb6)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tb5)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tb4)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tb3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tb2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.tb1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.messages.ResumeLayout(false);
			this.ledcontrol.ResumeLayout(false);
			this.ledcontrol.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.maxLedsNUP)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.NumericUpDown nup_start;
        private System.Windows.Forms.NumericUpDown nup_to;
        private System.Windows.Forms.NumericUpDown nup_red;
        private System.Windows.Forms.NumericUpDown nup_green;
        private System.Windows.Forms.NumericUpDown nup_blue;
        private System.Windows.Forms.NumericUpDown nup_bright;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btn_apply;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TabControl tabs;
        private System.Windows.Forms.TabPage messages;
        private System.Windows.Forms.TabPage traintraffic;
        private System.Windows.Forms.TabPage ledcontrol;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button connectbutton;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TrackBar tb6;
        private System.Windows.Forms.TrackBar tb5;
        private System.Windows.Forms.TrackBar tb4;
        private System.Windows.Forms.TrackBar tb3;
        private System.Windows.Forms.TrackBar tb2;
        private System.Windows.Forms.TrackBar tb1;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btSet2;
        private System.Windows.Forms.Button btSet1;
        private System.Windows.Forms.Button btClear;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.NumericUpDown maxLedsNUP;
        private System.Windows.Forms.ComboBox cbCom;
    }
}