using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Client
{
    public partial class Form_C2 : Form
    {
        string name;
        public Form_C2(string newname)
        {
            name = newname;
            InitializeComponent();
            label1.Text = "Hello " + name + ", Ready to order.";
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
            button2.Text = "Pending";
            button2.BackColor = System.Drawing.Color.Red;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form_C5 order = new Form_C5(this);
            order.Show();
            this.Hide();
        }
    }
}
