using System;
using System.Linq;
using System.Windows.Forms;

namespace Db_proj
{
    public partial class AddWorker : UserControl
    {

        AdminStart main;

        bool NameError, usrError, passError;
        public AddWorker(AdminStart main)
        {
            InitializeComponent();
            this.main = main;

            comboBox1.DataSource = Enum.GetValues(typeof(Emp_type));
            Namelabel.Text = "";
            label5.Text = "";
            label6.Text = "";
            button1.Enabled = !(NameError || passError || usrError);

        }

        private void button1_Click(object sender, EventArgs e)
        {

            
                Worker it = new Worker(-1, textBox1.Text, (Emp_type)comboBox1.SelectedItem, true, -1, Task.NONE);
            if (main.organiser.Controller.AddEmp(it, textBox2.Text, textBox3.Text))
                MessageBox.Show("Done");
            else
                MessageBox.Show("Error");
        }

        private void AddWorker_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            NameError = !(textBox1.Text.All(c => char.IsWhiteSpace(c) || char.IsLetter(c))) || textBox1.Text == "";
            for (int i = 0; i < textBox1.Text.Length - 1; i++)
            {
                if (textBox1.Text[i] == ' ' && textBox1.Text[i + 1] == ' ')
                {
                    NameError = true;
                    break;
                }
                else
                {
                    NameError = false;
                }

            }
            Namelabel.Text = !NameError ? "" : "Error";
            button1.Enabled = !(NameError || passError || usrError);

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            main.GoToUsrContrl(NextsAdmin.WORKERSLIST);
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click_1(object sender, EventArgs e)
        {

        }

        private void Namelabel_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            label5.Text = textBox2.Text == "" ? "Error" : "";
            usrError = textBox2.Text == "";
            if (!textBox2.Text.All(char.IsLetterOrDigit))
            {
                label5.Text = "Error";
                usrError = true;
            }
            button1.Enabled = !(NameError || passError || usrError);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            label6.Text = textBox3.Text == "" ? "Error" : "";
            passError = textBox3.Text == "";
            button1.Enabled = !(NameError || passError || usrError);
        }
    }
}
