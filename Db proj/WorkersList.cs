using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.Threading.Tasks;
namespace Staff
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
            var temp = main.organiser.Controller.GetAllEmployees();
            if (temp == null)
            {
                return;
            }
            List<Worker> tempworkers = new List<Worker>();
            foreach (DataRow item in temp.Rows)
            {
                tempworkers.Add(DataBaseEssentials.ConvertToWorkerClass(item));
            }
            if (Workers.Count != tempworkers.Count)
            {
                goto here;
            }
            for (int i = 0; i < tempworkers.Count; i++)
            {
                if (Workers[i].CurrentTask != tempworkers[i].CurrentTask)
                {
                    goto here;
                }
                
            }
            return;
        here:
            Workers.Clear();
            Workers = tempworkers;
            panel1.Controls.Clear();
            
            
            

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

        void AsyncUpdate()
        {
            //MessageBox.Show("done");
            if (!IsHandleCreated)
            {
                return;
            }
            
                this.BeginInvoke(new MethodInvoker(delegate ()
                {
                    UpdateList();
                    
                }));
            
            Task.Delay(new TimeSpan(0, 0, 0, 0, 500)).ContinueWith(o => { AsyncUpdate(); });
        }
        private void WorkersList_Load(object sender, EventArgs e)
        {
            AsyncUpdate();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
