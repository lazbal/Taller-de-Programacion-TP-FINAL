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
        /// Eliminar de la base de datos el cartel seleccionado.
        /// </summary>
        void EliminarElementoCarteleria(Int64 pID);
        /// <summary>
        /// Obtener un Elemento Cartelería por su Id.
        /// </summary>
        /// <param name="pId">Identificador.</param>
        ElementoCarteleria BuscarElementoCarteleria(Int64 pId);
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
        /// <summary>
        /// Actualiza los banners de fuente externas del día de hoy.
        /// </summary>
        void ActualizarNoticiasHoy();
        #endregion
    }
}
