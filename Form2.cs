using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComponentLearning_1
{
    public partial class Form2 : Form
    {
        Image img = null;
        bool isOk = true;

        public Form2(Image img)
        {
            InitializeComponent();
            this.img = img;
        }

        private void initWidth()
        {
            newWidth = int.Parse(tbLatime.Text);
        }
        public int SendNewWidth()
        {
            return newWidth;
        }

        private void initHeight()
        {
            newHeight = int.Parse(tbLatime.Text);
        }
        public int SendNewHeight()
        {
            return newHeight;
        }

        private void btnResize_Click(object sender, EventArgs e)
        {
            if (img != null)
            {
                if (isOk)
                {
                    initWidth();
                    initHeight();

                    btnResize.DialogResult = DialogResult.OK;
                    
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Invalid input");
                }
            }
            else
            {
                MessageBox.Show("No image loaded");
            }
        }
                        
        int newWidth = -1;
        private void tbLatime_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                initWidth();
                errorProvider1.SetError(tbLatime, "");
                isOk = true;
            }
            catch
            {
                errorProvider1.SetError(tbLatime, "Invalid input");
                tbLatime.Focus();
                isOk = false;
            }
            if (newWidth < 0 || newWidth > 1000)
            {
                errorProvider1.SetError(tbLatime, "Invalid input");
                tbLatime.Focus();
                isOk = false;
            }
            else
            {
                errorProvider1.SetError(tbLatime, "");
                isOk = true;
            }
        }

        int newHeight = -1;
        private void tbInaltime_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                initHeight();
                errorProvider2.SetError(tbInaltime, "");
                isOk = true;
            }
            catch
            {
                errorProvider2.SetError(tbInaltime, "Invalid input");
                tbInaltime.Focus();
                isOk = false;
            }
            if (newHeight < 0 || newHeight > 1000) //la cat face overflow?
            {
                errorProvider2.SetError(tbInaltime, "Invalid input");
                tbInaltime.Focus();
                isOk = false;
            }
            else
            {
                errorProvider2.SetError(tbInaltime, "");
                isOk = true;
            }
        }
    }
}
