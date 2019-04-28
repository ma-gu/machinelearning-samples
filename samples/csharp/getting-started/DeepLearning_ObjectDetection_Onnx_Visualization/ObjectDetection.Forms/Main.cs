using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ObjectDetection.Forms
{
    public partial class Main : Form
    {
        VideoCapture Capture { get; set; }

        public Main()
        {
            InitializeComponent();
        }

        private void ProcessButton_Click(object sender, EventArgs e)
        {
            Capture = new VideoCapture(FileNameTextBox.Text);
            Capture.Start();
            Capture.ImageGrabbed += ProcessFrame;
        }

        private void ProcessFrame(object sender, EventArgs e)
        {
            var mat = new Mat();
            Capture.Read(mat);

            if (mat.IsEmpty) return;
            DisplayImage(mat.ToImage<Bgr, byte>());
        }


        private delegate void DisplayImageDelegate(IImage image);
        private void DisplayImage(IImage image)
        {
            if (VideoImage.InvokeRequired)
            {
                try
                {
                    var DI = new DisplayImageDelegate(DisplayImage);
                    this.BeginInvoke(DI, new object[] { image });
                }
                catch (Exception ex)
                {
                }
            }
            else
            {
                VideoImage.Image = image;
            }
        }

        private void ProcessImageButton_Click(object sender, EventArgs e)
        {

        }
    }
}
