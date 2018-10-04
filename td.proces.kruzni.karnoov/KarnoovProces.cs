using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using org.mariuszgromada.math.mxparser;
using td.common;

namespace td.proces.kruzni.karnoov
{
    public class KarnoovProces : IAnalizaProblema
    {
        public List<KarnoovProcesTacka> proces;
        public double stepenKorisnogDejstva;
        public double R;
        public double K;        
        public double Tp;
        public double Ti;
        public double qd;
        public double qo;
        public double Ikor;

        public KarnoovProces()
        {
            var n1 = new KarnoovProcesTacka("1");
            n1.ProcesKojiVodiDalje = TipProcesa.Izotermski;

            var n2 = new KarnoovProcesTacka("2");
            n2.ProcesKojiVodiDalje = TipProcesa.Izoenotropski;

            var n3 = new KarnoovProcesTacka("3");
            n3.ProcesKojiVodiDalje = TipProcesa.Izotermski;

            var n4 = new KarnoovProcesTacka("4");
            n4.ProcesKojiVodiDalje = TipProcesa.Izoenotropski;


            n1.Prethodna = n4;
            n1.Sledeca = n2;

            n2.Prethodna = n1;
            n2.Sledeca = n3;

            n3.Prethodna = n2;
            n3.Sledeca = n4;

            n4.Prethodna = n3;
            n4.Sledeca = n1;

            var adijabata1 = new AdijabatskiProcess(n2, n3);

            var adijabata2 = new AdijabatskiProcess(n4, n1);

            proces = new List<KarnoovProcesTacka>();

            proces.Add(n1);
            proces.Add(n2);
            proces.Add(n3);
            proces.Add(n4);            
        }

        public void PostaviKonstante(double R, double K)
        {
            proces.ForEach(n => n.R = R);
            proces.ForEach(n => n.K = K);

            this.R = R;
            this.K = K;
        }

        public void PostaviStanje(int tacka, double? p, double? v, double? T)
        {
            //tacke u nizu idu od nula
            proces[tacka-1].PostaviStanje(p, v, T);
        }

        public void Analiza()
        {
            proces.ForEach(n => n.R = R);
            proces.ForEach(n => n.K = K);

            foreach (var n in proces)
            {
                n.ApliciratiJednacinuStanja();
            }

            foreach (var n in proces)
            {
                foreach (var stanje in n.Stanje.Keys.ToList())
                {
                    n.ProveriPrethodnoStanje();
                    n.ProveriSledeceStanje();
                }
            }

            stepenKorisnogDejstva = StepenKorisnogDejstva();

            qd = OdrediKolicinaDovedeneToplote();
            qo = OdrediKolicinaOdvedeneToplote();
            Ikor = MehanickiRad();

        }

        private double MehanickiRad()
        {
            var jednacina = "qd - qo";

            var konkretnaJednacina = new Expression(jednacina);

            konkretnaJednacina.addConstants(new Constant("qd", Math.Abs(qd)));

            konkretnaJednacina.addConstants(new Constant("qo", Math.Abs(qo)));

            return konkretnaJednacina.calculate();
        }

        private double StepenKorisnogDejstva()
        {
            var jednacina = "(Ti-Tp)/Ti";

            var konkretnaJednacina = new Expression(jednacina);

            var izoterme = proces.Where(t => t.ProcesKojiVodiDalje == TipProcesa.Izotermski);

            var TiTacka = izoterme.OrderByDescending(t => t.Stanje["T"]).FirstOrDefault();
            var TpTacka = izoterme.OrderBy(t => t.Stanje["T"]).FirstOrDefault();

            Ti = TiTacka.Stanje["T"].Value;
            Tp = TpTacka.Stanje["T"].Value;

            konkretnaJednacina.addConstants(new Constant("Ti", TiTacka.Stanje["T"].Value));

            konkretnaJednacina.addConstants(new Constant("Tp", TpTacka.Stanje["T"].Value));

            return konkretnaJednacina.calculate();
        }
        
        private double OdrediKolicinaDovedeneToplote()
        {
            var jednacina = "R*Ti*ln(v2/v1)";

            var konkretnaJednacina = new Expression(jednacina);

            konkretnaJednacina.addConstants(new Constant("R", R));
            konkretnaJednacina.addConstants(new Constant("K", K));
            konkretnaJednacina.addConstants(new Constant("Ti", Ti));
            konkretnaJednacina.addConstants(new Constant("Tp", Tp));

            var v1 = proces[0].Stanje["v"].Value;
            var v2 = proces[1].Stanje["v"].Value;

            konkretnaJednacina.addConstants(new Constant("v1", v1));
            konkretnaJednacina.addConstants(new Constant("v2", v2));

            return konkretnaJednacina.calculate();
        }

        private double OdrediKolicinaOdvedeneToplote()
        {
            var jednacina = "R*Tp*ln(v4/v3)";

            var konkretnaJednacina = new Expression(jednacina);

            konkretnaJednacina.addConstants(new Constant("R", R));
            konkretnaJednacina.addConstants(new Constant("K", K));
            konkretnaJednacina.addConstants(new Constant("Ti", Ti));
            konkretnaJednacina.addConstants(new Constant("Tp", Tp));

            var v3 = proces[2].Stanje["v"].Value;
            var v4 = proces[3].Stanje["v"].Value;

            konkretnaJednacina.addConstants(new Constant("v3", v3));
            konkretnaJednacina.addConstants(new Constant("v4", v4));

            return konkretnaJednacina.calculate();
        }

        public string[] Izvestaj()
        {
            var izvestaj = new List<string>();

            izvestaj.Add("Konstante: ");

            izvestaj.Add(Environment.NewLine);

            izvestaj.Add("Univerzalna Gasna konstanta ( R ): " + R + " [ J/kgK ]");
            izvestaj.Add("Boltzmann-ova konstanta ( K ): " + K + " [ J/K ]");

            izvestaj.Add(Environment.NewLine);

            izvestaj.Add("Pocetno stanje: ");

            izvestaj.Add(Environment.NewLine);

            foreach (var p in proces)
            {
                izvestaj.Add("Tacka: " + p.Naziv);

                string[] keys = {"p", "v", "T"};

                var jedinice = new Dictionary<string, string>();
                jedinice.Add("p", "[ Pa ]");
                jedinice.Add("v", "[ m^3 ]");
                jedinice.Add("T", "[ K ]");

                foreach (var key in keys)
                {
                    
                    izvestaj.Add($"{key}: {(p.Stanje[key].HasValue ? p.Stanje[key]?.ToString() : string.Empty)}" + " " + jedinice[key]);
                }

                izvestaj.Add(Environment.NewLine);
            }

            izvestaj.Add("Koeficijent korisnog dejstva ( nt ): " + stepenKorisnogDejstva);
            izvestaj.Add("Kolicina dovedene toplote ( qd ): " + qd + " [ J/kg]");
            izvestaj.Add("Kolicina odvedene toplote ( qd ): " + qo + " [ J/kg]");
            izvestaj.Add("Dobjeni mehanicki rad (Ikor): " + Ikor + " [ J/kg ]");

            return izvestaj.ToArray();
        }
    }
}
