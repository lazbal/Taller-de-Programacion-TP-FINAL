using System.Windows.Forms;
using System.Linq;
using CapaEntidad;

namespace CapaVisual
{
    public partial class Buscar : Form
    {
        public string idElemento { get; set; }
        FachadaCapaVisual iFachada;

        public Buscar(FachadaCapaVisual pFachada)
        {
            InitializeComponent();
            iFachada = pFachada;
            grillaBusqueda.AutoGenerateColumns = true;
        }

        private void cadenaBuscar_TextChanged(object sender, System.EventArgs e)
        {
            grillaBusqueda.DataSource = this.iFachada.BusquedaAproxElementoCarteleria(cadenaBuscar.Text);
            grillaBusqueda.Columns.Remove("Frecuencia");
        }

        private void grillaBusqueda_DoubleClick(object sender, System.EventArgs e)
        {
            ElementoCarteleria elementoCarteleria = grillaBusqueda.CurrentRow.DataBoundItem as ElementoCarteleria;
            NuevoElementoCarteleria editarElemento = new NuevoElementoCarteleria(elementoCarteleria,iFachada);
            editarElemento.ShowDialog();
        }
    }
}
