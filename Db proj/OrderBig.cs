using System;
using System.Drawing;
using System.Windows.Forms;

namespace Db_proj
{
    public partial class OrderBig : UserControl
    {
        ChefStart main;
        Order CurrentOrder;
        int VInterval = 40, HInterval = 200;
        bool taken = false;
        public OrderBig(ChefStart main, Order CurrentOrder)
        {
            InitializeComponent();
            this.main = main;
            this.CurrentOrder = CurrentOrder;
            
            UpdateList();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void OrderBig_Load(object sender, EventArgs e)
        {

        }
        public void UpdateList()
        {
            label1.Text = "Order #" + CurrentOrder.OrderID.ToString();
            foreach (Control item in panel1.Controls)
            {
                item.Dispose();
            }
            panel1.Controls.Clear();
            for (int i = 0; i < CurrentOrder.Items.Count; i++)
            {
                MenuItem item = CurrentOrder.Items[i];
                Label temp = new Label();
                temp.Text = item.name;
                panel1.Controls.Add(temp);
                temp.Location = new Point(20, 20 + i * VInterval);
                if (taken)
                {
                    CheckBox temp2 = new CheckBox();

                    panel1.Controls.Add(temp2);
                    temp2.Location = new Point(20 + HInterval, 20 + i * VInterval);
                }
            }
            label2.Text = "Time :" + CurrentOrder.OrderTime.ToString();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            main.CancelTaken(CurrentOrder);
            main.UpdateList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!taken)
            {
                button1.Text = "Set Ready";
                button2.Text = "Leave order";
                taken = true;
                main.SetTakn(CurrentOrder);
                UpdateList();
            }
            else
            {
                main.SetReady(CurrentOrder);
                main.UpdateList();
            }

        }
    }
}
