using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Client
{
    public partial class Form_C6 : Form
    {
        List<Order> Orders = new List<Order>();
        Form_C4 back;
        bool Expanded = false;
        public Form_C6(Form_C4 newback)
        {
            InitializeComponent();
            this.ControlBox = false;
            back = newback;
            pictureBox1.Image = DataBaseEssentials.BinaryToImage(DataBaseEssentials.c1.GetLogo());

        }

        void AsyncUpdate()
        {
            //MessageBox.Show("done");
            if (!IsHandleCreated)
            {
                return;
            }
            if (!Expanded)
            {
                this.BeginInvoke(new MethodInvoker(delegate ()
                {
                    UpdateList();

                }));
            }


            Task.Delay(new TimeSpan(0, 0, 0, 0, 500)).ContinueWith(o => { AsyncUpdate(); });
        }

        public void UpdateList()
        {
            var newOrders = DataBaseEssentials.c1.GetAllOrdersByClientID(DataBaseEssentials.cid);
            if (Expanded)
            {
                Expanded = false;
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
            foreach (Control item in panel1.Controls)
            {
                item.Dispose();
            }
            panel1.Controls.Clear();

            Orders.Clear();
            Orders = newOrders;
            for (int i = 0; i < Orders.Count; i++)
            {
                Order item = Orders[i];
                OrderTab it = new OrderTab(item, this);
                panel1.Controls.Add(it);
                it.Location = new Point(20, 20 + i * 40);
            }
            float sum = 0;
            foreach (Order item in Orders)
            {
                foreach (MenuItem itm in item.Items)
                {
                    sum += itm.price;
                }
            }
            label1.Text = "Total :" + sum.ToString();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            back.Show();
            this.Hide();
        }
        public void Expand(Order it)
        {
            foreach (Control item in panel1.Controls)
            {
                item.Dispose();
            }
            panel1.Controls.Clear();
            OrderExpanded temp = new OrderExpanded(this, it);
            panel1.Controls.Add(temp);
            Expanded = true;
        }
        private void Form_C6_Load(object sender, EventArgs e)
        {

        }

        private void Form_C6_Load_1(object sender, EventArgs e)
        {
            AsyncUpdate();
        }




    }
}
