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
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public int RSSItemId { get; set; }
        
        public int refRSSFeed { get; set; }
        [ForeignKey("refRSSFeed")]
        private RSSFeed iRSSFeed { get; set; }

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
