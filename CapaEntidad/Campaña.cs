using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CapaEntidad
{
    /// <summary>
    /// Clase de datos para campañas.
    /// </summary>
	public class Campaña
    {
        /// <summary>
        /// Clave foránea del elemento cartelería. Funciona como clave principal de la campaña.
        /// </summary>
		[Key, ForeignKey("ElementoCarteleria")]
		public Int64 refElementoCarteleriaId { get; set; }
		public virtual ElementoCarteleria ElementoCarteleria { get; set; }

        /// <summary>
        /// Tiempo que durará cada imágen hasta la siguiente.
        /// </summary>
        [Required]
		public virtual TimeSpan TiempoXImagen { get; set; }

        /// <summary>
        /// Colección de imagenes a mostrar en la campaña.
        /// </summary>
        [Required]
		public virtual ICollection<ImagenCampaña> ListaImagenes { get; set; }

        /// <summary>
        /// Inicializa una instancia de la clase <see cref="Campaña"/>.
        /// </summary>
		public Campaña()
		{
			ListaImagenes = new List<ImagenCampaña>();
		}

        /// <summary>
        /// Método para agregar imágenes a una campaña. Obteniendo como parámetro la ruta a la imágen a agregar.
        /// </summary>
        /// <param name="pRuta">Ruta en disco a la imagen.</param>
        public void AgregarImagen(string pRuta)
		{
			this.ListaImagenes.Add (new ImagenCampaña (pRuta));
		}

        /// <summary>
        /// Representación string de la clase.
        /// </summary>
        public override string ToString()
        {
            return this.ListaImagenes.Count + " imágenes. " + this.TiempoXImagen.ToString() + " por imágen.";
        }
    }
}
