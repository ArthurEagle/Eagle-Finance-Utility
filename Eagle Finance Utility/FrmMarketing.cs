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
    public partial class FrmMarketing : Form
    {
        public FrmMarketing()
        {
            InitializeComponent();
        }
        public FrmMainMenu frmMM;
        Dictionary<string, bool> MlkColCheck;
        Dictionary<string, bool> CFColCheck;
        Dictionary<string, bool> PIColCheck;
        private void SetLastUpdateLabelAfterUpdate()
        {
            lblUpdate.Text = Environment.UserName + " " + DateTime.Now.ToString();
        }
        private void SetPriorPeriodsReadonly(DataGridView dgv, Dictionary<string, bool> ColCheck)
        {

            foreach (DataGridViewColumn c in dgv.Columns)
            {
                if (c.Index > 2)
                {
                    var sPeriod = Convert.ToInt32(c.HeaderText);
                    if (sPeriod < Convert.ToInt32(AppController.DataController.CloseYYYYMM))
                    {
                        c.ReadOnly = true;
                        c.DefaultCellStyle.BackColor = Color.Gainsboro;
                    }
                    else
                    {
                        if (!ColCheck.ContainsKey(c.HeaderText))
                        {
                            ColCheck.Add(c.HeaderText, false);
                        }
                        else if (ColCheck[c.HeaderText])
                        {
                            foreach (DataGridViewRow row in dgv.Rows)
                            {
                                if (row.Cells["Brand"].Value.ToString() == "Total:")
                                {
                                    row.Cells[c.Index].Style.BackColor = Color.LightGreen;
                                }
                            }
                        }
                    }
                }
                else
                {
                    c.ReadOnly = true;
                }
            }
        }

        private void SetTotalRowReadOnly(DataGridView dgv)
        {
            foreach(DataGridViewRow r in dgv.Rows)
            {
                if (r.Cells["Brand"].Value.ToString() == "Total:")
                {
                    r.ReadOnly = true;
                }
            }
        }
        private void SetNoSalesPeriodReadOnly(DataGridView dgv)
        {
            if (cbxFiscalYear.SelectedItem.ToString() == AppController.DataController.CurrentFiscalYear)
            {

                var noSalesPeriods = AppController.DataController.AmortBrandDT.Select("[Has Sales] = 0");

                if (noSalesPeriods.Length > 0)
                {
                    foreach (DataGridViewColumn c in dgv.Columns)
                    {
                        if (c.HeaderText == AppController.DataController.CloseYYYYMM)
                        {
                            foreach (DataRow dr in noSalesPeriods)
                            {
                                foreach (DataGridViewRow r in dgv.Rows)
                                {

                                    if (r.Cells["Brand"].Value.ToString().Trim() == dr["Brand"].ToString().Trim())
                                    {
                                        r.Cells[c.Index].ReadOnly = true;
                                        r.Cells[c.Index].Style.BackColor = Color.Gainsboro;
                                    }
                                }
                            }

                        }
                    }
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
                if (row.Cells["Brand"].Value.ToString() != "Total:")
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
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.Cells["Brand"].Value.ToString() == "Total:")
                {
                    row.Cells[colIndex].Value = total;
                    if (total != 100)
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

        private void SumAllColumns(DataGridView dgv, Dictionary<string, bool> ColCheck)
        {
            for(int i = 3; i <15;i++)
            {
                if(Convert.ToInt32(dgv.Columns[i].HeaderText) >= Convert.ToInt32(AppController.DataController.CloseYYYYMM))
                {
                    SumColumnTotal(i, dgv, ColCheck);
                }
            
            }
        }
        private void CheckColumnTotalAndUpdate(DataGridView dgv, Dictionary<string, bool> ColCheck)
        {
            int cnt = 0;
            foreach (KeyValuePair<string, bool> kvp in ColCheck)
            {
                if (kvp.Value)
                {
                    cnt++;
                    UpdateMktgAllocByPeriod(dgv, kvp.Key);
                }

            }
            if (cnt > 0)
            {
                AppController.DataController.RefreshMarketingExpenseAllocData();
                SetLastUpdateLabelAfterUpdate();
            }
        }
        private void UpdateMktgAllocByPeriod(DataGridView dgv, string YYYYMM)
        {
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.Cells["Brand"].Value.ToString() != "Total:")
                {
                    if (Convert.ToInt32(YYYYMM) >= Convert.ToInt32(AppController.DataController.CloseYYYYMM))
                    {
                        if(dgv.Columns.Contains(YYYYMM))
                        {
                            if (Convert.ToDouble(row.Cells[YYYYMM].Value) > 0)
                            {
                                var brd = row.Cells["Brand"].Value.ToString();
                                var lvl = row.Cells["LevelID"].Value.ToString();
                                var busArea = row.Cells["Business Area"].Value.ToString();
                                if (busArea == "MILK" || busArea == "MLK")
                                {
                                    busArea = "MLK";
                                }
                                else
                                {
                                    busArea = "SNK";
                                }
                                var percent = (Convert.ToDouble(row.Cells[YYYYMM].Value) / 100.00).ToString();
                                AppController.DataController.InsertOrUpdateMktgAlloc(YYYYMM, brd, percent, busArea, lvl);
                            }
                        }                       

                    }

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
        private void FrmMarketing_Load(object sender, EventArgs e)
        {
           
        }

        private void cbxFiscalYear_SelectedIndexChanged(object sender, EventArgs e)
        {

            MktgMlkBS.DataSource = AppController.DataController.EFF_MktgDS.Tables[cbxFiscalYear.SelectedItem.ToString() + " MLK"];
            dgvMktgAllocMLK.DataSource = MktgMlkBS;

            MktgCFBS.DataSource = AppController.DataController.EFF_MktgDS.Tables[cbxFiscalYear.SelectedItem.ToString() + " CORNFIELDS"];
            dgvMktgAllocCF.DataSource = MktgCFBS;

            MktgPIBS.DataSource = AppController.DataController.EFF_MktgDS.Tables[cbxFiscalYear.SelectedItem.ToString() + " POPCORN INDIANA"];
            dgvMktgAllocPI.DataSource = MktgPIBS;

            SetPriorPeriodsReadonly(dgvMktgAllocCF, CFColCheck);
            SetPriorPeriodsReadonly(dgvMktgAllocPI, PIColCheck);
            SetPriorPeriodsReadonly(dgvMktgAllocMLK, MlkColCheck);

            SetNoSalesPeriodReadOnly(dgvMktgAllocMLK);
            SetNoSalesPeriodReadOnly(dgvMktgAllocCF);
            SetNoSalesPeriodReadOnly(dgvMktgAllocPI);

            SetTotalRowReadOnly(dgvMktgAllocMLK);
            SetTotalRowReadOnly(dgvMktgAllocCF);
            SetTotalRowReadOnly(dgvMktgAllocPI);

        }

        private void dgvMktgAllocMLK_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            double pct;
            if (double.TryParse(dgvMktgAllocMLK.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(), out pct))
            {
                if (pct < 0)
                {
                    MessageBox.Show("Percents must be non-negative.");
                    dgvMktgAllocMLK.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "0";
                }
                SumColumnTotal(e.ColumnIndex, dgvMktgAllocMLK, MlkColCheck);
            }
        }

        private void dgvMktgAllocCF_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            double pct;
            if (double.TryParse(dgvMktgAllocCF.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(), out pct))
            {
                if (pct < 0)
                {
                    MessageBox.Show("Percents must be non-negative.");
                    dgvMktgAllocCF.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "0";
                }
                SumColumnTotal(e.ColumnIndex, dgvMktgAllocCF, CFColCheck);
            }
        }

        private void dgvMktgAllocPI_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            double pct;
            if (double.TryParse(dgvMktgAllocPI.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(), out pct))
            {
                if (pct < 0)
                {
                    MessageBox.Show("Percents must be non-negative.");
                    dgvMktgAllocPI.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "0";
                }
                SumColumnTotal(e.ColumnIndex, dgvMktgAllocPI, PIColCheck);
            }
        }

        private void dgvMktgAllocMLK_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Please enter Allcoation percent as a decimal number. Ex. enter 25.5 for 25.5%.");
        }

        private void dgvMktgAllocCF_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Please enter Allcoation percent as a decimal number. Ex. enter 25.5 for 25.5%.");
        }

        private void dgvMktgAllocPI_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Please enter Allcoation percent as a decimal number. Ex. enter 25.5 for 25.5%.");
        }

        private void FrmMarketing_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmMM.Show();
        }

        private void FrmMarketing_Load_1(object sender, EventArgs e)
        {
            MlkColCheck = new Dictionary<string, bool>();
            PIColCheck = new Dictionary<string, bool>();
            CFColCheck = new Dictionary<string, bool>();


            cbxFiscalYear.DataSource = AppController.DataController.MktgFiscalYrsLst.OrderBy(p => p).ToList();
            cbxFiscalYear.SelectedItem = Convert.ToInt32(AppController.DataController.CurrentFiscalYear);


        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            CheckColumnTotalAndUpdate(dgvMktgAllocMLK, MlkColCheck);           

            CheckColumnTotalAndUpdate(dgvMktgAllocCF, CFColCheck);        

            CheckColumnTotalAndUpdate(dgvMktgAllocPI, PIColCheck);
          
        }

        private void miPaste_Click(object sender, EventArgs e)
        {
            PasteClipboard(dgvMktgAllocMLK);
            SumAllColumns(dgvMktgAllocMLK, MlkColCheck);
        }

        private void miCopy_Click(object sender, EventArgs e)
        {
            CopyClipboard(dgvMktgAllocMLK);
        }

        private void miCFCopy_Click(object sender, EventArgs e)
        {
            CopyClipboard(dgvMktgAllocCF);
        }

        private void miCFPaste_Click(object sender, EventArgs e)
        {
            PasteClipboard(dgvMktgAllocCF);
        }

        private void miPICopy_Click(object sender, EventArgs e)
        {
            CopyClipboard(dgvMktgAllocPI);
        }

        private void miPIPaste_Click(object sender, EventArgs e)
        {
            PasteClipboard(dgvMktgAllocPI);
        }
    }
}
