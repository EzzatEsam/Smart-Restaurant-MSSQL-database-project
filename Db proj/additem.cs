using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
namespace Staff
{
    public partial class additem : UserControl
    {
        bool NameError, CatError, PriceError;

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
            UpdateCombo();
        }
        public void UpdateCombo()
        {
            var it = main.organiser.Controller.GetAllCats();
            foreach (var item in it)
            {
                comboBox1.Items.Add(item);
            }

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

            MenuItem it = new MenuItem(-1, textBox1.Text, comboBox1.Text, float.Parse(textBox3.Text));
            it.Image = pictureBox1.Image;
            //it.Image = filename;
            if (main.AddToMenu(it))
            {
                MessageBox.Show("Done");
                UpdateCombo();
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
                //filename = open.FileName;


            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            CatError = !(comboBox1.Text.All(char.IsLetter)) || comboBox1.Text == "";
            label5.Text = !CatError ? "" : "Error";
            button1.Enabled = !(NameError || PriceError || CatError);
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            CatError = !(comboBox1.Text.All(char.IsLetter)) || comboBox1.Text == "";
            label5.Text = !CatError ? "" : "Error";
            button1.Enabled = !(NameError || PriceError || CatError);
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

        }
    }
}
