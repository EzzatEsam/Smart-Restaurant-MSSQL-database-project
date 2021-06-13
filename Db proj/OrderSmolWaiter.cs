using System;
using System.Windows.Forms;

namespace Staff
{
    public partial class OrderSmolWaiter : UserControl
    {
        bool taken = false;
        Order CurrentOrder;
        WaiterStart main;
        int labelmaxsize = 30;
        public OrderSmolWaiter(Order current, WaiterStart c)
        {
            InitializeComponent();
            this.CurrentOrder = current;
            main = c;
            label1.Text = "Order #" + current.OrderID.ToString();
            foreach (MenuItem item in current.Items)
            {
                label2.Text += item.name + " ,";
                if (label2.Text.Length > labelmaxsize)
                {
                    label2.Text += "..";
                    break;

                }
            }
            label3.Text = "Table no :" + current.TableNo.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!taken)
            {
                if (main.AmIBusy())
                {
                    return;
                }
                taken = true;
                main.TakenOrder(CurrentOrder);
                button1.Text = "Done";
            }
            else
            {
                main.SetOrderDelivered(CurrentOrder);
                main.UpdateList();
            }
        }
    }
}
