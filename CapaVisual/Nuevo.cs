using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CapaEntidad;

namespace CapaVisual
{
    /// <summary>
    /// Clase base para las ventanas de creación/modificación de anuncios.
    /// </summary>
    public partial class Nuevo : Form
    {
        //Atributos.
        private List<Horario> iListaHorarios = new List<Horario>();

        /// <summary>
        /// Frecuencia con que se mostrará el anuncio. Lista de horarios <see cref="Horario"/>
        /// </summary>
        public List<Horario> ListaHorarios
        {
            get { return iListaHorarios; }
            set { iListaHorarios = value; }
        }

        /// <summary>
        /// Constructor de la ventana.
        /// </summary>
        public Nuevo()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Acciones a realizar para seleccionar la frecuencia.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bSeleccionarHorarios_Click(object sender, EventArgs e)
        {
            //Abrir la ventana de selección de horarios.
            CapaVisual.SeleccionarHorarios vSelector = new CapaVisual.SeleccionarHorarios(iListaHorarios);
            DialogResult resultado = vSelector.ShowDialog();
        }
    }
}
