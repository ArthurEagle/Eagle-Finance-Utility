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
    public partial class FrmObsolAlloc : Form
    {
  
        public FrmObsolAlloc()
        {
            InitializeComponent();

          

            cbxFiscalYear.DataSource = AppController.DataController.ObsoFiscalYrsLst.OrderBy(p => p).ToList();
            cbxFiscalYear.SelectedItem = Convert.ToInt32(AppController.DataController.CurrentFiscalYear);
            
        }

        public FrmMainMenu frmMM;

        bool OkToUpdate = false;
        Dictionary<string, bool> MlkColCheck;
        Dictionary<string, bool> SnkColCheck;
        private void LoadDictionary()
        {

        }
        private void cbxFiscalYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            MilkObsoBS.DataSource = AppController.DataController.EFF_ObsoMLKDS.Tables[cbxFiscalYear.SelectedItem.ToString()];
            dgvObsoAllocMLK.DataSource = MilkObsoBS;

         

            SnackObsoBS.DataSource = AppController.DataController.EFF_ObsoSNKDS.Tables[cbxFiscalYear.SelectedItem.ToString()];
            dgvObsoAllocSnk.DataSource = SnackObsoBS;


            MlkColCheck = new Dictionary<string, bool>();
            SnkColCheck = new Dictionary<string, bool>();

            SetPriorPeriodsReadonly(dgvObsoAllocMLK, MlkColCheck);
            SetPriorPeriodsReadonly(dgvObsoAllocSnk, SnkColCheck);
        }


        private void SetPriorPeriodsReadonly(DataGridView dgv, Dictionary<string, bool> ColCheck)
        {
            
            foreach (DataGridViewColumn c in dgv.Columns)
            {
                if(c.Index > 2)
                {
                    var sPeriod = Convert.ToInt32(c.HeaderText);
                    if (sPeriod <= Convert.ToInt32(AppController.DataController.CloseYYYYMM))
                    {
                        c.ReadOnly = true;
                        c.DefaultCellStyle.BackColor = Color.Gainsboro;
                    }
                    else
                    {
                        ColCheck.Add(c.HeaderText, false);
                    }
                }
                else
                {
                    c.ReadOnly = true;
                }               
            }
        }


        private void SumColumnTotal(int colIndex, DataGridView dgv, Dictionary<string, bool> ColCheck)
        {
            //This will only be valid for non-read only cells. Some historical data values sum > 100 as of the time writing this.
            // Valid for Close period and greater YYYYMM
            double total = 0;
           
            foreach (DataGridViewRow row in dgv.Rows)
            {                
                if(row.Cells["Item Level 3"].Value.ToString() != "Total:")
                {
                    double val = 0;
                    if (Double.TryParse(row.Cells[colIndex].Value.ToString(), out val))
                    {
                        total += val;
                    }
                    else
                    {
                        row.Cells[colIndex].Value = 0;
                    }
                }
            }
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.Cells["Item Level 3"].Value.ToString() == "Total:")
                {
                    row.Cells[colIndex].Value = total;
                    if(total != 100)
                    {
                        row.Cells[colIndex].Style.BackColor = Color.Orange;
                        ColCheck[dgv.Columns[colIndex].HeaderText] = false;
                       
                    }
                    else
                    {
                        row.Cells[colIndex].Style.BackColor = Color.LightGreen;
                        ColCheck[dgv.Columns[colIndex].HeaderText] = true;
                    }
                }
            }

        }

        private void CheckColumnTotalAndUpdate(DataGridView dgv, Dictionary<string, bool> ColCheck)
        {
            foreach (KeyValuePair<string, bool> kvp in ColCheck)
            {
                if (kvp.Value)
                {
                    UpdateObsolAllocByPeriod(dgv, kvp.Key);
                }              

            }
        }
        private void UpdateObsolAllocByPeriod(DataGridView dgv,string YYYYMM)
        {
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.Cells["Item Level 3"].Value.ToString() != "Total:")
                {   
                     if (Convert.ToInt32(YYYYMM) >= Convert.ToInt32(AppController.DataController.CloseYYYYMM))
                     {
                        var lvl3Name = row.Cells["Item Level 3"].Value.ToString();
                        var lvl2Name = row.Cells["Item Level 2"].Value.ToString();
                        var busArea = row.Cells["Business Area"].Value.ToString();
                        if(busArea == "MILK")
                        {
                            busArea = "MLK";
                        }
                        else
                        {
                            busArea = "SNK";
                        }
                        var percent = (Convert.ToDouble(row.Cells[YYYYMM].Value) / 100.00).ToString();
                        AppController.DataController.InsertOrUpdateObsolAlloc(YYYYMM, lvl3Name, percent, busArea, lvl2Name);

                     }             

                }
            }
        }
        private bool CheckColumnTotals(Dictionary<string,bool> ColCheck)
        {
            int cnt = 0;
            foreach (KeyValuePair<string, bool> kvp in ColCheck)
            {
                if (!kvp.Value)
                {
                    cnt++;
                }
            }
            if(cnt == 0)
            {
                return true;
            }
            else
            {               
                return false;
            }
        }
        private void UpdateObsoAlloc(DataGridView dgv, Dictionary<string, bool> ColCheck)
        {
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.Cells["Item Level 3"].Value.ToString() != "Total:")
                {
                    foreach(KeyValuePair<string, bool> kvp in ColCheck)
                    {
                        var yyyymm = dgv.Columns[kvp.Key].HeaderText;
                        if (Convert.ToInt32(yyyymm) >= Convert.ToInt32(AppController.DataController.CloseYYYYMM))
                        {
                            var lvl3Name = row.Cells["Item Level 3"].Value.ToString();
                            var lvl2Name = row.Cells["Item Level 2"].Value.ToString();
                            var busArea = row.Cells["Business Area"].Value.ToString();
                            var percent = (Convert.ToDouble(row.Cells[kvp.Key].Value) / 100.00).ToString();
                            AppController.DataController.InsertOrUpdateObsolAlloc(yyyymm, lvl3Name, percent,busArea,lvl2Name);
                           
                        }

                    }

                }
            }
        }

        private void SetLastUpdateLabelAfterUpdate()
        {
            lblUpdate.Text = Environment.UserName + " " + DateTime.Now.ToString();
        }
        private void dgvObsoAllocMLK_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Please enter Allcoation percent as a decimal number. Ex. enter 25.5 for 25.5%.");
        }

        private void dgvObsoAllocSnk_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Please enter Allcoation percent as a decimal number. Ex. enter 25.5 for 25.5%.");
        }

        private void dgvObsoAllocMLK_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            SumColumnTotal(e.ColumnIndex, dgvObsoAllocMLK,MlkColCheck);
        }

        private void dgvObsoAllocSnk_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            SumColumnTotal(e.ColumnIndex, dgvObsoAllocSnk,SnkColCheck);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {           
                CheckColumnTotalAndUpdate(dgvObsoAllocMLK, MlkColCheck);
                SetLastUpdateLabelAfterUpdate();

                CheckColumnTotalAndUpdate(dgvObsoAllocSnk, SnkColCheck);
                SetLastUpdateLabelAfterUpdate();       
            
        }

        private void FrmObsolAlloc_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmMM.Show();
        }
    }
}
