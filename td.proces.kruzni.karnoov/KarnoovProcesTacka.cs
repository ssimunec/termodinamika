using System;
using System.Collections.Generic;
using System.Linq;
using org.mariuszgromada.math.mxparser;

namespace td.proces.kruzni.karnoov
{
    public class KarnoovProcesTacka
    {
        public string Naziv { get; private set; }

        public int brojNode = 1;
        public double R;
        public double K;

        public KarnoovProcesTacka Prethodna { get; set; }
        public KarnoovProcesTacka Sledeca { get; set; }

        public string SlikaStanja
        {
            get
            {
                return "Tacka: " + this.Naziv +
                       Environment.NewLine +
                       this.Stanje.Select((vrednost) => $"{vrednost.Key}: {vrednost.Value?.ToString() ?? ""}")
                           .Aggregate((a, b) => a + Environment.NewLine + b);
            }
        }

        public Dictionary<string, double?> Stanje { get; private set; }

        public KarnoovProcesTacka(string naziv)
        {
            Naziv = naziv;
            this.PostaviStanje(null, null, null);
        }
        public void PostaviStanje(double? p, double? v, double? T)
        {
            if (p.HasValue)
            {
                p = double.IsNaN(p.Value) ? null : p;
            }

            if (v.HasValue)
            {
                v = double.IsNaN(v.Value) ? null : v;
            }

            if (T.HasValue)
            {
                T = double.IsNaN(T.Value) ? null : T;
            }

            this.Stanje = new Dictionary<string, double?> { { "p", p }, { "v", v }, { "T", T } };
        }

        public bool MozeApliciratiJednacinuStanja => Stanje.Values.Count(x => x.HasValue) >= 2;
        public TipProcesa ProcesKojiVodiDalje { get; set; }

        public bool ApliciratiJednacinuStanja()
        {
            if (MozeApliciratiJednacinuStanja)
            {
                var jednacine = GetJednacineStanja();

                var trebaNaci = Stanje.First(x => !x.Value.HasValue);

                var konkretnaJednacina = new Expression(jednacine[trebaNaci.Key]);

                Stanje.Where(x => x.Value != null).ToList().ForEach(s =>
                {
                    konkretnaJednacina.addConstants(new Constant(s.Key, s.Value.Value));
                });

                konkretnaJednacina.addConstants(new Constant("R", this.R));

                var rezultat = konkretnaJednacina.calculate();

                if (!double.IsNaN(rezultat))
                    this.Stanje[trebaNaci.Key] = rezultat;

                return true;
            }

            return false;
        }

        public Dictionary<String, String>  GetJednacineStanja()
        {
            // vazi ako je izotermski
            var jednacine = new Dictionary<string, string>();

            jednacine.Add("p", "(R*T)/v");
            jednacine.Add("v", "(R*T)/p");
            jednacine.Add("T", "(p*v)/R");

            return jednacine;
        }

        public Dictionary<String, String> GetJednacineZaKruzniCiklus()
        {
            var jednacine = new Dictionary<string, string>();

            return jednacine;
        }


        public bool ProveriPrethodnoStanje()
        {
            if (Prethodna.ProcesKojiVodiDalje == TipProcesa.Izotermski && Prethodna.Stanje["T"].HasValue && !Stanje["T"].HasValue)
            {
                Stanje["T"] = Prethodna.Stanje["T"];
            }

            if (Prethodna.ProcesKojiVodiDalje == TipProcesa.Izotermski)
            {
                //pv == pv
                var vrednostiKojeTrebaNaci = Stanje.Where(x => !x.Value.HasValue).ToList();

                foreach (var trebaNaci in vrednostiKojeTrebaNaci)
                {
                    if ((new string[] { "p", "v" }).Contains(trebaNaci.Key))
                    {
                        var jednacine = GetIzotermskeJednacine();

                        var konkretnaJednacina = new Expression(jednacine[trebaNaci.Key]);

                        Prethodna.Stanje.Where(x => x.Value != null).ToList().ForEach(s =>
                        {
                            konkretnaJednacina.addConstants(new Constant(s.Key + "1", s.Value.Value));
                        });

                        Stanje.Where(x => x.Value != null).ToList().ForEach(s =>
                        {
                            konkretnaJednacina.addConstants(new Constant(s.Key + "2", s.Value.Value));
                        });

                        DodajKonstante(konkretnaJednacina);

                        var rezultat = konkretnaJednacina.calculate();

                        if (!double.IsNaN(rezultat))
                            this.Stanje[trebaNaci.Key] = rezultat;
                    }
                }
            }

            if (this.Prethodna.ProcesKojiVodiDalje == TipProcesa.Izoenotropski)
            {
                var sveJednacine = GetIzenotropskeJednacine();

                foreach (var jednacine in sveJednacine)
                {
                    var vrednostiKojeTrebaNaci =
                        Stanje.Where(x => !x.Value.HasValue || double.IsNaN(x.Value.Value)).ToList();

                    foreach (var vrednostKojuTrebaNaci in vrednostiKojeTrebaNaci)
                    {
                        if (!jednacine.Keys.Contains(vrednostKojuTrebaNaci.Key + "2")) continue;

                        var konkretnaJednacina = new Expression(jednacine[vrednostKojuTrebaNaci.Key + "1"]);

                        Prethodna.Stanje.Where(x => x.Value != null).ToList().ForEach(s =>
                        {
                            konkretnaJednacina.addConstants(new Constant(s.Key + "1", s.Value.Value));
                        });

                        Stanje.Where(x => x.Value != null).ToList().ForEach(s =>
                        {
                            konkretnaJednacina.addConstants(new Constant(s.Key + "2", s.Value.Value));
                        });
                        
                        DodajKonstante(konkretnaJednacina);

                        var rezultat = konkretnaJednacina.calculate();

                        if (!double.IsNaN(rezultat))
                            this.Stanje[vrednostKojuTrebaNaci.Key] = rezultat;
                    }
                }
            }

            return false;
        }

        public bool ProveriSledeceStanje()
        {
            if (this.ProcesKojiVodiDalje == TipProcesa.Izoenotropski)
            {
                var sveJednacine = GetIzenotropskeJednacine();

                foreach (var jednacine in sveJednacine)
                {
                    var vrednostiKojeTrebaNaci =
                        Stanje.Where(x => !x.Value.HasValue || double.IsNaN(x.Value.Value)).ToList();

                    foreach (var vrednostKojuTrebaNaci in vrednostiKojeTrebaNaci)
                    {
                        if (!jednacine.Keys.Contains(vrednostKojuTrebaNaci.Key + "1")) continue;

                        var konkretnaJednacina = new Expression(jednacine[vrednostKojuTrebaNaci.Key + "1"]);

                        Stanje.Where(x => x.Value != null).ToList().ForEach(s =>
                        {
                            konkretnaJednacina.addConstants(new Constant(s.Key + "1", s.Value.Value));
                        });

                        Sledeca.Stanje.Where(x => x.Value != null).ToList().ForEach(s =>
                        {
                            konkretnaJednacina.addConstants(new Constant(s.Key + "2", s.Value.Value));
                        });

                        DodajKonstante(konkretnaJednacina);

                        var rezultat = konkretnaJednacina.calculate();

                        if (!double.IsNaN(rezultat))
                            this.Stanje[vrednostKojuTrebaNaci.Key] = rezultat;
                    }
                }
            }

            if (this.ProcesKojiVodiDalje == TipProcesa.Izotermski)
            {
                var vrednostiKojeTrebaNaci = Stanje.Where(x => !x.Value.HasValue).ToList();

                foreach (var trebaNaci in vrednostiKojeTrebaNaci)
                {
                    if ((new string[] { "p", "v" }).Contains(trebaNaci.Key))
                    {
                        var jednacine = GetIzotermskeJednacine();

                        var konkretnaJednacina = new Expression(jednacine[trebaNaci.Key]);

                        Stanje.Where(x => x.Value != null).ToList().ForEach(s =>
                        {
                            konkretnaJednacina.addConstants(new Constant(s.Key + "1", s.Value.Value));
                        });

                        Sledeca.Stanje.Where(x => x.Value != null).ToList().ForEach(s =>
                        {
                            konkretnaJednacina.addConstants(new Constant(s.Key + "2", s.Value.Value));
                        });

                        DodajKonstante(konkretnaJednacina);

                        var rezultat = konkretnaJednacina.calculate();

                        if (!double.IsNaN(rezultat))
                            this.Stanje[trebaNaci.Key] = rezultat;
                    }
                }
            }

            return false;
        }

        private void DodajKonstante(Expression konkretnaJednacina)
        {
            konkretnaJednacina.addConstants(new Constant("K", K));
            konkretnaJednacina.addConstants(new Constant("R", R));
        }


        public Dictionary<String, String> GetIzotermskeJednacine()
        {
            // vazi ako je izotermski
            var jednacine = new Dictionary<string, string>();

            jednacine.Add("p", "(p1*v1)/v2");
            jednacine.Add("v", "(p1*v1)/p2");

            return jednacine;
        }

        public List<Dictionary<String, String>> GetIzenotropskeJednacine()
        {
            var sve = new List<Dictionary<string, string>>();

            // 1
            var jednacine = new Dictionary<string, string>();

            jednacine.Add("V1", "V2/(T1/T2)^(1/(K - 1))");
            jednacine.Add("V2", "V1*(T1/T2)^(1/(K - 1))");

            jednacine.Add("T1", "T2*(V2/V1)^(K - 1)");
            jednacine.Add("T2", "T1*(V2/V1)^(1 - K)");

            sve.Add(jednacine);

            // 2
            jednacine = new Dictionary<string, string>();

            jednacine.Add("p1", "p2/(T2/T1)^(K/(K - 1))");
            jednacine.Add("p2", "p1*(T2/T1)^(K/(K - 1))");

            jednacine.Add("T1", "T2/(p2/p1)^((K - 1)/K)");
            jednacine.Add("T2", "T1*(p2/p1)^((K - 1)/K)");

            sve.Add(jednacine);
            
            // 3
            jednacine = new Dictionary<string, string>();

            jednacine.Add("V1", "V2/(p1/p2)^(1/K)");
            jednacine.Add("V2", "V1*(p1/p2)^(1/K)");

            jednacine.Add("p1", "p2*(V2/V1)^K");
            jednacine.Add("p2", "p1/(V2/V1)^K");

            sve.Add(jednacine);

            return sve;
        }
    }
}