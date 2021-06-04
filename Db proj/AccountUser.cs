using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Db_proj
{
    public class AccountUser : Form
    {
        public FormOrganiser organiser= null;
        public virtual void ReturnBack() { }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AccountUser));
            this.SuspendLayout();
            // 
            // AccountUser
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AccountUser";
            this.ResumeLayout(false);

        }
    }
}
