using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using td.common;
using td.energetika.biogas;
using td.ui.forms.Karnoov;

namespace td.ui.forms
{
    public partial class AnalizaProcesaBiomasa : Form
    {
        private FormHelper formHelper = new FormHelper();

        SupstitucijaBiogasomZivotinje substitucijaZivotinje = new SupstitucijaBiogasomZivotinje();

        SupstitucijaBiogasomBiomasa supstitucijaBio = new SupstitucijaBiogasomBiomasa();

        private SubstitucijaAnaliza substitucijaKonvencionalno; 

        public AnalizaProcesaBiomasa()
        {
            substitucijaKonvencionalno = new SubstitucijaAnaliza(substitucijaZivotinje, supstitucijaBio);

            InitializeComponent();
        }

        private void btnDodela_Click(object sender, EventArgs e)
        {
            if (formHelper.DodelaParametraProcesu(cmbZivotinje.SelectedItem as UlazniParametar, this.substitucijaZivotinje, this.scintilla1))
            {
                Izvestaj();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (formHelper.DodelaParametraProcesu(cmbBiomasa.SelectedItem as UlazniParametar, this.substitucijaZivotinje, this.scintilla1))
            {
                Izvestaj();
            }
        }

        private void AnalizaProcesaBiomasa_Load(object sender, EventArgs e)
        {
            formHelper.PopuniCombo(cmbZivotinje, substitucijaZivotinje);

            formHelper.PopuniCombo(cmbBiomasa, supstitucijaBio);

            formHelper.PopuniCombo(cmbAnaliza, substitucijaKonvencionalno);
        }

        private void Izvestaj()
        {
            formHelper.IzvestajIzProcesa(this.substitucijaZivotinje, scintilla1, false);
            formHelper.IzvestajIzProcesa(this.supstitucijaBio, scintilla1, true);
            formHelper.IzvestajIzProcesa(this.substitucijaKonvencionalno, scintilla1, true);

        }

        private void scintilla1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                substitucijaZivotinje.Analiza();
                supstitucijaBio.Analiza();

                substitucijaKonvencionalno.subsubstitucijaBiomasa = supstitucijaBio;
                substitucijaKonvencionalno.subsubstitucijaZivotinje = substitucijaZivotinje;

                substitucijaKonvencionalno.Analiza();
                }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            
            Izvestaj();
        }
    }
}
