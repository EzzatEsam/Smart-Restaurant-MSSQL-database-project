using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Client
{
    public partial class Form_C5 : Form
    {
        List<MenuItem> OurMenu = new List<MenuItem>();
        public Form_C5()
        {
            InitializeComponent();
            // temporary data
            for (int i = 0; i < 10; i++)
            {
                MenuItem temp = new MenuItem(i + 1, "Kebab" + i.ToString(), "Meats", 120f, (float)i / 10 * 5);
                OurMenu.Add(temp);
            }
            for (int i = 0; i < 10; i++)
            {
                MenuItem temp = new MenuItem(i + 11, "Tuna" + i.ToString(), "Fish", 120f, (float)i / 10 * 5);
                OurMenu.Add(temp);
            }
            for (int i = 0; i < 10; i++)
            {
                MenuItem temp = new MenuItem(i + 21, "Dog" + i.ToString(), "Animals", 120f, (float)i / 10 * 5);
                OurMenu.Add(temp);
            }
            UpdateList();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form_C6 confirm = new Form_C6();
            confirm.Show();
            this.Hide();
        }
        public void UpdateList()
        {
            foreach (Control item in panel1.Controls)
            {
                item.Dispose();
            }
            panel1.Controls.Clear();
            for (int i = 0; i < OurMenu.Count; i++)
            {
                MenuItem item = OurMenu[i];
                ItmInMenu temp = new ItmInMenu(this, item);
                panel1.Controls.Add(temp);
                temp.Location = new Point(20, 20 +   45*i);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            //Form_C2 back = new Form_C2();
            //start.Show();
            //this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form_C5_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //textBox2.Text = "";
        }
    }
}
