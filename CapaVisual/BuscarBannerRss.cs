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
    public partial class BuscarBannerRss : Buscar
    {
        FachadaCapaVisual iFachada;

        public BuscarBannerRss(FachadaCapaVisual pFachada)
        {
            InitializeComponent();
            iFachada = pFachada;
        }

        public void CargarDataGrid(IList<RSSFeed> pBannerRss)
        {
            foreach (RSSFeed banner in pBannerRss)
            {
                string[] columna = new string[] { banner.Nombre, banner.Descripcion, banner.RSSFeedId.ToString() };
                grillaBusqueda.Rows.Add(columna);
            }
        }

        private void grillaBusqueda_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            idElemento = (string)grillaBusqueda.CurrentRow.Cells["columnId"].Value;
            RSSFeed iBanner = iFachada.BuscarRssFeed(int.Parse(idElemento));
            NuevoBanner ventBanner = new NuevoBanner(iBanner, iFachada);
            ventBanner.ShowDialog();
            if (ventBanner.DialogResult == DialogResult.OK)
            {
                iFachada.ActualizarRssFeed(iBanner);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            grillaBusqueda.Rows.Clear();
            grillaBusqueda.Refresh();
            IList<RSSFeed> iBanners;
            if (String.IsNullOrWhiteSpace(cadenaBuscar.Text))
            {
                DialogResult result = MessageBox.Show("Desea mostrar todos los Banner Estáticos?", "Mensaje", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    iBanners = iFachada.ObtenerRssFeed();
                    this.CargarDataGrid(iBanners);
                }
            }
            else
            {
                iBanners = iFachada.BusquedaAproxBannerRss(cadenaBuscar.Text);
                this.CargarDataGrid(iBanners);
            }
        }
    }
}
