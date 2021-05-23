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
    public partial class additem : UserControl
    {
        bool NameError ,CatError,PriceError;
        AdminStart main;
        public additem(AdminStart main)
        {
            NameError = true;
            CatError = true;
            PriceError = true;
            InitializeComponent();
            this.main = main;
            Namelabel.Text = "";
            label5.Text = "";
            label6.Text = "";
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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (NameError || CatError || PriceError)
            {
                ErrorLabel.Text = "Error";

            }
            else
            {
                MenuItem it = new MenuItem(-1, textBox1.Text, textBox2.Text,float.Parse( textBox3.Text));
                ErrorLabel.Text = main.AddToMenu(it) ? "" : "Error";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            main.Goto(NextsAdmin.MENULIST);
        }

        private void additem_Load(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            float test;
            PriceError = !float.TryParse(textBox3.Text,out test) || textBox3.Text == "" || test <=0 ;
            label6.Text = !PriceError ? "" : "Error";
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            CatError = !(textBox2.Text.All(char.IsLetter)) || textBox2.Text == "" ;
            label5.Text = !CatError ? "" : "Error";
        }
    }
}
