using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Db_proj
{
    public enum Emp_type
    {
        CHEF ,WAITER 
    }
    public enum Order_status
    {
        PENDING, READY , DELIVERED
    }
    public enum Task
    {
        ORDER,
        CLIENTCONTACT,
        NONE
    }
    public enum RequestType
    {
        INQUIRY , CHECKOUT
    }
    public enum RequestStatus
    {
        PENDING ,ONIT ,DONE
    }
    public class MenuItem
    {
        public int number; public string name; public string category; public float price;
        public MenuItem(int number , string name ,string category ,float price)
        {
            this.number = number;
            this.name = name;
            this.category = category;
            this.price = price;
        }
    }
    public class Order
    {
        public int OrderID, ClientID,TableNo;
        public Order_status Status;
        public TimeSpan OrderTime;
        public List<MenuItem> Items = new List<MenuItem>() ;
        
    }
    public class ContactRequest
    {
        public int ContactNumber;
        public int TableNumber;
        public TimeSpan ContactTime;
        public RequestType ContactType;
        public RequestStatus ContactStatus;
        public int OrderNumber=-1;
    }
    public class Worker
    {
        public int ssid;public string name; public Emp_type type; public bool IsFree; public int CurrentTask; public Task cType;
        public Worker(int ssid , string name ,Emp_type type ,bool IsFree ,int current ,Task tskTYpe )
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
