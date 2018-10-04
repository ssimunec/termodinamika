using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using org.mariuszgromada.math.mxparser;

namespace td.ui.forms.Karnoov
{
    public partial class JednaVrednost : Form
    {
        public double Vrednost { get; set; }

        public JednaVrednost()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Vrednost = proveri(txtP_C , txtP);
        }

        private double proveri(TextBox source, TextBox target)
        {
            var konkretnaJednacina = new Expression(source.Text);

            var vrednost = konkretnaJednacina.calculate();

            target.Text = vrednost.ToString();

            return vrednost;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Vrednost = proveri(txtP_C, txtP);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void JednaVrednost_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Name = label2.Text;
        }
    }
}
