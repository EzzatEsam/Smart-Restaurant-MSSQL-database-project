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
            button3.Enabled = false;
           
            UpdateList();
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            if (AmIBusy())
            {
                MessageBox.Show("You still have unfinished tasks");
                return;
            }
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
            button3.Enabled = false;
        }
        public void UpdateList()
        {
            panel3.SendToBack();
            // update orders from db
            // update requests from db
            //

            Orders = organiser.Controller.GetAllOrdersByStatus(Order_status.READY);
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
            button3.Enabled = true;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void WaiterStart_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (AmIBusy())
            {
                MessageBox.Show("You still have unfinished tasks");
                return;
            }
            
            panel1.Controls.Clear();
            panel2.Controls.Clear();
            panel3.Controls.Add(new ChangeLogins(this));
            panel3.BringToFront();
        }
        public override void ReturnBack()
        {
            UpdateList();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (AmIBusy())
            {
                MessageBox.Show("You still have unfinished tasks");
                return;
            }
            UpdateList();
        }
    }
}
