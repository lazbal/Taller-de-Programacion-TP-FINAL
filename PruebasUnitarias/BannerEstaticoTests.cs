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
    public class BannerEstaticoTests
    {
        [TestMethod()]
        public void Mostrar_NewBanner_EmptyStringTest()
        {
            BannerEstatico mBE = new BannerEstatico();
            string ExpectedResult = "";
            string ActualResult = mBE.Mostrar();

            Assert.AreEqual(ExpectedResult, ActualResult);
        }

        [TestMethod()]
        public void Mostrar_NullText_EmptyStringTest()
        {
            BannerEstatico mBE = new BannerEstatico();
            mBE.Texto = null;
            string ExpectedResult = "";
            string ActualResult = mBE.Mostrar();

            Assert.AreEqual(ExpectedResult, ActualResult);
        }
    }
}