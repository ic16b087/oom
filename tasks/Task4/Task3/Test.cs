using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Task3.Fussball;
using Task3.Tennis;

namespace Tests
{
    [TestFixture]

    class Test
    {
        [Test]
        public void SimpleTest()
        {
            Assert.IsTrue(1 == 1);
        }
    }

    public class F_PlayerTests
    {
        [Test]
        public void CanCreateF_Player()
        {
            var x = new F_Player("Burian", "Lukas", 156);

            Assert.IsTrue(x.VNAME == "Lukas");
            Assert.IsTrue(x.NNAME == "Burian");
            Assert.IsTrue(x.P_GROESSE == 156);
        }

        [Test]
        public void CannotCreateF_PlayerWithEmtyVNAME()
        {
            Assert.Catch(() =>
            {
                var x = new F_Player("Burian", "", 156);
            });
        }

        [Test]
        public void CannotCreateF_PlayerWithEmtyNNAME()
        {
            Assert.Catch(() =>
            {
                var x = new F_Player("", "Lukas", 156);
            });
        }

        [Test]
        public void CannotCreateF_PlayerWithTooSmallGROESSE()
        {
            Assert.Catch(() =>
            {
                var x = new F_Player("Burian", "Lukas", 20);
            });
        }

        [Test]
        public void CanUpdateF_PlayerGROESSE()
        {
                var x = new F_Player("Burian", "Lukas", 120);
                x.P_GROESSE = 140;
                Assert.IsTrue(x.P_GROESSE == 140);
        }

        [Test]
        public void CannotUpdateF_PlayerGROESSEWithNegativeValue()
        {
            Assert.Catch(() =>
            {
                var x = new F_Player("Burian", "Lukas", 120);
                x.P_GROESSE = -20;
            });
        }

        [Test]
        public void CanSetF_PlayerABLOESE()
        {
            var x = new F_Player("Burian", "Lukas", 120);
            x.ABLOESESUMME = 2000;
            Assert.IsTrue(x.ABLOESESUMME == 2000);
        }

        [Test]
        public void CannotUpdateF_PlayerABLOESEWithNegativeValue()
        {
            Assert.Catch(() =>
            {
                var x = new F_Player("Burian", "Lukas", 120);
                x.ABLOESESUMME = -20;
            });
        }
        [Test]
        public void CanAufschlagABLOSESUMME()
        {
            var x = new F_Player("Burian", "Lukas", 120);
            x.ABLOESESUMME = 2000;
            Assert.IsTrue(x.Aufschlag_Abloese() == 102000);
        }


    }

    public class T_PlayerTests
    {
        [Test]
        public void CanCreateT_Player()
        {
            var x = new T_Player("Burian", "Lukas", 156);

            Assert.IsTrue(x.VNAME == "Lukas");
            Assert.IsTrue(x.NNAME == "Burian");
            Assert.IsTrue(x.Update_GROESSE == 156);
        }

        [Test]
        public void CannotUpdateT_PlayerGROESSEWithNegativeValue()
        {
            Assert.Catch(() =>
            {
                var x = new T_Player("Burian", "Lukas", 120);
                x.Update_GROESSE = -20;
            });

        }

        [Test]
        public void CanGEHALT()
        {
            var x = new T_Player("Burian", "Lukas", 120);
            x.GEHALT_oeffentlich = 2000;
            Assert.IsTrue(x.GEHALT() == 1000);
        }

    }
}

