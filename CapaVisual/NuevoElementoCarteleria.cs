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
    public partial class NuevoElementoCarteleria : Nuevo
    {
        //Atributos.
        private ElementoCarteleria iElementoCarteleria;
        private bool iModoActualizacion;

        /// <summary>
        /// Constructor de la ventana.
        /// </summary>
        /// <param name="pElementoCarteleria">Campaña a cargar/modificar.</param>
        public NuevoElementoCarteleria(ElementoCarteleria pElementoCarteleria, bool pModoActualizacion = false) : base()
        {
            InitializeComponent();
            iModoActualizacion = pModoActualizacion;
            lvImagenes.LargeImageList = new ImageList();
            //Cargamos a la ventana el elemento de cartelería parámetro
            iElementoCarteleria = pElementoCarteleria;
            //Para las fechas no se comprueba la nulidad ya que no es posible.
            this.dtpFechaInicio.Value = iElementoCarteleria.FechaInicio;
            this.dtpFechaFin.Value = iElementoCarteleria.FechaFin;
            if (!String.IsNullOrEmpty(iElementoCarteleria.Nombre))
            {
                this.tbNombre.Text = iElementoCarteleria.Nombre;
            }
            if (!String.IsNullOrEmpty(iElementoCarteleria.Descripcion))
            {
                this.tbDescripcion.Text = iElementoCarteleria.Descripcion;
            }
            if (iElementoCarteleria.Frecuencia == null)
            {
                this.iElementoCarteleria.Frecuencia = new List<Horario>();
            }
            this.ListaHorarios = this.iElementoCarteleria.Frecuencia.ToList();
            //Si es un elemento de cartelería nuevo se genera la lista de imágenes.
            if (iElementoCarteleria.Campaña == null)
            {
                //Inicializa la lista de imágenes del recuadro derecho en la ventana.
                iElementoCarteleria.Campaña = new Campaña();
            }
            else
            {
                foreach (ImagenCampaña mImagenCampaña in iElementoCarteleria.Campaña.ListaImagenes)
                {
                    lvImagenes.LargeImageList.Images.Add(mImagenCampaña.Ruta, mImagenCampaña.Imagen);
                    lvImagenes.Items.Add(mImagenCampaña.Ruta, mImagenCampaña.Ruta);
                }
                this.numMM.Value = this.iElementoCarteleria.Campaña.TiempoXImagen.Minutes;
                this.numHH.Value = this.iElementoCarteleria.Campaña.TiempoXImagen.Hours;
            }
            //Tamaño para la vista previa de las imágenes.
            lvImagenes.LargeImageList.ImageSize = new Size(235, 235);
            //Si es un elemento de cartelería nuevo se genera el banner.
            if (iElementoCarteleria.Banner == null)
            {
                this.cbTipoBanner.SelectedItem = this.cbTipoBanner.Items[1];
                iElementoCarteleria.Banner = new BannerEstatico();
            }
            else if (iElementoCarteleria.Banner is RSSFeed)
            {
                this.cbTipoBanner.SelectedItem = this.cbTipoBanner.Items[0];
                this.tbBanner.Text = (iElementoCarteleria.Banner as RSSFeed).URL;
                this.btnSeleccionarFuenteRSS.Visible = true;
            }
            else
            {
                //Debe ir primero esta linea
                this.tbBanner.Text = (iElementoCarteleria.Banner as BannerEstatico).Texto;
                this.cbTipoBanner.SelectedItem = this.cbTipoBanner.Items[1];
            }
        }

        /// <summary>
        /// Acciones a realizar al seleccionar agregar imágenes.
        /// </summary>
        private void bAgregarImagenes_Click(object sender, EventArgs e)
        {
            //Abrir una ventana de seleccion de archivos y filtrar por formatos de imágenes.
            abrirImagenes.Filter = "Todas las Imágenes|*.png;*.jpg;*.bmp";
            DialogResult result = abrirImagenes.ShowDialog();
            //Sí salió correctamente
            if (result == DialogResult.OK)
            { 
                //Se crea un arreglo con las rutas de los archivos.
                string[] rutas = abrirImagenes.FileNames;
                //Para cada elemento del arreglo, se lo agrega a la lista para la vista previa.
                for (int i = 0; i < rutas.Length; i++)
                {
                    Image iImage = Image.FromFile(rutas[i]);
                    lvImagenes.LargeImageList.Images.Add(rutas[i], Image.FromFile(rutas[i]));
                    lvImagenes.Items.Add(rutas[i], rutas[i]);
                }
            }
        }

        /// <summary>
        /// Acciones a realizar al seleccionar quitar imágenes seleccionadas.
        /// </summary>
        private void bQuitarImagenes_Click(object sender, EventArgs e)
        {
            //Para cada una de las imágenes seleccionadas.
            for (int i = 0; i < lvImagenes.SelectedItems.Count; i++)
            {
                //Eliminarlas de la lista.
                ListViewItem item = lvImagenes.SelectedItems[i];
                lvImagenes.Items.Remove(item);
                lvImagenes.LargeImageList.Images.RemoveByKey(item.ImageKey);
            }
        }

        /// <summary>
        /// Acciones a realizar al seleccionar tiempo máximo sugerido.
        /// </summary>
        private void bTMS_Click(object sender, EventArgs e)
        {
            //Sí la lista de imágenes cargadas está vacía, el tiempo es 0. Caso contrario
            if (this.lvImagenes.Items.Count != 0)
            {
                //Se obtiene el menos intervalo de tiempo que durará la campaña en un día y se lo divide por la cantidad de imágenes que lleve la campaña.
                decimal tiempoMinimoImagenMinutos = Convert.ToDecimal(TiempoMinimo().TotalMinutes / lvImagenes.Items.Count);
                this.numHH.Value = Convert.ToInt32(Math.Truncate(tiempoMinimoImagenMinutos / (decimal)60.0));
                this.numMM.Value = Convert.ToInt32(tiempoMinimoImagenMinutos - this.numHH.Value*60);
            }
        }

        /// <summary>
        /// Acción a realizar al hacer doble click sobre una imágen en la vista previa.
        /// </summary>
        private void lvImagenes_DoubleClick(object sender, EventArgs e)
        {
            //Recrear la imagen.
            string imagen = lvImagenes.SelectedItems[0].ImageKey;
            //Mostrar imagen en pantalla completa.
            CapaVisual.CuadroImagen verImagen = new CapaVisual.CuadroImagen(imagen);
            verImagen.ShowDialog();
        }

        /// <summary>
        /// Obtiene el intervalo de tiempo de menor duración en que debe mostrarse la campaña.
        /// </summary>
        /// <returns>Devuelve el valor del intervalo de tiempo.</returns>
        private TimeSpan TiempoMinimo()
        {
            //Sí la lista está vacía, el intervalo es 0.
            if (this.ListaHorarios.Count == 0)
            {
                return new TimeSpan(0, 0, 0);
            }
            else
            {
                //Calcula el mínimo intervalo de tiempo y lo devuelve.
                return this.ListaHorarios.Min(elem => elem.HoraFin - elem.HoraInicio);
            }
        }

        /// <summary>
        /// Acciónes a realizar cuando se quiere seleccionar una fuente RSS.
        /// </summary>
        private void btnSeleccionarFuenteRSS_Click(object sender, EventArgs e)
        {
            (this.iElementoCarteleria.Banner as RSSFeed).URL = this.tbBanner.Text;
            //Abrir la ventana para la seleccion de fuentes pasándole el banner como parámetro para modificarlo.
            ComprobarRSSFeed mNuevoRSS = new ComprobarRSSFeed(iElementoCarteleria.Banner as RSSFeed);
            mNuevoRSS.ShowDialog();
            this.tbBanner.Text = (this.iElementoCarteleria.Banner as RSSFeed).URL;
        }

        /// <summary>
        /// Evento al cambiar la selección en la lista de tipo de banner.
        /// </summary>
        private void cbTipoBanner_SelectedValueChanged(object sender, EventArgs e)
        {
            switch (this.cbTipoBanner.SelectedIndex)
            {
                //Caso de que se seleccione RSSFeed
                case 0:
                    {
                        this.btnSeleccionarFuenteRSS.Visible = true;
                        this.iElementoCarteleria.Banner = new RSSFeed(this.tbBanner.Text);
                        break;
                    }
                //Caso de que se seleccione Banner Estático
                case 1:
                    {
                        this.btnSeleccionarFuenteRSS.Visible = false;
                        this.iElementoCarteleria.Banner = new BannerEstatico(this.tbBanner.Text);
                        break;
                    }
                default:
                    {
                        this.tbBanner.Text = "Seleccione el tipo de banner";
                        this.btnSeleccionarFuenteRSS.Visible = false;
                        break;
                    }
            }
        }

        /// <summary>
        /// Cancelar los cambios.
        /// </summary>
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            //Cerrar Ventana.
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        /// <summary>
        /// Aceptar los cambios.
        /// </summary>
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            //No controlo la cantidad de elementos en ListaHorarios para que se puedan guardar campañas o banners inactivos.
            //Comprobar que ningun parámetro sea null
            if (this.tbNombre.Text == "" || this.tbDescripcion.Text == "")
            {
                MessageBox.Show("Asegurese de completar todos los campos requeridos");
            }
            else
            {
                //Cargar los datos en la campaña provista.
                iElementoCarteleria.Nombre = this.tbNombre.Text;
                iElementoCarteleria.Descripcion = this.tbDescripcion.Text;
                iElementoCarteleria.FechaInicio = this.dtpFechaInicio.Value;
                iElementoCarteleria.FechaFin = this.dtpFechaFin.Value;
                iElementoCarteleria.Frecuencia.Clear();
                if (this.ListaHorarios.Count > 0)
                {
                    foreach (Horario mHorario in this.ListaHorarios)
                    {
                        iElementoCarteleria.Frecuencia.Add(mHorario);
                    }
                }
                //Campaña
                iElementoCarteleria.Campaña.TiempoXImagen = new TimeSpan(Convert.ToInt32(this.numHH.Value), Convert.ToInt32(this.numMM.Value), 0);
                iElementoCarteleria.Campaña.ListaImagenes.Clear();
                if (this.lvImagenes.LargeImageList.Images.Count > 0)
                {
                    //Agregar cada una de las imágenes en la vista previa a la lista en la campaña.
                    foreach (string mRuta in this.lvImagenes.LargeImageList.Images.Keys)
                    {
                        iElementoCarteleria.Campaña.AgregarImagen(mRuta);
                    }
                }

                //Banner
                //Sólo se actualiza sí es estático, caso contrario se actualiza en la comprobación de la fuente
                if (cbTipoBanner.SelectedIndex == 1)
                {
                    iElementoCarteleria.Banner = new BannerEstatico(tbBanner.Text);
                }

                //Insertar en la base de datos
                if (iModoActualizacion)
                {
                    FachadaCapaVisual.ActualizarElementoCarteleria(iElementoCarteleria);
                }
                else
                {
                    FachadaCapaVisual.AgregarElementoCarteleria(iElementoCarteleria);
                }

                //Cerrar ventana.
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        /// <summary>
        /// Muestra una tabla con los horarios ocupados actualmente.
        /// </summary>
        private void btnHorariosOcupados_Click(object sender, EventArgs e)
        {
            HorariosOcupados vTabla = new HorariosOcupados(this.dtpFechaInicio.Value, this.dtpFechaFin.Value);
            DialogResult resultado = vTabla.ShowDialog();
        }
    }
}
