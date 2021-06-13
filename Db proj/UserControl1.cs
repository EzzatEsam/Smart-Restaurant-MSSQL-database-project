using System;
using System.Windows.Forms;

namespace Staff
{
    public partial class WorkerSingle : UserControl
    {
        AdminStart main;
        Worker current;
        public WorkerSingle(AdminStart main, Worker it)
        {
            InitializeComponent();
            this.main = main;
            current = it;
            label1.Text = current.ssid.ToString();
            label2.Text = current.name;
            label3.Text = current.type.ToString();
            label4.Text = current.IsFree ? "Free" : "Busy";
            label5.Text = (current.CurrentTask == 0) ? "None" : current.CurrentTask.ToString();
            label6.Text = (current.CurrentTask == 0) ? "None" : current.cType.ToString();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            main.DeleteEmplyee(current.ssid, current.type);
        }
    }
}
