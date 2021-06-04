using System;
using System.Linq;
using System.Windows.Forms;

namespace Client
{
    public partial class Form_C1 : Form
    {
       public Controller c1;
        public int cid;
        public int tablenumber;
        public Form_C1()
        {
            InitializeComponent();
            c1 = new Controller();
        }
        private void Form_C1_Load (object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool containL = false;
            bool StartS = false;
            bool spaces = false;
            if (textBox1.Text.All(c => char.IsWhiteSpace(c) || char.IsLetter(c)))
                containL = true;

            if (textBox1.Text.StartsWith(" "))
                StartS = true;


            for (int i = 0; i < textBox1.Text.Length - 1; i++)
            {
                if (textBox1.Text[i] == ' ' && textBox1.Text[i + 1] == ' ')
                {
                    spaces = true;
                    break;
                }
                else
                {
                    spaces = false;
                }

            }

            //c => char.IsWhiteSpace(c) || char.IsLetter(c));
            //if (textBox1.Text.StartsWith(" "))

            if (textBox1.Text == string.Empty || !containL || StartS || spaces)
            {
                MessageBox.Show("Error, Please enter a valid name.");
            }
            
            else if (textBox2.Text == string.Empty || !textBox2.Text.All(C=> char.IsDigit(C)) || StartS || spaces)
            {
                MessageBox.Show("Error, Please enter a valid table number.");
            }
            else  if (c1.checktablenumber(int.Parse(textBox2.Text)) == 0)
            {
                MessageBox.Show("Error, Please re-check your table number.");
            }
            else if (c1.checktablestatus(int.Parse(textBox2.Text)) == 0)
            {
                MessageBox.Show("Error, this table should be occupied.");
            }
            else
            {
                cid = c1.insertclient(textBox1.Text, int.Parse(textBox2.Text));
                tablenumber = int.Parse(textBox2.Text);
                c1.updatetablestatus(int.Parse(textBox2.Text), true);
                Form_C2 start = new Form_C2(textBox1.Text, this);
                start.Show();
                this.Hide();

                //string x = DateTime.Now.ToShortTimeString();
                ////DateTime x;
                //DateTime dateTime = DateTime.Parse(x);
                //Console.WriteLine("The specified date is valid: " + dateTime);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
