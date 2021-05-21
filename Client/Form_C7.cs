using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Client
{
    public partial class Form_C7 : Form
    {
        public Form_C7()
        {
            InitializeComponent();
            //label1.Text = "Total:  " + sum ;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form_C6 chechout = new Form_C6();
            chechout.Show();
            this.Hide();
        }

        private void Form_C7_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
