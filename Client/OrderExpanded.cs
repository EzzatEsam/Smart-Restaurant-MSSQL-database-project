using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Client
{
    public partial class OrderExpanded : UserControl
    {
        Form_C6 main;
        Order current;
        public OrderExpanded(Form_C6 main,
        Order current)
        {
            InitializeComponent();
            this.main = main;
            this.current = current;
            label1.Text ="Order#"+ current.OrderID.ToString();
            label2.Text = "Order Time:" + current.OrderTime.ToString();
            float sum = 0f;
            for (int i = 0; i < current.Items.Count; i++)
            {
                MenuItem item = current.Items[i];
                sum += item.price;
                RatingTab temp = new RatingTab(main, item);
                panel1.Controls.Add(temp);
                temp.Location = new Point(10, 20 + i * (temp.Height)); 
           
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
