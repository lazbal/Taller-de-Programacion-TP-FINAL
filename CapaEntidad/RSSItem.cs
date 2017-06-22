using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CapaEntidad
{
    /// <summary>
    /// Ítem RSS que contiene la noticia a mostrar.
    /// </summary>
    public class RSSItem
    {
        /// <summary>
        /// Identificador del objeto. Generado por la base de datos.
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public Int64 RSSItemId { get; set; }
        
        /// <summary>
        /// Clave foránea. Identifica la fuente RSS padre.
        /// </summary>
        public Int64 refRSSFeed { get; set; }
        [ForeignKey("refRSSFeed")]
        private RSSFeed iRSSFeed { get; set; }

        /// <summary>
        /// Inicializa una instancia de la clase <see cref="RSSItem"/>.
        /// </summary>
		public RSSItem ()
		{
			
		}

        /// <summary>
        /// Título de la noticia.
        /// </summary>
        public string Titulo { get; set; }

        /// <summary>
        /// Cuerpo de la noticia.
        /// </summary>
        public string Cuerpo { get; set; }

		/// <summary>
		/// Obtiene la cadena a mostrar para ésta noticia.
		/// </summary>
		/// <returns>La cadena.</returns>
        public string ObtenerCadena ()
        {
            return String.Format("{0} - {1}",this.Titulo,this.Cuerpo);
        }

    }
}
