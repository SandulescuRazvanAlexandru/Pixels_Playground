using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComponentLearningAnalizaMultidim
{
    public class KMeans
    {
        public static Random random = new Random();
        public List<Vector3D> allPoints;
        public DataTable dt;
        public int k; // nr clustere
        public Clusters pointClusters = null; //the k Clusters

        /**@param pointsFile : the csv file for input points
         * @param k : number of clusters
         */

        public void CitireDateVector3D(System.IO.Stream stream, List<Vector3D> pointList)
        {
            string rootDirectory = System.IO.Path.GetFullPath(@"..\..\");
            string fisier = rootDirectory + "/xls/Names.CSV";
            System.IO.StreamReader streamReader = new System.IO.StreamReader(fisier);

            string[] names;
            names = streamReader.ReadLine().Split(',');
            names[0] += " (X) ";
            names[1] += " (Y) ";
            names[2] += " (Z) ";

            streamReader = new System.IO.StreamReader(stream);
            dt = new DataTable();
            foreach (string crt in names)
            {
                dt.Columns.Add(new DataColumn(crt, typeof(double)));
            }

            // citeste si construieste punct 3D
            while (!streamReader.EndOfStream)
            {
                float X, Y, Z;
                Vector3D vector;

                String[] values = streamReader.ReadLine().Split(',');
                dt.Rows.Add(values); // pune si in DataTable prin conversie implicita la tip camp
                X = float.Parse(values[0]); Y = float.Parse(values[1]); Z = float.Parse(values[2]);
                vector = new Vector3D(X, Y, Z, -1); // -1 este index apartenenta cluster 
                pointList.Add(vector);
            }
        }
        public KMeans(int nrClustere)
        {
            k = nrClustere; // vine din Form1
                        
            System.IO.Stream fileStream = null;
            OpenFileDialog ofd = new OpenFileDialog();
            string rootDirectory = System.IO.Path.GetFullPath(@"..\..\");
            string fisier = rootDirectory + "/xls/Scalare.CSV";
            
            ofd.FileName = fisier; 
            fileStream = ofd.OpenFile();

            allPoints = new List<Vector3D>(); // initializeaza si trimite la incarcat prin citire din fisier
            CitireDateVector3D(fileStream, allPoints);
        }


        // step 1: get random seeds as initial centroids of the k clusters
        public void getInitialKRandomSeeds()
        {
            pointClusters = new Clusters(allPoints);
            List<Vector3D> kRandomPoints = getKRandomPoints();
            for (int i = 0; i < k; i++)
            {
                kRandomPoints.ElementAt(i).index = i;
                pointClusters.Add(new Cluster(kRandomPoints.ElementAt(i)));
            }
        }

        public List<Vector3D> getKRandomPoints()
        {
            List<Vector3D> kRandomPoints = new List<Vector3D>();
            bool[] alreadyChosen = new bool[allPoints.Count];
            int size = allPoints.Count;
            for (int i = 0; i < k; i++)
            {
                int index = -1, r = random.Next(size--) + 1;
                for (int j = 0; j < r; j++)
                {
                    index++;
                    while (alreadyChosen[index])
                        index++;
                }
                kRandomPoints.Add(allPoints.ElementAt(index));
                alreadyChosen[index] = true;
            }
            return kRandomPoints;
        }

        // step 2: assign points to initial Clusters   
        private void getInitialClusters()
        {
            pointClusters.assignPointsToClusters();
        }

        //  step 3: update the k Clusters until no changes in their members occur
        public void updateClustersUntilNoChange()
        {
            bool isChanged = pointClusters.updateClusters(); // la ultima repartizare s-a schimbat ceva
            while (isChanged) // daca dupa repartizarea punctelor pe clustere s-a mai schimbat ceva
                isChanged = pointClusters.updateClusters(); // se reactualizeaza tot
            // pointClusters este lista clusterelor, la un moment dat


            // ****************** Afisare finala ******************* // 
            string rootDirectory = System.IO.Path.GetFullPath(@"..\..\");
            string fisier = rootDirectory + "/xls/RezultateClusterAnalizaMultidim.txt";
            System.IO.StreamWriter streamWriter = new System.IO.StreamWriter(fisier);

            int i = 0;
            foreach (Vector3D crt in allPoints)
            {
                streamWriter.WriteLine($"indiv_{i} cluster \t {crt.index}"); 
                i++;
            }
            streamWriter.WriteLine("\n\n");

            i = 0;
            foreach (Cluster crt in pointClusters)
            {
                streamWriter.WriteLine($"Cluster_{i} contine \t {crt.points.Count} indivizi");
                i++;
            }
            streamWriter.Close();
        }

        // sinteza K-means clustering; clusterele sunt liste de puncte 3D (Vector3D)
        // punctele stiu si ele (membru index) carui cluster apartin la un moment dat
        public List<Cluster> getPointsClusters()
        { 
            //procesul de clusterizare
            if (pointClusters == null)
            {
                getInitialKRandomSeeds();
                getInitialClusters();
                updateClustersUntilNoChange();
            }
            return pointClusters;
        }

        //public static void main(String[] args)
        //{
        //    //String pointsFilePath = "files/randomPoints.csv";
        //    //KMeans kMeans = new KMeans(pointsFilePath, 6);
        //    //List<cluster> pointsClusters = kMeans.getPointsClusters();
        //    //for (int i = 0 ; i < kMeans.k; i++)
        //    // Console.WriteLine("Cluster " + i + ": " + pointsClusters.get(i));
        //}
    }
}
