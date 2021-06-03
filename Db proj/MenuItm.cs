using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Db_proj
{
    public partial class MenuItm : UserControl
    {
        AdminStart main;
        MenuItem itm;
        public MenuItm(AdminStart main, MenuItem itm)
        {
            InitializeComponent();
            this.main = main;
            this.itm = itm;
            label1.Text = itm.number.ToString();
            label2.Text = itm.name;
            label3.Text = itm.category;
            label4.Text = itm.price.ToString();
            label5.Text = itm.rating.ToString();
            pictureBox1.Image = itm.Image;
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            main.DeleteItem(itm.number);
        }
    }
}
