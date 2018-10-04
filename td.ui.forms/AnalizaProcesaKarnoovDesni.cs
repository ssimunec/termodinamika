using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using td.proces.kruzni.karnoov;
using td.ui.forms.Karnoov;

namespace td.ui.forms
{
    public partial class AnalizaProcesaKarnoovDesni : Form
    {

        private double R = double.NaN;
        private double K = double.NaN;

        public Dictionary<int, Tuple<double?, double?, double?>> parametri = 
            new Dictionary<int, Tuple<double?, double?, double?>>();

        public AnalizaProcesaKarnoovDesni()
        {
            InitializeComponent();

            this.scintilla1.Text = string.Empty;

            InicijalizacijaParametara();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            PrikaziDialogZaTacku(1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PrikaziDialogZaTacku(2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PrikaziDialogZaTacku(3);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            PrikaziDialogZaTacku(4);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            UnosUniverzalneGasneKonstante();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            UnosBoltzmannoveKonstante();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            var poruka = this.Provera();
            if (!string.IsNullOrWhiteSpace(poruka))
            {
                MessageBox.Show(this, poruka, @"Greska !", MessageBoxButtons.OK);

                return;
            }
            
            var tProces = new KarnoovProces();

            tProces.R = this.R;
            tProces.K = this.K;

            foreach (var key in this.parametri.Keys)
            {
                tProces.PostaviStanje(key, parametri[key].Item1, parametri[key].Item2, parametri[key].Item3);
            }

            try
            {
                tProces.Analiza();
            }
            catch (Exception exception)
            {
                this.scintilla1.Text = exception.Message + Environment.NewLine + exception.Source;
            }
            

            IzvestajIzProcesa(tProces);
        }

        private void InicijalizacijaParametara()
        {
            parametri[1] = new Tuple<double?, double?, double?>(null, null, null);
            parametri[2] = new Tuple<double?, double?, double?>(null, null, null);
            parametri[3] = new Tuple<double?, double?, double?>(null, null, null);
            parametri[4] = new Tuple<double?, double?, double?>(null, null, null);
        }

        private void IzvestajBezAnalize()
        {
            var tProces = new KarnoovProces();

            tProces.R = this.R;
            tProces.K = this.K;

            foreach (var key in this.parametri.Keys)
            {
                tProces.PostaviStanje(key, parametri[key].Item1, parametri[key].Item2, parametri[key].Item3);
            }

            IzvestajIzProcesa(tProces);
        }

        private void IzvestajIzProcesa(KarnoovProces proces)
        {
            var izvestaj = new StringBuilder();

            var linije = proces.Izvestaj();

            foreach (var linija in linije)
            {
                if(linija != System.Environment.NewLine)
                    izvestaj.Append(System.Environment.NewLine);

                izvestaj.Append(linija);
            }

            this.scintilla1.Text = izvestaj.ToString();
        }

        private string Provera()
        {
            List<string> poruke = new List<string>();

            if (double.IsNaN(this.K))
                poruke.Add("Molim vas unesite Boltzmann-ovu konstantu [ K ]");

            if (double.IsNaN(this.R))
                poruke.Add("Molim vas unesite univerzalnu gasnu konstantu [ R ]");

            return poruke.Aggregate("", (p, a) => a = a + "\n" + p );
        }

        private void PrikaziDialogZaTacku(int tacka)
        {
            var dialog = new KarnoovTackaSet();

            var parametriZaTacku = parametri[tacka];

            dialog.PodesiVrednosti(tacka, parametriZaTacku.Item1, parametriZaTacku.Item2, parametriZaTacku.Item3);

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                parametri[tacka] = new Tuple<double?, double?, double?>(dialog.P, dialog.V, dialog.T);

                IzvestajBezAnalize();
            }
        }

        private void UnosUniverzalneGasneKonstante()
        {
            var dialog = new JednaVrednost();
            dialog.label2.Text = "R:";
            dialog.lblJedinica.Text = @"[ J/kgK ]";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                this.R = dialog.Vrednost;
                IzvestajBezAnalize();
            }
        }

        private void UnosBoltzmannoveKonstante()
        {
            var dialog = new JednaVrednost();
            dialog.label2.Text = "K:";

            dialog.lblJedinica.Text = @"";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                this.K = dialog.Vrednost;
                IzvestajBezAnalize();
            }
        }
    }
}
