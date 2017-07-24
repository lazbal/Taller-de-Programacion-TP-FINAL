using System;
using System.Collections.Generic;
using System.Linq;
using CapaEntidad;
using CapaNegocio;
using System.Net;

namespace CapaVisual
{
    public static class FachadaCapaVisual
    {
        public static DateTime FechaBaseHorarios()
        {
            //dd = Dia
            //MM = Mes (confundido con mm)
            //yyyy = Año en 4 dígitos
            return DateTime.ParseExact(@"01/01/1753", @"dd/MM/yyyy", null);
        }

        #region Banner
        /// <summary>
        /// Obtener los ítems o noticias de una fuente RSS desde su URL.
        /// </summary>
        /// <param name="pURL">URL de la fuente RSS</param>
        /// <returns>Noticias obtenidas desde la fuente RSS.</returns>
        public static ICollection<RSSItem> LeerRSS(string pURL)
        {
            return ControladorBanners.LeerRSS(pURL);
        }

        /// <summary>
        /// Crea una entrada de <typeparamref name="Banner"/>.
        /// </summary>
        /// <param name="pBanner">Objeto a insertar.</param>
        public static void AgregarBanner(Banner pBanner)
        {
            ControladorBanners.AgregarBanner(pBanner);
        }

        /// <summary>
        /// Actualiza una entrada de <typeparamref name="Banner"/>
        /// </summary>
        /// <param name="pBanner">Banner que se desea actualizar.</param>
        public static void ActualizarBanner(Banner pBanner)
        {
            ControladorBanners.ActualizarBanner(pBanner);
        }

        /// <summary>
        /// Obtiene todas las entradas de <typeparamref name="Banner"/>
        /// </summary>
        /// <returns>Todos las instancias de Banner.</returns>
        public static ICollection<Banner> ObtenerBanners()
        {
            return ControladorBanners.GetAllBanners();
        }

        /// <summary>
        /// Obtiene elementos de <typeparamref name="Banner"/> entre un rango de fechas.
        /// </summary>
        /// <param name="pFechaInicio">Fecha de inicio del rango de búsqueda.</param>
        /// <param name="pFechaFin">Fecha fin del rango de búsqueda.</param>
        /// <returns>Banners que estén comprendidos en las fechas de búsquedas.</returns>
        public static ICollection<Banner> ObtenerBannersEntre(DateTime pFechaInicio, DateTime pFechaFin)
        {
            return ControladorBanners.GetAllBannersEntre(pFechaInicio, pFechaFin);
        }

        /// <summary>
        /// Obtiene Banner del día.
        /// </summary>
        /// <returns>Banners que correspondan al día de la fecha.</returns>
        public static ICollection<Banner> ObtenerBannersHoy()
        {
            return ControladorBanners.BannersHoy();
        }

        /// <summary>
        /// Búsqueda de <typeparamref name="Banner"/> según su ID.
        /// </summary>
        /// <param name="pId">ID del Banner que se desea buscar.</param>
        /// <returns>Banner que correspondiente al ID.</returns>
        public static Banner BuscarBanner(Int64 pId)
        {
            return ControladorBanners.BuscarBanner(pId);
        }

        /// <summary>
        /// Busca una entrada de <typeparamref name="Banner"/> en donde su nombre o descripción coincida con una cadena de entrada.
        /// </summary>
        /// <param name="pCadena">Cadena de caracteres por la cual se va a buscar un Banner.</param>
        /// <returns>Banner que contengan como nombre o descripción la cadena de búsqueda.</returns>
        public static ICollection<Banner> BusquedaAproxBanner(string pCadena)
        {
            return ControladorBanners.BusquedaAproxBanner(pCadena);
        }

        /// <summary>
        /// Para los banner que provengan de una fuente externa, se actualizan las noticias de las fuentes externas.
        /// </summary>
        public static void ActualizarNoticiasHoy(ICollection<Banner> pBanners)
        {
            ControladorBanners.ActualizarNoticias(pBanners);
        }

        /// <summary>
        /// Elimina un banner por su identificador.
        /// </summary>
        /// <param name="pID">Identificador del Banner que se desea eliminar.</param>
        public static void EliminarBanner(Int64 pID)
        {
            ControladorBanners.EliminarBanner(pID);
        }
        #endregion
        #region Campaña
        /// <summary>
        /// Crea una entrada de <typeparamref name="Campaña"/>
        /// </summary>
        /// <param name="pCampaña">Campaña que se desea agregar.</param>
        public static void AgregarCampaña(Campaña pCampaña)
        {
            ControladorCampañas.AgregarCampaña(pCampaña);
        }

        /// <summary>
        /// Actualiza una entrada de <typeparamref name="Campaña"/>
        /// </summary>
        /// <param name="pCampaña">Campaña que se va a actualizar.</param>
        public static void ActualizarCampaña(Campaña pCampaña)
        {
            ControladorCampañas.ActualizarCampaña(pCampaña);
        }

        /// <summary>
        /// Obtiene todas las instancias de <typeparamref name="Campaña"/>
        /// </summary>
        /// <returns>Todas las campañas.</returns>
        public static ICollection<Campaña> ObtenerCampañas()
        {
            return ControladorCampañas.GetAllCampañas();
        }

        /// <summary>
        /// Obtiene las instancias de campañas entre un rango de fechas.
        /// </summary>
        /// <param name="pFechaInicio">Fecha de inicio del rango de búsqueda.</param>
        /// <param name="pFechaFin">Fecha de fin del rango de búsqueda.</param>
        /// <returns>Campañas que se encuentren dentro del rango de fechas.</returns>
        public static ICollection<Campaña> ObtenerCampañasEntre(DateTime pFechaInicio, DateTime pFechaFin)
        {
            return ControladorCampañas.GetAllCampañasEntre(pFechaInicio, pFechaFin);
        }

        /// <summary>
        /// Obtiene las campañas del día de la fecha.
        /// </summary>
        /// <returns>Campañas del día.</returns>
        public static ICollection<Campaña> ObtenerCampañasHoy()
        {
            return ControladorCampañas.CampañasHoy();
        }

        /// <summary>
        /// Busca una campaña según un ID.
        /// </summary>
        /// <param name="pId">ID de la campaña que se desea buscar.</param>
        /// <returns>Campaña correspondiente al ID.</returns>
        public static Campaña BuscarCampaña(Int64 pId)
        {
            return ControladorCampañas.BuscarCampaña(pId);
        }

        /// <summary>
        /// Busca campañas en donde su nombre o descripción contengan una cadena.
        /// </summary>
        /// <param name="pCadena">Cadena de búsqueda.</param>
        /// <returns>Campañas cuyo nombre o descricpión contengan la cadena de búsqueda.</returns>
        public static ICollection<Campaña> BusquedaAproxCampaña(string pCadena)
        {
            return ControladorCampañas.BusquedaAproxCampaña(pCadena);
        }

        /// <summary>
        /// Elimina una entrada de <typeparamref name="Campaña"/> según ID.
        /// </summary>
        /// <param name="pID">ID de la campaña a eliminar.</param>
        public static void EliminarCampaña(Int64 pID)
        {
            ControladorCampañas.EliminarCampaña(pID);
        }
        #endregion
    }
}
