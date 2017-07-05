using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using CapaEntidad;
using CapaDatos;

namespace CapaNegocio
{
	/// <summary>
	/// Fachada capa negocio.
	/// </summary>
    public static class FachadaCapaNegocio
    {
        #region Lectura de RSSFeed
        /// <summary>
        /// Obtener los ítems o noticias de una fuente RSS desde su URL.
        /// </summary>
        /// <param name="pUrl">URL de la fuente RSS</param>
        /// <returns>Noticias obtenidas de la fuente.</returns>
        public static ICollection<RSSItem> LeerRSS(String pURL)
        {
            return FachadaCapaNegocio.LeerRSS(new Uri(pURL));
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
        #region Métodos
        /// <summary>
        /// Crea una entrada de <typeparamref name="ElementoCarteleria"/>.
        /// </summary>
        /// <param name="pElementoCarteleria">Objeto a insertar.</param>
        public static void AgregarElementoCarteleria(ElementoCarteleria pElementoCarteleria)
        {
            CapaDatosFachada.GetInstancia().Create(pElementoCarteleria);
        }

        /// <summary>
        /// Actualiza una entrada.
        /// </summary>
        /// <param name="pCamapaña">Objeto actualizado.</param>
        public static void ActualizarElementoCarteleria(ElementoCarteleria pElementoCarteleria)
        {
            CapaDatosFachada.GetInstancia().Update(pElementoCarteleria);
        }

        /// <summary>
        /// Elimina un cartel por su Identificador
        /// </summary>
        /// <param name="pID">Identificador del objeto a eliminar</param>
        public static void EliminarElementoCarteleria(Int64 pID)
        {
            CapaDatosFachada.GetInstancia().Delete(pID);
        }

        /// <summary>
        /// Elimina una entrada.
        /// </summary>
        /// <param name="pElementoCarteleriaID">Id del objeto a eliminar.</param>
        public static ElementoCarteleria BuscarElementoCarteleria(Int64 pId)
        {
            return CapaDatosFachada.GetInstancia().GetByIdElementoCarteleria(pId);
        }

        /// <summary>
        /// Elimina una entrada.
        /// </summary>
        /// <param name="pElementoCarteleria">Objeto a eliminar.</param>
        public static ICollection<ElementoCarteleria> BusquedaAproxElementoCarteleria(string pNombre)
        {
            return CapaDatosFachada.GetInstancia().BusquedaAproximacionElementoCarteleria(pNombre);
        }

        /// <summary>
        /// Obtener todos los carteles existentes.
        /// </summary>
        public static ICollection<ElementoCarteleria> GetAllElementosCarteleria()
        {
            return CapaDatosFachada.GetInstancia().GetAllElementosCarteleria();
        }

        /// <summary>
        /// Obtener todos los carteles existentes, entre dos fechas.
        /// </summary>
        /// <param name="pFechaInicio">Fecha inicial en la que debe estar contenida el cartel.</param>
        /// <param name="pFechaFin">Fecha final en la que debe estar contenida el cartel.</param>
        /// <returns></returns>
        public static ICollection<ElementoCarteleria> GetAllElementosCarteleriaEntre(DateTime pFechaInicio, DateTime pFechaFin)
        {
            return CapaDatosFachada.GetInstancia().GetAllElementosCarteleriaEntre(pFechaInicio, pFechaFin);
        }

        /// <summary>
        /// Obtener los carteles existentes para el día de la fecha.
        /// </summary>
        /// <returns></returns>
        public static ICollection<ElementoCarteleria> ElementosCarteleriaHoy()
        {
            ICollection<ElementoCarteleria> mCartelesHoy = new List<ElementoCarteleria>();
            foreach (ElementoCarteleria mEC in CapaDatosFachada.GetInstancia().GetElementosCarteleriaHoy())
            {
                if (mEC.GetHorarioHoy() != null)
                {
                    mCartelesHoy.Add(mEC);
                }
            }
            return mCartelesHoy;
        }

        /// <summary>
        /// Para los carteles cuyo banner provenga de una fuente externa.
        /// Se actualizan las noticias de las fuentes externas.
        /// </summary>
        public static void ActualizarNoticiasHoy()
        {

            foreach (ElementoCarteleria mElementoCarteleria in FachadaCapaNegocio.ElementosCarteleriaHoy())
            {
                try
                {
                    // not null nor other type but rssfeed
                    if (mElementoCarteleria.Banner is RSSFeed)
                    {
                        RSSFeed mRSSFeed = mElementoCarteleria.Banner as RSSFeed;
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
