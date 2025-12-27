namespace Presentation_Layer.Licenses.Local_Licesnse.Controles
{
    partial class ctrlLicenseInfoWithFilter
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gbLicesneFliter = new System.Windows.Forms.GroupBox();
            this.btnFindLicense = new System.Windows.Forms.Button();
            this.txtLicenseID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ctrlLicenseInfo1 = new Presentation_Layer.Licenses.Controles.ctrlLicenseInfo();
            this.gbLicesneFliter.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbLicesneFliter
            // 
            this.gbLicesneFliter.Controls.Add(this.btnFindLicense);
            this.gbLicesneFliter.Controls.Add(this.txtLicenseID);
            this.gbLicesneFliter.Controls.Add(this.label1);
            this.gbLicesneFliter.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbLicesneFliter.Location = new System.Drawing.Point(3, 3);
            this.gbLicesneFliter.Name = "gbLicesneFliter";
            this.gbLicesneFliter.Size = new System.Drawing.Size(526, 84);
            this.gbLicesneFliter.TabIndex = 1;
            this.gbLicesneFliter.TabStop = false;
            this.gbLicesneFliter.Text = "Filter";
            // 
            // btnFindLicense
            // 
            this.btnFindLicense.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFindLicense.Image = global::Presentation_Layer.Properties.Resources.License_View_32;
            this.btnFindLicense.Location = new System.Drawing.Point(451, 16);
            this.btnFindLicense.Name = "btnFindLicense";
            this.btnFindLicense.Size = new System.Drawing.Size(59, 55);
            this.btnFindLicense.TabIndex = 2;
            this.btnFindLicense.UseVisualStyleBackColor = true;
            this.btnFindLicense.Click += new System.EventHandler(this.btnFindLicense_Click);
            // 
            // txtLicenseID
            // 
            this.txtLicenseID.Location = new System.Drawing.Point(143, 30);
            this.txtLicenseID.Name = "txtLicenseID";
            this.txtLicenseID.Size = new System.Drawing.Size(285, 27);
            this.txtLicenseID.TabIndex = 1;
            this.txtLicenseID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLicenseID_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "License ID :";
            // 
            // ctrlLicenseInfo1
            // 
            this.ctrlLicenseInfo1.License = null;
            this.ctrlLicenseInfo1.Location = new System.Drawing.Point(0, 81);
            this.ctrlLicenseInfo1.Name = "ctrlLicenseInfo1";
            this.ctrlLicenseInfo1.Size = new System.Drawing.Size(1022, 342);
            this.ctrlLicenseInfo1.TabIndex = 2;
            // 
            // ctrlLicenseInfoWithFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbLicesneFliter);
            this.Controls.Add(this.ctrlLicenseInfo1);
            this.Name = "ctrlLicenseInfoWithFilter";
            this.Size = new System.Drawing.Size(1025, 423);
            this.Load += new System.EventHandler(this.ctrlLicenseInfoWithFilter_Load);
            this.gbLicesneFliter.ResumeLayout(false);
            this.gbLicesneFliter.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox gbLicesneFliter;
        private System.Windows.Forms.Button btnFindLicense;
        private System.Windows.Forms.TextBox txtLicenseID;
        private System.Windows.Forms.Label label1;
        private Licenses.Controles.ctrlLicenseInfo ctrlLicenseInfo1;
    }
}
