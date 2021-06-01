using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Db_proj
{
    public class FormOrganiser
    {
        public F_login Start;
        public Form Current;
        public DBControlller Controller;

        public FormOrganiser()
        {
            Controller = new DBControlller(this);
        }

        public void GoTo(int formN)   //0 start  1 admin   2 chef 3 waiter
        {
            switch (formN)
            {
                case 0:
                    {
                        
                        if(Current !=null)
                        Current.Dispose();
                        Start.Reset();
                        Start.Show();
                        break;
                    }
                case 1:
                    {
                        Start.Reset();
                        Start.Hide();
                        
                        Form newform = new AdminStart(this);
                        newform.Show();
                        if (Current != null)
                            Current.Dispose();
                        Current = newform;
                        break;
                    }
                case 2:
                    {
                        Start.Reset();

                        Start.Hide();
                        Form newform = new ChefStart(this);
                        newform.Show();
                        if (Current != null)
                            Current.Dispose();
                        Current = newform;
                        break;
                    }
                case 3:
                    {
                        Start.Reset();

                        Start.Hide();
                        Form newform = new WaiterStart(this);
                        newform.Show();
                        if (Current != null)
                            Current.Dispose();
                        Current = newform;
                        break;
                    }
                default:
                    {
                        if (Current != null)
                            Current.Dispose();
                        Start.Show();
                        break;
                    }
            
            }
        }
        
    }
}
