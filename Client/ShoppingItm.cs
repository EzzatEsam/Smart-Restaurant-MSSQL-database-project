using System;
using System.Windows.Forms;

namespace Client
{
    public partial class ShoppingItm : UserControl
    {
        Form_C5 main;
        public int n = 1;
        public MenuItem current;
        public ShoppingItm(Form_C5 main,
        MenuItem current)
        {
            InitializeComponent();
            this.main = main;
            this.current = current;
            label1.Text = n.ToString() + "X " + current.name;
        }

        private void ShoppingItm_Load(object sender, EventArgs e)
        {

        }
        public void UpdateLabel()
        {
            label1.Text = n.ToString() + "X " + current.name;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (n > 1)
            {
                n--;
                label1.Text = n.ToString() + "X " + current.name;
                main.UpdateSum();
                return;
            }
            main.DeleteFromShopping(this);
        }
    }
}
