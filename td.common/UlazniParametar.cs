using System;

namespace td.common
{
    [AttributeUsage(AttributeTargets.Field)]
    public class UlazniParametar : Attribute
    {
        public string Ime { get; }
        public string Labela { get; }
        public string Jedinica { get; }

        public UlazniParametar(string ime, string labela, string jedinica)
        {
            Ime = ime;
            Labela = labela;
            Jedinica = jedinica;
        }
    }
}