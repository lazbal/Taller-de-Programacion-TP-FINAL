using System;
using System.Collections.Generic;
using System.Linq;
using CapaEntidad;
using CapaNegocio;

namespace CapaVisual
{
    public static class FachadaCapaVisual
    {
        public static DateTime FechaBaseHorarios()
        {
            //dd = Dia
            //MM = Mes (confundido con mm)
            //yyyy = Año en 4 dígitos
            return DateTime.ParseExact(@"01/01/1753", @"dd/MM/yyyy", null);
        }

        #region Banner

        public static IEnumerable<RSSItem> LeerRSS(string pURL)
        {
            return ControladorBanners.LeerRSS(pURL);
        }

        public static void AgregarBanner(Banner pBanner)
        {
            ControladorBanners.AgregarBanner(pBanner);
        }

        public static void ActualizarBanner(Banner pBanner)
        {
            ControladorBanners.ActualizarBanner(pBanner);
        }

        public static ICollection<Banner> ObtenerBanners()
        {
            return ControladorBanners.GetAllBanners();
        }

        public static ICollection<Banner> ObtenerBannersEntre(DateTime pFechaInicio, DateTime pFechaFin)
        {
            return ControladorBanners.GetAllBannersEntre(pFechaInicio, pFechaFin);
        }

        public static ICollection<Banner> ObtenerBannersHoy()
        {
            return ControladorBanners.BannersHoy();
        }

        public static Banner BuscarBanner(Int64 pId)
        {
            return ControladorBanners.BuscarBanner(pId);
        }

        public static ICollection<Banner> BusquedaAproxBanner(string pCadena)
        {
            return ControladorBanners.BusquedaAproxBanner(pCadena);
        }

        public static void ActualizarNoticiasHoy(ICollection<Banner> pBanners)
        {
            ControladorBanners.ActualizarNoticias(pBanners);
        }

        public static void EliminarBanner(Int64 pID)
        {
            ControladorBanners.EliminarBanner(pID);
        }
        #endregion
        #region Campaña
        public static void AgregarCampaña(Campaña pCampaña)
        {
            ControladorCampañas.AgregarCampaña(pCampaña);
        }

        public static void ActualizarCampaña(Campaña pCampaña)
        {
            ControladorCampañas.ActualizarCampaña(pCampaña);
        }

        public static ICollection<Campaña> ObtenerCampañas()
        {
            return ControladorCampañas.GetAllCampañas();
        }

        public static ICollection<Campaña> ObtenerCampañasEntre(DateTime pFechaInicio, DateTime pFechaFin)
        {
            return ControladorCampañas.GetAllCampañasEntre(pFechaInicio, pFechaFin);
        }

        public static ICollection<Campaña> ObtenerCampañasHoy()
        {
            return ControladorCampañas.CampañasHoy();
        }

        public static Campaña BuscarCampaña(Int64 pId)
        {
            return ControladorCampañas.BuscarCampaña(pId);
        }

        public static ICollection<Campaña> BusquedaAproxCampaña(string pCadena)
        {
            return ControladorCampañas.BusquedaAproxCampaña(pCadena);
        }

        public static void EliminarCampaña(Int64 pID)
        {
            ControladorCampañas.EliminarCampaña(pID);
        }
        #endregion
    }
}
