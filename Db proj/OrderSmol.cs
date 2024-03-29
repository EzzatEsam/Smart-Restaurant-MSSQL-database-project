﻿using System;
using System.Windows.Forms;

namespace Staff
{
    public partial class OrderSmol : UserControl
    {
        Order current;
        ChefStart main;
        int labelmaxsize = 50;
        public OrderSmol(Order current, ChefStart c)
        {
            InitializeComponent();
            this.current = current;
            main = c;
            label1.Text = "Order #" + current.OrderID.ToString();
            foreach (MenuItem item in current.Items)
            {
                label2.Text += item.name + " ,";
                if (label2.Text.Length > labelmaxsize)
                {
                    label2.Text += "..";
                    break;

                }
            }
            label3.Text = "Time :" + current.OrderTime.ToString();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void OrderSmol_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            main.Expand(current);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
