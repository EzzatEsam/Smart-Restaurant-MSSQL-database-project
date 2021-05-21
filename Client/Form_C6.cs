using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Client
{
    public partial class Form_C6 : Form
    {
        public Form_C6()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form_C4 chechout = new Form_C4();
            chechout.Show();
            this.Hide();
        }
    }
}
