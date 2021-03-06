﻿namespace Eagle_Finance_Utility
{
    partial class FrmPPVTimePeriod
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPPVTimePeriod));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbxPPVAccount = new System.Windows.Forms.ListBox();
            this.btnPPVAccountAdd = new System.Windows.Forms.Button();
            this.txtPPVAccount = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxBusArea = new System.Windows.Forms.ComboBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvPPVTimePeriod = new System.Windows.Forms.DataGridView();
            this.cbxFiscalYear = new System.Windows.Forms.ComboBox();
            this.bPW_PRD_CustomDataSet = new Eagle_Finance_Utility.BPW_PRD_CustomDataSet();
            this.eFFPPVPeriodManagementBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.eFF_PPV_Period_ManagementTableAdapter = new Eagle_Finance_Utility.BPW_PRD_CustomDataSetTableAdapters.EFF_PPV_Period_ManagementTableAdapter();
            this.bsPPVTime = new System.Windows.Forms.BindingSource(this.components);
            this.label9 = new System.Windows.Forms.Label();
            this.lblUpdate = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPPVTimePeriod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bPW_PRD_CustomDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eFFPPVPeriodManagementBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsPPVTime)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.lbxPPVAccount);
            this.groupBox1.Controls.Add(this.btnPPVAccountAdd);
            this.groupBox1.Controls.Add(this.txtPPVAccount);
            this.groupBox1.Location = new System.Drawing.Point(916, 17);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(331, 775);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "PPV Account";
            // 
            // lbxPPVAccount
            // 
            this.lbxPPVAccount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbxPPVAccount.FormattingEnabled = true;
            this.lbxPPVAccount.ItemHeight = 16;
            this.lbxPPVAccount.Location = new System.Drawing.Point(8, 59);
            this.lbxPPVAccount.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lbxPPVAccount.Name = "lbxPPVAccount";
            this.lbxPPVAccount.Size = new System.Drawing.Size(313, 708);
            this.lbxPPVAccount.TabIndex = 3;
            // 
            // btnPPVAccountAdd
            // 
            this.btnPPVAccountAdd.Location = new System.Drawing.Point(223, 27);
            this.btnPPVAccountAdd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPPVAccountAdd.Name = "btnPPVAccountAdd";
            this.btnPPVAccountAdd.Size = new System.Drawing.Size(100, 28);
            this.btnPPVAccountAdd.TabIndex = 1;
            this.btnPPVAccountAdd.Text = "Add";
            this.btnPPVAccountAdd.UseVisualStyleBackColor = true;
            this.btnPPVAccountAdd.Click += new System.EventHandler(this.btnPPVAccountAdd_Click);
            // 
            // txtPPVAccount
            // 
            this.txtPPVAccount.Location = new System.Drawing.Point(8, 27);
            this.txtPPVAccount.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPPVAccount.Name = "txtPPVAccount";
            this.txtPPVAccount.Size = new System.Drawing.Size(205, 22);
            this.txtPPVAccount.TabIndex = 2;
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
            this.groupBox3.Controls.Add(this.dgvPPVTimePeriod);
            this.groupBox3.Controls.Add(this.cbxFiscalYear);
            this.groupBox3.Location = new System.Drawing.Point(16, 15);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Size = new System.Drawing.Size(892, 778);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "PPV Time Period";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(291, 27);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 17);
            this.label2.TabIndex = 6;
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
            this.cbxBusArea.Location = new System.Drawing.Point(396, 23);
            this.cbxBusArea.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbxBusArea.Name = "cbxBusArea";
            this.cbxBusArea.Size = new System.Drawing.Size(160, 24);
            this.cbxBusArea.TabIndex = 5;
            this.cbxBusArea.SelectedIndexChanged += new System.EventHandler(this.cbxBusArea_SelectedIndexChanged);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.Location = new System.Drawing.Point(785, 23);
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
            // dgvPPVTimePeriod
            // 
            this.dgvPPVTimePeriod.AllowUserToAddRows = false;
            this.dgvPPVTimePeriod.AllowUserToDeleteRows = false;
            this.dgvPPVTimePeriod.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPPVTimePeriod.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPPVTimePeriod.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvPPVTimePeriod.Location = new System.Drawing.Point(8, 59);
            this.dgvPPVTimePeriod.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvPPVTimePeriod.Name = "dgvPPVTimePeriod";
            this.dgvPPVTimePeriod.RowHeadersWidth = 51;
            this.dgvPPVTimePeriod.Size = new System.Drawing.Size(876, 710);
            this.dgvPPVTimePeriod.TabIndex = 0;
            this.dgvPPVTimePeriod.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPPVTimePeriod_CellClick);
            this.dgvPPVTimePeriod.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPPVTimePeriod_CellEndEdit);
            this.dgvPPVTimePeriod.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvPPVTimePeriod_CurrentCellDirtyStateChanged);
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
            // bPW_PRD_CustomDataSet
            // 
            this.bPW_PRD_CustomDataSet.DataSetName = "BPW_PRD_CustomDataSet";
            this.bPW_PRD_CustomDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // eFFPPVPeriodManagementBindingSource
            // 
            this.eFFPPVPeriodManagementBindingSource.DataMember = "EFF_PPV_Period_Management";
            this.eFFPPVPeriodManagementBindingSource.DataSource = this.bPW_PRD_CustomDataSet;
            // 
            // eFF_PPV_Period_ManagementTableAdapter
            // 
            this.eFF_PPV_Period_ManagementTableAdapter.ClearBeforeFill = true;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(912, 796);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(89, 17);
            this.label9.TabIndex = 8;
            this.label9.Text = "Last Update:";
            // 
            // lblUpdate
            // 
            this.lblUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUpdate.AutoSize = true;
            this.lblUpdate.Location = new System.Drawing.Point(1011, 796);
            this.lblUpdate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUpdate.Name = "lblUpdate";
            this.lblUpdate.Size = new System.Drawing.Size(0, 17);
            this.lblUpdate.TabIndex = 7;
            // 
            // FrmPPVTimePeriod
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1259, 823);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lblUpdate);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FrmPPVTimePeriod";
            this.Text = "PPV Management";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmPPVTimePeriod_FormClosing);
            this.Load += new System.EventHandler(this.FrmPPVTimePeriod_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPPVTimePeriod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bPW_PRD_CustomDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eFFPPVPeriodManagementBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsPPVTime)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox lbxPPVAccount;
        private System.Windows.Forms.Button btnPPVAccountAdd;
        private System.Windows.Forms.TextBox txtPPVAccount;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvPPVTimePeriod;
        private System.Windows.Forms.ComboBox cbxFiscalYear;
        private BPW_PRD_CustomDataSet bPW_PRD_CustomDataSet;
        private System.Windows.Forms.BindingSource eFFPPVPeriodManagementBindingSource;
        private BPW_PRD_CustomDataSetTableAdapters.EFF_PPV_Period_ManagementTableAdapter eFF_PPV_Period_ManagementTableAdapter;
        private System.Windows.Forms.BindingSource bsPPVTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbxBusArea;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblUpdate;
    }
}