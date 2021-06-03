using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Data;
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
            Workers.Clear();
            panel1.Controls.Clear();
            // here we reload the employees db 
            var temp = main.organiser.Controller.GetAllEmployees();
            foreach (DataRow item in temp.Rows)
            {
                Workers.Add (DataBaseEssentials.ConvertToWorkerClass(item));
            }

            for (int i = 0; i < Workers.Count; i++)
            {
                Worker item = Workers[i];
                WorkerSingle it = new WorkerSingle(main, item);
                panel1.Controls.Add(it);
                it.Location = new System.Drawing.Point(10, 10 + i * it.Height);
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            main.GoToUsrContrl(NextsAdmin.WORKERADD);
        }

       
        private void WorkersList_Load(object sender, EventArgs e)
        {

        }
    }
}
