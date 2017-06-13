using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CapaEntidad
{
    /// <summary>
    /// Clase para determinar las frecuencias de los anuncios. Cada horario es un día de la semana y el rango de horas en que se mostrará.
    /// </summary>
    public class Horario
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int HorarioId { get; set; }

		public int refElementoCarteleriaId { get; set; }
		[ForeignKey	("refElementoCarteleriaId")]
		private ElementoCarteleria iElementoCarteleria { get; set; }

        //Propiedades
        /// <summary>
        /// Hora en que inicia el anuncio.
        /// </summary>
		[Required]
        public TimeSpan HoraInicio { get; set; }

        /// <summary>
        /// Hora en que finaliza el anuncio.
		/// </summary>
		[Required]
        public TimeSpan HoraFin { get; set; }

        /// <summary>
        /// Día en que se pasará el anuncio.
		/// </summary>
		[Required]
        public DayOfWeek DiaSemana { get; set; }

		public Horario ()
		{
			
		}

		/// <summary>
		/// Crea una nueva instancia de la clase Horario.
        /// </summary>
        /// <param name="pDia">Día en que se mostrará el anuncio.</param>
        /// <param name="pHoraInicio">Hora en la que inicia a mostrarse.</param>
        /// <param name="pHoraFin">Hora en la que finaliza de mostrarse.</param>
        public Horario(DayOfWeek pDia, TimeSpan pHoraInicio, TimeSpan pHoraFin)
        {
            DiaSemana = pDia;
            HoraInicio = pHoraInicio;
            HoraFin = pHoraFin;
        }

		/// <summary>
		/// Verifica que dos horarios no se superpongan. Devuelve verdadero si existe superposición.
		/// </summary>
		public Boolean Colisiona(Horario pHorario)
		{
			if (this.DiaSemana==pHorario.DiaSemana && this.HoraInicio<pHorario.HoraFin && this.HoraFin>pHorario.HoraInicio) {
				return true;
			}
			return false;
		}

        public override string ToString()
        {
            return this.DiaSemana + " de " + this.HoraInicio + " a " + this.HoraFin;
        }
    }
}
