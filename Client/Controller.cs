using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Client
{
    public class Controller
    {
        DataManager dm = new DataManager();
        public int insertclient(string name, int tablenumber)
        {
        
            var dict = new Dictionary<string, object>() { { "@TNUMBER", tablenumber}, { "@Cname", name} };
            string query = "spinsertClient";
            var output1 = dm.ExecuteScalar(query, dict);
            return (int)output1;
  
        }

        public int checktablenumber(int tablenumber)
        {
            var dict = new Dictionary<string, object>() { { "@TNUMBER", tablenumber } };
            string query = "spchecktable";
            var output1 = dm.ExecuteScalar(query, dict);
            return (int)output1;
          
        }
        public int checktablestatus(int tablenumber)
        {
            var dict = new Dictionary<string, object>() { { "@TNUMBER", tablenumber } };
            string query = "spchecktablestatus";
            var output1 = dm.ExecuteScalar(query, dict);
            return (int)output1;

        }
        public void updatetablestatus(int tablenumber, bool status)
        {
            var dict = new Dictionary<string, object>() { { "@TNUMBER", tablenumber }, { "@status", status } };
            string query = "updatetablestatus";
            dm.ExecuteScalar(query, dict);
        }
        public bool InsertCR(int CID, int tablenum, DateTime time, bool check)
        {
            
            var dict = new Dictionary<string, object>() { { "@CID", CID }, { "@TNUMBER", tablenum }, { "@TIME", time }, { "@CHECK", check } };
            string query = "spinsertCR";
            dm.ExecuteNonQuery(query, dict);
            bool flag = true;
            return flag;
        }
        public List<MenuItem> getmenuitems()
        {

            string query = "spmenuuser";
            var output2 = dm.ExecuteReader(query, null);
            //return output2;
            List<MenuItem> lmi = new List<MenuItem>();
            foreach (DataRow DR in output2.Rows)
            {
                MenuItem mi = new MenuItem(Convert.ToInt32(DR[0]), Convert.ToString(DR[1]), Convert.ToString(DR[4]),(float) Convert.ToDouble(DR[3]), ((DR[2]) == System.DBNull.Value) ? -1 : (float)Convert.ToDouble(DR[2]));
                lmi.Add(mi);
                
            }
            return lmi;
        }
        public int InsertOR(int CID,int status, int tablenum, DateTime time)
        {

            var dict = new Dictionary<string, object>() { { "@CID", CID }, { "@STATUS", status}, { "@TNUMBER", tablenum }, { "@TIME", time } };
            string query = "spinsertORDER";
            var output1 = dm.ExecuteScalar(query, dict);
            return (int)output1;
        }
        public bool InsertORMI(int orderid, int itemnumber)
        {
            
                var dict = new Dictionary<string, object>() { { "@ORDERID", orderid }, { "@ITEMNUMBER", itemnumber } };
                string query = "spinsertORMI";
                var x= dm.ExecuteNonQuery(query, dict);
                return true;
        }
    }
}
