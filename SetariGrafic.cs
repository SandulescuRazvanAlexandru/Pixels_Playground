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
    public partial class SetariGrafic : Form
    {
        ControlUtilizator.ControlGrafic grafic;
        HartaDeCulori cm = new HartaDeCulori();
        GroupBox tipGrafic;
        RadioButton suprafata;
        RadioButton scatterPlot;
        RadioButton meshContur;
        RadioButton cascada;
        RadioButton histograma;
        RadioButton suprafataSiContur;
        RadioButton meshZ;
        RadioButton mesh;
        public bool setariVizualizare = false;

        public SetariGrafic(ControlUtilizator.ControlGrafic grafic, bool setari)
        {
            InitializeComponent();
            this.grafic = grafic;
            this.setariVizualizare = setari;

            elevatieTB.Text = grafic.Unghiuri.Elevatie.ToString();
            azimutTB.Text = grafic.Unghiuri.Azimut.ToString();

            liniiX.Checked = grafic.C3Grid.ReteaX;
            liniiY.Checked = grafic.C3Grid.ReteaY;
            liniiZ.Checked = grafic.C3Grid.ReteaZ;

            liniiX.CheckedChanged += liniiX_CheckedChanged;
            liniiY.CheckedChanged += liniiY_CheckedChanged;
            liniiZ.CheckedChanged += liniiZ_CheckedChanged;

            albastruRB.CheckedChanged += albastruRB_CheckedChanged;
            portocaliuRB.CheckedChanged += portocaliuRB_CheckedChanged;
            verdeRB.CheckedChanged += verdeRB_CheckedChanged;
            culoriMultipleRB.CheckedChanged += culoriMultipleRB_CheckedChanged;

            elevatieTB.TextChanged += elevatieTB_TextChanged;
            azimutTB.TextChanged += azimutTB_TextChanged;


            tipGrafic = new GroupBox();
            tipGrafic.Location = new Point(groupBoxRetea.Location.X,
                groupBoxRetea.Location.Y + groupBoxRetea.Height + 10);
            tipGrafic.Width = groupBoxRetea.Width;
            tipGrafic.Height = 200;
            tipGrafic.Text = "Tip grafic";

            suprafata = new RadioButton();
            suprafata.Text = "Suprafata";
            suprafata.Location = new Point(10, 20);
            suprafata.CheckedChanged += suprafata_CheckedChanged;

            scatterPlot = new RadioButton();
            scatterPlot.Text = "Scatter plot";
            scatterPlot.CheckedChanged += scatterPlot_CheckedChanged;
            scatterPlot.Location = new Point(10, 40);

            meshContur = new RadioButton();
            meshContur.Text = "Mesh contur";
            meshContur.Location = new Point(10, 60);
            meshContur.CheckedChanged += meshContur_CheckedChanged;

            cascada = new RadioButton();
            cascada.Text = "Cascada";
            cascada.Location = new Point(10, 80);
            cascada.CheckedChanged += cascada_CheckedChanged;

            histograma = new RadioButton();
            histograma.Text = "Histograma";
            histograma.Location = new Point(10, 100);
            histograma.CheckedChanged += histograma_CheckedChanged;

            suprafataSiContur = new RadioButton();
            suprafataSiContur.Text = "Suprafata si contur";
            suprafataSiContur.Width = tipGrafic.Width - 10;
            suprafataSiContur.Location = new Point(10, 120);
            suprafataSiContur.CheckedChanged += suprafataSiContur_CheckedChanged;

            meshZ = new RadioButton();
            meshZ.Text = "Mesh Z";
            meshZ.Location = new Point(10, 140);
            meshZ.CheckedChanged += meshZ_CheckedChanged;
            mesh = new RadioButton();
            mesh.Text = "Mesh";
            mesh.Location = new Point(10, 160);
            mesh.CheckedChanged += mesh_CheckedChanged;

            // GroupBox
            tipGrafic.Controls.Add(suprafata);
            tipGrafic.Controls.Add(scatterPlot);
            tipGrafic.Controls.Add(meshContur);
            tipGrafic.Controls.Add(cascada);
            tipGrafic.Controls.Add(histograma);
            tipGrafic.Controls.Add(suprafataSiContur);
            tipGrafic.Controls.Add(meshZ);
            tipGrafic.Controls.Add(mesh);

            if (grafic.estimareRegresie || setariVizualizare)
            {
                // extinde zona vizibila daca sunt functii 3D unde pot fi alese suprafata, contur, mesh... 

                buttonOK.Location = new Point(buttonOK.Location.X,
                   tipGrafic.Location.Y + tipGrafic.Height + 10);
                this.Controls.Add(tipGrafic); // ataseaza si tipGrafic
            }
        }

        void scatterPlot_CheckedChanged(object sender, EventArgs e)
        {
            if (scatterPlot.Checked)
            {
                grafic.C3DrawChart.ChartTypeRegression = TipuriDeGrafice.ChartTypeEnum.Scatter;
                if (setariVizualizare)
                    grafic.C3DrawChart.ChartType = TipuriDeGrafice.ChartTypeEnum.Scatter;
                grafic.PanelDesen.Invalidate();
            }
        }

        void meshContur_CheckedChanged(object sender, EventArgs e)
        {
            if (meshContur.Checked)
            {
                grafic.C3DrawChart.ChartTypeRegression = TipuriDeGrafice.ChartTypeEnum.MeshContour;
                if (setariVizualizare)
                    grafic.C3DrawChart.ChartType = TipuriDeGrafice.ChartTypeEnum.MeshContour;
                grafic.PanelDesen.Invalidate();
            }
        }

        void cascada_CheckedChanged(object sender, EventArgs e)
        {
            if (cascada.Checked)
            {
                grafic.C3DrawChart.ChartTypeRegression = TipuriDeGrafice.ChartTypeEnum.Waterfall;
                if (setariVizualizare)
                    grafic.C3DrawChart.ChartType = TipuriDeGrafice.ChartTypeEnum.Waterfall;
                grafic.PanelDesen.Invalidate();
            }
        }

        void histograma_CheckedChanged(object sender, EventArgs e)
        {
            if (histograma.Checked)
            {
                grafic.C3DrawChart.ChartTypeRegression = TipuriDeGrafice.ChartTypeEnum.Bar3D;
                if (setariVizualizare)
                    grafic.C3DrawChart.ChartType = TipuriDeGrafice.ChartTypeEnum.Bar3D;
                grafic.PanelDesen.Invalidate();
            }
        }

        void suprafataSiContur_CheckedChanged(object sender, EventArgs e)
        {
            if (suprafataSiContur.Checked)
            {
                grafic.C3DrawChart.ChartTypeRegression = TipuriDeGrafice.ChartTypeEnum.SurfaceFillContour;
                if (setariVizualizare)
                    grafic.C3DrawChart.ChartType = TipuriDeGrafice.ChartTypeEnum.SurfaceFillContour;
                grafic.PanelDesen.Invalidate();
            }
        }

        void meshZ_CheckedChanged(object sender, EventArgs e)
        {
            if (meshZ.Checked)
            {
                grafic.C3DrawChart.ChartTypeRegression = TipuriDeGrafice.ChartTypeEnum.MeshZ;
                if (setariVizualizare)
                    grafic.C3DrawChart.ChartType = TipuriDeGrafice.ChartTypeEnum.MeshZ;
                grafic.PanelDesen.Invalidate();
            }
        }

        void mesh_CheckedChanged(object sender, EventArgs e)
        {
            if (mesh.Checked)
            {
                grafic.C3DrawChart.ChartTypeRegression = TipuriDeGrafice.ChartTypeEnum.Mesh;
                if (setariVizualizare)
                    grafic.C3DrawChart.ChartType = TipuriDeGrafice.ChartTypeEnum.Mesh;
                grafic.PanelDesen.Invalidate();
            }
        }

        void suprafata_CheckedChanged(object sender, EventArgs e)
        {
            if (suprafata.Checked)
            {
                grafic.C3DrawChart.ChartTypeRegression = TipuriDeGrafice.ChartTypeEnum.Surface;
                if (setariVizualizare)
                    grafic.C3DrawChart.ChartType = TipuriDeGrafice.ChartTypeEnum.Surface;
                grafic.PanelDesen.Invalidate();
            }
        }

        void azimutTB_TextChanged(object sender, EventArgs e)
        {
            try
            {
                grafic.Unghiuri.Azimut = float.Parse(azimutTB.Text);
                grafic.PanelDesen.Invalidate();
            }
            catch (Exception ex) { }
        }

        void elevatieTB_TextChanged(object sender, EventArgs e)
        {
            try
            {
                grafic.Unghiuri.Elevatie = float.Parse(elevatieTB.Text);
                grafic.PanelDesen.Invalidate();
            }
            catch (Exception ex) { }
        }

        private void albastruRB_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton cb = (RadioButton)sender;
            if (cb.Checked)
            {
                grafic.C3DrawChart.CMap = cm.Cool();
                grafic.PanelDesen.Invalidate();
            }
        }

        private void portocaliuRB_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton cb = (RadioButton)sender;
            if (cb.Checked)
            {
                grafic.C3DrawChart.CMap = cm.Spring();
                grafic.PanelDesen.Invalidate();
            }
        }

        private void verdeRB_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton cb = (RadioButton)sender;
            if (cb.Checked)
            {
                grafic.C3DrawChart.CMap = cm.Summer();
                grafic.PanelDesen.Invalidate();
            }
        }

        private void culoriMultipleRB_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton cb = (RadioButton)sender;
            if (cb.Checked)
            {
                grafic.C3DrawChart.CMap = cm.Jet();
                grafic.PanelDesen.Invalidate();
            }
        }

        void liniiZ_CheckedChanged(object sender, EventArgs e)
        {
            grafic.C3Grid.ReteaZ = !grafic.C3Grid.ReteaZ;
            grafic.PanelDesen.Invalidate();
        }

        void liniiX_CheckedChanged(object sender, EventArgs e)
        {
            grafic.C3Grid.ReteaX = !grafic.C3Grid.ReteaX;
            grafic.PanelDesen.Invalidate();
        }

        void liniiY_CheckedChanged(object sender, EventArgs e)
        {
            grafic.C3Grid.ReteaY = !grafic.C3Grid.ReteaY;
            grafic.PanelDesen.Invalidate();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
