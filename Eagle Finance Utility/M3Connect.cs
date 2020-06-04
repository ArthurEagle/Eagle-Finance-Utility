using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace Eagle_Finance_Utility
{
    class M3Connect
    {
        // private string ConnString = "Driver={SQL Server};Server=172.16.9.11;UID=EFFUser;PWD=P@ssword!;Database=M3FDBPRD;";
       // private string ConnString = "Driver={SQL Server};Server=172.16.12.243;UID=EFFUser;PWD=P@ssword!;Database=M3CUSTOMDB;";
        private string ConnString = "Provider=SQLOLEDB;Data Source=172.16.9.12;Initial Catalog=BPW_PRD_Custom;Persist Security Info = True; User ID = Alewis; Password =P@ssw0rd!123456";

        public string[] IsServerConnected()
        {
            string[] sArr = new string[2];

            using (OleDbConnection connection =
              new OleDbConnection(ConnString))
            {
                try
                {
                    connection.Open();
                    connection.Close();
                    sArr[0] = "T";
                    return sArr;
                }
                catch (Exception ex)
                {
                    sArr[0] = "F";
                    sArr[1] = ex.Message;
                    return sArr;
                }
            }
        }
        public DataTable FillDataTable(string sql)
        {
            DataTable dt = new DataTable();
            using (OleDbConnection connection =
              new OleDbConnection(ConnString))
            {
                OleDbDataAdapter adapter =
                    new OleDbDataAdapter(sql, connection);

                // Open the connection and fill the DataSet.
                try
                {
                    connection.Open();
                    adapter.Fill(dt);
                    connection.Close();
                }
                catch (Exception ex)
                {
                    string msg = "Please send the following error to Eagle IT group support: \r\n" +
                        "SQL: " + sql + "\r\n" +
                        "Error: " + ex.Message;
                    MessageBox.Show(msg);
                }

                return dt;
            }
        }
        public void Command(string sql)
        {
            using (OleDbConnection connection = new OleDbConnection(ConnString))
            {
                OleDbCommand cmd = new OleDbCommand(sql, connection);
                // Open the connection and fill the DataSet.
                try
                {
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    string msg = "Please send the following error to Eagle IT group support: \r\n" +
                        "SQL: " + sql + "\r\n" +
                        "Error: " + ex.Message;
                    MessageBox.Show(msg);
                }
            }
        }
        public string LineReader(string sql)
        {
            string txt = "";
            using (OleDbConnection connection = new OleDbConnection(ConnString))
            {
                OleDbCommand cmd = new OleDbCommand(sql, connection);
                // Open the connection and fill the DataSet.
                try
                {
                    connection.Open();
                    OleDbDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        txt = reader[0].ToString();
                    }
                    connection.Close();

                }
                catch (Exception ex)
                {
                    string msg = "Please send the following error to Eagle IT group support: \r\n" +
                        "SQL: " + sql + "\r\n" +
                        "Error: " + ex.Message;
                    MessageBox.Show(msg);
                }
            }
            return txt;
        }

    }
}
