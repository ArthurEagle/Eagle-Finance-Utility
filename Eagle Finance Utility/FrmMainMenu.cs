using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eagle_Finance_Utility
{
    public partial class FrmMainMenu : Form
    {
        public FrmMainMenu()
        {
            InitializeComponent();
        }

        FrmIPVAmount frmIPV;
        FrmPPVTimePeriod frmPPV;
        FrmObsolAlloc frmObsol;
        private void button1_Click(object sender, EventArgs e)
        {
            //NOT USED
        }

        private void btnPPVTime_Click(object sender, EventArgs e)
        {
            frmPPV = new FrmPPVTimePeriod();
            frmPPV.frmMM = this;
            frmPPV.Show();
            this.Hide();
        }

        private void btnIPVAccount_Click(object sender, EventArgs e)
        {
            //NOT USED
        }

        private void btnIPVAmount_Click(object sender, EventArgs e)
        {
            frmIPV = new FrmIPVAmount();
            frmIPV.frmMM = this;
            frmIPV.Show();
            this.Hide();
        }

        private void btnObsolAlloc_Click(object sender, EventArgs e)
        {


            frmObsol = new FrmObsolAlloc();
            frmObsol.frmMM = this;
            frmObsol.Show();
            this.Hide();
        }

        private void FrmMainMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
