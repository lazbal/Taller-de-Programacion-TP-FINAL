using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using CapaEntidad;

namespace CapaVisual
{
    public partial class Presentacion : Form
    {
        private ElementoCarteleria iCartelActual;
        private IEnumerator<ElementoCarteleria> iCartelesHoy;
        private IEnumerator<ImagenCampaña> iImagenesCartelActual;
        private System.Timers.Timer iTemporizadorCartel;
        private System.Timers.Timer iTemporizadorImagen;
        
        /// <summary>
        /// Inicializa una instancia de la ventana de presentación
        /// </summary>
        /// <param name="pFachada"></param>
        public Presentacion()
        {
            InitializeComponent();
            //Activamos el picture box para que no aparezca el cursor en el text box.
            this.ActiveControl = pbCampaña;
            //Obtenemos los carteles de hoy.
            this.iCartelesHoy = FachadaCapaVisual.ObtenerElementosCarteleriaHoy().GetEnumerator();
            //Inicializamos el temporizador de carteles
            iTemporizadorCartel = new System.Timers.Timer();
            //Asignamos el método al evento de finalización del temporizador
            this.iTemporizadorCartel.Elapsed += new System.Timers.ElapsedEventHandler(this.Cartel_Elapsed);
            //Inicializamos el temporizador de imagenes
            iTemporizadorImagen = new System.Timers.Timer();
            //Asignamos el método al evento de finalización del temporizador
            this.iTemporizadorImagen.Elapsed += new System.Timers.ElapsedEventHandler(this.Imagen_Elapsed);
            //Disparamos el evento para que inicie la presentación
            this.Cartel_Elapsed(this, null);
        }

        /// <summary>
        /// Evento disparado al finalizar el tiempo de un cartel.
        /// </summary>
        private void Cartel_Elapsed(object sender, EventArgs e)
        {
            this.CambiarCartel();
        }

        /// <summary>
        /// Evento disparado al finalizar el tiempo de una imagen.
        /// </summary>
        private void Imagen_Elapsed(object sender, EventArgs e)
        {
            this.CambiarImagen();
        }

        /// <summary>
        /// Cambia al siguiente cartel. Coloca una imagen por defecto al finalizar.
        /// </summary>
        private void CambiarCartel()
        {
            //Sí se movió el puntero al próximo cartel y éste no está vacio.
            if (this.iCartelesHoy.MoveNext() && this.iCartelesHoy.Current != null)
            {
                //Lo capturamos
                this.iCartelActual = this.iCartelesHoy.Current;
                //Obtenemos el horario del día de hoy
                Horario mHorarioHoy = this.iCartelActual.GetHorarioHoy();
                //Asignamos el intervalo en milisegundos que durará el cartel.
                this.iTemporizadorCartel.Interval = (mHorarioHoy.HoraFin - mHorarioHoy.HoraInicio).TotalMilliseconds/10000;
                //Capturamos el enumerador de imágenes de la campaña del cartel.
                this.iImagenesCartelActual = this.iCartelActual.Campaña.ListaImagenes.GetEnumerator();
                //Asignamos el intervalo en milisegundos que durará cada imagen de la campaña.
                this.iTemporizadorImagen.Interval = this.iCartelActual.Campaña.TiempoXImagen.TotalMilliseconds/100;
                //Ponemos a correr el temporizador del cartel.
                this.iTemporizadorCartel.Start();
                //Colocamos la primer imagen.
                this.CambiarImagen();
                if (this.iCartelActual.Banner != null)
                {
                    this.tbBanner.Text = this.iCartelActual.Banner.Mostrar();
                }
            }
            else
            {
                //Paramos los temporizadores
                this.iTemporizadorCartel.Stop();
                this.iTemporizadorImagen.Stop();
                //Colocamos la imagen por defecto
                this.pbCampaña.Image = Properties.Resources.CampañaDefecto;
            }
        }

        /// <summary>
        /// Cambia a la siguiente imagen. Reinicia el ciclo si se finalizó la secuencia.
        /// </summary>
        private void CambiarImagen()
        {
            //Sí se pudo mover a la siguiente imagen
            if (this.iImagenesCartelActual.MoveNext())
            {
                //Colocamos la imagen actual
                this.pbCampaña.Image = this.iImagenesCartelActual.Current.Imagen;
                //Ponemos a correr el contador
                this.iTemporizadorImagen.Start();
            }
            else
            {
                //Reiniciamos el puntero al lugar previo a la primer imagen
                this.iImagenesCartelActual.Reset();
                //Colocamos la primer imgaen
                this.CambiarImagen();
            }
        }

        /// <summary>
        ///Al cerrar la ventana despachamos los timers
        /// </summary>
        private void Presentacion_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.iTemporizadorCartel.Dispose();
            this.iTemporizadorImagen.Dispose();
        }
    }
}
