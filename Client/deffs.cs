using System;
using System.Collections.Generic;
using System.Drawing;
using System.Data;
using System.IO;
namespace Client
{
    public static class DataBaseEssentials
    {
        public static string ConnectionString = @"Data Source=.;Initial Catalog=RESTDB;Integrated Security=True";
        public static string LoginCommand = "TryLogin";
        public static string GetAllEmpsCommand = "GetAllEmps";
        public static string UpdateAccountCommand = "UpdatePass";
        public static string GetAllMenuCommand = "GetAllMenu";
        public static string AddEmpCommand = "AddEmployee";
        public static string AddItemCommand = "AddMenuItem";
        public static string GetAllOrdersCommand = "GetOrdersByState";
        public static string GetAllReqsCommand = "GetRequestsByState";
        public static string SetEmpStatsCommand = "EmpStatus";
        public static string GetItemsInOrderCommand = "GetItemsInOrder";
        public static string GetClientNameCommand = "GetClientName";
        public static string GetWokerNameCommand = "GetWorkerNameByAccount";
        public static string GetWorkerStatusCommand = "GetEmployeeStatus";
        public static string SetOrderStatusCommand = "SetOrderStatus";
        public static string SetRequestStatusCommand = "SetRequest";
        public static string GetAllOrderByClientCommand = "GetAllClientOrders";
        public static string UpdateLogoCommand = "UpdateLogo";
        public static string GetLogoCommand = "GetLogo";
        public static string DeleteItemCommand = "DeleteMenueItem";
        public static string DeleteWorkerCommand = "DeleteFromEmployees";
        public static string ChangeNumberOfTablesCommand = "SetTablesCount";
        //public static MenuItem ConvertToMenuItemClass(DataRow it)
        //{
        //    MenuItem output = new MenuItem(Convert.ToInt32(it["ITMNUMBER"]), Convert.ToString(it["INAME"]), Convert.ToString(it["CATEGORY"]), (float)Convert.ToDouble(it["PRICE"]),);

        //    return output;

        //}

        
        public static Image BinaryToImage(byte[] binaryData)
        {
            if (binaryData == null)
            {
                return null;
            }
            MemoryStream ms = new MemoryStream(binaryData);

            Image img = Image.FromStream(ms);
            return img;

            
        }
    }

    
    public enum Emp_type
    {
        CHEF, WAITER
    }
    public enum Order_status
    {
        PENDING, READY, DELIVERED
    }
    public enum Task
    {
        ORDER,
        CLIENTCONTACT,
        NONE
    }
    public enum RequestType
    {
        INQUIRY, CHECKOUT
    }
    public enum RequestStatus
    {
        PENDING, ONIT, DONE
    }
    public class MenuItem
    {
        public int number; public string name; public string category; public float price; public float rating;
        public Bitmap Image;
        public MenuItem(int number, string name, string category, float price, float rating)
        {
            this.number = number;
            this.name = name;
            this.category = category;
            this.price = price;
            this.rating = rating;
            
        }
    }
    public class Order
    {
        public int OrderID, ClientID, TableNo;
        public Order_status Status;
        public TimeSpan OrderTime;
        public List<MenuItem> Items = new List<MenuItem>();

    }
    public class ContactRequest
    {
        public int ContactNumber;
        public int TableNumber;
        public TimeSpan ContactTime;
        public RequestType ContactType;
        public RequestStatus ContactStatus;
        public int OrderNumber = -1;
    }
    public class Worker
    {
        public int ssid; public string name; public Emp_type type; public bool IsFree; public int CurrentTask; public Task cType;
        public Worker(int ssid, string name, Emp_type type, bool IsFree, int current, Task tskTYpe)
        {
            this.ssid = ssid;
            this.name = name;
            this.type = type;
            this.IsFree = IsFree;
            CurrentTask = current;
            cType = tskTYpe;
        }
    }

}
