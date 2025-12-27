namespace Presentation_Layer.Licenses.Controles
{
    partial class ctrlLicenseHistory
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbLicenses = new System.Windows.Forms.TabControl();
            this.tpLocal = new System.Windows.Forms.TabPage();
            this.lblLocalNumber = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvLocalLicensesHistory = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.tpInternaional = new System.Windows.Forms.TabPage();
            this.lblInterNumber = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvInternaionalLicenses = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.cmsInterenationalLicenseHistory = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.InternationalLicenseHistorytoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsLocalLicenseHistory = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showLicenseInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.tbLicenses.SuspendLayout();
            this.tpLocal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalLicensesHistory)).BeginInit();
            this.tpInternaional.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInternaionalLicenses)).BeginInit();
            this.cmsInterenationalLicenseHistory.SuspendLayout();
            this.cmsLocalLicenseHistory.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbLicenses);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1077, 303);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Driver Licenses";
            // 
            // tbLicenses
            // 
            this.tbLicenses.Controls.Add(this.tpLocal);
            this.tbLicenses.Controls.Add(this.tpInternaional);
            this.tbLicenses.Location = new System.Drawing.Point(21, 29);
            this.tbLicenses.Name = "tbLicenses";
            this.tbLicenses.SelectedIndex = 0;
            this.tbLicenses.Size = new System.Drawing.Size(1050, 268);
            this.tbLicenses.TabIndex = 0;
            // 
            // tpLocal
            // 
            this.tpLocal.Controls.Add(this.lblLocalNumber);
            this.tpLocal.Controls.Add(this.label2);
            this.tpLocal.Controls.Add(this.dgvLocalLicensesHistory);
            this.tpLocal.Controls.Add(this.label1);
            this.tpLocal.Location = new System.Drawing.Point(4, 34);
            this.tpLocal.Name = "tpLocal";
            this.tpLocal.Padding = new System.Windows.Forms.Padding(3);
            this.tpLocal.Size = new System.Drawing.Size(1042, 230);
            this.tpLocal.TabIndex = 0;
            this.tpLocal.Text = "Local";
            this.tpLocal.UseVisualStyleBackColor = true;
            // 
            // lblLocalNumber
            // 
            this.lblLocalNumber.AutoSize = true;
            this.lblLocalNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLocalNumber.Location = new System.Drawing.Point(113, 186);
            this.lblLocalNumber.Name = "lblLocalNumber";
            this.lblLocalNumber.Size = new System.Drawing.Size(0, 20);
            this.lblLocalNumber.TabIndex = 139;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 186);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 20);
            this.label2.TabIndex = 138;
            this.label2.Text = "# Records:";
            // 
            // dgvLocalLicensesHistory
            // 
            this.dgvLocalLicensesHistory.AllowUserToAddRows = false;
            this.dgvLocalLicensesHistory.AllowUserToDeleteRows = false;
            this.dgvLocalLicensesHistory.AllowUserToResizeRows = false;
            this.dgvLocalLicensesHistory.BackgroundColor = System.Drawing.Color.White;
            this.dgvLocalLicensesHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLocalLicensesHistory.ContextMenuStrip = this.cmsLocalLicenseHistory;
            this.dgvLocalLicensesHistory.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvLocalLicensesHistory.Location = new System.Drawing.Point(7, 33);
            this.dgvLocalLicensesHistory.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvLocalLicensesHistory.MultiSelect = false;
            this.dgvLocalLicensesHistory.Name = "dgvLocalLicensesHistory";
            this.dgvLocalLicensesHistory.ReadOnly = true;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLocalLicensesHistory.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvLocalLicensesHistory.RowHeadersWidth = 51;
            this.dgvLocalLicensesHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLocalLicensesHistory.Size = new System.Drawing.Size(1028, 148);
            this.dgvLocalLicensesHistory.TabIndex = 137;
            this.dgvLocalLicensesHistory.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(210, 20);
            this.label1.TabIndex = 136;
            this.label1.Text = "Local Licenses History:";
            // 
            // tpInternaional
            // 
            this.tpInternaional.Controls.Add(this.lblInterNumber);
            this.tpInternaional.Controls.Add(this.label4);
            this.tpInternaional.Controls.Add(this.dgvInternaionalLicenses);
            this.tpInternaional.Controls.Add(this.label5);
            this.tpInternaional.Location = new System.Drawing.Point(4, 34);
            this.tpInternaional.Name = "tpInternaional";
            this.tpInternaional.Padding = new System.Windows.Forms.Padding(3);
            this.tpInternaional.Size = new System.Drawing.Size(1042, 230);
            this.tpInternaional.TabIndex = 1;
            this.tpInternaional.Text = "International";
            this.tpInternaional.UseVisualStyleBackColor = true;
            // 
            // lblInterNumber
            // 
            this.lblInterNumber.AutoSize = true;
            this.lblInterNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInterNumber.Location = new System.Drawing.Point(131, 194);
            this.lblInterNumber.Name = "lblInterNumber";
            this.lblInterNumber.Size = new System.Drawing.Size(0, 20);
            this.lblInterNumber.TabIndex = 143;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(24, 194);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 20);
            this.label4.TabIndex = 142;
            this.label4.Text = "# Records:";
            // 
            // dgvInternaionalLicenses
            // 
            this.dgvInternaionalLicenses.AllowUserToAddRows = false;
            this.dgvInternaionalLicenses.AllowUserToDeleteRows = false;
            this.dgvInternaionalLicenses.AllowUserToResizeRows = false;
            this.dgvInternaionalLicenses.BackgroundColor = System.Drawing.Color.White;
            this.dgvInternaionalLicenses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInternaionalLicenses.ContextMenuStrip = this.cmsInterenationalLicenseHistory;
            this.dgvInternaionalLicenses.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvInternaionalLicenses.Location = new System.Drawing.Point(7, 41);
            this.dgvInternaionalLicenses.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvInternaionalLicenses.MultiSelect = false;
            this.dgvInternaionalLicenses.Name = "dgvInternaionalLicenses";
            this.dgvInternaionalLicenses.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvInternaionalLicenses.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvInternaionalLicenses.RowHeadersWidth = 51;
            this.dgvInternaionalLicenses.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInternaionalLicenses.Size = new System.Drawing.Size(1028, 148);
            this.dgvInternaionalLicenses.TabIndex = 141;
            this.dgvInternaionalLicenses.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(262, 20);
            this.label5.TabIndex = 140;
            this.label5.Text = "Internaional Licenses History:";
            // 
            // cmsInterenationalLicenseHistory
            // 
            this.cmsInterenationalLicenseHistory.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsInterenationalLicenseHistory.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.InternationalLicenseHistorytoolStripMenuItem});
            this.cmsInterenationalLicenseHistory.Name = "cmsLocalLicenseHistory";
            this.cmsInterenationalLicenseHistory.Size = new System.Drawing.Size(227, 70);
            // 
            // InternationalLicenseHistorytoolStripMenuItem
            // 
            this.InternationalLicenseHistorytoolStripMenuItem.Image = global::Presentation_Layer.Properties.Resources.License_View_32;
            this.InternationalLicenseHistorytoolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.InternationalLicenseHistorytoolStripMenuItem.Name = "InternationalLicenseHistorytoolStripMenuItem";
            this.InternationalLicenseHistorytoolStripMenuItem.Size = new System.Drawing.Size(226, 38);
            this.InternationalLicenseHistorytoolStripMenuItem.Text = "Show License Info";
            this.InternationalLicenseHistorytoolStripMenuItem.Click += new System.EventHandler(this.InternationalLicenseHistorytoolStripMenuItem_Click);
            // 
            // cmsLocalLicenseHistory
            // 
            this.cmsLocalLicenseHistory.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsLocalLicenseHistory.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showLicenseInfoToolStripMenuItem});
            this.cmsLocalLicenseHistory.Name = "cmsLocalLicenseHistory";
            this.cmsLocalLicenseHistory.Size = new System.Drawing.Size(213, 42);
            // 
            // showLicenseInfoToolStripMenuItem
            // 
            this.showLicenseInfoToolStripMenuItem.Image = global::Presentation_Layer.Properties.Resources.License_View_32;
            this.showLicenseInfoToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.showLicenseInfoToolStripMenuItem.Name = "showLicenseInfoToolStripMenuItem";
            this.showLicenseInfoToolStripMenuItem.Size = new System.Drawing.Size(212, 38);
            this.showLicenseInfoToolStripMenuItem.Text = "Show License Info";
            this.showLicenseInfoToolStripMenuItem.Click += new System.EventHandler(this.showLicenseInfoToolStripMenuItem_Click);
            // 
            // ctrlLicenseHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "ctrlLicenseHistory";
            this.Size = new System.Drawing.Size(1083, 306);
            this.groupBox1.ResumeLayout(false);
            this.tbLicenses.ResumeLayout(false);
            this.tpLocal.ResumeLayout(false);
            this.tpLocal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalLicensesHistory)).EndInit();
            this.tpInternaional.ResumeLayout(false);
            this.tpInternaional.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInternaionalLicenses)).EndInit();
            this.cmsInterenationalLicenseHistory.ResumeLayout(false);
            this.cmsLocalLicenseHistory.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabControl tbLicenses;
        private System.Windows.Forms.TabPage tpLocal;
        private System.Windows.Forms.TabPage tpInternaional;
        private System.Windows.Forms.Label lblLocalNumber;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvLocalLicensesHistory;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblInterNumber;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgvInternaionalLicenses;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ContextMenuStrip cmsInterenationalLicenseHistory;
        private System.Windows.Forms.ToolStripMenuItem InternationalLicenseHistorytoolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip cmsLocalLicenseHistory;
        private System.Windows.Forms.ToolStripMenuItem showLicenseInfoToolStripMenuItem;
    }
}
