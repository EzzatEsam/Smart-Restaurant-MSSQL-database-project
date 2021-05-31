using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Db_proj
{
    public partial class WaiterStart : Form
    {
        FormOrganiser main;
        List<Order> Orders = new List<Order>();
        List<ContactRequest> Reqs = new List<ContactRequest>();
        int VInterval = 40;
        bool IsBusy = false;
        public WaiterStart(FormOrganiser main)
        {
            InitializeComponent();
            this.ControlBox = false;
            this.main = main;

            // temp test for data
            for (int i = 0; i < 20; i++)
            {
                ContactRequest temp = new ContactRequest();
                temp.ContactNumber = i;
                temp.TableNumber = 14;

                temp.ContactStatus = RequestStatus.PENDING;
                temp.ContactTime = new TimeSpan(20, 15, 0);

                Reqs.Add(temp);


            }
            //

            for (int i = 0; i < 20; i++)
            {
                Order temp = new Order();
                temp.OrderID = i;
                temp.TableNo = 14;
                temp.ClientID = 15;
                temp.Status = Order_status.PENDING;
                temp.OrderTime = new TimeSpan(20, 15, 0);
                for (int j = 0; j < 3; j++)
                {
                    temp.Items.Add(new MenuItem(j, "fish", "also fish", 25f * j / 2));
                }
                Orders.Add(temp);

                //
                ContactRequest temp2 = new ContactRequest();
                temp2.ContactNumber = i;
                temp2.ContactTime = new TimeSpan(20, 15, 0);
                temp2.ContactType = ((float)i % 2f == 0) ? RequestType.CHECKOUT : RequestType.INQUIRY;
                temp2.TableNumber = 14;
                temp2.ContactStatus = RequestStatus.PENDING;
                Reqs.Add(temp2);


            }
            UpdateList();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            main.GoTo(0);
        }
        public void SetDelivered(Order it)
        {
            IsBusy = false;
        }
        public void Taken()
        {
            IsBusy = true;
        }

        public bool AmIBusy()
        {
            return IsBusy;
        }
        public void SetDone(ContactRequest it)
        {
            IsBusy = false;
        }
        public void ExpandCheck(ContactRequest it)
        {
            panel1.Controls.Clear();
            panel2.Controls.Clear();
            foreach (Control item in panel1.Controls)
            {
                item.Dispose();
            }
            foreach (Control item in panel2.Controls)
            {
                item.Dispose();
            }
            panel3.BringToFront();
            check temp = new check(it, this);
            panel3.Controls.Add(temp);




        }
        public void UpdateList()
        {
            panel3.SendToBack();
            // update orders from db
            // update requests from db
            //
            panel1.Controls.Clear();
            panel2.Controls.Clear();
            panel3.Controls.Clear();
            foreach (Control item in panel1.Controls)
            {
                item.Dispose();
            }
            foreach (Control item in panel2.Controls)
            {
                item.Dispose();
            }
            foreach (Control item in panel3.Controls)
            {
                item.Dispose();
            }


            for (int i = 0; i < Orders.Count; i++)
            {
                Order item = Orders[i];
                OrderSmolWaiter it = new OrderSmolWaiter(item, this);
                panel1.Controls.Add(it);
                it.Location = new Point(20, 20 + i * VInterval);
            }
            for (int i = 0; i < Reqs.Count; i++)
            {
                ContactRequest item = Reqs[i];
                RequestSmol it = new RequestSmol(item, this);
                panel2.Controls.Add(it);
                it.Location = new Point(5, 20 + i * VInterval * 3);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void WaiterStart_Load(object sender, EventArgs e)
        {

        }
    }
}
