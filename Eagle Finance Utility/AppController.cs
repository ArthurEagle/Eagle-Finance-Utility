using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eagle_Finance_Utility
{
    class AppController
    {
        public static void InitializeApp()
        {
            // Add intializaltion Code
            DataController.LoadRawMaterialItemsAndAccounts();
            DataController.LoadIPV_PPV_ObsoWithPrimaryData();
            DataController.SetCurrentFiscalYear();
            DataController.SetCurrentCloseDateYYYYMM();
            DataController.CreateObsolescenceWorkTables();
        }
        private static DataController dataController;

        public static DataController DataController
        {
            get
            {
                if (dataController == null)
                {
                    dataController = new DataController();
                }
                return dataController;
            }
        }
        private static UserController userController;

        public static UserController UserController
        {
            get
            {
                if (userController == null)
                {
                    userController = new UserController();
                }
                return userController;
            }
        }
    }
}
