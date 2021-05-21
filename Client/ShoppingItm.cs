using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Client
{
    public partial class ShoppingItm : UserControl
    {
        Form_C5 main;
        MenuItem current;
        public ShoppingItm(Form_C5 main,
        MenuItem current)
        {
            InitializeComponent();
            this.main = main;
            this.current = current;
            label1.Text = current.name;
        }

        private void ShoppingItm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            main.DeleteFromShopping(current);
        }
    }
}
