using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CapaEntidad;

namespace CapaVisual
{
    /// <summary>
    /// Selector de frecuencia con que se mostrará un anuncio.
    /// </summary>
    public partial class SeleccionarHorarios : Form
    {
        //Atributos.
        private List<Horario> iListaHorarios;
        
        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="pListaHorarios">Recibe una lista de horarios existente, sea para alta o modificación.</param>
        public SeleccionarHorarios(List<Horario> pListaHorarios)
        {
            InitializeComponent();
            iListaHorarios = pListaHorarios;
            //Sí la lista contiene elementos (es una modificación de horarios), éstos se cargarán en la ventana.
            foreach (Horario elem in iListaHorarios)
            {
                //Se usan los datos de la menor fecha.
                DateTime elemInicio = new DateTime(1753, 01, 01, elem.HoraInicio.Hours, elem.HoraInicio.Minutes, elem.HoraInicio.Seconds);
                DateTime elemFin = new DateTime(1753, 01, 01, elem.HoraFin.Hours, elem.HoraFin.Minutes, elem.HoraFin.Seconds);
                switch (elem.DiaSemana)
                {
                    case DayOfWeek.Monday:
                        {
                            cbLunes.Checked = true;
                            dtpLunesInicio.Value = elemInicio;
                            dtpLunesFin.Value = elemFin;
                            break;
                        }
                    case DayOfWeek.Tuesday:
                        {
                            cbMartes.Checked = true;
                            dtpMartesInicio.Value = elemInicio;
                            dtpMartesFin.Value = elemFin;
                            break;
                        }
                    case DayOfWeek.Wednesday:
                        {
                            cbMiercoles.Checked = true;
                            dtpMiercolesInicio.Value = elemInicio;
                            dtpMiercolesFin.Value = elemFin;
                            break;
                        }
                    case DayOfWeek.Thursday:
                        {
                            cbJueves.Checked = true;
                            dtpJuevesInicio.Value = elemInicio;
                            dtpJuevesFin.Value = elemFin;
                            break;
                        }
                    case DayOfWeek.Friday:
                        {
                            cbViernes.Checked = true;
                            dtpViernesInicio.Value = elemInicio;
                            dtpViernesFin.Value = elemFin;
                            break;
                        }
                    case DayOfWeek.Saturday:
                        {
                            cbSabado.Checked = true;
                            dtpSabadoInicio.Value = elemInicio;
                            dtpSabadoFin.Value = elemFin;
                            break;
                        }
                    case DayOfWeek.Sunday:
                        {
                            cbDomingo.Checked = true;
                            dtpDomingoInicio.Value = elemInicio;
                            dtpDomingoFin.Value = elemFin;
                            break;
                        }
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// Se ha marcado el Lunes como día para mostrar el anuncio, y se habilitan sus horarios para ser definidos.
        /// </summary>
        private void cbLunes_CheckedChanged(object sender, EventArgs e)
        {
            this.dtpLunesInicio.Visible = this.cbLunes.Checked;
            this.dtpLunesFin.Visible = this.cbLunes.Checked;
        }

        /// <summary>
        /// Se ha marcado el Martes como día para mostrar el anuncio, y se habilitan sus horarios para ser definidos.
        /// </summary>
        private void cbMartes_CheckedChanged(object sender, EventArgs e)
        {
            this.dtpMartesInicio.Visible = this.cbMartes.Checked;
            this.dtpMartesFin.Visible = this.cbMartes.Checked;
        }

        /// <summary>
        /// Se ha marcado el Miércoles como día para mostrar el anuncio, y se habilitan sus horarios para ser definidos.
        /// </summary>
        private void cbMiercoles_CheckedChanged(object sender, EventArgs e)
        {
           this. dtpMiercolesInicio.Visible = this.cbMiercoles.Checked;
           this.dtpMiercolesFin.Visible = this.cbMiercoles.Checked;
        }

        /// <summary>
        /// Se ha marcado el Jueves como día para mostrar el anuncio, y se habilitan sus horarios para ser definidos.
        /// </summary>
        private void cbJueves_CheckedChanged(object sender, EventArgs e)
        {
            this.dtpJuevesInicio.Visible = this.cbJueves.Checked;
            this.dtpJuevesFin.Visible = this.cbJueves.Checked;
        }

        /// <summary>
        /// Se ha marcado el Viernes como día para mostrar el anuncio, y se habilitan sus horarios para ser definidos.
        /// </summary>
        private void cbViernes_CheckedChanged(object sender, EventArgs e)
        {
            this.dtpViernesInicio.Visible = this.cbViernes.Checked;
            this.dtpViernesFin.Visible = this.cbViernes.Checked;
        }

        /// <summary>
        /// Se ha marcado el Sábado como día para mostrar el anuncio, y se habilitan sus horarios para ser definidos.
        /// </summary>
        private void cbSabado_CheckedChanged(object sender, EventArgs e)
        {
            this.dtpSabadoInicio.Visible = this.cbSabado.Checked; ;
            this.dtpSabadoFin.Visible = this.cbSabado.Checked;
        }

        /// <summary>
        /// Se ha marcado el Domingo como día para mostrar el anuncio, y se habilitan sus horarios para ser definidos.
        /// </summary>
        private void cbDomingo_CheckedChanged(object sender, EventArgs e)
        {
            this.dtpDomingoInicio.Visible = this.cbDomingo.Checked; ;
            this.dtpDomingoFin.Visible = this.cbDomingo.Checked; ;
        }

        /// <summary>
        /// Se aceptaron los cambios en los horarios.
        /// </summary>
        private void bAceptar_Click(object sender, EventArgs e)
        {
            this.iListaHorarios.Clear();
        //Se controla qué dia está seleccionado y se lo agrega a la lista de horarios, junto con las horas seleccionadas para inicio y fin del anuncio.
        //Cada if corresponde a un dia de la semana
            if (cbLunes.Checked)
            {
				if (((dtpLunesInicio.Value.Hour < dtpLunesFin.Value.Hour) || ((dtpLunesInicio.Value.Hour == dtpLunesFin.Value.Hour) && (dtpLunesInicio.Value.Minute <= dtpLunesFin.Value.Minute))))
                {
                    iListaHorarios.Add(new Horario(
                                                    DayOfWeek.Monday,
                                                    new TimeSpan(dtpLunesInicio.Value.Hour, dtpLunesInicio.Value.Minute, 0),
                                                    new TimeSpan(dtpLunesFin.Value.Hour, dtpLunesFin.Value.Minute, 0)
                                                  )
                                       );
                }
                else 
                {
                    throw new ArgumentOutOfRangeException("En Lunes la hora de inicio es posterior a la de fin.");
                }
            }
            else
            {
                iListaHorarios.RemoveAll(horario => horario.DiaSemana == DayOfWeek.Monday);
            }
            if (cbMartes.Checked)
            {
				if (((dtpMartesInicio.Value.Hour < dtpMartesFin.Value.Hour) || ((dtpMartesInicio.Value.Hour == dtpMartesFin.Value.Hour) && (dtpMartesInicio.Value.Minute <= dtpMartesFin.Value.Minute))))
                {
                    iListaHorarios.Add(new Horario(
                                                DayOfWeek.Tuesday,
                                                new TimeSpan(dtpMartesInicio.Value.Hour, dtpMartesInicio.Value.Minute, 0),
                                                new TimeSpan(dtpMartesFin.Value.Hour, dtpMartesFin.Value.Minute, 0)
                                              )
                                   );
                }
                else
                {
                    throw new ArgumentOutOfRangeException("En Martes la hora de inicio es posterior a la de fin.");
                }
            }
            else
            {
                iListaHorarios.RemoveAll(horario => horario.DiaSemana == DayOfWeek.Tuesday);
            }
            if (cbMiercoles.Checked)
            {
				if (((dtpMiercolesInicio.Value.Hour < dtpMiercolesFin.Value.Hour) || ((dtpMiercolesInicio.Value.Hour == dtpMiercolesFin.Value.Hour) && (dtpMiercolesInicio.Value.Minute <= dtpMiercolesFin.Value.Minute))))
                {
                    iListaHorarios.Add(new Horario(
                                                DayOfWeek.Wednesday,
                                                new TimeSpan(dtpMiercolesInicio.Value.Hour, dtpMiercolesInicio.Value.Minute, 0),
                                                new TimeSpan(dtpMiercolesFin.Value.Hour, dtpMiercolesFin.Value.Minute, 0)
                                              )
                                   );
                }
                else
                {
                    throw new ArgumentOutOfRangeException("En Miércoles la hora de inicio es posterior a la de fin.");
                }
            }
            else
            {
                iListaHorarios.RemoveAll(horario => horario.DiaSemana == DayOfWeek.Wednesday);
            }
            if (cbJueves.Checked)
            {
				if (((dtpJuevesInicio.Value.Hour < dtpJuevesFin.Value.Hour) || ((dtpJuevesInicio.Value.Hour == dtpJuevesFin.Value.Hour) && (dtpJuevesInicio.Value.Minute <= dtpJuevesFin.Value.Minute))))
                {
                    iListaHorarios.Add(new Horario(
                                                DayOfWeek.Thursday,
                                                new TimeSpan(dtpJuevesInicio.Value.Hour, dtpJuevesInicio.Value.Minute, 0),
                                                new TimeSpan(dtpJuevesFin.Value.Hour, dtpJuevesFin.Value.Minute, 0)
                                              )
                                   );
                }
                else
                {
                    throw new ArgumentOutOfRangeException("En Jueves la hora de inicio es posterior a la de fin.");
                }
            }
            else
            {
                iListaHorarios.RemoveAll(horario => horario.DiaSemana == DayOfWeek.Thursday);
            }
            if (cbViernes.Checked)
            {
				if (((dtpViernesInicio.Value.Hour < dtpViernesFin.Value.Hour) || ((dtpViernesInicio.Value.Hour == dtpViernesFin.Value.Hour) && (dtpViernesInicio.Value.Minute <= dtpViernesFin.Value.Minute))))
                {
                    iListaHorarios.Add(new Horario(
                                                DayOfWeek.Friday,
                                                new TimeSpan(dtpViernesInicio.Value.Hour, dtpViernesInicio.Value.Minute, 0),
                                                new TimeSpan(dtpViernesFin.Value.Hour, dtpViernesFin.Value.Minute, 0)
                                              )
                                   );
                }
                else
                {
                    throw new ArgumentOutOfRangeException("En Viernes la hora de inicio es posterior a la de fin.");
                }
            }
            else
            {
                iListaHorarios.RemoveAll(horario => horario.DiaSemana == DayOfWeek.Friday);
            }
            if (cbSabado.Checked)
            {
				if (((dtpSabadoInicio.Value.Hour < dtpSabadoFin.Value.Hour) || ((dtpSabadoInicio.Value.Hour == dtpSabadoFin.Value.Hour) && (dtpSabadoInicio.Value.Minute <= dtpSabadoFin.Value.Minute))))
                {
                    iListaHorarios.Add(new Horario(
                                                DayOfWeek.Saturday,
                                                new TimeSpan(dtpSabadoInicio.Value.Hour, dtpSabadoInicio.Value.Minute, 0),
                                                new TimeSpan(dtpSabadoFin.Value.Hour, dtpSabadoFin.Value.Minute, 0)
                                              )
                                   );
                }
                else
                {
                    throw new ArgumentOutOfRangeException("En Sábado la hora de inicio es posterior a la de fin.");
                }
            }
            else
            {
                iListaHorarios.RemoveAll(horario => horario.DiaSemana == DayOfWeek.Saturday);
            }
            if (cbDomingo.Checked)
            {
				if (((dtpDomingoInicio.Value.Hour < dtpDomingoFin.Value.Hour) || ((dtpDomingoInicio.Value.Hour == dtpDomingoFin.Value.Hour) && (dtpDomingoInicio.Value.Minute <= dtpDomingoFin.Value.Minute))))
                {
                    iListaHorarios.Add(new Horario(
                                                DayOfWeek.Sunday,
                                                new TimeSpan(dtpDomingoInicio.Value.Hour, dtpDomingoInicio.Value.Minute, 0),
                                                new TimeSpan(dtpDomingoFin.Value.Hour, dtpDomingoFin.Value.Minute, 0)
                                              )
                                   );
                }
                else
                {
                    throw new ArgumentOutOfRangeException("En Domingo la hora de inicio es posterior a la de fin.");
                }
            }
            else
            {
                iListaHorarios.RemoveAll(horario => horario.DiaSemana == DayOfWeek.Sunday);
            }
            //Cerrar ventana.
            this.Close();
        }
    }
}
