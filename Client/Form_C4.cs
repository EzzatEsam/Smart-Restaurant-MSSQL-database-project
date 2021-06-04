using System;
using System.Windows.Forms;

namespace Client
{
    public partial class Form_C4 : Form
    {
        string name;
        public Form_C5 make;
        Form_C6 Orders;
        Form_C9 chechout;
        public Form_C4( Form_C5 newmake)
        {
            name = DataBaseEssentials.ClientName;
            make = newmake;
            this.ControlBox = false;
            InitializeComponent();
            label1.Text = "Hello " + name + ", Make another order?";
            if (DataBaseEssentials.flagCR)
            {
                button2.Text = "Pending";
                button2.BackColor = System.Drawing.Color.Red;
            }
            pictureBox1.Image = DataBaseEssentials.BinaryToImage(DataBaseEssentials.c1.GetLogo());

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form_C4_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string x = DateTime.Now.ToShortTimeString();
            DateTime dateTime = DateTime.Parse(x);
            DataBaseEssentials.c1.InsertCR(DataBaseEssentials.cid, DataBaseEssentials.tablenumber, dateTime, false);
            button2.Text = "Pending";
            button2.BackColor = System.Drawing.Color.Red;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            make.Show();
            this.Hide();
            make.Reset();
            make.PrevForm = this;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (chechout == null)
            {
                chechout = new Form_C9(name, this); 
            }
             
            chechout.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Orders == null)
            {
                Orders = new Form_C6(this);
            }
            
            Orders.Show();
            Orders.UpdateList();
            this.Hide();
        }
    }
}
