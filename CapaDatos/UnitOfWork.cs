using System;
using CapaEntidad;

namespace CapaDatos
{
	/// <summary>
	/// Unit of work.
	/// </summary>
    public class UnitOfWork : IDisposable
	{
		#region Datos
		private CapaDatosContexto context = new CapaDatosContexto();
		private RepositorioGenerico<RSSItem> iRSSItemRepositorio;
		private RepositorioGenerico<Horario> iHorarioRepositorio;
		private RepositorioGenerico<Campaña> iCampañaRepositorio;
		private RepositorioGenerico<ImagenCampaña> iImagenCampañaRepositorio;
		private RepositorioGenerico<Banner> iBannerRepositorio;

		private bool disposed = false;
		#endregion
		#region Constructores
		/// <summary>
		/// Inicializa una instancia de la clase <see cref="UnitOfWork"/>.
		/// </summary>
		public UnitOfWork()
		{
		}
        #endregion
        #region Propiedades
		/// <summary>
		/// Obtiene el repositorio de <see cref="RSSItem"/> .
		/// </summary>
		/// <value>The RSS Item repositorio.</value>
        public RepositorioGenerico<RSSItem> RSSItemRepositorio
        {
            get
            {
                if (this.iRSSItemRepositorio == null)
                {
                    this.iRSSItemRepositorio = new RepositorioGenerico<RSSItem>(context);
                }
                return this.iRSSItemRepositorio;
            }
        }

		/// <summary>
		/// Obtiene el repositorio de <see cref="Horario"/> .
		/// </summary>
		/// <value>The Horario repositorio.</value>
        public RepositorioGenerico<Horario> HorarioRepositorio
        {
            get
            {
                if (this.iHorarioRepositorio == null)
                {
                    this.iHorarioRepositorio = new RepositorioGenerico<Horario>(context);
                }
                return this.iHorarioRepositorio;
            }
        }

		/// <summary>
		/// Obtiene el repositorio de <see cref="Campaña"/> .
		/// </summary>
		/// <value>The campaña repositorio.</value>
        public RepositorioGenerico<Campaña> CampañaRepositorio
        {
            get
            {
                if (this.iCampañaRepositorio == null)
                {
                    this.iCampañaRepositorio = new RepositorioGenerico<Campaña>(context);
                }
                return this.iCampañaRepositorio;
            }
        }

		/// <summary>
		/// Obtiene el repositorio de <see cref="ImagenCampaña"/>.
		/// </summary>
		/// <value>The imagen campaña repositorio.</value>
        public RepositorioGenerico<ImagenCampaña> ImagenCampañaRepositorio
        {
            get
            {
                if (this.iImagenCampañaRepositorio == null)
                {
                    this.iImagenCampañaRepositorio = new RepositorioGenerico<ImagenCampaña>(context);
                }
                return this.iImagenCampañaRepositorio;
            }
        }
        
		/// <summary>
		/// Obtiene el repositorio de <see cref="Banner"/>.
		/// </summary>
		/// <value>The banner est repositorio.</value>
        public RepositorioGenerico<Banner> BannerRepositorio
        {
            get
            {
                if (this.iBannerRepositorio == null)
                {
                    this.iBannerRepositorio = new RepositorioGenerico<Banner>(context);
                }
                return this.iBannerRepositorio;
            }
        }
		#endregion
		#region Métodos
		/// <summary>
		/// Guarda los cambios en el contexto.
		/// </summary>
        public void Save()
        {
            context.SaveChanges();
        }
		/// <summary>
		/// Despacha el contexto.
		/// </summary>
		/// <param name="disposing">Sí disposing es <c>true</c>.</param>
        protected void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }
		/// <summary>
		/// Libera los recursos utilizados por <see cref="CapaDatos.UnitOfWork"/> object.
		/// </summary>
		/// <remarks>Call <see cref="Dispose"/> when you are finished using the <see cref="CapaDatos.UnitOfWork"/>. The
		/// <see cref="Dispose"/> method leaves the <see cref="CapaDatos.UnitOfWork"/> in an unusable state. After calling
		/// <see cref="Dispose"/>, you must release all references to the <see cref="CapaDatos.UnitOfWork"/> so the garbage
		/// collector can reclaim the memory that the <see cref="CapaDatos.UnitOfWork"/> was occupying.</remarks>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
		#endregion
    }
}
