using System;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
namespace Db_proj
{
    public partial class additem : UserControl
    {
        bool NameError, CatError, PriceError;
        string filename;
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
            button1.Enabled = false;
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
            button1.Enabled = !(NameError || PriceError || CatError);
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
                MenuItem it = new MenuItem(-1, textBox1.Text, textBox2.Text, float.Parse(textBox3.Text));
                //it.Image = filename;
                if (main.AddToMenu(it) )
                {
                MessageBox.Show("Done");
                }
                else
                ErrorLabel.Text = "Error";
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            main.GoToUsrContrl(NextsAdmin.MENULIST);
        }

        private void additem_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            // image filters  
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                // display image in picture box  
                pictureBox1.Image = new Bitmap(open.FileName);
                filename = open.FileName;


            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            float test;
            PriceError = !float.TryParse(textBox3.Text, out test) || textBox3.Text == "" || test <= 0;
            label6.Text = !PriceError ? "" : "Error";
            button1.Enabled = !(NameError || PriceError || CatError);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            CatError = !(textBox2.Text.All(char.IsLetter)) || textBox2.Text == "";
            label5.Text = !CatError ? "" : "Error";
            button1.Enabled = !(NameError || PriceError || CatError);
        }
    }
}
