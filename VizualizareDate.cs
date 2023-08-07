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
    public partial class VizualizareDate : Form
    {
        
            public List<Vector3D> date;

            public VizualizareDate()
            {
                InitializeComponent();

                numericUpDownClustere.ValueChanged += numericUpDownClustere_ValueChanged;
                checkBoxRegresie.CheckedChanged += checkBoxRegresie_CheckedChanged;
                checkBoxDistantaMinima.CheckedChanged += checkBoxDistantaMinima_CheckedChanged;
                checkBoxDistantaMaxima.CheckedChanged += checkBoxDistantaMaxima_CheckedChanged;

                checkBoxVectori.Hide();
            }
            // grafic e de clasa ControlGrafic si include panel dublu bufferizat
            void checkBoxRegresie_CheckedChanged(object sender, EventArgs e)
            {
                if (checkBoxRegresie.Checked)
                {
                    checkBoxPolinomiala.Checked = false;
                    grafic.estimareRegresie = true;
                    grafic.tipRegresie = TipRegresie.Liniara;
                    grafic.regresie = new NorDePuncte(grafic.C3DataSeries);
                    grafic.regresie.DatePentruEstimare();
                    grafic.regresie.EstimareModel();
                    textBoxDetalii.AppendText("\r\n-Linear regression plane: \r\n z = " + Math.Round(grafic.regresie.a, 2));
                    if (grafic.regresie.b > 0)
                        textBoxDetalii.AppendText(" + ");
                    else
                        textBoxDetalii.AppendText(" - ");
                    textBoxDetalii.Text += Math.Abs(Math.Round(grafic.regresie.b, 2)) + " * x";
                    if (grafic.regresie.c > 0)
                        textBoxDetalii.AppendText(" + ");
                    else
                        textBoxDetalii.AppendText(" - ");
                    textBoxDetalii.AppendText(Math.Abs(Math.Round(grafic.regresie.c, 2)) + " * y" + "\r\n");
                }
                else
                    grafic.estimareRegresie = false;
                grafic.PanelDesen.Invalidate();
            }
            
            void numericUpDownClustere_ValueChanged(object sender, EventArgs e)
            {               // alegere nr clustere din numericUpDown
                KMeans kMeans = new KMeans(grafic.C3DataSeries, (int)numericUpDownClustere.Value);
                grafic.clustere = kMeans.getPointsClusters();
                grafic.PanelDesen.Invalidate();
            }

            void checkBoxDistantaMaxima_CheckedChanged(object sender, EventArgs e)
            {
                if (checkBoxDistantaMaxima.Checked)
                {
                    grafic.arataDistanteMaxime = true;
                    NorDePuncte norDePuncte = new NorDePuncte();
                    norDePuncte.dateVect = grafic.C3DataSeries;
                    norDePuncte.CalculeazaDistante();
                    textBoxDetalii.AppendText("\r\n-Maximum distance " + Math.Round(UtilitaraMatrici.Maxim(norDePuncte.matriceDistante), 2) + "\r\n");
                    List<Tuple<int, int>> distanteMaxime = UtilitaraMatrici.GetMaximIndexes(norDePuncte.matriceDistante);
                    grafic.distanteMaxime = new List<Tuple<Vector3D, Vector3D>>();
                    foreach (Tuple<int, int> t in distanteMaxime)
                    {
                        Tuple<Vector3D, Vector3D> segment = new Tuple<Vector3D, Vector3D>(grafic.C3DataSeries.PointList[t.Item1],
                            grafic.C3DataSeries.PointList[t.Item2]);
                        grafic.distanteMaxime.Add(segment);
                    }
                }
                else
                    grafic.arataDistanteMaxime = false;
                grafic.PanelDesen.Invalidate();
            }

            void checkBoxDistantaMinima_CheckedChanged(object sender, EventArgs e)
            {
                if (checkBoxDistantaMinima.Checked)
                {
                    grafic.arataDistanteMinime = true;
                    NorDePuncte norDePuncte = new NorDePuncte();
                    norDePuncte.dateVect = grafic.C3DataSeries;
                    norDePuncte.CalculeazaDistante();
                    textBoxDetalii.AppendText("\r\n-Minimum distance " + Math.Round(UtilitaraMatrici.Minim(norDePuncte.matriceDistante), 2) + "\r\n");
                    List<Tuple<int, int>> distanteMinime = UtilitaraMatrici.GetMinimIndexes(norDePuncte.matriceDistante);
                    grafic.distanteMinime = new List<Tuple<Vector3D, Vector3D>>();
                    foreach (Tuple<int, int> t in distanteMinime)
                    {
                        Tuple<Vector3D, Vector3D> segment = new Tuple<Vector3D, Vector3D>(grafic.C3DataSeries.PointList[t.Item1],
                            grafic.C3DataSeries.PointList[t.Item2]);
                        grafic.distanteMinime.Add(segment);
                    }
                }
                else
                    grafic.arataDistanteMinime = false;
                grafic.PanelDesen.Invalidate();
            }

            public ControlUtilizator.ControlGrafic Grafic
            {
                get { return grafic; }
                set { grafic = value; }
            }

            private void VizualizareDate_Resize(object sender, EventArgs e)
            {
                grafic.PanelDesen.Invalidate();
            }

            private void setariGraficToolStripMenuItem_Click(object sender, EventArgs e)
            {
                SetariGrafic setari = new SetariGrafic(Grafic, false);
                setari.ShowDialog();
                grafic.PanelDesen.Invalidate();
            }

            private void tabelDateToolStripMenuItem_Click(object sender, EventArgs e)
            {
                TabelDate tabel = new TabelDate(grafic.C3DataSeries);
                tabel.MdiParent = this.MdiParent;
                // tabel.Text = this.Text.Split('-')[1];
                tabel.Show();
            }

            private void checkBoxPolinomiala_CheckedChanged(object sender, EventArgs e)
            {
                if (checkBoxPolinomiala.Checked)
                {
                    checkBoxRegresie.Checked = false;
                    grafic.estimareRegresie = true;
                    grafic.tipRegresie = TipRegresie.Polinomiala;
                    grafic.regresie = new NorDePuncte(grafic.C3DataSeries);
                    grafic.regresie.DatePentruEstimare();
                    grafic.regresie.EstimarePolin();
                    textBoxDetalii.AppendText("\r\n-Polynomial regression plane:\r\n z = " + Math.Round(grafic.regresie.ap, 2));
                    if (grafic.regresie.bp > 0)
                        textBoxDetalii.AppendText(" + ");
                    else
                        textBoxDetalii.AppendText(" - ");
                    textBoxDetalii.Text += Math.Abs(Math.Round(grafic.regresie.bp, 2)) + " * x";
                    if (grafic.regresie.cp > 0)
                        textBoxDetalii.AppendText(" + ");
                    else
                        textBoxDetalii.AppendText(" - ");
                    textBoxDetalii.AppendText(Math.Abs(Math.Round(grafic.regresie.cp, 2)) + " * y");
                    if (grafic.regresie.dp > 0)
                        textBoxDetalii.AppendText(" + ");
                    else
                        textBoxDetalii.AppendText(" - ");
                    textBoxDetalii.AppendText(Math.Abs(Math.Round(grafic.regresie.dp, 2)) + " * x^2");
                    if (grafic.regresie.ep > 0)
                        textBoxDetalii.AppendText(" + ");
                    else
                        textBoxDetalii.AppendText(" - ");
                    textBoxDetalii.AppendText(Math.Abs(Math.Round(grafic.regresie.ep, 2)) + " * y^2");
                    if (grafic.regresie.fp > 0)
                        textBoxDetalii.AppendText(" + ");
                    else
                        textBoxDetalii.AppendText(" - ");
                    textBoxDetalii.AppendText(Math.Abs(Math.Round(grafic.regresie.fp, 2)) + " * x * y" + "\r\n");
                }
                else
                    grafic.estimareRegresie = false;
                grafic.PanelDesen.Invalidate();
            }

            private void checkBoxBaza_CheckedChanged(object sender, EventArgs e)
            {
                if (checkBoxBaza.Checked)
                {
                    checkBoxBazaCov.Checked = false;
                    checkBoxVectori.Show();
                    grafic.C3DataSeries.PointList = Vector3D.CopyList(date);
                    int nrElem = grafic.C3DataSeries.PointList.Count;
                    float[,] a = new float[nrElem, 3];
                    for (int i = 0; i < nrElem; i++)
                    {
                        a[i, 0] = grafic.C3DataSeries.PointList[i].X;
                        a[i, 1] = grafic.C3DataSeries.PointList[i].Y;
                        a[i, 2] = grafic.C3DataSeries.PointList[i].Z;
                    }
                    float[] w = new float[3];
                    float[,] v = new float[3, 3];
                    UtilitaraMatrici.SVD(a, nrElem, 3, w, v);
                    foreach (Vector3D vector in grafic.C3DataSeries.PointList)
                    {
                        float[] vect = new float[3];
                        vect[0] = vector.X;
                        vect[1] = vector.Y;
                        vect[2] = vector.Z;
                        float[] vectBazaNoua = UtilitaraMatrici.InmultireMatriceVector(UtilitaraMatrici.CalculInversa(v), vect);
                        vector.X = vectBazaNoua[0];
                        vector.Y = vectBazaNoua[1];
                        vector.Z = vectBazaNoua[2];
                    }
                    textBoxDetalii.AppendText("\r\nEigenvectors basis:\r\n");
                    textBoxDetalii.AppendText("b1: (" + Math.Round(v[0, 0], 2) + ", " + Math.Round(v[0, 1], 2) + ", " + Math.Round(v[0, 2], 2) + ")\r\n");
                    textBoxDetalii.AppendText("b2: (" + Math.Round(v[1, 0], 2) + ", " + Math.Round(v[1, 1], 2) + ", " + Math.Round(v[1, 2], 2) + ")\r\n");
                    textBoxDetalii.AppendText("b3: (" + Math.Round(v[2, 0], 2) + ", " + Math.Round(v[2, 1], 2) + ", " + Math.Round(v[2, 2], 2) + ")\r\n");
                    textBoxDetalii.AppendText("\r\nAssociated eigenvalues: \r\n");
                    textBoxDetalii.AppendText("l1 = " + Math.Round(w[0], 2) + "; l2 = " + Math.Round(w[1], 2) + "; l3 = " + Math.Round(w[2]) + "\r\n");

                    grafic.vectoriProprii = v;
                }
                else
                {
                    grafic.C3DataSeries.PointList = Vector3D.CopyList(date);
                    checkBoxVectori.Hide();
                    grafic.afisareVectoriProprii = false;
                    checkBoxVectori.Checked = false;
                }
                checkBoxPolinomiala.Checked = false;
                checkBoxRegresie.Checked = false;
                grafic.PanelDesen.Invalidate();
            }

            private void checkBoxVectori_CheckedChanged(object sender, EventArgs e)
            {
                if (checkBoxVectori.Checked)
                    grafic.afisareVectoriProprii = true;
                else
                    grafic.afisareVectoriProprii = false;
                grafic.PanelDesen.Invalidate();
            }

            private void checkBoxBazaCov_CheckedChanged(object sender, EventArgs e)
            {
                if (checkBoxBazaCov.Checked)
                {
                    checkBoxBaza.Checked = false;
                    checkBoxVectori.Show();
                    int nrElem = grafic.C3DataSeries.PointList.Count;
                    double[,] a = new double[nrElem, 3];
                    for (int i = 0; i < nrElem; i++)
                    {
                        a[i, 0] = grafic.C3DataSeries.PointList[i].X;
                        a[i, 1] = grafic.C3DataSeries.PointList[i].Y;
                        a[i, 2] = grafic.C3DataSeries.PointList[i].Z;
                    }

                    a = UtilitaraMatrici.NormalizareMatrice3Var(a);
                    double[,] cov = UtilitaraMatrici.MatriceCovarianta(a);

                    double[] wr;
                    double[] wi;
                    double[,] vl;
                    double[,] vr;

                    alglib.rmatrixevd(cov, 3, 3, out wr, out wi, out vl, out vr);
                    float[,] v = UtilitaraMatrici.ConvertMatrice(vl);

                    foreach (Vector3D vector in grafic.C3DataSeries.PointList)
                    {
                        float[] vect = new float[3];
                        vect[0] = vector.X;
                        vect[1] = vector.Y;
                        vect[2] = vector.Z;
                        float[] vectBazaNoua = UtilitaraMatrici.InmultireMatriceVector(UtilitaraMatrici.CalculInversa(v), vect);
                        vector.X = vectBazaNoua[0];
                        vector.Y = vectBazaNoua[1];
                        vector.Z = vectBazaNoua[2];
                    }

                    textBoxDetalii.AppendText("\r\nEigenvectors basis:\r\n");
                    textBoxDetalii.AppendText("b1: (" + Math.Round(v[0, 0], 2) + ", " + Math.Round(v[0, 1], 2) + ", " + Math.Round(v[0, 2], 2) + ")\r\n");
                    textBoxDetalii.AppendText("b2: (" + Math.Round(v[1, 0], 2) + ", " + Math.Round(v[1, 1], 2) + ", " + Math.Round(v[1, 2], 2) + ")\r\n");
                    textBoxDetalii.AppendText("b3: (" + Math.Round(v[2, 0], 2) + ", " + Math.Round(v[2, 1], 2) + ", " + Math.Round(v[2, 2], 2) + ")\r\n");
                    textBoxDetalii.AppendText("\r\nAssociated eigenvalues: \r\n");
                    textBoxDetalii.AppendText("l1 = " + Math.Round(wr[0], 2) + "; l2 = " + Math.Round(wr[1], 2) + "; l3 = " + Math.Round(wr[2]) + "\r\n");

                    grafic.vectoriProprii = v;
                }
                else
                {
                    grafic.C3DataSeries.PointList = Vector3D.CopyList(date);
                    checkBoxVectori.Hide();
                    grafic.afisareVectoriProprii = false;
                    checkBoxVectori.Checked = false;
                }
                checkBoxPolinomiala.Checked = false;
                checkBoxRegresie.Checked = false;
                grafic.PanelDesen.Invalidate();
            }


        }
    
}
