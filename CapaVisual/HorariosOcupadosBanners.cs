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
    public partial class HorariosOcupadosBanners : BannersHorariosOcupados
    {
        public HorariosOcupadosBanners (DateTime pFechaInicio, DateTime pFechaFin) : base()
        {
            InitializeComponent();
            GenerarGrilla(pFechaInicio, pFechaFin);
        }

        protected void GenerarGrilla(DateTime pFechaInicio, DateTime pFechaFin)
        {
            {
                ICollection<Banner> iElementos = FachadaCapaVisual.ObtenerBannersHoy();
                base.GenerarGrilla(iElementos, pFechaInicio, pFechaFin);
            }
        }
    }

    public class BannersHorariosOcupados : HorariosOcupados<Banner> { }
}
