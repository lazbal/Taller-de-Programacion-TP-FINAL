﻿using System;
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
    public partial class NuevoCampaña : Nuevo
    {
        //Atributos.
        private Campaña iCampaña;
        private bool iModoActualizacion;

        /// <summary>
        /// Inicializa una instancia de la ventana.
        /// </summary>
        /// <param name="pCampaña">Campaña a cargar/modificar.</param>
        public NuevoCampaña(Campaña pCampaña, bool pModoActualizacion = false) : base()
        {
            InitializeComponent();
            iModoActualizacion = pModoActualizacion;
            lvImagenes.LargeImageList = new ImageList();
            //Cargamos a la ventana el elemento de cartelería parámetro
            if (pCampaña == null)
            {
                pCampaña = new Campaña();
            }
            iCampaña = pCampaña;
            //Para las fechas no se comprueba la nulidad ya que no es posible.
            this.dtpFechaInicio.Value = iCampaña.FechaInicio;
            this.dtpFechaFin.Value = iCampaña.FechaFin;
            if (!String.IsNullOrEmpty(iCampaña.Nombre))
            {
                this.tbNombre.Text = iCampaña.Nombre;
            }
            if (!String.IsNullOrEmpty(iCampaña.Descripcion))
            {
                this.tbDescripcion.Text = iCampaña.Descripcion;
            }
            if (iCampaña.Frecuencia == null)
            {
                this.iCampaña.Frecuencia = new List<Horario>();
            }
            this.ListaHorarios = this.iCampaña.Frecuencia.ToList();
            //Obtener imágenes de la campaña
            foreach (ImagenCampaña mImagenCampaña in iCampaña.ListaImagenes)
            {
                lvImagenes.LargeImageList.Images.Add(mImagenCampaña.Ruta, mImagenCampaña.Imagen);
                lvImagenes.Items.Add(mImagenCampaña.Ruta, mImagenCampaña.Ruta);
            }
            //Obtener tiempo por imagen de la campaña
            this.numSS.Value = this.iCampaña.TiempoXImagen.Seconds;
            this.numMM.Value = this.iCampaña.TiempoXImagen.Minutes;
            this.numHH.Value = this.iCampaña.TiempoXImagen.Hours;
            //Tamaño para la vista previa de las imágenes.
            lvImagenes.LargeImageList.ImageSize = new Size(235, 235);
        }

        /// <summary>
        /// Acciones a realizar al seleccionar agregar imágenes.
        /// </summary>
        private void BAgregarImagenes_Click(object sender, EventArgs e)
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
        private void BQuitarImagenes_Click(object sender, EventArgs e)
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
        private void BTMS_Click(object sender, EventArgs e)
        {
            //Sí la lista de imágenes cargadas está vacía, el tiempo es 0. Caso contrario
            if (this.lvImagenes.Items.Count != 0)
            {
                //Se obtiene el menor intervalo de tiempo que durará la campaña en un día y se lo divide por la cantidad de imágenes que lleve la campaña.
                decimal tiempoMinimoPorImagenSegundos = Convert.ToDecimal(TiempoMinimo().TotalSeconds / lvImagenes.Items.Count);
                this.numHH.Value = Convert.ToInt32(Math.Truncate(tiempoMinimoPorImagenSegundos / (decimal)3600.0));
                this.numMM.Value = Convert.ToInt32(Math.Truncate((tiempoMinimoPorImagenSegundos - this.numHH.Value * 3600) / (decimal)60.0));
                this.numSS.Value = Convert.ToInt32(tiempoMinimoPorImagenSegundos - this.numMM.Value * 60 - this.numHH.Value * 3600);
            }
        }

        /// <summary>
        /// Acción a realizar al hacer doble click sobre una imágen en la vista previa.
        /// </summary>
        private void LvImagenes_DoubleClick(object sender, EventArgs e)
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
        /// Muestra una tabla con los horarios ocupados actualmente.
        /// </summary>
        private void BtnHorariosOcupados_Click(object sender, EventArgs e)
        {
            HorariosOcupadosCampañas vTabla = new HorariosOcupadosCampañas(this.dtpFechaInicio.Value, this.dtpFechaFin.Value);
            DialogResult resultado = vTabla.ShowDialog();
        }

        /// <summary>
        /// Sobreescritura del método <see cref="Nuevo.CargarElemento"/>. Carga los datos de la campaña.
        /// </summary>
        protected override bool CargarElemento()
        {
            //Verificación de lista de imágenes.
            if (this.lvImagenes.LargeImageList.Images.Count == 0 && MessageBox.Show("Esta campaña no posee imágenes. ¿Desea continuar de esta manera?", "Advertencia", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return false;
            }
            //Verificación de tiempo por imagen.
            else if (this.lvImagenes.LargeImageList.Images.Count != 0 && this.numHH.Value + this.numMM.Value + this.numSS.Value == 0)
            {
                MessageBox.Show("El tiempo por imagen no puede ser 0");
                return false;
            }
            //Todo en orden.
            else
            {
                //Cargar los datos en la campaña provista.
                iCampaña.Nombre = this.tbNombre.Text;
                iCampaña.Descripcion = this.tbDescripcion.Text;
                iCampaña.FechaInicio = this.dtpFechaInicio.Value;
                iCampaña.FechaFin = this.dtpFechaFin.Value;
                iCampaña.Frecuencia.Clear();
                if (this.ListaHorarios.Count > 0)
                {
                    foreach (Horario mHorario in this.ListaHorarios)
                    {
                        iCampaña.Frecuencia.Add(mHorario);
                    }
                }
                //Campaña
                iCampaña.TiempoXImagen = new TimeSpan(Convert.ToInt32(this.numHH.Value), Convert.ToInt32(this.numMM.Value), Convert.ToInt32(this.numSS.Value));
                iCampaña.ListaImagenes.Clear();
                if (this.lvImagenes.LargeImageList.Images.Count > 0)
                {
                    //Agregar cada una de las imágenes en la vista previa a la lista en la campaña.
                    foreach (string mRuta in this.lvImagenes.LargeImageList.Images.Keys)
                    {
                        iCampaña.AgregarImagen(mRuta);
                    }
                }

                //Insertar en la base de datos
                if (iModoActualizacion)
                {
                    FachadaCapaVisual.ActualizarCampaña(iCampaña);
                }
                else
                {
                    FachadaCapaVisual.AgregarCampaña(iCampaña);
                }

                return true;
            }
        }
    }
}
