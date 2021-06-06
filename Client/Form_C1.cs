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
        Form_C2 start;
        public Form_C1()
        {
            InitializeComponent();
            c1 = new Controller();
            DataBaseEssentials.c1 = c1;
            pictureBox1.Image = DataBaseEssentials.BinaryToImage(c1.GetLogo());
            DataBaseEssentials.Main = this;
            UpdateTables();

        }
        void UpdateTables()
        {
            var tables= c1.GetEmptyTableNums();
            if (tables == null)
            {
                
                button1.Enabled = false;
                label3.Text = "No empty tables at the moment";
                return;
            }
            label3.Text = "";
            button1.Enabled = true;
            comboBox1.Items.Clear();
            foreach (var item in tables)
            {
                comboBox1.Items.Add(item.ToString());
            }

        }
        private void Form_C1_Load (object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        public void RefreshAgain()
        {
            UpdateTables();
            textBox1.Text = "";
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
            
            else if (comboBox1.Text == string.Empty || !comboBox1.Text.All(C=> char.IsDigit(C)) || StartS || spaces)
            {
                MessageBox.Show("Error, Please enter a valid table number.");
            }
            else  if (c1.checktablenumber(int.Parse(comboBox1.Text)) == 0)
            {
                MessageBox.Show("Error, Please re-check your table number.");
            }
            else if (c1.checktablestatus(int.Parse(comboBox1.Text)) == 0)
            {
                MessageBox.Show("Error, this table should be occupied.");
                UpdateTables();
            }
            else
            {
                cid = c1.insertclient(textBox1.Text, int.Parse(comboBox1.Text));
                DataBaseEssentials.cid = cid;
                tablenumber = int.Parse(comboBox1.Text);
                DataBaseEssentials.tablenumber = tablenumber;
                c1.updatetablestatus(int.Parse(comboBox1.Text), true);
                if (start != null)
                {
                    start.Dispose();
                }
                start = new Form_C2(textBox1.Text, this);
                DataBaseEssentials.ClientName = textBox1.Text;
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
