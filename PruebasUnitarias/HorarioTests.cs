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
    public class HorarioTests
    {
        [TestMethod()]
        public void Colisiona_2New_TrueTest()
        {
            Horario H1 = new Horario();
            Horario H2 = new Horario();

            Assert.IsFalse(H1.Colisiona(H2));
        }

        [TestMethod()]
        public void Colisiona_Colision_TrueTest()
        {
            Horario H1 = new Horario(DayOfWeek.Friday, new TimeSpan(1500), new TimeSpan(2000));
            Horario H2 = new Horario(DayOfWeek.Friday, new TimeSpan(1800), new TimeSpan(2500));
            Assert.IsTrue(H1.Colisiona(H2));
        }

        [TestMethod()]
        public void Colisiona_NoColision_FalseTest()
        {
            Horario H1 = new Horario(DayOfWeek.Friday, new TimeSpan(1500), new TimeSpan(2000));
            Horario H2 = new Horario(DayOfWeek.Friday, new TimeSpan(2000), new TimeSpan(2500));
            Assert.IsFalse(H1.Colisiona(H2));
        }
    }
}