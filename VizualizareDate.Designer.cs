
using System.Windows.Forms;

namespace ComponentLearning_3
{
    partial class VizualizareDate
    {
        
            /// <summary>
            /// Required designer variable.
            /// </summary>
            private System.ComponentModel.IContainer components = null;

            /// <summary>
            /// Clean up any resources being used.
            /// </summary>
            /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
            protected override void Dispose(bool disposing)
            {
                if (disposing && (components != null))
                {
                    components.Dispose();
                }
                base.Dispose(disposing);
            }

            #region Windows Form Designer generated code

            /// <summary>
            /// Required method for Designer support - do not modify
            /// the contents of this method with the code editor.
            /// </summary>
            private void InitializeComponent()
            {
                this.components = new System.ComponentModel.Container();
                System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VizualizareDate));
                this.checkBoxDistantaMinima = new System.Windows.Forms.CheckBox();
                this.checkBoxDistantaMaxima = new System.Windows.Forms.CheckBox();
                this.checkBoxRegresie = new System.Windows.Forms.CheckBox();
                this.label10 = new System.Windows.Forms.Label();
                this.label9 = new System.Windows.Forms.Label();
                this.numericUpDownClustere = new System.Windows.Forms.NumericUpDown();
                this.label2 = new System.Windows.Forms.Label();
                this.textBoxDetalii = new System.Windows.Forms.TextBox();
                this.menuStrip1 = new System.Windows.Forms.MenuStrip();
                this.setariGraficToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
                this.tabelDateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
                this.checkBoxPolinomiala = new System.Windows.Forms.CheckBox();
                this.checkBoxBaza = new System.Windows.Forms.CheckBox();
                this.grafic = new ControlUtilizator.ControlGrafic();
                this.checkBoxVectori = new System.Windows.Forms.CheckBox();
                this.checkBoxBazaCov = new System.Windows.Forms.CheckBox();
                ((System.ComponentModel.ISupportInitialize)(this.numericUpDownClustere)).BeginInit();
                this.menuStrip1.SuspendLayout();
                this.SuspendLayout();
                // 
                // checkBoxDistantaMinima
                // 
                this.checkBoxDistantaMinima.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
                this.checkBoxDistantaMinima.AutoSize = true;
                this.checkBoxDistantaMinima.Location = new System.Drawing.Point(860, 115);
                this.checkBoxDistantaMinima.Margin = new System.Windows.Forms.Padding(4);
                this.checkBoxDistantaMinima.Name = "checkBoxDistantaMinima";
                this.checkBoxDistantaMinima.Size = new System.Drawing.Size(142, 21);
                this.checkBoxDistantaMinima.TabIndex = 17;
                this.checkBoxDistantaMinima.Text = "Minimum distance";
                this.checkBoxDistantaMinima.UseVisualStyleBackColor = true;
                // 
                // checkBoxDistantaMaxima
                // 
                this.checkBoxDistantaMaxima.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
                this.checkBoxDistantaMaxima.AutoSize = true;
                this.checkBoxDistantaMaxima.Location = new System.Drawing.Point(860, 144);
                this.checkBoxDistantaMaxima.Margin = new System.Windows.Forms.Padding(4);
                this.checkBoxDistantaMaxima.Name = "checkBoxDistantaMaxima";
                this.checkBoxDistantaMaxima.Size = new System.Drawing.Size(145, 21);
                this.checkBoxDistantaMaxima.TabIndex = 16;
                this.checkBoxDistantaMaxima.Text = "Maximum distance";
                this.checkBoxDistantaMaxima.UseVisualStyleBackColor = true;
                // 
                // checkBoxRegresie
                // 
                this.checkBoxRegresie.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
                this.checkBoxRegresie.AutoSize = true;
                this.checkBoxRegresie.Location = new System.Drawing.Point(860, 58);
                this.checkBoxRegresie.Margin = new System.Windows.Forms.Padding(4);
                this.checkBoxRegresie.Name = "checkBoxRegresie";
                this.checkBoxRegresie.Size = new System.Drawing.Size(180, 21);
                this.checkBoxRegresie.TabIndex = 15;
                this.checkBoxRegresie.Text = "Linear regression plane";
                this.checkBoxRegresie.UseVisualStyleBackColor = true;
                // 
                // label10
                // 
                this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
                this.label10.AutoSize = true;
                this.label10.Location = new System.Drawing.Point(997, 266);
                this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
                this.label10.Name = "label10";
                this.label10.Size = new System.Drawing.Size(57, 17);
                this.label10.TabIndex = 14;
                this.label10.Text = "clusters";
                // 
                // label9
                // 
                this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
                this.label9.AutoSize = true;
                this.label9.Location = new System.Drawing.Point(856, 266);
                this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
                this.label9.Name = "label9";
                this.label9.Size = new System.Drawing.Size(83, 17);
                this.label9.TabIndex = 13;
                this.label9.Text = "Classified in";
                // 
                // numericUpDownClustere
                // 
                this.numericUpDownClustere.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
                this.numericUpDownClustere.Location = new System.Drawing.Point(941, 263);
                this.numericUpDownClustere.Margin = new System.Windows.Forms.Padding(4);
                this.numericUpDownClustere.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
                this.numericUpDownClustere.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
                this.numericUpDownClustere.Name = "numericUpDownClustere";
                this.numericUpDownClustere.Size = new System.Drawing.Size(48, 22);
                this.numericUpDownClustere.TabIndex = 12;
                this.numericUpDownClustere.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
                // 
                // label2
                // 
                this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                | System.Windows.Forms.AnchorStyles.Right)));
                this.label2.AutoSize = true;
                this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.label2.Location = new System.Drawing.Point(943, 299);
                this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
                this.label2.Name = "label2";
                this.label2.Size = new System.Drawing.Size(71, 25);
                this.label2.TabIndex = 18;
                this.label2.Text = "Details";
                // 
                // textBoxDetalii
                // 
                this.textBoxDetalii.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                | System.Windows.Forms.AnchorStyles.Right)));
                this.textBoxDetalii.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.textBoxDetalii.Location = new System.Drawing.Point(820, 340);
                this.textBoxDetalii.Margin = new System.Windows.Forms.Padding(4);
                this.textBoxDetalii.Multiline = true;
                this.textBoxDetalii.Name = "textBoxDetalii";
                this.textBoxDetalii.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
                this.textBoxDetalii.Size = new System.Drawing.Size(312, 281);
                this.textBoxDetalii.TabIndex = 19;
                // 
                // menuStrip1
                // 
                this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
                this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setariGraficToolStripMenuItem,
            this.tabelDateToolStripMenuItem});
                this.menuStrip1.Location = new System.Drawing.Point(0, 0);
                this.menuStrip1.Name = "menuStrip1";
                this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
                this.menuStrip1.Size = new System.Drawing.Size(1133, 28);
                this.menuStrip1.TabIndex = 20;
                this.menuStrip1.Text = "menuStrip1";
                // 
                // setariGraficToolStripMenuItem
                // 
                this.setariGraficToolStripMenuItem.Name = "setariGraficToolStripMenuItem";
                this.setariGraficToolStripMenuItem.Size = new System.Drawing.Size(127, 24);
                this.setariGraficToolStripMenuItem.Text = "Graphic settings";
                this.setariGraficToolStripMenuItem.Click += new System.EventHandler(this.setariGraficToolStripMenuItem_Click);
                // 
                // tabelDateToolStripMenuItem
                // 
                this.tabelDateToolStripMenuItem.Name = "tabelDateToolStripMenuItem";
                this.tabelDateToolStripMenuItem.Size = new System.Drawing.Size(91, 24);
                this.tabelDateToolStripMenuItem.Text = "Data table";
                this.tabelDateToolStripMenuItem.Click += new System.EventHandler(this.tabelDateToolStripMenuItem_Click);
                // 
                // checkBoxPolinomiala
                // 
                this.checkBoxPolinomiala.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
                this.checkBoxPolinomiala.AutoSize = true;
                this.checkBoxPolinomiala.Location = new System.Drawing.Point(860, 87);
                this.checkBoxPolinomiala.Margin = new System.Windows.Forms.Padding(4);
                this.checkBoxPolinomiala.Name = "checkBoxPolinomiala";
                this.checkBoxPolinomiala.Size = new System.Drawing.Size(208, 21);
                this.checkBoxPolinomiala.TabIndex = 21;
                this.checkBoxPolinomiala.Text = "Polynomial regression plane";
                this.checkBoxPolinomiala.UseVisualStyleBackColor = true;
                this.checkBoxPolinomiala.CheckedChanged += new System.EventHandler(this.checkBoxPolinomiala_CheckedChanged);
                // 
                // checkBoxBaza
                // 
                this.checkBoxBaza.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
                this.checkBoxBaza.AutoSize = true;
                this.checkBoxBaza.Location = new System.Drawing.Point(860, 174);
                this.checkBoxBaza.Margin = new System.Windows.Forms.Padding(4);
                this.checkBoxBaza.Name = "checkBoxBaza";
                this.checkBoxBaza.Size = new System.Drawing.Size(149, 21);
                this.checkBoxBaza.TabIndex = 22;
                this.checkBoxBaza.Text = "Eigenvectors basis";
                this.checkBoxBaza.UseVisualStyleBackColor = true;
                this.checkBoxBaza.CheckedChanged += new System.EventHandler(this.checkBoxBaza_CheckedChanged);
                // 
                // grafic
                // 
                this.grafic.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
                this.grafic.BackColor = System.Drawing.Color.White;
                this.grafic.Location = new System.Drawing.Point(56, 42);
                this.grafic.Margin = new System.Windows.Forms.Padding(5);
                this.grafic.Name = "grafic";
                this.grafic.Size = new System.Drawing.Size(712, 579);
                this.grafic.TabIndex = 0;
                // 
                // checkBoxVectori
                // 
                this.checkBoxVectori.AutoSize = true;
                this.checkBoxVectori.Location = new System.Drawing.Point(859, 231);
                this.checkBoxVectori.Margin = new System.Windows.Forms.Padding(4);
                this.checkBoxVectori.Name = "checkBoxVectori";
                this.checkBoxVectori.Size = new System.Drawing.Size(114, 21);
                this.checkBoxVectori.TabIndex = 23;
                this.checkBoxVectori.Text = "EigenVectors";
                this.checkBoxVectori.UseVisualStyleBackColor = true;
                this.checkBoxVectori.CheckedChanged += new System.EventHandler(this.checkBoxVectori_CheckedChanged);
                // 
                // checkBoxBazaCov
                // 
                this.checkBoxBazaCov.AutoSize = true;
                this.checkBoxBazaCov.Location = new System.Drawing.Point(859, 202);
                this.checkBoxBazaCov.Margin = new System.Windows.Forms.Padding(4);
                this.checkBoxBazaCov.Name = "checkBoxBazaCov";
                this.checkBoxBazaCov.Size = new System.Drawing.Size(266, 21);
                this.checkBoxBazaCov.TabIndex = 24;
                this.checkBoxBazaCov.Text = "Covariance matrix eigenVectors basis";
                this.checkBoxBazaCov.UseVisualStyleBackColor = true;
                this.checkBoxBazaCov.CheckedChanged += new System.EventHandler(this.checkBoxBazaCov_CheckedChanged);
                // 
                // VizualizareDate
                // 
                this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.ClientSize = new System.Drawing.Size(1133, 636);
                this.Controls.Add(this.checkBoxBazaCov);
                this.Controls.Add(this.checkBoxVectori);
                this.Controls.Add(this.checkBoxBaza);
                this.Controls.Add(this.checkBoxPolinomiala);
                this.Controls.Add(this.textBoxDetalii);
                this.Controls.Add(this.label2);
                this.Controls.Add(this.checkBoxDistantaMinima);
                this.Controls.Add(this.checkBoxDistantaMaxima);
                this.Controls.Add(this.checkBoxRegresie);
                this.Controls.Add(this.label10);
                this.Controls.Add(this.label9);
                this.Controls.Add(this.numericUpDownClustere);
                this.Controls.Add(this.grafic);
                this.Controls.Add(this.menuStrip1);
                //this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
                this.MainMenuStrip = this.menuStrip1;
                this.Margin = new System.Windows.Forms.Padding(4);
                this.Name = "VizualizareDate";
                this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                this.Text = "Data graphic";
                this.Resize += new System.EventHandler(this.VizualizareDate_Resize);
                ((System.ComponentModel.ISupportInitialize)(this.numericUpDownClustere)).EndInit();
                this.menuStrip1.ResumeLayout(false);
                this.menuStrip1.PerformLayout();
                this.ResumeLayout(false);
                this.PerformLayout();

            }

            #endregion

            private ControlUtilizator.ControlGrafic grafic;
            private System.Windows.Forms.CheckBox checkBoxDistantaMinima;
            private System.Windows.Forms.CheckBox checkBoxDistantaMaxima;
            private System.Windows.Forms.CheckBox checkBoxRegresie;
            private System.Windows.Forms.Label label10;
            private System.Windows.Forms.Label label9;
            private System.Windows.Forms.NumericUpDown numericUpDownClustere;
            private System.Windows.Forms.Label label2;
            private System.Windows.Forms.TextBox textBoxDetalii;
            private System.Windows.Forms.MenuStrip menuStrip1;
            private System.Windows.Forms.ToolStripMenuItem setariGraficToolStripMenuItem;
            private ToolStripMenuItem tabelDateToolStripMenuItem;
            private CheckBox checkBoxPolinomiala;
            private CheckBox checkBoxBaza;
            private CheckBox checkBoxVectori;
            private CheckBox checkBoxBazaCov;
        }
}