using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Staff
{
    public partial class ChefStart : AccountUser
    {

        List<Order> Orders = new List<Order>();
        int VInterval = 40;

        public ChefStart(FormOrganiser main)
        {
            InitializeComponent();
            this.ControlBox = false;
            organiser = main;
            label1.Text = "Hello " + main.Controller.GetEmpName(main.Controller.CurrentID);
            pictureBox1.Image = DataBaseEssentials.BinaryToImage(main.Controller.GetLogo());
            UpdateList();
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
            Task.Delay(new TimeSpan(0, 0, 0, 0, DataBaseEssentials.RefreshRateMS)).ContinueWith(o => { AsyncUpdate(); });
        }
        public void UpdateList()
        {
            // update orders from db
            var newOrders = organiser.Controller.GetAllOrdersByStatus(Order_status.PENDING);
            if (!Refreshing)
            {
                Refreshing = true;
                goto here;
            }


            if (newOrders.Count == Orders.Count)
            {
                for (int i = 0; i < Orders.Count; i++)
                {
                    if (Orders[i].OrderID != newOrders[i].OrderID)
                    {
                        goto here;
                    }
                }
                return;
            }
        here:
            Orders.Clear();
            Orders = newOrders;
            //
            foreach (Control item in panel1.Controls)
            {
                item.Dispose();
            }
            panel1.Controls.Clear();


            for (int i = 0; i < Orders.Count; i++)
            {
                Order item = Orders[i];
                OrderSmol it = new OrderSmol(item, this);
                panel1.Controls.Add(it);
                it.Location = new Point(20, 20 + i * VInterval);
            }
          


        }

        public void CancelTaken(Order currentOrder)
        {
            if (organiser.Controller.SetOrderStatus(currentOrder.OrderID, Order_status.PENDING))
            {
                organiser.Controller.SetEmpFree(organiser.Controller.CurrentID, Emp_type.CHEF);
            }

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
        public void Expand(Order it)
        {
            foreach (Control item in panel1.Controls)
            {
                item.Dispose();
            }
            panel1.Controls.Clear();
            Refreshing = false;
            OrderBig ord = new OrderBig(this, it);
            panel1.Controls.Add(ord);
            

        }
        public void SetTakn(Order it)
        {
            if (organiser.Controller.SetOrderStatus(it.OrderID, Order_status.ONIT))
            {
                organiser.Controller.SetEmpStatus(organiser.Controller.CurrentID, Emp_type.CHEF, TaskType.ORDER, it.OrderID);
            }
        }
        public void SetReady(Order it)
        {
            if (organiser.Controller.SetOrderStatus(it.OrderID, Order_status.READY))
            {
                organiser.Controller.SetEmpFree(organiser.Controller.CurrentID, Emp_type.CHEF);
                UpdateList();
            }


        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void ChefStart_Load(object sender, EventArgs e)
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
            foreach (Control item in panel1.Controls)
            {
                item.Dispose();
            }
            panel1.Controls.Clear();
            Refreshing = false;
            panel1.Controls.Add(new ChangeLogins(this));
            

        }
        public override void ReturnBack()
        {
            UpdateList();

        }
        public bool AmIBusy()
        {
            return !organiser.Controller.IsEmpFree(organiser.Controller.CurrentID);
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
