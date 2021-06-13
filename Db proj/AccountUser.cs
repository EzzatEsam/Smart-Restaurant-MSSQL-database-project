using System.Windows.Forms;
namespace Staff
{
    public class AccountUser : Form
    {
        public FormOrganiser organiser = null;
        public virtual void ReturnBack() { }
        public bool Refreshing = true;
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
