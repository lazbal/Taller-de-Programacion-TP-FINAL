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
		[Key, ForeignKey("ElementoCarteleria")]
		public int refElementoCarteleriaId { get; set; }
		public virtual ElementoCarteleria ElementoCarteleria { get; set; }

        [Required]
		public virtual TimeSpan TiempoXImagen { get; set; }

        [Required]
		public virtual ICollection<ImagenCampaña> ListaImagenes { get; set; }

        /// <summary>
        /// Inicializa una instancia de la clase <see cref="CapaEntidad.Campaña"/>.
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

        public override string ToString()
        {
            return this.ListaImagenes.Count + " imágenes. " + this.TiempoXImagen.ToString() + " por imágen.";
        }
    }
}
