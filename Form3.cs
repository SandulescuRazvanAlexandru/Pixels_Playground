using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComponentLearning_1
{
    public partial class Form3 : Form
    {
        int prag = -1;
        bool isOk = true;
        public Form3()
        {
            InitializeComponent();
        }
                
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (isOk)
            {
                initPrag();
                btnOK.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid input");
            }
        }

        private void initPrag()
        {
            prag = int.Parse(tbThickness.Text);
        }

        public int sendPrag()
        {
            return prag;
        }

        private void tbThickness_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                initPrag();
                errorProvider1.SetError(tbThickness, "");
                isOk = true;
            }
            catch
            {
                errorProvider1.SetError(tbThickness, "Invalid input");
                tbThickness.Focus();
                isOk = false;
            }
            if (prag < 0 || prag > 1000)
            {
                errorProvider1.SetError(tbThickness, "Invalid input");
                tbThickness.Focus();
                isOk = false;
            }
            else
            {
                errorProvider1.SetError(tbThickness, "");
                isOk = true;
            }
        }
    }
}
