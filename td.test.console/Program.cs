using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using org.mariuszgromada.math.mxparser;
using td.energetika.biogas;
using td.energetika.geo;
using td.proces.kruzni.karnoov;

namespace td.test.console
{
    class Program
    {
        static void Main(string[] args)
        {
            TestKarnoov();

            TestBioMasa();

            TestGeo();
        }

        private static void TestGeo()
        {
            var geo = new GeotermalnaBusotina();

            geo.Vx = 500 * Math.Pow(10, -3);            
            geo.ro = 990;
            geo.Cp = 4.174 * Math.Pow(10, 3);

            geo.tu = 55;
            geo.ti = 45;
            geo.nis = 1;

            geo.tau = 24 * 60;

            geo.QsKwh = 15;
            geo.Analiza();


            Izvestaj(geo.Izvestaj());
        }

        public static void Izvestaj(string[] sadrzaj)
        {
            foreach (var linija in sadrzaj)
            {
                Console.WriteLine(linija);
            }
        }

        private static void TestKarnoov()
        {
            KarnoovProces proces1 = new KarnoovProces();
            proces1.PostaviStanje(1, (60 * Math.Pow(10, 5)), null, 900);
            proces1.PostaviStanje(3, (1 * Math.Pow(10, 5)), null, 300);

            proces1.R = 287;
            proces1.K = 287;

            proces1.Analiza();

            proces1.Izvestaj();
        }

        private static void TestBioMasa()
        {
            SupstitucijaBiogasomZivotinje substitucijaZivotinje = new SupstitucijaBiogasomZivotinje();

            substitucijaZivotinje.Vx = 1.1;
            substitucijaZivotinje.fb = 1.2;

            substitucijaZivotinje.trenutnaKolicinaMetana = 60;
            substitucijaZivotinje.idealnaKolicinaMetana = 70;

            substitucijaZivotinje.Hd = 25.1;

            substitucijaZivotinje.N = 10;
            substitucijaZivotinje.ns = 0.90;

            substitucijaZivotinje.Analiza();

            Izvestaj(substitucijaZivotinje.Izvestaj());


            SupstitucijaBiogasomBiomasa supstitucijaBio = new SupstitucijaBiogasomBiomasa();

            supstitucijaBio.Vx = 0.25;
            supstitucijaBio.trenutnaKolicinaMetana = 60;
            supstitucijaBio.idealnaKolicinaMetana = 70;

            supstitucijaBio.Hd = 25.1;

            supstitucijaBio.m = (5 * Math.Pow(10, 3));

            supstitucijaBio.ns = 0.90;

            supstitucijaBio.Analiza();

            Izvestaj(supstitucijaBio.Izvestaj());

            SubstitucijaAnaliza analiza = new SubstitucijaAnaliza(substitucijaZivotinje, supstitucijaBio);

            analiza.Hd1 = 41.2;

            analiza.Analiza();
            Izvestaj(analiza.Izvestaj());

            Console.ReadLine();
        }
    }

   
}
