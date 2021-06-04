using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Db_proj
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
            button3.Enabled = false;
            UpdateList();


        }
        public void UpdateList()
        {
            // update orders from db
            Orders = organiser.Controller.GetAllOrdersByStatus(Order_status.PENDING);
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
            button3.Enabled = true;

        }

        public void CancelTaken(Order currentOrder)
        {
            organiser.Controller.SetEmpStatus(organiser.Controller.CurrentID, Emp_type.CHEF, organiser.Controller.SetOrderStatus(currentOrder.OrderID, Order_status.PENDING));
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

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

            OrderBig ord = new OrderBig(this, it);
            panel1.Controls.Add(ord);
            button3.Enabled = false;

        }
        public void SetTakn(Order it)
        {
            if (organiser.Controller.SetOrderStatus(it.OrderID, Order_status.ONIT))
            {
                organiser.Controller.SetEmpStatus(organiser.Controller.CurrentID, Emp_type.CHEF, false);
            }
        }
        public void SetReady(Order it)
        {
            
            organiser.Controller.SetEmpStatus(organiser.Controller.CurrentID, Emp_type.CHEF, organiser.Controller.SetOrderStatus(it.OrderID, Order_status.READY));
        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void ChefStart_Load(object sender, EventArgs e)
        {

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
            panel1.Controls.Add(new ChangeLogins(this));
            button3.Enabled = false;
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
