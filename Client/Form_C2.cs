using System;
using System.Windows.Forms;

namespace Client
{
    public partial class Form_C2 : Form
    {
        public string name;
        public Form_C1 back;
        public bool flagCR;
        Form_C5 order;
        public Form_C2(string newname, Form_C1 newback)
        {
            name = newname;
            InitializeComponent();
            this.ControlBox = false;
            label1.Text = "Hello " + name + ", Ready to order.";
            back = newback;
            pictureBox1.Image = DataBaseEssentials.BinaryToImage(DataBaseEssentials.c1.GetLogo());

        }

        private void label1_Click(object sender, EventArgs e)
        {
            //label1.Text = "Hello " + name + ", Ready to order.";

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form_C2_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string x = DateTime.Now.ToShortTimeString();
            DateTime dateTime = DateTime.Parse(x);
            back.c1.InsertCR(back.cid, back.tablenumber, dateTime, false);
            flagCR = true;
            button2.Text = "Pending";
            button2.BackColor = System.Drawing.Color.Red;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (order == null)
            {
                order = new Form_C5(this);
            }
            order.Show();
            this.Hide();
        }
    }
}
