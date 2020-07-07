namespace Eagle_Finance_Utility
{
    partial class FrmMarketing
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMarketing));
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvMktgAllocPI = new System.Windows.Forms.DataGridView();
            this.cmsPI = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miPICopy = new System.Windows.Forms.ToolStripMenuItem();
            this.miPIPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvMktgAllocCF = new System.Windows.Forms.DataGridView();
            this.cmsCF = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miCFCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.miCFPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvMktgAllocMLK = new System.Windows.Forms.DataGridView();
            this.cmsMLK = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.miPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.cbxFiscalYear = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.lblUpdate = new System.Windows.Forms.Label();
            this.MktgCFBS = new System.Windows.Forms.BindingSource(this.components);
            this.MktgMlkBS = new System.Windows.Forms.BindingSource(this.components);
            this.MktgPIBS = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMktgAllocPI)).BeginInit();
            this.cmsPI.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMktgAllocCF)).BeginInit();
            this.cmsCF.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMktgAllocMLK)).BeginInit();
            this.cmsMLK.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MktgCFBS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MktgMlkBS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MktgPIBS)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.dgvMktgAllocPI);
            this.groupBox3.Controls.Add(this.dgvMktgAllocCF);
            this.groupBox3.Controls.Add(this.btnUpdate);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.dgvMktgAllocMLK);
            this.groupBox3.Controls.Add(this.cbxFiscalYear);
            this.groupBox3.Location = new System.Drawing.Point(10, 11);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1082, 614);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Marketing Allocation";
            // 
            // dgvMktgAllocPI
            // 
            this.dgvMktgAllocPI.AllowUserToAddRows = false;
            this.dgvMktgAllocPI.AllowUserToDeleteRows = false;
            this.dgvMktgAllocPI.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMktgAllocPI.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvMktgAllocPI.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMktgAllocPI.ContextMenuStrip = this.cmsPI;
            this.dgvMktgAllocPI.Location = new System.Drawing.Point(14, 468);
            this.dgvMktgAllocPI.Name = "dgvMktgAllocPI";
            this.dgvMktgAllocPI.RowHeadersWidth = 51;
            this.dgvMktgAllocPI.Size = new System.Drawing.Size(1058, 140);
            this.dgvMktgAllocPI.TabIndex = 6;
            this.dgvMktgAllocPI.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMktgAllocPI_CellEndEdit);
            this.dgvMktgAllocPI.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvMktgAllocPI_DataError);
            // 
            // cmsPI
            // 
            this.cmsPI.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miPICopy,
            this.miPIPaste});
            this.cmsPI.Name = "cmsPI";
            this.cmsPI.Size = new System.Drawing.Size(103, 48);
            // 
            // miPICopy
            // 
            this.miPICopy.Name = "miPICopy";
            this.miPICopy.Size = new System.Drawing.Size(102, 22);
            this.miPICopy.Text = "Copy";
            this.miPICopy.Click += new System.EventHandler(this.miPICopy_Click);
            // 
            // miPIPaste
            // 
            this.miPIPaste.Name = "miPIPaste";
            this.miPIPaste.Size = new System.Drawing.Size(102, 22);
            this.miPIPaste.Text = "Paste";
            this.miPIPaste.Click += new System.EventHandler(this.miPIPaste_Click);
            // 
            // dgvMktgAllocCF
            // 
            this.dgvMktgAllocCF.AllowUserToAddRows = false;
            this.dgvMktgAllocCF.AllowUserToDeleteRows = false;
            this.dgvMktgAllocCF.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMktgAllocCF.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvMktgAllocCF.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMktgAllocCF.ContextMenuStrip = this.cmsCF;
            this.dgvMktgAllocCF.Location = new System.Drawing.Point(14, 291);
            this.dgvMktgAllocCF.Name = "dgvMktgAllocCF";
            this.dgvMktgAllocCF.RowHeadersWidth = 51;
            this.dgvMktgAllocCF.Size = new System.Drawing.Size(1058, 171);
            this.dgvMktgAllocCF.TabIndex = 5;
            this.dgvMktgAllocCF.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMktgAllocCF_CellEndEdit);
            this.dgvMktgAllocCF.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvMktgAllocCF_DataError);
            // 
            // cmsCF
            // 
            this.cmsCF.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miCFCopy,
            this.miCFPaste});
            this.cmsCF.Name = "cmsCF";
            this.cmsCF.Size = new System.Drawing.Size(103, 48);
            // 
            // miCFCopy
            // 
            this.miCFCopy.Name = "miCFCopy";
            this.miCFCopy.Size = new System.Drawing.Size(102, 22);
            this.miCFCopy.Text = "Copy";
            this.miCFCopy.Click += new System.EventHandler(this.miCFCopy_Click);
            // 
            // miCFPaste
            // 
            this.miCFPaste.Name = "miCFPaste";
            this.miCFPaste.Size = new System.Drawing.Size(102, 22);
            this.miCFPaste.Text = "Paste";
            this.miCFPaste.Click += new System.EventHandler(this.miCFPaste_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.Location = new System.Drawing.Point(998, 17);
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
            // dgvMktgAllocMLK
            // 
            this.dgvMktgAllocMLK.AllowUserToAddRows = false;
            this.dgvMktgAllocMLK.AllowUserToDeleteRows = false;
            this.dgvMktgAllocMLK.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMktgAllocMLK.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvMktgAllocMLK.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMktgAllocMLK.ContextMenuStrip = this.cmsMLK;
            this.dgvMktgAllocMLK.Location = new System.Drawing.Point(14, 46);
            this.dgvMktgAllocMLK.Name = "dgvMktgAllocMLK";
            this.dgvMktgAllocMLK.RowHeadersWidth = 51;
            this.dgvMktgAllocMLK.Size = new System.Drawing.Size(1058, 239);
            this.dgvMktgAllocMLK.TabIndex = 0;
            this.dgvMktgAllocMLK.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMktgAllocMLK_CellEndEdit);
            this.dgvMktgAllocMLK.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvMktgAllocMLK_DataError);
            // 
            // cmsMLK
            // 
            this.cmsMLK.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miCopy,
            this.miPaste});
            this.cmsMLK.Name = "cmsMLK";
            this.cmsMLK.Size = new System.Drawing.Size(103, 48);
            // 
            // miCopy
            // 
            this.miCopy.Name = "miCopy";
            this.miCopy.Size = new System.Drawing.Size(102, 22);
            this.miCopy.Text = "Copy";
            this.miCopy.Click += new System.EventHandler(this.miCopy_Click);
            // 
            // miPaste
            // 
            this.miPaste.Name = "miPaste";
            this.miPaste.Size = new System.Drawing.Size(102, 22);
            this.miPaste.Text = "Paste";
            this.miPaste.Click += new System.EventHandler(this.miPaste_Click);
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
            this.label9.Location = new System.Drawing.Point(817, 628);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(68, 13);
            this.label9.TabIndex = 12;
            this.label9.Text = "Last Update:";
            // 
            // lblUpdate
            // 
            this.lblUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUpdate.AutoSize = true;
            this.lblUpdate.Location = new System.Drawing.Point(890, 628);
            this.lblUpdate.Name = "lblUpdate";
            this.lblUpdate.Size = new System.Drawing.Size(0, 13);
            this.lblUpdate.TabIndex = 11;
            // 
            // FrmMarketing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1102, 650);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lblUpdate);
            this.Controls.Add(this.groupBox3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmMarketing";
            this.Text = "Marketing Allocation";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMarketing_FormClosing);
            this.Load += new System.EventHandler(this.FrmMarketing_Load_1);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMktgAllocPI)).EndInit();
            this.cmsPI.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMktgAllocCF)).EndInit();
            this.cmsCF.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMktgAllocMLK)).EndInit();
            this.cmsMLK.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MktgCFBS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MktgMlkBS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MktgPIBS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgvMktgAllocCF;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvMktgAllocMLK;
        private System.Windows.Forms.ComboBox cbxFiscalYear;
        private System.Windows.Forms.DataGridView dgvMktgAllocPI;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblUpdate;
        private System.Windows.Forms.BindingSource MktgCFBS;
        private System.Windows.Forms.BindingSource MktgMlkBS;
        private System.Windows.Forms.BindingSource MktgPIBS;
        private System.Windows.Forms.ContextMenuStrip cmsMLK;
        private System.Windows.Forms.ToolStripMenuItem miCopy;
        private System.Windows.Forms.ToolStripMenuItem miPaste;
        private System.Windows.Forms.ContextMenuStrip cmsPI;
        private System.Windows.Forms.ToolStripMenuItem miPICopy;
        private System.Windows.Forms.ToolStripMenuItem miPIPaste;
        private System.Windows.Forms.ContextMenuStrip cmsCF;
        private System.Windows.Forms.ToolStripMenuItem miCFCopy;
        private System.Windows.Forms.ToolStripMenuItem miCFPaste;
    }
}