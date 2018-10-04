using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using td.common;
using td.ui.forms.Karnoov;

namespace td.ui.forms
{
    public class FormHelper
    {
        public void PopuniCombo(ComboBox cmb, IAnalizaProblema problem)
        {
            var ulazneVelicine = (from f in problem.GetType().GetFields()
                                  where f.GetCustomAttributes(typeof(UlazniParametar), false).Any()
                                  select f.GetCustomAttributes(typeof(UlazniParametar), false).First()).ToList();

            foreach (var ulaznaVelicina in ulazneVelicine)
            {
                cmb.Items.Add(ulaznaVelicina);
            }
        }


        public bool DodelaParametraProcesu(UlazniParametar velicina, IAnalizaProblema problem, ScintillaNET.Scintilla scintilla)
        {
            if (velicina != null)
            {
                var propertys = from f in problem.GetType().GetFields()
                                where f.GetCustomAttributes(typeof(UlazniParametar), false).Any()
                                select new AnalizaProcesa.PropertyEx()
                                {
                                    Field = f,
                                    Atr = f.GetCustomAttributes(typeof(UlazniParametar), false).First() as UlazniParametar
                                };

                var property = (from p in propertys
                                where p.Atr.Ime == velicina.Ime
                                select p).FirstOrDefault();

                if (property != null)
                {
                    var dialog = new JednaVrednost();
                    dialog.label2.Text = property.Atr.Labela;

                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        property.Field.SetValue(problem, dialog.Vrednost);

                        return true;
                    }
                }
            }

            return false;
        }

        public void IzvestajIzProcesa(IAnalizaProblema proces, ScintillaNET.Scintilla scintilla, bool sacuvaj = false)
        {
            var izvestaj = new StringBuilder(sacuvaj ? scintilla.Text : string.Empty);

            var linije = proces.Izvestaj();

            foreach (var linija in linije)
            {
                izvestaj.Append(System.Environment.NewLine);
                izvestaj.Append(linija);
            }

            scintilla.Text = izvestaj.ToString();
        }
    }
}
