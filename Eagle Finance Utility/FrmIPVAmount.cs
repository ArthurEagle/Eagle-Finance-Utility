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
    public partial class FrmIPVAmount : Form
    {
        public FrmIPVAmount()
        {
            InitializeComponent();
        }

        public FrmMainMenu frmMM;
        IList<string> fiscalYears;
        IList<string> ipvAccts;
        IList<string> ipvItems;
        IList<string> ipvDates;
        decimal currAmount;
        private void FrmIPVAmount_Load(object sender, EventArgs e)
        {
            AmountBS.DataSource = AppController.DataController.IPVAmount;
            dgvIPVTransaction.DataSource = AmountBS;
            
          
            CreateLoadFiscalYearList();
            cbxFiscalYear.SelectedItem = AppController.DataController.CurrentFiscalYear;
            cbxBusArea.SelectedItem = "ALL";

            HideColumns();
            ReadOnlyColumns();

            PopulateIPVAccountList();
            PopulateIPVItemList();
            PopulateCalendarYYYYMMBox();

            cbxNewBusArea.SelectedIndex = 0;
            
        }

        private void PopulateIPVAccountList()
        {
            ipvAccts = new List<string>();
            if (lbxIPVAccount.Items.Count > 0)
            {
                lbxIPVAccount.Items.Clear();
            }
            foreach (DataRow dr in AppController.DataController.EFF_CustomDS.Tables["EFF_IPV_Account"].Rows)
            {
                var acct = dr["GL Account"].ToString();
                ipvAccts.Add(acct);
            }
            lbxIPVAccount.DataSource = ipvAccts;
            cbxNewAccount.DataSource = ipvAccts;
        }

        private void PopulateIPVItemList()
        {
            ipvItems = new List<string>();
            if (lbxIPVItem.Items.Count > 0)
            {
                lbxIPVItem.Items.Clear();
            }
            foreach (DataRow dr in AppController.DataController.EFF_CustomDS.Tables["EFF_IPV_Item"].Rows)
            {
                var item = dr["Item"].ToString();
                ipvItems.Add(item);
            }
            lbxIPVItem.DataSource = ipvItems;
            cbxNewItem.DataSource = ipvItems;
        }

        private void PopulateCalendarYYYYMMBox()
        {
            ipvDates = new List<string>();
             
            var closePer = AppController.DataController.CloseYYYYMM;

            var year = Convert.ToInt32(closePer.Substring(0, 4));
            var month = Convert.ToInt32(closePer.Substring(4, 2));

            var closeDate = new DateTime(year, month, 1);

            for(int i = 1; i <12;i ++)
            {
                var newDate = closeDate.AddMonths(i);
                var newYr = newDate.Year.ToString();
                var newMn = newDate.Month.ToString();

                if(newMn.Length == 1)
                {
                    newMn = "0" + newMn;
                }

                ipvDates.Add(newYr + newMn);
            }
            cbxNewDate.DataSource = ipvDates;

        }
        private void HideColumns()
        {
            dgvIPVTransaction.Columns["AmountKey"].Visible = false;
            dgvIPVTransaction.Columns["Update Date"].Visible = false;
            dgvIPVTransaction.Columns["Update User"].Visible = false;
            dgvIPVTransaction.Columns["ToUpdate"].Visible = false;
            dgvIPVTransaction.Columns["FiscalSort"].Visible = false;
        }

        private void ReadOnlyColumns()
        {
            foreach (DataGridViewColumn col in dgvIPVTransaction.Columns)
            {
                col.ReadOnly = true;
            }
            dgvIPVTransaction.Columns["Recorded Amount"].ReadOnly = false;
        }

        private void SetPriorPeriodsReadonly()
        {

            foreach (DataGridViewRow r in dgvIPVTransaction.Rows)
            {
                var sPeriod = Convert.ToInt32(r.Cells["YYYYMM"].Value);
                if (sPeriod < Convert.ToInt32(AppController.DataController.CloseYYYYMM))
                {
                    r.ReadOnly = true;
                    r.Cells["Recorded Amount"].Style.BackColor = Color.Gainsboro;
                }
            }
        }
        private void CreateLoadFiscalYearList()
        {
            var yrs = from ppv in AppController.DataController.EFF_CustomDS.Tables["EFF_IPV_Amount"].AsEnumerable()
                      orderby ppv.Field<string>("YYYYMM") descending
                      select ppv.Field<string>("YYYYMM");


            //Get Max Calendar Year 
            var maxCalPeriod = yrs.Max<string>();
            var maxYear = maxCalPeriod.Substring(0, 4);
            var years = Convert.ToInt32(maxYear) - 2018;

            fiscalYears = new List<string>();

            for (int i = 0; i <= years + 1; i++)
            {
                fiscalYears.Add((2018 + i).ToString());
            }

            cbxFiscalYear.DataSource = fiscalYears;

        }
        private void FilterIPVDataGridByFiscalYearAndBusArea(string year, string ba)
        {
            string fromPeriod = (Convert.ToInt32(year) - 1).ToString() + "04";
            string toPeriod = year + "03";



            if (ba == "ALL")
            {
                AmountBS.Filter = "[YYYYMM] >= '" + fromPeriod + "' AND [YYYYMM] <= '" + toPeriod + "'";

            }
            else
            {
                AmountBS.Filter = "[YYYYMM] >= '" + fromPeriod + "' AND [YYYYMM] <= '" + toPeriod + "' AND [Business Area] = '" + ba + "'";
            }
            AmountBS.Sort = "[FiscalSort] Asc";

            SetPriorPeriodsReadonly();
        }

        private void ClearToUpdateAfterUpdate()
        {
            foreach(DataGridViewRow row in dgvIPVTransaction.Rows)
            {
                row.Cells["ToUpdate"].Value = false;
            }
        }

        private void SetLastUpdateLabelAfterUpdate()
        {
            lblUpdate.Text = Environment.UserName + " " + DateTime.Now.ToString();
        }
        private void cbxFiscalYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxBusArea.SelectedItem != null)
                FilterIPVDataGridByFiscalYearAndBusArea(cbxFiscalYear.SelectedItem.ToString(), cbxBusArea.SelectedItem.ToString());
        }

        private void cbxBusArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxFiscalYear.SelectedItem != null)
                FilterIPVDataGridByFiscalYearAndBusArea(cbxFiscalYear.SelectedItem.ToString(), cbxBusArea.SelectedItem.ToString());
        }

        private void dgvIPVTransaction_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
           
            var newAMount = Convert.ToDecimal(dgvIPVTransaction.CurrentCell.Value);
            dgvIPVTransaction.Rows[e.RowIndex].Cells["ToUpdate"].Value = true;

        }

        private void dgvIPVTransaction_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            currAmount  = Convert.ToDecimal(dgvIPVTransaction.CurrentCell.Value);
        }

        private void dgvIPVTransaction_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            
        }

        private void dgvIPVTransaction_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
                MessageBox.Show("Please enter a decimal value");           
           
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var currFYear = cbxFiscalYear.SelectedItem.ToString();
            var currBA = cbxBusArea.SelectedItem.ToString();
            
            AppController.DataController.UpdateIPVAmountTable();

            SetLastUpdateLabelAfterUpdate();
            dgvIPVTransaction.DataSource = AmountBS;
            CreateLoadFiscalYearList();
            ClearToUpdateAfterUpdate();

            HideColumns();
            ReadOnlyColumns();
            FilterIPVDataGridByFiscalYearAndBusArea(cbxFiscalYear.SelectedItem.ToString(), cbxBusArea.SelectedItem.ToString());

            cbxFiscalYear.SelectedItem = currFYear;
            cbxBusArea.SelectedItem = currBA;


        }

        private void btnIPVAccountAdd_Click(object sender, EventArgs e)
        {
            var account = txtIPVAccount.Text;

            if (lbxIPVAccount.Items.Contains(account))
            {
                MessageBox.Show("The GL Account you have entered already exists in the IPV Account List");
            }
            else
            {
                if (!AppController.DataController.InsertNewIPVAccount(account))
                {
                    MessageBox.Show("You have etered an invlaid GL Account");
                }
                else
                {
                    PopulateIPVAccountList();
                }
            }
        }

        private void btnIPVItemAdd_Click(object sender, EventArgs e)
        {
            var item = txtIPVItem.Text;

            if (lbxIPVItem.Items.Contains(item))
            {
                MessageBox.Show("The Item Number you have entered already exists in the IPV Item List");
            }
            else
            {
                if (!AppController.DataController.InsertNewIPVItem(item))
                {
                    MessageBox.Show("You have entered an invlaid Item Number");
                }
                else
                {
                    PopulateIPVItemList();
                }
            }
        }

        private void FrmIPVAmount_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmMM.Show();
        }

        private void btnIPVTranAdd_Click(object sender, EventArgs e)
        {
            decimal amt = 0;
            if(decimal.TryParse(txtNewAmount.Text,out amt))
            {
                var ba = cbxNewBusArea.SelectedItem.ToString();
                var item = cbxNewItem.SelectedItem.ToString();
                var account = cbxNewAccount.SelectedItem.ToString();
                var date = cbxNewDate.SelectedItem.ToString();

                if(!AppController.DataController.InsertNewIPVTransaction(amt,ba,item,account,date))
                {
                    MessageBox.Show("There is already a matching record for this period. Please update the Recorded Amount"); ;
                }
                else
                {
                    var currFYear = cbxFiscalYear.SelectedItem.ToString();
                    var currBA = cbxBusArea.SelectedItem.ToString();

                    SetLastUpdateLabelAfterUpdate();
                    CreateLoadFiscalYearList();
                    ClearToUpdateAfterUpdate();

                    HideColumns();
                    ReadOnlyColumns();
                    FilterIPVDataGridByFiscalYearAndBusArea(cbxFiscalYear.SelectedItem.ToString(), cbxBusArea.SelectedItem.ToString());

                    cbxFiscalYear.SelectedItem = currFYear;
                    cbxBusArea.SelectedItem = currBA;
                }
            }
            else
            {
                MessageBox.Show("Please enter a decimal value");
            }
        }
    }
}
