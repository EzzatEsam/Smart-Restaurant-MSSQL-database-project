using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Client
{
    public partial class Form_C5 : Form
    {
        Form_C2 back;
        List<ShoppingItm> Shopping = new List<ShoppingItm>();
        List<MenuItem> OurMenu = new List<MenuItem>();
        
        public Form_C5(Form_C2 back)
        {
            InitializeComponent();
            this.ControlBox = false;
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

            for (int i = 0; i < OurMenu.Count; i++)
            {
                MenuItem item = OurMenu[i];
                ItmInMenu temp = new ItmInMenu(this, item);
                panel1.Controls.Add(temp);
                temp.Location = new Point(20, 20 + 45 * i);


            }
            //for (int i = 0; i < Shopping.Count; i++)
            //{
            //    MenuItem item = Shopping[i];
            //    ShoppingItm temp = new ShoppingItm(this, item);
            //    panel2.Controls.Add(temp);
            //    temp.Location = new Point(10 + temp.Width * i, 20);
            //}
        }
        void AddToDrawnItems()
        {
            
            panel2.Controls.Clear();
            for (int i = 0; i < Shopping.Count; i++)
            {
                ShoppingItm temp = Shopping[i]; 
                panel2.Controls.Add(temp);
                temp.Location = new Point(10 + temp.Width * i, 20);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            back.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        public void AddToShopping(MenuItem it)
        {
            for (int i = 0; i < Shopping.Count; i++)
            {
                if (Shopping[i].current == it)
                {
                    Shopping[i].n++;
                    Shopping[i].UpdateLabel();
                    UpdateSum();
                    return;
                }
            }
            ShoppingItm temp = new ShoppingItm(this, it);
            Shopping.Add(temp);
            AddToDrawnItems();
            UpdateSum();
        }
        private void Form_C5_Load(object sender, EventArgs e)
        {

        }
        public void DeleteFromShopping(ShoppingItm it)
        {
            //todo
            Shopping.Remove(it);
            AddToDrawnItems();
            UpdateSum();
        }
        public void UpdateSum()
        {
            float total = 0f;
            foreach (ShoppingItm item in Shopping)
            {
                total += item.current.price * item.n;
            }
            textBox1.Text = total.ToString();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            foreach (Control item in panel2.Controls)
            {
                item.Dispose();
            }
            panel2.Controls.Clear();
            Shopping.Clear();
            textBox1.Text = "0";

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
