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
    public class ElementoCarteleriaTests
    {
        [TestMethod()]
        public void GetHorarioHoy_NewElemento_NullTest()
        {
            ElementoCarteleria mEC = new Campaña();

            Horario ExpectedResult = null;
            Horario RealResult = mEC.GetHorarioHoy();

            Assert.AreEqual(ExpectedResult, RealResult);
        }

        [TestMethod()]
        public void GetHorarioHoy_TodayHorario_NotNullTest()
        {
            ElementoCarteleria mEC = new Campaña();
            mEC.Frecuencia.Add(new Horario(DateTime.Today.DayOfWeek, new TimeSpan(), new TimeSpan()));

            Horario RealResult = mEC.GetHorarioHoy();

            Assert.IsNotNull(RealResult);
        }

        [TestMethod()]
        public void TieneDia_NewElemento_FalseTest()
        {
            ElementoCarteleria mEC = new Campaña();
            bool TieneAlgunDia = false;

            foreach (DayOfWeek item in Enum.GetValues(typeof(DayOfWeek)))
            {
                if (mEC.TieneDia(item))
                {
                    TieneAlgunDia = true;
                }
            }

            Assert.IsFalse(TieneAlgunDia);
        }

        [TestMethod()]
        public void CompareTo_NewElemento_EqualToItselfTest()
        {
            ElementoCarteleria mEC1 = new Campaña();

            Assert.IsTrue(mEC1.CompareTo(mEC1) == 0);
        }

        [TestMethod()]
        public void CompareTo_NewElemento_LowerThanNullTest()
        {
            ElementoCarteleria mEC1 = new Campaña();

            Assert.IsTrue(mEC1.CompareTo(null) == -1);
        }

        [TestMethod()]
        public void CompareTo_2NewElementosWithoutHorarioHoy_FirstIsLowerTest()
        {
            ElementoCarteleria mEC1 = new Campaña();
            ElementoCarteleria mEC2 = new Campaña();

            Assert.IsTrue(mEC1.CompareTo(mEC2) == -1);
        }

        [TestMethod()]
        public void CompareTo_2NewElementos_TheOneWithHorarioHoyIsLowerTest()
        {
            ElementoCarteleria mEC1 = new Campaña();
            ElementoCarteleria mEC2 = new Campaña();
            mEC2.Frecuencia.Add(new Horario(DateTime.Today.DayOfWeek, new TimeSpan(), new TimeSpan()));

            Assert.IsTrue(mEC2.CompareTo(mEC1) == -1);
        }

        [TestMethod()]
        public void CompareTo_2NewElementosWithHorarioHoy_TheOneWithLowerHoraInicioIsLowerTest()
        {
            ElementoCarteleria mEC1 = new Campaña();
            mEC1.Frecuencia.Add(new Horario(DateTime.Today.DayOfWeek, new TimeSpan(1000), new TimeSpan()));
            ElementoCarteleria mEC2 = new Campaña();
            mEC2.Frecuencia.Add(new Horario(DateTime.Today.DayOfWeek, new TimeSpan(500), new TimeSpan()));

            Assert.IsTrue(mEC1.CompareTo(mEC2) == 1);
        }

        [TestMethod()]
        public void CompareTo_2NewElementosWithSameHoraInicio_AreEqualTest()
        {
            ElementoCarteleria mEC1 = new Campaña();
            mEC1.Frecuencia.Add(new Horario(DateTime.Today.DayOfWeek, new TimeSpan(500), new TimeSpan()));
            ElementoCarteleria mEC2 = new Campaña();
            mEC2.Frecuencia.Add(new Horario(DateTime.Today.DayOfWeek, new TimeSpan(500), new TimeSpan()));

            Assert.IsTrue(mEC1.CompareTo(mEC2) == 0);
        }
    }
}