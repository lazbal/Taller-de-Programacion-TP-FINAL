using System;
using System.Collections.Generic;
using CapaEntidad;

namespace CapaNegocio
{
	/// <summary>
	/// Interfaz de la capa de negocio, con todos los mensajes que deben proveerse.
	/// </summary>
    public interface IFachadaCapaNegocio
    {
        #region Leer RSSFeed
        /// <summary>
        /// Obtener los ítems o noticias de una fuente RSS desde su URL.
        /// </summary>
        /// <param name="pUrl">URL de la fuente RSS</param>
        /// <returns>Noticias obtenidas de la fuente.</returns>
        ICollection<RSSItem> LeerRSS(string pURL);
        #endregion
        #region Elementos Cartelería
        /// <summary>
        /// Agregar un Elemento Cartelería
        /// </summary>
        /// <param name="pElementoCarteleria">Elemento Carteleria a agregar.</param>
        void AgregarElementoCarteleria(ElementoCarteleria pElementoCarteleria);
        /// <summary>
        /// Actualizar un Elemento Cartelería
        /// </summary>
        /// <param name="pElementoCarteleria">Elemento Carteleria a actualizar.</param>
        void ActualizarElementoCarteleria(ElementoCarteleria pElementoCarteleria);
        /// <summary>
        /// Obtener un Elemento Cartelería por su Id.
        /// </summary>
        /// <param name="pId">Identificador.</param>
        ElementoCarteleria BuscarElementoCarteleria(int pId);
        /// <summary>
        /// Buscar ElementosCarteleria estáticos por nombre.
        /// </summary>
        /// <param name="pNombre">Posible subcadena del nombre.</param>
        ICollection<ElementoCarteleria> BusquedaAproxElementoCarteleria(string pNombre);
        /// <summary>
        /// Obtener todos los ElementosCarteleria.
        /// </summary>
        ICollection<ElementoCarteleria> GetAllElementosCarteleria();
        /// <summary>
        /// Obtener todos los ElementosCarteleria entre dos fechas.
        /// </summary>
        ICollection<ElementoCarteleria> GetAllElementosCarteleriaEntre(DateTime pFechaInicio, DateTime pFechaFin);
        /// <summary>
        /// Obtener los ElementosCarteleria pertenecientes al día de la fecha. Ordenados por hora de inicio.
        /// </summary>
        ICollection<ElementoCarteleria> ElementosCarteleriaHoy();
        #endregion
        /*
        #region Campaña
        /// <summary>
        /// Agregar una campaña.
        /// </summary>
        /// <param name="pCampaña">Campaña a agregar.</param>
        void AgregarCampaña(Campaña pCampaña);
		/// <summary>
		/// Actualizar una campaña.
		/// </summary>
		/// <param name="pCampaña">Campaña a actualizar.</param>
        void ActualizarCampaña(Campaña pCampaña);
		/// <summary>
		/// Obtener todas las campañas.
		/// </summary>
		ICollection<ElementoCarteleria> GetAllCampañas();
		/// <summary>
		/// Obtener todas las campañas entre dos fechas.
		/// </summary>
		/// <param name="pFechaInicial">Fecha inicial.</param>
		/// <param name="pFechaFinal">Fecha final.</param>
		ICollection<ElementoCarteleria> GetAllCampañasEntre (DateTime pFechaInicial, DateTime pFechaFinal);
        #endregion
        #region Banner Estático
        /// <summary>
        /// Agregar un banner estático
        /// </summary>
        /// <param name="pBanner">Banner a agregar.</param>
        void AgregarBannerEstatico(BannerEstatico pBanner);
		/// <summary>
		/// Actualizar un banner estático
		/// </summary>
		/// <param name="pBanner">Banner a actualizar.</param>
        void ActualizarBannerEstatico(BannerEstatico pBanner);
		/// <summary>
		/// Obtener todos los banners estáticos.
		/// </summary>
		/// <returns>The all banners estaticos.</returns>
		ICollection<ElementoCarteleria> GetAllBannersEstaticos();
		#endregion
		#region RSSFeed
		/// <summary>
		/// Agregar una fuente de RSS.
		/// </summary>
		/// <param name="pBanner">Fuente RSS a agregar.</param>
        void AgregarRSSFeed(RSSFeed pBanner);
		/// <summary>
		/// Actualizar una fuente de RSS.
		/// </summary>
		/// <param name="pBanner">Fuente RSS a agregar.</param>
        void ActualizarRSSFeed(RSSFeed pBanner);
		/// <summary>
		/// Obtener todas las fuentes RSS.
		/// </summary>
		ICollection<ElementoCarteleria> GetAllRSSFeed();
		#endregion
		#region Métodos del Día
        /// <summary>
		/// Obtener las campañas pertenecientes al día de la fecha. Ordenadas por hora de inicio.
        /// </summary>
		ICollection<ElementoCarteleria> CampañasHoy();
		/// <summary>
		/// Obtener los banners pertenecientes al día de la fecha. Ordenados por hora de inicio.
		/// </summary>
		ICollection<ElementoCarteleria> BannersHoy();
		#endregion
		#region Búsqueda por Nombre
		/// <summary>
		/// Buscar fuentes RSS por nombre.
		/// </summary>
		/// <param name="pNombre">Posible subcadena del nombre.</param>
		ICollection<RSSFeed> BusquedaAproxBannerRSS(string pNombre);
		/// <summary>
		/// Buscar banners estáticos por nombre.
		/// </summary>
		/// <param name="pNombre">Posible subcadena del nombre.</param>
		ICollection<BannerEstatico> BusquedaAproxBannerEstatico(string pNombre);
		/// <summary>
		/// Buscar campañas por nombre.
		/// </summary>
		/// <param name="pNombre">Posible subcadena del nombre.</param>
		ICollection<Campaña> BusquedaAproxCampaña(string pNombre);
		#endregion
		#region Búsqueda por Id
		/// <summary>
		/// Obtener una campaña por su Id
		/// </summary>
		/// <param name="pId">Identificador.</param>
        Campaña BuscarCampaña(int pId);
		/// <summary>
		/// Obtener un banner estático por su Id.
		/// </summary>
		/// <param name="pId">Identificador.</param>
        BannerEstatico BuscarBannerEstatico(int pId);
		/// <summary>
		/// Buscar una fuente RSS por su Id.
		/// </summary>
		/// <param name="pId">Identificador.</param>
        RSSFeed BuscarRSSFeed(int pId);
		#endregion
        */
    }
}
