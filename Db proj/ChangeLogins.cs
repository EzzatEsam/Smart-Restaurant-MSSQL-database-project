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
    public partial class ChangeLogins : UserControl
    {
        bool login_check = false;
        bool pass_check = false;
        bool conf_check = false;
        bool old_check = false;
        AccountUser main;
        public ChangeLogins(AccountUser Main)
        {
            InitializeComponent();
            textBox2.Text = "New Password";
            textBox3.Text = "Confirm Password";
            textBox4.Text = "Old Password";
            textBox1.Text = "New Username";
            label1.Text = "";
            textBox2.PasswordChar = '\0';
            textBox3.PasswordChar = '\0';
            textBox4.PasswordChar = '\0';
            textBox2.ForeColor = Color.Gray;
            textBox3.ForeColor = Color.Gray;
            textBox4.ForeColor = Color.Gray;
            textBox1.ForeColor = Color.Gray;
            main = Main;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "New Username" && textBox1.Text != "")
                login_check = true;
            else
                login_check = false;
            button1.Enabled = login_check && pass_check && conf_check && old_check;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text != "New Passwords" && textBox1.Text != "")
                pass_check = true;
            else
                pass_check = false;
            button1.Enabled = login_check && pass_check && conf_check && old_check;
            label2.Text = textBox3.Text == textBox2.Text || textBox2.Text == "New Passwords" ? " " : "Passwords not matching";
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "New Username")
            {
                textBox1.ForeColor = Color.Black;
                textBox1.Text = "";
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0)
            {
                textBox1.ForeColor = Color.Gray;
                textBox1.Text = "New Username";
            }
        }


        

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "New Password")
            {
                textBox2.PasswordChar = '*';
                textBox2.ForeColor = Color.Black;
                textBox2.Text = "";
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text.Length == 0)
            {
                textBox2.PasswordChar = '\0';
                textBox2.ForeColor = Color.Gray;
                textBox2.Text = "New Password";
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text != "Confirm Password" && textBox3.Text != "" || textBox2.Text != textBox3.Text)
                conf_check = true;
            else
                conf_check = false;
            button1.Enabled = login_check && pass_check && conf_check && old_check;
            label2.Text = textBox3.Text == textBox2.Text || textBox3.Text == "Confirm Password" ? " " : "Passwords not matching";
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (textBox3.Text.Length == 0)
            {
                textBox3.PasswordChar = '\0';
                textBox3.ForeColor = Color.Gray;
                textBox3.Text = "Confirm Password";
            }
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            if (textBox3.Text == "Confirm Password")
            {
                textBox3.PasswordChar = '*';
                textBox3.ForeColor = Color.Black;
                textBox3.Text = "";
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (textBox4.Text != "Old Password" && textBox4.Text != "")
                old_check = true;
            else
                old_check = false;
            button1.Enabled = login_check && pass_check && conf_check && old_check;
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (textBox4.Text.Length == 0)
            {
                textBox4.ForeColor = Color.Gray;
                textBox4.Text = "Old Password"; textBox4.PasswordChar = '\0';
            }
        }

        private void textBox4_Enter(object sender, EventArgs e)
        {
            if (textBox4.Text == "Old Password")
            {
                textBox4.PasswordChar = '*';
                textBox4.ForeColor = Color.Black;
                textBox4.Text = "";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            main.ReturnBack();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (main.organiser.Controller.UpdatePass(main.organiser.Controller.CurrentID, textBox1.Text, textBox2.Text, textBox4.Text))
            {
                main.ReturnBack();
                MessageBox.Show("Done");
            }
            label3.Text = "Check old Password";
            
        }
    }
}
