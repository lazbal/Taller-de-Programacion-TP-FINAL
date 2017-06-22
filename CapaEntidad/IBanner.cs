using System;

namespace CapaEntidad
{
	public interface IBanner
    {
        /// <summary>
        /// Devuelve el texto a mostrar.
        /// </summary>
		string Mostrar();

        /// <summary>
        /// Representación string del objeto.
        /// </summary>
        string ToString();
    }
}

