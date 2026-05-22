using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Daniel_Rosas_Cruz
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            string dbPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "tasks.db");
            var db = new AccesoDatos(dbPath);

            using (var login = new UI.LoginForm(db))
            {
                if (login.ShowDialog() == DialogResult.OK)
                {
                    Application.Run(new Form1(db, login.UsuarioAutenticado));
                }
            }
        }
    }
}
