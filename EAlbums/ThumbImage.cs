using System;
using System.Drawing;
using System.Drawing.Design;
using System.IO;
using System.Windows.Forms;

namespace EAlbums
{
    [Serializable]
    public class ThumbImage
    {

        private const double PiFact = Math.PI / 180.0f;//Circle angle   
        private double actualAngle;

        private Bitmap thumbOriginalBitmap;


        public Size BitmapSize = new Size(64, 64);

        public int MaxThumbSize = 64;

        public int PixelSize = 4;


        public double DistanceFromScreen { get; set; }
        public Point CircleCenter { get; set; }
        public Point Radius { get; set; }
        public float Alpha { get; set; }


        public bool IsHover { get; set; }

        public Color HoverColor { get; set; }
        public Color BackgroundColor { get; set; }
        public double OriginalAngle { get; set; }

        private Rectangle mainRect;

        private Rectangle shadowRect;

        public Bitmap ThumbMainBitmap { get; set; }
        public Bitmap ThumbShadowBitmap { get; set; }

        public Bitmap ThumbOriginalBitmap
        {
            get { return thumbOriginalBitmap; }
            set
            {
                thumbOriginalBitmap = value;
                if (thumbOriginalBitmap == null)
                {
                    return;
                }
                var nWidth = MaxThumbSize;
                var nHeight = thumbOriginalBitmap.Height * MaxThumbSize / thumbOriginalBitmap.Width;

                if (nHeight > MaxThumbSize)
                {
                    nHeight = MaxThumbSize;
                    nWidth = thumbOriginalBitmap.Width * MaxThumbSize / thumbOriginalBitmap.Height;
                }
                BitmapSize = new Size(nWidth, nHeight);
                ThumbMainBitmap = new Bitmap(nWidth, nHeight);
                Graphics g = Graphics.FromImage(ThumbMainBitmap);
                g.DrawImage(thumbOriginalBitmap, 0, 0, nWidth, nHeight);

                DrawShadow();

            }
        }


        public ThumbImage(Bitmap bitmap)
        {
            Alpha = 0;
            CircleCenter = new Point(0, 0);
            ThumbOriginalBitmap = bitmap;
        }

        public ThumbImage(Bitmap bitmap, Point circleCenter, double angle)
        {
            Alpha = 0;
            CircleCenter = circleCenter;
            this.OriginalAngle = angle;
            ThumbOriginalBitmap = bitmap;

        }
        public void DrawImage(Graphics g)
        {
            g.DrawImage(ThumbMainBitmap, mainRect);
            g.DrawImage(ThumbShadowBitmap, shadowRect);

            if (IsHover)
            {
                var pen = new Pen(HoverColor);
                g.DrawRectangle(pen, mainRect);
                pen.Dispose();
            }
            else
            {
                var dTrasp = (float)(100 + 100 * Math.Cos(actualAngle));
                var sb = new SolidBrush(Color.FromArgb((int)dTrasp, BackgroundColor.R, BackgroundColor.G, BackgroundColor.B));
                g.FillRectangle(sb, mainRect);
                g.FillRectangle(sb, shadowRect);
                sb.Dispose();
            }
        }

        public bool CheckIsHover(Point currectPoint)
        {
            IsHover = mainRect.Contains(currectPoint);
            return IsHover;
        }

        public void Refresh()
        {

            // angle and distance from screen
            actualAngle = (OriginalAngle + Alpha) * PiFact;

            DistanceFromScreen = 10 + 10 * Math.Cos(actualAngle);

            // rectangles
            var x = CircleCenter.X + (int)(Radius.X * Math.Sin(actualAngle));
            var y = CircleCenter.Y - (int)(Radius.Y * Math.Cos(actualAngle));

            var dSize = (float)(80 - 20 * Math.Cos(actualAngle));

            dSize = dSize / 100;

            mainRect.X = (int)(x - (BitmapSize.Width * dSize) / 2);
            mainRect.Y = (int)(y - (BitmapSize.Height * dSize));
            mainRect.Width = (int)(BitmapSize.Width * dSize);
            mainRect.Height = (int)(BitmapSize.Height * dSize);

            shadowRect.X = (int)(x - (BitmapSize.Width * dSize) / 2);
            shadowRect.Y = (int)y;
            shadowRect.Width = (int)(BitmapSize.Width * dSize);
            shadowRect.Height = (int)(BitmapSize.Height * dSize);


        }


        private unsafe void DrawShadow()
        {
            ThumbShadowBitmap = new Bitmap(ThumbMainBitmap);
            ThumbShadowBitmap.RotateFlip(RotateFlipType.RotateNoneFlipY);
            System.Drawing.Imaging.BitmapData bmd = ThumbShadowBitmap.LockBits(
                new Rectangle(0, 0, ThumbShadowBitmap.Width, ThumbShadowBitmap.Height), System.Drawing.Imaging.ImageLockMode.ReadWrite, ThumbShadowBitmap.PixelFormat);

            byte* row = (byte*)bmd.Scan0;

            for (var y = 0; y < bmd.Height; y++)
            {
                byte trasp = (byte)(100 * ((ThumbShadowBitmap.Height - y)) / ThumbShadowBitmap.Height);

                int xx = 3;

                for (var x = 0; x < bmd.Width; x++)
                {
                    row[xx] = trasp; //Alpha

                    xx += PixelSize;
                }

                row += bmd.Stride;
            }

            ThumbShadowBitmap.UnlockBits(bmd);
        }
    }
}