namespace Eagle_Finance_Utility
{
    partial class FrmObsolAlloc
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvObsoAllocSnk = new System.Windows.Forms.DataGridView();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvObsoAllocMLK = new System.Windows.Forms.DataGridView();
            this.cbxFiscalYear = new System.Windows.Forms.ComboBox();
            this.MilkObsoBS = new System.Windows.Forms.BindingSource(this.components);
            this.SnackObsoBS = new System.Windows.Forms.BindingSource(this.components);
            this.label9 = new System.Windows.Forms.Label();
            this.lblUpdate = new System.Windows.Forms.Label();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvObsoAllocSnk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvObsoAllocMLK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MilkObsoBS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SnackObsoBS)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgvObsoAllocSnk);
            this.groupBox3.Controls.Add(this.btnUpdate);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.dgvObsoAllocMLK);
            this.groupBox3.Controls.Add(this.cbxFiscalYear);
            this.groupBox3.Location = new System.Drawing.Point(16, 15);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Size = new System.Drawing.Size(1928, 777);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Obsolescence Allocation";
            // 
            // dgvObsoAllocSnk
            // 
            this.dgvObsoAllocSnk.AllowUserToAddRows = false;
            this.dgvObsoAllocSnk.AllowUserToDeleteRows = false;
            this.dgvObsoAllocSnk.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvObsoAllocSnk.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvObsoAllocSnk.Location = new System.Drawing.Point(19, 414);
            this.dgvObsoAllocSnk.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvObsoAllocSnk.Name = "dgvObsoAllocSnk";
            this.dgvObsoAllocSnk.RowHeadersWidth = 51;
            this.dgvObsoAllocSnk.Size = new System.Drawing.Size(1896, 338);
            this.dgvObsoAllocSnk.TabIndex = 5;
            this.dgvObsoAllocSnk.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvObsoAllocSnk_CellEndEdit);
            this.dgvObsoAllocSnk.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvObsoAllocSnk_DataError);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(1815, 21);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(100, 28);
            this.btnUpdate.TabIndex = 4;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 27);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Fiscal Year:";
            // 
            // dgvObsoAllocMLK
            // 
            this.dgvObsoAllocMLK.AllowUserToAddRows = false;
            this.dgvObsoAllocMLK.AllowUserToDeleteRows = false;
            this.dgvObsoAllocMLK.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvObsoAllocMLK.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvObsoAllocMLK.Location = new System.Drawing.Point(19, 57);
            this.dgvObsoAllocMLK.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvObsoAllocMLK.Name = "dgvObsoAllocMLK";
            this.dgvObsoAllocMLK.RowHeadersWidth = 51;
            this.dgvObsoAllocMLK.Size = new System.Drawing.Size(1896, 338);
            this.dgvObsoAllocMLK.TabIndex = 0;
            this.dgvObsoAllocMLK.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvObsoAllocMLK_CellEndEdit);
            this.dgvObsoAllocMLK.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvObsoAllocMLK_DataError);
            // 
            // cbxFiscalYear
            // 
            this.cbxFiscalYear.FormattingEnabled = true;
            this.cbxFiscalYear.Location = new System.Drawing.Point(107, 23);
            this.cbxFiscalYear.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbxFiscalYear.Name = "cbxFiscalYear";
            this.cbxFiscalYear.Size = new System.Drawing.Size(160, 24);
            this.cbxFiscalYear.TabIndex = 1;
            this.cbxFiscalYear.SelectedIndexChanged += new System.EventHandler(this.cbxFiscalYear_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(1583, 802);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(89, 17);
            this.label9.TabIndex = 10;
            this.label9.Text = "Last Update:";
            // 
            // lblUpdate
            // 
            this.lblUpdate.AutoSize = true;
            this.lblUpdate.Location = new System.Drawing.Point(1681, 802);
            this.lblUpdate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUpdate.Name = "lblUpdate";
            this.lblUpdate.Size = new System.Drawing.Size(0, 17);
            this.lblUpdate.TabIndex = 9;
            // 
            // FrmObsolAlloc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1955, 830);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lblUpdate);
            this.Controls.Add(this.groupBox3);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FrmObsolAlloc";
            this.Text = "Obsolescence Alloccation";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmObsolAlloc_FormClosing);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvObsoAllocSnk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvObsoAllocMLK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MilkObsoBS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SnackObsoBS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvObsoAllocMLK;
        private System.Windows.Forms.ComboBox cbxFiscalYear;
        private System.Windows.Forms.BindingSource MilkObsoBS;
        private System.Windows.Forms.DataGridView dgvObsoAllocSnk;
        private System.Windows.Forms.BindingSource SnackObsoBS;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblUpdate;
    }
}