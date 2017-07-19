using System;
using System.IO;
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
        /// <summary>
        /// Identificador del objeto. Generador por la base de datos.
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64 ImagenCampanaId { get; set; }

        /// <summary>
        /// Clave foránea. Identifica a la campaña padre.
        /// </summary>
		public virtual Int64 refCampanaId { get; set; }
		[ForeignKey("refCampanaId")]
		private Campaña iCampaña { get; set; }

        /// <summary>
        /// Ruta en disco del archivo imagen.
        /// </summary>
		[Required]
		private string iRuta;
        
        /// <summary>
        /// Conversión de la ruta en imágen.
        /// </summary>
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
                try
                {
                    if (value != null)
                    {
                        iRuta = value;
                        iImagen = Image.FromFile(iRuta);
                    }
                    else
                        throw new ArgumentNullException("La ruta de la imagen no puede ser nula");
                }
                catch (ArgumentNullException)
                {
                    throw;
                }
                catch (FileNotFoundException)
                {
                    throw;
                }
                catch (OutOfMemoryException)
                {
                    throw;
                }
                catch (ArgumentException)
                {
                    throw;
                }
            }
        }
			
		/// <summary>
		/// Imagen almacenada.
		/// </summary>
		public virtual Image Imagen { get { return iImagen; } }

        /// <summary>
        /// Inicializa una instancia de la clase <see cref="ImagenCampaña"/>.
        /// </summary>
		public ImagenCampaña ()
		{
			
		}

		/// <summary>
		/// Constructor de la clase ImagenCampaña.
		/// </summary>
		/// <param name="pRuta">Ruta de la imagen a almacenar.</param>
		public ImagenCampaña(string pRuta)
		{
            Ruta = pRuta;
		}
    }
}