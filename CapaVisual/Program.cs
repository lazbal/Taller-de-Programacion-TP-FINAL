using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidad;

namespace CapaVisual
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            AdminCarteleria ventana = new AdminCarteleria();
            //Presentacion ventana = new Presentacion();
            ventana.ShowDialog();
        }
    }
}
