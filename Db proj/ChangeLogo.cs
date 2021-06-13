using System;
using System.Drawing;
using System.Windows.Forms;
namespace Staff
{
    public partial class ChangeLogo : UserControl
    {
        AccountUser main;
        public ChangeLogo(AccountUser main)
        {
            InitializeComponent();
            this.main = main;
            button2.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            // image filters  
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                // display image in picture box  
                pictureBox1.Image = new Bitmap(open.FileName);
                button2.Enabled = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            main.ReturnBack();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (main.organiser.Controller.ChangeLogo(pictureBox1.Image))
            {
                MessageBox.Show("Done");
                ((AdminStart)main).TestUpdate();
                main.ReturnBack();
            }
            else
                MessageBox.Show("Error");

        }
    }
}
