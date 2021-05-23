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
    public partial class AddWorker : UserControl
    {

        AdminStart main;
        
        bool NameError, usrError, passError;
        public AddWorker(AdminStart main )
        {
            InitializeComponent();
            this.main = main;
           
            comboBox1.DataSource = Enum.GetValues(typeof(Emp_type));
            Namelabel.Text = "";
            label5.Text = "";
            label6.Text = "";
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            if (NameError || passError || usrError)
            {
                ErrorLabel.Text = "Error";
                
            }
            else 
            {
                Worker it = new Worker(-1, textBox1.Text, (Emp_type)comboBox1.SelectedItem, true, -1, Task.NONE);
                ErrorLabel.Text = main.AddEmployee(it,textBox2.Text,textBox3.Text) ? "" : "Error";
            }
        }

        private void AddWorker_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            NameError = !(textBox1.Text.All(c => char.IsWhiteSpace(c) || char.IsLetter(c))) || textBox1.Text== "";
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
            
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            main.Goto(NextsAdmin.WORKERSLIST);
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
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            label6.Text = textBox3.Text == "" ? "Error" : "";
            passError = textBox3.Text == "";
        }
    }
}
