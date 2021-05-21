using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Db_proj
{
    public partial class check : UserControl
    {
        ContactRequest current;
        WaiterStart main;
        public check(ContactRequest current,WaiterStart main)
        {
            InitializeComponent();
            this.current = current;
            this.main = main;

            label1.Text = "C#" + current.ContactNumber.ToString();
            label2.Text = "Table no :" + current.TableNumber;
            label4.Text = "Time :" + current.ContactTime.ToString();
            //next code needs part is getting the order using its number
            // needs db access
            label5.Text = "Total :" + "Egp";
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            main.SetDone(current);
            main.UpdateList();
        }
    }
}
