namespace Eagle_Finance_Utility
{
    partial class FrmIPVAmount
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmIPVAmount));
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxBusArea = new System.Windows.Forms.ComboBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvIPVTransaction = new System.Windows.Forms.DataGridView();
            this.cbxFiscalYear = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbxIPVAccount = new System.Windows.Forms.ListBox();
            this.btnIPVAccountAdd = new System.Windows.Forms.Button();
            this.txtIPVAccount = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbxIPVItem = new System.Windows.Forms.ListBox();
            this.btnIPVItemAdd = new System.Windows.Forms.Button();
            this.txtIPVItem = new System.Windows.Forms.TextBox();
            this.AmountBS = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtNewAmount = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnIPVTranAdd = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cbxNewDate = new System.Windows.Forms.ComboBox();
            this.cbxNewAccount = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbxNewItem = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbxNewBusArea = new System.Windows.Forms.ComboBox();
            this.lblUpdate = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIPVTransaction)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AmountBS)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.cbxBusArea);
            this.groupBox3.Controls.Add(this.btnUpdate);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.dgvIPVTransaction);
            this.groupBox3.Controls.Add(this.cbxFiscalYear);
            this.groupBox3.Location = new System.Drawing.Point(16, 15);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Size = new System.Drawing.Size(893, 618);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "IPV Transaction";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(284, 27);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 17);
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
            this.cbxBusArea.Location = new System.Drawing.Point(389, 23);
            this.cbxBusArea.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbxBusArea.Name = "cbxBusArea";
            this.cbxBusArea.Size = new System.Drawing.Size(160, 24);
            this.cbxBusArea.TabIndex = 7;
            this.cbxBusArea.SelectedIndexChanged += new System.EventHandler(this.cbxBusArea_SelectedIndexChanged);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.Location = new System.Drawing.Point(785, 21);
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
            // dgvIPVTransaction
            // 
            this.dgvIPVTransaction.AllowUserToAddRows = false;
            this.dgvIPVTransaction.AllowUserToDeleteRows = false;
            this.dgvIPVTransaction.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvIPVTransaction.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIPVTransaction.Location = new System.Drawing.Point(8, 59);
            this.dgvIPVTransaction.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvIPVTransaction.Name = "dgvIPVTransaction";
            this.dgvIPVTransaction.RowHeadersWidth = 51;
            this.dgvIPVTransaction.Size = new System.Drawing.Size(877, 551);
            this.dgvIPVTransaction.TabIndex = 0;
            this.dgvIPVTransaction.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvIPVTransaction_CellBeginEdit);
            this.dgvIPVTransaction.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvIPVTransaction_CellEndEdit);
            this.dgvIPVTransaction.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvIPVTransaction_CurrentCellDirtyStateChanged);
            this.dgvIPVTransaction.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvIPVTransaction_DataError);
            // 
            // cbxFiscalYear
            // 
            this.cbxFiscalYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxFiscalYear.FormattingEnabled = true;
            this.cbxFiscalYear.Location = new System.Drawing.Point(107, 23);
            this.cbxFiscalYear.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbxFiscalYear.Name = "cbxFiscalYear";
            this.cbxFiscalYear.Size = new System.Drawing.Size(160, 24);
            this.cbxFiscalYear.TabIndex = 1;
            this.cbxFiscalYear.SelectedIndexChanged += new System.EventHandler(this.cbxFiscalYear_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.lbxIPVAccount);
            this.groupBox1.Controls.Add(this.btnIPVAccountAdd);
            this.groupBox1.Controls.Add(this.txtIPVAccount);
            this.groupBox1.Location = new System.Drawing.Point(915, 15);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(339, 340);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "IPV Account";
            // 
            // lbxIPVAccount
            // 
            this.lbxIPVAccount.FormattingEnabled = true;
            this.lbxIPVAccount.ItemHeight = 16;
            this.lbxIPVAccount.Location = new System.Drawing.Point(8, 59);
            this.lbxIPVAccount.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lbxIPVAccount.Name = "lbxIPVAccount";
            this.lbxIPVAccount.Size = new System.Drawing.Size(313, 260);
            this.lbxIPVAccount.TabIndex = 3;
            // 
            // btnIPVAccountAdd
            // 
            this.btnIPVAccountAdd.Location = new System.Drawing.Point(223, 27);
            this.btnIPVAccountAdd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnIPVAccountAdd.Name = "btnIPVAccountAdd";
            this.btnIPVAccountAdd.Size = new System.Drawing.Size(100, 28);
            this.btnIPVAccountAdd.TabIndex = 1;
            this.btnIPVAccountAdd.Text = "Add";
            this.btnIPVAccountAdd.UseVisualStyleBackColor = true;
            this.btnIPVAccountAdd.Click += new System.EventHandler(this.btnIPVAccountAdd_Click);
            // 
            // txtIPVAccount
            // 
            this.txtIPVAccount.Location = new System.Drawing.Point(8, 27);
            this.txtIPVAccount.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtIPVAccount.Name = "txtIPVAccount";
            this.txtIPVAccount.Size = new System.Drawing.Size(205, 22);
            this.txtIPVAccount.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.lbxIPVItem);
            this.groupBox2.Controls.Add(this.btnIPVItemAdd);
            this.groupBox2.Controls.Add(this.txtIPVItem);
            this.groupBox2.Location = new System.Drawing.Point(917, 362);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(339, 368);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "IPV Item";
            // 
            // lbxIPVItem
            // 
            this.lbxIPVItem.FormattingEnabled = true;
            this.lbxIPVItem.ItemHeight = 16;
            this.lbxIPVItem.Location = new System.Drawing.Point(8, 59);
            this.lbxIPVItem.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lbxIPVItem.Name = "lbxIPVItem";
            this.lbxIPVItem.Size = new System.Drawing.Size(313, 292);
            this.lbxIPVItem.TabIndex = 3;
            // 
            // btnIPVItemAdd
            // 
            this.btnIPVItemAdd.Location = new System.Drawing.Point(223, 27);
            this.btnIPVItemAdd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnIPVItemAdd.Name = "btnIPVItemAdd";
            this.btnIPVItemAdd.Size = new System.Drawing.Size(100, 28);
            this.btnIPVItemAdd.TabIndex = 1;
            this.btnIPVItemAdd.Text = "Add";
            this.btnIPVItemAdd.UseVisualStyleBackColor = true;
            this.btnIPVItemAdd.Click += new System.EventHandler(this.btnIPVItemAdd_Click);
            // 
            // txtIPVItem
            // 
            this.txtIPVItem.Location = new System.Drawing.Point(8, 27);
            this.txtIPVItem.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtIPVItem.Name = "txtIPVItem";
            this.txtIPVItem.Size = new System.Drawing.Size(205, 22);
            this.txtIPVItem.TabIndex = 2;
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.txtNewAmount);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.btnIPVTranAdd);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.cbxNewDate);
            this.groupBox4.Controls.Add(this.cbxNewAccount);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.cbxNewItem);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.cbxNewBusArea);
            this.groupBox4.Location = new System.Drawing.Point(16, 640);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox4.Size = new System.Drawing.Size(893, 90);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "New IPV Transaction";
            // 
            // txtNewAmount
            // 
            this.txtNewAmount.Location = new System.Drawing.Point(639, 43);
            this.txtNewAmount.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtNewAmount.Name = "txtNewAmount";
            this.txtNewAmount.Size = new System.Drawing.Size(132, 22);
            this.txtNewAmount.TabIndex = 19;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(635, 22);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 17);
            this.label7.TabIndex = 18;
            this.label7.Text = "IPV Amount:";
            // 
            // btnIPVTranAdd
            // 
            this.btnIPVTranAdd.Location = new System.Drawing.Point(785, 39);
            this.btnIPVTranAdd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnIPVTranAdd.Name = "btnIPVTranAdd";
            this.btnIPVTranAdd.Size = new System.Drawing.Size(100, 28);
            this.btnIPVTranAdd.TabIndex = 17;
            this.btnIPVTranAdd.Text = "Add";
            this.btnIPVTranAdd.UseVisualStyleBackColor = true;
            this.btnIPVTranAdd.Click += new System.EventHandler(this.btnIPVTranAdd_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(471, 22);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(140, 17);
            this.label5.TabIndex = 16;
            this.label5.Text = "Calendar YYYYYMM:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(296, 22);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 17);
            this.label6.TabIndex = 15;
            this.label6.Text = "GL Account:";
            // 
            // cbxNewDate
            // 
            this.cbxNewDate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxNewDate.FormattingEnabled = true;
            this.cbxNewDate.Items.AddRange(new object[] {
            "ALL",
            "MLK",
            "SNK"});
            this.cbxNewDate.Location = new System.Drawing.Point(469, 43);
            this.cbxNewDate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbxNewDate.Name = "cbxNewDate";
            this.cbxNewDate.Size = new System.Drawing.Size(160, 24);
            this.cbxNewDate.TabIndex = 14;
            // 
            // cbxNewAccount
            // 
            this.cbxNewAccount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxNewAccount.FormattingEnabled = true;
            this.cbxNewAccount.Location = new System.Drawing.Point(300, 42);
            this.cbxNewAccount.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbxNewAccount.Name = "cbxNewAccount";
            this.cbxNewAccount.Size = new System.Drawing.Size(160, 24);
            this.cbxNewAccount.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 22);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 17);
            this.label3.TabIndex = 12;
            this.label3.Text = "Business Area:";
            // 
            // cbxNewItem
            // 
            this.cbxNewItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxNewItem.FormattingEnabled = true;
            this.cbxNewItem.Items.AddRange(new object[] {
            "ALL",
            "MLK",
            "SNK"});
            this.cbxNewItem.Location = new System.Drawing.Point(131, 43);
            this.cbxNewItem.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbxNewItem.Name = "cbxNewItem";
            this.cbxNewItem.Size = new System.Drawing.Size(160, 24);
            this.cbxNewItem.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(127, 22);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 17);
            this.label4.TabIndex = 10;
            this.label4.Text = "Item Number:";
            // 
            // cbxNewBusArea
            // 
            this.cbxNewBusArea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxNewBusArea.FormattingEnabled = true;
            this.cbxNewBusArea.Items.AddRange(new object[] {
            "MLK",
            "SNK"});
            this.cbxNewBusArea.Location = new System.Drawing.Point(20, 42);
            this.cbxNewBusArea.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbxNewBusArea.Name = "cbxNewBusArea";
            this.cbxNewBusArea.Size = new System.Drawing.Size(97, 24);
            this.cbxNewBusArea.TabIndex = 9;
            // 
            // lblUpdate
            // 
            this.lblUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUpdate.AutoSize = true;
            this.lblUpdate.Location = new System.Drawing.Point(1012, 736);
            this.lblUpdate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUpdate.Name = "lblUpdate";
            this.lblUpdate.Size = new System.Drawing.Size(0, 17);
            this.lblUpdate.TabIndex = 5;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(913, 736);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(89, 17);
            this.label9.TabIndex = 6;
            this.label9.Text = "Last Update:";
            // 
            // FrmIPVAmount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1269, 763);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lblUpdate);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FrmIPVAmount";
            this.Text = "IPV Management";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmIPVAmount_FormClosing);
            this.Load += new System.EventHandler(this.FrmIPVAmount_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIPVTransaction)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AmountBS)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvIPVTransaction;
        private System.Windows.Forms.ComboBox cbxFiscalYear;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox lbxIPVAccount;
        private System.Windows.Forms.Button btnIPVAccountAdd;
        private System.Windows.Forms.TextBox txtIPVAccount;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox lbxIPVItem;
        private System.Windows.Forms.Button btnIPVItemAdd;
        private System.Windows.Forms.TextBox txtIPVItem;
        private System.Windows.Forms.BindingSource AmountBS;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbxBusArea;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtNewAmount;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnIPVTranAdd;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbxNewDate;
        private System.Windows.Forms.ComboBox cbxNewAccount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbxNewItem;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbxNewBusArea;
        private System.Windows.Forms.Label lblUpdate;
        private System.Windows.Forms.Label label9;
    }
}