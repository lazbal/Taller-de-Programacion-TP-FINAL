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
    public partial class BuscarBannerEst : Buscar
    {
        FachadaCapaVisual iFachada;
        public BuscarBannerEst(FachadaCapaVisual pFachada)
        {
            InitializeComponent();
            iFachada = pFachada;
        }

        public void CargarDataGrid(IList<BannerEstatico> pBannerEstatico)
        {
            foreach (BannerEstatico banner in pBannerEstatico)
            {
                string[] columna = new string[] { banner.Nombre, banner.Descripcion };
                grillaBusqueda.Rows.Add(columna);
            }
        }

        private void grillaBusqueda_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            idElemento = (string)grillaBusqueda.CurrentRow.Cells["columnId"].Value;
            BannerEstatico iBanner = iFachada.BuscarBannerEstatico(int.Parse(idElemento));
            NuevoBanner ventBanner = new NuevoBanner(iBanner);
            ventBanner.ShowDialog();
            if (ventBanner.DialogResult == DialogResult.OK)
            {
                iFachada.ActualizarBannerEstatico(iBanner);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            grillaBusqueda.Rows.Clear();
            grillaBusqueda.Refresh();
            IList<BannerEstatico> iBanners;
            if (String.IsNullOrWhiteSpace(cadenaBuscar.Text))
            {
                DialogResult result = MessageBox.Show("Desea mostrar todos los Banner Estáticos?", "Mensaje", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    iBanners = iFachada.ObtenerBannersEstaticos();
                    this.CargarDataGrid(iBanners);
                }
            }
            else
            {
                iBanners = iFachada.BusquedaAproxBannerEstatico(cadenaBuscar.Text);
                this.CargarDataGrid(iBanners);
            }
        }
    }
}
