using System;
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
            label3.Text = current.rating.ToString() + "/5";
            label4.Text = current.price.ToString() + "LE";
            pictureBox1.Image = current.Image;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            main.AddToShopping(current);
        }

        private void ItmInMenu_Load(object sender, EventArgs e)
        {
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
