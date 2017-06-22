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
    public class FachadaCapaNegocio : IFachadaCapaNegocio
    {
		#region Datos
        private ICapaDatosFachada iFachadaDatos = new CapaDatosFachada();
        private ICollection<ElementoCarteleria> iElementosCarteleriaHoy;
		#endregion
		#region Constructores
		/// <summary>
		/// Inicializa una instancia de la clase <see cref="FachadaCapaNegocio"/>.
		/// </summary>
        public FachadaCapaNegocio()
        {
            iElementosCarteleriaHoy = iFachadaDatos.GetElementosCarteleriaHoy();
        }
        #endregion
        #region Lectura de RSSFeed
        /// <summary>
        /// Obtener los ítems o noticias de una fuente RSS desde su URL.
        /// </summary>
        /// <param name="pUrl">URL de la fuente RSS</param>
        /// <returns>Noticias obtenidas de la fuente.</returns>
        public ICollection<RSSItem> LeerRSS(String pURL)
        {
            return this.LeerRSS(new Uri(pURL));
        }
        /// <summary>
        /// Obtener los ítems o noticias de una fuente RSS desde su URL.
        /// </summary>
        /// <param name="pUrl">URL de la fuente RSS</param>
        /// <returns>Noticias obtenidas de la fuente.</returns>
        public ICollection<RSSItem> LeerRSS(Uri pURL)
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
        public void AgregarElementoCarteleria(ElementoCarteleria pElementoCarteleria)
        {
            iFachadaDatos.Create(pElementoCarteleria);
        }

        /// <summary>
        /// Actualiza una entrada.
        /// </summary>
        /// <param name="pCamapaña">Objeto actualizado.</param>
        public void ActualizarElementoCarteleria(ElementoCarteleria pElementoCarteleria)
        {
            iFachadaDatos.Update(pElementoCarteleria);
        }

        /// <summary>
        /// Elimina un cartel por su Identificador
        /// </summary>
        /// <param name="pID">Identificador del objeto a eliminar</param>
        public void EliminarElementoCarteleria(Int64 pID)
        {
            iFachadaDatos.Delete(pID);
        }

        /// <summary>
        /// Elimina una entrada.
        /// </summary>
        /// <param name="pElementoCarteleriaID">Id del objeto a eliminar.</param>
        public ElementoCarteleria BuscarElementoCarteleria(Int64 pId)
        {
            return iFachadaDatos.GetByIdElementoCarteleria(pId);
        }

        /// <summary>
        /// Elimina una entrada.
        /// </summary>
        /// <param name="pElementoCarteleria">Objeto a eliminar.</param>
        public ICollection<ElementoCarteleria> BusquedaAproxElementoCarteleria(string pNombre)
        {
            return iFachadaDatos.BusquedaAproximacionElementoCarteleria(pNombre);
        }

        /// <summary>
        /// Obtener todos los carteles existentes.
        /// </summary>
        public ICollection<ElementoCarteleria> GetAllElementosCarteleria()
        {
            return iFachadaDatos.GetAllElementosCarteleria();
        }

        /// <summary>
        /// Obtener todos los carteles existentes, entre dos fechas.
        /// </summary>
        /// <param name="pFechaInicio">Fecha inicial en la que debe estar contenida el cartel.</param>
        /// <param name="pFechaFin">Fecha final en la que debe estar contenida el cartel.</param>
        /// <returns></returns>
        public ICollection<ElementoCarteleria> GetAllElementosCarteleriaEntre(DateTime pFechaInicio, DateTime pFechaFin)
        {
            return iFachadaDatos.GetAllElementosCarteleriaEntre(pFechaInicio, pFechaFin);
        }

        /// <summary>
        /// Obtener los carteles existentes para el día de la fecha.
        /// </summary>
        /// <returns></returns>
        public ICollection<ElementoCarteleria> ElementosCarteleriaHoy()
        {
            return iFachadaDatos.GetElementosCarteleriaHoy();
        }

        /// <summary>
        /// Para los carteles cuyo banner provenga de una fuente externa.
        /// Se actualizan las noticias de las fuentes externas.
        /// </summary>
        public void ActualizarNoticiasHoy()
        {

            foreach (ElementoCarteleria mElementoCarteleria in iElementosCarteleriaHoy)
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
