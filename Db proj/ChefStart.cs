using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Db_proj
{
    public partial class ChefStart : Form
    {
        FormOrganiser main;
        List<Order> Orders = new List<Order>();
        int VInterval = 40;
        public ChefStart(FormOrganiser main)
        {
            InitializeComponent();
            this.ControlBox = false;
            this.main = main;

            // temp test for data
            for (int i = 0; i < 20; i++)
            {
                Order temp = new Order();
                temp.OrderID = i;
                temp.TableNo = 14;
                temp.ClientID = 15;
                temp.Status = Order_status.PENDING;
                temp.OrderTime = new TimeSpan(20, 15, 0);
                for (int j = 0; j < 3; j++)
                {
                    temp.Items.Add(new MenuItem(j, "fish", "also fish", 25f * j / 2));
                }
                Orders.Add(temp);


            }
            UpdateList();


        }
        public void UpdateList()
        {
            // update orders from db

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
        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            main.GoTo(0);
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

        }
        public void SetTakn(Order it)
        {

        }
        public void SetReady(Order it)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void ChefStart_Load(object sender, EventArgs e)
        {

        }
    }
}
