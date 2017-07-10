using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using CapaEntidad;
using CapaDatos;

namespace CapaNegocio
{
	/// <summary>
	/// Controlador de Campañas.
	/// </summary>
    public static class ControladorCampañas
    {
        #region Campañas
        /// <summary>
        /// Crea una entrada de <typeparamref name="Campaña"/>.
        /// </summary>
        /// <param name="pCampaña">Objeto a insertar.</param>
        public static void AgregarCampaña(Campaña pCampaña)
        {
            CapaDatosFachada.GetInstancia().Create(pCampaña);
        }

        /// <summary>
        /// Actualiza una entrada.
        /// </summary>
        /// <param name="pCamapaña">Objeto actualizado.</param>
        public static void ActualizarCampaña(Campaña pCampaña)
        {
            CapaDatosFachada.GetInstancia().Update(pCampaña);
        }

        /// <summary>
        /// Elimina una campaña por su Identificador
        /// </summary>
        /// <param name="pID">Identificador del objeto a eliminar</param>
        public static void EliminarCampaña(Int64 pID)
        {
            CapaDatosFachada.GetInstancia().Delete(CapaDatosFachada.GetInstancia().GetByIdCampaña(pID));
        }

        /// <summary>
        /// Elimina una campaña
        /// </summary>
        /// <param name="pCampaña">Objeto a eliminar</param>
        public static void EliminarCampaña(Campaña pCampaña)
        {
            CapaDatosFachada.GetInstancia().Delete(pCampaña);
        }

        /// <summary>
        /// Busca una entrada.
        /// </summary>
        /// <param name="pCampañaID">Id del objeto a buscar.</param>
        public static Campaña BuscarCampaña(Int64 pId)
        {
            return CapaDatosFachada.GetInstancia().GetByIdCampaña(pId);
        }

        /// <summary>
        /// Elimina una entrada.
        /// </summary>
        /// <param name="pCampaña">Objeto a eliminar.</param>
        public static ICollection<Campaña> BusquedaAproxCampaña(string pNombre)
        {
            return CapaDatosFachada.GetInstancia().BusquedaAproximacionCampaña(pNombre);
        }

        /// <summary>
        /// Obtener todas las campañas existentes.
        /// </summary>
        public static ICollection<Campaña> GetAllCampañas()
        {
            return CapaDatosFachada.GetInstancia().GetAllCampañas();
        }

        /// <summary>
        /// Obtener todas las campañas existentes, entre dos fechas.
        /// </summary>
        /// <param name="pFechaInicio">Fecha inicial en la que debe estar contenida el cartel.</param>
        /// <param name="pFechaFin">Fecha final en la que debe estar contenida el cartel.</param>
        /// <returns></returns>
        public static ICollection<Campaña> GetAllCampañasEntre(DateTime pFechaInicio, DateTime pFechaFin)
        {
            return CapaDatosFachada.GetInstancia().GetAllCampañasEntre(pFechaInicio, pFechaFin);
        }

        /// <summary>
        /// Obtener las campañas existentes para el día de la fecha.
        /// </summary>
        /// <returns></returns>
        public static ICollection<Campaña> CampañasHoy()
        {
            ICollection<Campaña> mCampañasHoy = new List<Campaña>();
            foreach (Campaña mB in CapaDatosFachada.GetInstancia().GetCampañasHoy())
            {
                if (mB.GetHorarioHoy() != null)
                {
                    mCampañasHoy.Add(mB);
                }
            }
            return mCampañasHoy;
        }
        #endregion
    }
}
