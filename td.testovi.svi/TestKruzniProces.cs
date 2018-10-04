using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using td.proces.kruzni.karnoov;

namespace td.testovi.svi
{
    [TestClass]
    public class TestKruzniProces
    {
        [TestMethod]
        public void TestKarnoov()
        {
            Console.WriteLine("Termodinamika test konzolna aplikacija");

            var c1 = new KarnoovProcesTacka();

            c1.PostaviStanje((60 * 10 ^ 5), null, 900);
            c1.R = 287;

            c1.ApliciratiJednacinuStanja();

            //Assert.AreEqual(c1.)
            Assert.AreEqual(c1.Stanje["p"], 605);
            Assert.AreEqual(Math.Round(c1.Stanje["v"].Value, 2), 426.94);
            Assert.AreEqual(c1.Stanje["T"], 900);
        }
    }
}
