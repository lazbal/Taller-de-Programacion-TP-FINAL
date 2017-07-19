using Microsoft.VisualStudio.TestTools.UnitTesting;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad.Tests
{
    [TestClass()]
    public class ImagenCampañaTests
    {
        [TestMethod()]
        public void ImagenCampañaRutaSet_NewImagen_NullResultsTest()
        {
            ImagenCampaña mIC = new ImagenCampaña();

            string ExpectedRuta = null;
            string RealRuta = mIC.Ruta;

            Assert.AreEqual(ExpectedRuta, RealRuta);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException),
        "La ruta no puede ser nula")]
        public void ImagenCampañaRutaSet_NullRuta_ExceptionTest()
        {
            ImagenCampaña mIC = new ImagenCampaña(null);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException),
        "La ruta no puede ser vacía")]
        public void ImagenCampañaRutaSet_EmptyRuta_ExceptionTest()
        {
            ImagenCampaña mIC = new ImagenCampaña("");
        }

        [TestMethod()]
        [ExpectedException(typeof(System.IO.FileNotFoundException),
        "No se encontró el archivo")]
        public void ImagenCampañaRutaSet_NotFoundRuta_ExceptionTest()
        {
            ImagenCampaña mIC = new ImagenCampaña(@"C:\noesitis.jpg");
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException),
        "No se encontró el archivo")]
        public void ImagenCampañaRutaSet_WrongCharRuta_ExceptionTest()
        {
            ImagenCampaña mIC = new ImagenCampaña("C:\noesitis.jpg");
        }
    }
}