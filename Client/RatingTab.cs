using System;
using System.Windows.Forms;

namespace Client
{
    public partial class RatingTab : UserControl
    {
        Form_C6 main;
        MenuItem current;
        public RatingTab(Form_C6 main,
        MenuItem current,bool taken)
        {
            InitializeComponent();
            this.main = main;
            this.current = current;
            label1.Text = current.name;
            label2.Text = current.price.ToString() + "LE";
            if (taken)
            {
                StarRatingControl star = new StarRatingControl(this);
                panel1.Controls.Add(star);
            }
        }
        public void RateIt(int stars)
        {
            DataBaseEssentials.c1.InsertRate(DataBaseEssentials.cid, current.number, stars);
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void RatingTab_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
