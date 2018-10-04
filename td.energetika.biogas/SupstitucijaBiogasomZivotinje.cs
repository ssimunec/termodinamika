using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using org.mariuszgromada.math.mxparser;
using td.common;

namespace td.energetika.biogas
{
    public class SupstitucijaBiogasomZivotinje : IAnalizaProblema
    {
        //37

        [UlazniParametar("Vx", "Vx", "Vx")]
        public double Vx;

        [UlazniParametar("fb", "Faktor brojnosti", "")]
        public double fb; //faktor brojnosti

        [UlazniParametar("idealnaKolicinaMetana", "Idealna kolicina metana", "")]
        public double idealnaKolicinaMetana;

        [UlazniParametar("trenutnaKolicinaMetana", "Trenutna Kolicina Metana", "")]
        public double trenutnaKolicinaMetana;

        public double Hdx; //toplotna moc

        [UlazniParametar("Hd", "Toplotna moc idealnog 70% biogasa", "")]
        public double Hd; //toplotna moc idealnog 70% biogasa

        [UlazniParametar("N", "Broj grla", "jedinica")]
        public double N; // kolicina grla

        [UlazniParametar("ns", "Stepen iskoriscenja sistema za sagorevanje goriva", "jedinica")]
        public double ns; // stepen iskoriscenja sistema za sagorevanje goriva

        public double P; // dnevna toplotna snaga
        public double Qg;


        public void Analiza()
        {
            this.Hdx = ToplotnaMocBiogasa();

            this.P = DnevnaToplotnaSnaga();

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

        public double DnevnaToplotnaSnaga()
        {
            var jednacina = "Vx*fb*N*Hdx*ns";

            var konkretnaJednacina = new Expression(jednacina);

            konkretnaJednacina.addConstants(new Constant("Vx", this.Vx));

            konkretnaJednacina.addConstants(new Constant("fb", this.fb));

            konkretnaJednacina.addConstants(new Constant("N", this.N));

            konkretnaJednacina.addConstants(new Constant("Hdx", this.Hdx));

            konkretnaJednacina.addConstants(new Constant("ns", this.ns));

            return konkretnaJednacina.calculate();
        }

        public double GodisnjaKolicinaToplote()
        {
            var jednacina = "P*tau";

            var konkretnaJednacina = new Expression(jednacina);

            konkretnaJednacina.addConstants(new Constant("P", this.P));

            konkretnaJednacina.addConstants(new Constant("tau", 365));

            return konkretnaJednacina.calculate();
        }



        public string[] Izvestaj()
        {
            var izvestaj = new List<string>();

            izvestaj.Add("Zadati parametri za zivotinje: ");

            (from f in this.GetType().GetFields()
                    where f.GetCustomAttributes(typeof(UlazniParametar), false).Any()
                    select new { Field = f, Atr = f.GetCustomAttributes(typeof(UlazniParametar), false).First() as UlazniParametar })
                .ToList().ForEach(p =>
                {
                    izvestaj.Add(p.Atr.Ime + " : " + p.Field.GetValue(this).ToString());
                });

            izvestaj.Add("Izracunati parametri za zivotinje: ");

            izvestaj.Add(String.Format("Toplotna moc biogasa: {0} MJ/nm^3", Hdx));
            izvestaj.Add(String.Format("Dnevna toplotna snaga: {0} MJ/dan", P));
            izvestaj.Add(String.Format("Godisnja kolicina toplote: {0} MJ", Qg));

            izvestaj.Add(System.Environment.NewLine);

            return izvestaj.ToArray();
        }

    }
}
