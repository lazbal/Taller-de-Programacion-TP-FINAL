using System;
using System.Collections.Generic;
using CapaEntidad;

namespace CapaDatos
{
	/// <summary>
	/// Interfaz a satisfacer por la Capa de Datos.
	/// </summary>
	public interface ICapaDatosFachada
	{
        #region ElementoCarteleria
        /// <summary>
        /// Crear una <see cref="ElementoCarteleria"/> en la base de datos.
        /// </summary>
        /// <param name="pElementoCarteleria">ElementoCarteleria a crear.</param>
        void Create(ElementoCarteleria pElementoCarteleria);
		/// <summary>
		/// Actualizar una <see cref="ElementoCarteleria"/> en la base de datos.
		/// </summary>
		/// <param name="pElementoCarteleria">ElementoCarteleria a actualizar.</param>
		void Update(ElementoCarteleria pElementoCarteleria);
		/// <summary>
		/// Obtener todas las <see cref="ElementoCarteleria"/> en la base de datos.
		/// </summary>
		/// <returns>Todas las ElementoCartelerias.</returns>
		ICollection<ElementoCarteleria> GetAllElementosCarteleria();
        /// <summary>
        /// Obtener todas las <see cref="ElementoCarteleria"/> en la base de datos para el día de la fecha.
        /// </summary>
        /// <returns>Todos los ElementosCarteleria del día.</returns>
        ICollection<ElementoCarteleria> GetElementosCarteleriaHoy();
        /// <summary>
        /// Obtener todas las <see cref="ElementoCarteleria"/> en la base de datos comprendidas entre dos fechas.
        /// </summary>
        /// <param name="pFechaInicial">Fecha inicial.</param>
        /// <param name="pFechaFinal">Fecha final.</param>
        ICollection<ElementoCarteleria> GetAllElementosCarteleriaEntre (DateTime pFechaInicial, DateTime pFechaFinal);
        /// <summary>
        /// Devuelve la coleccion con los elementos de carteleria cuyo nombre poseen similitud con la cadena provista.
        /// </summary>
        /// <param name="pNombre">Posible nombre.</param>
        /// <returns>Lista de coincidencias <typeparamref name="ElementoCarteleria"/></returns>
        ICollection<ElementoCarteleria> BusquedaAproximacionElementoCarteleria(string pNombre);
        /// <summary>
        /// Obtiene una <see cref="ElementoCarteleria"/> por su Id.
        /// </summary>
        /// <param name="pId">Identificador de la ElementoCarteleria.</param>
        ElementoCarteleria GetByIdElementoCarteleria (int pId);
        #endregion
        /*
		#region Campaña
		/// <summary>
		/// Crear una <see cref="Campaña"/> en la base de datos.
		/// </summary>
		/// <param name="pCampaña">Campaña a crear.</param>
		void Create(Campaña pCampaña);
		/// <summary>
		/// Actualizar una <see cref="Campaña"/> en la base de datos.
		/// </summary>
		/// <param name="pCampaña">Campaña a actualizar.</param>
		void Update(Campaña pCampaña);
		/// <summary>
		/// Obtener todas las <see cref="Campaña"/> en la base de datos.
		/// </summary>
		/// <returns>Todas las campañas.</returns>
		ICollection<ElementoCarteleria> GetAllCampañas();
		/// <summary>
		/// Obtener todas las <see cref="Campaña"/> en la base de datos comprendidas entre dos fechas.
		/// </summary>
		/// <param name="pFechaInicial">Fecha inicial.</param>
		/// <param name="pFechaFinal">Fecha final.</param>
		ICollection<ElementoCarteleria> GetAllCampañasEntre (DateTime pFechaInicial, DateTime pFechaFinal);
        /// <summary>
        /// Devuelve la coleccion con los elementos de carteleria que poseen campaña y cuyo nombre poseen similitud con la cadena provista.
        /// </summary>
        /// <param name="pNombre">Posible nombre.</param>
        /// <returns>Lista de coincidencias <typeparamref name="ElementoCarteleria"/></returns>
        ICollection<ElementoCarteleria> BusquedaAproximacionCampaña(string pNombre);
        /// <summary>
        /// Obtiene una <see cref="Campaña"/> por su Id.
        /// </summary>
        /// <param name="pId">Identificador de la campaña.</param>
        Campaña GetByIdCampaña (int pId);
        #endregion
        #region Banners
        /// <summary>
        /// Obtiene todos los <see cref="Banners"/> de la base de datos.
        /// </summary>
        ICollection<ElementoCarteleria> GetAllBanners();
        /// <summary>
        /// Devuelve todos lo elementos de carteleria con RSSFeed, entre dos fechas
        /// </summary>
        /// <param name="pFechaInicial">Fecha inicial.</param>
        /// <param name="pFechaFinal">Fecha final.</param>
        ICollection<ElementoCarteleria> GetAllBannersEntre(DateTime pFechaInicial, DateTime pFechaFinal);
        /// <summary>
        /// Devuelve la coleccion con los elementos de carteleria que poseen Banners y cuyo nombre poseen similitud con la cadena provista.
        /// </summary>
        /// <param name="pNombre">Posible nombre.</param>
        /// <returns>Lista de coincidencias <typeparamref name="ElementoCarteleria"/></returns>
        ICollection<ElementoCarteleria> BusquedaAproximacionBanners(string pNombre);
        #endregion
        #region Banner Estático
        /// <summary>
        /// Crear una <see cref="BannerEstatico"/> en la base de datos.
        /// </summary>
        /// <param name="pBanner">Banner estático a crear.</param>
        void Create(BannerEstatico pBanner);
		/// <summary>
		/// Actualiza una <see cref="BannerEstatico"/> en la base de datos.
		/// </summary>
		/// <param name="pBanner">Banner estático a actualizar.</param>
		void Update(BannerEstatico pBanner);
		/// <summary>
		/// Obtiene todos los <see cref="BannerEstatico"/> en la base de datos.
		/// </summary>
		/// <returns>Todos los banners estáticos.</returns>
		ICollection<ElementoCarteleria> GetAllBannersEst();
		/// <summary>
		/// Obtiene todos los <see cref="BannerEstatico"/> en la base de datos comprendidos entre dos fechas.
		/// </summary>
		/// <param name="pFechaInicial">Fecha inicial.</param>
		/// <param name="pFechaFinal">Fecha final.</param>
		ICollection<ElementoCarteleria> GetAllBannersEstEntre (DateTime pFechaInicial, DateTime pFechaFinal);
        /// <summary>
        /// Devuelve la coleccion con los elementos de carteleria que poseen banner estático y cuyo nombre poseen similitud con la cadena provista.
        /// </summary>
        /// <param name="pNombre">Posible nombre.</param>
        /// <returns>Lista de coincidencias <typeparamref name="ElementoCarteleria"/></returns>
        ICollection<ElementoCarteleria> BusquedaAproximacionBannerEst(string pNombre);
        /// <summary>
        /// Obtiene un <see cref="BannerEstatico"/> por su Id
        /// </summary>
        /// <param name="pId">Identificador del banner estático.</param>
        BannerEstatico GetByIdBannerEst (int pId);
		#endregion
		#region RSSFeed
		/// <summary>
		/// Crea un <see cref="RSSFeed"/> en la base de datos.
		/// </summary>
		/// <param name="pBanner">RSSFeed a crear.</param>
		void Create(RSSFeed pBanner);
		/// <summary>
		/// Actualiza un <see cref="RSSFeed"/> en la base de datos.
		/// </summary>
		/// <param name="pBanner">RSSFeed a actualizar.</param>
		void Update(RSSFeed pBanner);
		/// <summary>
		/// Obtiene todos los <see cref="RSSFeed"/> de la base de datos.
		/// </summary>
		ICollection<ElementoCarteleria> GetAllRSSFeed();
		/// <summary>
		/// Obtiene los <see cref="RSSFeed"/> en la base de datos, comprendidos entre dos fechas.
		/// </summary>
		/// <param name="pFechaInicial">Fecha inicial.</param>
		/// <param name="pFechaFinal">Fecha final.</param>
		ICollection<ElementoCarteleria> GetAllRSSFeedEntre (DateTime pFechaInicial, DateTime pFechaFinal);
        /// <summary>
        /// Devuelve la coleccion con los elementos de carteleria que poseen RSSFeed y cuyo nombre poseen similitud con la cadena provista.
        /// </summary>
        /// <param name="pNombre">Posible nombre.</param>
        /// <returns>Lista de coincidencias <typeparamref name="ElementoCarteleria"/></returns>
        ICollection<ElementoCarteleria> BusquedaAproximacionRSSFeed(string pNombre);
        /// <summary>
        /// Obtiene un <see cref="RSSFeed"/> por su Id.
        /// </summary>
        /// <param name="pId">Identificador del RSSFeed.</param>
        RSSFeed GetByIdRSSFeed (int pId);
        #endregion
        #region Métodos del Día
        /// <summary>
        /// Devuelve las <see cref="Campaña"/>  corresponientes al día de la fecha.
        /// </summary>
        /// <returns>Campañas de hoy</returns>
        ICollection<ElementoCarteleria> CampañasHoy();
        /// <summary>
        /// Devuelve la lista de los elementos de cartelería con Banners a mostrar el día de la fecha. Sin orden específico.
        /// </summary>
        /// <returns>Lista de <typeparamref name="ElementoCarteleria"/></returns>
        ICollection<ElementoCarteleria> BannersHoy();
        /// <summary>
        /// Devuelve los <see cref="BannerEstatico"/> corresponientes al día de la fecha.
        /// </summary>
        /// <returns>Banners estáticos de hoy</returns>
        ICollection<ElementoCarteleria> BannerEstHoy();
        /// <summary>
        /// Devuelve los <see cref="RSSFeed"/> corresponientes al día de la fecha.
        /// </summary>
        /// <returns>RSSFeeds de hoy</returns>
        ICollection<ElementoCarteleria> RSSFeedHoy();
        #endregion
        */
    }
}

