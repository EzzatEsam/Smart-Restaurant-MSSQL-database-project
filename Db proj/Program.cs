using System;
using System.Windows.Forms;

namespace Staff
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            FormOrganiser Organiser = new FormOrganiser();
            F_login StartForm = new F_login(Organiser);
            Organiser.Start = StartForm;
            Application.Run(StartForm);
        }
    }
}
