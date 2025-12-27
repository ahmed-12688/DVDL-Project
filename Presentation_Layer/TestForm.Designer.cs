namespace Presentation_Layer
{
    partial class TestForm
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
            this.btnEdit = new System.Windows.Forms.Button();
            this.txtTestEdit = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.ctrlLicenseInfoWithFilter1 = new Presentation_Layer.Licenses.Local_Licesnse.Controles.ctrlLicenseInfoWithFilter();
            this.SuspendLayout();
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(191, 96);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(68, 22);
            this.btnEdit.TabIndex = 0;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // txtTestEdit
            // 
            this.txtTestEdit.Location = new System.Drawing.Point(29, 96);
            this.txtTestEdit.Name = "txtTestEdit";
            this.txtTestEdit.Size = new System.Drawing.Size(144, 22);
            this.txtTestEdit.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(51, 217);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(132, 53);
            this.button1.TabIndex = 2;
            this.button1.Text = "PersonInfo";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ctrlLicenseInfoWithFilter1
            // 
            this.ctrlLicenseInfoWithFilter1.Location = new System.Drawing.Point(220, 138);
            this.ctrlLicenseInfoWithFilter1.Name = "ctrlLicenseInfoWithFilter1";
            this.ctrlLicenseInfoWithFilter1.Size = new System.Drawing.Size(1025, 423);
            this.ctrlLicenseInfoWithFilter1.TabIndex = 3;
            // 
            // TestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1325, 604);
            this.Controls.Add(this.ctrlLicenseInfoWithFilter1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtTestEdit);
            this.Controls.Add(this.btnEdit);
            this.Name = "TestForm";
            this.Text = "TestForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.TextBox txtTestEdit;
        private System.Windows.Forms.Button button1;
        private Licenses.Local_Licesnse.Controles.ctrlLicenseInfoWithFilter ctrlLicenseInfoWithFilter1;
    }
}