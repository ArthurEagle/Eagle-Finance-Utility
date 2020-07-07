namespace Eagle_Finance_Utility
{
    partial class FrmAmortization
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAmortization));
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbxAccount = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxBusArea = new System.Windows.Forms.ComboBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvAmortization = new System.Windows.Forms.DataGridView();
            this.cbxFiscalYear = new System.Windows.Forms.ComboBox();
            this.AmortBS = new System.Windows.Forms.BindingSource(this.components);
            this.label9 = new System.Windows.Forms.Label();
            this.lblUpdate = new System.Windows.Forms.Label();
            this.cmsAmort = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.siCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.siPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAmortization)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AmortBS)).BeginInit();
            this.cmsAmort.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.cbxAccount);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.cbxBusArea);
            this.groupBox3.Controls.Add(this.btnUpdate);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.dgvAmortization);
            this.groupBox3.Controls.Add(this.cbxFiscalYear);
            this.groupBox3.Location = new System.Drawing.Point(10, 11);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(994, 700);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Amortization";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(422, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "GL Account:";
            // 
            // cbxAccount
            // 
            this.cbxAccount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxAccount.FormattingEnabled = true;
            this.cbxAccount.Location = new System.Drawing.Point(492, 19);
            this.cbxAccount.Name = "cbxAccount";
            this.cbxAccount.Size = new System.Drawing.Size(121, 21);
            this.cbxAccount.TabIndex = 9;
            this.cbxAccount.SelectedIndexChanged += new System.EventHandler(this.cbxAccount_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(213, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Business Area:";
            // 
            // cbxBusArea
            // 
            this.cbxBusArea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxBusArea.FormattingEnabled = true;
            this.cbxBusArea.Items.AddRange(new object[] {
            "ALL",
            "MLK",
            "SNK"});
            this.cbxBusArea.Location = new System.Drawing.Point(292, 19);
            this.cbxBusArea.Name = "cbxBusArea";
            this.cbxBusArea.Size = new System.Drawing.Size(121, 21);
            this.cbxBusArea.TabIndex = 7;
            this.cbxBusArea.SelectedIndexChanged += new System.EventHandler(this.cbxBusArea_SelectedIndexChanged);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.Location = new System.Drawing.Point(914, 18);
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
            // dgvAmortization
            // 
            this.dgvAmortization.AllowUserToAddRows = false;
            this.dgvAmortization.AllowUserToDeleteRows = false;
            this.dgvAmortization.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvAmortization.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvAmortization.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAmortization.ContextMenuStrip = this.cmsAmort;
            this.dgvAmortization.Location = new System.Drawing.Point(6, 48);
            this.dgvAmortization.Name = "dgvAmortization";
            this.dgvAmortization.RowHeadersWidth = 51;
            this.dgvAmortization.Size = new System.Drawing.Size(982, 646);
            this.dgvAmortization.TabIndex = 0;
            this.dgvAmortization.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAmortization_CellEndEdit);
            this.dgvAmortization.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvAmortization_DataError);
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
            this.label9.Location = new System.Drawing.Point(775, 714);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(68, 13);
            this.label9.TabIndex = 12;
            this.label9.Text = "Last Update:";
            // 
            // lblUpdate
            // 
            this.lblUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUpdate.AutoSize = true;
            this.lblUpdate.Location = new System.Drawing.Point(848, 714);
            this.lblUpdate.Name = "lblUpdate";
            this.lblUpdate.Size = new System.Drawing.Size(0, 13);
            this.lblUpdate.TabIndex = 11;
            // 
            // cmsAmort
            // 
            this.cmsAmort.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.siCopy,
            this.siPaste});
            this.cmsAmort.Name = "cmsAmort";
            this.cmsAmort.Size = new System.Drawing.Size(181, 70);
            // 
            // siCopy
            // 
            this.siCopy.Name = "siCopy";
            this.siCopy.Size = new System.Drawing.Size(180, 22);
            this.siCopy.Text = "Copy";
            this.siCopy.Click += new System.EventHandler(this.siCopy_Click);
            // 
            // siPaste
            // 
            this.siPaste.Name = "siPaste";
            this.siPaste.Size = new System.Drawing.Size(180, 22);
            this.siPaste.Text = "Paste";
            this.siPaste.Click += new System.EventHandler(this.siPaste_Click);
            // 
            // FrmAmortization
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1015, 739);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lblUpdate);
            this.Controls.Add(this.groupBox3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FrmAmortization";
            this.Text = "Amortization Allocation";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmAmortization_FormClosing);
            this.Load += new System.EventHandler(this.FrmAmortization_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAmortization)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AmortBS)).EndInit();
            this.cmsAmort.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbxBusArea;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvAmortization;
        private System.Windows.Forms.ComboBox cbxFiscalYear;
        private System.Windows.Forms.BindingSource AmortBS;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbxAccount;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblUpdate;
        private System.Windows.Forms.ContextMenuStrip cmsAmort;
        private System.Windows.Forms.ToolStripMenuItem siCopy;
        private System.Windows.Forms.ToolStripMenuItem siPaste;
    }
}