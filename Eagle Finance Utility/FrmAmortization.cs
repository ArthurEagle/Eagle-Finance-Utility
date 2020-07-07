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
    public partial class FrmAmortization : Form
    {
        public FrmAmortization()
        {
            InitializeComponent();
        }

        public FrmMainMenu frmMM;

        DataTable UpdateValueDT;
        private void FrmAmortization_Load(object sender, EventArgs e)
        {
            var user = Environment.UserName;

            cbxFiscalYear.DataSource = AppController.DataController.AmortFiscalYrsLst.OrderBy(p => p).ToList();
            cbxFiscalYear.SelectedItem = Convert.ToInt32(AppController.DataController.CurrentFiscalYear);

            cbxBusArea.SelectedIndex = 0;
            LoadCbxAmortAccount();
            CreateUpdateValueDT();
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
        private void CreateUpdateValueDT()
        {
            UpdateValueDT = new DataTable();
            UpdateValueDT.Columns.Add("YYYYMM", typeof(string));
            UpdateValueDT.Columns.Add("BusArea", typeof(string));
            UpdateValueDT.Columns.Add("Brand", typeof(string));
            UpdateValueDT.Columns.Add("AcctDesc", typeof(string));
            UpdateValueDT.Columns.Add("Amount", typeof(double));


        }
        private void LoadDgvByYear(string year)
        {
            AmortBS.DataSource = AppController.DataController.EFF_AmortDS.Tables[year];
            dgvAmortization.DataSource = AmortBS;
            AmortBS.Sort = "[Business Area],Brand ASC";
        }
        private void LoadCbxAmortAccount()
        {
            cbxAccount.Items.Add("ALL");
            foreach (string s in AppController.DataController.AmortAcctLst)
            {
                cbxAccount.Items.Add(s);
            }
            cbxAccount.SelectedIndex = 0;
        }
        private void FilterAmortDataGridByBusAreaAndAccount(string ba,string acct)
        {
            

            if (ba == "ALL" && acct == "ALL")
            {
                AmortBS.Filter = "";
            }
            else if(ba == "ALL" && acct != "ALL")
            {
                AmortBS.Filter = "[GL Account] = '" + acct + "'";
            }
            else if (ba != "ALL" && acct == "ALL")
            {
                AmortBS.Filter = "[Business Area] = '" + ba + "'";
            }
            else if(ba != "ALL" && acct != "ALL")
            {
                AmortBS.Filter = "[Business Area] = '" + ba + "' AND [GL Account] = '" + acct + "'";
            }
                
            //AmortBS.Sort = "[FiscalSort] Asc";


        }

        private void SetPriorPeriodsReadonly()
        {

            foreach (DataGridViewColumn c in dgvAmortization.Columns)
            {
                if (c.Index >= 3)
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

        private void SetNoSalesPeriodReadOnly()
        {
            if (cbxFiscalYear.SelectedItem.ToString() == AppController.DataController.CurrentFiscalYear)
            {

                var noSalesPeriods = AppController.DataController.AmortBrandDT.Select("[Has Sales] = 0");

                if (noSalesPeriods.Length > 0)
                {
                    foreach (DataGridViewColumn c in dgvAmortization.Columns)
                    {
                        if (c.HeaderText == AppController.DataController.CloseYYYYMM)
                        {
                            foreach (DataRow dr in noSalesPeriods)
                            {
                                foreach (DataGridViewRow r in dgvAmortization.Rows)
                                {

                                    if (r.Cells["Brand"].Value.ToString() == dr["Brand"].ToString())
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

        private void SetLastUpdateLabelAfterUpdate()
        {
            lblUpdate.Text = Environment.UserName + " " + DateTime.Now.ToString();
        }
        private void cbxFiscalYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxFiscalYear.SelectedItem != null)
            {
                LoadDgvByYear(cbxFiscalYear.SelectedItem.ToString());
                SetPriorPeriodsReadonly();
                SetNoSalesPeriodReadOnly();
            }
        }

        private void cbxBusArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxFiscalYear.SelectedItem != null && cbxAccount.SelectedItem != null && cbxBusArea.SelectedItem != null)
                FilterAmortDataGridByBusAreaAndAccount(cbxBusArea.SelectedItem.ToString(), cbxAccount.SelectedItem.ToString());
        }

        private void cbxAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxFiscalYear.SelectedItem != null && cbxAccount.SelectedItem != null && cbxBusArea.SelectedItem != null)
                FilterAmortDataGridByBusAreaAndAccount(cbxBusArea.SelectedItem.ToString(), cbxAccount.SelectedItem.ToString());
        }

        private void dgvAmortization_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Please enter a numeric value.");
        }

        private void dgvAmortization_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string yyyymm = dgvAmortization.Columns[e.ColumnIndex].HeaderText;
            string ba = dgvAmortization.Rows[e.RowIndex].Cells["Business Area"].Value.ToString();
            string brand = dgvAmortization.Rows[e.RowIndex].Cells["Brand"].Value.ToString();
            string acct = dgvAmortization.Rows[e.RowIndex].Cells["GL Account"].Value.ToString();
            double amount = Convert.ToDouble(dgvAmortization.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);

            var res = UpdateValueDT.Select("Brand ='" + brand + "' AND YYYYMM = '" + yyyymm + "' AND AcctDesc = '" + acct + "'");
            if(res.Length == 1)
            {
                res[0]["Amount"] = amount;
            }
            else
            {
                UpdateValueDT.Rows.Add(yyyymm,ba, brand, acct, amount);
            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if(UpdateValueDT.Rows.Count > 0)
            {
               
                AppController.DataController.InsertOrUpdateAmortAmount(UpdateValueDT);
                SetLastUpdateLabelAfterUpdate();
            }
        }

        private void FrmAmortization_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmMM.Show();
        }

        private void siCopy_Click(object sender, EventArgs e)
        {
            CopyClipboard(dgvAmortization);
        }

        private void siPaste_Click(object sender, EventArgs e)
        {
            PasteClipboard(dgvAmortization);
        }
    }
}
