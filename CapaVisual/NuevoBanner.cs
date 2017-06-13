using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CapaEntidad;

namespace CapaVisual
{
    /// <summary>
    /// Ventana específica para la creación/modificación de un nuevo banner.
    /// </summary>
    public partial class NuevoBanner : Nuevo
    {
        //Atributos.
        //Consultar al profesor como se podría hacer con una especie de TEntity
        private BannerEstatico iBannerEstatico;
        private RSSFeed iRSSFeed;
        private FachadaCapaVisual iFachada;

        /// <summary>
        /// Banner del tipo estático.
        /// </summary>
        public BannerEstatico Banner
        {
            get { return iBannerEstatico; }
            set { iBannerEstatico = value; }
        }

        /// <summary>
        /// Banner del tipo RSS.
        /// </summary>
        public RSSFeed RSSFeed
        {
            get { return iRSSFeed; }
            set { iRSSFeed = value; }
        }

        /// <summary>
        /// Constructor de la ventana para un banner estático.
        /// </summary>
        /// <param name="pBannerEstatico">Banner estático a cargar/modificar.</param>
        public NuevoBanner(BannerEstatico pBannerEstatico)
        {
            InitializeComponent();
            iBannerEstatico = pBannerEstatico;
            this.Name = "Nuevo Banner Estático";
        }

        /// <summary>
        /// Constructor de la ventana para un banner RSS.
        /// </summary>
        /// <param name="pRSSFeed">Banner RSS a cargar/modificar.</param>
        public NuevoBanner(RSSFeed pRSSFeed, FachadaCapaVisual pFachada)
        {
            InitializeComponent();
            iRSSFeed = pRSSFeed;
            iFachada = pFachada;
            this.Name = "Nuevo Banner RSS";
        }

        /// <summary>
        /// Acciónes a realizar cuando se quiere seleccionar una fuente RSS.
        /// </summary>
        private void btnSeleccionarFuenteRSS_Click(object sender, EventArgs e)
        {
            //Abrir la ventana para la seleccion de fuentes pasándole el banner como parámetro para modificarlo.
            ComprobarRSSFeed mNuevoRSS = new ComprobarRSSFeed(RSSFeed,iFachada);
            mNuevoRSS.ShowDialog();
        }

        /// <summary>
        /// Cancelar cambios.
        /// </summary>
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            //Cerrar ventana.
            this.Close();
        }

        /// <summary>
        /// Aceptar cambios.
        /// </summary>
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            //No controlo la cantidad de elementos en ListaHorarios para que se puedan guardar campañas o banners inactivos.
            //Sí es un banner estático se carga éste atributo.
            if (iBannerEstatico != null)
            {
                Banner.Texto = tbEstatico.Text;
                Banner.Nombre = this.tbNombre.Text;
                Banner.Descripcion = this.tbDescripcion.Text;
                Banner.Frecuencia = this.ListaHorarios;
                Banner.FechaInicio = this.dtpFechaInicio.Value;
                Banner.FechaFin = this.dtpFechaFin.Value;
            }
            //Sino, es un banner RSS y se carga dicho atributo.
            else
            {
                RSSFeed.Nombre = this.tbNombre.Text;
                RSSFeed.Descripcion = this.tbDescripcion.Text;
                RSSFeed.Frecuencia = this.ListaHorarios;
                RSSFeed.FechaInicio = this.dtpFechaInicio.Value;
                RSSFeed.FechaFin = this.dtpFechaFin.Value;
            }
            //Cerrar ventana.
            this.Close();
        }

        /// <summary>
        /// Acciones a realizar durante la carga de la ventana.
        /// </summary>
        private void NuevoBanner_Load(object sender, EventArgs e)
        {
            //Sí es un banner estático el que se provee al constructor, la ventana se carga para tal elemento.
            if (iBannerEstatico != null)
            {
                lblEstatico.Visible = true;
                tbEstatico.Visible = true;
                btnSeleccionarFuenteRSS.Visible = false;
            }
            //Sino se carga para un banner RSS.
            else
            {
                lblEstatico.Visible = false;
                tbEstatico.Visible = false;
                btnSeleccionarFuenteRSS.Visible = true;
            }
        }
    }
}
