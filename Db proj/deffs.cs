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
