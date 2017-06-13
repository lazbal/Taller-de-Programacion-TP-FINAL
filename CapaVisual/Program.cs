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
            FachadaCapaVisual iFachada = new FachadaCapaVisual();
            AdminCarteleria ventana = new AdminCarteleria(iFachada);
            ventana.ShowDialog();
        }
    }
}
