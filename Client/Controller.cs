﻿using System;
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

            string query = "GetMenuWIthRating";
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
        public int InsertOR(int CID,int status, int tablenum, DateTime time)
        {

            var dict = new Dictionary<string, object>() { { "@CID", CID }, { "@STATUS", status}, { "@TNUMBER", tablenum }, { "@TIME", time } };
            string query = "spinsertORDER";
            var output1 = dm.ExecuteScalar(query, dict);
            return (int)output1;
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
                switch (Convert.ToInt16(output.Rows[i][2]))
                {
                    case 0:
                        NewOrder.Status = Order_status.PENDING;
                        break;
                    case 2:
                        NewOrder.Status = Order_status.READY;
                        break;
                    case 3:
                        NewOrder.Status = Order_status.DELIVERED;
                        break;
                    default:
                        break;
                }
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
                var x= dm.ExecuteNonQuery(query, dict);
                return true;
        }
    }
}
