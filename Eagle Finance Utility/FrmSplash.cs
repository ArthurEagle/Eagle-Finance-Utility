using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.NetworkInformation;
using System.Diagnostics;

namespace Eagle_Finance_Utility
{
    public partial class FrmSpalsh : Form
    {
        public FrmSpalsh()
        {
            InitializeComponent();
            SetVersionLabel();
            CheckNetworkAvailable();
            BeginDataLoad();
        }
        bool hasInternetAccess = false;
        bool hasDBAccess = false;
        string errMsg = "";
        private void CheckSeverAccess()
        {
            M3Connect m3C = new M3Connect();
            string[] result = m3C.IsServerConnected();
            if (result[0] == "T")
            {
                hasDBAccess = true;
            }
            else
            {
                errMsg = result[1];
                hasDBAccess = false;
            }
        }
        private void CheckNetworkAvailable()
        {
            var access = NetworkInterface.GetIsNetworkAvailable();
            if (access)
            {
                hasInternetAccess = true;
                CheckSeverAccess();
            }
            else
            {
                hasInternetAccess = false;
            }
        }
        private void SetVersionLabel()
        {
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            string version = fvi.FileVersion;

            //lblVersion.Text = "App Version: " + version;
        }
        private void BeginDataLoad()
        {
            if (hasInternetAccess)
            {
                if (hasDBAccess)
                {
                    backgroundWorker1.RunWorkerAsync();
                }
                else
                {
                    MessageBox.Show("Application could not connect to the database server. Please make sure you are connected to the corporate network or connect via VPN."
                        + Environment.NewLine
                        + "Error Message: " + errMsg);
                    Application.Exit();
                }
            }
            else
            {
                MessageBox.Show("Make sure you are connected to the internet.");
                Application.Exit();
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            worker.WorkerReportsProgress = true;
            // Assign the result of the computation
            // to the Result property of the DoWorkEventArgs
            // object. This is will be available to the 
            // RunWorkerCompleted eventhandler.
            //   worker.ReportProgress(1);
           AppController.InitializeApp();

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
            }
            else
            {
                // Finally, handle the case where the operation 
                // succeeded.              
                FrmMainMenu frmMN = new FrmMainMenu();
                frmMN.Show();
                this.Hide();
            }
        }
    }
}
