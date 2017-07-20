using System;
using System.Collections.Generic;
using CapaEntidad;

namespace CapaNegocio
{
    /// <summary>
    /// Implementación de base del lector de RSS.
    /// </summary>
    public abstract class RSSReader : IRSSReader
    {
        /// <summary>
        /// Método de lectura de la fuente RSS.
        /// </summary>
        /// <param name="pUrl">URL de la fuente RSS.</param>
        /// <returns>Devuelve una colección de items <see cref="RSSItem"/>.</returns>
        /// <exception cref="UriFormatException"></exception>
        public ICollection<RSSItem> Read(String pUrl)
        {
            //Que la URL no esté vacía o compuesta por espacios.
            if (String.IsNullOrWhiteSpace(pUrl))
            {
                throw new ArgumentNullException("URL");
            }
            try 
            {
                //Llama al método que utiliza un objeto Uri.
                return this.Read(new Uri(pUrl));
            }
            catch (UriFormatException)
            {
                //Que el formato de la URL corresponda con el de una pagina web (http://example.com).
                throw new UriFormatException("El formato de la URL ingresada no es correcto.");
            }
        }

        /// <summary>
        /// Método abstacto a implementar para la lectura de una fuente RSS.
        /// </summary>
        /// <param name="pUrl">URL de la fuente en formato <see cref="Uri"/>.</param>
        /// <returns>Devuelve una colección de ítems <see cref="RSSItem"/>.</returns>
        public abstract ICollection<RSSItem> Read(Uri pUrl);

    }
}
