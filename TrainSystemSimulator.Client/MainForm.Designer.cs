namespace Bluestacks.Client
{
    partial class MainForm
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
            this.panelContainer = new System.Windows.Forms.Panel();
            this.tbcSettings = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.txbTimer = new System.Windows.Forms.TextBox();
            this.lblTimer = new System.Windows.Forms.Label();
            this.btnSaveSetting = new System.Windows.Forms.Button();
            this.lblNoOfStations = new System.Windows.Forms.Label();
            this.txbNoOfTrains = new System.Windows.Forms.TextBox();
            this.tbcSimulator = new System.Windows.Forms.TabPage();
            this.tbcSetting = new System.Windows.Forms.TabControl();
            this.txbNoOfStations = new System.Windows.Forms.TextBox();
            this.tloBaseSimulator = new System.Windows.Forms.TableLayoutPanel();
            this.tloTopLevelSimulator = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tvwStations = new System.Windows.Forms.TreeView();
            this.tvwTrains = new System.Windows.Forms.TreeView();
            this.tvwTracks = new System.Windows.Forms.TreeView();
            this.btnStartSimulator = new System.Windows.Forms.Button();
            this.lblNoOfTrains = new System.Windows.Forms.Label();
            this.pnlShipmentCapacity = new System.Windows.Forms.Panel();
            this.panelContainer.SuspendLayout();
            this.tbcSettings.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tbcSimulator.SuspendLayout();
            this.tbcSetting.SuspendLayout();
            this.tloBaseSimulator.SuspendLayout();
            this.tloTopLevelSimulator.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelContainer
            // 
            this.panelContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelContainer.Controls.Add(this.tbcSetting);
            this.panelContainer.Location = new System.Drawing.Point(2, 2);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(1083, 569);
            this.panelContainer.TabIndex = 0;
            // 
            // tbcSettings
            // 
            this.tbcSettings.Controls.Add(this.panel1);
            this.tbcSettings.Location = new System.Drawing.Point(4, 22);
            this.tbcSettings.Name = "tbcSettings";
            this.tbcSettings.Padding = new System.Windows.Forms.Padding(10);
            this.tbcSettings.Size = new System.Drawing.Size(1075, 543);
            this.tbcSettings.TabIndex = 1;
            this.tbcSettings.Text = "Setting";
            this.tbcSettings.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Location = new System.Drawing.Point(5, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1066, 537);
            this.panel1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 7;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 1F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 1F));
            this.tableLayoutPanel1.Controls.Add(this.lblNoOfStations, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblTimer, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.txbTimer, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.pnlShipmentCapacity, 2, 7);
            this.tableLayoutPanel1.Controls.Add(this.txbNoOfStations, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblNoOfTrains, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.txbNoOfTrains, 2, 5);
            this.tableLayoutPanel1.Controls.Add(this.label4, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.btnSaveSetting, 2, 9);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 11;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 1F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 2F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1060, 531);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 161);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(5);
            this.label4.Size = new System.Drawing.Size(190, 23);
            this.label4.TabIndex = 11;
            this.label4.Text = "Shipment capacity of indivisual trains";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txbTimer
            // 
            this.txbTimer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txbTimer.Location = new System.Drawing.Point(225, 92);
            this.txbTimer.Name = "txbTimer";
            this.txbTimer.Size = new System.Drawing.Size(259, 20);
            this.txbTimer.TabIndex = 9;
            // 
            // lblTimer
            // 
            this.lblTimer.AutoSize = true;
            this.lblTimer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTimer.Location = new System.Drawing.Point(13, 89);
            this.lblTimer.Name = "lblTimer";
            this.lblTimer.Size = new System.Drawing.Size(206, 31);
            this.lblTimer.TabIndex = 8;
            this.lblTimer.Text = "Timer (in secs)";
            // 
            // btnSaveSetting
            // 
            this.btnSaveSetting.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveSetting.Location = new System.Drawing.Point(331, 489);
            this.btnSaveSetting.Name = "btnSaveSetting";
            this.btnSaveSetting.Size = new System.Drawing.Size(153, 23);
            this.btnSaveSetting.TabIndex = 7;
            this.btnSaveSetting.Text = "Save Settings";
            this.btnSaveSetting.UseVisualStyleBackColor = true;
            this.btnSaveSetting.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lblNoOfStations
            // 
            this.lblNoOfStations.AutoSize = true;
            this.lblNoOfStations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNoOfStations.Location = new System.Drawing.Point(13, 53);
            this.lblNoOfStations.Name = "lblNoOfStations";
            this.lblNoOfStations.Padding = new System.Windows.Forms.Padding(5);
            this.lblNoOfStations.Size = new System.Drawing.Size(206, 31);
            this.lblNoOfStations.TabIndex = 3;
            this.lblNoOfStations.Text = "Enter number of stations";
            // 
            // txbNoOfTrains
            // 
            this.txbNoOfTrains.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txbNoOfTrains.Location = new System.Drawing.Point(225, 128);
            this.txbNoOfTrains.Name = "txbNoOfTrains";
            this.txbNoOfTrains.Size = new System.Drawing.Size(259, 20);
            this.txbNoOfTrains.TabIndex = 6;
            this.txbNoOfTrains.TextChanged += new System.EventHandler(this.txbNoOfTrains_TextChanged);
            // 
            // tbcSimulator
            // 
            this.tbcSimulator.Controls.Add(this.tloBaseSimulator);
            this.tbcSimulator.Location = new System.Drawing.Point(4, 22);
            this.tbcSimulator.Margin = new System.Windows.Forms.Padding(10);
            this.tbcSimulator.Name = "tbcSimulator";
            this.tbcSimulator.Padding = new System.Windows.Forms.Padding(3);
            this.tbcSimulator.Size = new System.Drawing.Size(1075, 543);
            this.tbcSimulator.TabIndex = 0;
            this.tbcSimulator.Text = "Simulator";
            this.tbcSimulator.UseVisualStyleBackColor = true;
            // 
            // tbcSetting
            // 
            this.tbcSetting.Controls.Add(this.tbcSimulator);
            this.tbcSetting.Controls.Add(this.tbcSettings);
            this.tbcSetting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbcSetting.Location = new System.Drawing.Point(0, 0);
            this.tbcSetting.Margin = new System.Windows.Forms.Padding(0);
            this.tbcSetting.Name = "tbcSetting";
            this.tbcSetting.Padding = new System.Drawing.Point(0, 0);
            this.tbcSetting.SelectedIndex = 0;
            this.tbcSetting.Size = new System.Drawing.Size(1083, 569);
            this.tbcSetting.TabIndex = 0;
            // 
            // txbNoOfStations
            // 
            this.txbNoOfStations.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbNoOfStations.Location = new System.Drawing.Point(225, 56);
            this.txbNoOfStations.Name = "txbNoOfStations";
            this.txbNoOfStations.Size = new System.Drawing.Size(259, 20);
            this.txbNoOfStations.TabIndex = 12;
            // 
            // tloBaseSimulator
            // 
            this.tloBaseSimulator.ColumnCount = 1;
            this.tloBaseSimulator.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tloBaseSimulator.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tloBaseSimulator.Controls.Add(this.tloTopLevelSimulator, 0, 0);
            this.tloBaseSimulator.Controls.Add(this.btnStartSimulator, 0, 1);
            this.tloBaseSimulator.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tloBaseSimulator.Location = new System.Drawing.Point(3, 3);
            this.tloBaseSimulator.Name = "tloBaseSimulator";
            this.tloBaseSimulator.RowCount = 2;
            this.tloBaseSimulator.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 95F));
            this.tloBaseSimulator.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tloBaseSimulator.Size = new System.Drawing.Size(1069, 537);
            this.tloBaseSimulator.TabIndex = 1;
            // 
            // tloTopLevelSimulator
            // 
            this.tloTopLevelSimulator.ColumnCount = 3;
            this.tloTopLevelSimulator.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tloTopLevelSimulator.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tloTopLevelSimulator.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34F));
            this.tloTopLevelSimulator.Controls.Add(this.label1, 0, 0);
            this.tloTopLevelSimulator.Controls.Add(this.label2, 1, 0);
            this.tloTopLevelSimulator.Controls.Add(this.label3, 2, 0);
            this.tloTopLevelSimulator.Controls.Add(this.tvwStations, 0, 1);
            this.tloTopLevelSimulator.Controls.Add(this.tvwTrains, 1, 1);
            this.tloTopLevelSimulator.Controls.Add(this.tvwTracks, 2, 1);
            this.tloTopLevelSimulator.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tloTopLevelSimulator.Location = new System.Drawing.Point(3, 3);
            this.tloTopLevelSimulator.Name = "tloTopLevelSimulator";
            this.tloTopLevelSimulator.RowCount = 2;
            this.tloTopLevelSimulator.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tloTopLevelSimulator.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 95F));
            this.tloTopLevelSimulator.Size = new System.Drawing.Size(1063, 504);
            this.tloTopLevelSimulator.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(344, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Stations";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(353, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(344, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Trains";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(703, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(357, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tracks";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tvwStations
            // 
            this.tvwStations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvwStations.Location = new System.Drawing.Point(3, 28);
            this.tvwStations.Name = "tvwStations";
            this.tvwStations.Size = new System.Drawing.Size(344, 473);
            this.tvwStations.TabIndex = 3;
            // 
            // tvwTrains
            // 
            this.tvwTrains.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvwTrains.Location = new System.Drawing.Point(353, 28);
            this.tvwTrains.Name = "tvwTrains";
            this.tvwTrains.Size = new System.Drawing.Size(344, 473);
            this.tvwTrains.TabIndex = 4;
            // 
            // tvwTracks
            // 
            this.tvwTracks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvwTracks.Location = new System.Drawing.Point(703, 28);
            this.tvwTracks.Name = "tvwTracks";
            this.tvwTracks.Size = new System.Drawing.Size(357, 473);
            this.tvwTracks.TabIndex = 5;
            // 
            // btnStartSimulator
            // 
            this.btnStartSimulator.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStartSimulator.Location = new System.Drawing.Point(926, 513);
            this.btnStartSimulator.Name = "btnStartSimulator";
            this.btnStartSimulator.Size = new System.Drawing.Size(140, 21);
            this.btnStartSimulator.TabIndex = 2;
            this.btnStartSimulator.Text = "Start Simulator";
            this.btnStartSimulator.UseVisualStyleBackColor = true;
            this.btnStartSimulator.Click += new System.EventHandler(this.btnStartSimulator_Click);
            // 
            // lblNoOfTrains
            // 
            this.lblNoOfTrains.AutoSize = true;
            this.lblNoOfTrains.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNoOfTrains.Location = new System.Drawing.Point(13, 125);
            this.lblNoOfTrains.Name = "lblNoOfTrains";
            this.lblNoOfTrains.Padding = new System.Windows.Forms.Padding(5);
            this.lblNoOfTrains.Size = new System.Drawing.Size(206, 31);
            this.lblNoOfTrains.TabIndex = 5;
            this.lblNoOfTrains.Text = "Enter number of trains";
            // 
            // pnlShipmentCapacity
            // 
            this.pnlShipmentCapacity.AutoScroll = true;
            this.pnlShipmentCapacity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlShipmentCapacity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlShipmentCapacity.Location = new System.Drawing.Point(225, 164);
            this.pnlShipmentCapacity.Name = "pnlShipmentCapacity";
            this.pnlShipmentCapacity.Size = new System.Drawing.Size(259, 312);
            this.pnlShipmentCapacity.TabIndex = 10;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1090, 575);
            this.Controls.Add(this.panelContainer);
            this.Name = "MainForm";
            this.Text = "Bluestacks Coding Assignment";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.panelContainer.ResumeLayout(false);
            this.tbcSettings.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tbcSimulator.ResumeLayout(false);
            this.tbcSetting.ResumeLayout(false);
            this.tloBaseSimulator.ResumeLayout(false);
            this.tloTopLevelSimulator.ResumeLayout(false);
            this.tloTopLevelSimulator.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelContainer;
        private System.Windows.Forms.TabControl tbcSetting;
        private System.Windows.Forms.TabPage tbcSimulator;
        private System.Windows.Forms.TabPage tbcSettings;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox txbNoOfTrains;
        private System.Windows.Forms.Label lblNoOfStations;
        private System.Windows.Forms.Button btnSaveSetting;
        private System.Windows.Forms.Label lblTimer;
        private System.Windows.Forms.TextBox txbTimer;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txbNoOfStations;
        private System.Windows.Forms.TableLayoutPanel tloBaseSimulator;
        private System.Windows.Forms.TableLayoutPanel tloTopLevelSimulator;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TreeView tvwStations;
        private System.Windows.Forms.TreeView tvwTrains;
        private System.Windows.Forms.TreeView tvwTracks;
        private System.Windows.Forms.Button btnStartSimulator;
        private System.Windows.Forms.Label lblNoOfTrains;
        private System.Windows.Forms.Panel pnlShipmentCapacity;
    }
}

