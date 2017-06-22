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
		public string Texto { get; set; }

        /// <summary>
        /// Inicializa una instancia de la clase <see cref="BannerEstatico"/>.
        /// </summary>
		public BannerEstatico() : base() { }

        /// <summary>
        /// Inicializa una instancia de la clase <see cref="BannerEstatico"/>.
        /// </summary>
        /// <param name="pTexto">Texto del banner.</param>
		public BannerEstatico (string pTexto) : base()
		{
            this.Texto = pTexto;
		}

		/// <summary>
		/// Texto a mostrar del banner.
		/// </summary>
		public override string Mostrar()
		{
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
