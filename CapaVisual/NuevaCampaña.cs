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
    public partial class NuevaCampaña : Nuevo
    {
        //Atributos.
        private Campaña iCampaña;

        /// <summary>
        /// Constructor de la ventana.
        /// </summary>
        /// <param name="pCampaña">Campaña a cargar/modificar.</param>
        public NuevaCampaña(Campaña pCampaña) : base()
        {
            InitializeComponent();
            //Inicializa la lista de imágenes del recuadro derecho en la ventana.
            lvImagenes.LargeImageList = new ImageList();
            //Tamaño para la vista previa de las imágenes.
            lvImagenes.LargeImageList.ImageSize = new Size(235, 235);
            iCampaña = pCampaña;
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
                //Problemas cuando se hace negativo
                this.numHH.Value = Convert.ToInt32(tiempoMinimoImagenMinutos / (decimal)60.0);
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
        /// Cancelar los cambios.
        /// </summary>
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            //Cerrar Ventana.
            this.Close();
        }

        /// <summary>
        /// Aceptar los cambios.
        /// </summary>
        private void btnAceptar_Click(object sender, EventArgs e)
        {
            //No controlo la cantidad de elementos en ListaHorarios para que se puedan guardar campañas o banners inactivos.
            //Cargar los datos en la campaña provista.
            iCampaña.Nombre = this.tbNombre.Text;
            iCampaña.Descripcion = this.tbDescripcion.Text;
            iCampaña.FechaInicio = this.dtpFechaInicio.Value;
            iCampaña.FechaFin = this.dtpFechaFin.Value;
            iCampaña.Horario = this.ListaHorarios;
            iCampaña.TiempoXImagen = new TimeSpan(Convert.ToInt32(numHH.Value), Convert.ToInt32(numMM.Value), 0);
            //Agregar cada una de las imágenes en la vista previa a la lista en la campaña.
            foreach (string ruta in lvImagenes.LargeImageList.Images.Keys)
            {
                iCampaña.AgregarImagen(ruta);
            }

            //Cerrar ventana.
            this.Close();
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
    }
}
