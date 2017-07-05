using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CapaEntidad
{
	public class ElementoCarteleria : IComparable<ElementoCarteleria>
    {
        /// <summary>
        /// Identificador del objeto. Generado por la base de datos.
        /// </summary>
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public Int64 ElementoCarteleriaId { get; set; }

        /// <summary>
        /// Nombre del cartel
        /// </summary>
        [Required]
        public virtual string Nombre { get; set; } = null;
        
        /// <summary>
        /// Descripción del cartel
        /// </summary>
        [Required]
        public virtual string Descripcion { get; set; } = null;

        /// <summary>
        /// Fecha en que inicia a estar activo el cartel.
        /// </summary>
        [Required]
        public virtual DateTime FechaInicio { get; set; }

        /// <summary>
        /// Fecha en que finaliza su actividad.
        /// </summary>
        [Required]
        public virtual DateTime FechaFin { get; set; }

        /// <summary>
        /// Días y horas en que se debe mostrar durante la semana.
        /// Para más información véase <see cref="Horario"/>
        /// </summary>
        [Required]
		public virtual ICollection<Horario> Frecuencia { get; set; }

        /// <summary>
        /// Campaña compuesta de imágenes que se mostrará.
        /// </summary>
        public virtual Campaña Campaña { get; set; } = null;

        /// <summary>
        /// Banner a mostrar. Puede ser texto plano o provenir de fuentes externas.
        /// </summary>
		public virtual Banner Banner { get; set; } = null;

        /// <summary>
        /// Inicializa una instancia de la clase <see cref="ElementoCarteleria"/>.
        /// </summary>
        public ElementoCarteleria ()
		{
			Frecuencia = new List<Horario>();
            FechaInicio = DateTime.Today;
            FechaFin = DateTime.Today;
        }

        /// <summary>
        /// Inicializa una instancia de la clase <see cref="ElementoCarteleria"/>.
        /// </summary>
		public ElementoCarteleria (String pNombre, String pDescripcion, DateTime pFechaInicio, DateTime pFechaFin,
			ICollection<Horario> pFrecuencia, Campaña pCampaña, Banner pBanner)
		{
			this.Nombre = pNombre;
			this.Descripcion = pDescripcion;
			this.FechaInicio = pFechaInicio;
			this.FechaFin = pFechaFin;
			this.Frecuencia = pFrecuencia;
			this.Campaña = pCampaña;
			this.Banner = pBanner;
		}

		/// <summary>
		/// Devuelve el horario a cumplir en el día de la fecha.
        /// Su funcional reside en los elementos que contienen un horario para el día de la fecha.
		/// </summary>
		public Horario GetHorarioHoy()
		{
            foreach (Horario horario in Frecuencia)
            {
                if (horario.DiaSemana == DateTime.Today.DayOfWeek)
                {
                    return horario;
                }
            }
            return null;
        }

        /// <summary>
        /// Devuelve el horario a cumplir en el día de la fecha.
        /// Su funcional reside en los elementos que contienen un horario para un día de la semana.
        /// </summary>
        public Horario GetHorarioDia(DayOfWeek pDia)
        {
            foreach (Horario horario in Frecuencia)
            {
                if (horario.DiaSemana == pDia)
                {
                    return horario;
                }
            }
            return null;
        }

        /// <summary>
        /// Responde sí en la lista de frecuencia existe un horario para un día de la semana
        /// </summary>
        public Boolean TieneDia(DayOfWeek pDia)
        {
            foreach (Horario horario in Frecuencia)
            {
                if (horario.DiaSemana == pDia)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Verifica sí el elemento se superpone en horarios con una colleción de horarios dada.
        /// </summary>
        /// <returns>true sí existe al menos una colisión.</returns>
        public Boolean Colisiona(ICollection<Horario> pHorariosExternos)
		{
			foreach (Horario mHorarioExterno in pHorariosExternos) {
				foreach (Horario mHorarioInterno in this.Frecuencia) {
					if (mHorarioExterno.Colisiona (mHorarioInterno)) {
						return true;
					}
				}
			}
			return false;
		}

		/// <summary>
		/// Devuelve los horarios de la campaña invocadora que colisionan con la colección de horarios dada.
		/// </summary>
		/// <param name="pCampaña">Campaña a contrastar.</param>
		public ICollection<Horario> Colisiones(ICollection<Horario> pHorariosExternos)
		{
			List<Horario> mColisiones = new List<Horario> ();
			foreach (Horario mHorarioExterno in this.Frecuencia) {
				foreach (Horario mHorarioInterno in this.Frecuencia) {
					if (mHorarioExterno.Colisiona (mHorarioInterno)) {
						mColisiones.Add (mHorarioInterno);
					}
				}
			}
			return mColisiones;
		}

        /// <summary>
        /// Implementacion de la interfaz IComparable.
        /// Permite el ordenamiento de elementos.
        /// </summary>
        public int CompareTo(ElementoCarteleria pOther)
        {
            if (pOther == this)
            {
                return 0;
            }
            //Si el otro elemento es nulo o no posee elemento para hoy, se considera pOther mayor
            else if (pOther == null || pOther.GetHorarioHoy() == null)
            {
                return -1;
            }
            //Sí este elemento es nulo, no tiene horario, o la hora de inicio mayor, se considera pOther menor
            else if (this == null || this.GetHorarioHoy() == null || pOther.GetHorarioHoy().HoraInicio < this.GetHorarioHoy().HoraInicio)
            {
                return +1;
            }
            //Sí este elemento tiene hora de inicio menor, se considera pOther mayor
            else if (pOther.GetHorarioHoy().HoraInicio > this.GetHorarioHoy().HoraInicio)
            {
                return -1;
            }
            //Otro caso, se consideran iguales.
            return 0;
        }
    }
}

