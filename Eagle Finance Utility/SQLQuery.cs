using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eagle_Finance_Utility
{
    class SQLQuery
    {
        public string Select1()
        {
            string sql = "SELECT * FROM EFF_IPV_Account_Management";
            return sql;
        }
        public string Select2()
        {
            string sql = "SELECT * FROM EFF_IPV_Amount_Management";
            return sql;
        }
        public string Select3()
        {
            string sql = "SELECT * FROM EFF_IPV_Item_Management";
            return sql;
        }
        public string Select4()
        {
            string sql = "SELECT * FROM EFF_PPV_Account_Management";
            return sql;
        }
        public string Select5()
        {
            string sql = "SELECT [PeriodKey],[Business Area],[Sales Period YYYYMM],[PPV Period YYYYMM],[Update User],[Update Date] FROM EFF_PPV_Period_Management";
            return sql;
        }
        public string Select6()
        {
            string sql = "SELECT Calendar_YYYYMM, [Business Area],  [Level 2], [Level 3], [Alloc Pct],"+
                "IIF(CAST(RIGHT(Calendar_YYYYMM, 2) AS INT) >= 4, CAST(LEFT(Calendar_YYYYMM, 4) AS INT) + 1, CAST(LEFT(Calendar_YYYYMM, 4) AS INT)) FiscalYear FROM EFF_Obsolescence_Allocation";
            return sql;
        }
        public string Select7(string currentCloseYYYYMM)
        {
            string sql = "SELECT i.MMHIE3[Level3ID],i.[Lvl3 Name]  " +
                        " FROM dbo.Sales_Master " +
                        " JOIN dbo.EFF_ItemHierarchy i " +
                        " ON MMITNO = [Product SKU] " +
                        " WHERE Calendar_YYYYMM = '202005' " +
                        "AND [Data Version] = 'Actual' " +
                        "AND [Line Status] = 'Invoiced Completed' " +
                        "AND [GL Account] = '401000' " +
                        "AND [Invoiced Amount] > 0 " +
                        "GROUP BY i.MMHIE3,i.[Lvl3 Name] ";
            return sql;

        }
        public string Select8(string currentCloseYYYYMM)
        {
            //string sql = "SELECT i.MMHIE1[Level1ID],RTRIM(i.[Lvl1 Name])[Lvl1 Name],i.MMHIE2[Level2ID],RTRIM(i.[Lvl2 Name])[Lvl2 Name],i.MMHIE3[Level3ID], RTRIM(i.[Lvl3 Name])[Lvl3 Name]" +
            //        " ,IIF(ISNULL(SUM(isnull([Invoiced Amount],0)),0) > 0,1,0) [Has Sales] " +
            //        " FROM dbo.EFF_ItemHierarchy i " +
            //        " LEFT JOIN dbo.Sales_Master ON [Product SKU] = [MMITNO] " +
            //        " AND [Data Version] = 'Actual' AND [Line Status] = 'Invoiced Completed' AND [Invoiced Amount] > 0 AND Calendar_YYYYMM = '" + currentCloseYYYYMM + "' " +
            //        " WHERE i.MMHIE2 IS NOT NULL " +
            //        " AND i.MMHIE3 IS NOT NULL " +
            //        " GROUP BY i.MMHIE1 , i.[Lvl1 Name], i.MMHIE2 , i.[Lvl2 Name], i.MMHIE3 , i.[Lvl3 Name]" +
            //        " ORDER BY i.MMHIE1 , i.[Lvl1 Name], i.MMHIE2 , i.[Lvl2 Name], i.MMHIE3 , i.[Lvl3 Name]  ";
            string sql = "SELECT Level1ID,       [Lvl1 Name],       Level2ID,       [Lvl2 Name],       Level3ID,       [Lvl3 Name],       [Has Sales] " +
                        "FROM dbo.EFF_ItemHierHasSalesClosePeriod";
            return sql;

        }
        public string Select9()
        {
            string sql = "SELECT * " +
            " FROM dbo.EFF_Expense_Allocation_Level " +
            " WHERE LevelID <> 'ALLOCATION' ";
            return sql;
        }
        public string Select10(string currentCloseYYYYMM)
        {
            //string sql = "SELECT [Business area], "+
            //" CASE when [User-defined field 3 - item name] = 'PRIVATE LABEL' then 'PRIVATE LABEL' ELSE[Product group name] END AS Brand, " +
            //" IIF(SUM(isnull([Invoiced Amount],0)) > 0,1,0) [Has Sales] " +
            //" FROM STD_BPW_PRD_Datamarts.dbo.Dim_Items LEFT JOIN dbo.Sales_Master ON [Product SKU] = [Item number] " +
            //" AND [Data Version] = 'Actual' AND [Line Status] = 'Invoiced Completed' AND [Invoiced Amount] > 0 AND Calendar_YYYYMM = '"+ currentCloseYYYYMM + "' " +
            //" WHERE [Item Group] like '10%' " +
            //" GROUP BY CASE WHEN [User-defined field 3 - item name] = 'PRIVATE LABEL' THEN 'PRIVATE LABEL' ELSE [Product group name]   END,    [Business area] " +
            //" UNION ALL " +
            //" SELECT 'MLK','MILK',1" +
            //" UNION ALL" +
            //" SELECT 'SNK','CORNFIELDS',1";
            string sql = "Select * FROM EFF_BrandHasSalesClosePeriod";
            return sql;
        }
        public string Select11()
        {
            string sql = "SELECT a.*,m.Description,a.[GL Account] + ' - ' + m.Description[GL Acct Desc], "+
            " IIF(CAST(RIGHT(Calendar_YYYYMM, 2) AS INT) >= 4, CAST(LEFT(Calendar_YYYYMM, 4) AS INT) + 1, CAST(LEFT(Calendar_YYYYMM, 4) AS INT)) FiscalYear " +
            " FROM dbo.EFF_Amortization a " +
            " JOIN dbo.GL_Mapping m " +
            " ON m.[GL Account] =a.[GL Account]";
            return sql;
        }
        public string Select12()
        {
            string sql = " SELECT [GL Account],[Description],CAST([GL Account] AS VARCHAR(6)) + ' - ' + Description [GL Acct Desc] "+
             " FROM dbo.GL_Mapping WHERE Cat1 = 'Amortization'";
            return sql;
        }
        public string Select13()
        {
            string sql = "SELECT CorpExpKey,ExpenseLevelKey,LevelID, Calendar_YYYYMM, ce.[Business Area], " +
                    " [Alloc Pct], " +
                    " IIF(CAST(RIGHT(Calendar_YYYYMM, 2) AS INT) >= 4, CAST(LEFT(Calendar_YYYYMM, 4) AS INT) + 1, CAST(LEFT(Calendar_YYYYMM, 4) AS INT)) FiscalYear  "+
                    " FROM dbo.EFF_Corporate_Expense_Allocation ce " +
                    " JOIN dbo.EFF_Expense_Allocation_Level el" +
                    " ON ExpenseLevelKey = LevelKey";;
            return sql;
        }
        public string Select14()
        {
            string sql = "SELECT LevelKey,LevelID,[Business Area] " +
                        " FROM dbo.EFF_Expense_Allocation_Level";
            return sql;
        }
        public string Select15()
        {
            string sql = "SELECT ot.FiscalYear, ot.CostCenterID, lv.LevelID,lv.[Update User],lv.[Update Date] "+
                        " FROM dbo.EFF_OneTimeExpense_Mapping ot " +
                        " JOIN dbo.EFF_Expense_Allocation_Level lv " +
                        " ON ot.ExpenseLevelKey = lv.LevelKey " +
                        " ORDER BY ot.FiscalYear DESC, lv.LevelID ASC";
            return sql;
        }
        public string Select16()
        {
            string sql = "SELECT MarketingKey, ma.[Business Area], Brand, Calendar_YYYYMM, [Alloc Pct], LevelKey, LevelID, "+
                        " IIF(CAST(RIGHT(Calendar_YYYYMM, 2) AS INT) >= 4, CAST(LEFT(Calendar_YYYYMM, 4) AS INT) + 1, CAST(LEFT(Calendar_YYYYMM, 4) AS INT)) FiscalYear "+
                        " FROM dbo.EFF_Marketing_Allocation ma " +
                        " JOIN dbo.EFF_Expense_Allocation_Level " +
                        " ON LevelKey = ExpenseLevelKey";
            return sql;
        }

        public string Select17()
        {
            string sql = "SELECT DISTINCT ma.[Business Area], Brand, LevelKey, LevelID "+
                        " FROM dbo.EFF_Marketing_Allocation ma "+
                        " JOIN dbo.EFF_Expense_Allocation_Level "+
                        " ON LevelKey = ExpenseLevelKey "+
                        " ORDER BY ma.[Business Area], LevelID, ma.Brand";
            return sql;
        }
        public string Select18()
        {
            string sql = "Select dbo.EFF_Get_ClosePeriod()";
            return sql;
        }
        public string Update1(string updateUser,string updateDate, string newPPVPeriod,string periodKey)
        {
            string sql = "UPDATE EFF_PPV_Period_Management SET [Update User] = '" + updateUser + "'" +
                " , [Update Date] = '" + updateDate + "'" +
                 " , [PPV Period YYYYMM] = '" + newPPVPeriod + "'" +
                " WHERE periodKey = " + periodKey;
            return sql;
        }

        public string Update2(string updateUser, string updateDate, string newAmount, string amountKey)
        {
            string sql = "UPDATE EFF_IPV_Amount_Management SET [Update User] = '" + updateUser + "'" +
                " , [Update Date] = '" + updateDate + "'" +
                 " , [Recorded Amount] = " + newAmount + 
                " WHERE AmountKey = " + amountKey;
            return sql;
        }

        public string Update3(string updateUser, string updateDate, string yyyymm,string level3Name, string percent)
        {
            string sql = "UPDATE EFF_Obsolescence_Allocation " +
                " SET [Update User] = '" + updateUser + "'" +
                " , [Update Date] = '" + updateDate + "'" +
                ", [Alloc Pct] = '" + percent + "'" +
                " WHERE Calendar_YYYYMM = '" + yyyymm + "'" +
                " AND [Level 3] = '" + level3Name + "'";
            return sql;
        }
        public string Update4(string amortKey,string amount,string updateUser)
        {
            string sql = "UPDATE dbo.EFF_Amortization " +
            " SET Amount = "+amount+",[Update User] = '"+updateUser+"', [Update Date] = GETDATE()" +
            " WHERE AmortizationKey = "+amortKey;
            return sql;
        }
        public string Update5(string expKey,string user,string percent)
        {
            string sql = "UPDATE dbo.EFF_Corporate_Expense_Allocation "+
            " SET[Alloc Pct] = "+percent + ",[Update User] = '"+user+"',[Update Date] = GetDate() "+
            " WHERE CorpExpKey = " + expKey;
            return sql;
        }
        public string Update6(string updateUser, string yyyymm, string brand, string expLevelKey, string busArea, string percent)
        {
            string sql = "UPDATE dbo.EFF_Marketing_Allocation " +
            " SET[Alloc Pct] = " + percent + " ,[Update User] = '"+updateUser+"' ,[Update Date] = GetDate() "+
            " WHERE Calendar_YYYYMM = '"+yyyymm+"' AND[Business Area] = '"+busArea+"' " +
            " AND Brand = '"+brand+"' AND ExpenseLevelKey = "+ expLevelKey;
            return sql;
        }
        public string Insert1(string updateUser, string updateDate, string account)
        {
            string sql = "INSERT INTO EFF_PPV_Account_Management ([Update User], [Update Date] , [GL Account] ) VALUES ('" + updateUser + "','" + updateDate + "','" + account + "')";
            return sql;
        }

        public string Insert2(string updateUser, string updateDate, string account)
        {
            string sql = "INSERT INTO EFF_IPV_Account_Management ([Update User], [Update Date] , [GL Account] ) VALUES ('" + updateUser + "','" + updateDate + "','" + account + "')";
            return sql;
        }

        public string Insert3(string updateUser, string updateDate, string item)
        {
            string sql = "INSERT INTO EFF_IPV_Item_Management ([Update User], [Update Date] , [item] ) VALUES ('" + updateUser + "','" + updateDate + "','" + item+ "')";
            return sql;
        }

        public string Insert4(string updateUser, string updateDate, string item,string busArea, string date,string account,string amount)
        {
            string sql = "INSERT INTO EFF_IPV_Amount_Management ([Update User], [Update Date] , [item], [YYYYMM],[GL Account], [Recorded Amount],[Business Area] ) VALUES ('" + 
                updateUser + "','" + updateDate + "','" + item + "','" + date + "','" + account + "'," + amount + ",'" + busArea + "')";
            return sql;
        }
        public string Insert5(string updateUser, string updateDate, string yyyymm, string level3Name, string percent,string busArea,string level2Name)
        {
            string sql = "INSERT INTO dbo.EFF_Obsolescence_Allocation (Calendar_YYYYMM,[Business Area],[Level 2],[Level 3],[Alloc Pct],[Update Date],[Update User]) " +
                        " VALUES('" + yyyymm + "','" + busArea + "','" + level2Name + "','" + level3Name + "'," + percent + ",'" + updateDate + "','" + updateUser + "') ";
              
            return sql;
        }
        public string Insert6(string updateUser, string yyyymm, string brand, string busArea, string account,string amount)
        {
            string sql = "INSERT INTO dbo.EFF_Amortization "+
                " ( [Business Area], [Brand Name], [GL Account], Calendar_YYYYMM,    Amount,    [Update User],    [Update Date]) "+
                " VALUES( '"+busArea+"', '"+brand+"', '"+ account + "', '"+yyyymm+"',"+amount+", '"+updateUser+"', GETDATE())";
            return sql;
        }
        public string Insert7(string updateUser, string yyyymm, string LevelKey, string busArea, string percent)
        {
            string sql = "INSERT INTO dbo.EFF_Corporate_Expense_Allocation ( ExpenseLevelKey, Calendar_YYYYMM, [Business Area], "+
             " [Alloc Pct], [Update User], [Update Date]) VALUES ("+ LevelKey + ", '" + yyyymm + "', '" + busArea + "'," + percent + ", '" + updateUser + "', GETDATE())";
            return sql;
        }

        public string Insert8(string fiscalYear, string expLevelKey,string costCtr,string user)
        {
            string sql = "INSERT INTO dbo.EFF_OneTimeExpense_Mapping(    FiscalYear,    ExpenseLevelKey,    CostCenterID,    [Update User],    [Update Date]) "+
             " VALUES('"+fiscalYear+"', "+expLevelKey+", '"+costCtr+"', '"+user+"', GETDATE())";
            return sql;
        }

        public string Insert9(string updateUser, string yyyymm,string brand, string expLevelKey, string busArea, string percent)
        {
            string sql = "INSERT INTO dbo.EFF_Marketing_Allocation " +
             " (    [Business Area], Brand, Calendar_YYYYMM,    [Alloc Pct], ExpenseLevelKey,[Update User],[Update Date]) " +
            " VALUES('"+busArea+"', '"+brand+"', '"+yyyymm+"',"+percent+", "+expLevelKey+", '"+updateUser+"',GetDate())";
            return sql;
        }
    }
}
