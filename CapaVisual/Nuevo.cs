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

        /// <summary>
        /// Evento al hacer click en el botón Aceptar. Realiza comprobaciones de campos requeridos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            //Verificación de nombre no vacío.
            if (this.tbNombre.Text == "")
            {
                MessageBox.Show("El campo Nombre no puede estar vacío");
            }
            //Verificación de descripción no vacía
            else if (this.tbDescripcion.Text == "")
            {
                MessageBox.Show("El campo Descripción no puede estar vacío");
            }
            //Verificación de fechas.
            else if (this.dtpFechaFin.Value < this.dtpFechaInicio.Value)
            {
                MessageBox.Show("La fecha de fin no puede ser menor a la de inicio");
            }
            //Campos obligatorios en orden.
            else
            {
                //Verificación de frecuencia.
                if (this.ListaHorarios.Count == 0 && MessageBox.Show("No se seleccionaron horarios. ¿Desea continuar de esta manera?", "Advertencia", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    return;
                }
                //Sí la operacion subyacente se ejecuta con éxito se cierra el form.
                if (CargarElemento())
                {
                    //Cerrar ventana.
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }

        /// <summary>
        /// Evento al hacer click en el botón Cancelar. Cierra el form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            //Cerrar Ventana.
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        /// <summary>
        /// Método sobreescribible. Funciones a continuación de las comprobaciones básicas de la ventana.
        /// </summary>
        /// <returns>Devuelve el estado de éxito de la operación.</returns>
        protected virtual bool CargarElemento()
        {
            throw new NotImplementedException();
        }
    }
}
