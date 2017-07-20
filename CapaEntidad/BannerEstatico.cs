using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CapaEntidad
{
    /// <summary>
    /// Especificación de la clase Banner. El contenido a mostrar está implícito en la clase.
    /// </summary>
    public class BannerEstatico : Banner
    {
        /// <summary>
        /// Texto a mostrar del banner.
        /// </summary>
		[Required]
        public string Texto { get; set; } = "";

        /// <summary>
        /// Inicializa una instancia de la clase <see cref="BannerEstatico"/>.
        /// </summary>
		public BannerEstatico() { }

        /// <summary>
        /// Inicializa una instancia de la clase <see cref="BannerEstatico"/> a partir de otro banner base.
        /// </summary>
		public BannerEstatico(Banner pOtroBanner) : base()
        {
            Id = pOtroBanner.Id;
            Nombre = pOtroBanner.Nombre;
            Descripcion = pOtroBanner.Descripcion;
            FechaInicio = pOtroBanner.FechaInicio;
            FechaFin = pOtroBanner.FechaInicio;
            Frecuencia = pOtroBanner.Frecuencia;
        }

        /// <summary>
        /// Inicializa una instancia de la clase <see cref="BannerEstatico"/>.
        /// </summary>
        /// <param name="pTexto">Texto del banner.</param>
        public BannerEstatico (string pTexto)
		{
            this.Texto = pTexto;
		}

		/// <summary>
		/// Texto a mostrar del banner.
		/// </summary>
		public override string Mostrar()
		{
            if (Texto == null)
            {
                Texto = "";
            }
			return Texto;
        }

        /// <summary>
        /// Representación string del objeto.
        /// </summary>
        public override string ToString()
        {
            return Mostrar();
        }
    }
}
