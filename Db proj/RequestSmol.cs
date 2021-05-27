using System;
using System.Windows.Forms;

namespace Db_proj
{
    public partial class RequestSmol : UserControl
    {
        ContactRequest current;

        WaiterStart main;
        int labelmaxsize = 50;
        bool taken;
        public RequestSmol(ContactRequest it, WaiterStart main)
        {
            InitializeComponent();
            current = it;
            this.main = main;
            label1.Text = "Order #" + current.ContactNumber.ToString();
            label2.Text = "Table #" + current.TableNumber.ToString();
            //get customer name from db manager

            label3.Text = "Name :" + "John Cena";
            label4.Text = current.ContactType.ToString();
            label5.Text = current.ContactTime.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            {
                if (!taken)
                {
                    if (main.AmIBusy())
                    {
                        return;
                    }
                    if (current.ContactType == RequestType.CHECKOUT)
                    {
                        main.ExpandCheck(current);
                        main.Taken();
                        return;
                    }
                    taken = true;
                    main.Taken();
                    button1.Text = "Done";
                }
                else
                {
                    main.SetDone(current);
                    main.UpdateList();
                }
            }
        }
    }
}
