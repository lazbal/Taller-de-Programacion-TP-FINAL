using System;
using System.Collections.Generic;
using System.Linq;
using CapaEntidad;
using CapaNegocio;

namespace CapaVisual
{
    public static class FachadaCapaVisual
    {
        public static IEnumerable<RSSItem> LeerRSS(string pURL)
        {
            return FachadaCapaNegocio.LeerRSS(pURL);
        }

        public static void AgregarElementoCarteleria(ElementoCarteleria pElementoCarteleria)
        {
            FachadaCapaNegocio.AgregarElementoCarteleria(pElementoCarteleria);
        }

        public static void ActualizarElementoCarteleria(ElementoCarteleria pElementoCarteleria)
        {
            FachadaCapaNegocio.ActualizarElementoCarteleria(pElementoCarteleria);
        }

        public static ICollection<ElementoCarteleria> ObtenerElementosCarteleria()
        {
            return FachadaCapaNegocio.GetAllElementosCarteleria();
        }

        public static ICollection<ElementoCarteleria> ObtenerElementosCarteleriaEntre(DateTime pFechaInicio, DateTime pFechaFin)
        {
            return FachadaCapaNegocio.GetAllElementosCarteleriaEntre(pFechaInicio, pFechaFin);
        }

        public static ElementoCarteleria SiguienteElementoCarteleria()
        {
            ElementoCarteleria mSig = FachadaCapaNegocio.GetAllElementosCarteleria().FirstOrDefault();
            FachadaCapaNegocio.GetAllElementosCarteleria().Remove(mSig);
            FachadaCapaNegocio.GetAllElementosCarteleria().Add(mSig);
            return mSig;
        }

        public static ICollection<ElementoCarteleria> ObtenerElementosCarteleriaHoy()
        {
            return FachadaCapaNegocio.ElementosCarteleriaHoy();
        }

        public static ElementoCarteleria BuscarElementoCarteleria(Int64 pId)
        {
            return FachadaCapaNegocio.BuscarElementoCarteleria(pId);
        }

        public static ICollection<ElementoCarteleria> BusquedaAproxElementoCarteleria(string pTitulo)
        {
            return FachadaCapaNegocio.BusquedaAproxElementoCarteleria(pTitulo);
        }

        public static void ActualizarNoticiasHoy()
        {
            FachadaCapaNegocio.ActualizarNoticiasHoy();
        }

        public static void EliminarElementoCarteleria(Int64 pID)
        {
            FachadaCapaNegocio.EliminarElementoCarteleria(pID);
        }
    }
}
