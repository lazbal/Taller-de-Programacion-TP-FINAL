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

        /*protected void GenerarGrilla(DateTime pFechaInicio, DateTime pFechaFin)
        {
            {
                ICollection<Campaña> iElementos = FachadaCapaVisual.ObtenerCampañasHoy();
                //Iniciar el contador de fechas
                DateTime mFechaActual = pFechaInicio;
                //Para cada fecha
                while (mFechaActual <= pFechaFin)
                {
                    //Crear la fila en el datagrid y obtenemos el indice de fila creada
                    int mRow = this.dgHorariosOcupados.Rows.Add(mFechaActual.DayOfWeek.ToString() + ' ' + mFechaActual.ToShortDateString());
                    //Procedemos a llenar las celdas de esa fila
                    foreach (ElementoCarteleria mElemento in iElementos)
                    {

                        //Sí el elemento de cartelería corresponde a mostrarse ese día
                        if (mElemento.FechaInicio <= mFechaActual && mElemento.FechaFin >= pFechaFin && mElemento.TieneDia(mFechaActual.DayOfWeek))
                        {
                            //Obtengo el horario para ese día
                            Horario mHorario = mElemento.GetHorarioDia(mFechaActual.DayOfWeek);
                            //Traduzco la hora de inicio en un índice de columna (en tramos de a media hora, las horas se convierten en el doble y mas uno por la columna día)
                            int mColInicial = Convert.ToInt32(mHorario.HoraInicio.Hours * 2) + 1;
                            //Sí no es a la hora en punto, me situo en la siguiente celda
                            if (mHorario.HoraInicio.Minutes > 0)
                            {
                                mColInicial++;
                            }
                            //Repito con la hora final
                            int mColFinal = Convert.ToInt32(mHorario.HoraFin.Hours * 2) + 1;
                            if (mHorario.HoraFin.Minutes > 0)
                            {
                                mColFinal++;
                            }
                            //Para cada celda de la fila creada pinto la celda en el rango horario ocupado
                            for (int mColActual = mColInicial; mColActual <= mColFinal; mColActual++)
                            {
                                this.dgHorariosOcupados[mColActual, mRow].Style.BackColor = Color.Red;
                            }
                        }
                    }
                    //Fecha siguiente
                    mFechaActual = mFechaActual.AddDays(1);
                }
            }
        }*/
    }

    public class CampañaHorariosOcupados : HorariosOcupados<Campaña> { }
}
