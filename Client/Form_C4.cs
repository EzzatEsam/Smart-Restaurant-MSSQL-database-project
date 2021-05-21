using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Client
{
    public partial class Form_C4 : Form
    {
        string name;
        Form_C5 make;
        public Form_C4(string newname, Form_C5 newmake)
        {
            name = newname;
            make = newmake;
            InitializeComponent();
            label1.Text = "Hello " + name + ", Make another order?";
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
            button2.Text = "Pending";
            button2.BackColor = System.Drawing.Color.Red;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            make.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form_C9 chechout = new Form_C9(name);
            chechout.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form_C6 chechout = new Form_C6(this);
            chechout.Show();
            this.Hide();
        }
    }
}
