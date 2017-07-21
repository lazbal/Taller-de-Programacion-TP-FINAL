using System.Windows.Forms;
using CapaEntidad;

namespace CapaVisual
{
    public partial class AdminCarteleria : Form
    {
        /// <summary>
        /// Inicializa una instancia del objeto.
        /// </summary>
        /// <param name="pFachada"></param>
        public AdminCarteleria()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Abre el formulario para iniciar la presentación de campañas.
        /// </summary>
        private void btnPresentacion_Click(object sender, System.EventArgs e)
        {
            Presentacion iPresentacion = new Presentacion();
            iPresentacion.Show();
            this.Show();
        }

        /// <summary>
        /// Abre el formulario para la creación de una nueva campaña.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNuevaCampaña_Click(object sender, System.EventArgs e)
        {
            this.Hide();
            NuevoCampaña iNuevoElemento = new NuevoCampaña(new Campaña());
            iNuevoElemento.ShowDialog();
            this.Show();
        }

        /// <summary>
        /// Abre el formulario para la búsqueda y edición de carteles.
        /// </summary>
        private void btnListarCampañas_Click(object sender, System.EventArgs e)
        {
            this.Hide();
            Buscar iBuscador = new Buscar(typeof(Campaña));
            iBuscador.ShowDialog();
            this.Show();
        }

        private void btnNuevoBanner_Click(object sender, System.EventArgs e)
        {
            this.Hide();
            NuevoBanner iNuevoElemento = new NuevoBanner(new BannerEstatico());
            iNuevoElemento.ShowDialog();
            this.Show();
        }

        private void btnListarBanners_Click(object sender, System.EventArgs e)
        {
            this.Hide();
            Buscar iBuscador = new Buscar(typeof(Banner));
            iBuscador.ShowDialog();
            this.Show();
        }
    }
}
