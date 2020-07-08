using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;

namespace Eagle_Finance_Utility
{
    class DataController
    {
        M3ViewsDataSet m3ViewsDS;
        SQLQuery sql = new SQLQuery();
        M3Connect m3c = new M3Connect();

        DataTable EFF_IPV_Account;
        DataTable EFF_IPV_Amount;
        DataTable EFF_IPV_Item;
        DataTable EFF_PPV_Account;
        DataTable EFF_PPV_Period;
        DataTable EFF_Obsol_Alloc;
      //  DataTable EFF_LVL3_Sales;
        DataTable EFF_Item_Hierarchy;
        DataTable EFF_Amortization;
        DataTable EFF_Expense_Alloc;
        DataTable EFF_OneTimeMap;
        DataTable EFF_Mktg_Exp_Alloc;

        public DataSet EFF_CustomDS;
        public DataSet EFF_ObsoMLKDS;
        public DataSet EFF_ObsoSNKDS;
        public DataSet EFF_AmortDS;
        public DataSet EFF_ExpenseDS;
        public DataSet EFF_MktgDS;

        public DataTable PPVTime;
        public DataTable IPVAmount;
        public DataTable AmortBrandDT; 
        public DataTable AmortAccountDT;
        public DataTable ExpenseLevelDT;
        public DataTable MarketingLevelDT;

        List<string> Items;
        List<string> Accounts;

        public string CurrentFiscalYear;
        public string CloseYYYYMM;

        public IList<int> ObsoFiscalYrsLst;
        public IList<int> AmortFiscalYrsLst;
        public IList<int> ExpFiscalYrsLst;
        public IList<int> MktgFiscalYrsLst;
        public IList<string> BrandsLst;
        public IList<string> AmortAcctLst;
        public IList<string> ExpLevelLst;
        public IList<string> OneTimeFiscalYearLst;
        public IList<string> CostCenterLst;
        public IList<string> MktgLevelLst;

        public string howToLnk = @"https://installedapplications.blob.core.windows.net/appinstall/Eagle%20Finance%20Utility/Eagle%20Finance%20Allocation%20Utility%20How-to%20Guide.docx";

        private void LoadValidCostCenters()
        {
            CostCenterLst = new List<string>();
            foreach(DataRow dr in EFF_CustomDS.Tables["EFF_OneTimeMap"].Rows)
            {
                var cc = dr["CostCenterID"].ToString();
                if(!CostCenterLst.Contains(cc))
                {
                    CostCenterLst.Add(cc);
                }
            }

        }
        public void LoadValidOneTimeExpenseMapFiscalYears()
        {
            OneTimeFiscalYearLst = new List<string>();
            for(int i = 0;i<5;i++)
            {
              var fy = Convert.ToInt32(CurrentFiscalYear);
                fy += i;
                OneTimeFiscalYearLst.Add(fy.ToString());

            }
        }     
        private void LoadValidExpenseLevels()
        {
            ExpenseLevelDT = m3c.FillDataTable(sql.Select14());
            ExpLevelLst = new List<string>();
            foreach(DataRow dr in ExpenseLevelDT.Rows)
            {
                if(dr["LevelID"].ToString() != "ALLOCATION")
                {
                    ExpLevelLst.Add(dr["LevelID"].ToString());
                }
            }
        }
        private void LoadValidMarketingLevels()
        {
            MarketingLevelDT = m3c.FillDataTable(sql.Select17());
            MktgLevelLst = new List<string>();
            foreach (DataRow dr in MarketingLevelDT.Rows)
            {
                if (dr["LevelID"].ToString() != "ALLOCATION" && !MktgLevelLst.Contains(dr["LevelID"].ToString()))
                {
                    MktgLevelLst.Add(dr["LevelID"].ToString());
                }
            }
        }
        public void LoadValidBrands()
        {
            BrandsLst = new List<string>();
            AmortBrandDT = m3c.FillDataTable(sql.Select10(CloseYYYYMM));
            foreach(DataRow dr in AmortBrandDT.Rows)
            {
                BrandsLst.Add(dr["Brand"].ToString());
            }
        }
        public void LoadValidAmortAccts()
        {
            AmortAcctLst = new List<string>();
            AmortAccountDT = m3c.FillDataTable(sql.Select12());
            foreach (DataRow dr in AmortAccountDT.Rows)
            {
                AmortAcctLst.Add(dr["GL Acct Desc"].ToString());
            }
        }
        public void LoadRawMaterialItemsAndAccounts()
        {
            Items = new List<string>();
            Accounts = new List<string>();

            m3ViewsDS = new M3ViewsDataSet();
            M3ViewsDataSetTableAdapters.FCHACC___Chart_of_accounts_Accounting_dimension_1TableAdapter acctAdapt = new M3ViewsDataSetTableAdapters.FCHACC___Chart_of_accounts_Accounting_dimension_1TableAdapter();
            M3ViewsDataSetTableAdapters.MITMAS___Item_MasterTableAdapter mitmasAdapt = new M3ViewsDataSetTableAdapters.MITMAS___Item_MasterTableAdapter();

            acctAdapt.Fill(m3ViewsDS._FCHACC___Chart_of_accounts_Accounting_dimension_1);
            mitmasAdapt.Fill(m3ViewsDS._MITMAS___Item_Master);


            var itmLst = from item in m3ViewsDS._MITMAS___Item_Master where item.Item_type != "Z10" select item.Item_number;

            foreach(string s in itmLst)
            {
                Items.Add(s.Trim());
            }

            var actLst = from act in m3ViewsDS._FCHACC___Chart_of_accounts_Accounting_dimension_1 select act.Accounting_identity;

            foreach (string s in actLst)
            {
                Accounts.Add(s.Trim());
            }
        }

        public void LoadIPV_PPV_ObsoWithPrimaryData()
        {
            if(EFF_CustomDS != null)
            {
                EFF_CustomDS.Dispose();
            }

            EFF_CustomDS = new DataSet();
            EFF_CustomDS.DataSetName = "CustomDS";

            EFF_IPV_Account = m3c.FillDataTable(sql.Select1());
            EFF_IPV_Account.TableName = "EFF_IPV_Account";

            EFF_IPV_Amount = m3c.FillDataTable(sql.Select2());
            EFF_IPV_Amount.TableName = "EFF_IPV_Amount";

            EFF_IPV_Item = m3c.FillDataTable(sql.Select3());
            EFF_IPV_Item.TableName = "EFF_IPV_Item";

            EFF_PPV_Account = m3c.FillDataTable(sql.Select4());
            EFF_PPV_Account.TableName = "EFF_PPV_Account";

            EFF_PPV_Period = m3c.FillDataTable(sql.Select5());
            EFF_PPV_Period.TableName = "EFF_PPV_Period";

            EFF_Obsol_Alloc = m3c.FillDataTable(sql.Select6());
            EFF_Obsol_Alloc.TableName = "EFF_Obsol_Alloc";

            //EFF_LVL3_Sales = m3c.FillDataTable(sql.Select7(CloseYYYYMM));
            //EFF_LVL3_Sales.TableName = "EFF_LVL3_Sales";

            EFF_Item_Hierarchy = m3c.FillDataTable(sql.Select8(CloseYYYYMM));
            EFF_Item_Hierarchy.TableName = "EFF_Item_Hierarchy";

            EFF_Amortization = m3c.FillDataTable(sql.Select11());
            EFF_Amortization.TableName = "EFF_Amortization";


  

            EFF_Expense_Alloc = m3c.FillDataTable(sql.Select13());
            EFF_Expense_Alloc.TableName = "EFF_Expense_Alloc";

            EFF_OneTimeMap = m3c.FillDataTable(sql.Select15());
            EFF_OneTimeMap.TableName = "EFF_OneTimeMap";

            EFF_Mktg_Exp_Alloc = m3c.FillDataTable(sql.Select16());
            EFF_Mktg_Exp_Alloc.TableName = "EFF_Mktg_Exp_Alloc";

            EFF_CustomDS.Tables.Add(EFF_IPV_Account);
            EFF_CustomDS.Tables.Add(EFF_IPV_Amount);
            EFF_CustomDS.Tables.Add(EFF_IPV_Item);
            EFF_CustomDS.Tables.Add(EFF_PPV_Account);
            EFF_CustomDS.Tables.Add(EFF_PPV_Period);
            EFF_CustomDS.Tables.Add(EFF_Obsol_Alloc);
            //EFF_CustomDS.Tables.Add(EFF_LVL3_Sales);
            EFF_CustomDS.Tables.Add(EFF_Item_Hierarchy);
            EFF_CustomDS.Tables.Add(EFF_Amortization);
            EFF_CustomDS.Tables.Add(EFF_Expense_Alloc);
            EFF_CustomDS.Tables.Add(EFF_OneTimeMap);
            EFF_CustomDS.Tables.Add(EFF_Mktg_Exp_Alloc);

            LoadValidBrands();
            LoadValidAmortAccts();
            LoadValidExpenseLevels();
            LoadValidOneTimeExpenseMapFiscalYears();
            LoadValidCostCenters();
            LoadValidMarketingLevels();

            CreatePPVTimePeriodWorkTable();
            CreateIPVAmountWorkTable();
            CreateObsolescenceWorkTables();
            CreateAmortizationWorkTables();
            CreateExpenseWorkTables();
            CreateMarketingExpenseWorkTables();
        }
        public void RefreshOneTimeExpenseMapData()
        {
            EFF_CustomDS.Tables.Remove(EFF_OneTimeMap);
            EFF_OneTimeMap = m3c.FillDataTable(sql.Select15());
            EFF_OneTimeMap.TableName = "EFF_OneTimeMap";
            EFF_CustomDS.Tables.Add(EFF_OneTimeMap);
        }
        public void RefreshObsolescenceAllocData()
        {
            EFF_CustomDS.Tables.Remove(EFF_Obsol_Alloc);
            EFF_Obsol_Alloc = m3c.FillDataTable(sql.Select6());
            EFF_Obsol_Alloc.TableName = "EFF_Obsol_Alloc";
            EFF_CustomDS.Tables.Add(EFF_Obsol_Alloc);
        }

        public void RefreshMarketingExpenseAllocData()
        {
            EFF_CustomDS.Tables.Remove(EFF_Mktg_Exp_Alloc);
            EFF_Mktg_Exp_Alloc = m3c.FillDataTable(sql.Select16());
            EFF_Mktg_Exp_Alloc.TableName = "EFF_Mktg_Exp_Alloc";
            EFF_CustomDS.Tables.Add(EFF_Mktg_Exp_Alloc);
        }
        public void RefreshExpenseAllocData()
        {
            EFF_CustomDS.Tables.Remove(EFF_Expense_Alloc);
            EFF_Expense_Alloc = m3c.FillDataTable(sql.Select13());
            EFF_Expense_Alloc.TableName = "EFF_Expense_Alloc";
            EFF_CustomDS.Tables.Add(EFF_Expense_Alloc);
        }

        public void RefreshAmortizartionAllocData()
        {
            EFF_CustomDS.Tables.Remove(EFF_Amortization);
            EFF_Amortization = m3c.FillDataTable(sql.Select11());
            EFF_Amortization.TableName = "EFF_Amortization";
            EFF_CustomDS.Tables.Add(EFF_Amortization);
        }
        private void CreateIPVAmountWorkTable()
        {
            if (IPVAmount != null)
            {
                IPVAmount.Dispose();
            }
            IPVAmount = EFF_IPV_Amount.Clone();

            IPVAmount.Columns.Add("ToUpdate", typeof(bool));
            IPVAmount.Columns.Add("FiscalSort", typeof(int));

            foreach (DataRow dr in EFF_IPV_Amount.Rows)
            {
                DateTime f = new DateTime(Convert.ToInt32(dr["YYYYMM"].ToString().Substring(0, 4)), Convert.ToInt32(dr["YYYYMM"].ToString().Substring(4, 2)), 01);
                int srt = 0;
                //Fiscal Sort Order
                if (f.Month >= 4)
                {
                    srt = f.Month - 3;
                }
                else
                {
                    srt = f.Month + 9;
                }

                IPVAmount.Rows.Add(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3], dr[4].ToString(), dr[5], dr[6].ToString(), dr[7].ToString(), false, srt);
            }
        }

        private void CreateExpenseWorkTables()
        {

            EFF_ExpenseDS = new DataSet();

            //Get Max Calendar Period list from EFF_Amortization
            var periods = from obs in AppController.DataController.EFF_CustomDS.Tables["EFF_Expense_Alloc"].AsEnumerable()
                          orderby obs.Field<string>("Calendar_YYYYMM") descending
                          select obs.Field<string>("Calendar_YYYYMM");



            var maxCalPeriod = periods.Max<string>();

            //Get Fiscal Year list from EFF_Amortization
            var fiscalYears = from obs in AppController.DataController.EFF_CustomDS.Tables["EFF_Expense_Alloc"].AsEnumerable()
                              orderby obs.Field<int>("FiscalYear") descending
                              select obs.Field<int>("FiscalYear");

            ExpFiscalYrsLst = fiscalYears.Distinct().ToList();
            var maxYr = ExpFiscalYrsLst.Max();


            //Add a few mor years to fiscalyears
            for (int i = 1; i < 4; i++)
            {
               ExpFiscalYrsLst.Add(maxYr + i);
            }

            foreach (int s in ExpFiscalYrsLst)
            {
                // Get Calendar Periods
                List<string> calPeriods = new List<string>();
                for (int i = 0; i < 6; i++)
                {
                    var per = (s - 1).ToString() + "0" + (4 + i).ToString();
                    calPeriods.Add(per);
                }
                for (int i = 0; i < 3; i++)
                {
                    var per = (s - 1).ToString() + (10 + i).ToString();
                    calPeriods.Add(per);
                }
                for (int i = 0; i < 3; i++)
                {
                    var per = s.ToString() + "0" + (1 + i).ToString();
                    calPeriods.Add(per);
                }

                var records = EFF_CustomDS.Tables["EFF_Expense_Alloc"].Select("FiscalYear = " + s.ToString());

                var expRes = CreateExpenseWorkTable(s, calPeriods, records);
                EFF_ExpenseDS.Tables.Add(expRes);

            }
        }
        private DataTable CreateExpenseWorkTable(int fiscalYear, List<string> calPeriods, DataRow[] expRecs)
        {
            DataTable expDT = new DataTable();
            expDT.TableName = fiscalYear.ToString();

            expDT.Columns.Add("Business Area", typeof(string));
            expDT.Columns.Add("LevelID", typeof(string));     

            foreach (string s in calPeriods)
            {
                expDT.Columns.Add(s, typeof(double));
            }

            foreach (DataRow dr in ExpenseLevelDT.Rows)
            {
                if(dr["LevelID"].ToString()  != "ALLOCATION")
                {
                    var lvl = dr["LevelID"].ToString();
                    var ba = dr["Business Area"].ToString();
                    expDT.Rows.Add(ba,lvl, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
                }              
            }

            foreach (DataRow dr in expDT.Rows)
            {
                var lvl = dr["LevelID"].ToString();
                var ba = dr["Business Area"].ToString();
                foreach (string s in calPeriods)
                {
                    if (expRecs.Length > 0)
                    {
                        DataTable expRecsDt = expRecs.CopyToDataTable();
                        var record = expRecsDt.Select("Calendar_YYYYMM = '" + s + "' AND [Business Area] = '" + ba + "' AND [LevelID] = '" + lvl+ "'");

                        if (record.Length == 1)
                        {
                            var pct = record[0];
                            dr[s] = Convert.ToDouble(pct["Alloc Pct"]) * 100;
                        }
                    }

                }
            }
            //Fill Totals List
            List<decimal> totals = new List<decimal>();
            for (int i = 2; i < 14; i++)
            {
                decimal total = 0;
                foreach (DataRow dr in expDT.Rows)
                {
                    total += Convert.ToDecimal(dr[i]);
                }
                totals.Add(total);
            }
            //Fill Totals row
            //Add Totals Row
            expDT.Rows.Add("", "Total:", totals[0], totals[1], totals[2], totals[3], totals[4], totals[5], totals[6], totals[7], totals[8], totals[9], totals[10], totals[11]);

            return expDT;
        }

        private void CreateMarketingExpenseWorkTables()
        {



            EFF_MktgDS = new DataSet();

            //Get Max Calendar Period list from EFF_Mktg_Exp_Alloc
            var periods = from obs in AppController.DataController.EFF_CustomDS.Tables["EFF_Mktg_Exp_Alloc"].AsEnumerable()
                          orderby obs.Field<string>("Calendar_YYYYMM") descending
                          select obs.Field<string>("Calendar_YYYYMM");



            var maxCalPeriod = periods.Max<string>();

            //Get Fiscal Year list from EFF_Mktg_Exp_Alloc
            var fiscalYears = from obs in AppController.DataController.EFF_CustomDS.Tables["EFF_Mktg_Exp_Alloc"].AsEnumerable()
                              orderby obs.Field<int>("FiscalYear") descending
                              select obs.Field<int>("FiscalYear");

            MktgFiscalYrsLst = fiscalYears.Distinct().ToList();
            var maxYr = MktgFiscalYrsLst.Max();


            //Add a few mor years to fiscalyears
            for (int i = 1; i < 4; i++)
            {
                MktgFiscalYrsLst.Add(maxYr + i);
            }

            foreach (int s in MktgFiscalYrsLst)
            {
                // Get Calendar Periods
                List<string> calPeriods = new List<string>();
                for (int i = 0; i < 6; i++)
                {
                    var per = (s - 1).ToString() + "0" + (4 + i).ToString();
                    calPeriods.Add(per);
                }
                for (int i = 0; i < 3; i++)
                {
                    var per = (s - 1).ToString() + (10 + i).ToString();
                    calPeriods.Add(per);
                }
                for (int i = 0; i < 3; i++)
                {
                    var per = s.ToString() + "0" + (1 + i).ToString();
                    calPeriods.Add(per);
                }

               

                foreach(string lv in MktgLevelLst)
                {                  
                    var records = EFF_CustomDS.Tables["EFF_Mktg_Exp_Alloc"].Select("FiscalYear = " + s.ToString() + " AND [LevelID] = '" + lv+ "'");
                    var mktgRes = CreateMarketingWorkTable(s, calPeriods, records,lv);
                    EFF_MktgDS.Tables.Add(mktgRes);
                }
                

            }
        }
        private DataTable CreateMarketingWorkTable(int fiscalYear, List<string> calPeriods, DataRow[] mktgRecs,string levelID)
        {
            DataTable mktgDT = new DataTable();
            mktgDT.TableName = fiscalYear.ToString() + " " + levelID;

            mktgDT.Columns.Add("Business Area", typeof(string));
            mktgDT.Columns.Add("LevelID", typeof(string));
            mktgDT.Columns.Add("Brand", typeof(string));


            foreach (string s in calPeriods)
            {
                mktgDT.Columns.Add(s, typeof(double));
            }

            foreach (DataRow dr in MarketingLevelDT.Rows)
            {
                if (dr["LevelID"].ToString() != "ALLOCATION" && dr["LevelID"].ToString() == levelID)
                {
                    var lvl = dr["LevelID"].ToString();
                    var ba =  dr["Business Area"].ToString();
                    var brd = dr["Brand"].ToString();
                    mktgDT.Rows.Add(ba, lvl,brd, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
                }
            }

            foreach (DataRow dr in mktgDT.Rows)
            {
                var lvl = dr["LevelID"].ToString();
                var ba = dr["Business Area"].ToString();
                var brd = dr["Brand"].ToString();
                foreach (string s in calPeriods)
                {
                    if (mktgRecs.Length > 0)
                    {
                        DataTable mktgRecsDt = mktgRecs.CopyToDataTable();
                        var record = mktgRecsDt.Select("Calendar_YYYYMM = '" + s + "' AND [Business Area] = '" + ba + "' AND [LevelID] = '" + lvl + "' AND Brand = '" + brd + "'");

                        if (record.Length == 1)
                        {
                            var pct = record[0];
                            dr[s] = Convert.ToDouble(pct["Alloc Pct"]) * 100;
                        }
                    }

                }
            }
            //Fill Totals List
            List<decimal> totals = new List<decimal>();
            for (int i = 3; i < 15; i++)
            {
                decimal total = 0;
                foreach (DataRow dr in mktgDT.Rows)
                {
                    total += Convert.ToDecimal(dr[i]);
                }
                totals.Add(total);
            }
            //Fill Totals row
            //Add Totals Row
            mktgDT.Rows.Add("", "", "Total:", totals[0], totals[1], totals[2], totals[3], totals[4], totals[5], totals[6], totals[7], totals[8], totals[9], totals[10], totals[11]);

            return mktgDT;
        }
        private void CreateAmortizationWorkTables()
        {



            EFF_AmortDS = new DataSet();

            //Get Max Calendar Period list from EFF_Amortization
            var periods = from obs in AppController.DataController.EFF_CustomDS.Tables["EFF_Amortization"].AsEnumerable()
                          orderby obs.Field<string>("Calendar_YYYYMM") descending
                          select obs.Field<string>("Calendar_YYYYMM");



            var maxCalPeriod = periods.Max<string>();

            //Get Fiscal Year list from EFF_Amortization
            var fiscalYears = from obs in AppController.DataController.EFF_CustomDS.Tables["EFF_Amortization"].AsEnumerable()
                              orderby obs.Field<int>("FiscalYear") descending
                              select obs.Field<int>("FiscalYear");

            AmortFiscalYrsLst = fiscalYears.Distinct().ToList();
            var maxYr = AmortFiscalYrsLst.Max();


            //Add a few mor years to fiscalyears
            for (int i = 1; i < 4; i++)
            {
                AmortFiscalYrsLst.Add(maxYr + i);
            }

            foreach (int s in AmortFiscalYrsLst)
            {
                // Get Calendar Periods
                List<string> calPeriods = new List<string>();
                for (int i = 0; i < 6; i++)
                {
                    var per = (s - 1).ToString() + "0" + (4 + i).ToString();
                    calPeriods.Add(per);
                }
                for (int i = 0; i < 3; i++)
                {
                    var per = (s - 1).ToString() + (10 + i).ToString();
                    calPeriods.Add(per);
                }
                for (int i = 0; i < 3; i++)
                {
                    var per = s.ToString() + "0" + (1 + i).ToString();
                    calPeriods.Add(per);
                }

                var records = EFF_CustomDS.Tables["EFF_Amortization"].Select("FiscalYear = " + s.ToString());

                var amortRes = CreateAmortizationWorkTable(s, calPeriods, records);
                EFF_AmortDS.Tables.Add(amortRes);

            }
        }

        private DataTable CreateAmortizationWorkTable(int fiscalYear, List<string> calPeriods, DataRow[] amortRecs)
        {
            DataTable amortDT = new DataTable();
            amortDT.TableName = fiscalYear.ToString();

            amortDT.Columns.Add("Business Area", typeof(string));
            amortDT.Columns.Add("Brand", typeof(string));
            amortDT.Columns.Add("GL Account", typeof(string));

            foreach (string s in calPeriods)
            {
                amortDT.Columns.Add(s, typeof(double));
            }

            foreach (string s in AmortAcctLst)
            {
                foreach (DataRow dr in AmortBrandDT.Rows)
                {                
                    amortDT.Rows.Add(dr["Business Area"].ToString(), dr["Brand"].ToString(), s, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
                }                
            }
            foreach (DataRow dr in amortDT.Rows)
            {
                var brnd = dr["Brand"].ToString();
                var acct = dr["GL Account"].ToString();
                foreach (string s in calPeriods)
                {
                    if(s == "202006" )
                    {

                    }
                    if (amortRecs.Length > 0)
                    {
                        DataTable amortRecsDt = amortRecs.CopyToDataTable();
                        var record = amortRecsDt.Select("Calendar_YYYYMM = '" + s + "' AND [Brand Name] = '" + brnd + "' AND [GL Acct Desc] = '" + acct + "'");

                        if (record.Length == 1)
                        {
                            var pct = record[0];
                            dr[s] = Convert.ToDouble(pct["Amount"]);
                        }
                    }

                }
            }


            return amortDT;
        }
        public void CreateObsolescenceWorkTables()
        {
            EFF_ObsoMLKDS = new DataSet();
            EFF_ObsoSNKDS = new DataSet();
            //MLK - Item Heirarchy
            var mlk = EFF_CustomDS.Tables["EFF_Item_Hierarchy"].Select("Level1ID = 'MLK'");

            //SNK - Item Heirarchy
            var snk = EFF_CustomDS.Tables["EFF_Item_Hierarchy"].Select("Level1ID = 'SNK'");

            //Get Max Calendar Period list from EFF_Obso_Alloc
            var periods = from obs in AppController.DataController.EFF_CustomDS.Tables["EFF_Obsol_Alloc"].AsEnumerable()
                          orderby obs.Field<string>("Calendar_YYYYMM") descending
                          select obs.Field<string>("Calendar_YYYYMM");

           
        
            var maxCalPeriod = periods.Max<string>();

            //Get Fiscal Year list from EFF_Obso_Alloc
            var fiscalYears = from obs in AppController.DataController.EFF_CustomDS.Tables["EFF_Obsol_Alloc"].AsEnumerable()
                              orderby obs.Field<int>("FiscalYear") descending
                              select obs.Field<int>("FiscalYear");

            ObsoFiscalYrsLst = fiscalYears.Distinct().ToList();
            var maxYr = ObsoFiscalYrsLst.Max();


            //Add a few mor years to fiscalyears
            for (int i = 1;i<4;i++)
            {
                ObsoFiscalYrsLst.Add(maxYr + i);
            }

            foreach(int s in ObsoFiscalYrsLst)
            {
                // Get Calendar Periods
                List<string> calPeriods = new List<string>();
                for(int i = 0; i< 6;i++)
                {
                    var per = (s - 1).ToString() + "0" + (4 + i).ToString();
                    calPeriods.Add(per);
                }
                for (int i = 0; i < 3; i++)
                {
                    var per = (s - 1).ToString() + (10 + i).ToString();
                    calPeriods.Add(per);
                }
                for (int i = 0; i < 3; i++)
                {
                    var per = s.ToString() + "0" + (1 + i).ToString();
                    calPeriods.Add(per);
                }
         
                var records = EFF_CustomDS.Tables["EFF_Obsol_Alloc"].Select("FiscalYear = " + s.ToString());
             
                var mlkRes = CreateObsoWorkTable(s, calPeriods, records, mlk);
                EFF_ObsoMLKDS.Tables.Add(mlkRes);

                var snkRes = CreateObsoWorkTable(s, calPeriods, records, snk);
                EFF_ObsoSNKDS.Tables.Add(snkRes);

            }

        }

        private DataTable CreateObsoWorkTable(int fiscalYear, List<string> calPeriods, DataRow[] obsoRecs, DataRow[] itemHier)
        {
            //Rows: MLK item Hierarchy and Add a row for Percent Total
            //Columns: Calendar Periods, Item Heirarch Level Headers

            DataTable obsoDT = new DataTable();
            obsoDT.TableName = fiscalYear.ToString();

            obsoDT.Columns.Add("Business Area", typeof(string));
            obsoDT.Columns.Add("Item Level 2", typeof(string));
            obsoDT.Columns.Add("Item Level 3", typeof(string));

            foreach(string s in calPeriods)
            {
                obsoDT.Columns.Add(s, typeof(double));
            }

            foreach(DataRow dr in itemHier)
            {
                obsoDT.Rows.Add(dr["Lvl1 Name"].ToString(), dr["Lvl2 Name"].ToString(), dr["Lvl3 Name"].ToString(), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
            }

           

            foreach (DataRow dr in obsoDT.Rows)
            {
                var lvl3 = dr["Item Level 3"].ToString();
                foreach (string s in calPeriods)
                {
                    if(obsoRecs.Length > 0)
                    {
                        DataTable obsoRecsDt = obsoRecs.CopyToDataTable();
                        var record = obsoRecsDt.Select("Calendar_YYYYMM = '" + s + "' AND [Level 3] = '" + lvl3 + "'");

                        if (record.Length == 1)
                        {
                            var pct = record[0];
                            dr[s] =Convert.ToDecimal(pct["Alloc Pct"]) * 100;
                        }
                    }
                   
                }
            }

            
            //Fill Totals List
            List<decimal> totals = new List<decimal>();
            for (int i = 3; i < 15; i++)
            {
                decimal total = 0;
                foreach (DataRow dr in obsoDT.Rows)
                {
                    total += Convert.ToDecimal(dr[i]);
                }
                totals.Add(total);
            }
            //Fill Totals row
            //Add Totals Row
            obsoDT.Rows.Add("", "", "Total:", totals[0], totals[1], totals[2], totals[3], totals[4], totals[5], totals[6], totals[7], totals[8], totals[9], totals[10], totals[11]);
            return obsoDT;

        }
        public void CreatePPVTimePeriodWorkTable()
        {
            if(PPVTime != null)
            {
                PPVTime.Dispose();
            }
            PPVTime = EFF_PPV_Period.Clone();
            PPVTime.Columns.Add("Previous Deferment", typeof(int));
            PPVTime.Columns.Add("ToUpdate", typeof(bool));
            PPVTime.Columns.Add("FiscalSort", typeof(int));



            foreach (DataRow dr in EFF_PPV_Period.Rows)
            {
                DateTime t = new DateTime(Convert.ToInt32(dr["PPV Period YYYYMM"].ToString().Substring(0, 4)), Convert.ToInt32(dr["PPV Period YYYYMM"].ToString().Substring(4, 2)), 01);
                DateTime f = new DateTime(Convert.ToInt32(dr["Sales Period YYYYMM"].ToString().Substring(0, 4)), Convert.ToInt32(dr["Sales Period YYYYMM"].ToString().Substring(4, 2)), 01);

                var res = Math.Round(t.Subtract(f).Days / 30.0);
                int srt = 0;
                //Fiscal Sort Order
                if(f.Month >= 4)
                {
                    srt = f.Month - 3;
                }
                else
                {
                    srt = f.Month + 9;
                }

                PPVTime.Rows.Add(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3], dr[4].ToString(), dr[5], res,false,srt);
            }
        }
        public void UpdatePPVTimePeriod()
        {
            var toUpdate = PPVTime.Select("ToUpdate = true");


            foreach (DataRow dr in toUpdate)
            {
                string pKey = dr["PeriodKey"].ToString();
                string ppvPeriod = dr["PPV Period YYYYMM"].ToString();
                string updateUser = Environment.UserName;
                string updateDate = DateTime.Now.ToShortDateString();

                m3c.Command(sql.Update1(updateUser, updateDate, ppvPeriod, pKey));

               

            }
            EFF_CustomDS.Tables.Remove(EFF_PPV_Period);

            EFF_PPV_Period = m3c.FillDataTable(sql.Select5());
            EFF_PPV_Period.TableName = "EFF_PPV_Period";

            EFF_CustomDS.Tables.Add(EFF_PPV_Period);
            CreatePPVTimePeriodWorkTable();



        }
        public void UpdateIPVAmountTable()
        {
            var toUpdate = IPVAmount.Select("ToUpdate = true");


            foreach (DataRow dr in toUpdate)
            {
                string pKey = dr["AmountKey"].ToString();
                string ipvAmt = dr["Recorded Amount"].ToString();
                string updateUser = Environment.UserName;
                string updateDate = DateTime.Now.ToShortDateString();

                m3c.Command(sql.Update2(updateUser, updateDate, ipvAmt, pKey));

                EFF_CustomDS.Tables.Remove(EFF_IPV_Amount);

                EFF_IPV_Amount = m3c.FillDataTable(sql.Select2());
                EFF_IPV_Amount.TableName = "EFF_IPV_Amount";

                EFF_CustomDS.Tables.Add(EFF_IPV_Amount);

            }
        }
        
        private void UpdateObsoAlloc(string YYYYMM,string Level3Name, string percent)
        {
            var user = Environment.UserName;
            var date = DateTime.Now.ToString();
            m3c.Command(sql.Update3(user, date, YYYYMM, Level3Name, percent));
        }
        private void InsertObsolAlloc(string YYYYMM, string Level3Name, string percent,string busArea,string level2Name)
        {
            var user = Environment.UserName;
            var date = DateTime.Now.ToString();
            m3c.Command(sql.Insert5(user, date, YYYYMM, Level3Name, percent, busArea, level2Name));
        }
        public void InsertOrUpdateObsolAlloc(string YYYYMM, string Level3Name, string percent, string busArea, string level2Name)
        {
            var res = EFF_CustomDS.Tables["EFF_Obsol_Alloc"].Select("Calendar_YYYYMM = '" + YYYYMM + "' and [Level 3] = '" + Level3Name + "'");

            if(res.Length > 0)
            {
                UpdateObsoAlloc(YYYYMM, Level3Name,percent);
            }
            else
            {
                InsertObsolAlloc(YYYYMM, Level3Name, percent, busArea, level2Name);
            }



        }

        private void InsertMarketingAlloc(string YYYYMM, string brand, string percent, string busArea, string levelID)
        {
            var res = ExpenseLevelDT.Select("LevelID = '" + levelID + "'");
            var levelKey = res[0]["LevelKey"].ToString();
            var user = Environment.UserName;
            m3c.Command(sql.Insert9(user, YYYYMM, brand,levelKey, busArea, percent));
        }

        private void UpdateMarketingAlloc(string YYYYMM, string brand, string percent, string busArea, string levelID)
        {
            var res = ExpenseLevelDT.Select("LevelID = '" + levelID + "'");
            var levelKey = res[0]["LevelKey"].ToString();
            var user = Environment.UserName;
            m3c.Command(sql.Update6(user, YYYYMM, brand, levelKey, busArea, percent));
        }
        public void InsertOrUpdateMktgAlloc(string YYYYMM, string brand, string percent, string busArea, string levelID)
        {
            var res = EFF_CustomDS.Tables["EFF_Mktg_Exp_Alloc"].Select("Calendar_YYYYMM = '" + YYYYMM + "' and [LevelID] = '" + levelID + "' AND Brand ='" + brand + "'");

            if (res.Length > 0)
            {
                 UpdateMarketingAlloc(YYYYMM,brand,percent,busArea,levelID);
            }
            else
            {
                InsertMarketingAlloc(YYYYMM, brand, percent, busArea, levelID);
            }



        }
        private void InsertExpenseAlloc(string YYYYMM, string LevelID, string percent, string busArea)
        {
            var res = ExpenseLevelDT.Select("LevelID = '" + LevelID + "'");
            var levelKey = res[0]["LevelKey"].ToString();
            var user = Environment.UserName;
            m3c.Command(sql.Insert7(user, YYYYMM, levelKey, busArea, percent));

        }
        private void UpdateExpenseAlloc(string expKey, string percent)
        {
            var user = Environment.UserName;
            var date = DateTime.Now.ToString();
            m3c.Command(sql.Update5(expKey,user, percent));
        }
        public void InsertOrUpdateExpenseAlloc(string YYYYMM, string LevelID, string percent, string busArea)
        {
            var res = EFF_CustomDS.Tables["EFF_Expense_Alloc"].Select("Calendar_YYYYMM = '" + YYYYMM + "' AND LevelID = '" + LevelID + "'");

            if (res.Length > 0)
            {
                var expKey = res[0]["CorpExpKey"].ToString();
                UpdateExpenseAlloc(expKey, percent);
            }
            else
            {
                InsertExpenseAlloc(YYYYMM, LevelID, percent, busArea);
            }



        }
        private void InsertAmortAmount(string yyyymm, string brand, string busArea, string account, string amount)
        {
            var user = Environment.UserName;
            m3c.Command(sql.Insert6(user, yyyymm, brand, busArea, account, amount));
        }

        public void InsertOneTimeMapping(string fiscalYear, string expLevelKey, string costCtr)
        {
            var user = Environment.UserName;
            m3c.Command(sql.Insert8(fiscalYear,expLevelKey,costCtr,user));
            RefreshOneTimeExpenseMapData();

        }
        private void UpdateAmortAmount(string amortKey, string amount)
        {
            var user = Environment.UserName;
            m3c.Command(sql.Update4(amortKey,amount,user));
        }

        public void InsertOrUpdateAmortAmount(DataTable dt)
        {
            foreach (DataRow dr in dt.Rows)
            {
                var yyyymm = dr["YYYYMM"].ToString();
                var ba = dr["BusArea"].ToString();
                var brand = dr["Brand"].ToString();
                var acct = dr["AcctDesc"].ToString().Substring(0, 6);
                var amount = dr["Amount"].ToString();

                var res = EFF_CustomDS.Tables["EFF_Amortization"].Select("Calendar_YYYYMM = '" + yyyymm + "' AND [Brand Name] = '" + brand + "' AND [GL Account] = '" + acct + "'");
                if (res.Length == 1)
                {
                    var key = res[0]["AmortizationKey"].ToString();
                    UpdateAmortAmount(key, amount);
                }
                else
                {
                    InsertAmortAmount(yyyymm, brand, ba, acct, amount);
                }

                RefreshAmortizartionAllocData();
            }
           
        }

        public void SetCurrentFiscalYear()
        {
            var date = DateTime.Now;
            var year = date.Year;
            var month = date.Month;

            if(month >= 4)
            {
                year += 1;
            }


            CurrentFiscalYear = year.ToString();
        }

       public void SetCurrentCloseDateYYYYMM()
       {
            CloseYYYYMM = "";
            //var month = DateTime.Now.Month.ToString();
            //var year = DateTime.Now.Year.ToString();

            //if (DateTime.Now.Day <= 10)
            //{
            //    month = DateTime.Now.AddMonths(-1).Month.ToString();
            //    year = DateTime.Now.AddMonths(-1).Year.ToString();
            //}


            //if (month.Length == 1)
            //{
            //    month = "0" + month.ToString();
            //}

            //CloseYYYYMM = year + month;

            CloseYYYYMM = m3c.LineReader(sql.Select18());
        }

        public bool InsertNewPPVAccount(string account)
        {
            var exist = m3ViewsDS._FCHACC___Chart_of_accounts_Accounting_dimension_1.Select("[Accounting identity] = '" + account + "'");

            if(exist.Length == 1)
            {
                string updateUser = Environment.UserName;
                string updateDate = DateTime.Now.ToShortDateString();
                m3c.Command(sql.Insert1(updateUser,updateDate, account));

               

                EFF_CustomDS.Tables.Remove(EFF_PPV_Account);

                EFF_PPV_Account = m3c.FillDataTable(sql.Select4());
                EFF_PPV_Account.TableName = "EFF_PPV_Account";

                EFF_CustomDS.Tables.Add(EFF_PPV_Account);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool InsertNewIPVAccount(string account)
        {
            var exist = m3ViewsDS._FCHACC___Chart_of_accounts_Accounting_dimension_1.Select("[Accounting identity] = '" + account + "'");

            if (exist.Length == 1)
            {
                string updateUser = Environment.UserName;
                string updateDate = DateTime.Now.ToShortDateString();
                m3c.Command(sql.Insert2(updateUser, updateDate, account));



                EFF_CustomDS.Tables.Remove(EFF_IPV_Account);

                EFF_IPV_Account = m3c.FillDataTable(sql.Select1());
                EFF_IPV_Account.TableName = "EFF_IPV_Account";

                EFF_CustomDS.Tables.Add(EFF_IPV_Account);
                return true;
            }
            else
            {
                return false;
            }
        }


        public bool InsertNewIPVItem(string item)
        {
            var exist = m3ViewsDS._MITMAS___Item_Master.Select("[Item number] = '" + item + "'");

            if (exist.Length == 1)
            {
                string updateUser = Environment.UserName;
                string updateDate = DateTime.Now.ToShortDateString();
                m3c.Command(sql.Insert3(updateUser, updateDate, item));



                EFF_CustomDS.Tables.Remove(EFF_IPV_Item);

                EFF_IPV_Item = m3c.FillDataTable(sql.Select3());
                EFF_IPV_Item.TableName = "EFF_IPV_Item";

                EFF_CustomDS.Tables.Add(EFF_IPV_Item);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool InsertNewIPVTransaction(decimal amount,string busArea, string item, string account, string calYYYYMM)
        {
            var exist = EFF_IPV_Amount.Select("[Item] = '" + item + "' AND [Business Area] = '" + busArea + "' AND [GL Account] = '" + account + "' AND [YYYYMM] = '" + calYYYYMM + "'");

            if (exist.Length == 0)
            {
                string updateUser = Environment.UserName;
                string updateDate = DateTime.Now.ToShortDateString();
                m3c.Command(sql.Insert4(updateUser, updateDate, item,busArea,calYYYYMM,account,amount.ToString()));



                EFF_CustomDS.Tables.Remove(EFF_IPV_Amount);

                EFF_IPV_Amount = m3c.FillDataTable(sql.Select2());
                EFF_IPV_Amount.TableName = "EFF_IPV_Amount";

                EFF_CustomDS.Tables.Add(EFF_IPV_Amount);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
