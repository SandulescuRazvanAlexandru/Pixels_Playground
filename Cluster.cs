using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComponentLearningAnalizaMultidim
{
    public class Cluster
    {
        public List<Vector3D> points;
        // dinamic, lista punctelor 3D ce fac parte din acest cluster
        private Vector3D centroid;

        public Cluster(Vector3D firstPoint)
        {
            points = new List<Vector3D>();
            centroid = firstPoint;
        }

        public Vector3D getCentroid()
        {
            return centroid;
        }

        public void updateCentroid()
        {
            double x = 0d, y = 0d, z = 0d;
            foreach (Vector3D point in points)
            { //
                x += point.X;
                y += point.Y;
                z += point.Z;
            }
            centroid = new Vector3D(
                (float)x / (float)points.Count,
                (float)y / (float)points.Count,
                (float)z / (float)points.Count,
                1);
        }

        public List<Vector3D> getPoints()
        {
            return points;
        }
    }
}
