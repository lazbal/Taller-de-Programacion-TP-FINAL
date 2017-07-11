using System;
using CapaEntidad;
using System.Data.Entity;

namespace CapaDatos
{
    /// <summary>
    /// Clase contexto.
    /// </summary>
    public class CapaDatosContexto : DbContext
    {
		#region Constructores
        /// <summary>
        /// Constructor.
        /// </summary>
		public CapaDatosContexto() : base("name = Context")
		{
            Database.SetInitializer<CapaDatosContexto>(new DropCreateDatabaseIfModelChanges<CapaDatosContexto>());
        }
		#endregion
		#region Propiedades y Datos
        /// <summary>
        /// Propiedad Horario. Es un conjunto de <typeparamref name="Horario"/>
        /// </summary>
		public DbSet<Horario> Horario { get; set; }
        /// <summary>
        /// Propiedad ImagenCampaña. Es un conjunto de <typeparamref name="ImagenCampaña"/>
        /// </summary>
        public DbSet<ImagenCampaña> ImagenCampaña { get; set; }
        /// <summary>
        /// Propiedad ElementoCarteleria. Es un conjunto de <typeparamref name="ElementoCarteleria"/>
        /// </summary>
        public DbSet<ElementoCarteleria> ElementosCarteleria { get; set; }
        /// <summary>
        /// Propiedad Campaña. Es un conjunto de <typeparamref name="Campaña"/>
        /// </summary>
        public DbSet<Campaña> Campaña { get; set; }
        /// <summary>
        /// Propiedad BannerEstático. Es un conjunto de <typeparamref name="Banner"/>
        /// </summary>
        public DbSet<Banner> Banner { get; set; }
		#endregion
		#region Overrides
        //Sobreescribimos la creación de tablas para forzar la separación de clases abstractas y especificaciones.
		protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Campaña>()
                .ToTable("Campañas");

            modelBuilder.Entity<BannerEstatico>()
                .ToTable("BannersEstaticos");

            modelBuilder.Entity<RSSFeed>()
                .ToTable("RSSFeeds");

            modelBuilder.Entity<Horario>()
                .Property(h => h.HorarioId)
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<ImagenCampaña>()
                .Property(i => i.ImagenCampanaId)
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<ImagenCampaña>()
                .HasKey(i => new { i.ImagenCampanaId, i.refCampanaId });
        }
		#endregion
    }
}
