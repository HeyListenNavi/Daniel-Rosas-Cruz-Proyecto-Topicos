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

            string connectionString = @"Server=localhost\SQLEXPRESS01;Database=TaskAppDB;Integrated Security=True;";
            var db = new AccesoDatos(connectionString);

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
