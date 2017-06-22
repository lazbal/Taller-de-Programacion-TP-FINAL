using System;
using System.Collections.Generic;
using System.Linq;
using CapaEntidad;
using CapaNegocio;

namespace CapaVisual
{
    public class FachadaCapaVisual
    {
        private IFachadaCapaNegocio iFachadaNegocio = new FachadaCapaNegocio();
        private ICollection<ElementoCarteleria> iElementosCarteleria;
        private Campaña iCampañaDefecto;
        private BannerEstatico iBannerDefecto;

        public FachadaCapaVisual()
        {
            iElementosCarteleria = iFachadaNegocio.GetAllElementosCarteleria();
            iCampañaDefecto = new Campaña();
            iCampañaDefecto.TiempoXImagen = new TimeSpan(0, 30, 0);
            iCampañaDefecto.AgregarImagen("CampañaDefecto.jpg");
            iBannerDefecto = new BannerEstatico();
            iBannerDefecto.Texto = "Contáctenos!!!";

        }

        public IEnumerable<RSSItem> LeerRSS(string pURL)
        {
            return iFachadaNegocio.LeerRSS(pURL);
        }

        public void AgregarElementoCarteleria(ElementoCarteleria pElementoCarteleria)
        {
            iFachadaNegocio.AgregarElementoCarteleria(pElementoCarteleria);
        }

        public void ActualizarElementoCarteleria(ElementoCarteleria pElementoCarteleria)
        {
            iFachadaNegocio.ActualizarElementoCarteleria(pElementoCarteleria);
        }

        public ICollection<ElementoCarteleria> ObtenerElementosCarteleria()
        {
            return iFachadaNegocio.GetAllElementosCarteleria();
        }

        public ICollection<ElementoCarteleria> ObtenerElementosCarteleriaEntre(DateTime pFechaInicio, DateTime pFechaFin)
        {
            return iFachadaNegocio.GetAllElementosCarteleriaEntre(pFechaInicio, pFechaFin);
        }

        public ElementoCarteleria SiguienteElementoCarteleria()
        {
            ElementoCarteleria mSig = iElementosCarteleria.FirstOrDefault();
            iElementosCarteleria.Remove(mSig);
            iElementosCarteleria.Add(mSig);
            return mSig;
        }

        public ICollection<ElementoCarteleria> ObtenerElementosCarteleriaHoy()
        {
            return iFachadaNegocio.ElementosCarteleriaHoy();
        }

        public ElementoCarteleria BuscarElementoCarteleria(Int64 pId)
        {
            return iFachadaNegocio.BuscarElementoCarteleria(pId);
        }

        public ICollection<ElementoCarteleria> BusquedaAproxElementoCarteleria(string pTitulo)
        {
            return iFachadaNegocio.BusquedaAproxElementoCarteleria(pTitulo);
        }

        public void ActualizarNoticiasHoy()
        {
            iFachadaNegocio.ActualizarNoticiasHoy();
        }

        public void EliminarElementoCarteleria(Int64 pID)
        {
            //ElementoCarteleria mElementoEliminar = iFachadaNegocio.BuscarElementoCarteleria(pID);
            iFachadaNegocio.EliminarElementoCarteleria(pID);
        }
    }
}
