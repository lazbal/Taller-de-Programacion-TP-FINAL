using Microsoft.VisualStudio.TestTools.UnitTesting;
using CapaVisual;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaVisual.Tests
{
    [TestClass()]
    public class FachadaCapaVisualTests
    {
        [TestMethod()]
        public void FechaBaseHorariosTest()
        {
            DateTime ExpectedResult = new DateTime(1753,1,1);
            DateTime RealResult = FachadaCapaVisual.FechaBaseHorarios();
            Assert.AreEqual(ExpectedResult, RealResult);
        }
    }
}