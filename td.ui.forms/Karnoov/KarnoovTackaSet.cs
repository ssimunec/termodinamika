using org.mariuszgromada.math.mxparser;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace td.ui.forms.Karnoov
{
    public partial class KarnoovTackaSet : Form
    {
        public double? T { get; set; }
        public double? V { get; set; }
        public double? P { get; set; }

        public KarnoovTackaSet()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ProveriSve();
         
            if (MessageBox.Show(this, "Da li su uneti podaci tacni ?", "Provera",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.OK;

                this.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ProveriSve();
        }

        private void ProveriSve()
        {
            this.T = proveri(txtT_C, txtT);
            this.P = proveri(txtP_C, txtP);
            this.V = proveri(txtV_C, txtV);
        }
        
        private double proveri(TextBox source, TextBox target)
        {
            var konkretnaJednacina = new Expression(source.Text);

            var vrednost = konkretnaJednacina.calculate();

            target.Text = vrednost.ToString();

            return vrednost;
        }

        private void textBox_Change(object sender, EventArgs e)
        {
            ProveriSve();
        }

        public void PodesiVrednosti(int tacka, double? p, double? v, double? T)
        {
            this.T = T;
            this.V = v;
            this.P = p;

            this.lblNazivTacke.Text = String.Format("Vrednosti u tacki {0}", tacka);

            ProveriSve();
        }

    }
}
