using org.mariuszgromada.math.mxparser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using td.common;

namespace td.energetika.geo
{
    //45
    public class GeotermalnaBusotina : IAnalizaProblema
    {
        // Karakteristike busotine - Tabela 19
        [UlazniParametar("Vx", "Vx", "Vx")]
        public double Vx;

        [UlazniParametar("tu", "Ulazna temperatura", "K")]
        public double tu; // t ulazno

        [UlazniParametar("ti", "Izlazna temperatura", "K")]
        public double ti; // t izlazno

        // Fizicke osobine vode - Tabela 1
        [UlazniParametar("ro", "Gustina vode", "Vx")]
        public double ro;

        [UlazniParametar("Cp", "Cp", "Vx")]
        public double Cp;

        //maseni protok geotermalnog izvora
        public double m;

        [UlazniParametar("nis", "Energetska efikasnost", "")]
        public double nis =  1; //efikasnost =1

        public double P; // kolicina toplote

        public double Qd; // dnevna kolicina toplote

        public double QdKwh;

        [UlazniParametar("tau", "Vreme u satima", "")]
        public double tau; // vreme u satima

        public double N; // broj stambenih jedinica

        [UlazniParametar("QsKwh", "Potrebna snaga po stambenoj jedinici", "Kwh")]
        public double QsKwh; // potrebna snaga po stambenoj jedinici

        public double QgkWh; //godisnja iskoristiva kolicina toplote

        public void Analiza()
        {
            this.m = MaseniProtokGeotermalnogIzvora();

            this.P = KolicinaToplote();

            this.Qd = DnevnaKolicinaToplote();

            this.QdKwh = DnevnaKolicinaToploteKwh();

            this.N = IzracunajBrojStambenihJedinica();

            this.QgkWh = GodisnjaIskorristivaKolicinaToplote();
        }
        
        public string[] Izvestaj()
        {
            var izvestaj = new List<string>();

            izvestaj.Add("Zadati parametri: ");

            (from f in this.GetType().GetFields()
                    where f.GetCustomAttributes(typeof(UlazniParametar), false).Any()
                    select new { Field = f, Atr = f.GetCustomAttributes(typeof(UlazniParametar), false).First() as UlazniParametar })
                .ToList().ForEach(p =>
                {
                    izvestaj.Add(p.Atr.Ime + " : " + p.Field.GetValue(this).ToString());
                });

            izvestaj.Add("Izracunati parametri: ");

            izvestaj.Add(String.Format("Maseni protok geoternalnog izvor {0} [kg/min]", this.m));

            izvestaj.Add(String.Format("Toplotna snaga geoternalnog izvor {0} [W]", this.P));

            izvestaj.Add(String.Format("Dnevna kolicina toplote geoternalnog izvor {0} [J]", this.Qd));

            izvestaj.Add(String.Format("Dnevna kolicina toplote geoternalnog izvor {0} [kWh]", this.QdKwh));

            izvestaj.Add(String.Format("Godisnja kolicina toplote geoternalnog izvor {0} [kWh]", this.QgkWh));

            return izvestaj.ToArray();
        }

        public double MaseniProtokGeotermalnogIzvora()
        {
            var jednacina = "ro*Vx";

            var konkretnaJednacina = new Expression(jednacina);

            konkretnaJednacina.addConstants(new Constant("ro", this.ro));

            konkretnaJednacina.addConstants(new Constant("Vx", this.Vx));


            return konkretnaJednacina.calculate();
        }

        public double KolicinaToplote()
        {
            var jednacina = "m*Cp*(tu-ti)*nis";


            var konkretnaJednacina = new Expression(jednacina);

            konkretnaJednacina.addConstants(new Constant("m", this.m));
            konkretnaJednacina.addConstants(new Constant("Cp", this.Cp));
            konkretnaJednacina.addConstants(new Constant("tu", this.tu));
            konkretnaJednacina.addConstants(new Constant("ti", this.ti));
            konkretnaJednacina.addConstants(new Constant("nis", this.nis));

            return konkretnaJednacina.calculate();
        }

        private double DnevnaKolicinaToplote()
        {
            var jednacina = "P*tau";

            var konkretnaJednacina = new Expression(jednacina);

            konkretnaJednacina.addConstants(new Constant("P", this.P));
            konkretnaJednacina.addConstants(new Constant("tau", this.tau));

            return konkretnaJednacina.calculate();
        }

        private double DnevnaKolicinaToploteKwh()
        {
            //var jednacina = "Qd * C";

            //var konkretnaJednacina = new Expression(jednacina);

            //konkretnaJednacina.addConstants(new Constant("Qd", this.Qd));
            //konkretnaJednacina.addConstants(new Constant("C", 2.777778 * Math.Pow(10, -7)));

            //
            return this.Qd * 2.777778 * Math.Pow(10, -7);
        }

        private double IzracunajBrojStambenihJedinica()
        {

            var jednacina = "QdKwh/QsKwh";

            var konkretnaJednacina = new Expression(jednacina);

            konkretnaJednacina.addConstants(new Constant("QdKwh", this.QdKwh));
            konkretnaJednacina.addConstants(new Constant("QsKwh", this.QsKwh));

            return konkretnaJednacina.calculate();

            //return this.QdKwh / this QsKwh;
        }

        private double GodisnjaIskorristivaKolicinaToplote()
        {
            var jednacina = "QdKwh*365";

            var konkretnaJednacina = new Expression(jednacina);

            konkretnaJednacina.addConstants(new Constant("QdKwh", this.QdKwh));

            return konkretnaJednacina.calculate();
        }

    }
}
