using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

using EgoDevil.Utilities.BkWorker;

namespace EAlbums
{
    public partial class ImageViewer : UserControl
    {
        public enum Statuses
        {
            Ready = 0,
            Loading = 1,
            Loaded = 2,
        }
        public int CircleCount = 3;
        public List<string> ImagePaths = new List<string>();

        public int Interval = 100;
        private readonly ImageCircleRevolver imageCircleRevolver = null;
        private bool isShowingImage = false;

        public Statuses Status { get; set; }


        public ImageViewer()
        {
            InitializeComponent();

            this.SetStyle(
              ControlStyles.UserPaint |
              ControlStyles.AllPaintingInWmPaint |
              ControlStyles.DoubleBuffer, true);

            timer.Enabled = false;
            Status = Statuses.Ready;

            BackgroundColor = Color.FromArgb(255, 0, 0, 0);
            imageCircleRevolver = new ImageCircleRevolver()
            {
                BackgroundColor = BackgroundColor,
                CircleCount = CircleCount,
                Interval = Interval,
                OrginalCenter = new Point(Width / 2, Height / 2 - CircleCount * Interval / 2),
            };

        }

        public float Alpha { get; set; }

        public Color BackgroundColor { get; set; }
        public void LoadThumbs()
        {
            var dir = Path.Combine(Application.StartupPath, "Images");
            LoadThumbs(dir);

        }
        public void LoadThumbs(string dir)
        {
            if (!Directory.Exists(dir))
            {
                return;
            }
            var filePaths = Directory.GetFiles(dir);
            LoadThumbs(filePaths.ToList());

        }

        public void LoadThumbs(List<string> filePaths)
        {
            imageCircleRevolver.Load(filePaths);
            Status = Statuses.Loaded;
        }

        private void AlbumView_MouseDown(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                ShowSelectedImage();
            }
        }

        private void AlbumView_MouseMove(object sender, MouseEventArgs e)
        {

            imageCircleRevolver.SetRevolveType(RevolveTypes.Fixed);
            var x0 = Width / 2;
            var y0 = Height / 2;

            imageCircleRevolver.SetAlphaAccel((((float)(e.X - x0)) * 3.0f) / ((float)x0));

            if ((e.Button & MouseButtons.Right) == MouseButtons.Right)
            {
                imageCircleRevolver.SetPerspective(12 - (((float)(-e.Y + y0)) * 10.0f) / ((float)y0));
            }
            else if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                imageCircleRevolver.SetRevolveType(RevolveTypes.Transformable);
            }

            var isHover = imageCircleRevolver.SelectHoverItem(e.Location);
            if (isHover)
            {
                imageCircleRevolver.SetRevolveType(RevolveTypes.None);
            }


        }

        private void AlbumView_Paint(object sender, PaintEventArgs e)
        {
            //draw background
            e.Graphics.FillRectangle(new SolidBrush(BackgroundColor), 0, 0, Width, Height);
         
            switch (Status)
            {
                case Statuses.Ready:
                   
                    break;
                case Statuses.Loading:
                    FontFamily fontFamily = new FontFamily("Arial");
                    Font font = new Font(fontFamily, 36, FontStyle.Regular, GraphicsUnit.Pixel);
                    e.Graphics.DrawString("Loading...", font, Brushes.Red, new PointF(0, 0));
                    break;
                case Statuses.Loaded:
                    if (!isShowingImage)
                    {
                        imageCircleRevolver.SetOrginalCenter(new Point(Width / 2, Height / 2 - CircleCount * Interval / 2));
                        imageCircleRevolver.DrawImages(e.Graphics);
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }



        }

        private void apboxShowPicture_Click(object sender, EventArgs e)
        {
            apboxShowPicture.Visible = false;
            if (!timer.Enabled)
            {
                timer.Enabled = true;
            }
            isShowingImage = false;
        }

        private void apboxShowPicture_Paint(object sender, PaintEventArgs e)
        {
            if (imageCircleRevolver.SelectedObject != null)
            {
                FontFamily fontFamily = new FontFamily("Arial");
                Font font = new Font(fontFamily, 36, FontStyle.Regular, GraphicsUnit.Pixel);
                e.Graphics.DrawString(imageCircleRevolver.SelectedObject.Name, font, Brushes.Red, new PointF(0, 0));
            }

        }


        private void ImageViewer_Load(object sender, EventArgs e)
        {

        }

        private void RefreshImages()
        {
            if (Status == Statuses.Loaded)
            {
                imageCircleRevolver.SetAlpha();
                imageCircleRevolver.Refresh();
                Invalidate();
            }
        }
        private void ShowSelectedImage()
        {

            if (imageCircleRevolver.SelectedObject != null)
            {

                apboxShowPicture.Image = Image.FromFile(imageCircleRevolver.SelectedObject.FullPath);

                apboxShowPicture.Visible = true;
                if (timer.Enabled)
                {
                    timer.Enabled = false;
                }
                imageCircleRevolver.ClearHover();
                isShowingImage = true;
            }
            else
            {
                apboxShowPicture.Visible = false;
                if (!timer.Enabled)
                {
                    timer.Enabled = true;
                }
                isShowingImage = false;
            }
            Invalidate();
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            RefreshImages();
        }

        private void backgroundWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            Status = Statuses.Loading;
            LoadThumbs();
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            Status = Statuses.Loaded;
        }

        public void Loading()
        {
            this.backgroundWorker.RunWorkerAsync();
            timer.Enabled = true;
            //BackgroundThread bt = new BackgroundThread(LoadThumbs);
            //bt.Start();
        }
    }
}