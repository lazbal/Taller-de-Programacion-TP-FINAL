using System;
using System.Windows.Forms;
using System.Linq;
using CapaEntidad;

namespace CapaVisual
{
    public partial class Buscar : Form
    {
        public string idElemento { get; set; }
        private Type iTipo;

        public Buscar(Type pTipo)
        {
            InitializeComponent();
            iTipo = pTipo;
            dgBusqueda.AutoGenerateColumns = true;
            this.ActiveControl = tbBuscar;
        }

        private void cadenaBuscar_TextChanged(object sender, System.EventArgs e)
        {
            if (iTipo == typeof(Campaña))
            {
                dgBusqueda.DataSource = FachadaCapaVisual.BusquedaAproxCampaña(tbBuscar.Text);
            }
            else if (iTipo == typeof(Banner))
            {
                dgBusqueda.DataSource = FachadaCapaVisual.BusquedaAproxBanner(tbBuscar.Text);
            }
            else
            {
                throw new ArgumentException("Este tipo no puede ser procesado para búsquedas");
            }
            dgBusqueda.Columns.Remove("Frecuencia");
        }

        private void grillaBusqueda_DoubleClick(object sender, System.EventArgs e)
        {
            if (dgBusqueda.CurrentRow != null)
            {
                if (iTipo == typeof(Campaña))
                {
                    Campaña campaña = dgBusqueda.CurrentRow.DataBoundItem as Campaña;
                    NuevoCampaña editarElemento = new NuevoCampaña(campaña, true);
                    editarElemento.ShowDialog();
                }
                else if (iTipo == typeof(Banner))
                {
                    Banner banner = dgBusqueda.CurrentRow.DataBoundItem as Banner;
                    NuevoBanner editarElemento = new NuevoBanner(banner, true);
                    editarElemento.ShowDialog();
                }
            }
        }

        private void dgBusqueda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete && this.dgBusqueda.SelectedRows != null)
            {
                DataGridViewRow mSelectedRow = this.dgBusqueda.SelectedRows[0];
                DialogResult result = MessageBox.Show("¿Está seguro que desea eliminar el elemento "+ mSelectedRow.Cells[2].Value.ToString()+"?", "Advertencia", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    if (iTipo == typeof(Campaña))
                    {
                        FachadaCapaVisual.EliminarCampaña((Int64)mSelectedRow.Cells[1].Value);
                    }
                    else if (iTipo == typeof(Banner))
                    {
                        FachadaCapaVisual.EliminarBanner((Int64)mSelectedRow.Cells[1].Value);
                    }
                    cadenaBuscar_TextChanged(this, null);
                    MessageBox.Show("Eliminación realizada con éxito");
                }
            }
        }
    }
}
