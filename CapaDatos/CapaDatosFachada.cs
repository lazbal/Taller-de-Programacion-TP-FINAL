using System;
using System.Collections.Generic;
using System.Linq;
using CapaEntidad;

namespace CapaDatos
{
    /// <summary>
    /// Fachada para la capa de datos.
    /// </summary>
	public class CapaDatosFachada
    {
        #region Datos
        private UnitOfWork iUnitOfWork;
        private static CapaDatosFachada instancia = null;
        #endregion
        #region Constructores
        /// <summary>
        /// Método de Singleton para obtener la instancia.
        /// </summary>
        /// <returns></returns>
        public static CapaDatosFachada GetInstancia()
        {
            if (instancia == null)
                instancia = new CapaDatosFachada();
            return instancia;
        }

        /// <summary>
        /// Inicializa una instancia de la clase <see cref="CapaDatos.CapaDatosFachada"/>.
        /// </summary>
        private CapaDatosFachada()
		{
             this.iUnitOfWork = new UnitOfWork();
        }
		#endregion
        #region Banner
        /// <summary>
        /// Crea una entrada de <typeparamref name="Banner"/> en la tabla de éstos.
        /// </summary>
        /// <param name="pBanner">Objeto a insertar en tabla.</param>
        public void Create(Banner pBanner)
        {
            iUnitOfWork.BannerRepositorio.Insert(pBanner);
            iUnitOfWork.Save();
        }

        /// <summary>
        /// Actualiza una entrada de tabla.
        /// </summary>
        /// <param name="pCamapaña">Objeto actualizado.</param>
        public void Update(Banner pBanner)
        {
            iUnitOfWork.BannerRepositorio.Update(pBanner);
            iUnitOfWork.Save();
        }

        /// <summary>
        /// Elimina una entrada de tabla.
        /// </summary>
        /// <param name="pBanner">Objeto a eliminar.</param>
        public void Delete(Banner pBanner)
        {
            if (pBanner is RSSFeed)
            {
                //se eliminan todas las noticias almacenadas primero
                IEnumerable<RSSItem> mListaNoticiasBorrar = ((RSSFeed)pBanner).UltimasNoticias;
                foreach (RSSItem item in mListaNoticiasBorrar.Reverse())
                {
                    iUnitOfWork.RSSItemRepositorio.Delete(item);
                }
            }
            //finalmente se elimina el banner
            iUnitOfWork.BannerRepositorio.Delete(pBanner);
            //guardar cambios
            iUnitOfWork.Save();
        }

        /// <summary>
        /// Devuelve todas las entradas de tabla como una lista.
        /// </summary>
        /// <returns>Lista de <typeparamref name="Banner"/>,</returns>
        public ICollection<Banner> GetAllBanners()
        {
            IQueryable<Banner> consulta = iUnitOfWork.BannerRepositorio.Queryable;
            return consulta.ToList();
        }

        /// <summary>
        /// Devuelve la consulta con todos los banners entre dos fechas
        /// </summary>
        /// <param name="pFechaInicial">Fecha inicial.</param>
        /// <param name="pFechaFinal">Fecha final.</param>
        private IQueryable<Banner> GetQueryAllBannersEntre(DateTime pFechaInicial, DateTime pFechaFinal)
        {
            IQueryable<Banner> iBanners =
                from banner in iUnitOfWork.BannerRepositorio.Queryable
                where (banner.FechaInicio <= pFechaFinal) &&
                      (banner.FechaFin >= pFechaInicial)
                select banner;
            return iBanners;
        }

        /// <summary>
        /// Obtener todas las <see cref="Banner"/> en la base de datos que comprenden la fecha de hoy.
        /// Ordenadas por el horario de inicio para el día de hoy.
        /// Las que no posean un horario para el día de hoy se colocan al final de la coleccion.
        /// </summary>
        /// <returns>Todos los Banners del día.</returns>
        public ICollection<Banner> GetBannersHoy()
        {
            IQueryable<Banner> consulta = GetQueryAllBannersEntre(DateTime.Today, DateTime.Today);
            //Se ordenan por el día de la fecha de la consulta.
            return consulta.AsEnumerable().OrderBy(elem => elem).ToList();
        }

        /// <summary>
        /// Devuelve todos los banners entre dos fechas.
        /// </summary>
        /// <param name="pFechaInicial">Fecha inicial.</param>
        /// <param name="pFechaFinal">Fecha final.</param>
        public ICollection<Banner> GetAllBannersEntre(DateTime pFechaInicial, DateTime pFechaFinal)
        {
            IQueryable<Banner> consulta = GetQueryAllBannersEntre(pFechaInicial, pFechaFinal);
            //Se ordenan por el día de la fecha de la consulta. En caso de ser null irá primero.
            return consulta.ToList();
        }

        /// <summary>
        /// Busca y obtiene un elemento específico en la base de datos.
        /// </summary>
        /// <param name="pBanner">ID del objeto a buscar</param>
        /// <returns>El objeto encontrado ó nulo si no lo encuentra.</returns>
        public Banner GetByIdBanner(Int64 pBanner)
        {
            return iUnitOfWork.BannerRepositorio.GetByID(pBanner); ;
        }

        /// <summary>
        /// Devuelve la consulta los elementos de carteleria cuyo nombre poseen similitud con la cadena provista.
        /// </summary>
        /// <param name="pNombre">Posible nombre.</param>
        /// <returns>Lista de coincidencias <typeparamref name="Banner"/></returns>
        public IQueryable<Banner> QueryBusquedaAproximacionBanner(string pCadena)
        {
            //Se realiza una consulta a la tabla por las entradas cuyo nombre contiene la cadena provista.
            IQueryable<Banner> iBanner =
                from banner in iUnitOfWork.BannerRepositorio.Queryable
                where banner.Nombre.Contains(pCadena) ||
                        banner.Descripcion.Contains(pCadena)
                select banner;
            return iBanner;
        }

        /// <summary>
        /// Devuelve la coleccion con los elementos de carteleria cuyo nombre poseen similitud con la cadena provista.
        /// </summary>
        /// <param name="pNombre">Posible nombre.</param>
        /// <returns>Lista de coincidencias <typeparamref name="Banner"/></returns>
        public ICollection<Banner> BusquedaAproximacionBanner(string pCadena)
        {
            return QueryBusquedaAproximacionBanner(pCadena).ToList();
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
        /// <param name="pCampaña">Objeto a eliminar.</param>
        public void Delete(Campaña pCampaña)
        {
            //Para forzar la eliminación en cascada. Se eliminan primero los items que contienen claves foráneas.
            //Eliminar todas las imágenes de la campaña.
            foreach (ImagenCampaña imagen in pCampaña.ListaImagenes.Reverse())
            {
                iUnitOfWork.ImagenCampañaRepositorio.Delete(imagen);
            }
            //Eliminar la campaña.
            iUnitOfWork.CampañaRepositorio.Delete(pCampaña);
            //guardar cambios
            iUnitOfWork.Save();
        }

        /// <summary>
        /// Devuelve todas las entradas de tabla como una lista.
        /// </summary>
        /// <returns>Lista de <typeparamref name="Campaña"/>,</returns>
        public ICollection<Campaña> GetAllCampañas()
        {
            IQueryable<Campaña> consulta = iUnitOfWork.CampañaRepositorio.Queryable;
            return consulta.ToList();
        }

        /// <summary>
        /// Devuelve la consulta con todas las campañas entre dos fechas
        /// </summary>
        /// <param name="pFechaInicial">Fecha inicial.</param>
        /// <param name="pFechaFinal">Fecha final.</param>
        private IQueryable<Campaña> GetQueryAllCampañasEntre(DateTime pFechaInicial, DateTime pFechaFinal)
        {
            IQueryable<Campaña> iCampañas =
                from campaña in iUnitOfWork.CampañaRepositorio.Queryable
                where (campaña.FechaInicio <= pFechaFinal) &&
                      (campaña.FechaFin >= pFechaInicial)
                select campaña;
            return iCampañas;
        }

        /// <summary>
        /// Devuelve todas las campañas entre dos fechas.
        /// </summary>
        /// <param name="pFechaInicial">Fecha inicial.</param>
        /// <param name="pFechaFinal">Fecha final.</param>
        public ICollection<Campaña> GetAllCampañasEntre(DateTime pFechaInicial, DateTime pFechaFinal)
        {
            IQueryable<Campaña> consulta = GetQueryAllCampañasEntre(pFechaInicial, pFechaFinal);
            //Se ordenan por el día de la fecha de la consulta. En caso de ser null irá primero.
            return consulta.ToList();
        }

        /// <summary>
        /// Obtener todas las <see cref="Campaña"/> en la base de datos que comprenden la fecha de hoy.
        /// Ordenadas por el horario de inicio para el día de hoy.
        /// Las que no posean un horario para el día de hoy se colocan al final de la coleccion.
        /// </summary>
        /// <returns>Todas las campañas del día.</returns>
        public ICollection<Campaña> GetCampañasHoy()
        {
            IQueryable<Campaña> consulta = GetQueryAllCampañasEntre(DateTime.Today, DateTime.Today);
            //Se ordenan por el día de la fecha de la consulta.
            return consulta.AsEnumerable().OrderBy(elem => elem).ToList();
        }

        /// <summary>
        /// Busca y obtiene un elemento específico en la base de datos.
        /// </summary>
        /// <param name="pCampaña">ID del objeto a buscar</param>
        /// <returns>El objeto encontrado ó nulo si no lo encuentra.</returns>
        public Campaña GetByIdCampaña(Int64 pCampaña)
		{
			return iUnitOfWork.CampañaRepositorio.GetByID(pCampaña); ;
        }

        /// <summary>
        /// Devuelve la consulta los elementos de carteleria cuyo nombre poseen similitud con la cadena provista.
        /// </summary>
        /// <param name="pNombre">Posible nombre.</param>
        /// <returns>Lista de coincidencias <typeparamref name="Campaña"/></returns>
        public IQueryable<Campaña> QueryBusquedaAproximacionCampaña(string pCadena)
        {
            //Se realiza una consulta a la tabla por las entradas cuyo nombre contiene la cadena provista.
            IQueryable<Campaña> iCampaña =
                from campaña in iUnitOfWork.CampañaRepositorio.Queryable
                where campaña.Nombre.Contains(pCadena) ||
                      campaña.Descripcion.Contains(pCadena)
                select campaña;
            return iCampaña;
        }

        /// <summary>
        /// Devuelve la coleccion con los elementos de carteleria cuyo nombre poseen similitud con la cadena provista.
        /// </summary>
        /// <param name="pNombre">Posible nombre.</param>
        /// <returns>Lista de coincidencias <typeparamref name="Campaña"/></returns>
        public ICollection<Campaña> BusquedaAproximacionCampaña(string pCadena)
        {
            return QueryBusquedaAproximacionCampaña(pCadena).ToList();
        }
        #endregion
    }
}
