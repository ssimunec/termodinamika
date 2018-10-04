namespace td.proces.kruzni.karnoov
{
    public class AdijabatskiProcess
    {
        public KarnoovProcesTacka PocetnaTacka { get; }
        public KarnoovProcesTacka KrajnjaTacka { get; }

        public AdijabatskiProcess(KarnoovProcesTacka pocetnaTacka, KarnoovProcesTacka krajnjaTacka)
        {
            this.PocetnaTacka = pocetnaTacka;
            this.KrajnjaTacka = krajnjaTacka;
        }

        public bool PrimeniFormule()
        {

            return false;
        }

        public void GetJednacineStanjaAdijabat()
        {
            
        }
    }
}