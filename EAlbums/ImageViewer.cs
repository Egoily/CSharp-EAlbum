using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace EAlbums
{
    public partial class ImageViewer : UserControl
    {
        public int CircleCount = 3;

        public List<string> ImagePaths = new List<string>();

        public int Interval = 100;

        private readonly ImageCircleRevolver imageCircleRevolver = null;

        public ImageViewer()
        {
            InitializeComponent();

            this.SetStyle(
              ControlStyles.UserPaint |
              ControlStyles.AllPaintingInWmPaint |
              ControlStyles.DoubleBuffer, true);

            timer.Enabled = false;
            Pattern = Patterns.Pending;

            BackgroundColor = Color.FromArgb(255, 0, 0, 0);
            imageCircleRevolver = new ImageCircleRevolver()
            {
                BackgroundColor = BackgroundColor,
                CircleCount = CircleCount,
                Interval = Interval,
                OrginalCenter = new Point(Width / 2, Height / 2 - CircleCount * Interval / 2),
            };
        }

        public enum Patterns
        {
            Pending = 0,
            Loading = 1,
            Ready = 2,
            Browse = 3,
        }
        public float Alpha { get; set; }

        public Color BackgroundColor { get; set; }

        public Patterns Pattern { get; set; }
        public void Loading()
        {
            this.backgroundWorker.RunWorkerAsync();

            SetTimerEnabled(true);
            //BackgroundThread bt = new BackgroundThread(LoadThumbs);
            //bt.Start();
        }

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
        }

        private static RectangleF GetImageZoomRect(Size srcSize, Size desSize)
        {
            int width;
            int height;
            if (srcSize.Width <= desSize.Width && srcSize.Height <= desSize.Height)
            {
                width = srcSize.Width;
                height = srcSize.Height;
            }
            else if (srcSize.Width <= desSize.Width && srcSize.Height > desSize.Height)
            {
                height = desSize.Height;
                width = srcSize.Width * height / srcSize.Height;
            }
            else if (srcSize.Width > desSize.Width && srcSize.Height <= desSize.Height)
            {
                width = desSize.Width;
                height = srcSize.Height * width / srcSize.Width;
            }
            else
            {
                width = desSize.Width;
                height = srcSize.Height * width / srcSize.Width;
                if (height > desSize.Height)
                {
                    height = desSize.Height;
                    width = srcSize.Width * height / srcSize.Height;
                }
            }
            return new RectangleF(x: (desSize.Width - width) / 2, y: (desSize.Height - height) / 2, width: width, height: height);
        }

        private void AlbumView_MouseDown(object sender, MouseEventArgs e)
        {
            switch (Pattern)
            {
                case Patterns.Pending:
                    break;

                case Patterns.Loading:
                    break;

                case Patterns.Ready:
                    if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
                    {
                        if (imageCircleRevolver.SelectedObject != null)
                        {
                            SetTimerEnabled(false);
                            Pattern = Patterns.Browse;
                            Invalidate();
                        }
                    }
                    break;

                case Patterns.Browse:
                    if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
                    {
                        SetTimerEnabled(true);
                        Pattern = Patterns.Ready;
                        Invalidate();
                    }
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void AlbumView_MouseMove(object sender, MouseEventArgs e)
        {
            if (Pattern == Patterns.Ready)
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
        }

        private void AlbumView_Paint(object sender, PaintEventArgs e)
        {
            PaintAlbumView(e.Graphics);
        }

        private void backgroundWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            Pattern = Patterns.Loading;
            LoadThumbs();
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            Pattern = Patterns.Ready;
        }

        private void ImageViewer_Load(object sender, EventArgs e)
        {
        }

        private void PaintAlbumView(Graphics g)
        {
            //draw background
            g.FillRectangle(new SolidBrush(BackgroundColor), 0, 0, Width, Height);
            switch (Pattern)
            {
                case Patterns.Pending:
                    PaintPendingPattern(g);
                    break;

                case Patterns.Loading:
                    PaintLoadingPattern(g);
                    break;

                case Patterns.Ready:
                    PaintReadyPattern(g);
                    break;

                case Patterns.Browse:
                    PaintShowingPattern(g);
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void PaintLoadingPattern(Graphics g)
        {
            FontFamily fontFamily = new FontFamily("Arial");
            Font font = new Font(fontFamily, 36, FontStyle.Regular, GraphicsUnit.Pixel);
            g.DrawString("Loading...", font, Brushes.Red, new PointF(0, 0));
        }

        private void PaintPendingPattern(Graphics g)
        {
        }
        private void PaintReadyPattern(Graphics g)
        {
            imageCircleRevolver.SetOrginalCenter(new Point(Width / 2, Height / 2 - CircleCount * Interval / 2));
            imageCircleRevolver.DrawImages(g);
        }

        private void PaintShowingPattern(Graphics g)
        {
            if (imageCircleRevolver.SelectedObject != null)
            {
                using (var image = Image.FromFile(imageCircleRevolver.SelectedObject.FullPath))
                {
                    var units = GraphicsUnit.Pixel;
                    var desRect = GetImageZoomRect(image.Size, this.Size);
                    var srcRect = new RectangleF(0, 0, image.Width, image.Height);

                    g.DrawImage(image, desRect, srcRect, units);

                    imageCircleRevolver.ClearHover();
                    FontFamily fontFamily = new FontFamily("Arial");
                    Font font = new Font(fontFamily, 36, FontStyle.Regular, GraphicsUnit.Pixel);
                    g.DrawString(imageCircleRevolver.SelectedObject.Name, font, Brushes.Red, new PointF(0, 0));
                }
            }
        }
        private void RefreshImages()
        {
            if (Pattern == Patterns.Ready)
            {
                imageCircleRevolver.SetAlpha();
                imageCircleRevolver.Refresh();
                Invalidate();
            }
        }

        private bool SetTimerEnabled(bool enabled)
        {
            if (enabled)
            {
                if (!timer.Enabled)
                    timer.Enabled = true;
            }
            else
            {
                if (timer.Enabled)
                    timer.Enabled = false;
            }
            return timer.Enabled;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            RefreshImages();
        }
    }
}