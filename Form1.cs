using ControlUtilizator;
using ComponentLearning_2;
using ComponentLearning_3;
using ComponentLearning_4;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using ComponentLearning_1;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.Face;
using Emgu.CV.Util;
using ComponentLearningApp;
using MachineLearningApp;

namespace ComponentLearning_1
{
    public partial class Form1 : Form
    {
        Image img;
        Bitmap bitmapCopy = null;
        string path;
        List<System.Drawing.Point> lp;
        System.Drawing.Point crt;
        bool creionApasat;

        public Form1()
        {
            InitializeComponent();
            lp = new List<System.Drawing.Point>();
            creionApasat = false;
            img = null;
            //path = null;
            string rootDirectory = System.IO.Path.GetFullPath(@"..\..\");
            path = rootDirectory + "/Teste/test1.png";

            if (path != null)
            {
                DrawFully(path);
                CopyBitmap((Bitmap)drawArea.Bitmap.Clone());
            }
        }

        private void DrawBitmapOnDrawArea(Bitmap bitmap)
        {
            if (drawArea.Bitmap != null)
            {
                drawArea.Bitmap.Dispose();
            }
            drawArea.Bitmap = bitmap;
            drawArea.Invalidate();
        }
       
        private void DrawFully(string fileName)
        {
            img = Image.FromFile(fileName);
            Bitmap bitmap = new Bitmap(fileName);
            JustDraw(bitmap);
        }

        private void DrawFully(Bitmap bitmap)
        {
            img = bitmap;
            JustDraw(bitmap);
        }

        private void JustDraw(Bitmap bitmap)
        {
            DrawBitmapOnDrawArea(bitmap);
            ResetDrawArea();
        }

        private void ResetDrawArea()
        {
            drawArea.ResetParameters();
            drawArea.Scale(ScaleType.StrechToFit);
            drawArea.Focus();
        }

        private void CopyBitmap(Bitmap bitmap)
        {
            bitmapCopy = (Bitmap)bitmap.Clone();
        }

        private void resizeDrawAreaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResetDrawArea();
        }

        private void OpenImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "images | *.png;*.jpg;*.jpeg;*.bmp";
            ofd.Title = "Open an image";
            if (ofd.ShowDialog() == DialogResult.OK && ofd.FileName != "")
            {
                path = ofd.FileName;
                DrawFully(path);
                CopyBitmap((Bitmap)drawArea.Bitmap.Clone());
            }
            else
            {
                MessageBox.Show("Image not opened");
            }
            ofd.Dispose();
        }

        private void reloadInitialImage_Click(object sender, EventArgs e)
        {
            if (drawArea.Bitmap != null)
            {
                DrawFully((Bitmap)bitmapCopy.Clone());
            }
            else
            {
                NoImageLoaded(sender, e);
            }
        }

        private string ChooseFilter()
        {
            // PNG
            if (ImageFormat.Png.Equals(img.RawFormat))
            {
                return "Png Image (.png)|*.png|JPEG Image (.jpeg)|*.jpeg|Bitmap Image (.bmp)|*.bmp";
            }
            // Jpeg
            if (ImageFormat.Jpeg.Equals(img.RawFormat))
            {
                return "JPEG Image (.jpeg)|*.jpeg|Png Image (.png)|*.png|Bitmap Image (.bmp)|*.bmp";
            }
            // Bmp
            if (ImageFormat.Bmp.Equals(img.RawFormat))
            {
                return "Bitmap Image (.bmp)|*.bmp|JPEG Image (.jpeg)|*.jpeg|Png Image (.png)|*.png";
            }
            // All files
            return "All Files (*.*)|*.*";
        }

        private void SaveImage_Click(object sender, EventArgs e)
        {
            if (img == null)
            {
                NoImageLoaded(sender, e);
            }
            else
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Title = "Save current image";
                sfd.Filter = ChooseFilter();

                if (sfd.ShowDialog() == DialogResult.OK && sfd.FileName != "")
                {
                    drawArea.Bitmap.Save(sfd.FileName, img.RawFormat);
                }
                else
                {
                    MessageBox.Show("Image not saved");
                }

                sfd.Dispose();
            }
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnScalare_Click(object sender, EventArgs e)
        {
            if (img == null)
            {
                NoImageLoaded(sender, e);
            }
            else
            {
                string rootDirectory = System.IO.Path.GetFullPath(@"..\..\");
                StreamReader fisMare = new System.IO.StreamReader(rootDirectory + "/xls/EdgeDetection.csv");
                StreamWriter fisMic = new System.IO.StreamWriter(rootDirectory + "/xls/Scalare.csv");

                double wl = 0, wr = 750, wt = 0, wb = 750;
                int vl = 0, vr = 100, vt = 0, vb = 100;
                int xe, ye, ze;
                double a1, a2, b1, b2;
                a1 = (vl - vr) / (wl - wr); b1 = (wl * vr - wr * vl) / (wl - wr);
                a2 = (vt - vb) / (wb - wt); b2 = (wb * vb - wt * vt) / (wb - wt);
                //int z = 0;
                int i = 0, n = 0;
                int[] x = new int[1000000], y = new int[1000000], z = new int[1000000];

                while (!fisMare.EndOfStream) // incarca vectori coordonate
                {
                    String[] values = fisMare.ReadLine().Split(',');
                    x[i] = int.Parse(values[0]);
                    y[i] = int.Parse(values[1]);
                    z[i] = int.Parse(values[2]);

                    // scalare simultana, adica pixel negru
                    x[i] = (int)(a1 * x[i] + b1);
                    y[i] = (int)(a2 * y[i] + b2);

                    i++;
                }

                n = i; 
                sortFully(n, x, y, z);

                xe = x[0];
                ye = y[0];

                string tmp;
                tmp = $"{x[0]},{y[0]},{z[0]}";
                fisMic.WriteLine(tmp);

                for (i = 1; i < n - 1; i++)
                {
                    if (x[i] != xe) // s-a schimbat x
                    {
                        xe = x[i];
                        ye = y[i];
                        tmp = $"{x[i]},{y[i]},{z[i]}";
                        fisMic.WriteLine(tmp);
                    }
                    else
                    {
                        if (y[i] != ye) // s-a schimbat y
                        {
                            ye = y[i];
                            tmp = $"{x[i]},{y[i]},{z[i]}";
                            fisMic.WriteLine(tmp);
                        }
                    }
                    //sare peste o pereche (x, y, z)
                }
                fisMic.Close();
                fisMare.Close();
            }
        }

        private void sortFully(int n, int[] x, int[] y, int[] z)
        {
            int i, j;
            for (i = 0; i < n - 1; i++)
            {
                for (j = i + 1; j < n; j++)
                    if (x[i] > x[j])
                    {
                        sortX(x, y, z, i, j);
                    }
                    else
                    {
                        if (x[i] == x[j])
                        {
                            if (y[i] > y[j])
                            {
                                sortY(x, y, z, i, j);
                            }
                        }
                    }
            }
        }

        private void sortX(int[] x, int [] y, int[] z, int i, int j)
        {
            int aux = x[i];
            x[i] = x[j];
            x[j] = aux;

            sortY(x, y, z, i, j);
        }

        private void sortY(int[] x, int[] y, int[] z, int i, int j)
        {
            int aux = y[i];
            y[i] = y[j];
            y[j] = aux;

            aux = z[i];
            z[i] = z[j];
            z[j] = aux;
        }
        private void NoImageLoaded(object sender, EventArgs e)
        {
            MessageBox.Show("No image loaded");
            OpenImage_Click(sender, e);
        }

        private void Polishing(Procesare procesare)
        {
            procesare.FinishProcessing();
            drawArea.Invalidate();
        }

        private void btnMakeGray_Click(object sender, EventArgs e)
        {
            if (drawArea.Bitmap != null)
            {
                Procesare procesare = new Procesare(drawArea.Bitmap);
                procesare.MakeGray();
                Polishing(procesare);
            }
            else
            {
                NoImageLoaded(sender, e);
            }
        }

        private void negative_Click(object sender, EventArgs e)
        {
            if (drawArea.Bitmap != null)
            {
                Procesare procesare = new Procesare(drawArea.Bitmap);
                procesare.Negative();
                Polishing(procesare);
            }
            else
            {
                NoImageLoaded(sender, e);
            }
        }

        private void blurr_Click(object sender, EventArgs e)
        {
            if (drawArea.Bitmap != null)
            {
                Procesare procesare = new Procesare(drawArea.Bitmap);
                Bitmap bitmap = procesare.Blur(drawArea.Bitmap, 5);
                DrawFully(bitmap);
            }
            else
            {
                NoImageLoaded(sender, e);
            }
        }

        TipVector tip = TipVector.SIMPLU;
        private void btnScatterPlot_Click(object sender, EventArgs e)
        {
            if (img == null)
            {
                NoImageLoaded(sender, e);
            }
            else
            {
                System.IO.Stream fileStream = null;
                OpenFileDialog ofd = new OpenFileDialog();

                string rootDirectory = System.IO.Path.GetFullPath(@"..\..\");
                string fisier = rootDirectory + @"/xls/Scalare.csv";
                
                ofd.FileName = fisier; 
                fileStream = ofd.OpenFile();

                DateVectoriale dateVect = new DateVectoriale(fileStream, tip);
                VizualizareDate afisareGrafic = new VizualizareDate();

                afisareGrafic.Grafic.C3DrawChart.ChartType = TipuriDeGrafice.ChartTypeEnum.NorDePuncte;
                afisareGrafic.Grafic.C3DataSeries = dateVect.CopyWithNewList();
                afisareGrafic.date = Vector3D.CopyList(afisareGrafic.Grafic.C3DataSeries.PointList);
                foreach(Vector3D v in afisareGrafic.date)
                {
                    v.Z = 0;
                }
                afisareGrafic.ShowDialog();

                fileStream.Close();
            }
        }

        private void btnEdgeDetection_Click(object sender, EventArgs e)
        {
            if (drawArea.Bitmap != null)
            {
                Procesare procesare = new Procesare(drawArea.Bitmap);

                Form3 f3 = new Form3();
                f3.ShowDialog();

                if (f3.btnOK.DialogResult == DialogResult.OK)
                {
                    int val = f3.sendPrag();
                    procesare.EdgeDetection(val);
                    procesare.FinishProcessing();
                    drawArea.Invalidate();
                }
                else
                {
                    MessageBox.Show("Error regarding thickness");
                }
            }
            else
            {
                NoImageLoaded(sender, e);
            }
        }

        private void fluxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnMakeGray_Click(sender, e);
            btnEdgeDetection_Click_2(sender, e);
            btnScalare_Click(sender, e);
            btnScatterPlot_Click(sender, e);
        }

        private void webCamModuleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            f4.ShowDialog();

            if (f4.btnSaveExit.DialogResult == DialogResult.OK)
            {
                Bitmap bmp = f4.sendBitmap();
                DrawFully(bmp);
                CopyBitmap((Bitmap)bmp.Clone());
            }
            else
            {
                MessageBox.Show("No picture taken");
            }
        }

        private void btnEdgeDetection_Click_2(object sender, EventArgs e)
        {
            Procesare procesare = new Procesare(drawArea.Bitmap);
            procesare.EdgeDetection(24);
            Polishing(procesare);
        }

        private void Resize_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2(drawArea.Bitmap);
            f2.ShowDialog();

            if (f2.btnResize.DialogResult == DialogResult.OK)
            {
                int newWidth = f2.SendNewWidth();
                int newHeight = f2.SendNewHeight();

                DrawFully(ResizeFunction_1(img, newWidth, newHeight));
            }
            else
            {
                MessageBox.Show("Error resizing image");
            }
        }

        private Bitmap ResizeFunction_1(Image image, int WantedWidth, int WantedHeight)
        {
            int sourceWidth = image.Width;
            int sourceHeight = image.Height;
            int sourceX = 0;
            int sourceY = 0;
            int destX = 0;
            int destY = 0;

            float nPercent = 0;
            float nPercentW = 0;
            float nPercentH = 0;

            nPercentW = ((float)WantedWidth / (float)sourceWidth);
            nPercentH = ((float)WantedHeight / (float)sourceHeight);
            if (nPercentH < nPercentW)
            {
                nPercent = nPercentH;
                destX = Convert.ToInt32((WantedWidth - (sourceWidth * nPercent)) / 2);
            }
            else
            {
                nPercent = nPercentW;
                destY = Convert.ToInt32((WantedHeight - (sourceHeight * nPercent)) / 2);
            }

            int destWidth = (int)(sourceWidth * nPercent);
            int destHeight = (int)(sourceHeight * nPercent);

            Bitmap bitmap = new Bitmap(WantedWidth, WantedHeight, PixelFormat.Format24bppRgb);
            bitmap.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            Graphics graphic = Graphics.FromImage(bitmap);
            graphic.Clear(drawArea.BackColor);
            graphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
            graphic.DrawImage(image, new Rectangle(destX, destY, destWidth, destHeight), 
                new Rectangle(sourceX, sourceY, sourceWidth, sourceHeight), GraphicsUnit.Pixel);
            graphic.Dispose();

            return bitmap;
        }

        private void initImageInput()
        {
            imageInput = drawArea.Bitmap.ToImage<Bgr, byte>();
        }

        private void StartDetection(object sender, EventArgs e)
        {
            reloadInitialImage_Click(sender, e);
            initImageInput();
        }

        private Boolean Check(object sender, EventArgs e)
        {
            if (drawArea.Bitmap == null)
            {
                NoImageLoaded(sender, e);
                return false;
            }
            else
            {
                StartDetection(sender, e);
                return true;
            }
        }

        Image<Bgr, byte> imageInput = null;

        // 1
        private void no1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Check(sender, e))
            {
                DetectFaceHaar();
            }
        }

        private void DetectFaceHaar()
        {
            try
            {
                string rootDirectory = System.IO.Path.GetFullPath(@"..\..\");
                string facePath = rootDirectory + "/xmls/haarcascade_frontalface_default.xml";

                CascadeClassifier classifierFace = new CascadeClassifier(facePath);

                var imgGray = imageInput.Convert<Gray, byte>().Clone();

                Rectangle[] faces = classifierFace.DetectMultiScale(imgGray, 1.1, 4);
                foreach (var face in faces)
                {
                    imageInput.Draw(face, new Bgr(0, 0, 255), 2);
                    imgGray.ROI = face;
                }

                DrawFully(imageInput.ToBitmap());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // 1.5
        private void no1CropToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Check(sender, e))
            {
                Crop1();
            }
        }

        private void Crop1()
        {
            try
            {
                string rootDirectory = System.IO.Path.GetFullPath(@"..\..\");
                string facePath = rootDirectory + "/xmls/haarcascade_frontalface_default.xml";

                CascadeClassifier classifierFace = new CascadeClassifier(facePath);

                var imageGray = imageInput.Convert<Gray, byte>().Clone();

                Rectangle[] faces = classifierFace.DetectMultiScale(imageGray, 1.1, 4);
                if (faces.Length > 1)
                {
                    MessageBox.Show("This option is available only for one-person pictures");
                }
                else
                {
                    var imageCrop = imageInput.Clone();
                    imageCrop.ROI = faces[0];
                    DrawFully(imageCrop.ToBitmap());
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // 2
        private void no2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Check(sender, e))
            {
                DetectFaceLBP();
            }
        }

        private void DetectFaceLBP()
        {
            try
            {
                string rootDirectory = System.IO.Path.GetFullPath(@"..\..\");
                string facePath = rootDirectory + "/xmls/lbpcascade_frontalface.xml";

                CascadeClassifier classifierFace = new CascadeClassifier(facePath);

                var imgGray = imageInput.Convert<Gray, byte>().Clone();

                Rectangle[] faces = classifierFace.DetectMultiScale(imgGray, 1.1, 4);
                foreach (var face in faces)
                {
                    imageInput.Draw(face, new Bgr(255, 0, 0), 2);
                    imgGray.ROI = face;
                }
                DrawFully(imageInput.ToBitmap());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // 2.5
        private void no2CropToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Check(sender, e))
            {
                Crop2();
            }
        }

        private void Crop2()
        {
            try
            {
                string rootDirectory = System.IO.Path.GetFullPath(@"..\..\");
                string facePath = rootDirectory + "/xmls/lbpcascade_frontalface.xml";

                CascadeClassifier classifierFace = new CascadeClassifier(facePath);

                var imgGray = imageInput.Convert<Gray, byte>().Clone();

                Rectangle[] faces = classifierFace.DetectMultiScale(imgGray, 1.1, 4);
                if (faces.Length > 1)
                {
                    MessageBox.Show("This option is available only for one-person pictures");
                }
                else
                {
                    var imageCrop = imageInput.Clone();
                    imageCrop.ROI = faces[0];
                    DrawFully(imageCrop.ToBitmap());
                }                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // 3
        private void no3EyesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Check(sender, e))
            {
                ImprovedFaceDetection();
            }
        }

        private void ImprovedFaceDetection()
        {
            try
            {
                string rootDirectory = System.IO.Path.GetFullPath(@"..\..\");
                string facePath = rootDirectory + "/xmls/lbpcascade_frontalface_improved.xml";

                CascadeClassifier classifierFace = new CascadeClassifier(facePath);

                var imgGray = imageInput.Convert<Gray, byte>().Clone();

                Rectangle[] faces = classifierFace.DetectMultiScale(imgGray, 1.1, 4);
                foreach (var face in faces)
                {
                    imageInput.Draw(face, new Bgr(0, 255, 255), 2);
                    imgGray.ROI = face;
                }

                DrawFully(imageInput.ToBitmap());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // 3.5
        private void no3CropToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Check(sender, e))
            {
                Crop3();
            }
        }

        private void Crop3()
        {
            try
            {
                string rootDirectory = System.IO.Path.GetFullPath(@"..\..\");
                string facePath = rootDirectory + "/xmls/lbpcascade_frontalface_improved.xml";

                CascadeClassifier classifierFace = new CascadeClassifier(facePath);

                var imgGray = imageInput.Convert<Gray, byte>().Clone();
                
                Rectangle[] faces = classifierFace.DetectMultiScale(imgGray, 1.1, 4);
                if (faces.Length > 1)
                {
                    MessageBox.Show("This option is available only for one-person pictures");
                }
                else
                {
                    var imageCrop = imageInput.Clone();
                    imageCrop.ROI = faces[0];
                    DrawFully(imageCrop.ToBitmap());
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // 4
        private void no4EyesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Check(sender, e))
            {
                DetectEyes();
            }
        }

        private void DetectEyes()
        {
            try
            {
                string rootDirectory = System.IO.Path.GetFullPath(@"..\..\");
                string facePath = rootDirectory + "/xmls/haarcascade_frontalface_default.xml";
                string eyePath = rootDirectory + "/xmls/haarcascade_eye.xml";

                CascadeClassifier classifierFace = new CascadeClassifier(facePath);
                CascadeClassifier classifierEye = new CascadeClassifier(eyePath);

                var imgGray = imageInput.Convert<Gray, byte>().Clone();

                Rectangle[] faces = classifierFace.DetectMultiScale(imgGray, 1.1, 4);
                foreach (var face in faces)
                {
                    imgGray.ROI = face;
                    Rectangle[] eyes = classifierEye.DetectMultiScale(imgGray, 1.1, 4);
                    foreach (var eye in eyes)
                    {
                        var e = eye;
                        e.X += face.X;
                        e.Y += face.Y;
                        imageInput.Draw(e, new Bgr(0, 255, 0), 2);
                    }
                }
                DrawFully(imageInput.ToBitmap());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Landmarks
        private void landmarkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Check(sender, e))
            {
                Landmarks();
            }
        }

        private void Landmarks()
        {
            try
            {
                string rootDirectory = System.IO.Path.GetFullPath(@"..\..\");
                string lbpFacepath = rootDirectory + "/xmls/lbpcascade_frontalface_improved.xml";
                string modelPath = rootDirectory + "/xmls/lbfmodel.yaml.txt";

                CascadeClassifier classifier = new CascadeClassifier(lbpFacepath);
                FacemarkLBFParams facemarkLBF = new FacemarkLBFParams();
                FacemarkLBF facemark = new FacemarkLBF(facemarkLBF);

                var img = new Bitmap(drawArea.Bitmap).ToImage<Bgr, byte>();
                var imgGray = img.Convert<Gray, byte>();
                var faces = classifier.DetectMultiScale(imgGray);

                facemark.LoadModel(modelPath);

                VectorOfVectorOfPointF landmarks = new VectorOfVectorOfPointF();
                VectorOfRect rects = new VectorOfRect(faces);
                bool result = facemark.Fit(imgGray, rects, landmarks);
                if (result)
                {
                    for (int i = 0; i < faces.Length; i++)
                    {
                        FaceInvoke.DrawFacemarks(img, landmarks[i], new MCvScalar(0, 0, 255));
                        var p = landmarks[i][33];
                        CvInvoke.Circle(img, new System.Drawing.Point((int)p.X, (int)p.Y), 5, new MCvScalar(0, 255, 0), -1);
                    }
                }

                drawArea.Bitmap = img.ToBitmap();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //===Drawing===//
        private void drawArea_MouseDown(object sender, MouseEventArgs e)
        {
            crt = new System.Drawing.Point(-1, -1);
            creionApasat = true;
            lp.Add(crt);
        }

        private void drawArea_MouseMove(object sender, MouseEventArgs e)
        {
            crt = new System.Drawing.Point(e.X, e.Y);

            Graphics g = this.CreateGraphics();
            Pen c = new Pen(Color.Blue);
            if (creionApasat == true && (lp[lp.Count - 1].X != -1))
            {
                g.DrawLine(c, lp[lp.Count - 1], crt);
            }
            if (creionApasat == true)
            {
                lp.Add(crt);
            }
        }

        private void drawArea_MouseUp(object sender, MouseEventArgs e)
        {
            creionApasat = false;
        }

        private void readCSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string rootDirectory = System.IO.Path.GetFullPath(@"..\..\");
            string fisier = rootDirectory + "/xls/Scalare.CSV";

            System.IO.StreamReader streamReader = new System.IO.StreamReader(fisier);
            string[] values = null;

            while (!streamReader.EndOfStream)
            {
                values = streamReader.ReadLine().Split(',');
            }
            MessageBox.Show(values.Length.ToString());

            streamReader.Close();
        }

        private void analizaMultidimensionalaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form5 f5 = new Form5();
            f5.Show();
        }

        Graphics g;
        int xMin = -1, xMax = -1, yMin = -1, yMax = -1;

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form6 f6 = new Form6();
            f6.ShowDialog();
        }

        private void draw2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            g = drawArea.CreateGraphics();
            Pen c = new Pen(Color.Red);

            Form5 f5 = new Form5();
            f5.ShowDialog();

            xMin = f5.minX + drawArea.margineStanga;
            xMax = f5.maxX + drawArea.margineStanga;
            yMin = f5.minY;
            yMax = f5.maxY;

            //MessageBox.Show(xMin + " " + yMin + " " + (xMax - xMin) + " " + (yMax - yMin));
            
            
            
            g.DrawRectangle(c, xMin, yMin, xMax - xMin, yMax - yMin);
            //g.DrawRectangle(c, 0, 48, 52, 45);
        }
    }
}
