using ComponentLearning_1;
using ComponentLearning_2;
using ComponentLearningAnalizaMultidim;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComponentLearningApp
{
    public partial class Form5 : Form
    {
        public int minX = -1, maxX = -1;
        public int minY = -1, maxY = -1;
        public Form5()
        {
            InitializeComponent();
            
        }
        public Form5(int minx, int maxx, int miny, int maxy)
        {
            InitializeComponent();
            this.minX = minx;
            this.maxX = maxx;
            this.minY = miny;
            this.maxY = maxy;
        }
        DataTable dt;

        private void readCSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string rootDirectory = System.IO.Path.GetFullPath(@"..\..\");
            string fisier = rootDirectory + "/xls/Names.CSV";
            System.IO.StreamReader streamReader = new System.IO.StreamReader(fisier);

            string[] names;
            names = streamReader.ReadLine().Split(',');
            names[0] += " (X) ";
            names[1] += " (Y) ";
            names[2] += " (Z) ";

            fisier = rootDirectory + "/xls/Scalare.CSV";
            streamReader = new System.IO.StreamReader(fisier);

            dt = new DataTable();
            foreach (string crt in names)
            {
                dt.Columns.Add(new DataColumn(crt, typeof(double)));
            }

            while (!streamReader.EndOfStream)
            {
                string[] values = streamReader.ReadLine().Split(',');
                dt.Rows.Add(values);
            }
            dataGridView1.DataSource = dt; streamReader.Close();
        }

        public int[] x = new int[1000000], y = new int[1000000];

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public int a = 0, b = 0;
        private void clusterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KMeans kMeans; int i = 0;
            kMeans = new KMeans(4);
            kMeans.getPointsClusters(); // initiaza si termina procesul de clusterizare
            dataGridView1.DataSource = kMeans.dt;
            Color[] lstColor ={ Color.AntiqueWhite, Color.Violet, Color.Chocolate,Color.GreenYellow,Color.Honeydew,  Color.PaleVioletRed,
                                  Color.LawnGreen,Color.Gold, Color.DimGray, Color.LightGray, Color.LightGoldenrodYellow, Color.LightSeaGreen};
            i = 0;
            foreach (Vector3D crt in kMeans.allPoints)
            {
                switch (crt.index)
                {
                    case 0: 
                        dataGridView1.Rows[i].DefaultCellStyle.BackColor = lstColor[0];
                        
                        string str = dataGridView1.Rows[i].Cells[0].Value.ToString();
                        x[a++] = int.Parse(str);
                        str = dataGridView1.Rows[i].Cells[1].Value.ToString();
                        y[b++] = int.Parse(str);

                        break;
                    case 1: dataGridView1.Rows[i].DefaultCellStyle.BackColor = lstColor[1]; break;
                    case 2: dataGridView1.Rows[i].DefaultCellStyle.BackColor = lstColor[2]; break;
                    case 3: dataGridView1.Rows[i].DefaultCellStyle.BackColor = lstColor[3]; break;
                    default: break;
                }
                i++;
            }
            --a;
            --b;
            sort();

            //MessageBox.Show(minX + " " + maxX + " aaaa " + minY + " " + maxY);

            //Form1 f1 = new Form1();
            //drawArea = f1.drawArea;
            //Graphics g = drawArea.CreateGraphics();
            //Pen c = new Pen(Color.Red);
            //g.DrawRectangle(c, minX, minY, maxX - minX, maxY - minY);

        }

        private void sort()
        {            
            minX = x[0];
            maxX = x[0];
            for (int j = 1; j <= a; ++j)
            {
                if (x[j] < minX)
                    minX = x[j];
                if (x[j] > maxX)
                    maxX = x[j];
            }

            minY = y[0];
            maxY = y[0];
            for (int j = 1; j <= b; ++j)
            {
                if (y[j] < minY)
                    minY = y[j];
                if (y[j] > maxY)
                    maxY = y[j];
            }

            //MessageBox.Show(minX + " " + maxX + " aaaa " + minY + " " + maxY);
        }
    }
}
