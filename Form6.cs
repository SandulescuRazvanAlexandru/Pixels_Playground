using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace MachineLearningApp
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
            textBox1.Text = "\r\nComponente pentru Învățare asistată\r\n\r\nCoordonator științific: Prof.Univ.Dr. Smeureanu Ion\r\n\r\nAbsolvent: Săndulescu Răzvan-Alexandru" +
                "\r\n\r\nVă mulțumesc!";
            textBox1.TextAlign = HorizontalAlignment.Center;
            textBox1.Font = new Font(textBox1.Font.FontFamily, 16);
        }

        private void Form6_Load(object sender, EventArgs e)
        {

        }
    }
}
