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
    public partial class TabelDate : Form
    {
        public TabelDate(DateVectoriale date)
        {
            InitializeComponent();

            this.X.HeaderText = date.Names[0];
            this.Y.HeaderText = date.Names[1];
            this.Z.HeaderText = date.Names[2];
            if (date.TipVectori == TipVector.CALITATIV)
                calitativ.HeaderText = date.Names[3];
            if (date.TipVectori == TipVector.CANTITATIV)
                cantitativ.HeaderText = date.Names[3];
            if (date.TipVectori == TipVector.MIXT)
            {
                calitativ.HeaderText = date.Names[3];
                cantitativ.HeaderText = date.Names[4];
            }
            foreach (Vector3D vector in date.PointList)
                dataGridView.Rows.Add(vector.GetObjectArray());
        }
    }
}
