using System;

namespace ITTF_Server
{
    partial class AdministrationForm
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
            this.lstBoxStations = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmboBoxWagons = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAddWagonToTrain = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmboBoxRoutes = new System.Windows.Forms.ComboBox();
            this.btnRemoveRouteNr = new System.Windows.Forms.Button();
            this.btnAddRoute = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lstViewTrains = new System.Windows.Forms.ListView();
            this.clmnHeaderLstViewTrainsTrain = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmnHeaderLstViewTrainsWagon = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmnHeaderLstViewTrainsTotalSeats = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmnHeaderLstViewTrainsTotalStandingSpots = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmnHeaderLstViewTrainsRoute = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lstViewWagons = new System.Windows.Forms.ListView();
            this.clmnHeaderLstViewWagonWagon = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmnHeaderLstViewWagonSeats = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmnHeaderLstViewWagonStandingspots = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtBoxStandingSpots = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBoxSeats = new System.Windows.Forms.TextBox();
            this.lblSeats = new System.Windows.Forms.Label();
            this.lblWagonNumber = new System.Windows.Forms.Label();
            this.txtBoxWagonNumber = new System.Windows.Forms.TextBox();
            this.btnRemoveWagons = new System.Windows.Forms.Button();
            this.btnAddWagons = new System.Windows.Forms.Button();
            this.cmboBoxStations = new System.Windows.Forms.ComboBox();
            this.lstViewRoutes = new System.Windows.Forms.ListView();
            this.clmnHeaderRouteNr = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.clmnHeaderStations = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnRemoveRoute = new System.Windows.Forms.Button();
            this.txtBoxRouteNr = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnAddStationToRoute = new System.Windows.Forms.Button();
            this.stationHandlerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tabControlStations = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.lblConnectedStations = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.btnAddToRoute = new System.Windows.Forms.Button();
            this.stationBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.iTrafficMessageBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stationHandlerBindingSource)).BeginInit();
            this.tabControlStations.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stationBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iTrafficMessageBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // lstBoxStations
            // 
            this.lstBoxStations.FormattingEnabled = true;
            this.lstBoxStations.Location = new System.Drawing.Point(5, 27);
            this.lstBoxStations.Margin = new System.Windows.Forms.Padding(2);
            this.lstBoxStations.Name = "lstBoxStations";
            this.lstBoxStations.Size = new System.Drawing.Size(744, 316);
            this.lstBoxStations.TabIndex = 20;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmboBoxWagons);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnAddWagonToTrain);
            this.groupBox1.Controls.Add(this.btnRemove);
            this.groupBox1.Location = new System.Drawing.Point(7, 10);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(158, 70);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add wagon to selected train";
            // 
            // cmboBoxWagons
            // 
            this.cmboBoxWagons.FormattingEnabled = true;
            this.cmboBoxWagons.Location = new System.Drawing.Point(91, 18);
            this.cmboBoxWagons.Name = "cmboBoxWagons";
            this.cmboBoxWagons.Size = new System.Drawing.Size(58, 21);
            this.cmboBoxWagons.TabIndex = 22;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Wagon number";
            // 
            // btnAddWagonToTrain
            // 
            this.btnAddWagonToTrain.Location = new System.Drawing.Point(27, 42);
            this.btnAddWagonToTrain.Name = "btnAddWagonToTrain";
            this.btnAddWagonToTrain.Size = new System.Drawing.Size(58, 23);
            this.btnAddWagonToTrain.TabIndex = 10;
            this.btnAddWagonToTrain.Text = "Add";
            this.btnAddWagonToTrain.UseVisualStyleBackColor = true;
            this.btnAddWagonToTrain.Click += new System.EventHandler(this.btnAddWagonToTrain_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(91, 42);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(58, 23);
            this.btnRemove.TabIndex = 21;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cmboBoxRoutes);
            this.groupBox2.Controls.Add(this.btnRemoveRouteNr);
            this.groupBox2.Controls.Add(this.btnAddRoute);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(169, 10);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(579, 70);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Set route to selected train";
            // 
            // cmboBoxRoutes
            // 
            this.cmboBoxRoutes.FormattingEnabled = true;
            this.cmboBoxRoutes.Location = new System.Drawing.Point(47, 15);
            this.cmboBoxRoutes.Name = "cmboBoxRoutes";
            this.cmboBoxRoutes.Size = new System.Drawing.Size(527, 21);
            this.cmboBoxRoutes.TabIndex = 22;
            // 
            // btnRemoveRouteNr
            // 
            this.btnRemoveRouteNr.Location = new System.Drawing.Point(498, 42);
            this.btnRemoveRouteNr.Name = "btnRemoveRouteNr";
            this.btnRemoveRouteNr.Size = new System.Drawing.Size(76, 23);
            this.btnRemoveRouteNr.TabIndex = 23;
            this.btnRemoveRouteNr.Text = "Remove";
            this.btnRemoveRouteNr.UseVisualStyleBackColor = true;
            this.btnRemoveRouteNr.Click += new System.EventHandler(this.btnRemoveRouteNr_Click);
            // 
            // btnAddRoute
            // 
            this.btnAddRoute.Location = new System.Drawing.Point(427, 42);
            this.btnAddRoute.Name = "btnAddRoute";
            this.btnAddRoute.Size = new System.Drawing.Size(65, 23);
            this.btnAddRoute.TabIndex = 22;
            this.btnAddRoute.Text = "Set";
            this.btnAddRoute.UseVisualStyleBackColor = true;
            this.btnAddRoute.Click += new System.EventHandler(this.btnAddRoute_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Route";
            // 
            // lstViewTrains
            // 
            this.lstViewTrains.AllowColumnReorder = true;
            this.lstViewTrains.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmnHeaderLstViewTrainsTrain,
            this.clmnHeaderLstViewTrainsWagon,
            this.clmnHeaderLstViewTrainsTotalSeats,
            this.clmnHeaderLstViewTrainsTotalStandingSpots,
            this.clmnHeaderLstViewTrainsRoute});
            this.lstViewTrains.FullRowSelect = true;
            this.lstViewTrains.GridLines = true;
            this.lstViewTrains.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lstViewTrains.Location = new System.Drawing.Point(6, 85);
            this.lstViewTrains.Name = "lstViewTrains";
            this.lstViewTrains.Size = new System.Drawing.Size(742, 261);
            this.lstViewTrains.TabIndex = 10;
            this.lstViewTrains.UseCompatibleStateImageBehavior = false;
            this.lstViewTrains.View = System.Windows.Forms.View.Details;
            // 
            // clmnHeaderLstViewTrainsTrain
            // 
            this.clmnHeaderLstViewTrainsTrain.Text = "Train nr.";
            this.clmnHeaderLstViewTrainsTrain.Width = 53;
            // 
            // clmnHeaderLstViewTrainsWagon
            // 
            this.clmnHeaderLstViewTrainsWagon.Text = "Wagons";
            this.clmnHeaderLstViewTrainsWagon.Width = 367;
            // 
            // clmnHeaderLstViewTrainsTotalSeats
            // 
            this.clmnHeaderLstViewTrainsTotalSeats.Text = "Total Seats";
            this.clmnHeaderLstViewTrainsTotalSeats.Width = 86;
            // 
            // clmnHeaderLstViewTrainsTotalStandingSpots
            // 
            this.clmnHeaderLstViewTrainsTotalStandingSpots.Text = "Total Standing Spots";
            this.clmnHeaderLstViewTrainsTotalStandingSpots.Width = 124;
            // 
            // clmnHeaderLstViewTrainsRoute
            // 
            this.clmnHeaderLstViewTrainsRoute.Text = "Route";
            this.clmnHeaderLstViewTrainsRoute.Width = 80;
            // 
            // lstViewWagons
            // 
            this.lstViewWagons.AllowColumnReorder = true;
            this.lstViewWagons.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmnHeaderLstViewWagonWagon,
            this.clmnHeaderLstViewWagonSeats,
            this.clmnHeaderLstViewWagonStandingspots});
            this.lstViewWagons.FullRowSelect = true;
            this.lstViewWagons.GridLines = true;
            this.lstViewWagons.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lstViewWagons.Location = new System.Drawing.Point(226, 6);
            this.lstViewWagons.Name = "lstViewWagons";
            this.lstViewWagons.Size = new System.Drawing.Size(522, 340);
            this.lstViewWagons.TabIndex = 0;
            this.lstViewWagons.UseCompatibleStateImageBehavior = false;
            this.lstViewWagons.View = System.Windows.Forms.View.Details;
            // 
            // clmnHeaderLstViewWagonWagon
            // 
            this.clmnHeaderLstViewWagonWagon.Text = "Wagon";
            this.clmnHeaderLstViewWagonWagon.Width = 64;
            // 
            // clmnHeaderLstViewWagonSeats
            // 
            this.clmnHeaderLstViewWagonSeats.Text = "Seats";
            this.clmnHeaderLstViewWagonSeats.Width = 66;
            // 
            // clmnHeaderLstViewWagonStandingspots
            // 
            this.clmnHeaderLstViewWagonStandingspots.Text = "Standing spots";
            this.clmnHeaderLstViewWagonStandingspots.Width = 83;
            // 
            // txtBoxStandingSpots
            // 
            this.txtBoxStandingSpots.Location = new System.Drawing.Point(145, 53);
            this.txtBoxStandingSpots.Name = "txtBoxStandingSpots";
            this.txtBoxStandingSpots.Size = new System.Drawing.Size(58, 20);
            this.txtBoxStandingSpots.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = " Number of standing spots";
            // 
            // txtBoxSeats
            // 
            this.txtBoxSeats.Location = new System.Drawing.Point(145, 31);
            this.txtBoxSeats.Name = "txtBoxSeats";
            this.txtBoxSeats.Size = new System.Drawing.Size(58, 20);
            this.txtBoxSeats.TabIndex = 7;
            // 
            // lblSeats
            // 
            this.lblSeats.AutoSize = true;
            this.lblSeats.Location = new System.Drawing.Point(3, 34);
            this.lblSeats.Name = "lblSeats";
            this.lblSeats.Size = new System.Drawing.Size(87, 13);
            this.lblSeats.TabIndex = 6;
            this.lblSeats.Text = " Number of seats";
            // 
            // lblWagonNumber
            // 
            this.lblWagonNumber.AutoSize = true;
            this.lblWagonNumber.Location = new System.Drawing.Point(6, 12);
            this.lblWagonNumber.Name = "lblWagonNumber";
            this.lblWagonNumber.Size = new System.Drawing.Size(80, 13);
            this.lblWagonNumber.TabIndex = 5;
            this.lblWagonNumber.Text = "Wagon number";
            // 
            // txtBoxWagonNumber
            // 
            this.txtBoxWagonNumber.Location = new System.Drawing.Point(145, 9);
            this.txtBoxWagonNumber.Name = "txtBoxWagonNumber";
            this.txtBoxWagonNumber.Size = new System.Drawing.Size(58, 20);
            this.txtBoxWagonNumber.TabIndex = 4;
            // 
            // btnRemoveWagons
            // 
            this.btnRemoveWagons.Location = new System.Drawing.Point(70, 79);
            this.btnRemoveWagons.Name = "btnRemoveWagons";
            this.btnRemoveWagons.Size = new System.Drawing.Size(133, 23);
            this.btnRemoveWagons.TabIndex = 4;
            this.btnRemoveWagons.Text = "Remove selected wagon";
            this.btnRemoveWagons.UseVisualStyleBackColor = true;
            this.btnRemoveWagons.Click += new System.EventHandler(this.btnRemoveWagons_Click);
            // 
            // btnAddWagons
            // 
            this.btnAddWagons.Location = new System.Drawing.Point(6, 79);
            this.btnAddWagons.Name = "btnAddWagons";
            this.btnAddWagons.Size = new System.Drawing.Size(58, 23);
            this.btnAddWagons.TabIndex = 4;
            this.btnAddWagons.Text = "Add";
            this.btnAddWagons.UseVisualStyleBackColor = true;
            this.btnAddWagons.Click += new System.EventHandler(this.btnAddWagons_Click);
            // 
            // cmboBoxStations
            // 
            this.cmboBoxStations.DisplayMember = "Method";
            this.cmboBoxStations.FormattingEnabled = true;
            this.cmboBoxStations.Location = new System.Drawing.Point(370, 15);
            this.cmboBoxStations.Name = "cmboBoxStations";
            this.cmboBoxStations.Size = new System.Drawing.Size(233, 21);
            this.cmboBoxStations.TabIndex = 21;
            this.cmboBoxStations.ValueMember = "Method";
            // 
            // lstViewRoutes
            // 
            this.lstViewRoutes.AllowColumnReorder = true;
            this.lstViewRoutes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmnHeaderRouteNr,
            this.clmnHeaderStations});
            this.lstViewRoutes.FullRowSelect = true;
            this.lstViewRoutes.GridLines = true;
            this.lstViewRoutes.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lstViewRoutes.Location = new System.Drawing.Point(6, 41);
            this.lstViewRoutes.Name = "lstViewRoutes";
            this.lstViewRoutes.Size = new System.Drawing.Size(742, 305);
            this.lstViewRoutes.TabIndex = 20;
            this.lstViewRoutes.UseCompatibleStateImageBehavior = false;
            this.lstViewRoutes.View = System.Windows.Forms.View.Details;
            // 
            // clmnHeaderRouteNr
            // 
            this.clmnHeaderRouteNr.Text = "Route nr.";
            this.clmnHeaderRouteNr.Width = 68;
            // 
            // clmnHeaderStations
            // 
            this.clmnHeaderStations.Text = "Stations";
            this.clmnHeaderStations.Width = 1000;
            // 
            // btnRemoveRoute
            // 
            this.btnRemoveRoute.Location = new System.Drawing.Point(217, 13);
            this.btnRemoveRoute.Name = "btnRemoveRoute";
            this.btnRemoveRoute.Size = new System.Drawing.Size(58, 23);
            this.btnRemoveRoute.TabIndex = 10;
            this.btnRemoveRoute.Text = "Remove station";
            this.btnRemoveRoute.UseVisualStyleBackColor = true;
            this.btnRemoveRoute.Click += new System.EventHandler(this.btnRemoveRoute_Click);
            // 
            // txtBoxRouteNr
            // 
            this.txtBoxRouteNr.Location = new System.Drawing.Point(89, 15);
            this.txtBoxRouteNr.Name = "txtBoxRouteNr";
            this.txtBoxRouteNr.Size = new System.Drawing.Size(58, 20);
            this.txtBoxRouteNr.TabIndex = 18;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Route number";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(293, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Select station";
            // 
            // btnAddStationToRoute
            // 
            this.btnAddStationToRoute.Location = new System.Drawing.Point(153, 13);
            this.btnAddStationToRoute.Name = "btnAddStationToRoute";
            this.btnAddStationToRoute.Size = new System.Drawing.Size(58, 23);
            this.btnAddStationToRoute.TabIndex = 16;
            this.btnAddStationToRoute.Text = "Add";
            this.btnAddStationToRoute.UseVisualStyleBackColor = true;
            this.btnAddStationToRoute.Click += new System.EventHandler(this.btnAddStationToRoute_Click);
            // 
            // tabControlStations
            // 
            this.tabControlStations.Controls.Add(this.tabPage1);
            this.tabControlStations.Controls.Add(this.tabPage2);
            this.tabControlStations.Controls.Add(this.tabPage3);
            this.tabControlStations.Controls.Add(this.tabPage4);
            this.tabControlStations.Location = new System.Drawing.Point(4, 3);
            this.tabControlStations.Name = "tabControlStations";
            this.tabControlStations.SelectedIndex = 0;
            this.tabControlStations.Size = new System.Drawing.Size(770, 376);
            this.tabControlStations.TabIndex = 20;
            this.tabControlStations.Tag = "";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lstViewTrains);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(762, 350);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Trains";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lstViewWagons);
            this.tabPage2.Controls.Add(this.txtBoxStandingSpots);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.btnAddWagons);
            this.tabPage2.Controls.Add(this.txtBoxSeats);
            this.tabPage2.Controls.Add(this.btnRemoveWagons);
            this.tabPage2.Controls.Add(this.lblSeats);
            this.tabPage2.Controls.Add(this.txtBoxWagonNumber);
            this.tabPage2.Controls.Add(this.lblWagonNumber);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(762, 350);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Wagons";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.lblConnectedStations);
            this.tabPage3.Controls.Add(this.lstBoxStations);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(762, 350);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Stations";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // lblConnectedStations
            // 
            this.lblConnectedStations.AutoSize = true;
            this.lblConnectedStations.Location = new System.Drawing.Point(7, 7);
            this.lblConnectedStations.Name = "lblConnectedStations";
            this.lblConnectedStations.Size = new System.Drawing.Size(181, 13);
            this.lblConnectedStations.TabIndex = 21;
            this.lblConnectedStations.Text = "The connected stations to the server";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.btnAddToRoute);
            this.tabPage4.Controls.Add(this.cmboBoxStations);
            this.tabPage4.Controls.Add(this.lstViewRoutes);
            this.tabPage4.Controls.Add(this.label6);
            this.tabPage4.Controls.Add(this.btnAddStationToRoute);
            this.tabPage4.Controls.Add(this.btnRemoveRoute);
            this.tabPage4.Controls.Add(this.label7);
            this.tabPage4.Controls.Add(this.txtBoxRouteNr);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(762, 350);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Routes";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // btnAddToRoute
            // 
            this.btnAddToRoute.Location = new System.Drawing.Point(609, 15);
            this.btnAddToRoute.Name = "btnAddToRoute";
            this.btnAddToRoute.Size = new System.Drawing.Size(139, 23);
            this.btnAddToRoute.TabIndex = 22;
            this.btnAddToRoute.Text = "Add to selected route";
            this.btnAddToRoute.UseVisualStyleBackColor = true;
            this.btnAddToRoute.Click += new System.EventHandler(this.btnAddToRoute_Click_1);
            // 
            // AdministrationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(777, 380);
            this.Controls.Add(this.tabControlStations);
            this.Name = "AdministrationForm";
            this.Text = "Administration ITTF";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stationHandlerBindingSource)).EndInit();
            this.tabControlStations.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stationBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iTrafficMessageBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnRemoveWagons;
        private System.Windows.Forms.Button btnAddWagons;
        private System.Windows.Forms.TextBox txtBoxWagonNumber;
        private System.Windows.Forms.Label lblSeats;
        private System.Windows.Forms.Label lblWagonNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBoxSeats;
        private System.Windows.Forms.TextBox txtBoxStandingSpots;
        private System.Windows.Forms.ListView lstViewWagons;
        private System.Windows.Forms.ColumnHeader clmnHeaderLstViewWagonWagon;
        private System.Windows.Forms.ColumnHeader clmnHeaderLstViewWagonSeats;
        private System.Windows.Forms.ColumnHeader clmnHeaderLstViewWagonStandingspots;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAddWagonToTrain;
        private System.Windows.Forms.ListView lstViewTrains;
        private System.Windows.Forms.ColumnHeader clmnHeaderLstViewTrainsTrain;
        private System.Windows.Forms.ColumnHeader clmnHeaderLstViewTrainsWagon;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ColumnHeader clmnHeaderLstViewTrainsTotalSeats;
        private System.Windows.Forms.ColumnHeader clmnHeaderLstViewTrainsTotalStandingSpots;
        private System.Windows.Forms.TextBox txtBoxRouteNr;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnAddStationToRoute;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnRemoveRoute;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.ListBox lstBoxStations;
        private System.Windows.Forms.ListView lstViewRoutes;
        private System.Windows.Forms.ColumnHeader clmnHeaderRouteNr;
        private System.Windows.Forms.ColumnHeader clmnHeaderStations;
        private System.Windows.Forms.ColumnHeader clmnHeaderLstViewTrainsRoute;
        private System.Windows.Forms.Button btnRemoveRouteNr;
        private System.Windows.Forms.Button btnAddRoute;
        private System.Windows.Forms.ComboBox cmboBoxStations;
        private System.Windows.Forms.BindingSource stationBindingSource;
        private System.Windows.Forms.BindingSource iTrafficMessageBindingSource;
        private System.Windows.Forms.BindingSource stationHandlerBindingSource;
        private System.Windows.Forms.TabControl tabControlStations;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Button btnAddToRoute;
        private System.Windows.Forms.ComboBox cmboBoxRoutes;
        private System.Windows.Forms.ComboBox cmboBoxWagons;
        private System.Windows.Forms.Label lblConnectedStations;
    }
}