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
    public class RSSFeedTests
    {
        [TestMethod()]
        public void Mostrar_NewRSSFeed_EmptyStringTest()
        {
            RSSFeed mRF = new RSSFeed();

            string ExpectedResult = "";
            string ActualResult = mRF.Mostrar();

            Assert.AreEqual(ExpectedResult, ActualResult);
        }

        [TestMethod()]
        public void Mostrar_NullUltimasNoticias_EmptyStringTest()
        {
            RSSFeed mRF = new RSSFeed();
            mRF.UltimasNoticias = null;

            string ExpectedResult = "";
            string ActualResult = mRF.Mostrar();

            Assert.AreEqual(ExpectedResult, ActualResult);
        }

        [TestMethod()]
        public void Mostrar_NoticiaExistente_EmptyStringTest()
        {
            RSSFeed mRF = new RSSFeed();
            ICollection<RSSItem> mLastNews = new List<RSSItem>()
            {
                new RSSItem(){ Titulo = "Uno", Cuerpo = "Noticia Uno" },
                new RSSItem(){ Titulo = "Dos", Cuerpo = "Noticia Dos" }
            };

            mRF.UltimasNoticias = mLastNews;

            string ExpectedResult = "Uno - Noticia Uno // Dos - Noticia Dos // ";
            string ActualResult = mRF.Mostrar();

            Assert.AreEqual(ExpectedResult, ActualResult);
        }
    }
}