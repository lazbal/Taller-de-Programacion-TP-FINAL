using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidad;

namespace CapaVisual
{
    public partial class BuscarCampaña : CapaVisual.Buscar
    {
        private FachadaCapaVisual iFachada;

        public BuscarCampaña(FachadaCapaVisual pFachada)
        {
            InitializeComponent();
            iFachada = pFachada;
        }

        public void CargarDataGrid(IList<Campaña> pCampañas)
        {
            foreach (Campaña campaña in pCampañas)
            {
                string[] columna = new string[] { campaña.Nombre, campaña.Descripcion, campaña.CampañaId.ToString() };
                grillaBusqueda.Rows.Add(columna);
            }
        }

        private void grillaBusqueda_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            idElemento = (string)grillaBusqueda.CurrentRow.Cells["columnId"].Value;
            Campaña iCampaña = iFachada.BuscarCampaña(int.Parse(idElemento));
            NuevaCampaña ventCampaña = new NuevaCampaña(iCampaña);
            ventCampaña.ShowDialog();
            if (ventCampaña.DialogResult == DialogResult.OK)
            {
                iFachada.ActualizarCampaña(iCampaña);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            grillaBusqueda.Rows.Clear();
            grillaBusqueda.Refresh();
            IList<Campaña> iCampañas;
            if (String.IsNullOrWhiteSpace(cadenaBuscar.Text))
            {
                DialogResult result = MessageBox.Show("Desea mostrar todos los Banner Estáticos?", "Mensaje", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    iCampañas = iFachada.ObtenerCampañas();
                    this.CargarDataGrid(iCampañas);
                }
            }
            else
            {
                iCampañas = iFachada.BusquedaAproxCampaña(cadenaBuscar.Text);
                this.CargarDataGrid(iCampañas);
            }
        }
    }
}
