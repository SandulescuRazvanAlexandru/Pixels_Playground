using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge;
using AForge.Video;
using AForge.Video.DirectShow;

namespace ComponentLearning_4
{
    public partial class Form4 : Form
    {
        private FilterInfoCollection captureDevices = null;
        private VideoCaptureDevice videoSource = null;
        bool isStarted;

        public Form4()
        {
            InitializeComponent();
            InitializeComponent_2();
        }

        private void InitializeComponent_2()
        {
            captureDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo device in captureDevices)
            {
                cbCameras.Items.Add(device.Name);
            }
            cbCameras.SelectedIndex = 0;
            videoSource = new VideoCaptureDevice();
            isStarted = false;
            StartVideo();
        }

        private void btnStartStop_Click(object sender, EventArgs e)
        {
            if (isStarted)
            {
                StopVideo();
            }
            else
            {
                StartVideo();
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            StopVideo();
        }

        private void btnResetCapture_Click(object sender, EventArgs e)
        {
            ResetPictureBox(pictureBox2);
        }

        Bitmap bitmap = null;
        private void btnCapture_Click(object sender, EventArgs e)
        {
            bitmap = (Bitmap)pictureBox1.Image.Clone();
            pictureBox2.Image = bitmap;
        }

        private void btnRotate_Click(object sender, EventArgs e)
        {
            if (bitmap != null)
            {
                bitmap.RotateFlip(RotateFlipType.Rotate90FlipNone);
                pictureBox2.Image = bitmap;
            }
            else
            {
                NoPictureTaken();
            }
        }

        private void NoPictureTaken()
        {
            MessageBox.Show("No image taken");
        }

        public Bitmap sendBitmap()
        {
            return bitmap;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Exit();
        }

        private void btnSaveExit_Click(object sender, EventArgs e)
        {
            if(pictureBox2.Image == null)
            {
                NoPictureTaken();
            }
            else
            {
                btnSaveExit.DialogResult = DialogResult.OK;
                Exit();
            }
        }

        private void Exit()
        {
            StopVideo();
            this.Close();
        }

        private void VideoSource_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            pictureBox1.Image = (Bitmap)eventArgs.Frame.Clone();
        }

        private void StopVideo()
        {
            Polishing();
            isStarted = false;
        }

        private void Polishing()
        {
            if (videoSource.IsRunning == true)
            {
                videoSource.Stop();
            }
            ResetPictureBox(pictureBox1);
            ResetPictureBox(pictureBox2);
        }

        private void StartVideo()
        {
            videoSource = new VideoCaptureDevice(captureDevices[cbCameras.SelectedIndex].MonikerString);
            videoSource.NewFrame += new NewFrameEventHandler(VideoSource_NewFrame);
            videoSource.Start();
            isStarted = true;
        }

        private void StartVideo(object sender)
        {
            videoSource = new VideoCaptureDevice(captureDevices[((ComboBox)sender).SelectedIndex].MonikerString);
            videoSource.NewFrame += new NewFrameEventHandler(VideoSource_NewFrame);
            videoSource.Start();
            isStarted = true;
        }

        private void ResetPictureBox(PictureBox pictureBox)
        {
            pictureBox.Image = null;
            pictureBox.Invalidate();
        }

        private void cbCameras_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbCameras.SelectedIndex = ((ComboBox)sender).SelectedIndex;

            if (videoSource != null)
            {
                StopVideo(); 
                StartVideo(sender);
            }
        }

        
    }
}
