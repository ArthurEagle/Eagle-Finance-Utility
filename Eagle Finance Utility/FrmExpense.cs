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
    public partial class FrmExpense : Form
    {
        public FrmExpense()
        {
            InitializeComponent();
        }

        public FrmMainMenu frmMM;

        Dictionary<string, bool> ColCheck;

        private void SumColumnTotal(int colIndex)
        {
            //This will only be valid for non-read only cells. Some historical data values sum > 100 as of the time writing this.
            // Valid for Close period and greater YYYYMM
            double total = 0;

            foreach (DataGridViewRow row in dgvExpense.Rows)
            {
                if (row.Cells["LevelID"].Value.ToString() != "Total:")
                {
                    double val = 0;
                    if (Double.TryParse(row.Cells[colIndex].Value.ToString(), out val) && row.Cells[colIndex].ReadOnly == false)
                    {
                        total += val;
                    }
                    else
                    {
                        row.Cells[colIndex].Value = 0;
                    }
                }
            }
            foreach (DataGridViewRow row in dgvExpense.Rows)
            {
                if (row.Cells["LevelID"].Value.ToString() == "Total:")
                {
                    row.Cells[colIndex].Value = total;
                    if (total != 100)
                    {
                        row.Cells[colIndex].Style.BackColor = Color.Orange;
                        ColCheck[dgvExpense.Columns[colIndex].HeaderText] = false;

                    }
                    else
                    {
                        row.Cells[colIndex].Style.BackColor = Color.LightGreen;
                        ColCheck[dgvExpense.Columns[colIndex].HeaderText] = true;
                    }
                }
            }

        }
        private void SumAllColumns()
        {
            for (int i = 2; i < 14; i++)
            {
                if (Convert.ToInt32(dgvExpense.Columns[i].HeaderText) >= Convert.ToInt32(AppController.DataController.CloseYYYYMM))
                {
                    SumColumnTotal(i);
                }

            }
        }
        private void CopyClipboard(DataGridView dgv)
        {
            DataObject d = dgv.GetClipboardContent();
            Clipboard.SetDataObject(d);
        }
        private void PasteClipboard(DataGridView dgv)
        {
            try
            {
                string s = Clipboard.GetText();
                string[] lines = s.Split('\n');
                int iFail = 0, iRow = dgv.CurrentCell.RowIndex;
                int iCol = dgv.CurrentCell.ColumnIndex;
                DataGridViewCell oCell;
                foreach (string line in lines)
                {
                    if (iRow < dgv.RowCount && line.Length > 0)
                    {
                        string[] sCells = line.Split('\t');
                        for (int i = 0; i < sCells.GetLength(0); ++i)
                        {
                            if (iCol + i < dgv.ColumnCount)
                            {
                                oCell = dgv[iCol + i, iRow];
                                if (!oCell.ReadOnly)
                                {
                                    if (oCell.Value.ToString() != sCells[i])
                                    {
                                        oCell.Value = Convert.ChangeType(sCells[i],
                                                              oCell.ValueType);

                                    }
                                    else
                                        iFail++;
                                    //only traps a fail if the data has changed 
                                    //and you are pasting into a read only cell
                                }
                            }
                            else
                            { break; }
                        }
                        iRow++;
                    }
                    else
                    { break; }
                    if (iFail > 0)
                        MessageBox.Show(string.Format("{0} updates failed due" +
                                        " to read only column setting", iFail));
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("The data you pasted is in the wrong format for the cell");
                return;
            }
        }
        private void SetTotalRowReadOnly(DataGridView dgv)
        {
            foreach (DataGridViewRow r in dgv.Rows)
            {
                if (r.Cells["LevelID"].Value.ToString() == "Total:")
                {
                    r.ReadOnly = true;
                }
            }
        }
        private void SetPriorPeriodsReadonly()
        {

            foreach (DataGridViewColumn c in dgvExpense.Columns)
            {
                if (c.Index >= 2)
                {
                    var sPeriod = Convert.ToInt32(c.HeaderText);
                    if (sPeriod < Convert.ToInt32(AppController.DataController.CloseYYYYMM))
                    {
                        c.ReadOnly = true;
                        c.DefaultCellStyle.BackColor = Color.Gainsboro;
                    }
                }
                else
                {
                    c.ReadOnly = true;
                }
            }
        }
        private void LoadDgvByYear(string year)
        {
            ExpenseBS.DataSource = AppController.DataController.EFF_ExpenseDS.Tables[year];
            dgvExpense.DataSource = ExpenseBS;
        }

        private void CheckColumnTotalAndUpdate()
        {
            int cnt = 0;
            foreach (KeyValuePair<string, bool> kvp in ColCheck)
            {
                if (kvp.Value)
                {
                    cnt++;
                    UpdateExpenseAllocByPeriod(kvp.Key);
                }

            }
            if (cnt > 0)
            {
                AppController.DataController.RefreshExpenseAllocData();
            }
        }

        private void UpdateExpenseAllocByPeriod(string YYYYMM)
        {
            foreach (DataGridViewRow row in dgvExpense.Rows)
            {
                if (row.Cells["LevelID"].Value.ToString() != "Total:")
                {
                    if (dgvExpense.Columns.Contains(YYYYMM))
                    {
                        if (Convert.ToInt32(YYYYMM) >= Convert.ToInt32(AppController.DataController.CloseYYYYMM))
                        {

                            if (Convert.ToDouble(row.Cells[YYYYMM].Value) > 0)
                            {
                                var lvl = row.Cells["LevelID"].Value.ToString();
                                var busArea = row.Cells["Business Area"].Value.ToString();

                                var percent = (Convert.ToDouble(row.Cells[YYYYMM].Value) / 100.00).ToString();
                                AppController.DataController.InsertOrUpdateExpenseAlloc(YYYYMM, lvl, percent, busArea);
                            }

                        }
                    }

                }
            }
        }

        private void SetLastUpdateLabelAfterUpdate()
        {
            lblUpdate.Text = Environment.UserName + " " + DateTime.Now.ToString();
        }

        private bool CheckCostCenterNumericAndLength(string costCtr)
        {
            int err = 0;

            int cc;
            if(!Int32.TryParse(costCtr, out cc))
            {
                err++;
            }

            if(costCtr.Length != 4)
            {
                err++;
            }

            if(err > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        private bool CheckCostCenterFiscalYearBusAreaNotExist(string costCtr, string fiscalYear, string levelID)
        {
            var res = AppController.DataController.EFF_CustomDS.Tables["EFF_OneTimeMap"].Select("CostCenterID = '" + costCtr + "' AND FiscalYear  = '" + fiscalYear + "' AND LevelID = '" + levelID + "'");
            if(res.Length > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        private void FrmExpense_Load(object sender, EventArgs e)
        {
            ColCheck = new Dictionary<string, bool>();

            cbxFiscalYear.DataSource = AppController.DataController.ExpFiscalYrsLst.OrderBy(p => p).ToList();
            cbxFiscalYear.SelectedItem = Convert.ToInt32(AppController.DataController.CurrentFiscalYear);

            OneTimeBS.DataSource = AppController.DataController.EFF_CustomDS.Tables["EFF_OneTimeMap"];
            dgvOneTime.DataSource = OneTimeBS;

            cbxFiscalYearMap.DataSource = AppController.DataController.OneTimeFiscalYearLst.OrderBy(p => p).ToList();
            cbxLevel.DataSource = AppController.DataController.ExpLevelLst.OrderBy(p => p).ToList();
            cbxCostCenter.DataSource = AppController.DataController.CostCenterLst.OrderBy(p => p).ToList();

            cbxFiscalYearMap.SelectedIndex = 0;
            cbxLevel.SelectedIndex = 0;
        }

        private void cbxFiscalYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxFiscalYear.SelectedItem != null)
            {
                LoadDgvByYear(cbxFiscalYear.SelectedItem.ToString());
               
                SetPriorPeriodsReadonly();
                SetTotalRowReadOnly(dgvExpense);
            }
        }

        private void dgvExpense_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Please end allocation percent as a decimal number. Example: %25.5 as 25.5");
        }

        private void FrmExpense_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmMM.Show();
        }

        private void dgvExpense_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            double pct;
            if (double.TryParse(dgvExpense.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(), out pct))
            {
                if (pct < 0)
                {
                    MessageBox.Show("Percents must be non-negative.");
                    dgvExpense.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "0";                  
                }
                SumColumnTotal(e.ColumnIndex);
            }
            
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            CheckColumnTotalAndUpdate();
            SetLastUpdateLabelAfterUpdate();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(CheckCostCenterNumericAndLength(cbxCostCenter.Text))
            {
                var cc = cbxCostCenter.Text;
                var fy = cbxFiscalYearMap.SelectedItem.ToString();
                var lvl = cbxLevel.SelectedItem.ToString();

                if (CheckCostCenterFiscalYearBusAreaNotExist(cc,fy,lvl))
                {
                    var res = AppController.DataController.ExpenseLevelDT.Select("LevelID = '" + lvl + "'");
                    var lvlKey = res[0]["LevelKey"].ToString();
                    AppController.DataController.InsertOneTimeMapping(fy, lvlKey, cc);
                    SetLastUpdateLabelAfterUpdate();

                    OneTimeBS.DataSource = AppController.DataController.EFF_CustomDS.Tables["EFF_OneTimeMap"];
                    dgvOneTime.DataSource = OneTimeBS;

                }
                else
                {
                    MessageBox.Show("The entered values already exist.");
                }
            }
            else
            {
                MessageBox.Show("Please enter a 4-digit value for Cost Center.");
            }
        }

        private void miCopy_Click(object sender, EventArgs e)
        {
            CopyClipboard(dgvExpense);
        }

        private void miPaste_Click(object sender, EventArgs e)
        {
            PasteClipboard(dgvExpense);
            SumAllColumns();
        }
    }
}
