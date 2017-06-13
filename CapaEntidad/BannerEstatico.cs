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
        /// Constructor de la clase BannerEstático.
        /// </summary>
		public BannerEstatico() : base() {}

        /// <summary>
        /// Constructor de la clase BannerEstático.
        /// </summary>
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
    }
}
