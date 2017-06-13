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
		[Key, ForeignKey ("ElementoCarteleria")]
		public int refElementoCarteleriaId { get; set; }
        public virtual ElementoCarteleria ElementoCarteleria { get; set; }

        /// <summary>
        /// Devuelve el texto a mostrar.
        /// </summary>
		public abstract string Mostrar();

        public override string ToString()
        {
            return this.Mostrar();
        }
    }
}
