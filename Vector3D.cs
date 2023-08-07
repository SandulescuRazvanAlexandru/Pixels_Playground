using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComponentLearningAnalizaMultidim
{
    public class Vector3D
    {
        public float X;
        public float Y;
        public float Z;
        public float W = 1f; // extensie pt calitativ/cantitativ
        public int index = -1;    //the cluster index (se schimba dinamic)

        public Vector3D(float _x, float _y, float _z, float _w)
        {// (X,Y,Z,W) point
            this.X = _x;
            this.Y = _y;
            this.Z = _z;
            this.W = _w;
        }

        public Vector3D()
        { }

        public Vector3D(Vector3D vector3D)
        {
            X = vector3D.X;
            Y = vector3D.Y;
            Z = vector3D.Z;
        }

        //public void TransformareSimpla(Matrice3D matrice)
        //{
        //    // inmultire punct R3 cu matrice
        //    float[] transf = matrice.InmultireVectorMatrice(new float[4] { X, Y, Z, W });
        //    X = transf[0];
        //    Y = transf[1];
        //    Z = transf[2];
        //    W = transf[3];
        //}

        //public void TransformareCuScalare
        //    (Matrice3D matrice, CubGrafic userC, Axe axe, EticheteGrafic etichete, Grafic grafic)
        //{
        //    //
        //    float x1 = (X - axe.XMIN) / (axe.XMAX - axe.XMIN) - 0.5f;
        //    float y1 = (Y - axe.YMIN) / (axe.YMAX - axe.YMIN) - 0.5f;
        //    float z1 = (Z - axe.ZMIN) / (axe.ZMAX - axe.ZMIN) - 0.5f;
        //    float[] transf = matrice.InmultireVectorMatrice(new float[4] { x1, y1, z1, W });
        //    X = (float)Math.Round(transf[0], 2);
        //    Y = (float)Math.Round(transf[1], 2);
        //    float xShift = 1.05f;
        //    float xScale = 1;
        //    float yShift = 1.05f;
        //    float yScale = 0.9f;
        //    if (etichete.Titlu == "No Title")
        //    {
        //        yShift = 0.95f;
        //        yScale = 1;
        //    }
        //    if (grafic.Colorat)
        //    {
        //        xShift = 0.95f;
        //        xScale = 0.9f;
        //    }
        //    X = (xShift + xScale * X) * userC.PanelDesen.Width / 2;
        //    Y = (yShift - yScale * Y) * userC.PanelDesen.Height / 2;
        //}

        internal float getEuclidianDistance(Vector3D vector)
        {
            return (float)Math.Sqrt(
                            (X - vector.X) * (X - vector.X) +
                            (Y - vector.Y) * (Y - vector.Y) +
                            (Z - vector.Z) * (Z - vector.Z)
                            );
        }
        internal float getEuclidianPhotoDistance(Vector3D vector)
        {
            return (float)Math.Sqrt(
                          0.4 * (X - vector.X) * (X - vector.X) +
                          0.4 * (Y - vector.Y) * (Y - vector.Y) +
                          0.2 * (Z - vector.Z) * (Z - vector.Z)
                            );
        }

        public static bool IsUnique(List<Vector3D> vectori, Vector3D v)
        {
            foreach (Vector3D vector in vectori)
                if (vector.X == v.X && vector.Y == v.Y && vector.Z == v.Z)
                    return false;
            return true;
        }

        public bool Equals(Vector3D v)
        {
            if (Math.Round(v.X) != Math.Round(this.X) ||
                Math.Round(v.Y) != Math.Round(this.Y) ||
                Math.Round(v.Z) != Math.Round(this.Z))
                return false;
            else
                return true;
        }

        public static List<Vector3D> CopyList(List<Vector3D> lista)
        {
            List<Vector3D> listaNoua = new List<Vector3D>();
            foreach (Vector3D v in lista)
            {
                Vector3D vn = (Vector3D)v.Clone(); // new pct cu pct
                listaNoua.Add(vn);
            }
            return listaNoua;
        }

        // bulina desenata la coord (X,Y)
        //public virtual void desenare(Graphics graphics, Brush brush,
        //    int colorNumber, int[,] CMap,
        //    Color color)
        //{
        //    graphics.FillEllipse(brush, this.X, this.Y, 5, 5);
        //}

        public virtual object Clone()
        {
            return new Vector3D(this.X, this.Y, this.Z, this.W);
        }

        public virtual object[] GetObjectArray()
        {
            return new object[] { this.X, this.Y, this.Z, "-", "-" };
        }

        //public void prelungeste(Axe axe, int directie)
        //{
        //    Vector3D lxMax = new Vector3D(axe.XMAX, 0, 0, 1);
        //    Vector3D lxMin = new Vector3D(axe.XMIN, 0, 0, 1);

        //    Vector3D lyMax = new Vector3D(0, axe.YMAX, 0, 1);
        //    Vector3D lyMin = new Vector3D(0, axe.YMIN, 0, 1);

        //    Vector3D lzMax = new Vector3D(0, 0, axe.ZMAX, 1);
        //    Vector3D lzMin = new Vector3D(0, 0, axe.ZMIN, 1);

        //    float maxDist = lxMax.getEuclidianDistance(lxMin);
        //    if (lyMax.getEuclidianDistance(lyMin) < maxDist)
        //        maxDist = lyMax.getEuclidianDistance(lyMin);
        //    if (lzMax.getEuclidianDistance(lzMin) < maxDist)
        //        maxDist = lzMax.getEuclidianDistance(lzMin);
        //    Vector3D origine = new Vector3D(0, 0, 0, 1);

        //    float scale = maxDist / this.getEuclidianDistance(origine);

        //    this.X *= directie * scale;
        //    this.Y *= directie * scale;
        //    this.Z *= directie * scale;
        //}
    }
}
