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
        public string Select7()
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
        public string Select8()
        {
            string sql = "SELECT i.MMHIE1 [Level1ID],RTRIM(i.[Lvl1 Name]) [Lvl1 Name],i.MMHIE2 [Level2ID],RTRIM(i.[Lvl2 Name]) [Lvl2 Name],i.MMHIE3 [Level3ID], RTRIM(i.[Lvl3 Name])[Lvl3 Name]  " +
                        " FROM dbo.EFF_ItemHierarchy i " +
                        "  WHERE i.MMHIE2 IS NOT NULL " +
                         " AND i.MMHIE3 IS NOT NULL " +
                        " GROUP BY i.MMHIE1 ,i.[Lvl1 Name],i.MMHIE2 ,i.[Lvl2 Name],i.MMHIE3 ,i.[Lvl3 Name] ";
            return sql;

        }
        public string Select9()
        {
            string sql = "SELECT * " +
            " FROM dbo.EFF_Expense_Allocation_Level " +
            " WHERE LevelID <> 'ALLOCATION' ";
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
    }
}
