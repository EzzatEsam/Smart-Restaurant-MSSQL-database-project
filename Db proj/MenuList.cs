using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Data;
namespace Db_proj
{
    public partial class MenuList : UserControl
    {
        AdminStart main;
        NextsAdmin back = NextsAdmin.ADMINENTER;
        List<MenuItem> Menu = new   List<MenuItem>();
        public MenuList(AdminStart main)
        {
            InitializeComponent();
            this.main = main;
            UpdateList();

        }
        public void UpdateList()
        {
            Menu.Clear();
            var temp = main.organiser.Controller.GetAllMenu();
            if (temp == null)
            {
                return;
            }
            foreach (DataRow item in temp.Rows)
            {
                Menu.Add(DataBaseEssentials.ConvertToMenuItemClass(item));
            }
            
            panel1.Controls.Clear();
            for (int i = 0; i < Menu.Count; i++)
            {
                MenuItem item = Menu[i];
                MenuItm it = new MenuItm(main, item);
                panel1.Controls.Add(it);
                it.Location = new System.Drawing.Point(10, 10 + i * it.Height);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            main.GoToUsrContrl(back);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            main.GoToUsrContrl(NextsAdmin.MENUADD);
        }
    }
}
