using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Db_proj
{
    public partial class WaiterStart : AccountUser
    {
        
        List<Order> Orders = new List<Order>();
        List<ContactRequest> Reqs = new List<ContactRequest>();
        
        public WaiterStart(FormOrganiser main)
        {
            InitializeComponent();
            this.ControlBox = false;
            organiser = main;
            label1.Text = "Hello " + main.Controller.GetEmpName(main.Controller.CurrentID);
            pictureBox1.Image = DataBaseEssentials.BinaryToImage(organiser.Controller.GetLogo());
            // temp test for data
            //for (int i = 0; i < 20; i++)
            //{
            //    ContactRequest temp = new ContactRequest();
            //    temp.ContactNumber = i;
            //    temp.TableNumber = 14;

            //    temp.ContactStatus = RequestStatus.PENDING;
            //    temp.ContactTime = new TimeSpan(20, 15, 0);

            //    Reqs.Add(temp);
            //}
            //

            //for (int i = 0; i < 20; i++)
            //{
            //    Order temp = new Order();
            //    temp.OrderID = i;
            //    temp.TableNo = 14;
            //    temp.ClientID = 15;
            //    temp.Status = Order_status.PENDING;
            //    temp.OrderTime = new TimeSpan(20, 15, 0);
            //    for (int j = 0; j < 3; j++)
            //    {
            //        temp.Items.Add(new MenuItem(j, "fish", "also fish", 25f * j / 2));
            //    }
            //    Orders.Add(temp);

            //    //
            //    ContactRequest temp2 = new ContactRequest();
            //    temp2.ContactNumber = i;
            //    temp2.ContactTime = new TimeSpan(20, 15, 0);
            //    temp2.ContactType = ((float)i % 2f == 0) ? RequestType.CHECKOUT : RequestType.INQUIRY;
            //    temp2.TableNumber = 14;
            //    temp2.ContactStatus = RequestStatus.PENDING;
            //    Reqs.Add(temp2);


            //}
            UpdateList();
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            organiser.GoTo(0);
        }
        public bool SetOrderDelivered(Order it)
        {
            if (organiser.Controller.SetOrderStatus(it.OrderID,Order_status.DELIVERED))
            {
                organiser.Controller.SetEmpStatus(organiser.Controller.CurrentID, Emp_type.WAITER, true);
                return true;
            }
            
            return false;
        }
        public bool SetContactDone(ContactRequest it)
        {
            if (organiser.Controller.SetRequestStatus(it.ContactNumber, RequestStatus.DONE))
            {
                organiser.Controller.SetEmpStatus(organiser.Controller.CurrentID, Emp_type.WAITER, true);
                return true;
            }

            return false;
        }
        public void TakenOrder(Order it)
        {
            organiser.Controller.SetEmpStatus(organiser.Controller.CurrentID, Emp_type.WAITER,false);
        }
        public bool TakenContact(ContactRequest it)
        {
            if (organiser.Controller.SetRequestStatus(it.ContactNumber, RequestStatus.ONIT))
            {
                organiser.Controller.SetEmpStatus(organiser.Controller.CurrentID, Emp_type.WAITER, false);
                return true;
            }

            return false;
        }
        public bool AmIBusy()
        {
            return !organiser.Controller.IsEmpFree(organiser.Controller.CurrentID);
        }
        
        public void ExpandCheck(ContactRequest it)
        {
            panel1.Controls.Clear();
            panel2.Controls.Clear();
            foreach (Control item in panel1.Controls)
            {
                item.Dispose();
            }
            foreach (Control item in panel2.Controls)
            {
                item.Dispose();
            }
            panel3.BringToFront();
            check temp = new check(it, this);
            panel3.Controls.Add(temp);
        }
        public void UpdateList()
        {
            panel3.SendToBack();
            // update orders from db
            // update requests from db
            //

            Orders = organiser.Controller.GetAllOrdersByStatus(Order_status.PENDING);
            Reqs = organiser.Controller.GetContactRequestsByStatus(RequestStatus.PENDING);


            panel1.Controls.Clear();
            panel2.Controls.Clear();
            panel3.Controls.Clear();
            foreach (Control item in panel1.Controls)
            {
                item.Dispose();
            }
            foreach (Control item in panel2.Controls)
            {
                item.Dispose();
            }
            foreach (Control item in panel3.Controls)
            {
                item.Dispose();
            }


            for (int i = 0; i < Orders.Count; i++)
            {
                Order item = Orders[i];
                OrderSmolWaiter it = new OrderSmolWaiter(item, this);
                panel1.Controls.Add(it);
                it.Location = new Point(20, 20 + i * it.Height);
            }
            for (int i = 0; i < Reqs.Count; i++)
            {
                ContactRequest item = Reqs[i];
                RequestSmol it = new RequestSmol(item, this);
                panel2.Controls.Add(it);
                it.Location = new Point(5, 20 + i * it.Height);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void WaiterStart_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            panel2.Controls.Clear();
            panel3.Controls.Add(new ChangeLogins(this));
            panel3.BringToFront();
        }
        public override void ReturnBack()
        {
            UpdateList();
        }
    }
}
