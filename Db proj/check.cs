using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Staff
{
    public partial class check : UserControl
    {
        ContactRequest current;
        WaiterStart main;
        public check(ContactRequest current, WaiterStart main)
        {
            InitializeComponent();
            this.current = current;
            this.main = main;

            label1.Text = "C#" + current.ContactNumber.ToString();
            label2.Text = "Table no :" + current.TableNumber;
            label3.Text = "Name :" + main.organiser.Controller.GetClientNameByNum(current.ClientID);
            label4.Text = "Time :" + current.ContactTime.ToString();
            //next code needs part is getting the order using its number
            float sum = 0f;
            List<MenuItem> itms = main.organiser.Controller.GetClientWholeMenu(current.ClientID);
            for (int i = 0; i < itms.Count; i++)
            {
                MenuItem item = itms[i];
                Label label = new Label();
                label.Text = (i + 1).ToString() + "- " + item.name;
                panel1.Controls.Add(label);
                label.Width = 200;
                label.Location = new System.Drawing.Point(label6.Location.X, 20 + i * label.Height);
                Label label2 = new Label();
                label2.Text = item.price.ToString() + "LE";
                panel1.Controls.Add(label2);
                label2.Width = 200;
                label2.Location = new System.Drawing.Point(label7.Location.X, 20 + i * label2.Height);

                sum += item.price;
            }
            label5.Text = "Total :" + sum.ToString() + "Egp";
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            main.SetContactDone(current);
            main.UpdateList();
        }
    }
}
