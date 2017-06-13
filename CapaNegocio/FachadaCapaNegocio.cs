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
		/// Inicializa una instancia de la clase <see cref="CapaNegocio.FachadaCapaNegocio"/>.
		/// </summary>
        public FachadaCapaNegocio()
        {
            iElementosCarteleriaHoy = iFachadaDatos.GetElementosCarteleriaHoy();
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
        public void AgregarElementoCarteleria(ElementoCarteleria pElementoCarteleria)
        {
            iFachadaDatos.Create(pElementoCarteleria);
        }

        public void ActualizarElementoCarteleria(ElementoCarteleria pElementoCarteleria)
        {
            iFachadaDatos.Update(pElementoCarteleria);
        }

        public ElementoCarteleria BuscarElementoCarteleria(int pId)
        {
            return iFachadaDatos.GetByIdElementoCarteleria(pId);
        }

        public ICollection<ElementoCarteleria> BusquedaAproxElementoCarteleria(string pNombre)
        {
            return iFachadaDatos.BusquedaAproximacionElementoCarteleria(pNombre);
        }

        public ICollection<ElementoCarteleria> GetAllElementosCarteleria()
        {
            return iFachadaDatos.GetAllElementosCarteleria();
        }

        public ICollection<ElementoCarteleria> GetAllElementosCarteleriaEntre(DateTime pFechaInicio, DateTime pFechaFin)
        {
            return iFachadaDatos.GetAllElementosCarteleriaEntre(pFechaInicio, pFechaFin);
        }

        public ICollection<ElementoCarteleria> ElementosCarteleriaHoy()
        {
            return iFachadaDatos.GetElementosCarteleriaHoy();
        }
        #endregion
        /*
		#region Métodos
		    #region Campaña
		    /// <summary>
		    /// Agregar una campaña.
		    /// </summary>
		    /// <param name="pCampaña">Campaña a agregar.</param>
            public void AgregarCampaña (Campaña pCampaña)
            {
			    //Deberíamos comprobar que los horarios cargados no se superpongan y sólo ahi agregarlos. Acá se nos fue a la mierda.
                iFachadaDatos.Create(pCampaña);
            }
		    /// <summary>
		    /// Actualizar una campaña.
		    /// </summary>
		    /// <param name="pCampaña">Campaña a actualizar.</param>
            public void ActualizarCampaña(Campaña pCampaña)
            {
                iFachadaDatos.Update(pCampaña);
            }
		    /// <summary>
		    /// Obtener todas las campañas.
		    /// </summary>
		    /// <returns>Todas las campañas.</returns>
		    public ICollection<ElementoCarteleria> GetAllCampañas()
            {
                return iFachadaDatos.GetAllCampañas();
            }
		    /// <summary>
		    /// Obtener todas las campañas entre dos fechas.
		    /// </summary>
		    /// <param name="pFechaInicial">Fecha inicial.</param>
		    /// <param name="pFechaFinal">Fecha final.</param>
		    public ICollection<ElementoCarteleria> GetAllCampañasEntre (DateTime pFechaInicial, DateTime pFechaFinal)
		    {
			    //Esto se podría usar para hacer consulta de que horarios están disponibles para contratar. Evitando tener que comprobar si cuando se agrega una campaña se superpone con otra.
			    //Podría ser una tabla con las fechas como filas y los intervalos de tiempo como columnas.
			    return iFachadaDatos.GetAllCampañasEntre (pFechaInicial, pFechaFinal);
		    }
		    /// <summary>
		    /// Verifica sí la campaña colisionaría con alguna campaña existente en horarios.
		    /// </summary>
		    /// <returns>Verdadero sí existe alguna colisión.
		    public Boolean ColisionaCampaña (ElementoCarteleria pElementoCarteleria)
		    {
			    ICollection<ElementoCarteleria> mCampañasExistentes = GetAllCampañasEntre (pElementoCarteleria.FechaInicio, pElementoCarteleria.FechaFin);
			    foreach (ElementoCarteleria mCampañaExistente in mCampañasExistentes) {
				    if (pElementoCarteleria.Colisiona(mCampañaExistente.Frecuencia)) {
					    return true;
				    }
			    }
			    return false;
		    }
            /// <summary>
            /// Devuelve las campañas que colisionan en horarios con <paramref name="pElementoCarteleria"/>
            /// </summary>
            public ICollection<ElementoCarteleria> ColisionesCampañas (ElementoCarteleria pElementoCarteleria)
		    {
			    List<ElementoCarteleria> mColisiones = new List<ElementoCarteleria> ();
			    ICollection<ElementoCarteleria> mElementoCarteleriaExistentes = GetAllCampañasEntre (pElementoCarteleria.FechaInicio, pElementoCarteleria.FechaFin);
			    foreach (ElementoCarteleria mElementoCarteleriaExistente in mElementoCarteleriaExistentes) {
				    if (pElementoCarteleria.Colisiona(mElementoCarteleriaExistente.Frecuencia)) {
					    mColisiones.Add (mElementoCarteleriaExistente);
				    }
			    }
			    return mColisiones;
		    }
		    #endregion
		    #region Banner Estático
		    /// <summary>
		    /// Agregar un banner estático
		    /// </summary>
		    /// <param name="pBanner">Banner a agregar.</param>
            public void AgregarBannerEstatico(BannerEstatico pBanner)
            {
                iFachadaDatos.Create(pBanner);
            }
		    /// <summary>
		    /// Actualizar un banner estático
		    /// </summary>
		    /// <param name="pBanner">Banner a actualizar.</param>
            public void ActualizarBannerEstatico(BannerEstatico pBanner)
            {
                iFachadaDatos.Update(pBanner);
            }
		    /// <summary>
		    /// Obtener todos los banners estáticos.
		    /// </summary>
		    public ICollection<ElementoCarteleria> GetAllBannersEstaticos()
            {
                return iFachadaDatos.GetAllBannersEst();
            }
		    #endregion
		    #region RSSFeed
		    /// <summary>
		    /// Agregar una fuente de RSS.
		    /// </summary>
		    /// <param name="pBanner">Fuente RSS a agregar.</param>
            public void AgregarRSSFeed(RSSFeed pBanner)
            {
                iFachadaDatos.Create(pBanner);
            }
		    /// <summary>
		    /// Actualizar una fuente de RSS.
		    /// </summary>
		    /// <param name="pBanner">Fuente RSS a agregar.</param>
            public void ActualizarRSSFeed(RSSFeed pBanner)
            {
                iFachadaDatos.Update(pBanner);
            }
		    /// <summary>
		    /// Obtener todas las fuentes RSS.
		    /// </summary>
		    public ICollection<ElementoCarteleria> GetAllRSSFeed()
            {
                return iFachadaDatos.GetAllRSSFeed();
            }
        #endregion
            #region Banners
            /// <summary>
            /// Obtener todas los banners entre dos fechas.
            /// </summary>
            /// <param name="pFechaInicial">Fecha inicial.</param>
            /// <param name="pFechaFinal">Fecha final.</param>
            public ICollection<ElementoCarteleria> GetAllBannersEntre(DateTime pFechaInicial, DateTime pFechaFinal)
            {
                //Esto se podría usar para hacer consulta de que horarios están disponibles para contratar. Evitando tener que comprobar si cuando se agrega una campaña se superpone con otra.
                //Podría ser una tabla con las fechas como filas y los intervalos de tiempo como columnas.
                return iFachadaDatos.GetAllBannersEntre(pFechaInicial, pFechaFinal);
            }
            /// <summary>
            /// Verifica sí el banner colisionaría con algun banner existente en horarios.
            /// </summary>
            /// <returns>Verdadero sí existe alguna colisión.
            public Boolean ColisionaBanner(ElementoCarteleria pElementoCarteleria)
            {
                ICollection<ElementoCarteleria> mElementoCarteleriaExistentes = GetAllBannersEntre(pElementoCarteleria.FechaInicio, pElementoCarteleria.FechaFin);
                foreach (ElementoCarteleria mElementoCarteleriaExistente in mElementoCarteleriaExistentes)
                {
                    if (pElementoCarteleria.Colisiona(mElementoCarteleriaExistente.Frecuencia))
                    {
                        return true;
                    }
                }
                return false;
            }
            /// <summary>
            /// Devuelve las campañas que colisionan en horarios con <paramref name="pElementoCarteleria"/>
            /// </summary>
            public ICollection<ElementoCarteleria> ColisionesBanner(ElementoCarteleria pElementoCarteleria)
            {
                List<ElementoCarteleria> mColisiones = new List<ElementoCarteleria>();
                ICollection<ElementoCarteleria> mElementoCarteleriaExistentes = GetAllBannersEntre(pElementoCarteleria.FechaInicio, pElementoCarteleria.FechaFin);
                foreach (ElementoCarteleria mElementoCarteleriaExistente in mElementoCarteleriaExistentes)
                {
                    if (pElementoCarteleria.Colisiona(mElementoCarteleriaExistente.Frecuencia))
                    {
                        mColisiones.Add(mElementoCarteleriaExistente);
                    }
                }
                return mColisiones;
            }
            #endregion
            #region Métodos del día
            /// <summary>
            /// Obtener las campañas pertenecientes al día de la fecha. Ordenadas por hora de inicio.
            /// </summary>
            public ICollection<ElementoCarteleria> CampañasHoy()
            {
			    SortedList<TimeSpan, ElementoCarteleria> resultado = new SortedList<TimeSpan, ElementoCarteleria>();
			    foreach (ElementoCarteleria campaña in iCampañasHoy) {
				    resultado.Add(campaña.GetHorarioHoy().HoraInicio,campaña);
			    }
			    return resultado.Values;
            }
		    /// <summary>
		    /// Obtener los banners pertenecientes al día de la fecha. Ordenados por hora de inicio.
		    /// </summary>
		    public ICollection<ElementoCarteleria> BannersHoy()
		    {
			    SortedList<TimeSpan, ElementoCarteleria> resultado = new SortedList<TimeSpan, ElementoCarteleria>();
			    foreach (BannerEstatico banner in iBannersEstaticosHoy) 
			    {
				    resultado.Add (banner.GetHorarioHoy().HoraInicio, banner);
			    }
			    //Convertir cada RSSFeed y sus noticias en un banner estático y agregarlos a la lista.
                foreach (RSSFeed rssfeed in iBannersRSSHoy)
                {
				    resultado.Add(rssfeed.GetHorarioHoy().HoraInicio, rssfeed.AsBannerEstático());
                }
			    return resultado.Values;
            }
		    #endregion
		    #region Búsqueda por nombre
		    /// <summary>
		    /// Buscar fuentes RSS por nombre.
		    /// </summary>
		    /// <param name="pNombre">Posible subcadena del nombre.</param>
		    public ICollection<RSSFeed> BusquedaAproxBannerRSS(string pNombre)
            {
                if (String.IsNullOrWhiteSpace(pNombre))
                {
                    throw new ArgumentNullException("Debe ingresar una cadena de búsqueda.");
                }

                return iFachadaDatos.BusquedaAproximacionRSSFeed(pNombre);
            }
		    /// <summary>
		    /// Buscar banners estáticos por nombre.
		    /// </summary>
		    /// <param name="pNombre">Posible subcadena del nombre.</param>
		    public ICollection<BannerEstatico> BusquedaAproxBannerEstatico(string pNombre)
            {
                if (String.IsNullOrWhiteSpace(pNombre))
                {
                    throw new ArgumentNullException("Debe ingresar una cadena de búsqueda.");
                }

                return iFachadaDatos.BusquedaAproximacionBannerEst(pNombre);
            }
		    /// <summary>
		    /// Buscar campañas por nombre.
		    /// </summary>
		    /// <param name="pNombre">Posible subcadena del nombre.</param>
		    public ICollection<Campaña> BusquedaAproxCampaña (string pNombre)
            {
                if (String.IsNullOrWhiteSpace(pNombre))
                {
                    throw new ArgumentNullException("Debe ingresar una cadena de búsqueda.");
                }

                return iFachadaDatos.BusquedaAproximacionCampaña(pNombre);
            }
		    #endregion
		    #region Búsqueda por Id
		    /// <summary>
		    /// Obtener una campaña por su Id
		    /// </summary>
		    /// <param name="pId">Identificador.</param>
            public Campaña BuscarCampaña(int pId)
            {
                return iFachadaDatos.GetByIdCampaña(pId);
            }
		    /// <summary>
		    /// Obtener un banner estático por su Id.
		    /// </summary>
		    /// <param name="pId">Identificador.</param>
            public BannerEstatico BuscarBannerEstatico(int pId)
            {
                return iFachadaDatos.GetByIdBannerEst(pId);
            }
		    /// <summary>
		    /// Buscar una fuente RSS por su Id.
		    /// </summary>
		    /// <param name="pId">Identificador.</param>
            public RSSFeed BuscarRSSFeed(int pId)
            {
                return iFachadaDatos.GetByIdRSSFeed(pId);
            }
		    #endregion
		#endregion
        */
    }
}
