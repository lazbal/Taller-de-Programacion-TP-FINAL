using System;
using System.Windows.Forms;
using System.Linq;
using CapaEntidad;

namespace CapaVisual
{
    public partial class Buscar : Form
    {
        public string idElemento { get; set; }

        public Buscar()
        {
            InitializeComponent();
            dgBusqueda.AutoGenerateColumns = true;
            this.ActiveControl = tbBuscar;
        }

        private void cadenaBuscar_TextChanged(object sender, System.EventArgs e)
        {
            dgBusqueda.DataSource = FachadaCapaVisual.BusquedaAproxElementoCarteleria(tbBuscar.Text);
            dgBusqueda.Columns.Remove("Frecuencia");
        }

        private void grillaBusqueda_DoubleClick(object sender, System.EventArgs e)
        {
            ElementoCarteleria elementoCarteleria = dgBusqueda.CurrentRow.DataBoundItem as ElementoCarteleria;
            NuevoElementoCarteleria editarElemento = new NuevoElementoCarteleria(elementoCarteleria,true);
            editarElemento.ShowDialog();
        }

        private void dgBusqueda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete && this.dgBusqueda.SelectedRows != null)
            {
                DataGridViewRow mSelectedRow = this.dgBusqueda.SelectedRows[0];
                DialogResult result = MessageBox.Show("¿Está seguro que desea eliminar el cartel "+ mSelectedRow.Cells[2].Value.ToString()+"?", "Advertencia", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    FachadaCapaVisual.EliminarElementoCarteleria((Int64)mSelectedRow.Cells[1].Value);
                    cadenaBuscar_TextChanged(this, null);
                    MessageBox.Show("Eliminación realizada con éxito");
                }
            }
        }
    }
}
