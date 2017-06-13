using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using CapaDatos;
using System.Net;

namespace CapaNegocio
{
    public class ControladorNegocio
    {
        //Propiedades
        /// <summary>
        /// Campañas del día a mostrar.
        /// </summary>
        public IEnumerable<Campaña> CampañasHoy { get; set; }

        /// <summary>
        /// Banners del día a mostrar.
        /// </summary>
        public IEnumerable<IBanner> BannersHoy { get; set; }

        //Constructor
        public ControladorNegocio()
        {

        }

        //Métodos
        /// <summary>
        /// Actualiza las noticias de los feeds RSS de la lista provista.
        /// </summary>
        public void ActualizarRSSFeed(IEnumerable<IBanner> pBanners)
        {
        ///FALTA BG WORKER
            //Creamos un lector de RSSFeeds.
            SyndicationFeedRssReader mReader = new SyndicationFeedRssReader();
            //Para cada banner en los banners de hoy.
            foreach (IBanner Banner in pBanners)
            {
                try
                {
                    //Que no sean estáticos.
                    if (Banner.Fuente() != null)
                    {
                        //Los tratamos como RSSFeed
                        RSSFeed mBanner = Banner as RSSFeed;
                        //Leemos las nuevas noticias.
                        IEnumerable<RssItem> mItemsNuevos = mReader.Read(mBanner.URL);
                        //Actualizamos su lista de noticias.
                        mBanner.ActualizarNoticias(mItemsNuevos);
                    }
                }
                //En caso de que no se pueda conectar con la fuente.
                catch (WebException)
                {
                    //Se saltea y se mostrará su lista de últimas noticias o actualizará en otro momento.
                }
            }
        }

        /// <summary>
        /// Actualiza los RSSFeeds que se requieren el día de hoy.
        /// </summary>
        public void ActualizarRSSFeedsHoy()
        {
            this.ActualizarRSSFeed(BannersHoy);
        }
    }
}
