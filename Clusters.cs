using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComponentLearningAnalizaMultidim
{
    public class Clusters : List<Cluster>
    {
        private List<Vector3D> allPoints;
        private bool isChanged;

        public Clusters(List<Vector3D> allPoints)
        {
            this.allPoints = allPoints;
        }

        public int getNearestCluster(Vector3D point)
        {// intoarce indexul celui mai <apropiat> cluster
            double minDistance = Double.MaxValue; // initializare cu infinit
            int index = -1;
            for (int i = 0; i < Count; i++)
            {// pt un punct cauta nearest cluster in functie de centroidul lui

                double squareOfDistance =
                    point.getEuclidianDistance(this.ElementAt(i).getCentroid());

                if (squareOfDistance < minDistance) // cluster mai apropiat
                {
                    minDistance = squareOfDistance;
                    index = i;
                }
            }
            return index;
        }

        public bool updateClusters()
        {
            foreach (Cluster cluster in this)
            {
                cluster.updateCentroid();
                cluster.getPoints().Clear();
            }
            isChanged = false;
            assignPointsToClusters();
            return isChanged;
        }

        public void assignPointsToClusters()
        {
            foreach (Vector3D point in allPoints)
            { // modif indexul in punctele 3D, cand s-a schimbat clusterul cel mai apropiat
                int previous = point.index;
                int newIndex = getNearestCluster(point);
                if (previous != newIndex)
                    isChanged = true;
                Cluster clusterTarget = this.ElementAt(newIndex); // noul cluster
                point.index = newIndex;
                clusterTarget.getPoints().Add(point);// add in lista noului cluster
            }
        }
    }
}
