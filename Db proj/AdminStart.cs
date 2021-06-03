using System;
using System.Windows.Forms;

namespace Db_proj
{
    public enum NextsAdmin
    {
        ADMINENTER, WORKERSLIST, WORKERADD, MENULIST, MENUADD, MODIACCOUNT
    }
    public partial class AdminStart :  AccountUser
    {
        
        UserControl current;
        NextsAdmin currentstate;
        public AdminStart(FormOrganiser it)
        {
            InitializeComponent();
            this.ControlBox = false;
            current = new pg_1(this);
            currentstate = NextsAdmin.ADMINENTER;
            this.Controls.Add(current);
            current.Show();
            organiser = it;
        }
        public bool AddEmployee(Worker it, string Usr, string Pass)
        {
            // here we add new employee to db and check if it can be added
            return false;
        }
        public bool DeleteEmplyee(int ID)
        {
            //delete an employee with given ID from DB
            return false;
        }
        public bool AddToMenu(MenuItem it)
        {
            // here we add new item to db and check if it can be added
            return organiser.Controller.AddItem(it);
        }
        public bool DeleteItem(int ID)
        {
            //delete an item with given ID from DB
            return false;
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
                case NextsAdmin.MODIACCOUNT :
                    temp = new ChangeLogins(this);
                    break;
                default:
                    temp = new pg_1(this);
                    break;
            }

            this.Controls.Remove(current);
            current.Dispose();
            current = temp;
            currentstate = it;
            this.Controls.Add(current);
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
    }
}
