using System;
using System.Drawing;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;


namespace CapaEntidad
{
    /// <summary>
    /// Clase de datos de las imágenes utilizadas en las campañas.
    /// </summary>
    public class ImagenCampaña
    {
        //Atributos
        public int ImagenCampanaId { get; set; }

		public virtual int refCampanaId { get; set; }
		[ForeignKey("refCampanaId")]
		private Campaña iCampaña { get; set; }

		[Required]
		private string iRuta;
		private Image iImagen;

        //Propiedades
        /// <summary>
        /// Ruta en disco de la imagen.
        /// </summary>
        public string Ruta
        {
            get { return iRuta; }
            set
            {
                iRuta = value;
                iImagen = Image.FromFile(iRuta);
            }
        }
			
		/// <summary>
		/// Imagen almacenada.
		/// </summary>
		public virtual Image Imagen { get { return iImagen; } }

		public ImagenCampaña ()
		{
			
		}

		/// <summary>
		/// Constructor de la clase ImagenCampaña.
		/// </summary>
		/// <param name="pRuta">Ruta de la imagen a almacenar.</param>
		public ImagenCampaña(string pRuta)
		{
			iRuta = pRuta;
			iImagen = Image.FromFile(pRuta);
		}
    }
}