using ComponentLearning_2;

namespace ComponentLearning_1
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.webCameraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reloadInitialImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resizeDrawAreaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSaveImage = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.makeGrayToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.negativeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.blurToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.edgeDetectionToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.scalareToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.scatterPlotToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fluxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.procesariNumericeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clusterizareToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sVMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.indiciBiometriciToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.faceDetectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.no1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.no6CropToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.no2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.no25CropToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.no4EyesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.no35CropToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.no3EyesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.no5LandmarksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drawArea = new ComponentLearning_2.DrawArea();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.imageToolStripMenuItem,
            this.procesariNumericeToolStripMenuItem,
            this.faceDetectionToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(610, 24);
            this.menuStrip1.TabIndex = 51;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openImageToolStripMenuItem,
            this.webCameraToolStripMenuItem,
            this.reloadInitialImageToolStripMenuItem,
            this.resizeDrawAreaToolStripMenuItem,
            this.btnSaveImage,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openImageToolStripMenuItem
            // 
            this.openImageToolStripMenuItem.Name = "openImageToolStripMenuItem";
            this.openImageToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openImageToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.openImageToolStripMenuItem.Text = "Open";
            this.openImageToolStripMenuItem.Click += new System.EventHandler(this.OpenImage_Click);
            // 
            // webCameraToolStripMenuItem
            // 
            this.webCameraToolStripMenuItem.Name = "webCameraToolStripMenuItem";
            this.webCameraToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
            this.webCameraToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.webCameraToolStripMenuItem.Text = "Web camera ";
            this.webCameraToolStripMenuItem.Click += new System.EventHandler(this.webCamModuleToolStripMenuItem_Click);
            // 
            // reloadInitialImageToolStripMenuItem
            // 
            this.reloadInitialImageToolStripMenuItem.Name = "reloadInitialImageToolStripMenuItem";
            this.reloadInitialImageToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.reloadInitialImageToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.reloadInitialImageToolStripMenuItem.Text = "Reload";
            this.reloadInitialImageToolStripMenuItem.Click += new System.EventHandler(this.reloadInitialImage_Click);
            // 
            // resizeDrawAreaToolStripMenuItem
            // 
            this.resizeDrawAreaToolStripMenuItem.Name = "resizeDrawAreaToolStripMenuItem";
            this.resizeDrawAreaToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.resizeDrawAreaToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.resizeDrawAreaToolStripMenuItem.Text = "Resize Zoom";
            this.resizeDrawAreaToolStripMenuItem.Click += new System.EventHandler(this.resizeDrawAreaToolStripMenuItem_Click);
            // 
            // btnSaveImage
            // 
            this.btnSaveImage.Name = "btnSaveImage";
            this.btnSaveImage.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.btnSaveImage.Size = new System.Drawing.Size(188, 22);
            this.btnSaveImage.Text = "Save";
            this.btnSaveImage.Click += new System.EventHandler(this.SaveImage_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exit_Click);
            // 
            // imageToolStripMenuItem
            // 
            this.imageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.makeGrayToolStripMenuItem1,
            this.negativeToolStripMenuItem,
            this.blurToolStripMenuItem,
            this.resizeToolStripMenuItem,
            this.edgeDetectionToolStripMenuItem1,
            this.scalareToolStripMenuItem1,
            this.scatterPlotToolStripMenuItem,
            this.fluxToolStripMenuItem});
            this.imageToolStripMenuItem.Name = "imageToolStripMenuItem";
            this.imageToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.imageToolStripMenuItem.Text = "Image";
            // 
            // makeGrayToolStripMenuItem1
            // 
            this.makeGrayToolStripMenuItem1.Name = "makeGrayToolStripMenuItem1";
            this.makeGrayToolStripMenuItem1.Size = new System.Drawing.Size(154, 22);
            this.makeGrayToolStripMenuItem1.Text = "Make Gray";
            this.makeGrayToolStripMenuItem1.Click += new System.EventHandler(this.btnMakeGray_Click);
            // 
            // negativeToolStripMenuItem
            // 
            this.negativeToolStripMenuItem.Name = "negativeToolStripMenuItem";
            this.negativeToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.negativeToolStripMenuItem.Text = "Negative";
            this.negativeToolStripMenuItem.Click += new System.EventHandler(this.negative_Click);
            // 
            // blurToolStripMenuItem
            // 
            this.blurToolStripMenuItem.Name = "blurToolStripMenuItem";
            this.blurToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.blurToolStripMenuItem.Text = "Blur";
            this.blurToolStripMenuItem.Click += new System.EventHandler(this.blurr_Click);
            // 
            // resizeToolStripMenuItem
            // 
            this.resizeToolStripMenuItem.Name = "resizeToolStripMenuItem";
            this.resizeToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.resizeToolStripMenuItem.Text = "Resize";
            this.resizeToolStripMenuItem.Click += new System.EventHandler(this.Resize_Click);
            // 
            // edgeDetectionToolStripMenuItem1
            // 
            this.edgeDetectionToolStripMenuItem1.Name = "edgeDetectionToolStripMenuItem1";
            this.edgeDetectionToolStripMenuItem1.Size = new System.Drawing.Size(154, 22);
            this.edgeDetectionToolStripMenuItem1.Text = "Edge Detection";
            this.edgeDetectionToolStripMenuItem1.Click += new System.EventHandler(this.btnEdgeDetection_Click);
            // 
            // scalareToolStripMenuItem1
            // 
            this.scalareToolStripMenuItem1.Name = "scalareToolStripMenuItem1";
            this.scalareToolStripMenuItem1.Size = new System.Drawing.Size(154, 22);
            this.scalareToolStripMenuItem1.Text = "Scalare";
            this.scalareToolStripMenuItem1.Click += new System.EventHandler(this.btnScalare_Click);
            // 
            // scatterPlotToolStripMenuItem
            // 
            this.scatterPlotToolStripMenuItem.Name = "scatterPlotToolStripMenuItem";
            this.scatterPlotToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.scatterPlotToolStripMenuItem.Text = "Scatter Plot";
            this.scatterPlotToolStripMenuItem.Click += new System.EventHandler(this.btnScatterPlot_Click);
            // 
            // fluxToolStripMenuItem
            // 
            this.fluxToolStripMenuItem.Name = "fluxToolStripMenuItem";
            this.fluxToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.fluxToolStripMenuItem.Text = "Flux";
            this.fluxToolStripMenuItem.Click += new System.EventHandler(this.fluxToolStripMenuItem_Click);
            // 
            // procesariNumericeToolStripMenuItem
            // 
            this.procesariNumericeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clusterizareToolStripMenuItem,
            this.sVMToolStripMenuItem,
            this.indiciBiometriciToolStripMenuItem});
            this.procesariNumericeToolStripMenuItem.Name = "procesariNumericeToolStripMenuItem";
            this.procesariNumericeToolStripMenuItem.Size = new System.Drawing.Size(120, 20);
            this.procesariNumericeToolStripMenuItem.Text = "Procesari numerice";
            // 
            // clusterizareToolStripMenuItem
            // 
            this.clusterizareToolStripMenuItem.Name = "clusterizareToolStripMenuItem";
            this.clusterizareToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.clusterizareToolStripMenuItem.Text = "Clusterizare";
            this.clusterizareToolStripMenuItem.Click += new System.EventHandler(this.analizaMultidimensionalaToolStripMenuItem_Click);
            // 
            // sVMToolStripMenuItem
            // 
            this.sVMToolStripMenuItem.Name = "sVMToolStripMenuItem";
            this.sVMToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.sVMToolStripMenuItem.Text = "SVM";
            // 
            // indiciBiometriciToolStripMenuItem
            // 
            this.indiciBiometriciToolStripMenuItem.Name = "indiciBiometriciToolStripMenuItem";
            this.indiciBiometriciToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.indiciBiometriciToolStripMenuItem.Text = "Indici biometrici";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // faceDetectionToolStripMenuItem
            // 
            this.faceDetectionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.no1ToolStripMenuItem,
            this.no6CropToolStripMenuItem,
            this.no2ToolStripMenuItem,
            this.no25CropToolStripMenuItem,
            this.no4EyesToolStripMenuItem,
            this.no35CropToolStripMenuItem,
            this.no3EyesToolStripMenuItem,
            this.no5LandmarksToolStripMenuItem});
            this.faceDetectionToolStripMenuItem.Name = "faceDetectionToolStripMenuItem";
            this.faceDetectionToolStripMenuItem.Size = new System.Drawing.Size(96, 20);
            this.faceDetectionToolStripMenuItem.Text = "Face detection";
            // 
            // no1ToolStripMenuItem
            // 
            this.no1ToolStripMenuItem.Name = "no1ToolStripMenuItem";
            this.no1ToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.no1ToolStripMenuItem.Text = "no. 1 - face";
            this.no1ToolStripMenuItem.Click += new System.EventHandler(this.no1ToolStripMenuItem_Click);
            // 
            // no6CropToolStripMenuItem
            // 
            this.no6CropToolStripMenuItem.Name = "no6CropToolStripMenuItem";
            this.no6CropToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.no6CropToolStripMenuItem.Text = "no. 1 - crop";
            this.no6CropToolStripMenuItem.Click += new System.EventHandler(this.no1CropToolStripMenuItem_Click);
            // 
            // no2ToolStripMenuItem
            // 
            this.no2ToolStripMenuItem.Name = "no2ToolStripMenuItem";
            this.no2ToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.no2ToolStripMenuItem.Text = "no. 2 - face";
            this.no2ToolStripMenuItem.Click += new System.EventHandler(this.no2ToolStripMenuItem_Click);
            // 
            // no25CropToolStripMenuItem
            // 
            this.no25CropToolStripMenuItem.Name = "no25CropToolStripMenuItem";
            this.no25CropToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.no25CropToolStripMenuItem.Text = "no. 2 - crop";
            this.no25CropToolStripMenuItem.Click += new System.EventHandler(this.no2CropToolStripMenuItem_Click);
            // 
            // no4EyesToolStripMenuItem
            // 
            this.no4EyesToolStripMenuItem.Name = "no4EyesToolStripMenuItem";
            this.no4EyesToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.no4EyesToolStripMenuItem.Text = "no. 3 - face";
            this.no4EyesToolStripMenuItem.Click += new System.EventHandler(this.no3EyesToolStripMenuItem_Click);
            // 
            // no35CropToolStripMenuItem
            // 
            this.no35CropToolStripMenuItem.Name = "no35CropToolStripMenuItem";
            this.no35CropToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.no35CropToolStripMenuItem.Text = "no. 3 - crop";
            this.no35CropToolStripMenuItem.Click += new System.EventHandler(this.no3CropToolStripMenuItem_Click);
            // 
            // no3EyesToolStripMenuItem
            // 
            this.no3EyesToolStripMenuItem.Name = "no3EyesToolStripMenuItem";
            this.no3EyesToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.no3EyesToolStripMenuItem.Text = "no. 4 - eyes";
            this.no3EyesToolStripMenuItem.Click += new System.EventHandler(this.no4EyesToolStripMenuItem_Click);
            // 
            // no5LandmarksToolStripMenuItem
            // 
            this.no5LandmarksToolStripMenuItem.Name = "no5LandmarksToolStripMenuItem";
            this.no5LandmarksToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.no5LandmarksToolStripMenuItem.Text = "no. 5 - landmarks";
            this.no5LandmarksToolStripMenuItem.Click += new System.EventHandler(this.landmarkToolStripMenuItem_Click);
            // 
            // drawArea
            // 
            this.drawArea.Bitmap = null;
            this.drawArea.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.drawArea.FocusPoint = ((System.Drawing.PointF)(resources.GetObject("drawArea.FocusPoint")));
            this.drawArea.Location = new System.Drawing.Point(12, 61);
            this.drawArea.Name = "drawArea";
            this.drawArea.Size = new System.Drawing.Size(410, 312);
            this.drawArea.TabIndex = 49;
            this.drawArea.MouseDown += new System.Windows.Forms.MouseEventHandler(this.drawArea_MouseDown);
            this.drawArea.MouseMove += new System.Windows.Forms.MouseEventHandler(this.drawArea_MouseMove);
            this.drawArea.MouseUp += new System.Windows.Forms.MouseEventHandler(this.drawArea_MouseUp);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(610, 428);
            this.Controls.Add(this.drawArea);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.drawArea_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.drawArea_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.drawArea_MouseUp);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btnSaveImage;
        private System.Windows.Forms.ToolStripMenuItem reloadInitialImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem makeGrayToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem edgeDetectionToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem scalareToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem scatterPlotToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem negativeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem blurToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fluxToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem procesariNumericeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clusterizareToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sVMToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem indiciBiometriciToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        public DrawArea drawArea;
        private System.Windows.Forms.ToolStripMenuItem webCameraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem faceDetectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem no1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem no2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem no3EyesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem no4EyesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem no5LandmarksToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resizeDrawAreaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem no6CropToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem no25CropToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem no35CropToolStripMenuItem;
    }
}

