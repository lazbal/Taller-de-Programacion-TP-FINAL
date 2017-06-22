using System.Windows.Forms;
using CapaEntidad;

namespace CapaVisual
{
    public partial class AdminCarteleria : Form
    {
        FachadaCapaVisual iFachada;

        /// <summary>
        /// Inicializa una instancia del objeto.
        /// </summary>
        /// <param name="pFachada"></param>
        public AdminCarteleria(FachadaCapaVisual pFachada)
        {
            InitializeComponent();
            iFachada = pFachada;
        }

        /// <summary>
        /// Abre el formulario para la creación de un nuevo cartel.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNuevoElemento_Click(object sender, System.EventArgs e)
        {
            this.Hide();
            NuevoElementoCarteleria iNuevoElemento = new NuevoElementoCarteleria(new ElementoCarteleria(), iFachada);
            iNuevoElemento.ShowDialog();
            this.Show();
        }

        /// <summary>
        /// Abre el formulario para iniciar la presentación de campañas.
        /// </summary>
        private void btnPresentacion_Click(object sender, System.EventArgs e)
        {
            Presentacion iPresentacion = new Presentacion(iFachada);
            iPresentacion.ShowDialog();
            this.Show();
        }

        /// <summary>
        /// Abre el formulario para la búsqueda y edición de carteles.
        /// </summary>
        private void btnListarCarteles_Click(object sender, System.EventArgs e)
        {
            this.Hide();
            Buscar iBuscador = new Buscar(iFachada);
            iBuscador.ShowDialog();
            this.Show();
        }
    }
}
