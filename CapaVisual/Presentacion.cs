using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using CapaEntidad;

namespace CapaVisual
{
    public partial class Presentacion : Form
    {
        private FachadaCapaVisual iFachada;
        private ElementoCarteleria iCartelActual;
        private IEnumerator<ElementoCarteleria> iCartelesHoy;
        private IEnumerator<ImagenCampaña> iImagenesCartelActual;
        private System.Timers.Timer iTemporizadorCartel;
        private System.Timers.Timer iTemporizadorImagen;

        public Presentacion(FachadaCapaVisual pFachada)
        {
            InitializeComponent();
            this.iFachada = pFachada;
            this.iCartelesHoy = iFachada.ObtenerElementosCarteleria().GetEnumerator();
            iTemporizadorCartel = new System.Timers.Timer();
            this.iTemporizadorCartel.Elapsed += new System.Timers.ElapsedEventHandler(this.Cartel_Elapsed);
            iTemporizadorImagen = new System.Timers.Timer();
            this.iTemporizadorImagen.Elapsed += new System.Timers.ElapsedEventHandler(this.Imagen_Elapsed);
            this.Cartel_Elapsed(this, null);
        }

        private void Cartel_Elapsed(object sender, EventArgs e)
        {
            this.iTemporizadorCartel.Dispose();
            this.CambiarCartel();
        }

        private void Imagen_Elapsed(object sender, EventArgs e)
        {
            this.iTemporizadorImagen.Dispose();
            this.CambiarImagen();
        }

        private void CambiarCartel()
        {
            if (this.iCartelesHoy.MoveNext() && this.iCartelesHoy.Current != null)
            {
                this.iCartelActual = this.iCartelesHoy.Current;
                Horario mHorarioHoy = this.iCartelActual.GetHorarioHoy();
                if (mHorarioHoy != null)
                {
                    this.iTemporizadorCartel.Interval = (mHorarioHoy.HoraFin - mHorarioHoy.HoraInicio).TotalMinutes;
                }
                this.iImagenesCartelActual = this.iCartelActual.Campaña.ListaImagenes.GetEnumerator();
                this.iTemporizadorImagen.Interval = this.iCartelActual.Campaña.TiempoXImagen.TotalMinutes;
                this.iTemporizadorCartel.Start();
                this.CambiarImagen();
                this.tbBanner.Text = "Cartel: " + iCartelActual.Nombre +" Tiempo Cartel: " + iTemporizadorCartel.Interval.ToString() + "min. Tiempo Imagen: " + iTemporizadorImagen.Interval.ToString() + "min.";
            }
        }

        private void CambiarImagen()
        {
            if (this.iImagenesCartelActual.MoveNext())
            {
                this.pbCampaña.Image = this.iImagenesCartelActual.Current.Imagen;
                this.iTemporizadorImagen.Start();
            }
            else
            {
                this.iImagenesCartelActual.Reset();
                this.CambiarImagen();
            }
        }

        private void Presentacion_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.iTemporizadorCartel.Dispose();
            this.iTemporizadorImagen.Dispose();
        }
    }
}
