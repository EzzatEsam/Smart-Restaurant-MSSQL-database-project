using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Client
{
    public partial class Form_C6 : Form
    {
        List<Order> Orders ;
        Form_C4 back;
        public Form_C6(Form_C4 newback)
        {
            InitializeComponent();
            this.ControlBox = false;
            back = newback;
            Orders= DataBaseEssentials.c1.GetAllOrdersByClientID(DataBaseEssentials.cid);
            pictureBox1.Image = DataBaseEssentials.BinaryToImage(DataBaseEssentials.c1.GetLogo());
            UpdateList();
        }
        public void UpdateList()
        {
            foreach (Control item in panel1.Controls)
            {
                item.Dispose();
            }
            panel1.Controls.Clear();


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

        }
        private void Form_C6_Load(object sender, EventArgs e)
        {

        }



        //private void Form_C6_Load(object sender, EventArgs e)
        //{

        //}
    }
}
