using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;
namespace Db_proj
{
    public class DBControlller
    {
        public int CurrentID { get; private set; }
        FormOrganiser main;
        public DBControlller(FormOrganiser main)
        {
            this.main = main;
        }
        public void Login(string user, string password)
        {
            DBManager manager = new DBManager();
            var dict = new Dictionary<string, object>() { { "username", user }, { "pass", password } };
            DataTable output = manager.ExecuteReader(DataBaseEssentials.LoginCommand, dict);
            if (output != null)
            {
                CurrentID = (int)output.Rows[0][0];
                main.GoTo(Convert.ToInt16(output.Rows[0][3]) + 1);
                
            }
            manager.CloseConnection();

        }
        public DataTable GetAllEmployees()
        {
            DBManager manager = new DBManager();
            var output = manager.ExecuteReader(DataBaseEssentials.GetAllEmpsCommand, null);
            manager.CloseConnection();
            return (DataTable)output;
        }
        public bool UpdatePass(int n, string usr, string pass, string oldpass)
        {
            DBManager manager = new DBManager();
            var dict = new Dictionary<string, object>() { { "AccNum", n }, { "UsrName", usr }, { "pass", pass }, { "OldPass", oldpass } };
            int output = manager.ExecuteNonQuery(DataBaseEssentials.UpdateAccountCommand, dict);
            manager.CloseConnection();
            return output != 0;
        }
        public DataTable GetAllMenu()
        {
            DBManager manager = new DBManager();
            var output = manager.ExecuteReader(DataBaseEssentials.GetAllMenuCommand, null);
            manager.CloseConnection();

            return (DataTable)output;
        }
        public bool AddItem(MenuItem it)
        {
            DBManager manager = new DBManager();
            var img = (byte[])((new ImageConverter()).ConvertTo(it.Image, typeof(byte[]))) ;
            var dict = new Dictionary<string, object>() { { "name", it.name}, { "@category", it.category }, { "@price", it.price }, { "@image", img } };
            int output = manager.ExecuteNonQuery(DataBaseEssentials.AddItemCommand, dict);
            manager.CloseConnection();
            return output != 0;
        }

        public bool DeleteItem(int it)
        {
            DBManager manager = new DBManager();
            var dict = new Dictionary<string, object>() { { "@num", it } };
            int output = manager.ExecuteNonQuery(DataBaseEssentials.DeleteItemCommand, dict);
            manager.CloseConnection();
            return output != 0;
        }

        public bool DeleteWorker(int it ,Emp_type type)
        {
            DBManager manager = new DBManager();
            var dict = new Dictionary<string, object>() { { "@num", it },{ "@type" ,(int) type } };
            int output = manager.ExecuteNonQuery(DataBaseEssentials.DeleteWorkerCommand, dict);
            manager.CloseConnection();
            return output != 0;
        }


        public bool ChangeLogo(Image it)
        {

            MemoryStream ms = new MemoryStream();
            it.Save(ms, ImageFormat.Jpeg);
            byte[] photo_aray = new byte[ms.Length];
            ms.Position = 0;
            ms.Read(photo_aray, 0, photo_aray.Length);
            DBManager manager = new DBManager();
            //var test = (byte[])((new ImageConverter()).ConvertTo(it, typeof(byte[]))) ;
            var dict = new Dictionary<string, object>() { { "logo", photo_aray } };
            int output = manager.ExecuteNonQuery(DataBaseEssentials.UpdateLogoCommand, dict);
            manager.CloseConnection();
            return output != 0;
        }
        public byte[] GetLogo()
        {
            DBManager manager = new DBManager();
            var output = manager.ExecuteScalar(DataBaseEssentials.GetLogoCommand, null);
            manager.CloseConnection();
            return (byte[])output ;
        }
        public bool AddEmp(Worker it,string account ,string pass )
        {
            DBManager manager = new DBManager();
            var dict = new Dictionary<string, object>() { { "@type",( it.type == Emp_type.CHEF )? 1 :2 }, { "@name", it.name }, { "pass", pass }, { "@account", account } };
            int output = manager.ExecuteNonQuery(DataBaseEssentials.AddEmpCommand, dict);
            manager.CloseConnection();
            return output != 0;
        }

        public bool SetEmpStatus(int ID , Emp_type type , bool isfree)
        {
            DBManager manager = new DBManager();
            var dict = new Dictionary<string, object>() { { "@type", (type == Emp_type.CHEF) ? 1 : 2 }, { "@ID",ID }, { "@free", isfree } };
            int output = manager.ExecuteNonQuery(DataBaseEssentials.SetEmpStatsCommand, dict);
            manager.CloseConnection();
            return output != 0;
        }
        public string GetEmpName(int ID)
        {
            DBManager manager = new DBManager();
            
            var dict = new Dictionary<string, object>() { { "@accid", ID } };
            var output = manager.ExecuteScalar(DataBaseEssentials.GetWokerNameCommand, dict);
            manager.CloseConnection();
            return output.ToString();
        }
        public bool SetOrderStatus(int ID , Order_status stats)
        {
            DBManager manager = new DBManager();
            var dict = new Dictionary<string, object>() { { "@status", (int)stats }, { "@ID", ID }, };
            int output = manager.ExecuteNonQuery(DataBaseEssentials.SetOrderStatusCommand, dict);
            manager.CloseConnection();
            return output != 0;
        }
        public bool SetRequestStatus(int ID, RequestStatus stats)
        {
            DBManager manager = new DBManager();
            var dict = new Dictionary<string, object>() { { "@status", (int)stats }, { "@ID", ID }, };
            int output = manager.ExecuteNonQuery(DataBaseEssentials.SetRequestStatusCommand, dict);
            manager.CloseConnection();
            return output != 0;
        }
        public bool IsEmpFree(int ID)
        {
            DBManager manager = new DBManager();

            var dict = new Dictionary<string, object>() { { "@accid", ID } };
            var output = manager.ExecuteScalar(DataBaseEssentials.GetWorkerStatusCommand, dict);
            manager.CloseConnection();
            return Convert.ToBoolean( output);
        }

        public List<Order> GetAllOrdersByStatus(Order_status state)
        {
            DBManager manager = new DBManager();
            int StateInt =-1;
            switch (state)
            {
                case Order_status.PENDING: StateInt = 0;
                    break;
                case Order_status.READY:
                    StateInt = 1;
                    break;
                case Order_status.DELIVERED:
                    StateInt = 2;
                    break;
                default:
                    break;
            }
            var dict = new Dictionary<string, object>() { { "@state", StateInt }  };
            var output = manager.ExecuteReader(DataBaseEssentials.GetAllOrdersCommand, dict);
            

            List<Order> Orders = new List<Order>();
            if (output == null)
            {
                manager.CloseConnection();
                return Orders;
            }
            for (int i = 0; i < output.Rows.Count; i++)
            {
                Order NewOrder = new Order();
                NewOrder.OrderID = Convert.ToInt16(output.Rows[i][0]);
                NewOrder.ClientID = Convert.ToInt16( output.Rows[i][1]);
                switch (Convert.ToInt16(output.Rows[i][2]))
                {
                    case 0: NewOrder.Status = Order_status.PENDING;
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
                NewOrder.TableNo = Convert.ToInt16( output.Rows[i][3]);
                NewOrder.OrderTime = TimeSpan.Parse( output.Rows[i][4].ToString());
                DataTable Itms = manager.ExecuteReader(DataBaseEssentials.GetItemsInOrderCommand, new Dictionary<string, object>() { { "@ordernum", NewOrder.OrderID } }); 
                NewOrder.Items = new List<MenuItem>();
                if (Itms !=null)    // check if order has no items in it ... wont come true ... only for debugging
                {
                    foreach (DataRow item in Itms.Rows)
                    {
                        NewOrder.Items.Add(DataBaseEssentials.ConvertToMenuItemClass(item));
                    }
                }
                Orders.Add(NewOrder);
            }
            manager.CloseConnection();
            return Orders;
        }

        public List<ContactRequest> GetContactRequestsByStatus(RequestStatus state)
        {
            DBManager manager = new DBManager();
            int StateInt = -1;
            switch (state)
            {
                case RequestStatus.PENDING:
                    StateInt = 0;
                    break;
                case RequestStatus.ONIT:
                    StateInt = 2;
                    break;
                case RequestStatus.DONE:
                    StateInt = 3;
                    break;
                default:
                    break;
            }
           
            var dict = new Dictionary<string, object>() { { "@state", StateInt } };
            var output = manager.ExecuteReader(DataBaseEssentials.GetAllReqsCommand, dict);


            List<ContactRequest> Requests = new List<ContactRequest>();
            if (output == null)
            {
                manager.CloseConnection();
                return Requests;
            }
            for (int i = 0; i < output.Rows.Count; i++)
            {
                ContactRequest NewRequest = new ContactRequest();
                NewRequest.ContactNumber = Convert.ToInt16(output.Rows[i][0]);
                NewRequest.ClientID = Convert.ToInt16(output.Rows[i][1]);
                switch (Convert.ToInt16(output.Rows[i][5]))
                {
                    case 0:
                        NewRequest.ContactStatus = RequestStatus.PENDING;
                        break;
                    case 2:
                        NewRequest.ContactStatus = RequestStatus.ONIT;
                        break;
                    case 3:
                        NewRequest.ContactStatus = RequestStatus.DONE;
                        break;
                    default:
                        break;
                }
                NewRequest.TableNumber = Convert.ToInt16(output.Rows[i][2]);
                NewRequest.ContactTime = TimeSpan.Parse(output.Rows[i][3].ToString());
                NewRequest.ContactType = Convert.ToBoolean(output.Rows[i][4]) ? RequestType.CHECKOUT : RequestType.INQUIRY;
                
                Requests.Add(NewRequest);
            }
            manager.CloseConnection();
            return Requests;
        }

        public List<MenuItem> GetClientWholeMenu(int id)
        {
            var WholeMenu = new List<MenuItem>();
            DBManager manager = new DBManager();
            var output = manager.ExecuteReader(DataBaseEssentials.GetAllOrderByClientCommand, new Dictionary<string, object>() { { "@ID",id} });
            if (output == null)
            {
                manager.CloseConnection();
                return WholeMenu;
            }
            foreach (DataRow item in output.Rows)
            {
                var test = item["ORDERID"];
                DataTable Itms = manager.ExecuteReader(DataBaseEssentials.GetItemsInOrderCommand, new Dictionary<string, object>() { { "@ordernum", item["ORDERID"] } });

                if (Itms != null)    // check if order has no items in it ... wont come true ... only for debugging
                {
                    foreach (DataRow itm in Itms.Rows)
                    {
                        WholeMenu.Add(DataBaseEssentials.ConvertToMenuItemClass(itm));
                    }
                }
            }
            

            manager.CloseConnection();
            return WholeMenu;
        }
        public string GetClientNameByNum(int n)
        {
            DBManager manager = new DBManager();
            string output = manager.ExecuteScalar(DataBaseEssentials.GetClientNameCommand, new Dictionary<string, object>() { { "@num", n } }).ToString();
            return output;
        }







    }
       
}

