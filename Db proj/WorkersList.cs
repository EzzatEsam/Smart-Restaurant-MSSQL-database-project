using System;
using System.Windows.Forms;
using System.Collections.Generic;
namespace Db_proj
{
    public partial class WorkersList : UserControl
    {
        AdminStart main;
        NextsAdmin back = NextsAdmin.ADMINENTER;
        List<Worker> Workers = new List<Worker>();
        public WorkersList(AdminStart main)
        {
            InitializeComponent();

            this.main = main;
            UpdateList();
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            main.GoToUsrContrl(back);
        }
        public void UpdateList()
        {
            // here we reload the employees db 
            Workers = main.organiser.Controller.GetAllEmployees();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            main.GoToUsrContrl(NextsAdmin.WORKERADD);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int ssid = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            main.DeleteEmplyee(ssid);
            UpdateList();
        }

        private void WorkersList_Load(object sender, EventArgs e)
        {

        }
    }
}
