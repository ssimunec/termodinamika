using System;
using System.Collections.Generic;
using System.Linq;
using org.mariuszgromada.math.mxparser;
using td.common;

namespace td.energetika.biogas
{
    public class SubstitucijaAnaliza : IAnalizaProblema
    {
        public SupstitucijaBiogasomZivotinje subsubstitucijaZivotinje;
        public SupstitucijaBiogasomBiomasa subsubstitucijaBiomasa;
        public double Q1;
        public double Q2;
        public double Q;

        public double m; // masa koonvencionalnog goriva koja se moze substituisati

        [UlazniParametar("Hd1", "Toplotna moc konvencionalnog goriva", "jedinica")]
        public double Hd1; //toplotna moc konvencionalnog goriva

        public double Qd; // dnevna kolicina energije od biogasa
        public double P;

        public SubstitucijaAnaliza(SupstitucijaBiogasomZivotinje subsubstitucijaZivotinje,
            SupstitucijaBiogasomBiomasa subsubstitucijaBiomasa)
        {
            this.subsubstitucijaZivotinje = subsubstitucijaZivotinje;
            this.subsubstitucijaBiomasa = subsubstitucijaBiomasa;
        }

        public void Analiza()
        {
            Q = UkupnaGodisnjaKolicinaToplote();

            m = MasaKonvencionalnogKojaSeMozeSupstituisati();

            Qd = DnevnaKolicinaEnergijeOdBioGasa();
        }

        private double UkupnaGodisnjaKolicinaToplote()
        {
            var jednacina = "Q1+Q2";

            var konkretnaJednacina = new Expression(jednacina);

            konkretnaJednacina.addConstants(new Constant("Q1", this.subsubstitucijaBiomasa.Qg));

            konkretnaJednacina.addConstants(new Constant("Q2", this.subsubstitucijaZivotinje.Qg));

            return konkretnaJednacina.calculate();
        }

        private double MasaKonvencionalnogKojaSeMozeSupstituisati()
        {
            var jednacina = "Q/Hd1";

            var konkretnaJednacina = new Expression(jednacina);

            konkretnaJednacina.addConstants(new Constant("Q", this.Q));

            konkretnaJednacina.addConstants(new Constant("Hd1", this.Hd1));

            return konkretnaJednacina.calculate();
        }

        private double DnevnaKolicinaEnergijeOdBioGasa()
        {
            var jednacina = "Q/tau";

            var konkretnaJednacina = new Expression(jednacina);

            konkretnaJednacina.addConstants(new Constant("Q", this.Q));

            konkretnaJednacina.addConstants(new Constant("tau", 365));

            return konkretnaJednacina.calculate();
        }
        
        public string[] Izvestaj()
        {
            var izvestaj = new List<string>();

            izvestaj.Add(Environment.NewLine);

            izvestaj.Add("Zadati parametri za analizu: ");

            (from f in this.GetType().GetFields()
                    where f.GetCustomAttributes(typeof(UlazniParametar), false).Any()
                    select new { Field = f, Atr = f.GetCustomAttributes(typeof(UlazniParametar), false).First() as UlazniParametar })
                .ToList().ForEach(p =>
                {
                    izvestaj.Add(p.Atr.Ime + " : " + p.Field.GetValue(this).ToString());
                });

            izvestaj.Add(Environment.NewLine);

            izvestaj.Add("Izracunati parametri: ");

            izvestaj.Add(Environment.NewLine);

            izvestaj.Add(String.Format("Ukupna kolicina toplote od biogasa: {0} [MJ]g", this.Q));

            izvestaj.Add(String.Format("Dnevna kolicina energije od biogasa: {0} [MJ]dan", this.Qd));

            izvestaj.Add(String.Format("Masa konv. goriva koje se moze supstituisati: {0} [kg]g", this.m));

            izvestaj.Add(Environment.NewLine);
            return izvestaj.ToArray();
        }
    }
}