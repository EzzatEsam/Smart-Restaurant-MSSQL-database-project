using System;
using System.Windows.Forms;

namespace Db_proj
{
    public partial class pg_1 : UserControl
    {
        AdminStart main;
        bool stt = false;
        int n;
        public pg_1(AdminStart f)
        {
            InitializeComponent();
            this.main = f;
            textBox1.Enabled = false;
            textBox1.Text = f.organiser.Controller.GetTables().Rows.Count.ToString();
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

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (!stt)
            {
                stt = true;
                textBox1.Enabled = true;
                
                button3.Enabled = false;
                return;
            }
            else
            {
                n =Convert.ToInt32( textBox1.Text);
                textBox1.Enabled = false;
                textBox1.Text = main.organiser.Controller.GetTables().Rows.Count.ToString();
                MessageBox.Show((main.organiser.Controller.SetTableNumbers(n)) ? "Done " : "Error");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int test = -1;
            button3.Enabled = int.TryParse(textBox1.Text, out test) && test > 1;
        }
    }
}
