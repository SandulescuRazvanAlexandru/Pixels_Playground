using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using ComponentLearningApp;

namespace ComponentLearning_2
{
    public enum ScaleType
    {
        In,
        Out,
        StrechToFit,
        Original
    }
    public partial class DrawArea : UserControl
    {
        private Bitmap bitmap = null;

        private float scaleCount = 0.0f;
        private float pageScale = 1.0f;

        private bool move = false;

        private PointF mousePosition = new PointF();
        private PointF focusPoint = new PointF();
        private PointF imagePosition = new PointF();

        public delegate void Zoom(float zoom);

        Graphics g;
        Point previous = new Point(0, 0);
        Pen c = new Pen(Color.Red);
        List<Point> lstPuncte = new List<Point>();
        public DrawArea()
        {
            InitializeComponent();
            ResizeRedraw = true;

            g = this.CreateGraphics();

        }

        int xMin, xMax, yMin, yMax;
        public DrawArea(int xMin, int xMax, int yMin, int yMax)
        {
            InitializeComponent();
            ResizeRedraw = true;

            g = this.CreateGraphics();

            this.xMin = xMin;
            this.xMax = xMax;
            this.yMin = yMin;
            this.yMax = yMax;
        }
        #region Properties
        public Bitmap Bitmap
        {
            get
            {
                return bitmap;
            }
            set
            {
                bitmap = value;
                Invalidate();
            }
        }


        public PointF FocusPoint
        {
            get
            {
                return focusPoint;
            }
            set
            {
                focusPoint = value;
                Invalidate();
            }
        }
        #endregion


        #region Methods
        public void ResetParameters()
        {
            if (bitmap != null)
                imagePosition = new PointF(bitmap.Width / 2f, bitmap.Height / 2f);
            pageScale = 1f;
            scaleCount = 0f;
            focusPoint = new PointF();
        }


        public PointF GetPointAtCurrentZoom(PointF pointAtZoom100)
        {
            pointAtZoom100.X = (pointAtZoom100.X - Width / 2.0f) / pageScale - focusPoint.X;
            pointAtZoom100.Y = (pointAtZoom100.Y - Height / 2.0f) / pageScale - focusPoint.Y;
            return pointAtZoom100;
        }


        public PointF GetPointAtZoom100(PointF pointAtCurrentZoom)
        {
            pointAtCurrentZoom.X = (pointAtCurrentZoom.X + focusPoint.X) * pageScale + Width / 2.0f;
            pointAtCurrentZoom.Y = (pointAtCurrentZoom.Y + focusPoint.Y) * pageScale + Height / 2.0f;
            return pointAtCurrentZoom;
        }


        public void Scale(ScaleType scaleType)
        {
            switch (scaleType)
            {
                case ScaleType.In:
                    MouseEventArgs mea = new MouseEventArgs(MouseButtons.Middle, 0, 0, 0, 120);
                    OnMouseWheel(mea);
                    Invalidate();
                    break;
                case ScaleType.Out:
                    mea = new MouseEventArgs(MouseButtons.Middle, 0, 0, 0, -120);
                    OnMouseWheel(mea);
                    Invalidate();
                    break;
                case ScaleType.Original:
                    scaleCount = 0f;
                    pageScale = 1f;
                    focusPoint = new PointF();
                    Invalidate();
                    break;
                case ScaleType.StrechToFit:
                    if (bitmap != null)
                    {
                        float scaleWidth = (float)Width / (float)bitmap.Width;
                        float scaleHeight = (float)Height / (float)bitmap.Height;
                        pageScale = (float)Math.Min(scaleWidth, scaleHeight);
                        scaleCount = (float)Math.Log(pageScale, Math.E);
                        focusPoint = new PointF();
                        Invalidate();
                    }
                    break;
            }
        }
        #endregion

        public int margineStanga, margineSus; // dreapta = stanga; sus = jos
        #region Events
        protected override void OnPaint(PaintEventArgs e)
        {
            if (bitmap != null)
            {          
                e.Graphics.TranslateTransform(Width / 2.0f, Height / 2.0f);
                e.Graphics.ScaleTransform(pageScale, pageScale);
                e.Graphics.TranslateTransform(focusPoint.X, focusPoint.Y);
                e.Graphics.DrawImage(bitmap, -imagePosition.X, -imagePosition.Y, bitmap.Width, bitmap.Height);

                margineStanga = (e.ClipRectangle.Width - bitmap.Width) / 2;
            }
        }


        protected override void OnMouseWheel(MouseEventArgs e)
        {
            if (bitmap != null)
            {
                scaleCount += (e.Delta / 120.0f) / 20.0f;
                if (scaleCount < -2.5f)
                    scaleCount = -2.5f;
                if (scaleCount > 3.5f)
                    scaleCount = 3.5f;
                pageScale = (float)Math.Exp(scaleCount);
                
                Invalidate();
            }
        }

        
        

        protected override void OnMouseDown(MouseEventArgs e)
        {
            previous.X = e.X;
            previous.Y = e.Y;

            lstPuncte = new List<Point>();
            lstPuncte.Add(previous);

            if (bitmap != null)
            {
                move = true;
                //move = false; // sa putem scrie pe drawArea - fixeaza poza 
                mousePosition = e.Location;
               
            }
        }

        
        protected override void OnMouseMove(MouseEventArgs e)
        {
            //MessageBox.Show("MouseMove pe drawArea");
            if (move == true)
            {
                //mousePosition = GetPointAtCurrentZoom(mousePosition);
                //PointF point = GetPointAtCurrentZoom(e.Location);
                //point.X -= mousePosition.X;
                //point.Y -= mousePosition.Y;

                //focusPoint.X += point.X;
                //focusPoint.Y += point.Y;
                //Invalidate();

                //mousePosition = e.Location;

                Point crt = new Point(e.X, e.Y); // pozitia curenta a mouse-ului

                g.DrawLine(c, previous, crt);
                lstPuncte.Add(crt);
                previous = crt;
            }
        }

        
        protected override void OnMouseUp(MouseEventArgs e)
        {
            move = false;
            int xMin = lstPuncte[0].X, xMax = lstPuncte[0].X;
            int yMin = lstPuncte[0].Y, yMax = lstPuncte[0].Y;

            foreach (Point it in lstPuncte)
            {
                //X
                if (it.X < xMin)
                    xMin = it.X;
                else
                    if (it.X > xMax)
                    xMax = it.X;
                //Y
                if (it.Y < yMin)
                    yMin = it.Y;
                else
                    if (it.Y > yMax)
                    yMax = it.Y;
            }


            //g.DrawRectangle(c, 0, 48, 52, 45);
            g.DrawRectangle(c, xMin, yMin, xMax - xMin, yMax - yMin);

            //Form5 f5 = new Form5();
            //xMin = f5.minX;
            //xMax = f5.maxX;
            //yMin = f5.minY;
            //yMax = f5.maxY;

            //MessageBox.Show(xMin + " " + yMin + " " + (xMax - xMin) + " " + (yMax - yMin));
            //g.DrawRectangle(c, xMin, yMin, xMax - xMin, yMax - yMin);
        }
        #endregion
    }
}
