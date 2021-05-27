using System;
using System.Windows.Forms;

namespace Db_proj
{
    public partial class WorkersList : UserControl
    {
        AdminStart main;
        NextsAdmin back = NextsAdmin.ADMINENTER;
        // we get the workers list from db in the constructor
        // right now we just creat a demo list
        Worker[] current =
        {
                new Worker(12,"Ahmed", Emp_type.CHEF,false,444, Task.ORDER ),
                new Worker(13, "Ahmed", Emp_type.CHEF, true, -1, Task.NONE),
                new Worker(14, "Hazem", Emp_type.WAITER, false, 532, Task.ORDER),
                new Worker(15, "Khaled", Emp_type.WAITER, false, 133, Task.CLIENTCONTACT)
        };
        public WorkersList(AdminStart main)
        {
            InitializeComponent();

            this.main = main;
            UpdateList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            main.Goto(back);
        }
        public void UpdateList()
        {
            // here we reload the employees db 
            dataGridView1.Rows.Clear();

            foreach (Worker it in current)
            {
                dataGridView1.Rows.Add(it.ssid.ToString(), it.name, it.type, it.IsFree, it.CurrentTask, it.cType);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            main.Goto(NextsAdmin.WORKERADD);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int ssid = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            main.DeleteEmplyee(ssid);
            UpdateList();
        }
    }
}
