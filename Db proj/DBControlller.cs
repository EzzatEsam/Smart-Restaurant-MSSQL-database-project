using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace Db_proj
{
    public class DBControlller
    {
        FormOrganiser main;
        public DBControlller(FormOrganiser main)
        {
            this.main = main;
        }
        public void Login(string user , string password)
        {
            DBManager manager = new DBManager();
            var dict = new Dictionary<string, object>() { { "username", user }, { "pass", password } };
            DataTable output= manager.ExecuteReader(DBStrings.LoginCommand, dict);
            if (output != null)
            {
                main.GoTo (Convert.ToInt16( output.Rows[0][2])+1);   
            }
            manager.CloseConnection();
        }
        public DataTable GetAllEmployees()
        {
            DBManager manager = new DBManager();
            var output = manager.ExecuteReader(DBStrings.GetAllEmpsCommand, null);
            manager.CloseConnection();
            return (DataTable)output;
        }

        }
       
}

