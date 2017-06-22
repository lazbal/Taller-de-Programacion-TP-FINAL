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
        /// Eliminar una <see cref="ElementoCarteleria"/> de la base de datos.
        /// </summary>
        /// <param name="pElementoCarteleriaID">ID del ElementoCarteleria a eliminar.</param>
        void Delete(Int64 pElementoCarteleriaID);
        /// <summary>
        /// Eliminar una <see cref="ElementoCarteleria"/> de la base de datos.
        /// </summary>
        /// <param name="pElementoCarteleria">ElementoCarteleria a eliminar.</param>
        void Delete(ElementoCarteleria pElementoCarteleria);
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
        ElementoCarteleria GetByIdElementoCarteleria (Int64 pId);
        #endregion
    }
}

