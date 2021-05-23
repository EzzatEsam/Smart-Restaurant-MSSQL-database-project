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
        Form_C2 back;
        List<MenuItem> Shopping = new List<MenuItem>();
        List<MenuItem> OurMenu = new List<MenuItem>();
        public Form_C5(Form_C2 back)
        {
            InitializeComponent();
            this.back = back;
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
        public void Reset()
        {
            Shopping.Clear();
            UpdateList();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (Shopping.Count == 0)
                return;
                   
                Form_C4 confirm = new Form_C4(back.name, this);
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
            foreach (Control item in panel2.Controls)
            {
                item.Dispose();
            }
            panel2.Controls.Clear();
            for (int i = 0; i < OurMenu.Count; i++)
            {
                MenuItem item = OurMenu[i];
                ItmInMenu temp = new ItmInMenu(this, item);
                panel1.Controls.Add(temp);
                temp.Location = new Point(20, 20 + 45 * i);

                
            }
            for (int i = 0; i < Shopping.Count; i++)
            {
                MenuItem item = OurMenu[i];
                ShoppingItm temp = new ShoppingItm(this, item);
                panel2.Controls.Add(temp);
                temp.Location = new Point(10 + temp.Width * i, 20);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            back.Show();
            this. Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        public void AddToShopping( MenuItem it)
        {
            Shopping.Add(it);
            UpdateList();
            UpdateSum();
        }
        private void Form_C5_Load(object sender, EventArgs e)
        {

        }
        public void DeleteFromShopping(MenuItem it)
        {
            //todo
            Shopping.Remove(it);
            UpdateList();
            UpdateSum();
        }
        void UpdateSum()
        {
            float total = 0f;
            foreach (MenuItem item in Shopping)
            {
                total += item.price;
            }
            textBox1.Text = total.ToString();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Shopping.Clear();
            UpdateList();
            textBox1.Text = "0";

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
