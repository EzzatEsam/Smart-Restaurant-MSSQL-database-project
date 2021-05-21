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

    public partial class F_login : Form
    {
        bool login_check, pass_check;
        public F_login()
        {
            InitializeComponent();
            textBox2.Text = "Password";
            textBox1.Text = "Username";
            textBox2.ForeColor = Color.Gray;
            textBox1.ForeColor = Color.Gray;
            button1.Enabled = false;
        }
        public void Reset()
        {
            textBox2.Text = "Password";
            textBox1.Text = "";
            label1.Text = "";
            textBox2.PasswordChar = '\0';
            textBox2.ForeColor = Color.Gray;
            textBox1.ForeColor = Color.Black;
            button1.Enabled = false;
            login_check = false;
            pass_check = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // here we send the login details to db and go to the next form according to the type of the returned account user
            // right no we just go with "chef" "admin" "waiter"
            switch (textBox1.Text)
            {
                case "admin":
                    Form nextAdmin = new AdminStart(this);
                    nextAdmin.Show();
                    this.Hide();
                    break;
                case "chef":
                    Form nextChef = new ChefStart(this);
                    nextChef.Show();
                    this.Hide();
                    break;
                case "waiter":
                    Form nextWaiter = new WaiterStart(this);
                    nextWaiter.Show();
                    this.Hide();
                    break;
                default:
                    label1.Text = "Wrong combination";
                    label1.ForeColor = Color.Red;
                    break;
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "Username" && textBox1.Text != "")
                login_check = true;
            else
                login_check = false;
            button1.Enabled = login_check && pass_check;

        }  
        void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text.Length == 0)
            {
                textBox2.PasswordChar = '\0';
                textBox2.ForeColor = Color.Gray;
                textBox2.Text = "Password";
            }
        }
        void psstxt_enter(object sender , EventArgs e)
        {
            if (textBox2.Text == "Password")
            {
                textBox2.PasswordChar = '*';
                textBox2.ForeColor = Color.Black;
                textBox2.Text = "";
            }
            

        }
        private void textBox1_Enter_1(object sender, EventArgs e)
        {
            if (textBox1.Text == "Username")
            {
                textBox1.ForeColor = Color.Black;
                textBox1.Text = "";
            }
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            {
                if (textBox2.Text != "Password" && textBox2.Text !="")
                    pass_check = true;
                else
                    pass_check = false;
                button1.Enabled = login_check && pass_check;

            }
        }
        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 0)
            {
                textBox1.ForeColor = Color.Gray;
                textBox1.Text = "Username";
            }

        }

    }
}
