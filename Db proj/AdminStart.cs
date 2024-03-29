﻿using System;
using System.Windows.Forms;

namespace Staff
{
    public enum NextsAdmin
    {
        ADMINENTER, WORKERSLIST, WORKERADD, MENULIST, MENUADD, MODIACCOUNT, CHANGELOGO
    }
    public partial class AdminStart : AccountUser
    {

        UserControl current;
        NextsAdmin currentstate;
        public AdminStart(FormOrganiser it)
        {
            InitializeComponent();
            this.ControlBox = false;
            organiser = it;
            current = new pg_1(this);
            currentstate = NextsAdmin.ADMINENTER;
            panel1.Controls.Add(current);
            current.Show();

            pictureBox1.Image = DataBaseEssentials.BinaryToImage(organiser.Controller.GetLogo());
        }
        public bool AddEmployee(Worker it, string Usr, string Pass)
        {
            // here we add new employee to db and check if it can be added
            return false;
        }
        public bool DeleteEmplyee(int ID, Emp_type type)
        {
            bool test = organiser.Controller.DeleteWorker(ID, type);
            this.GoToUsrContrl(NextsAdmin.WORKERSLIST);
            return test;
        }
        public bool AddToMenu(MenuItem it)
        {
            // here we add new item to db and check if it can be added
            return organiser.Controller.AddItem(it);
        }
        public bool DeleteItem(int ID)
        {
            bool test = organiser.Controller.DeleteItem(ID);
            this.GoToUsrContrl(NextsAdmin.MENULIST);
            return test;
        }
        public void GoToUsrContrl(NextsAdmin it)
        {
            UserControl temp;
            switch (it)
            {
                case NextsAdmin.ADMINENTER:
                    temp = new pg_1(this);
                    break;
                case NextsAdmin.WORKERSLIST:
                    temp = new WorkersList(this);
                    break;
                case NextsAdmin.WORKERADD:
                    temp = new AddWorker(this);
                    break;
                case NextsAdmin.MENULIST:
                    temp = new MenuList(this);
                    break;

                case NextsAdmin.MENUADD:
                    temp = new additem(this);
                    break;
                case NextsAdmin.MODIACCOUNT:
                    temp = new ChangeLogins(this);
                    break;
                case NextsAdmin.CHANGELOGO:
                    temp = new ChangeLogo(this);
                    break;
                default:
                    temp = new pg_1(this);
                    break;
            }

            panel1.Controls.Remove(current);
            current.Dispose();
            current = temp;
            currentstate = it;
            panel1.Controls.Add(current);

        }
        public void TestUpdate()
        {
            pictureBox1.Image = DataBaseEssentials.BinaryToImage(organiser.Controller.GetLogo());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            organiser.GoTo(0);
        }
        public override void ReturnBack()
        {
            GoToUsrContrl(NextsAdmin.ADMINENTER);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            GoToUsrContrl(NextsAdmin.MODIACCOUNT);
        }

        private void AdminStart_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            GoToUsrContrl(NextsAdmin.MODIACCOUNT);
        }
    }
}
