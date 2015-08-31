using System;
using System.Drawing;
using System.IO;

namespace EAlbums
{
    internal class ThumbElement
    {
        static public int ThumbSize = 64;

        public Bitmap MainBitmap = null;
        public Bitmap ShadowBitmap = null;

        public Rectangle MainRect = new Rectangle();
        public Rectangle ShadowRect = new Rectangle();

        public double OriginalAngle = 0;
        public double ActualAngle = 0;

        public double DistanceFromScreen = 0;

        public string Name;
        public string FullPath;

        public bool IsHover;

        private void Setting(String strFileName, double angle)
        {
            Bitmap bmpOriginal = new Bitmap(strFileName);

            Name = Path.GetFileNameWithoutExtension(strFileName);
            FullPath = strFileName;

            int nWidth = ThumbSize;
            int nHeight = bmpOriginal.Height * ThumbSize / bmpOriginal.Width;

            if (nHeight > ThumbSize)
            {
                nHeight = ThumbSize;
                nWidth = bmpOriginal.Width * ThumbSize / bmpOriginal.Height;
            }

            MainBitmap = new Bitmap(nWidth, nHeight);

            Graphics g = Graphics.FromImage(MainBitmap);

            g.DrawImage(bmpOriginal, 0, 0, nWidth, nHeight);

            ShadowBitmap = new Bitmap(MainBitmap);

            #region (* 阴影部分 *)

            //阴影部分
            unsafe
            {
                ShadowBitmap.RotateFlip(RotateFlipType.RotateNoneFlipY);

                System.Drawing.Imaging.BitmapData bmd = ShadowBitmap.LockBits(new Rectangle(0, 0, ShadowBitmap.Width, ShadowBitmap.Height),
                                                                             System.Drawing.Imaging.ImageLockMode.ReadWrite,
                                                                             ShadowBitmap.PixelFormat);

                int PixelSize = 4;

                byte* row = (byte*)bmd.Scan0;

                for (int y = 0; y < bmd.Height; y++)
                {
                    byte trasp = (byte)(100 * ((MainBitmap.Height - y)) / MainBitmap.Height);

                    int xx = 3;

                    for (int x = 0; x < bmd.Width; x++)
                    {
                        row[xx] = trasp;//更改Alpha的值

                        xx += PixelSize;
                    }

                    row += bmd.Stride;
                }

                ShadowBitmap.UnlockBits(bmd);
            }

            #endregion

            this.OriginalAngle = angle;
        }

        public ThumbElement(String strFileName)
        {
            Setting(strFileName, 0d);
        }

        public ThumbElement(String strFileName, double angle)
        {
            Setting(strFileName, angle);
        }
    }
}