using System;
using System.Windows.Forms;

namespace Db_proj
{
    public partial class pg_1 : UserControl
    {
        AdminStart main;
        public pg_1(AdminStart f)
        {
            InitializeComponent();
            this.main = f;
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            main.GoToUsrContrl(NextsAdmin.WORKERSLIST);
        }

        private void m_bttn_Click(object sender, EventArgs e)
        {

            main.GoToUsrContrl(NextsAdmin.MENULIST);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            main.GoToUsrContrl(NextsAdmin.MODIACCOUNT);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            main.GoToUsrContrl(NextsAdmin.CHANGELOGO);
        }
    }
}
