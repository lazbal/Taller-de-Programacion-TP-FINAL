using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaVisual
{
    /// <summary>
    /// Ventana para mostrar imágenes en pantalla completa
    /// </summary>
    public partial class CuadroImagen : Form
    {
        /// <summary>
        /// Constructor de la Ventana.
        /// </summary>
        /// <param name="pimagen">Ruta de la imagen a mostrar.</param>
        public CuadroImagen(string pimagen)
        {
            InitializeComponent();
            //Carga la imagen en un pictureBox.
            this.pbImagen.Image = Image.FromFile(pimagen);
        }

        /// <summary>
        /// Cerrar ventana al hacer click sobre la imagen.
        /// </summary>
        private void pbImagen_Click(object sender, EventArgs e)
        {
            //Cerrar Ventana
            this.Close();
        }
    }
}
