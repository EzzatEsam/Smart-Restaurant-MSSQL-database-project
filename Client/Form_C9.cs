using System;
using System.Windows.Forms;

namespace Client
{
    public partial class Form_C9 : Form
    {
        string name;
        Form_C4 back;
        public Form_C9(string newname, Form_C4 newback)
        {
            name = newname;
            InitializeComponent();
            this.ControlBox = false;
            back = newback;
            var output = back.make.back.back.c1.GetClientWholeMenu(back.make.back.back.cid); ;
            label1.Text = "Nice to have you " + name;
            
            float sum = 0;
            foreach (var item in output)
            {
                sum +=item.price;
                this.dataGridView1.Rows.Add(item.name, item.price);
            }
            textBox2.Text = sum.ToString();
        }
        

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form_C9_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            int sum = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; ++i)
            {
                sum += Convert.ToInt32(dataGridView1.Rows[i].Cells[1].Value);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            back.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
