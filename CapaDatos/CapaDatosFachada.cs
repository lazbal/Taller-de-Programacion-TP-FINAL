using System;
using System.Collections.Generic;
using System.Linq;
using CapaEntidad;

namespace CapaDatos
{
    /// <summary>
    /// Fachada para la capa de datos.
    /// </summary>
	public class CapaDatosFachada : ICapaDatosFachada
    {
		#region Datos
        private UnitOfWork iUnitOfWork = new UnitOfWork();
		#endregion
		#region Constructores
		/// <summary>
		/// Inicializa una instancia de la clase <see cref="CapaDatos.CapaDatosFachada"/>.
		/// </summary>
        public CapaDatosFachada()
		{
        }
		#endregion
		#region ElementoCarteleria
		/// <summary>
		/// Crea una entrada de <typeparamref name="ElementoCarteleria"/> en la tabla de éstos.
		/// </summary>
		/// <param name="pElementoCarteleria">Objeto a insertar en tabla.</param>
		public void Create(ElementoCarteleria pElementoCarteleria)
		{
			iUnitOfWork.ElementoCarteleriaRepositorio.Insert(pElementoCarteleria);
			iUnitOfWork.Save();
		}

		/// <summary>
		/// Actualiza una entrada de tabla.
		/// </summary>
		/// <param name="pCamapaña">Objeto actualizado.</param>
		public void Update(ElementoCarteleria pElementoCarteleria)
		{
			iUnitOfWork.ElementoCarteleriaRepositorio.Update(pElementoCarteleria);
			iUnitOfWork.Save();
		}

		/// <summary>
		/// Elimina una entrada de tabla.
		/// </summary>
		/// <param name="pCamapaña">Id del objeto a eliminar.</param>
		public void DeleteElementoCarteleria(int pElementoCarteleria)
		{
            iUnitOfWork.CampañaRepositorio.Delete(pElementoCarteleria);
            iUnitOfWork.BannerEstRepositorio.Delete(pElementoCarteleria);
            iUnitOfWork.RSSFeedRepositorio.Delete(pElementoCarteleria);
            iUnitOfWork.ElementoCarteleriaRepositorio.Delete(pElementoCarteleria);
			iUnitOfWork.Save();
		}

		/// <summary>
		/// Devuelve todas las entradas de tabla como una lista.
		/// </summary>
		/// <returns>Lista de <typeparamref name="ElementoCarteleria"/>,</returns>
		public IQueryable<ElementoCarteleria> GetQueryAllElementosCarteleria()
		{
			return iUnitOfWork.ElementoCarteleriaRepositorio.Queryable;
        }

        /// <summary>
        /// Devuelve todas las entradas de tabla como una lista.
        /// </summary>
        /// <returns>Lista de <typeparamref name="ElementoCarteleria"/>,</returns>
        public ICollection<ElementoCarteleria> GetAllElementosCarteleria()
        {
            IQueryable<ElementoCarteleria> consulta = GetQueryAllElementosCarteleria();
            return consulta.ToList();
        }

        /// <summary>
        /// Devuelve la consulta con todos los elementos de carteleria entre dos fechas
        /// </summary>
        /// <param name="pFechaInicial">Fecha inicial.</param>
        /// <param name="pFechaFinal">Fecha final.</param>
        public IQueryable<ElementoCarteleria> GetQueryAllElementosCarteleriaEntre(DateTime pFechaInicial, DateTime pFechaFinal)
        {
            IQueryable<ElementoCarteleria> iElementoCartelerias =
                from elementosCarteleria in iUnitOfWork.ElementoCarteleriaRepositorio.Queryable
                where (elementosCarteleria.FechaInicio <= pFechaFinal) &&
                      (elementosCarteleria.FechaFin >= pFechaInicial)
                select elementosCarteleria;
            return iElementoCartelerias;
        }

        /// <summary>
        /// Obtener todas las <see cref="ElementoCarteleria"/> en la base de datos para el día de la fecha.
        /// </summary>
        /// <returns>Todos los ElementosCarteleria del día.</returns>
        public ICollection<ElementoCarteleria> GetElementosCarteleriaHoy()
        {
            IQueryable<ElementoCarteleria> consulta = GetQueryAllElementosCarteleriaEntre(DateTime.Today, DateTime.Today);
            return consulta.ToList();
        }

        /// <summary>
        /// Devuelve todos los elementos de carteleria entre dos fechas
        /// </summary>
        /// <param name="pFechaInicial">Fecha inicial.</param>
        /// <param name="pFechaFinal">Fecha final.</param>
        public ICollection<ElementoCarteleria> GetAllElementosCarteleriaEntre (DateTime pFechaInicial, DateTime pFechaFinal)
		{
			 IQueryable<ElementoCarteleria> consulta = GetQueryAllElementosCarteleriaEntre(pFechaInicial, pFechaFinal);
            return consulta.ToList();
		}

        /// <summary>
        /// Busca y obtiene un elemento específico en la base de datos.
        /// </summary>
        /// <param name="pElementoCarteleria">ID del objeto a buscar</param>
        /// <returns>El objeto encontrado ó nulo si no lo encuentra.</returns>
        public ElementoCarteleria GetByIdElementoCarteleria(int pElementoCarteleria)
		{
			return iUnitOfWork.ElementoCarteleriaRepositorio.GetByID(pElementoCarteleria); ;
        }

        /// <summary>
        /// Devuelve la consulta los elementos de carteleria cuyo nombre poseen similitud con la cadena provista.
        /// </summary>
        /// <param name="pNombre">Posible nombre.</param>
        /// <returns>Lista de coincidencias <typeparamref name="ElementoCarteleria"/></returns>
        public IQueryable<ElementoCarteleria> QueryBusquedaAproximacionElementoCarteleria(string pNombre)
        {
            //Se realiza una consulta a la tabla por las entradas cuyo nombre contiene la cadena provista.
            IQueryable<ElementoCarteleria> iElementoCarteleria =
                from elementoCarteleria in iUnitOfWork.ElementoCarteleriaRepositorio.Queryable
                where elementoCarteleria.Nombre.Contains(pNombre)
                select elementoCarteleria;
            return iElementoCarteleria;
        }

        /// <summary>
        /// Devuelve la coleccion con los elementos de carteleria cuyo nombre poseen similitud con la cadena provista.
        /// </summary>
        /// <param name="pNombre">Posible nombre.</param>
        /// <returns>Lista de coincidencias <typeparamref name="ElementoCarteleria"/></returns>
        public ICollection<ElementoCarteleria> BusquedaAproximacionElementoCarteleria(string pNombre)
        {
            return QueryBusquedaAproximacionElementoCarteleria(pNombre).ToList();
        }
        #endregion
        /*
        #region RSSItem
        /// <summary>
        /// Crea una entrada de la tabla.
        /// </summary>
        /// <param name="pRSSItem">Objeto a insertar en tabla.</param>
        public void Create(RSSItem pRSSItem)
        {
            iUnitOfWork.RSSItemRepositorio.Insert(pRSSItem);
            iUnitOfWork.Save();
        }
		
        /// <summary>
        /// Actualiza una entrada de tabla.
        /// </summary>
        /// <param name="pRSSItem">Objeto actualizado.</param>
        public void Update(RSSItem pRSSItem)
        {
            iUnitOfWork.RSSItemRepositorio.Update(pRSSItem);
            iUnitOfWork.Save();
        }

        /// <summary>
        /// Elimina una entrada de la tabla.
        /// </summary>
        /// <param name="pRSSItem">Id del objeto a eliminar.</param>
        public void DeleteRSSItem(int pRSSItem)
		{
            iUnitOfWork.RSSItemRepositorio.Delete(pRSSItem);
            iUnitOfWork.Save();
        }

        /// <summary>
        /// Devuelve todas las entradas de tabla como una colección.
        /// </summary>
        /// <returns>Colleción de <typeparamref name="RSSItem"/>,</returns>
		public ICollection<RSSItem> GetAllRSSItems()
        {
            return iUnitOfWork.RSSItemRepositorio.Queryable.ToList();
        }

        /// <summary>
        /// Otiene un elemento de la tabla por su Id
        /// </summary>
        /// <param name="pRSSItem">Id del objeto a buscar</param>
        /// <returns>El objeto encontrado ó nulo si no lo encuentra.</returns>
        public RSSItem GetByIdRSSItem(int pRSSItem)
        {
            return iUnitOfWork.RSSItemRepositorio.GetByID(pRSSItem); ;
        }
		#endregion
		#region Horario
        /// <summary>
        /// Crea una entrada de la tabla.
        /// </summary>
        /// <param name="pHorario">Objeto a insertar en tabla.</param>
        public void Create(Horario pHorario)
        {
            iUnitOfWork.HorarioRepositorio.Insert(pHorario);
            iUnitOfWork.Save();
        }

        /// <summary>
        /// Actualiza una entrada de tabla.
        /// </summary>
        /// <param name="pHorario">Objeto actualizado.</param>
        public void Update(Horario pHorario)
        {
            iUnitOfWork.HorarioRepositorio.Update(pHorario);
            iUnitOfWork.Save();
        }

        /// <summary>
        /// Elimina una entrada de la tabla.
        /// </summary>
        /// <param name="pHorario">Id del objeto a eliminar.</param>
        public void DeleteHorario(int pHorario)
        {
            iUnitOfWork.HorarioRepositorio.Delete(pHorario);
            iUnitOfWork.Save();
        }

        /// <summary>
        /// Devuelve todas las entradas de tabla como una colección.
        /// </summary>
        /// <returns>Colección de <typeparamref name="Horario"/>,</returns>
		public ICollection<Horario> GetAllHorarios()
        {
            return iUnitOfWork.HorarioRepositorio.Queryable.ToList();
        }

        /// <summary>
        /// Obtiene un elemento específico de la tabla por su Id.
        /// </summary>
        /// <param name="pHorario">Id del objeto a buscar</param>
        /// <returns>El objeto encontrado ó nulo si no lo encuentra.</returns>
        public Horario GetByIdHorario(int pHorario)
        {
            return iUnitOfWork.HorarioRepositorio.GetByID(pHorario); 
        }
            		#endregion
		#region ImagenCampaña
        /// <summary>
        /// Crea una entrada de <typeparamref name="ImagenCampaña"/> en la tabla de éstos.
        /// </summary>
        /// <param name="pImCampaña">Objeto a insertar en tabla.</param>
        public void Create(ImagenCampaña pImCampaña)
        {
            iUnitOfWork.ImagenCampañaRepositorio.Insert(pImCampaña);
            iUnitOfWork.Save();
        }

        /// <summary>
        /// Actualiza una entrada de tabla.
        /// </summary>
        /// <param name="pImCampaña">Objeto actualizado.</param>
        public void Update(ImagenCampaña pImCampaña)
        {
            iUnitOfWork.ImagenCampañaRepositorio.Update(pImCampaña);
            iUnitOfWork.Save();
        }

        /// <summary>
        /// Elimina una entrada de tabla.
        /// </summary>
        /// <param name="pImCampaña">Id del objeto a eliminar.</param>
        public void DeleteImagenCampaña(int pImCampaña)
        {
			iUnitOfWork.ImagenCampañaRepositorio.Delete(pImCampaña);
            iUnitOfWork.Save();
        }

        /// <summary>
        /// Devuelve todas las entradas de tabla como una lista.
        /// </summary>
        /// <returns>Lista de <typeparamref name="ImagenCampaña"/>,</returns>
		public ICollection<ImagenCampaña> GetAllImagenesCampañas()
        {
            return iUnitOfWork.ImagenCampañaRepositorio.Queryable.ToList();
        }

        /// <summary>
        /// Busca y obtiene un elemento específico en la base de datos.
        /// </summary>
        /// <param name="pImCampaña">ID del objeto a buscar</param>
        /// <returns>El objeto encontrado ó nulo si no lo encuentra.</returns>
        public ImagenCampaña GetByIdImagenCampaña(int pImCampaña)
        {
            return iUnitOfWork.ImagenCampañaRepositorio.GetByID(pImCampaña); ;
        }
		#endregion
		#region Campaña
		/// <summary>
		/// Crea una entrada de <typeparamref name="Campaña"/> en la tabla de éstos.
		/// </summary>
		/// <param name="pCampaña">Objeto a insertar en tabla.</param>
		public void Create(Campaña pCampaña)
		{
			iUnitOfWork.CampañaRepositorio.Insert(pCampaña);
			iUnitOfWork.Save();
		}

		/// <summary>
		/// Actualiza una entrada de tabla.
		/// </summary>
		/// <param name="pCamapaña">Objeto actualizado.</param>
		public void Update(Campaña pCampaña)
		{
			iUnitOfWork.CampañaRepositorio.Update(pCampaña);
			iUnitOfWork.Save();
		}

		/// <summary>
		/// Elimina una entrada de tabla.
		/// </summary>
		/// <param name="pCamapaña">Id del objeto a eliminar.</param>
		public void DeleteCampaña(int pCampaña)
		{
			iUnitOfWork.CampañaRepositorio.Delete(pCampaña);
			iUnitOfWork.Save();
		}

		/// <summary>
		/// Devuelve todas las entradas de tabla como una lista.
		/// </summary>
		/// <returns>Lista de <typeparamref name="Campaña"/>,</returns>
		public ICollection<ElementoCarteleria> GetAllCampañas()
        {
            return GetQueryAllElementoCartelerias().Where(e => e.Campaña != null).ToList();
        }

		/// <summary>
		/// Devuelve todos lo elementos de carteleria con campañas, entre dos fechas
		/// </summary>
		/// <param name="pFechaInicial">Fecha inicial.</param>
		/// <param name="pFechaFinal">Fecha final.</param>
		public ICollection<ElementoCarteleria> GetAllCampañasEntre (DateTime pFechaInicial, DateTime pFechaFinal)
		{
            return GetQueryAllElementoCarteleriasEntre(pFechaInicial, pFechaFinal).Where(e => e.Campaña != null).ToList();
		}

		/// <summary>
		/// Busca y obtiene un elemento específico en la base de datos.
		/// </summary>
		/// <param name="pCamapaña">ID del objeto a buscar</param>
		/// <returns>El objeto encontrado ó nulo si no lo encuentra.</returns>
		public Campaña GetByIdCampaña(int pCamapaña)
		{
			return iUnitOfWork.CampañaRepositorio.GetByID(pCamapaña);
		}
        #endregion
        #region Banners
        /// <summary>
        /// Obtiene todos los <see cref="Banners"/> de la base de datos.
        /// </summary>
        public ICollection<ElementoCarteleria> GetAllBanners()
        {
            return GetQueryAllElementoCartelerias().Where(e => e.Banner != null).ToList();
        }

        /// <summary>
        /// Devuelve todos lo elementos de carteleria con RSSFeed, entre dos fechas
        /// </summary>
        /// <param name="pFechaInicial">Fecha inicial.</param>
        /// <param name="pFechaFinal">Fecha final.</param>
        public ICollection<ElementoCarteleria> GetAllBannersEntre(DateTime pFechaInicial, DateTime pFechaFinal)
        {
            return GetQueryAllElementoCarteleriasEntre(pFechaInicial, pFechaFinal).Where(e => e.Banner != null).ToList();
        }
        #endregion
        #region Banner Estático
        /// <summary>
        /// Crea una entrada de <typeparamref name="BannerEstatico"/> en la tabla de éstos.
        /// </summary>
        /// <param name="pBannerEst">Objeto a insertar en tabla.</param>
        public void Create(BannerEstatico pBannerEst)
        {
            iUnitOfWork.BannerEstRepositorio.Insert(pBannerEst);
            iUnitOfWork.Save();
        }

        /// <summary>
        /// Actualiza una entrada de tabla.
        /// </summary>
        /// <param name="pBannerEst">Objeto actualizado.</param>
        public void Update(BannerEstatico pBannerEst)
		{
            iUnitOfWork.BannerEstRepositorio.Update(pBannerEst);
            iUnitOfWork.Save();
        }

        /// <summary>
        /// Elimina una entrada de tabla.
        /// </summary>
        /// <param name="pBannerEst">Id del objeto a eliminar.</param>
        public void DeleteBannerEst(int pBannerEst)
        {
			iUnitOfWork.BannerEstRepositorio.Delete(pBannerEst);
            iUnitOfWork.Save();
        }

        /// <summary>
        /// Devuelve todos los elementos de cartelería con banners estáticos.
        /// </summary>
        /// <returns>Lista de <typeparamref name="BannerEstatico"/>,</returns>
		public ICollection<ElementoCarteleria> GetAllBannersEst()
        {
            return GetQueryAllElementoCartelerias().Where(e => e.Banner != null && e.Banner is BannerEstatico).ToList();
        }

        /// <summary>
        /// Devuelve todos lo elementos de carteleria con banners estáticos, entre dos fechas
        /// </summary>
        /// <param name="pFechaInicial">Fecha inicial.</param>
        /// <param name="pFechaFinal">Fecha final.</param>
        public ICollection<ElementoCarteleria> GetAllBannersEstEntre(DateTime pFechaInicial, DateTime pFechaFinal)
        {
            return GetQueryAllElementoCarteleriasEntre(pFechaInicial, pFechaFinal).Where(e => e.Banner != null && e.Banner is BannerEstatico).ToList();
        }

        /// <summary>
        /// Busca y obtiene un elemento específico en la base de datos.
        /// </summary>
        /// <param name="pBannerEst">ID del objeto a buscar</param>
        /// <returns>El objeto encontrado ó nulo si no lo encuentra.</returns>
		public virtual BannerEstatico GetByIdBannerEst(int pBannerEst)
        {
			return iUnitOfWork.BannerEstRepositorio.GetByID(pBannerEst);
        }
        #endregion
        #region RSSFeed
        /// <summary>
        /// Crea una entrada de <typeparamref name="RSSFeed"/> en la tabla de éstos.
        /// </summary>
        /// <param name="pRSSFeed">Objeto a insertar en tabla.</param>
        public void Create(RSSFeed pRSSFeed)
        {
            iUnitOfWork.RSSFeedRepositorio.Insert(pRSSFeed);
            iUnitOfWork.Save();
        }

        /// <summary>
        /// Actualiza una entrada de tabla.
        /// </summary>
        /// <param name="pRSSFeed">Objeto actualizado.</param>
        public void Update(RSSFeed pRSSFeed)
        {
            iUnitOfWork.RSSFeedRepositorio.Update(pRSSFeed);
            iUnitOfWork.Save();
        }

        /// <summary>
        /// Elimina una entrada de tabla.
        /// </summary>
        /// <param name="pRSSFeed">Id del objeto a eliminar.</param>
        public void DeleteRSSFeed(int pRSSFeed)
        {
            iUnitOfWork.RSSFeedRepositorio.Delete(pRSSFeed);
            iUnitOfWork.Save();
        }

        /// <summary>
        /// Devuelve todos los elementos de cartelería con RSSFeed.
        /// </summary>
        /// <returns>Lista de <typeparamref name="RSSFeed"/>,</returns>
		public ICollection<ElementoCarteleria> GetAllRSSFeed()
        {
            return GetQueryAllElementoCartelerias().Where(e => e.Banner != null && e.Banner is RSSFeed).ToList();
        }

        /// <summary>
        /// Devuelve todos lo elementos de carteleria con RSSFeed, entre dos fechas
        /// </summary>
        /// <param name="pFechaInicial">Fecha inicial.</param>
        /// <param name="pFechaFinal">Fecha final.</param>
        public ICollection<ElementoCarteleria> GetAllRSSFeedEntre(DateTime pFechaInicial, DateTime pFechaFinal)
        {
            return GetQueryAllElementoCarteleriasEntre(pFechaInicial, pFechaFinal).Where(e => e.Banner != null && e.Banner is RSSFeed).ToList();
        }

        /// <summary>
        /// Busca y obtiene un elemento específico en la base de datos.
        /// </summary>
        /// <param name="pRSSFeed">ID del objeto a buscar</param>
        /// <returns>El objeto encontrado ó nulo si no lo encuentra.</returns>
        public RSSFeed GetByIdRSSFeed(int pRSSFeed)
        {
            return iUnitOfWork.RSSFeedRepositorio.GetByID(pRSSFeed);
        }
        #endregion
        #region Métodos del Día
        /// <summary>
		/// Devuelve la query de elementos cartelería a mostrar el día de la fecha. Sin orden específico.
		/// </summary>
		/// <returns>Query de<typeparamref name= "ElementoCartería" /></ returns >
        public IQueryable<ElementoCarteleria> QueryElementosCarteleriaHoy()
        {
            //Se realiza una consulta por las entradas cuya fecha de inicio y fin encierran a la fecha del día actual.
            IQueryable<ElementoCarteleria> iElementosCarteleria =
                from elementosCarteleria in iUnitOfWork.ElementoCarteleriaRepositorio.Queryable
                where (elementosCarteleria.GetHorarioHoy().DiaSemana == DateTime.Today.DayOfWeek)
                      && (elementosCarteleria.FechaInicio <= DateTime.Today)
                      && (elementosCarteleria.FechaFin >= DateTime.Today)
                select elementosCarteleria;
            return iElementosCarteleria;
        }

        /// <summary>
		/// Devuelve la coleccion de elementos cartelería a mostrar el día de la fecha. Sin orden específico.
		/// </summary>
		/// <returns>Query de<typeparamref name= "ElementoCartería" /></ returns >
        public ICollection<ElementoCarteleria> ElementosCarteleriaHoy()
        {
            return QueryElementosCarteleriaHoy().ToList();
        }

        /// <summary>
        /// Devuelve la lista de los elementos de cartelería con campañas a mostrar el día de la fecha. Sin orden específico.
        /// </summary>
        /// <returns>Lista de <typeparamref name="ElementoCarteleria"/></returns>
        public ICollection<ElementoCarteleria> CampañasHoy()
        {
            return QueryElementosCarteleriaHoy().Where(e => e.Campaña != null).ToList();
        }

        /// <summary>
        /// Devuelve la lista de los elementos de cartelería con Banners a mostrar el día de la fecha. Sin orden específico.
        /// </summary>
        /// <returns>Lista de <typeparamref name="ElementoCarteleria"/></returns>
        public ICollection<ElementoCarteleria> BannersHoy()
        {
            return QueryElementosCarteleriaHoy().Where(e => e.Banner != null).ToList();
        }

        /// <summary>
        /// Devuelve la lista de los elementos de cartelería con banners estáticos a mostrar el día de la fecha. Sin orden específico.
        /// </summary>
        /// <returns>Lista de <typeparamref name="ElementoCarteleria"/></returns>
        public ICollection<ElementoCarteleria> BannerEstHoy()
        {
            return QueryElementosCarteleriaHoy().Where(e => e.Banner != null && e.Banner is BannerEstatico).ToList();
        }

        /// <summary>
        /// Devuelve la lista de los elementos de cartelería con RSSFeed a mostrar el día de la fecha. Sin orden específico.
        /// </summary>
        /// <returns>Lista de <typeparamref name="ElementoCarteleria"/></returns>
        public ICollection<ElementoCarteleria> RSSFeedHoy()
        {
            return QueryElementosCarteleriaHoy().Where(e => e.Banner != null && e.Banner is RSSFeed).ToList();
        }
        #endregion
        #region Buscadores
        /// <summary>
        /// Devuelve la consulta los elementos de carteleria cuyo nombre poseen similitud con la cadena provista.
        /// </summary>
        /// <param name="pNombre">Posible nombre.</param>
        /// <returns>Lista de coincidencias <typeparamref name="ElementoCarteleria"/></returns>
        public IQueryable<ElementoCarteleria> QueryBusquedaAproximacionElementoCarteleria(string pNombre)
        {
            //Se realiza una consulta a la tabla por las entradas cuyo nombre contiene la cadena provista.
            IQueryable<ElementoCarteleria> iElementoCarteleria =
                from elementoCarteleria in iUnitOfWork.ElementoCarteleriaRepositorio.Queryable
                where elementoCarteleria.Nombre.Contains(pNombre)
                select elementoCarteleria;
            return iElementoCarteleria;
        }

        /// <summary>
        /// Devuelve la coleccion con los elementos de carteleria que poseen campaña y cuyo nombre poseen similitud con la cadena provista.
        /// </summary>
        /// <param name="pNombre">Posible nombre.</param>
        /// <returns>Lista de coincidencias <typeparamref name="ElementoCarteleria"/></returns>
        public ICollection<ElementoCarteleria> BusquedaAproximacionCampaña(string pNombre)
        {
            return QueryBusquedaAproximacionElementoCarteleria(pNombre).Where(e => e.Campaña != null).ToList();
        }

        /// <summary>
        /// Devuelve la coleccion con los elementos de carteleria que poseen banner estático y cuyo nombre poseen similitud con la cadena provista.
        /// </summary>
        /// <param name="pNombre">Posible nombre.</param>
        /// <returns>Lista de coincidencias <typeparamref name="ElementoCarteleria"/></returns>
        public ICollection<ElementoCarteleria> BusquedaAproximacionBannerEst(string pNombre)
        {
            return QueryBusquedaAproximacionElementoCarteleria(pNombre).Where(e => e.Banner != null && e.Banner is BannerEstatico).ToList();
        }

        /// <summary>
        /// Devuelve la coleccion con los elementos de carteleria que poseen RSSFeed y cuyo nombre poseen similitud con la cadena provista.
        /// </summary>
        /// <param name="pNombre">Posible nombre.</param>
        /// <returns>Lista de coincidencias <typeparamref name="ElementoCarteleria"/></returns>
        public ICollection<ElementoCarteleria> BusquedaAproximacionRSSFeed(string pNombre)
        {
            return QueryBusquedaAproximacionElementoCarteleria(pNombre).Where(e => e.Banner != null && e.Banner is RSSFeed).ToList();
        }

        /// <summary>
        /// Devuelve la coleccion con los elementos de carteleria que poseen Banners y cuyo nombre poseen similitud con la cadena provista.
        /// </summary>
        /// <param name="pNombre">Posible nombre.</param>
        /// <returns>Lista de coincidencias <typeparamref name="ElementoCarteleria"/></returns>
        public ICollection<ElementoCarteleria> BusquedaAproximacionBanners(string pNombre)
        {
            return QueryBusquedaAproximacionElementoCarteleria(pNombre).Where(e => e.Banner != null).ToList();
        }
        #endregion
        */
    }
}
