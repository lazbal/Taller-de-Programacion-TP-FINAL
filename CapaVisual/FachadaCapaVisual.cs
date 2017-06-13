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

        public ElementoCarteleria BuscarElementoCarteleria(int pId)
        {
            return iFachadaNegocio.BuscarElementoCarteleria(pId);
        }

        public ICollection<ElementoCarteleria> BusquedaAproxElementoCarteleria(string pTitulo)
        {
            return iFachadaNegocio.BusquedaAproxElementoCarteleria(pTitulo);
        }
        /*
        public void AgregarCampaña(Campaña pCampaña)
        {
            iFachadaNegocio.AgregarCampaña(pCampaña);
        }

        public void ActualizarCampaña(Campaña pCampaña)
        {
            iFachadaNegocio.ActualizarCampaña(pCampaña);
        }

        public IList<Campaña> ObtenerCampañas()
        {
            return iFachadaNegocio.GetAllCampañas();
        }

        public void AgregarBannerEstatico(BannerEstatico pBanner)
        {
            iFachadaNegocio.AgregarBannerEstatico(pBanner);
        }

        public void ActualizarBannerEstatico(BannerEstatico pBanner)
        {
            iFachadaNegocio.ActualizarBannerEstatico(pBanner);
        }

        public IList<BannerEstatico> ObtenerBannersEstaticos()
        {
            return iFachadaNegocio.GetAllBannersEstaticos();
        }

        public void AgregarRssFeed(RSSFeed pBanner)
        {
            iFachadaNegocio.AgregarRssFeed(pBanner);
        }

        public void ActualizarRssFeed(RSSFeed pBanner)
        {
            iFachadaNegocio.ActualizarRssFeed(pBanner);
        }

        public IList<RSSFeed> ObtenerRssFeed()
        {
            return iFachadaNegocio.GetAllRssFeed();
        }

        public Campaña SiguienteCampaña()
        {
            Campaña mSig = iCampañas.FirstOrDefault();
            iCampañas.Remove(mSig);
            iCampañas.Add(mSig);
            return mSig;
        }

        public BannerEstatico SiguienteBanner()
        {
            BannerEstatico mSig = iBanners.FirstOrDefault();
            iBanners.Remove(mSig);
            iBanners.Add(mSig);
            return mSig;
        }

        public IList<Campaña> ObtenerCampañasHoy ()
        {
            return iFachadaNegocio.CampañasHoy();
        }

        public IList<BannerEstatico> ObtenerBannersHoy()
        {
            return iFachadaNegocio.BannersHoy();
        }

        public Campaña BuscarCampaña(int pId)
        {
            return iFachadaNegocio.BuscarCampaña(pId);
        }

        public BannerEstatico BuscarBannerEstatico(int pId)
        {
            return iFachadaNegocio.BuscarBannerEstatico(pId);
        }

        public RSSFeed BuscarRssFeed(int pId)
        {
            return iFachadaNegocio.BuscarRssFeed(pId);
        }

        public IList<Campaña> BusquedaAproxCampaña (string pTitulo)
        {
            return iFachadaNegocio.BusquedaAproxCampaña(pTitulo);
        }

        public IList<BannerEstatico> BusquedaAproxBannerEstatico (string pTitulo)
        {
            return iFachadaNegocio.BusquedaAproxBannerEstatico(pTitulo);
        }

        public IList<RSSFeed> BusquedaAproxBannerRss(string pTitulo)
        {
            return iFachadaNegocio.BusquedaAproxBannerRSS(pTitulo);
        }

        public IEnumerable<RSSItem> LeerRss(string pURL)
        {
            return iFachadaNegocio.LeerRSS(pURL);
        }
        */
    }
}
