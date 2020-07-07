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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmObsolAlloc));
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvObsoAllocSnk = new System.Windows.Forms.DataGridView();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvObsoAllocMLK = new System.Windows.Forms.DataGridView();
            this.cbxFiscalYear = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.lblUpdate = new System.Windows.Forms.Label();
            this.MilkObsoBS = new System.Windows.Forms.BindingSource(this.components);
            this.SnackObsoBS = new System.Windows.Forms.BindingSource(this.components);
            this.cmsMLK = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsSNK = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.siMLKCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.siMLKPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.siSNKCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.siSNKPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvObsoAllocSnk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvObsoAllocMLK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MilkObsoBS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SnackObsoBS)).BeginInit();
            this.cmsMLK.SuspendLayout();
            this.cmsSNK.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.dgvObsoAllocSnk);
            this.groupBox3.Controls.Add(this.btnUpdate);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.dgvObsoAllocMLK);
            this.groupBox3.Controls.Add(this.cbxFiscalYear);
            this.groupBox3.Location = new System.Drawing.Point(12, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1053, 631);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Obsolescence Allocation";
            // 
            // dgvObsoAllocSnk
            // 
            this.dgvObsoAllocSnk.AllowUserToAddRows = false;
            this.dgvObsoAllocSnk.AllowUserToDeleteRows = false;
            this.dgvObsoAllocSnk.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvObsoAllocSnk.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvObsoAllocSnk.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvObsoAllocSnk.ContextMenuStrip = this.cmsSNK;
            this.dgvObsoAllocSnk.Location = new System.Drawing.Point(14, 336);
            this.dgvObsoAllocSnk.Name = "dgvObsoAllocSnk";
            this.dgvObsoAllocSnk.RowHeadersWidth = 51;
            this.dgvObsoAllocSnk.Size = new System.Drawing.Size(1029, 275);
            this.dgvObsoAllocSnk.TabIndex = 5;
            this.dgvObsoAllocSnk.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvObsoAllocSnk_CellEndEdit);
            this.dgvObsoAllocSnk.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvObsoAllocSnk_DataError);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.Location = new System.Drawing.Point(968, 17);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 4;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Fiscal Year:";
            // 
            // dgvObsoAllocMLK
            // 
            this.dgvObsoAllocMLK.AllowUserToAddRows = false;
            this.dgvObsoAllocMLK.AllowUserToDeleteRows = false;
            this.dgvObsoAllocMLK.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvObsoAllocMLK.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvObsoAllocMLK.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvObsoAllocMLK.ContextMenuStrip = this.cmsMLK;
            this.dgvObsoAllocMLK.Location = new System.Drawing.Point(14, 46);
            this.dgvObsoAllocMLK.Name = "dgvObsoAllocMLK";
            this.dgvObsoAllocMLK.RowHeadersWidth = 51;
            this.dgvObsoAllocMLK.Size = new System.Drawing.Size(1029, 275);
            this.dgvObsoAllocMLK.TabIndex = 0;
            this.dgvObsoAllocMLK.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvObsoAllocMLK_CellEndEdit);
            this.dgvObsoAllocMLK.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvObsoAllocMLK_DataError);
            // 
            // cbxFiscalYear
            // 
            this.cbxFiscalYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxFiscalYear.FormattingEnabled = true;
            this.cbxFiscalYear.Location = new System.Drawing.Point(80, 19);
            this.cbxFiscalYear.Name = "cbxFiscalYear";
            this.cbxFiscalYear.Size = new System.Drawing.Size(121, 21);
            this.cbxFiscalYear.TabIndex = 1;
            this.cbxFiscalYear.SelectedIndexChanged += new System.EventHandler(this.cbxFiscalYear_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(794, 652);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(68, 13);
            this.label9.TabIndex = 10;
            this.label9.Text = "Last Update:";
            // 
            // lblUpdate
            // 
            this.lblUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUpdate.AutoSize = true;
            this.lblUpdate.Location = new System.Drawing.Point(868, 652);
            this.lblUpdate.Name = "lblUpdate";
            this.lblUpdate.Size = new System.Drawing.Size(0, 13);
            this.lblUpdate.TabIndex = 9;
            // 
            // cmsMLK
            // 
            this.cmsMLK.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.siMLKCopy,
            this.siMLKPaste});
            this.cmsMLK.Name = "cmsMLK";
            this.cmsMLK.Size = new System.Drawing.Size(103, 48);
            // 
            // cmsSNK
            // 
            this.cmsSNK.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.siSNKCopy,
            this.siSNKPaste});
            this.cmsSNK.Name = "cmsSNK";
            this.cmsSNK.Size = new System.Drawing.Size(103, 48);
            // 
            // siMLKCopy
            // 
            this.siMLKCopy.Name = "siMLKCopy";
            this.siMLKCopy.Size = new System.Drawing.Size(102, 22);
            this.siMLKCopy.Text = "Copy";
            this.siMLKCopy.Click += new System.EventHandler(this.siMLKCopy_Click);
            // 
            // siMLKPaste
            // 
            this.siMLKPaste.Name = "siMLKPaste";
            this.siMLKPaste.Size = new System.Drawing.Size(102, 22);
            this.siMLKPaste.Text = "Paste";
            this.siMLKPaste.Click += new System.EventHandler(this.siMLKPaste_Click);
            // 
            // siSNKCopy
            // 
            this.siSNKCopy.Name = "siSNKCopy";
            this.siSNKCopy.Size = new System.Drawing.Size(102, 22);
            this.siSNKCopy.Text = "Copy";
            this.siSNKCopy.Click += new System.EventHandler(this.siSNKCopy_Click);
            // 
            // siSNKPaste
            // 
            this.siSNKPaste.Name = "siSNKPaste";
            this.siSNKPaste.Size = new System.Drawing.Size(102, 22);
            this.siSNKPaste.Text = "Paste";
            this.siSNKPaste.Click += new System.EventHandler(this.siSNKPaste_Click);
            // 
            // FrmObsolAlloc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1073, 674);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lblUpdate);
            this.Controls.Add(this.groupBox3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmObsolAlloc";
            this.Text = "Obsolescence Allocation";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmObsolAlloc_FormClosing);
            this.Load += new System.EventHandler(this.FrmObsolAlloc_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvObsoAllocSnk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvObsoAllocMLK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MilkObsoBS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SnackObsoBS)).EndInit();
            this.cmsMLK.ResumeLayout(false);
            this.cmsSNK.ResumeLayout(false);
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
        private System.Windows.Forms.ContextMenuStrip cmsMLK;
        private System.Windows.Forms.ToolStripMenuItem siMLKCopy;
        private System.Windows.Forms.ToolStripMenuItem siMLKPaste;
        private System.Windows.Forms.ContextMenuStrip cmsSNK;
        private System.Windows.Forms.ToolStripMenuItem siSNKCopy;
        private System.Windows.Forms.ToolStripMenuItem siSNKPaste;
    }
}