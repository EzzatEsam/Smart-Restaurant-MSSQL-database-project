using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Client
{
    public partial class Form_C5 : Form
    {
        public Form_C5()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form_C6 confirm = new Form_C6();
            confirm.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Form_C2 back = new Form_C2();
            //start.Show();
            //this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form_C5_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
        }
    }
}
