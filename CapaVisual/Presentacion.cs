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
        private ElementoCarteleria iCartelSiguiente;
        private IEnumerator<ElementoCarteleria> iCartelesHoy;
        private IEnumerator<ImagenCampaña> iImagenesCartelActual;
        private System.Timers.Timer iTemporizadorCartel;
        private System.Timers.Timer iTemporizadorImagen;
        //Delegado para la modificación del texto banner desde distintos hilos.
        public delegate void CambiarBanner(string pBanner);
        public CambiarBanner BannerDelegado;
        
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
            //Asignar delegado
            BannerDelegado = new CambiarBanner(CambiarBannerMetodo);
        }

        /// <summary>
        /// Una vez creada la ventana.
        /// </summary>
        private void Presentacion_Load(object sender, EventArgs e)
        {
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
            //Sí se movió el puntero al próximo cartel, que éste no esté vacío y que tenga efectivamente un horario para hoy.
            if (this.iCartelesHoy.MoveNext() || iCartelSiguiente != null && iCartelSiguiente.GetHorarioHoy() != null)
            {
                //Primer ejecución
                if (iCartelSiguiente == null && iCartelActual == null)
                {
                    this.iCartelSiguiente = this.iCartelesHoy.Current;
                    this.CambiarCartel();
                }
                //proximas ejecuciones. Será true cuando se esté por mostrar el ultimo cartel.
                else if (iCartelSiguiente != null)
                {
                    this.iCartelActual = iCartelSiguiente;
                    this.iCartelSiguiente = this.iCartelesHoy.Current;
                    TimeSpan mHoraLocalActual = /*FachadaCapaVisual.FechaBaseHorarios() +*/ DateTime.Now.TimeOfDay;
                    //Obtenemos el horario del día de hoy de la campaña actual
                    Horario mHorarioHoyActual = this.iCartelActual.GetHorarioHoy();
                    if (mHorarioHoyActual.HoraFin >= mHoraLocalActual)
                    {
                        if (mHorarioHoyActual.HoraInicio <= mHoraLocalActual)
                        {
                            double mIntervaloCartel = (mHorarioHoyActual.HoraFin - mHoraLocalActual).TotalMilliseconds;
                            if (iCartelSiguiente != null && iCartelSiguiente.GetHorarioHoy() != null)
                            {
                                //Obtenemos el horario del día de hoy de la campaña siguiente
                                Horario mHorarioHoySiguiente = this.iCartelSiguiente.GetHorarioHoy();
                                //Sí los carteles se superponen, se mostrará el posterior cuando sea su tiempo de iniciar
                                //aunque el anterior no haya terminado
                                double mOpcion2 = (mHorarioHoySiguiente.HoraInicio - mHoraLocalActual).TotalMilliseconds;
                                //Se selecciona el menor de los dos intervalos de tiempo (si se superponen la opcion2 sera menor.
                                if (mOpcion2 > 0)
                                {
                                    mIntervaloCartel = Math.Min(mIntervaloCartel, mOpcion2);
                                }
                            }
                            //Asignamos el menor intervalo en milisegundos que durará el cartel.
                            this.iTemporizadorCartel.Interval = mIntervaloCartel;
                            //Capturamos el enumerador de imágenes de la campaña del cartel.
                            this.iImagenesCartelActual = this.iCartelActual.Campaña.ListaImagenes.GetEnumerator();
                            //Asignamos el intervalo en milisegundos que durará cada imagen de la campaña.
                            this.iTemporizadorImagen.Interval = this.iCartelActual.Campaña.TiempoXImagen.TotalMilliseconds;
                            //Ponemos a correr el temporizador del cartel.
                            this.iTemporizadorCartel.Start();
                            //Colocamos la primer imagen.
                            this.CambiarImagen();
                            //Colocamos el banner.
                            Invoke(BannerDelegado, iCartelActual.Banner.Mostrar());
                        }
                        else
                        {
                            //Colocamos el cartel por defecto
                            MostrarCartelPorDefecto();
                            //Colocamos un intervalo de tiempo hasta que sea el momento de iniciar de la campaña actual.
                            this.iTemporizadorCartel.Interval = (mHorarioHoyActual.HoraInicio - mHoraLocalActual).TotalMilliseconds;
                            this.iTemporizadorCartel.Start();
                        }
                    }
                    else
                    {
                        CambiarCartel();
                    }
                }
            }
            else
            {
                //Paramos los temporizadores
                this.iTemporizadorCartel.Stop();
                this.iTemporizadorImagen.Stop();
                //Colocamos el cartel por defecto
                MostrarCartelPorDefecto();
            }
        }

        /// <summary>
        /// Muestra un cartel por defecto para rellenar los tiempos vacíos.
        /// </summary>
        private void MostrarCartelPorDefecto()
        {
            this.pbCampaña.Image = Properties.Resources.CampañaDefecto;
            this.Invoke(BannerDelegado,Properties.Resources.BannerDefecto);
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
        /// Cambia al banner del cartel actual.
        /// </summary>
        /// <param name="pBanner">Cadena a mostrar</param>
        public void CambiarBannerMetodo(string pBanner)
        {
            if (pBanner != null)
            {
                this.tbBanner.Text = pBanner;
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
