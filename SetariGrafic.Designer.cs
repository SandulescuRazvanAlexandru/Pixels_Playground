
namespace ComponentLearning_3
{
    partial class SetariGrafic
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SetariGrafic));
            this.groupBoxRetea = new System.Windows.Forms.GroupBox();
            this.liniiZ = new System.Windows.Forms.CheckBox();
            this.liniiY = new System.Windows.Forms.CheckBox();
            this.liniiX = new System.Windows.Forms.CheckBox();
            this.groupBoxPerspectiva = new System.Windows.Forms.GroupBox();
            this.azimutTB = new System.Windows.Forms.TextBox();
            this.elevatieTB = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBoxCulori = new System.Windows.Forms.GroupBox();
            this.albastruRB = new System.Windows.Forms.RadioButton();
            this.verdeRB = new System.Windows.Forms.RadioButton();
            this.portocaliuRB = new System.Windows.Forms.RadioButton();
            this.culoriMultipleRB = new System.Windows.Forms.RadioButton();
            this.buttonOK = new System.Windows.Forms.Button();
            this.groupBoxRetea.SuspendLayout();
            this.groupBoxPerspectiva.SuspendLayout();
            this.groupBoxCulori.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxRetea
            // 
            this.groupBoxRetea.Controls.Add(this.liniiZ);
            this.groupBoxRetea.Controls.Add(this.liniiY);
            this.groupBoxRetea.Controls.Add(this.liniiX);
            this.groupBoxRetea.Location = new System.Drawing.Point(41, 319);
            this.groupBoxRetea.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxRetea.Name = "groupBoxRetea";
            this.groupBoxRetea.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxRetea.Size = new System.Drawing.Size(275, 108);
            this.groupBoxRetea.TabIndex = 10;
            this.groupBoxRetea.TabStop = false;
            this.groupBoxRetea.Text = "Retea linii";
            // 
            // liniiZ
            // 
            this.liniiZ.AutoSize = true;
            this.liniiZ.Location = new System.Drawing.Point(9, 80);
            this.liniiZ.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.liniiZ.Name = "liniiZ";
            this.liniiZ.Size = new System.Drawing.Size(94, 21);
            this.liniiZ.TabIndex = 2;
            this.liniiZ.Text = "Linii axa Z";
            this.liniiZ.UseVisualStyleBackColor = true;
            // 
            // liniiY
            // 
            this.liniiY.AutoSize = true;
            this.liniiY.Location = new System.Drawing.Point(9, 53);
            this.liniiY.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.liniiY.Name = "liniiY";
            this.liniiY.Size = new System.Drawing.Size(94, 21);
            this.liniiY.TabIndex = 1;
            this.liniiY.Text = "Linii axa Y";
            this.liniiY.UseVisualStyleBackColor = true;
            // 
            // liniiX
            // 
            this.liniiX.AutoSize = true;
            this.liniiX.Location = new System.Drawing.Point(9, 25);
            this.liniiX.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.liniiX.Name = "liniiX";
            this.liniiX.Size = new System.Drawing.Size(94, 21);
            this.liniiX.TabIndex = 0;
            this.liniiX.Text = "Linii axa X";
            this.liniiX.UseVisualStyleBackColor = true;
            // 
            // groupBoxPerspectiva
            // 
            this.groupBoxPerspectiva.Controls.Add(this.azimutTB);
            this.groupBoxPerspectiva.Controls.Add(this.elevatieTB);
            this.groupBoxPerspectiva.Controls.Add(this.label4);
            this.groupBoxPerspectiva.Controls.Add(this.label3);
            this.groupBoxPerspectiva.Location = new System.Drawing.Point(41, 201);
            this.groupBoxPerspectiva.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxPerspectiva.Name = "groupBoxPerspectiva";
            this.groupBoxPerspectiva.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxPerspectiva.Size = new System.Drawing.Size(275, 100);
            this.groupBoxPerspectiva.TabIndex = 7;
            this.groupBoxPerspectiva.TabStop = false;
            this.groupBoxPerspectiva.Text = "Perspectiva";
            // 
            // azimutTB
            // 
            this.azimutTB.Location = new System.Drawing.Point(80, 65);
            this.azimutTB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.azimutTB.Name = "azimutTB";
            this.azimutTB.Size = new System.Drawing.Size(49, 22);
            this.azimutTB.TabIndex = 3;
            // 
            // elevatieTB
            // 
            this.elevatieTB.Location = new System.Drawing.Point(80, 30);
            this.elevatieTB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.elevatieTB.Name = "elevatieTB";
            this.elevatieTB.Size = new System.Drawing.Size(49, 22);
            this.elevatieTB.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 69);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 17);
            this.label4.TabIndex = 1;
            this.label4.Text = "Azimut";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 33);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "Elevatie";
            // 
            // groupBoxCulori
            // 
            this.groupBoxCulori.Controls.Add(this.albastruRB);
            this.groupBoxCulori.Controls.Add(this.verdeRB);
            this.groupBoxCulori.Controls.Add(this.portocaliuRB);
            this.groupBoxCulori.Controls.Add(this.culoriMultipleRB);
            this.groupBoxCulori.Location = new System.Drawing.Point(41, 34);
            this.groupBoxCulori.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxCulori.Name = "groupBoxCulori";
            this.groupBoxCulori.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBoxCulori.Size = new System.Drawing.Size(275, 148);
            this.groupBoxCulori.TabIndex = 8;
            this.groupBoxCulori.TabStop = false;
            this.groupBoxCulori.Text = "Culori";
            // 
            // albastruRB
            // 
            this.albastruRB.AutoSize = true;
            this.albastruRB.Location = new System.Drawing.Point(11, 23);
            this.albastruRB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.albastruRB.Name = "albastruRB";
            this.albastruRB.Size = new System.Drawing.Size(81, 21);
            this.albastruRB.TabIndex = 3;
            this.albastruRB.TabStop = true;
            this.albastruRB.Text = "Albastru";
            this.albastruRB.UseVisualStyleBackColor = true;
            // 
            // verdeRB
            // 
            this.verdeRB.AutoSize = true;
            this.verdeRB.Location = new System.Drawing.Point(9, 84);
            this.verdeRB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.verdeRB.Name = "verdeRB";
            this.verdeRB.Size = new System.Drawing.Size(67, 21);
            this.verdeRB.TabIndex = 2;
            this.verdeRB.TabStop = true;
            this.verdeRB.Text = "Verde";
            this.verdeRB.UseVisualStyleBackColor = true;
            // 
            // portocaliuRB
            // 
            this.portocaliuRB.AutoSize = true;
            this.portocaliuRB.Location = new System.Drawing.Point(9, 54);
            this.portocaliuRB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.portocaliuRB.Name = "portocaliuRB";
            this.portocaliuRB.Size = new System.Drawing.Size(92, 21);
            this.portocaliuRB.TabIndex = 1;
            this.portocaliuRB.TabStop = true;
            this.portocaliuRB.Text = "Portocaliu";
            this.portocaliuRB.UseVisualStyleBackColor = true;
            // 
            // culoriMultipleRB
            // 
            this.culoriMultipleRB.AutoSize = true;
            this.culoriMultipleRB.Location = new System.Drawing.Point(11, 112);
            this.culoriMultipleRB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.culoriMultipleRB.Name = "culoriMultipleRB";
            this.culoriMultipleRB.Size = new System.Drawing.Size(117, 21);
            this.culoriMultipleRB.TabIndex = 0;
            this.culoriMultipleRB.TabStop = true;
            this.culoriMultipleRB.Text = "Culori multiple";
            this.culoriMultipleRB.UseVisualStyleBackColor = true;
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(127, 458);
            this.buttonOK.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(100, 28);
            this.buttonOK.TabIndex = 12;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // SetariGrafic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(345, 507);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.groupBoxRetea);
            this.Controls.Add(this.groupBoxPerspectiva);
            this.Controls.Add(this.groupBoxCulori);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            //this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "SetariGrafic";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Setari grafic";
            this.groupBoxRetea.ResumeLayout(false);
            this.groupBoxRetea.PerformLayout();
            this.groupBoxPerspectiva.ResumeLayout(false);
            this.groupBoxPerspectiva.PerformLayout();
            this.groupBoxCulori.ResumeLayout(false);
            this.groupBoxCulori.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxRetea;
        private System.Windows.Forms.CheckBox liniiZ;
        private System.Windows.Forms.CheckBox liniiY;
        private System.Windows.Forms.CheckBox liniiX;
        private System.Windows.Forms.GroupBox groupBoxPerspectiva;
        private System.Windows.Forms.TextBox azimutTB;
        private System.Windows.Forms.TextBox elevatieTB;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBoxCulori;
        private System.Windows.Forms.RadioButton albastruRB;
        private System.Windows.Forms.RadioButton verdeRB;
        private System.Windows.Forms.RadioButton portocaliuRB;
        private System.Windows.Forms.RadioButton culoriMultipleRB;
        private System.Windows.Forms.Button buttonOK;

    }
}