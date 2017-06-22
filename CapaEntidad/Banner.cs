using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace CapaEntidad
{
	/// <summary>
	/// Interfaz banner.
	/// </summary>
	public abstract class Banner : IBanner
	{
        /// <summary>
        /// Clave foránea del elemento cartelería. Funciona como clave principal del banner.
        /// </summary>
        [Key, ForeignKey ("ElementoCarteleria")]
		public Int64 refElementoCarteleriaId { get; set; }
        public virtual ElementoCarteleria ElementoCarteleria { get; set; }

        /// <summary>
        /// Devuelve el texto a mostrar.
        /// </summary>
		public abstract string Mostrar();

        /// <summary>
        /// Representación string del objeto.
        /// </summary>
        public override abstract string ToString();
    }
}
