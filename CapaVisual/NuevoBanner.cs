using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using CapaEntidad;

namespace CapaVisual
{
    /// <summary>
    /// Ventana para crear/modificar una campaña.
    /// </summary>
    public partial class NuevoBanner : Nuevo
    {
        //Atributos.
        private Banner iBanner;
        private bool iModoActualizacion;

        /// <summary>
        /// Constructor de la ventana.
        /// </summary>
        /// <param name="pBanner">Banner a cargar/modificar.</param>
        public NuevoBanner(Banner pBanner, bool pModoActualizacion = false) : base()
        {
            InitializeComponent();
            iModoActualizacion = pModoActualizacion;
            iBanner = pBanner;
            if (iBanner == null)
            {
                this.cbTipoBanner.SelectedItem = this.cbTipoBanner.Items[1];
                iBanner = new BannerEstatico();
            }
            else if (iBanner is RSSFeed)
            {
                //Debe ir primero esta linea para evitar la sobreescritura
                this.tbBanner.Text = (iBanner as RSSFeed).URL;
                this.cbTipoBanner.SelectedItem = this.cbTipoBanner.Items[0];
                this.btnSeleccionarFuenteRSS.Visible = true;
            }
            else
            {
                //Debe ir primero esta linea para evitar la sobreescritura
                this.tbBanner.Text = (iBanner as BannerEstatico).Texto;
                this.cbTipoBanner.SelectedItem = this.cbTipoBanner.Items[1];
            }
            //Para las fechas no se comprueba la nulidad ya que no es posible.
            this.dtpFechaInicio.Value = iBanner.FechaInicio;
            this.dtpFechaFin.Value = iBanner.FechaFin;
            if (!String.IsNullOrEmpty(iBanner.Nombre))
            {
                this.tbNombre.Text = iBanner.Nombre;
            }
            if (!String.IsNullOrEmpty(iBanner.Descripcion))
            {
                this.tbDescripcion.Text = iBanner.Descripcion;
            }
            if (iBanner.Frecuencia == null)
            {
                this.iBanner.Frecuencia = new List<Horario>();
            }
            this.ListaHorarios = this.iBanner.Frecuencia.ToList();
        }

        /// <summary>
        /// Acciónes a realizar cuando se quiere seleccionar una fuente RSS.
        /// </summary>
        private void BtnSeleccionarFuenteRSS_Click(object sender, EventArgs e)
        {
            (this.iBanner as RSSFeed).URL = this.tbBanner.Text;
            //Abrir la ventana para la seleccion de fuentes pasándole el banner como parámetro para modificarlo.
            ComprobarRSSFeed mNuevoRSS = new ComprobarRSSFeed(iBanner as RSSFeed);
            //Sí se comprobó la fuente, se habilita el botón aceptar.
            if (mNuevoRSS.ShowDialog() == DialogResult.OK)
            {
                this.tbBanner.Text = (this.iBanner as RSSFeed).URL;
            }
        }

        /// <summary>
        /// Evento al cambiar la selección en la lista de tipo de banner.
        /// </summary>
        private void CbTipoBanner_SelectedValueChanged(object sender, EventArgs e)
        {
            switch (this.cbTipoBanner.SelectedIndex)
            {
                //Caso de que se seleccione RSSFeed
                case 0:
                    {
                        //Se deshabilita el botón aceptar para que fuerce a comprobar la fuente.
                        this.btnSeleccionarFuenteRSS.Visible = true;
                        if (!(iBanner is RSSFeed))
                        {
                            this.iBanner = new RSSFeed(iBanner);
                        }
                        (this.iBanner as RSSFeed).URL = this.tbBanner.Text;
                        break;
                    }
                //Caso de que se seleccione Banner Estático
                case 1:
                    {
                        this.btnSeleccionarFuenteRSS.Visible = false;
                        if (!(iBanner is BannerEstatico))
                        {
                            this.iBanner = new BannerEstatico(iBanner);
                        }
                        (this.iBanner as BannerEstatico).Texto = this.tbBanner.Text;
                        break;
                    }
                default:
                    {
                        this.btnAceptar.Enabled = true;
                        this.tbBanner.Text = "Seleccione el tipo de banner";
                        this.btnSeleccionarFuenteRSS.Visible = false;
                        break;
                    }
            }
        }

        /// <summary>
        /// Cancelar los cambios.
        /// </summary>
        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            //Cerrar Ventana.
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        /// <summary>
        /// Muestra una tabla con los horarios ocupados actualmente.
        /// </summary>
        private void BtnHorariosOcupados_Click(object sender, EventArgs e)
        {
            HorariosOcupadosBanners vTabla = new HorariosOcupadosBanners(this.dtpFechaInicio.Value, this.dtpFechaFin.Value);
            DialogResult resultado = vTabla.ShowDialog();
        }

        /// <summary>
        /// Sobreescritura del método <see cref="Nuevo.CargarElemento"/>. Carga los datos del banner.
        /// </summary>
        protected override bool CargarElemento()
        {
            //Verificación del texto del banner (URL en caso de fuentes externas).
            if (this.tbBanner.Text == "")
            {
                MessageBox.Show("El campo Texto del Banner no puede estar vacío");
                return false;
            }
            else
            {
                //Cargar los datos en la campaña provista.
                iBanner.Nombre = this.tbNombre.Text;
                iBanner.Descripcion = this.tbDescripcion.Text;
                iBanner.FechaInicio = this.dtpFechaInicio.Value;
                iBanner.FechaFin = this.dtpFechaFin.Value;
                iBanner.Frecuencia.Clear();
                if (this.ListaHorarios.Count > 0)
                {
                    foreach (Horario mHorario in this.ListaHorarios)
                    {
                        iBanner.Frecuencia.Add(mHorario);
                    }
                }
                try
                { 
                    //Insertar en la base de datos
                    if (iModoActualizacion)
                    {
                        FachadaCapaVisual.ActualizarBanner(iBanner);
                    }
                    else
                    {
                        FachadaCapaVisual.AgregarBanner(iBanner);
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return false;
                }
            }
        }
    }
}
