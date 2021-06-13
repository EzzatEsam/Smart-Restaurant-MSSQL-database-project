using System;
using System.Collections.Generic;
using System.Data;

namespace Client
{
    public class Controller
    {
        DataManager dm = new DataManager();
        public int Insertclient(string name, int tablenumber)
        {

            var dict = new Dictionary<string, object>() { { "@TNUMBER", tablenumber }, { "@Cname", name } };
            string query = "spinsertClient";
            var output1 = dm.ExecuteScalar(query, dict);
            return (int)output1;

        }

        public DataTable GetTables()
        {

            return dm.ExecuteReader("GetTables", null);

        }
        public byte[] GetLogo()
        {
            return (byte[])dm.ExecuteScalar(DataBaseEssentials.GetLogoCommand, null);
        }

        public List<int> GetEmptyTableNums()
        {
            var output = dm.ExecuteReader("GetEmptyTablesNums", null);
            List<int> Out_ = new List<int>();
            if (output == null)
            {
                return null;
            }
            foreach (DataRow item in output.Rows)
            {
                Out_.Add((int)item[0]);
            }
            return Out_;
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
            var output = dm.ExecuteNonQuery(query, dict);
            bool flag = true;
            return flag;
        }
        public void End()
        {
            dm.CloseConnection();
        }

        public bool InsertRate(int cid, int itmNum, int rate)
        {
            var dict = new Dictionary<string, object>() { { "@ITEMNUMBER", itmNum }, { "@RATE", rate }, { "@CID", cid } };
            return (int)dm.ExecuteNonQuery("spinsertRATE", dict) == 1;
        }
        public List<MenuItem> Getmenuitems()
        {

            var output = dm.ExecuteReader(DataBaseEssentials.GetAllMenuCommand, null);

            List<MenuItem> lmi = new List<MenuItem>();
            var it = (DataTable)output;
            foreach (DataRow DR in it.Rows)
            {
                MenuItem mi = DataBaseEssentials.ConvertToMenuItemClass(DR);

                lmi.Add(mi);

            }
            return lmi;
        }

        public List<MenuItem> GetClientWholeMenu(int id)
        {
            var WholeMenu = new List<MenuItem>();

            var output = dm.ExecuteReader(DataBaseEssentials.GetAllOrderByClientCommand, new Dictionary<string, object>() { { "@ID", id } });
            if (output == null)
            {
                return WholeMenu;
            }
            foreach (DataRow item in output.Rows)
            {
                var test = item["ORDERID"];
                DataTable Itms = dm.ExecuteReader(DataBaseEssentials.GetItemsInOrderCommand, new Dictionary<string, object>() { { "@ordernum", item["ORDERID"] } });

                if (Itms != null)    // check if order has no items in it ... wont come true ... only for debugging
                {
                    foreach (DataRow itm in Itms.Rows)
                    {
                        WholeMenu.Add(DataBaseEssentials.ConvertToMenuItemClass(itm));
                    }
                }
            }



            return WholeMenu;
        }
        public int InsertOR(int CID, int status, int tablenum, DateTime time)
        {

            var dict = new Dictionary<string, object>() { { "@CID", CID }, { "@STATUS", status }, { "@TNUMBER", tablenum }, { "@TIME", time } };
            string query = "spinsertORDER";
            var output1 = dm.ExecuteScalar(query, dict);
            return Convert.ToInt16(output1);
        }
        public List<Order> GetAllOrdersByClientID(int ID)
        {

            var dict = new Dictionary<string, object>() { { "@ID", ID } };
            var output = dm.ExecuteReader(DataBaseEssentials.GetAllOrderByClientCommand, dict);
            List<Order> Orders = new List<Order>();
            if (output == null)
            {
                dm.CloseConnection();
                return Orders;
            }
            for (int i = 0; i < output.Rows.Count; i++)
            {
                Order NewOrder = new Order();
                NewOrder.OrderID = Convert.ToInt16(output.Rows[i][0]);
                NewOrder.ClientID = Convert.ToInt16(output.Rows[i][1]);
                NewOrder.Status = (Order_status)Convert.ToInt16(output.Rows[i][2]);
                NewOrder.TableNo = Convert.ToInt16(output.Rows[i][3]);
                NewOrder.OrderTime = TimeSpan.Parse(output.Rows[i][4].ToString());
                DataTable Itms = dm.ExecuteReader(DataBaseEssentials.GetItemsInOrderCommand, new Dictionary<string, object>() { { "@ordernum", NewOrder.OrderID } });
                NewOrder.Items = new List<MenuItem>();
                if (Itms != null)    // check if order has no items in it ... wont come true ... only for debugging
                {
                    foreach (DataRow item in Itms.Rows)
                    {
                        NewOrder.Items.Add(DataBaseEssentials.ConvertToMenuItemClass(item));
                    }
                }
                Orders.Add(NewOrder);
            }

            return Orders;
        }
        public bool InsertORMI(int orderid, int itemnumber)
        {

            var dict = new Dictionary<string, object>() { { "@ORDERID", orderid }, { "@ITEMNUMBER", itemnumber } };
            string query = "spinsertORMI";
            var x = dm.ExecuteNonQuery(query, dict);
            return true;
        }
    }
}
