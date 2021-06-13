using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
namespace Client
{
    public partial class OrderExpanded : UserControl
    {
        Form_C6 main;
        Order current;
        List<RatingTab> tabs = new List<RatingTab>();
        List<MenuItem> currentItems = new List<MenuItem>();
        
        public OrderExpanded(Form_C6 main,
        Order current)
        {
            InitializeComponent();
            this.main = main;
            this.current = current;
            label1.Text = "Order#" + current.OrderID.ToString();
            label2.Text = "Order Time:" + current.OrderTime.ToString();
            label3.Text = "Status :" + current.Status.ToString();
            float sum = 0f;
            for (int i = 0; i < current.Items.Count; i++)
            {
                var item = current.Items[i];

                bool found = false;
                for (int j = 0; j < currentItems.Count; j++)
                {
                    MenuItem itm = currentItems[j];
                    if (item.name == itm.name)
                    {
                        found = true;
                        tabs[j].Increment();
                    }
                }

                sum += item.price;
                if (!found)
                {
                    currentItems.Add(item);
                    RatingTab temp = new RatingTab(main, item, current.Status == Order_status.DELIVERED);
                    panel1.Controls.Add(temp);
                    temp.Location = new Point(10, 30 + tabs.Count * (temp.Height));
                    tabs.Add(temp);
                }
                

                

            }
            label4.Text = "Sum :" + sum.ToString() + "LE";

        }

        private void OrderExpanded_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            main.UpdateList();
        }
    }
}
