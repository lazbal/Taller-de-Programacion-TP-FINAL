using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CapaEntidad
{
    /// <summary>
    /// Clase para determinar las frecuencias de los anuncios.
    /// Cada horario es un día de la semana y el rango de horas en que se mostrará.
    /// </summary>
    public class Horario
    {
        /// <summary>
        /// Identificador del objeto. Generado por la base de datos.
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public Int64 HorarioId { get; set; }

        /// <summary>
        /// Clave foránea del elemento cartelería padre.
        /// </summary>
		public Int64 refElementoCarteleriaId { get; set; }
		[ForeignKey	("refElementoCarteleriaId")]
		private ElementoCarteleria iElementoCarteleria { get; set; }
        
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

        /// <summary>
        /// Inicializa una instancia de la clase <see cref="Horario"/>.
        /// </summary>
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

        /// <summary>
        /// Representación string del objeto.
        /// </summary>
        public override string ToString()
        {
            return this.DiaSemana + " de " + this.HoraInicio + " a " + this.HoraFin;
        }
    }
}
