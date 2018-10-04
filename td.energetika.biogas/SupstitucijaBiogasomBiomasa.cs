using System;
using System.Collections.Generic;
using System.Linq;
using org.mariuszgromada.math.mxparser;
using td.common;

namespace td.energetika.biogas
{
    public class SupstitucijaBiogasomBiomasa : IAnalizaProblema
    {
        [UlazniParametar("Vx", "Vx", "Vx")]
        public double Vx;

        [UlazniParametar("idealnaKolicinaMetana", "Idealna kolicina metana", "")]
        public double idealnaKolicinaMetana;

        [UlazniParametar("trenutnaKolicinaMetana", "Trenutna Kolicina Metana", "")]
        public double trenutnaKolicinaMetana;

        public double Hdx; //toplotna moc

        [UlazniParametar("Hd", "Toplotna moc idealnog 70% biogasa", "")]
        public double Hd; //toplotna moc idealnog 70% biogasa

        [UlazniParametar("m", "Masa", "")]
        public double m;

        [UlazniParametar("ns", "Stepen iskoriscenja sistema za sagorevanje goriva", "jedinica")]
        public double ns;

        public double Qg;

        public void Analiza()
        {
            this.Hdx = ToplotnaMocBiogasa();
            this.Qg = GodisnjaKolicinaToplote();
        }

        public double ToplotnaMocBiogasa()
        {
            var jednacina = "(trenutna * Hd) / ideal";

            var konkretnaJednacina = new Expression(jednacina);

            konkretnaJednacina.addConstants(new Constant("ideal", this.idealnaKolicinaMetana));

            konkretnaJednacina.addConstants(new Constant("trenutna", this.trenutnaKolicinaMetana));

            konkretnaJednacina.addConstants(new Constant("Hd", this.Hd));

            return konkretnaJednacina.calculate();
        }

        public double GodisnjaKolicinaToplote()
        {
            var jednacina = "Vx*m*Hdx*ns";

            var konkretnaJednacina = new Expression(jednacina);

            konkretnaJednacina.addConstants(new Constant("Vx", this.Vx));

            konkretnaJednacina.addConstants(new Constant("m", this.m));

            konkretnaJednacina.addConstants(new Constant("Hdx", this.Hdx));

            konkretnaJednacina.addConstants(new Constant("ns", this.ns));

            return konkretnaJednacina.calculate();
        }

        

        public string[] Izvestaj()
        {
            var izvestaj = new List<string>();

            izvestaj.Add("Zadati parametri za biomasu: ");

            (from f in this.GetType().GetFields()
                    where f.GetCustomAttributes(typeof(UlazniParametar), false).Any()
                    select new { Field = f, Atr = f.GetCustomAttributes(typeof(UlazniParametar), false).First() as UlazniParametar })
                .ToList().ForEach(p =>
                {
                    izvestaj.Add(p.Atr.Ime + " : " + p.Field.GetValue(this).ToString());
                });

            izvestaj.Add("Izracunati parametri za zivotinje: ");

            izvestaj.Add(String.Format("Toplotna moc biomase: {0} MJ/nm^3", Hdx));
            izvestaj.Add(String.Format("Godisnja kolicina toplote biomasa: {0} [MJ]g", Qg));

            return izvestaj.ToArray();
        }

    }
}