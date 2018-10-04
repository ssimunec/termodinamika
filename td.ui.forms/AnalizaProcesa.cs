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
    public partial class AnalizaProcesa : Form
    {
        private IAnalizaProblema problem;

        private FormHelper formHelper = new FormHelper();

        public AnalizaProcesa()
        {
            InitializeComponent();
        }

        public IAnalizaProblema Problem { get => problem; set => problem = value; }

        private void AnalizaProcesa_Load(object sender, EventArgs e)
        {
            formHelper.PopuniCombo(this.cmbParametar, this.problem);
        }
        
        private void btnDodela_Click(object sender, EventArgs e)
        {
            var velicina = cmbParametar.SelectedItem as UlazniParametar;

            formHelper.DodelaParametraProcesu(velicina, this.problem, this.scintilla1);
        }

        
    }
}
