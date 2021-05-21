using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Client
{
    public partial class Form_C1 : Form
    {
        public Form_C1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool containL = false;
            bool StartS= false;
            bool spaces= false;
            if (textBox1.Text.All(c => char.IsWhiteSpace(c) || char.IsLetter(c)))
                containL = true;

            if (textBox1.Text.StartsWith(" "))
                StartS = true;


            for (int i = 0; i < textBox1.Text.Length-1; i++)
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

            if (textBox1.Text == string.Empty || !containL || StartS || spaces )
            {
            MessageBox.Show("Error, Please enter a valid name.");
            }
            else
            {
                    Form_C2 start = new Form_C2(textBox1.Text);
                    start.Show();
                    this.Hide();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

       
    }
}
