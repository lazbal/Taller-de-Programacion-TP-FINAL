using System;
using System.Collections.Generic;
using System.ServiceModel.Syndication;
using System.Xml;
using System.Net;
using CapaEntidad;

namespace CapaNegocio
{
    /// <summary>
    /// Implementación del lector de RSS basada en las clases de <see cref="System.ServiceModel.Syndication"/>.
    /// </summary>
    public class SyndicationFeedRSSReader : RSSReader
    {
        /// <summary>
        /// Implementación para leer una fuente RSS.
        /// </summary>
        /// <param name="pUrl">URL de la fuente en formato <see cref="Uri"/>.</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="WebException"></exception>
        /// <returns></returns>
        public override ICollection<RSSItem> Read(Uri pUrl)
        {
            //No puede ser nulo.
            if (pUrl == null)
            {
                throw new ArgumentNullException("URL");
            }
            try
            { 
                //Creamos un lector de archivos XML (los RSS estan en tal formato).
                XmlReader mReader = XmlReader.Create(pUrl.AbsoluteUri);
                //Leemos la fuente y la almacenamos en un feed (lista de ítems rss).
                SyndicationFeed mFeed = SyndicationFeed.Load(mReader);
                //Creamos una lista de RSSItem.
				ICollection<RSSItem> mRSSItems = new List<RSSItem>();

                //Para cada elemento en el feed, lo agregamos a la lista con los datos que nos interesan (título, cuerpo y fecha).
                foreach (SyndicationItem bItem in mFeed.Items)
                {
                    mRSSItems.Add(new RSSItem
                    {
                        Titulo = bItem.Title.Text,
                        Cuerpo = bItem.Summary.Text,
                    });
                }
                //Devolvemos la lista de items creada.
                return mRSSItems; 
            }
            catch(WebException)
            {
                //Hubo problemas para conectarse a la url.
                throw new WebException("No se ha podido acceder a la URL especificada. Verifique su conexión a internet y que la URL sea efectivamente de una fuente RSS.");
            }
        }

    }
}
