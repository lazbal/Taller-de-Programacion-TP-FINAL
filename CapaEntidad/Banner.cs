using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace CapaEntidad
{
	/// <summary>
	/// Interfaz banner.
	/// </summary>
	public abstract class Banner : ElementoCarteleria
	{
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
