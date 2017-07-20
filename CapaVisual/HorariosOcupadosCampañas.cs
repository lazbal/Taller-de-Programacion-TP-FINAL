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
    /// <summary>
    /// Especificación de <see cref="HorariosOcupados{T}"/>
    /// </summary>
    public partial class HorariosOcupadosCampañas : CampañaHorariosOcupados
    {
        public HorariosOcupadosCampañas(DateTime pFechaInicio, DateTime pFechaFin) : base()
        {
            InitializeComponent();
            GenerarGrilla(pFechaInicio, pFechaFin);
        }

        protected void GenerarGrilla(DateTime pFechaInicio, DateTime pFechaFin)
        {
            {
                ICollection<Campaña> iElementos = FachadaCapaVisual.ObtenerCampañasHoy();
                base.GenerarGrilla(iElementos, pFechaInicio, pFechaFin);
            }
        }
    }

    /// <summary>
    /// Clase dummy para engañar a VisualStudio y permita la generalización de forms.
    /// </summary>
    public class CampañaHorariosOcupados : HorariosOcupados<Campaña> { }
}
