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
        /// <param name="pElementoCarteleriaID">Id del objeto a eliminar.</param>
        public void Delete(Int64 pElementoCarteleriaID)
		{
            Delete(iUnitOfWork.ElementoCarteleriaRepositorio.GetByID(pElementoCarteleriaID));
        }

        /// <summary>
        /// Elimina una entrada de tabla.
        /// </summary>
        /// <param name="pElementoCarteleria">Objeto a eliminar.</param>
        public void Delete(ElementoCarteleria pElementoCarteleria)
        {
            //Para forzar la eliminación en cascada. Se eliminan primero los items que contienen claves foráneas.
            //Eliminar todas las imágenes de la campaña.
            foreach (ImagenCampaña imagen in pElementoCarteleria.Campaña.ListaImagenes.Reverse())
            {
                iUnitOfWork.ImagenCampañaRepositorio.Delete(imagen);
            }
            //Eliminar la campaña del cartel.
            iUnitOfWork.CampañaRepositorio.Delete(pElementoCarteleria.Campaña);
            //Dependiendo del tipo de banner que se trate.
            if (pElementoCarteleria.Banner is BannerEstatico)
            {
                //simplemente se elimina el banner.
                iUnitOfWork.BannerEstRepositorio.Delete((BannerEstatico)pElementoCarteleria.Banner);
            }
            else if (pElementoCarteleria.Banner is RSSFeed)
            {
                //se eliminan todas las noticias almacenadas primero
                IEnumerable<RSSItem> mListaNoticiasBorrar = ((RSSFeed)pElementoCarteleria.Banner).UltimasNoticias;
                foreach (RSSItem item in mListaNoticiasBorrar.Reverse())
                {
                    iUnitOfWork.RSSItemRepositorio.Delete(item);
                }
                //luego se elimina el banner
                iUnitOfWork.RSSFeedRepositorio.Delete((RSSFeed)pElementoCarteleria.Banner);

            }
            //finalmente se elimina el cartel
            iUnitOfWork.ElementoCarteleriaRepositorio.Delete(pElementoCarteleria);
            //guardar cambios
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
        public ElementoCarteleria GetByIdElementoCarteleria(Int64 pElementoCarteleria)
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
    }
}
