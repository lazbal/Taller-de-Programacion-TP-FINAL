using System.Windows.Forms;
using CapaEntidad;

namespace CapaVisual
{
    public partial class AdminCarteleria : Form
    {
        FachadaCapaVisual iFachada;
        
        public AdminCarteleria(FachadaCapaVisual pFachada)
        {
            InitializeComponent();
            iFachada = pFachada;
        }

        private void btnNuevoElemento_Click(object sender, System.EventArgs e)
        {
            this.Hide();
            NuevoElementoCarteleria iNuevoElemento = new NuevoElementoCarteleria(new ElementoCarteleria(), iFachada);
            iNuevoElemento.ShowDialog();
            this.Show();
        }

        private void btnPresentacion_Click(object sender, System.EventArgs e)
        {
            this.Hide();
            Presentacion iPresentacion = new Presentacion();
            iPresentacion.ShowDialog();
            this.Show();
        }

        private void btnListarCarteles_Click(object sender, System.EventArgs e)
        {
            this.Hide();
            Buscar iBuscador = new Buscar(iFachada);
            iBuscador.ShowDialog();
            this.Show();
        }
    }
}
