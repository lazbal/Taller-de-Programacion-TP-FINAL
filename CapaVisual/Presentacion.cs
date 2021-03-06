﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using CapaEntidad;
using System.Net;
using System.ComponentModel;

namespace CapaVisual
{
    /// <summary>
    /// Ventana encargada de mostrar las Campañas y Banners, y el control de los tiempos de duración.
    /// </summary>
    public partial class Presentacion : Form
    {
        //Elementos necesarios para la gestión de las campañas.
        #region Campaña
        //Campaña mostrada.
        private Campaña iCampañaActual;
        //Siguiente campaña a mostrar.
        private Campaña iCampañaSiguiente;
        //Enumerador (recorrible) con las campañas para el día de la fecha.
        private IEnumerator<Campaña> iCampañasHoy;
        //Temporizador que controla el tiempo que dura la campaña actual.
        private System.Timers.Timer iTemporizadorCampaña;
        //Enumerador (recorrible) con las imágenes de la campaña actual.
        private IEnumerator<ImagenCampaña> iImagenesCampañaActual;
        //Temporizador que controla el tiempo que dura una imagen de la campaña actual.
        private System.Timers.Timer iTemporizadorImagen;
        #endregion
        //Elementos necesarios para la gestión de los banners.
        #region Banner
        //Banner mostrado
        private Banner iBannerActual;
        //Siguiente banner a mostrar
        private Banner iBannerSiguiente;
        //Enumerador (recorrible) con los banners para el día de la fecha.
        private IEnumerator<Banner> iBannersHoy;
        //Temporizador que controla el tiempo que dura el banner actual.
        private System.Timers.Timer iTemporizadorBanner;
        //Delegado para la modificación del texto banner desde distintos hilos.
        public delegate void CambiarTBBanner(string pBanner);
        public CambiarTBBanner BannerDelegado;
        #endregion

        /// <summary>
        /// Inicializa una instancia de la ventana de presentación
        /// </summary>
        /// <param name="pFachada"></param>
        public Presentacion()
        {
            InitializeComponent();
            //Activamos el picture box para que no aparezca el cursor en el text box.
            this.ActiveControl = pbCampaña;
            //Obtenemos las campañas de hoy.
            this.iCampañasHoy = FachadaCapaVisual.ObtenerCampañasHoy().GetEnumerator();
            //Obtenemos los banners de hoy.
            this.iBannersHoy = FachadaCapaVisual.ObtenerBannersHoy().GetEnumerator();
            //Inicializamos el temporizador de campañas
            iTemporizadorCampaña = new System.Timers.Timer();
            //Inicializamos el temporizador de banners
            iTemporizadorBanner = new System.Timers.Timer();
            //Asignamos el método al evento de finalización del temporizador de campañas
            this.iTemporizadorCampaña.Elapsed += new System.Timers.ElapsedEventHandler(this.Campaña_Elapsed);
            //Asignamos el método al evento de finalización del temporizador de banners
            this.iTemporizadorBanner.Elapsed += new System.Timers.ElapsedEventHandler(this.Banner_Elapsed);
            //Inicializamos el temporizador de imagenes
            iTemporizadorImagen = new System.Timers.Timer();
            //Asignamos el método al evento de finalización del temporizador
            this.iTemporizadorImagen.Elapsed += new System.Timers.ElapsedEventHandler(this.Imagen_Elapsed);
            //Asignar delegado
            BannerDelegado = new CambiarTBBanner(CambiarBannerMetodo);
        }

        /// <summary>
        /// Una vez creada la ventana.
        /// </summary>
        private void Presentacion_Load(object sender, EventArgs e)
        {
            //Disparamos el evento de campañas para que inicie la presentación
            this.Campaña_Elapsed(this, null);
            //Disparamos el evento de banners para que inicie la presentación
            this.Banner_Elapsed(this, null);
        }

        /// <summary>
        /// Evento disparado al finalizar el tiempo de una campaña.
        /// </summary>
        private void Campaña_Elapsed(object sender, EventArgs e)
        {
            this.CambiarCampaña();
        }

        /// <summary>
        /// Evento disparado al finalizar el tiempo de un banner.
        /// </summary>
        private void Banner_Elapsed(object sender, EventArgs e)
        {
            this.CambiarBanner();
        }

        /// <summary>
        /// Evento disparado al finalizar el tiempo de una imagen.
        /// </summary>
        private void Imagen_Elapsed(object sender, EventArgs e)
        {
            this.CambiarImagen();
        }

        /// <summary>
        /// Cambia a la siguiente campaña. Coloca una imagen por defecto al finalizar.
        /// </summary>
        private void CambiarCampaña()
        {
            //Sí se movió el puntero a la próxima campaña, que éste no esté vacío y que tenga efectivamente un horario para hoy.
            if (this.iCampañasHoy.MoveNext() || iCampañaSiguiente != null && iCampañaSiguiente.GetHorarioHoy() != null)
            {
                //Primer ejecución
                if (iCampañaSiguiente == null && iCampañaActual == null)
                {
                    this.iCampañaSiguiente = this.iCampañasHoy.Current;
                    this.CambiarCampaña();
                }
                //proximas ejecuciones. Será true cuando se esté por mostrar la última campaña.
                else if (iCampañaSiguiente != null)
                {
                    this.iCampañaActual = iCampañaSiguiente;
                    this.iCampañaSiguiente = this.iCampañasHoy.Current;
                    TimeSpan mHoraLocalActual = DateTime.Now.TimeOfDay;
                    //Obtenemos el horario del día de hoy de la campaña actual
                    Horario mHorarioHoyActual = this.iCampañaActual.GetHorarioHoy();
                    if (mHorarioHoyActual.HoraFin >= mHoraLocalActual)
                    {
                        if (mHorarioHoyActual.HoraInicio <= mHoraLocalActual)
                        {
                            double mIntervaloCampaña = (mHorarioHoyActual.HoraFin - mHoraLocalActual).TotalMilliseconds;
                            if (iCampañaSiguiente != null && iCampañaSiguiente.GetHorarioHoy() != null)
                            {
                                //Obtenemos el horario del día de hoy de la campaña siguiente
                                Horario mHorarioHoySiguiente = this.iCampañaSiguiente.GetHorarioHoy();
                                //Sí las campañas se superponen, se mostrará la posterior cuando sea su tiempo de iniciar
                                //aunque la anterior no haya terminado
                                double mOpcion2 = (mHorarioHoySiguiente.HoraInicio - mHoraLocalActual).TotalMilliseconds;
                                //Se selecciona el menor de los dos intervalos de tiempo (si se superponen la opcion2 sera menor.
                                if (mOpcion2 > 0)
                                {
                                    mIntervaloCampaña = Math.Min(mIntervaloCampaña, mOpcion2);
                                }
                            }
                            //Asignamos el menor intervalo en milisegundos que durará la campaña.
                            this.iTemporizadorCampaña.Interval = mIntervaloCampaña;
                            //Capturamos el enumerador de imágenes de la campaña.
                            this.iImagenesCampañaActual = this.iCampañaActual.ListaImagenes.GetEnumerator();
                            //Asignamos el intervalo en milisegundos que durará cada imagen de la campaña.
                            this.iTemporizadorImagen.Interval = this.iCampañaActual.TiempoXImagen.TotalMilliseconds;
                            //Ponemos a correr el temporizador de la campaña.
                            this.iTemporizadorCampaña.Start();
                            //Colocamos la primer imagen.
                            this.CambiarImagen();
                        }
                        else
                        {
                            //Colocamos la campaña por defecto
                            MostrarCampañaPorDefecto();
                            //Colocamos un intervalo de tiempo hasta que sea el momento de iniciar de la campaña actual.
                            this.iTemporizadorCampaña.Interval = (mHorarioHoyActual.HoraInicio - mHoraLocalActual).TotalMilliseconds;
                            this.iTemporizadorCampaña.Start();
                        }
                    }
                    else
                    {
                        CambiarCampaña();
                    }
                }
            }
            else
            {
                //Paramos los temporizadores
                this.iTemporizadorCampaña.Stop();
                this.iTemporizadorImagen.Stop();
                //Colocamos la campaña por defecto
                MostrarCampañaPorDefecto();
            }
        }

        /// <summary>
        /// Cambia al siguiente banner. Coloca un banner por defecto al finalizar.
        /// </summary>
        private void CambiarBanner()
        {
            //Sí se movió el puntero al próximo banner, que éste no esté vacío y que tenga efectivamente un horario para hoy.
            if (this.iBannersHoy.MoveNext() || iBannerSiguiente != null && iBannerSiguiente.GetHorarioHoy() != null)
            {
                //Primer ejecución
                if (iBannerSiguiente == null && iBannerActual == null)
                {
                    this.iBannerSiguiente = this.iBannersHoy.Current;
                    //Actualizar noticias del siguiente banner sí es de fuente externa.
                    ActualizarNoticiasBanner(iBannerSiguiente);
                    this.CambiarBanner();
                }
                //proximas ejecuciones. Será true cuando se esté por mostrar el ultimo banner.
                else if (iBannerSiguiente != null)
                {
                    this.iBannerActual = iBannerSiguiente;
                    this.iBannerSiguiente = this.iBannersHoy.Current;
                    TimeSpan mHoraLocalActual = DateTime.Now.TimeOfDay;
                    //Obtenemos el horario del día de hoy del banner actual
                    Horario mHorarioHoyActual = this.iBannerActual.GetHorarioHoy();
                    if (mHorarioHoyActual.HoraFin >= mHoraLocalActual)
                    {
                        if (mHorarioHoyActual.HoraInicio <= mHoraLocalActual)
                        {
                            double mIntervaloBanner = (mHorarioHoyActual.HoraFin - mHoraLocalActual).TotalMilliseconds;
                            if (iBannerSiguiente != null && iBannerSiguiente.GetHorarioHoy() != null)
                            {
                                //Obtenemos el horario del día de hoy del banner siguiente
                                Horario mHorarioHoySiguiente = this.iBannerSiguiente.GetHorarioHoy();
                                //Sí los banners se superponen, se mostrará el posterior cuando sea su tiempo de iniciar
                                //aunque el anterior no haya terminado
                                double mOpcion2 = (mHorarioHoySiguiente.HoraInicio - mHoraLocalActual).TotalMilliseconds;
                                //Se selecciona el menor de los dos intervalos de tiempo (si se superponen la opcion2 sera menor.
                                if (mOpcion2 > 0)
                                {
                                    mIntervaloBanner = Math.Min(mIntervaloBanner, mOpcion2);
                                }
                            }
                            //Asignamos el menor intervalo en milisegundos que durará el banner.
                            this.iTemporizadorBanner.Interval = mIntervaloBanner;
                            //Ponemos a correr el temporizador del banner.
                            this.iTemporizadorBanner.Start();
                            //Colocamos el banner.
                            Invoke(BannerDelegado, iBannerActual.Mostrar());
                            //Actualizar noticias del siguiente banner sí es de fuente externa.
                            ActualizarNoticiasBanner(iBannerSiguiente);
                        }
                        else
                        {
                            //Colocamos el banner por defecto
                            MostrarBannerPorDefecto();
                            //Colocamos un intervalo de tiempo hasta que sea el momento de iniciar del banner actual.
                            this.iTemporizadorBanner.Interval = (mHorarioHoyActual.HoraInicio - mHoraLocalActual).TotalMilliseconds;
                            this.iTemporizadorBanner.Start();
                        }
                    }
                    else
                    {
                        CambiarBanner();
                    }
                }
            }
            else
            {
                //Paramos los temporizadores
                this.iTemporizadorBanner.Stop();
                //Colocamos el banner por defecto
                MostrarBannerPorDefecto();
            }
        }

        /// <summary>
        /// Muestra una campaña por defecto para rellenar los tiempos vacíos.
        /// </summary>
        private void MostrarCampañaPorDefecto()
        {
            this.pbCampaña.Image = Properties.Resources.CampañaDefecto;
        }

        /// <summary>
        /// Muestra un banner por defecto para rellenar los tiempos vacíos.
        /// </summary>
        private void MostrarBannerPorDefecto()
        {
            this.Invoke(BannerDelegado, Properties.Resources.BannerDefecto);
        }


        /// <summary>
        /// Cambia a la siguiente imagen. Reinicia el ciclo si se finalizó la secuencia.
        /// </summary>
        private void CambiarImagen()
        {
            //Sí se pudo mover a la siguiente imagen
            if (this.iImagenesCampañaActual.MoveNext())
            {
                //Colocamos la imagen actual
                this.pbCampaña.Image = this.iImagenesCampañaActual.Current.Imagen;
                //Ponemos a correr el contador
                this.iTemporizadorImagen.Start();
            }
            else
            {
                //Reiniciamos el puntero al lugar previo a la primer imagen
                this.iImagenesCampañaActual.Reset();
                //Colocamos la primer imgaen
                this.CambiarImagen();
            }
        }

        /// <summary>
        /// Cambia al banner actual.
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
            this.iTemporizadorBanner.Dispose();
            this.iTemporizadorCampaña.Dispose();
            this.iTemporizadorImagen.Dispose();
        }

        /// <summary>
        /// Actualiza las noticias de un banner.
        /// </summary>
        /// <param name="iBannerSiguiente"></param>
        private void ActualizarNoticiasBanner(Banner pBanner)
        {
            if (pBanner != null && pBanner is RSSFeed)
            {
                string NoSePudoActualizarError = "No se pudo actualizar la fuente <<" + iBannerSiguiente.Nombre + ">>.\n";
                string SeUsaranLasNoticiasAlmacenadas = "\nSe utilizarán las noticias anteriormente almacenadas.";
                try
                {
                    ICollection<RSSItem> iItems = FachadaCapaVisual.LeerRSS(((RSSFeed)iBannerSiguiente).URL);
                    ((RSSFeed)iBannerSiguiente).UltimasNoticias.Clear();
                    foreach (RSSItem item in iItems)
                    {
                        ((RSSFeed)iBannerSiguiente).UltimasNoticias.Add(item);
                    }
                    FachadaCapaVisual.ActualizarBanner(iBannerSiguiente);
                }
                catch (Exception e)
                {
                    AutoClosingMessageBox.Show(NoSePudoActualizarError + e.Message + SeUsaranLasNoticiasAlmacenadas,
                                                "Error actualizando",
                                                5000);
                }
            }
        }
    }

    /// <summary>
    /// Caja de mensajes de cierre automático por temporizador.
    /// </summary>
    public class AutoClosingMessageBox
    {
        System.Threading.Timer _timeoutTimer;
        string _caption;
        AutoClosingMessageBox(string text, string caption, int timeout_milliseconds)
        {
            _caption = caption;
            _timeoutTimer = new System.Threading.Timer(OnTimerElapsed,
                null, timeout_milliseconds, System.Threading.Timeout.Infinite);
            using (_timeoutTimer)
                MessageBox.Show(text, caption);
        }
        public static void Show(string text, string caption, int timeout)
        {
            new AutoClosingMessageBox(text, caption, timeout);
        }
        void OnTimerElapsed(object state)
        {
            IntPtr mbWnd = FindWindow("#32770", _caption); // lpClassName is #32770 for MessageBox
            if (mbWnd != IntPtr.Zero)
                SendMessage(mbWnd, WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
            _timeoutTimer.Dispose();
        }
        const int WM_CLOSE = 0x0010;
        [System.Runtime.InteropServices.DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [System.Runtime.InteropServices.DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
        static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);
    }
}
