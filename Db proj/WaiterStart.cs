using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Staff
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
            if (organiser.Controller.SetOrderStatus(it.OrderID, Order_status.DELIVERED))
            {
                organiser.Controller.SetEmpFree(organiser.Controller.CurrentID, Emp_type.WAITER);
                return true;
            }

            return false;
        }
        public bool SetContactDone(ContactRequest it)
        {
            if (organiser.Controller.SetRequestStatus(it.ContactNumber, RequestStatus.DONE))
            {
                organiser.Controller.SetEmpFree(organiser.Controller.CurrentID, Emp_type.WAITER);
                return true;
            }

            return false;
        }
        public void TakenOrder(Order it)
        {
            if (organiser.Controller.SetOrderStatus(it.OrderID, Order_status.OMW))
            {
                Refreshing = false;
                organiser.Controller.SetEmpStatus(organiser.Controller.CurrentID, Emp_type.WAITER, TaskType.ORDER, it.OrderID);
            }

        }
        public bool TakenContact(ContactRequest it)
        {
            if (organiser.Controller.SetRequestStatus(it.ContactNumber, RequestStatus.ONIT))
            {
                Refreshing = false;
                organiser.Controller.SetEmpStatus(organiser.Controller.CurrentID, Emp_type.WAITER, TaskType.CLIENTCONTACT, it.ContactNumber);
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
            Refreshing = false;
            label3.Hide();
            label2.Hide();
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
            var newOrders = organiser.Controller.GetAllOrdersByStatus(Order_status.READY);
            var newReqs = organiser.Controller.GetContactRequestsByStatus(RequestStatus.PENDING);
            if (!Refreshing)
            {
                Refreshing = true;
                label3.Show();
                label2.Show();
                goto here;
            }
            panel3.SendToBack();
            // update orders from db

            if (newOrders.Count == Orders.Count && Reqs.Count == newReqs.Count)
            {
                for (int i = 0; i < Orders.Count; i++)
                {
                    if (Orders[i].OrderID != newOrders[i].OrderID)
                    {
                        goto here;
                    }
                }
                for (int i = 0; i < Reqs.Count; i++)
                {
                    if (Reqs[i].ContactNumber != newReqs[i].ContactNumber)
                    {
                        goto here;
                    }
                }
                return;
            }
        here:

            // update requests from db
            //
            Orders.Clear(); Reqs.Clear();
            Orders = newOrders;
            Reqs = newReqs;


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
        void AsyncUpdate()
        {
            //MessageBox.Show("done");
            if (!IsHandleCreated)
            {
                return;
            }
            if (Refreshing)
            {
                this.BeginInvoke(new MethodInvoker(delegate ()
                {
                    UpdateList();

                }));
            }
            //  I 100% understand the following code and I didnt copy paste it from SO
            Task.Delay(new TimeSpan(0, 0, 0, 0, DataBaseEssentials.RefreshRateMS)).ContinueWith(o => { AsyncUpdate(); });
        }
        private void WaiterStart_Load(object sender, EventArgs e)
        {
            AsyncUpdate();
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
            Refreshing = false;
            label3.Hide();
            label2.Hide();
            panel3.Controls.Add(new ChangeLogins(this));
            panel3.BringToFront();
        }
        public override void ReturnBack()
        {
            UpdateList();
        }

    }
}
