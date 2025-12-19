namespace Presentation_Layer.Applications.Local_Driving_Licenses
{
    partial class frmListLocalDrivingLicensesApplications
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
            this.txtFilterLDLApp = new System.Windows.Forms.TextBox();
            this.cbFilterLDLApp = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblRecordsNumber = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvLDLApps = new System.Windows.Forms.DataGridView();
            this.cmsLDLApps = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showApplicationDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.cancelApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.scheduleTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.issuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.showLiceneseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.showPersonLicenseHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnAddNewLDLApp = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLDLApps)).BeginInit();
            this.cmsLDLApps.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtFilterLDLApp
            // 
            this.txtFilterLDLApp.Location = new System.Drawing.Point(286, 302);
            this.txtFilterLDLApp.Name = "txtFilterLDLApp";
            this.txtFilterLDLApp.Size = new System.Drawing.Size(184, 22);
            this.txtFilterLDLApp.TabIndex = 17;
            this.txtFilterLDLApp.Visible = false;
            this.txtFilterLDLApp.TextChanged += new System.EventHandler(this.txtFilterLDLApp_TextChanged);
            this.txtFilterLDLApp.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilterLDLApp_KeyPress);
            // 
            // cbFilterLDLApp
            // 
            this.cbFilterLDLApp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilterLDLApp.FormattingEnabled = true;
            this.cbFilterLDLApp.Items.AddRange(new object[] {
            "None",
            "L.D.L.AppID",
            "National No",
            "Full Name",
            "Status"});
            this.cbFilterLDLApp.Location = new System.Drawing.Point(112, 302);
            this.cbFilterLDLApp.Name = "cbFilterLDLApp";
            this.cbFilterLDLApp.Size = new System.Drawing.Size(168, 24);
            this.cbFilterLDLApp.TabIndex = 16;
            this.cbFilterLDLApp.SelectedIndexChanged += new System.EventHandler(this.cbFilterLDLApp_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(30, 305);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 16);
            this.label2.TabIndex = 15;
            this.label2.Text = "Filter By : ";
            // 
            // lblRecordsNumber
            // 
            this.lblRecordsNumber.AutoSize = true;
            this.lblRecordsNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecordsNumber.Location = new System.Drawing.Point(109, 778);
            this.lblRecordsNumber.Name = "lblRecordsNumber";
            this.lblRecordsNumber.Size = new System.Drawing.Size(0, 16);
            this.lblRecordsNumber.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(469, 211);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(620, 42);
            this.label1.TabIndex = 11;
            this.label1.Text = "Local Driving License Applications";
            // 
            // dgvLDLApps
            // 
            this.dgvLDLApps.AllowUserToAddRows = false;
            this.dgvLDLApps.AllowUserToDeleteRows = false;
            this.dgvLDLApps.AllowUserToResizeRows = false;
            this.dgvLDLApps.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvLDLApps.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLDLApps.ContextMenuStrip = this.cmsLDLApps;
            this.dgvLDLApps.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvLDLApps.Location = new System.Drawing.Point(12, 332);
            this.dgvLDLApps.Name = "dgvLDLApps";
            this.dgvLDLApps.RowHeadersWidth = 51;
            this.dgvLDLApps.RowTemplate.Height = 24;
            this.dgvLDLApps.Size = new System.Drawing.Size(1379, 412);
            this.dgvLDLApps.TabIndex = 9;
            // 
            // cmsLDLApps
            // 
            this.cmsLDLApps.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsLDLApps.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showApplicationDetailsToolStripMenuItem,
            this.editApplicationToolStripMenuItem,
            this.deleteApplicationToolStripMenuItem,
            this.toolStripSeparator1,
            this.cancelApplicationToolStripMenuItem,
            this.toolStripSeparator2,
            this.scheduleTestToolStripMenuItem,
            this.toolStripSeparator3,
            this.issuToolStripMenuItem,
            this.toolStripSeparator4,
            this.showLiceneseToolStripMenuItem,
            this.toolStripSeparator5,
            this.showPersonLicenseHistoryToolStripMenuItem});
            this.cmsLDLApps.Name = "cmsLDLApps";
            this.cmsLDLApps.Size = new System.Drawing.Size(309, 366);
            // 
            // showApplicationDetailsToolStripMenuItem
            // 
            this.showApplicationDetailsToolStripMenuItem.Image = global::Presentation_Layer.Properties.Resources.PersonDetails_321;
            this.showApplicationDetailsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.showApplicationDetailsToolStripMenuItem.Name = "showApplicationDetailsToolStripMenuItem";
            this.showApplicationDetailsToolStripMenuItem.Size = new System.Drawing.Size(308, 38);
            this.showApplicationDetailsToolStripMenuItem.Text = "Show Application Details";
            this.showApplicationDetailsToolStripMenuItem.Click += new System.EventHandler(this.showApplicationDetailsToolStripMenuItem_Click);
            // 
            // editApplicationToolStripMenuItem
            // 
            this.editApplicationToolStripMenuItem.Image = global::Presentation_Layer.Properties.Resources.edit_32;
            this.editApplicationToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.editApplicationToolStripMenuItem.Name = "editApplicationToolStripMenuItem";
            this.editApplicationToolStripMenuItem.Size = new System.Drawing.Size(308, 38);
            this.editApplicationToolStripMenuItem.Text = "Edit Application ";
            this.editApplicationToolStripMenuItem.Click += new System.EventHandler(this.editApplicationToolStripMenuItem_Click);
            // 
            // deleteApplicationToolStripMenuItem
            // 
            this.deleteApplicationToolStripMenuItem.Image = global::Presentation_Layer.Properties.Resources.Delete_32_2;
            this.deleteApplicationToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.deleteApplicationToolStripMenuItem.Name = "deleteApplicationToolStripMenuItem";
            this.deleteApplicationToolStripMenuItem.Size = new System.Drawing.Size(308, 38);
            this.deleteApplicationToolStripMenuItem.Text = "Delete Application ";
            this.deleteApplicationToolStripMenuItem.Click += new System.EventHandler(this.deleteApplicationToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(305, 6);
            // 
            // cancelApplicationToolStripMenuItem
            // 
            this.cancelApplicationToolStripMenuItem.Image = global::Presentation_Layer.Properties.Resources.Delete_32;
            this.cancelApplicationToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cancelApplicationToolStripMenuItem.Name = "cancelApplicationToolStripMenuItem";
            this.cancelApplicationToolStripMenuItem.Size = new System.Drawing.Size(308, 38);
            this.cancelApplicationToolStripMenuItem.Text = "Cancel Application ";
            this.cancelApplicationToolStripMenuItem.Click += new System.EventHandler(this.cancelApplicationToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(305, 6);
            // 
            // scheduleTestToolStripMenuItem
            // 
            this.scheduleTestToolStripMenuItem.Image = global::Presentation_Layer.Properties.Resources.Schedule_Test_32;
            this.scheduleTestToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.scheduleTestToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.scheduleTestToolStripMenuItem.Name = "scheduleTestToolStripMenuItem";
            this.scheduleTestToolStripMenuItem.Size = new System.Drawing.Size(308, 38);
            this.scheduleTestToolStripMenuItem.Text = "SechduleTest";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(305, 6);
            // 
            // issuToolStripMenuItem
            // 
            this.issuToolStripMenuItem.Image = global::Presentation_Layer.Properties.Resources.IssueDrivingLicense_32;
            this.issuToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.issuToolStripMenuItem.Name = "issuToolStripMenuItem";
            this.issuToolStripMenuItem.Size = new System.Drawing.Size(308, 38);
            this.issuToolStripMenuItem.Text = "Issue Driving License (First Time)";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(305, 6);
            // 
            // showLiceneseToolStripMenuItem
            // 
            this.showLiceneseToolStripMenuItem.Image = global::Presentation_Layer.Properties.Resources.License_View_32;
            this.showLiceneseToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.showLiceneseToolStripMenuItem.Name = "showLiceneseToolStripMenuItem";
            this.showLiceneseToolStripMenuItem.Size = new System.Drawing.Size(308, 38);
            this.showLiceneseToolStripMenuItem.Text = "Show Licenese";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(305, 6);
            // 
            // showPersonLicenseHistoryToolStripMenuItem
            // 
            this.showPersonLicenseHistoryToolStripMenuItem.Image = global::Presentation_Layer.Properties.Resources.PersonLicenseHistory_32;
            this.showPersonLicenseHistoryToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.showPersonLicenseHistoryToolStripMenuItem.Name = "showPersonLicenseHistoryToolStripMenuItem";
            this.showPersonLicenseHistoryToolStripMenuItem.Size = new System.Drawing.Size(308, 38);
            this.showPersonLicenseHistoryToolStripMenuItem.Text = "Show Person License History";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 778);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 16);
            this.label3.TabIndex = 19;
            this.label3.Text = "# Records :";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Presentation_Layer.Properties.Resources.Local_32;
            this.pictureBox2.Location = new System.Drawing.Point(812, 87);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(57, 40);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 18;
            this.pictureBox2.TabStop = false;
            // 
            // btnAddNewLDLApp
            // 
            this.btnAddNewLDLApp.Image = global::Presentation_Layer.Properties.Resources.New_Application_64;
            this.btnAddNewLDLApp.Location = new System.Drawing.Point(1300, 226);
            this.btnAddNewLDLApp.Name = "btnAddNewLDLApp";
            this.btnAddNewLDLApp.Size = new System.Drawing.Size(91, 95);
            this.btnAddNewLDLApp.TabIndex = 14;
            this.btnAddNewLDLApp.UseVisualStyleBackColor = true;
            this.btnAddNewLDLApp.Click += new System.EventHandler(this.btnAddNewLDLApp_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::Presentation_Layer.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(1233, 757);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(158, 57);
            this.btnClose.TabIndex = 13;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Presentation_Layer.Properties.Resources.Applications;
            this.pictureBox1.Location = new System.Drawing.Point(606, 30);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(287, 178);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // frmListLocalDrivingLicensesApplications
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1408, 819);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.txtFilterLDLApp);
            this.Controls.Add(this.cbFilterLDLApp);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnAddNewLDLApp);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblRecordsNumber);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.dgvLDLApps);
            this.Name = "frmListLocalDrivingLicensesApplications";
            this.Text = "Local Driving Licenses Applications";
            this.Load += new System.EventHandler(this.frmListLocalDrivingLicensesApplications_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLDLApps)).EndInit();
            this.cmsLDLApps.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtFilterLDLApp;
        private System.Windows.Forms.ComboBox cbFilterLDLApp;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAddNewLDLApp;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblRecordsNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView dgvLDLApps;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ContextMenuStrip cmsLDLApps;
        private System.Windows.Forms.ToolStripMenuItem showApplicationDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editApplicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteApplicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem cancelApplicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem scheduleTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem issuToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem showLiceneseToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem showPersonLicenseHistoryToolStripMenuItem;
    }
}