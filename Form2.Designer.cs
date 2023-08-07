
namespace ComponentLearning_1
{
    partial class Form2
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
            this.labelHeight = new System.Windows.Forms.Label();
            this.labelWidth = new System.Windows.Forms.Label();
            this.tbInaltime = new System.Windows.Forms.TextBox();
            this.tbLatime = new System.Windows.Forms.TextBox();
            this.btnResize = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProvider2 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).BeginInit();
            this.SuspendLayout();
            // 
            // labelHeight
            // 
            this.labelHeight.AutoSize = true;
            this.labelHeight.Location = new System.Drawing.Point(46, 72);
            this.labelHeight.Name = "labelHeight";
            this.labelHeight.Size = new System.Drawing.Size(38, 13);
            this.labelHeight.TabIndex = 29;
            this.labelHeight.Text = "Height";
            // 
            // labelWidth
            // 
            this.labelWidth.AutoSize = true;
            this.labelWidth.Location = new System.Drawing.Point(46, 43);
            this.labelWidth.Name = "labelWidth";
            this.labelWidth.Size = new System.Drawing.Size(35, 13);
            this.labelWidth.TabIndex = 28;
            this.labelWidth.Text = "Width";
            // 
            // tbInaltime
            // 
            this.tbInaltime.Location = new System.Drawing.Point(138, 69);
            this.tbInaltime.Name = "tbInaltime";
            this.tbInaltime.Size = new System.Drawing.Size(82, 20);
            this.tbInaltime.TabIndex = 27;
            this.tbInaltime.TabStop = false;
            this.tbInaltime.Text = "255";
            this.tbInaltime.Validating += new System.ComponentModel.CancelEventHandler(this.tbInaltime_Validating);
            // 
            // tbLatime
            // 
            this.tbLatime.Location = new System.Drawing.Point(138, 40);
            this.tbLatime.Name = "tbLatime";
            this.tbLatime.Size = new System.Drawing.Size(82, 20);
            this.tbLatime.TabIndex = 26;
            this.tbLatime.TabStop = false;
            this.tbLatime.Text = "255";
            this.tbLatime.Validating += new System.ComponentModel.CancelEventHandler(this.tbLatime_Validating);
            // 
            // btnResize
            // 
            this.btnResize.Location = new System.Drawing.Point(82, 126);
            this.btnResize.Name = "btnResize";
            this.btnResize.Size = new System.Drawing.Size(95, 37);
            this.btnResize.TabIndex = 30;
            this.btnResize.Text = "Resize";
            this.btnResize.UseVisualStyleBackColor = true;
            this.btnResize.Click += new System.EventHandler(this.btnResize_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // errorProvider2
            // 
            this.errorProvider2.ContainerControl = this;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 256);
            this.Controls.Add(this.btnResize);
            this.Controls.Add(this.labelHeight);
            this.Controls.Add(this.labelWidth);
            this.Controls.Add(this.tbInaltime);
            this.Controls.Add(this.tbLatime);
            this.Name = "Form2";
            this.Text = "Form4";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelHeight;
        private System.Windows.Forms.Label labelWidth;
        public System.Windows.Forms.TextBox tbInaltime;
        public System.Windows.Forms.TextBox tbLatime;
        public System.Windows.Forms.Button btnResize;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ErrorProvider errorProvider2;
    }
}