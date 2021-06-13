using System;
using System.Windows.Forms;

namespace Client
{
    public partial class OrderTab : UserControl
    {
        Order current;
        Form_C6 main;
        int max = 25;
        public OrderTab(Order current,
        Form_C6 main)
        {
            InitializeComponent();
            this.current = current;
            this.main = main;
            label1.Text = "O#" + current.OrderID.ToString();
            label2.Text = "(";
            for (int i = 0; i < current.Items.Count; i++)
            {
                MenuItem it = current.Items[i];
                label2.Text += it.name + ",";
                if (label2.Text.Length > max)
                {
                    label2.Text += "..";
                    break;
                }


            }
            label2.Text += ")";
            label3.Text = "Time :" + current.OrderTime.ToString();
            label4.Text = "Status:" + current.Status.ToString();
        }

        private void OrderTab_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            main.Expand(current);
        }

        private void OrderTab_Load_1(object sender, EventArgs e)
        {

        }
    }
}
