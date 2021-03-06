﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CapaEntidad
{
    /// <summary>
    /// Especificación de la clase Banner. El contenido a mostrar proviene de una URL.
    /// </summary>
	public class RSSFeed : Banner
    {
        /// <summary>
        /// URL de la cual se obtienen las noticias.
        /// </summary>
        [Required]
        public string URL { get; set; } = "";

        /// <summary>
        /// Almacena las 20 últimas noticias obtenidas.
        /// </summary>
        [Required]
        public virtual ICollection<RSSItem> UltimasNoticias { get; set; }

        /// <summary>
        /// Inicializa una instancia de la clase <see cref="RSSFeed"/>.
        /// </summary>
        public RSSFeed() : base()
        {
            this.UltimasNoticias = new List<RSSItem>();
        }

        /// <summary>
        /// Inicializa una instancia de la clase <see cref="RSSFeed"/> a partir de un banner base.
        /// </summary>
        public RSSFeed(Banner pOtroBanner) : base()
        {
            Id = pOtroBanner.Id;
            Nombre = pOtroBanner.Nombre;
            Descripcion = pOtroBanner.Descripcion;
            FechaInicio = pOtroBanner.FechaInicio;
            FechaFin = pOtroBanner.FechaInicio;
            Frecuencia = pOtroBanner.Frecuencia;

            this.UltimasNoticias = new List<RSSItem>();
        }

        /// <summary>
        /// Inicializa una instancia de la clase <see cref="RSSFeed"/>.
        /// </summary>
        /// <param name="pURL">URL fuente</param>
        public RSSFeed(String pURL) : base()
		{
            if (pURL != null)
			    this.URL = pURL;
			this.UltimasNoticias = new List<RSSItem> ();
		}

		/// <summary>
		/// Constructor de la clase RSSFeed.
		/// </summary>
		public RSSFeed (String pURL, ICollection<RSSItem> pNoticias)
        {
            if (pURL != null)
                this.URL = pURL;
            this.UltimasNoticias = pNoticias;
		}

		/// <summary>
		/// Texto a mostrar del banner. Union de los items en últimas noticias.
		/// </summary>
		public override string Mostrar()
		{
			String union = "";
            if (UltimasNoticias != null)
            {
                foreach (var rssItem in UltimasNoticias)
                {
                    union += (rssItem.ObtenerCadena() + " // ");
                }
            }
			return union;
        }

        /// <summary>
        /// Representación string del objeto.
        /// </summary>
        public override string ToString()
        {
            return URL;
        }
    }
}
