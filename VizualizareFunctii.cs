using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ControlUtilizator;

namespace ComponentLearning_3
{
    public partial class VizualizareFunctii : Form
    {
        Functii functii = new Functii();

        public VizualizareFunctii()
        {
            InitializeComponent();

            grafic.C3DrawChart.ChartType = TipuriDeGrafice.ChartTypeEnum.Surface;

            radioButtonFunctie1.Checked = true;
            functii.functie(grafic.C3DataSeries, grafic.C3Axes,
                new CalculFunctie(Functii.functie1), new InitializareAxe(Functii.initializareAxe1));
        }

        public ControlUtilizator.ControlGrafic Grafic
        {
            get { return grafic; }
            set { grafic = value; }
        }

        private void setariGraficToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetariGrafic setari = new SetariGrafic(Grafic, true);
            setari.ShowDialog();
            grafic.PanelDesen.Invalidate();
        }

        private void radioButtonFunctie1_CheckedChanged(object sender, EventArgs e)
        {
            functii.functie(grafic.C3DataSeries, grafic.C3Axes,
                new CalculFunctie(Functii.functie1), new InitializareAxe(Functii.initializareAxe1));
            grafic.PanelDesen.Invalidate();
        }

        private void radioButtonFunctie2_CheckedChanged(object sender, EventArgs e)
        {
            functii.functie(grafic.C3DataSeries, grafic.C3Axes,
                new CalculFunctie(Functii.functie2), new InitializareAxe(Functii.initializareAxe2));
            grafic.PanelDesen.Invalidate();
        }

        private void radioButtonFunctie3_CheckedChanged(object sender, EventArgs e)
        {
            functii.functie(grafic.C3DataSeries, grafic.C3Axes,
                new CalculFunctie(Functii.functie3), new InitializareAxe(Functii.initializareAxe1));
            grafic.PanelDesen.Invalidate();
        }

        private void radioBtnParabola3D_CheckedChanged(object sender, EventArgs e)
        {
            functii.functie(grafic.C3DataSeries, grafic.C3Axes,
                new CalculFunctie(Functii.parabola3D), new InitializareAxe(Functii.initializareAxe1));
            grafic.PanelDesen.Invalidate();
        }
    }
}
