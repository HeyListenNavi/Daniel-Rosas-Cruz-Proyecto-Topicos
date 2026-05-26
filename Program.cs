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
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            AccesoDatos db = new AccesoDatos();

            while (true)
            {
                using (var login = new FormInicioSesion(db))
                {
                    if (login.ShowDialog() == DialogResult.OK)
                    {
                        using (var mainForm = new FormPrincipal(db, login.UsuarioAutenticado))
                        {
                            Application.Run(mainForm);
                        }
                    }
                    else
                    {
                        break; // User cancelled login or closed the login window
                    }
                }
            }
        }
    }
}
