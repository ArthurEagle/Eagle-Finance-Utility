namespace Eagle_Finance_Utility
{
    partial class FrmMainMenu
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnObsolAlloc = new System.Windows.Forms.Button();
            this.btnIPVAmount = new System.Windows.Forms.Button();
            this.btnPPVTime = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnObsolAlloc);
            this.groupBox1.Controls.Add(this.btnIPVAmount);
            this.groupBox1.Controls.Add(this.btnPPVTime);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(403, 310);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // btnObsolAlloc
            // 
            this.btnObsolAlloc.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnObsolAlloc.Location = new System.Drawing.Point(5, 116);
            this.btnObsolAlloc.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnObsolAlloc.Name = "btnObsolAlloc";
            this.btnObsolAlloc.Size = new System.Drawing.Size(389, 90);
            this.btnObsolAlloc.TabIndex = 1;
            this.btnObsolAlloc.Text = "Obsolescence Allocation";
            this.btnObsolAlloc.UseVisualStyleBackColor = true;
            this.btnObsolAlloc.Click += new System.EventHandler(this.btnObsolAlloc_Click);
            // 
            // btnIPVAmount
            // 
            this.btnIPVAmount.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIPVAmount.Location = new System.Drawing.Point(5, 21);
            this.btnIPVAmount.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnIPVAmount.Name = "btnIPVAmount";
            this.btnIPVAmount.Size = new System.Drawing.Size(389, 90);
            this.btnIPVAmount.TabIndex = 0;
            this.btnIPVAmount.Text = "IPV Management";
            this.btnIPVAmount.UseVisualStyleBackColor = true;
            this.btnIPVAmount.Click += new System.EventHandler(this.btnIPVAmount_Click);
            // 
            // btnPPVTime
            // 
            this.btnPPVTime.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPPVTime.Location = new System.Drawing.Point(5, 210);
            this.btnPPVTime.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPPVTime.Name = "btnPPVTime";
            this.btnPPVTime.Size = new System.Drawing.Size(389, 90);
            this.btnPPVTime.TabIndex = 2;
            this.btnPPVTime.Text = "PPV Management";
            this.btnPPVTime.UseVisualStyleBackColor = true;
            this.btnPPVTime.Click += new System.EventHandler(this.btnPPVTime_Click);
            // 
            // FrmMainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 327);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FrmMainMenu";
            this.Text = "Main Menu";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMainMenu_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnObsolAlloc;
        private System.Windows.Forms.Button btnIPVAmount;
        private System.Windows.Forms.Button btnPPVTime;
    }
}