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

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
