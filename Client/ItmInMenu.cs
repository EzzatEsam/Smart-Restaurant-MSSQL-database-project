using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Client
{
    public partial class ItmInMenu : UserControl
    {
        Form_C5 main;
        MenuItem current;
        public ItmInMenu(Form_C5 main, MenuItem current)
        {
            InitializeComponent();
            this.main = main;
            this.current = current;
            label1.Text = "#" + current.number.ToString();
            label2.Text = current.name;
            label3.Text = current.rating.ToString() +"/5" ;
            label4.Text = current.price.ToString() + "LE";


        }

        private void button1_Click(object sender, EventArgs e)
        {
            main.AddToShopping(current);
        }
    }
}
