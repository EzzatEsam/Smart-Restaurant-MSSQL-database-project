using System;
using System.Windows.Forms;
using System.Collections.Generic;
namespace Client
{
    public partial class Form_C9 : Form
    {
        bool conf = false;
        string name;
        List<MenuItem> menuItems = new List<MenuItem>();
        //List<int> Doubles = new List<int>();
        Form_C4 back;
        public Form_C9(string newname, Form_C4 newback)
        {
            name = newname;
            InitializeComponent();
            this.ControlBox = false;
            back = newback;
            var output = DataBaseEssentials.c1.GetClientWholeMenu(DataBaseEssentials.cid); ;
            label1.Text = "Nice to have you " + name;

            float sum = 0;
            foreach (var item in output)
            {
                int index = 0;
                int n = 1;
                for (int i = 0; i < menuItems.Count; i++)
                {
                    MenuItem itm = menuItems[i];
                    if (item.name == itm.name)
                    {
                        n+=Convert.ToInt32( dataGridView1[0, i].Value);
                        index = i;
                    }
                }
                sum += item.price;
                if (n==1)
                {
                    menuItems.Add(item);
                    this.dataGridView1.Rows.Add(n, item.name, item.price);
                }
                else
                {
                    dataGridView1[0,index].Value = n;
                    dataGridView1[2, index].Value = n*item.price;
                }
                
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
            if (conf)
            {
                
                DataBaseEssentials.c1.updatetablestatus(DataBaseEssentials.tablenumber, false);
                DataBaseEssentials.Main.Show();
                DataBaseEssentials.Main.RefreshAgain();
                this.Dispose();
                return;
            }
            string x = DateTime.Now.ToShortTimeString();
            DateTime dateTime = DateTime.Parse(x);
            DataBaseEssentials.c1.InsertCR(DataBaseEssentials.cid, DataBaseEssentials.tablenumber, dateTime, true);
            button1.Enabled = false;
            button1.Hide();
            button2.Text = "Leave";
            conf = true;
            label1.Text = "Please wait for a waiter to come by";
        }
    }
}
