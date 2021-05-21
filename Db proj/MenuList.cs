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
    public partial class MenuList : UserControl
    {
        AdminStart main;
        NextsAdmin back = NextsAdmin.ADMINENTER;
        MenuItem[] current =
        {
                new MenuItem(12,"Tuna", "fish",14f ),
                new MenuItem(13,"steak", "meats",20f ),
                new MenuItem(15,"another tuna", "fish",26f ),
                new MenuItem(14,"another another tuna", "fish",2000f ),
        };
        public MenuList(AdminStart main)
        {
            InitializeComponent();
            this.main = main;
            UpdateList();
            
        }
        public void UpdateList()
        {
            // here we reload the employees db 
            dataGridView1.Rows.Clear();
            foreach (MenuItem it in current)
            {
                dataGridView1.Rows.Add(it.number.ToString(), it.name, it.category, it.price);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            main.Goto(back);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int ssid = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            main.DeleteItem(ssid);
            UpdateList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            main.Goto(NextsAdmin.MENUADD);
        }
    }
}
