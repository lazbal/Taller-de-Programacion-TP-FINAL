using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using CapaEntidad;
using CapaDatos;

namespace CapaNegocio
{
	/// <summary>
	/// Controlador de Banners.
	/// </summary>
    public static class ControladorBanners
    {
        #region Lectura de RSSFeed
        /// <summary>
        /// Obtener los ítems o noticias de una fuente RSS desde su URL.
        /// </summary>
        /// <param name="pUrl">URL de la fuente RSS</param>
        /// <returns>Noticias obtenidas de la fuente.</returns>
        public static ICollection<RSSItem> LeerRSS(String pURL)
        {
            return ControladorBanners.LeerRSS(new Uri(pURL));
        }
        /// <summary>
        /// Obtener los ítems o noticias de una fuente RSS desde su URL.
        /// </summary>
        /// <param name="pUrl">URL de la fuente RSS</param>
        /// <returns>Noticias obtenidas de la fuente.</returns>
        public static ICollection<RSSItem> LeerRSS(Uri pURL)
        {
            //Se crea un lector RSS.
            SyndicationFeedRSSReader mRSSReader = new SyndicationFeedRSSReader();
            //Se le pide que lea la URL y devuelve una lista de items RSSItem.
            return mRSSReader.Read(pURL);
        }
        #endregion
        #region Banners
        /// <summary>
        /// Crea una entrada de <typeparamref name="Banner"/>.
        /// </summary>
        /// <param name="pBanner">Objeto a insertar.</param>
        public static void AgregarBanner(Banner pBanner)
        {
            CapaDatosFachada.GetInstancia().Create(pBanner);
        }

        /// <summary>
        /// Actualiza una entrada.
        /// </summary>
        /// <param name="pCamapaña">Objeto actualizado.</param>
        public static void ActualizarBanner(Banner pBanner)
        {
            CapaDatosFachada.GetInstancia().Update(pBanner);
        }

        /// <summary>
        /// Elimina un banner por su identificador
        /// </summary>
        /// <param name="pID">Identificador del objeto a eliminar</param>
        public static void EliminarBanner(Int64 pID)
        {
            CapaDatosFachada.GetInstancia().Delete(CapaDatosFachada.GetInstancia().GetByIdBanner(pID));
        }

        /// <summary>
        /// Elimina un banner
        /// </summary>
        /// <param name="pBanner">Objeto a eliminar</param>
        public static void EliminarBanner(Banner pBanner)
        {
            CapaDatosFachada.GetInstancia().Delete(pBanner);
        }

        /// <summary>
        /// Elimina una entrada.
        /// </summary>
        /// <param name="pBannerID">Id del objeto a eliminar.</param>
        public static Banner BuscarBanner(Int64 pId)
        {
            return CapaDatosFachada.GetInstancia().GetByIdBanner(pId);
        }

        /// <summary>
        /// Busca una entrada.
        /// </summary>
        /// <param name="pBanner">Objeto a Buscar.</param>
        public static ICollection<Banner> BusquedaAproxBanner(string pNombre)
        {
            return CapaDatosFachada.GetInstancia().BusquedaAproximacionBanner(pNombre);
        }

        /// <summary>
        /// Obtener todos los banners existentes.
        /// </summary>
        public static ICollection<Banner> GetAllBanners()
        {
            return CapaDatosFachada.GetInstancia().GetAllBanners();
        }

        /// <summary>
        /// Obtener todos los banners existentes, entre dos fechas.
        /// </summary>
        /// <param name="pFechaInicio">Fecha inicial en la que debe estar contenida el cartel.</param>
        /// <param name="pFechaFin">Fecha final en la que debe estar contenida el cartel.</param>
        /// <returns></returns>
        public static ICollection<Banner> GetAllBannersEntre(DateTime pFechaInicio, DateTime pFechaFin)
        {
            return CapaDatosFachada.GetInstancia().GetAllBannersEntre(pFechaInicio, pFechaFin);
        }

        /// <summary>
        /// Obtener los banners existentes para el día de la fecha.
        /// </summary>
        /// <returns></returns>
        public static ICollection<Banner> BannersHoy()
        {
            ICollection<Banner> mBannersHoy = new List<Banner>();
            foreach (Banner mB in CapaDatosFachada.GetInstancia().GetBannersHoy())
            {
                if (mB.GetHorarioHoy() != null)
                {
                    mBannersHoy.Add(mB);
                }
            }
            return mBannersHoy;
        }

        /// <summary>
        /// Para los banner que provengan de una fuente externa.
        /// Se actualizan las noticias de las fuentes externas.
        /// </summary>
        public static void ActualizarNoticias(ICollection<Banner> pBanners)
        {
            foreach (Banner mBanners in pBanners)
            {
                try
                {
                    // not null nor other type but rssfeed
                    if (mBanners is RSSFeed)
                    {
                        RSSFeed mRSSFeed = mBanners as RSSFeed;
                        mRSSFeed.UltimasNoticias = LeerRSS(mRSSFeed.URL);
                    }
                }
                catch (WebException)
                {

                }
            }
        }
        #endregion
    }
}
