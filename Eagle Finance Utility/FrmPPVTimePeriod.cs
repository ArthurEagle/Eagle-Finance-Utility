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
    public partial class FrmPPVTimePeriod : Form
    {
        public FrmPPVTimePeriod()
        {
            InitializeComponent();
        }
        

        public FrmMainMenu frmMM;
        IList<string> fiscalYears;
      


        private void FrmPPVTimePeriod_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'bPW_PRD_CustomDataSet.EFF_PPV_Period_Management' table. You can move, or remove it, as needed.
            //this.eFF_PPV_Period_ManagementTableAdapter.Fill(this.bPW_PRD_CustomDataSet.EFF_PPV_Period_Management);

            bsPPVTime.DataSource = AppController.DataController.PPVTime;
            dgvPPVTimePeriod.DataSource = bsPPVTime;
            CreateLoadFiscalYearList();
            cbxFiscalYear.SelectedItem = AppController.DataController.CurrentFiscalYear;
            cbxBusArea.SelectedItem = "ALL";
            AddColumns();
            HideColumns();
            ReadOnlyColumns();
            FilterPPVDataGridByFiscalYearAndBusArea(cbxFiscalYear.SelectedItem.ToString(),cbxBusArea.SelectedItem.ToString());
            PopulatePPVAccountList();

        }
        private void ReadOnlyColumns()
        {
            foreach(DataGridViewColumn col in dgvPPVTimePeriod.Columns)
            {
                col.ReadOnly = true;
            }
            dgvPPVTimePeriod.Columns["New Deferment"].ReadOnly = false;
        }
        private void CreateLoadFiscalYearList()
        {
           var yrs = from ppv in AppController.DataController.EFF_CustomDS.Tables["EFF_PPV_Period"].AsEnumerable() 
                     orderby ppv.Field<string>("Sales Period YYYYMM") descending select ppv.Field<string>("Sales Period YYYYMM");


            //Get Max Calendar Year 
            var maxCalPeriod = yrs.Max<string>();
            var maxYear= maxCalPeriod.Substring(0, 4);
            var years = Convert.ToInt32(maxYear) - 2018;

            fiscalYears = new List<string>();
            
            for(int i = 0; i <= years; i++)
            {
                fiscalYears.Add((2018 + i).ToString());
            }

            cbxFiscalYear.DataSource = fiscalYears;

        }

        private void SetPriorPeriodsReadonly()
        {
            
            foreach (DataGridViewRow r in dgvPPVTimePeriod.Rows)
            {
                var sPeriod = Convert.ToInt32(r.Cells["Sales Period YYYYMM"].Value);
                if (sPeriod < Convert.ToInt32(AppController.DataController.CloseYYYYMM))
                {
                    r.ReadOnly = true;
                    r.Cells["Previous Deferment"].Style.BackColor = Color.Gainsboro;
                }
            }
        }

        private void FilterPPVDataGridByFiscalYearAndBusArea(string year,string ba)
        {
            string fromPeriod = (Convert.ToInt32(year) - 1).ToString() + "04";
            string toPeriod = year +"03";



            if(ba == "ALL")
            {
                bsPPVTime.Filter = "[Sales Period YYYYMM] >= '" + fromPeriod + "' AND [Sales Period YYYYMM] <= '" + toPeriod + "'";
              
            }
            else
            {
                bsPPVTime.Filter = "[Sales Period YYYYMM] >= '" + fromPeriod + "' AND [Sales Period YYYYMM] <= '" + toPeriod + "' AND [Business Area] = '" + ba + "'";
            }
            bsPPVTime.Sort = "[FiscalSort] Asc";

            SetPriorPeriodsReadonly();
        }

        private void cbxFiscalYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbxBusArea.SelectedItem != null)
            FilterPPVDataGridByFiscalYearAndBusArea(cbxFiscalYear.SelectedItem.ToString(), cbxBusArea.SelectedItem.ToString());
        }

        private void AddColumns()
        {
      

            DataGridViewComboBoxColumn cbxCol = new DataGridViewComboBoxColumn();
            cbxCol.HeaderText = "New Deferment";
            cbxCol.Items.Add("-3");
            cbxCol.Items.Add("-2");
            cbxCol.Items.Add("-1");
            cbxCol.Items.Add("0");

            dgvPPVTimePeriod.Columns.Add(cbxCol);
            dgvPPVTimePeriod.Columns[""].Name = "New Deferment";


        }

        private void HideColumns()
        {
            dgvPPVTimePeriod.Columns["Update User"].Visible = false;
            dgvPPVTimePeriod.Columns["Update Date"].Visible = false;
            dgvPPVTimePeriod.Columns["PeriodKey"].Visible = false;
            dgvPPVTimePeriod.Columns["ToUpdate"].Visible = false;
            dgvPPVTimePeriod.Columns["FiscalSort"].Visible = false;
        }

        private void PopulatePPVAccountList()
        {   
            if(lbxPPVAccount.Items.Count > 0)
            {
                lbxPPVAccount.Items.Clear();
            }
            foreach(DataRow dr in AppController.DataController.EFF_CustomDS.Tables["EFF_PPV_Account"].Rows)
            {
                var acct = dr["GL Account"].ToString();
                lbxPPVAccount.Items.Add(acct);
               
            }
        }
        private void SetLastUpdateLabelAfterUpdate()
        {
            lblUpdate.Text = Environment.UserName + " " + DateTime.Now.ToString();
        }
        private void dgvPPVTimePeriod_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == dgvPPVTimePeriod.Rows[e.RowIndex].Cells["New Deferment"].ColumnIndex)
            {
                if (dgvPPVTimePeriod.CurrentCell.Value != null)
                {


                    if (dgvPPVTimePeriod.CurrentCell.Value.ToString() != "")
                    {
                        var def = Convert.ToInt32(dgvPPVTimePeriod.CurrentCell.Value);
                        var prevDef = Convert.ToInt32(dgvPPVTimePeriod.Rows[e.RowIndex].Cells["Previous Deferment"].Value);
                        var salesYYYYMM = dgvPPVTimePeriod.Rows[e.RowIndex].Cells["Sales Period YYYYMM"].Value.ToString();
                        var newPeriod = GetNewPPVPeriod(def, salesYYYYMM);
                        dgvPPVTimePeriod.Rows[e.RowIndex].Cells["PPV Period YYYYMM"].Value = newPeriod;

                        if (def != prevDef)
                        {
                            dgvPPVTimePeriod.Rows[e.RowIndex].Cells["ToUpdate"].Value = true;
                        }
                        else
                        {
                            dgvPPVTimePeriod.Rows[e.RowIndex].Cells["ToUpdate"].Value = false;
                        }

                    }
                }
            }
        }

        private void dgvPPVTimePeriod_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dgvPPVTimePeriod_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            DataGridViewColumn col = dgvPPVTimePeriod.Columns[dgvPPVTimePeriod.CurrentCell.ColumnIndex];
            if (col is DataGridViewComboBoxColumn)
            {
                dgvPPVTimePeriod.CommitEdit(DataGridViewDataErrorContexts.Commit);
                DataGridViewCellEventArgs e2 = new DataGridViewCellEventArgs(dgvPPVTimePeriod.CurrentCell.ColumnIndex, dgvPPVTimePeriod.CurrentCell.RowIndex);
                dgvPPVTimePeriod_CellEndEdit(sender, e2);
            }
        }

        private string GetNewPPVPeriod(int deferment,string SalesYYYYMM)
        {
            DateTime currPeriod = new DateTime(Convert.ToInt32(SalesYYYYMM.Substring(0, 4)), Convert.ToInt32(SalesYYYYMM.Substring(4, 2)), 01);
            var newPeriod = currPeriod.AddMonths(deferment).ToString("yyyyMMdd").Substring(0, 6);
            
            return newPeriod;

        }

         private void btnUpdate_Click(object sender, EventArgs e)
        {
            var currFYear = cbxFiscalYear.SelectedItem.ToString();
            var currBA = cbxBusArea.SelectedItem.ToString();

            AppController.DataController.UpdatePPVTimePeriod();
            bsPPVTime.DataSource = AppController.DataController.PPVTime;
            dgvPPVTimePeriod.DataSource = bsPPVTime;
            CreateLoadFiscalYearList();

            SetLastUpdateLabelAfterUpdate();
            HideColumns();
            ReadOnlyColumns();
            FilterPPVDataGridByFiscalYearAndBusArea(cbxFiscalYear.SelectedItem.ToString(), cbxBusArea.SelectedItem.ToString());

            cbxFiscalYear.SelectedItem = currFYear;
            cbxBusArea.SelectedItem = currBA;
        }

        private void cbxBusArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterPPVDataGridByFiscalYearAndBusArea(cbxFiscalYear.SelectedItem.ToString(), cbxBusArea.SelectedItem.ToString());
        }

        private void FrmPPVTimePeriod_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmMM.Show();
        }

        private void btnPPVAccountAdd_Click(object sender, EventArgs e)
        {
            var account = txtPPVAccount.Text;

            if(lbxPPVAccount.Items.Contains(account))
            {
                MessageBox.Show("The GL Account you have entered already exists in the PPV Account List");
            }
            else
            {
                if(!AppController.DataController.InsertNewPPVAccount(account))
                {
                    MessageBox.Show("You have entered an invlaid GL Account");
                }
                else
                {
                    PopulatePPVAccountList();
                }
            }

          
        }
    }
}
