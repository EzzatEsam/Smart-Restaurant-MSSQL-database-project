using System;
using System.Collections.Generic;
using System.Text;


namespace Client
{
    public class Controller
    {
        DataManager dm = new DataManager();
        public void insertclient(string name, int tablenumber)
        {
        
            var dict = new Dictionary<string, object>() { { "@TNUMBER", tablenumber}, { "@Cname", name} };
            string query = "spinsertClient";
            var output1=dm.ExecuteNonQuery(query, dict);
            int x =0;
        }

        public int checktablenumber(int tablenumber)
        {
            var dict = new Dictionary<string, object>() { { "@TNUMBER", tablenumber } };
            string query = "spchecktable";
            //var output1 = dm.ExecuteNonQuery(query, dict);
            return (int) dm.ExecuteScalar(query, dict);
            
        }

    }
}
