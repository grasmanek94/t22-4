namespace Launcher
{
    partial class Form1
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
            this.server = new System.Windows.Forms.Button();
            this.serverbind = new System.Windows.Forms.Button();
            this.station = new System.Windows.Forms.Button();
            this.stationip = new System.Windows.Forms.Button();
            this.cmd = new System.Windows.Forms.Button();
            this.update = new System.Windows.Forms.Button();
            this.editupdate = new System.Windows.Forms.Button();
            this.shutdown = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // server
            // 
            this.server.Location = new System.Drawing.Point(12, 12);
            this.server.Name = "server";
            this.server.Size = new System.Drawing.Size(75, 23);
            this.server.TabIndex = 0;
            this.server.Text = "Server";
            this.server.UseVisualStyleBackColor = true;
            this.server.Click += new System.EventHandler(this.server_Click);
            // 
            // serverbind
            // 
            this.serverbind.Location = new System.Drawing.Point(12, 41);
            this.serverbind.Name = "serverbind";
            this.serverbind.Size = new System.Drawing.Size(75, 23);
            this.serverbind.TabIndex = 1;
            this.serverbind.Text = "Edit BIND";
            this.serverbind.UseVisualStyleBackColor = true;
            this.serverbind.Click += new System.EventHandler(this.serverbind_Click);
            // 
            // station
            // 
            this.station.Location = new System.Drawing.Point(93, 12);
            this.station.Name = "station";
            this.station.Size = new System.Drawing.Size(75, 23);
            this.station.TabIndex = 2;
            this.station.Text = "Station";
            this.station.UseVisualStyleBackColor = true;
            this.station.Click += new System.EventHandler(this.station_Click);
            // 
            // stationip
            // 
            this.stationip.Location = new System.Drawing.Point(93, 41);
            this.stationip.Name = "stationip";
            this.stationip.Size = new System.Drawing.Size(75, 23);
            this.stationip.TabIndex = 3;
            this.stationip.Text = "Edit IP";
            this.stationip.UseVisualStyleBackColor = true;
            this.stationip.Click += new System.EventHandler(this.stationip_Click);
            // 
            // cmd
            // 
            this.cmd.Location = new System.Drawing.Point(12, 70);
            this.cmd.Name = "cmd";
            this.cmd.Size = new System.Drawing.Size(156, 23);
            this.cmd.TabIndex = 4;
            this.cmd.Text = "Command Prompt";
            this.cmd.UseVisualStyleBackColor = true;
            this.cmd.Click += new System.EventHandler(this.cmd_Click);
            // 
            // update
            // 
            this.update.Location = new System.Drawing.Point(174, 12);
            this.update.Name = "update";
            this.update.Size = new System.Drawing.Size(75, 23);
            this.update.TabIndex = 5;
            this.update.Text = "Update";
            this.update.UseVisualStyleBackColor = true;
            this.update.Click += new System.EventHandler(this.update_Click);
            // 
            // editupdate
            // 
            this.editupdate.Location = new System.Drawing.Point(174, 41);
            this.editupdate.Name = "editupdate";
            this.editupdate.Size = new System.Drawing.Size(75, 23);
            this.editupdate.TabIndex = 6;
            this.editupdate.Text = "Edit Update";
            this.editupdate.UseVisualStyleBackColor = true;
            this.editupdate.Click += new System.EventHandler(this.editupdate_Click);
            // 
            // shutdown
            // 
            this.shutdown.Location = new System.Drawing.Point(174, 70);
            this.shutdown.Name = "shutdown";
            this.shutdown.Size = new System.Drawing.Size(75, 23);
            this.shutdown.TabIndex = 7;
            this.shutdown.Text = "Shutdown";
            this.shutdown.UseVisualStyleBackColor = true;
            this.shutdown.Click += new System.EventHandler(this.shutdown_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(262, 103);
            this.ControlBox = false;
            this.Controls.Add(this.shutdown);
            this.Controls.Add(this.editupdate);
            this.Controls.Add(this.update);
            this.Controls.Add(this.cmd);
            this.Controls.Add(this.stationip);
            this.Controls.Add(this.station);
            this.Controls.Add(this.serverbind);
            this.Controls.Add(this.server);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "System Manager";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button server;
        private System.Windows.Forms.Button serverbind;
        private System.Windows.Forms.Button station;
        private System.Windows.Forms.Button stationip;
        private System.Windows.Forms.Button cmd;
        private System.Windows.Forms.Button update;
        private System.Windows.Forms.Button editupdate;
        private System.Windows.Forms.Button shutdown;
    }
}

