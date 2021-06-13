using System;
using System.Drawing;
using System.Windows.Forms;
namespace Staff
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
            label1.Text = "Request #" + current.ContactNumber.ToString();
            label2.Text = "Table #" + current.TableNumber.ToString();
            //get customer name from db manager

            label3.Text = "Name :" + main.organiser.Controller.GetClientNameByNum(current.ClientID);
            label4.Text = current.ContactType.ToString();
            if (current.ContactType == RequestType.CHECKOUT)
            {
                this.BackColor = Color.LightCyan;
            }
            label5.Text = current.ContactTime.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
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
                    main.TakenContact(current);
                    return;
                }
                taken = true;
                main.TakenContact(current);
                button1.Text = "Done";
            }
            else
            {
                main.SetContactDone(current);
                main.UpdateList();
            }

        }
    }
}
