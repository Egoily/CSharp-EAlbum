using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace EAlbums
{
    public partial class AlbumView : UserControl
    {
        private const double PI_FACT = Math.PI / 180.0f;//圆周角
        private const int MAXCOUNT = 100;//最大图像数

        private float _Alfa = 0;

        private float _AlfaAccel = 1;

        private float _Perspective = 4;//透视

        private ThumbElement _SelectedObject = null;

        private List<ThumbElement> _arImages1 = new List<ThumbElement>();
        private List<ThumbElement> _arImages2 = new List<ThumbElement>();

        public List<string> ImagePaths = new List<string>();

        private void InitOriginalAngle()
        {
            for (int i = 0; i < _arImages1.Count; i++)
            {
                _arImages1[i].OriginalAngle = (float)i * (360.0f) / (float)_arImages1.Count;
            }
            for (int i = 0; i < _arImages2.Count; i++)
            {
                _arImages2[i].OriginalAngle = (float)(i) * (360.0f) / ((float)_arImages2.Count);
            }
        }

        private void RePositionImages(List<ThumbElement> Images, int nRadX, int nRadY, int x0, int y0)
        {
            foreach (ThumbElement obj in Images)
            {
                // angle and distance from screen
                obj.ActualAngle = (obj.OriginalAngle + _Alfa) * PI_FACT;

                obj.DistanceFromScreen = 10 + 10 * Math.Cos(obj.ActualAngle);

                // rectangles
                int x = x0 + (int)(nRadX * Math.Sin(obj.ActualAngle));
                int y = y0 - (int)(nRadY * Math.Cos(obj.ActualAngle));

                float dSize = (float)(80 - 20 * Math.Cos(obj.ActualAngle));

                dSize = dSize / 100;

                obj.MainRect.X = (int)(x - (obj.MainBitmap.Width * dSize) / 2);
                obj.MainRect.Y = (int)(y - (obj.MainBitmap.Height * dSize));
                obj.MainRect.Width = (int)(obj.MainBitmap.Width * dSize);
                obj.MainRect.Height = (int)(obj.MainBitmap.Height * dSize);

                obj.ShadowRect.X = (int)(x - (obj.MainBitmap.Width * dSize) / 2);
                obj.ShadowRect.Y = (int)y;
                obj.ShadowRect.Width = (int)(obj.MainBitmap.Width * dSize);
                obj.ShadowRect.Height = (int)(obj.MainBitmap.Height * dSize);
            }

            Images.Sort(delegate(ThumbElement p1, ThumbElement p2) { return p2.DistanceFromScreen.CompareTo(p1.DistanceFromScreen); });
        }

        private void DrawImages(Graphics g, Color c, List<ThumbElement> Images)
        {
            foreach (ThumbElement obj in Images)
            {
                float dTrasp = (float)(100 + 100 * Math.Cos(obj.ActualAngle));

                g.DrawImage(obj.MainBitmap, obj.MainRect);
                g.DrawImage(obj.ShadowBitmap, obj.ShadowRect);

                if (obj.IsHover)
                {
                    g.DrawRectangle(Pens.White, obj.MainRect);
                }
                else
                {
                    SolidBrush sb = new SolidBrush(Color.FromArgb((int)dTrasp, c.R, c.G, c.B));
                    g.FillRectangle(sb, obj.MainRect);
                    g.FillRectangle(sb, obj.ShadowRect);
                }
            }
        }

        private void HoverSelecting(Point pt)
        {
            _SelectedObject = null;
            foreach (ThumbElement obj in _arImages1)
            {
                if (obj.MainRect.Contains(pt))
                {
                    obj.IsHover = true;
                    _SelectedObject = obj;
                }
                else
                {
                    obj.IsHover = false;
                }
            }

            foreach (ThumbElement obj in _arImages2)
            {
                if (obj.MainRect.Contains(pt))
                {
                    obj.IsHover = true;
                    _SelectedObject = obj;
                }
                else
                {
                    obj.IsHover = false;
                }
            }
        }

        private void ShowSelectedImage()
        {
            if (_SelectedObject != null)
            {
                apboxShowPicture.Image = Image.FromFile(_SelectedObject.FullPath);
                apboxShowPicture.Visible = true;
            }
            else
            {
                apboxShowPicture.Visible = false;
            }
        }

        private void LoadThumbs()
        {
            string dir = Path.Combine(Application.StartupPath, "Images");
            LoadThumbs(dir);
        }

        public void LoadThumbs(string dir)
        {
            if (Directory.Exists(dir))
            {
                timer.Enabled = false;

                String[] arStrings = Directory.GetFiles(dir);

                _arImages1.Clear();
                _arImages2.Clear();
                ImagePaths.Clear();

                int count = arStrings.Length;

                if (count > MAXCOUNT / 3)
                {
                    for (int i = 0; i < count / 2; i++)
                    {
                        _arImages1.Add(new ThumbElement(arStrings[i], (double)(i * (360.0f)) / (double)(count / 2)));
                        ImagePaths.Add(arStrings[i]);
                    }
                    for (int i = count / 2; i < count; i++)
                    {
                        _arImages2.Add(new ThumbElement(arStrings[i], (double)((i - count / 2) * (360.0f)) / (double)((count - count / 2))));
                        ImagePaths.Add(arStrings[i]);
                    }
                }
                else
                {
                    for (int i = 0; i < count; i++)
                    {
                        _arImages1.Add(new ThumbElement(arStrings[i], (double)(i * (360.0f)) / (double)(count)));
                        ImagePaths.Add(arStrings[i]);
                    }
                }

                //初始化角度
                //InitOriginalAngle();

                //Refresh();

                timer.Enabled = true;
            }
        }

        public void LoadThumbs(List<string> paths)
        {
            timer.Enabled = false;

            _arImages1.Clear();
            _arImages2.Clear();

            int count = paths.Count;
            if (count > MAXCOUNT / 3)
            {
                for (int i = 0; i < count / 2; i++)
                {
                    _arImages1.Add(new ThumbElement(paths[i], (double)(i * (360.0f)) / (double)(count / 2)));
                }
                for (int i = count / 2; i < count; i++)
                {
                    _arImages2.Add(new ThumbElement(paths[i], (double)((i - count / 2) * (360.0f)) / (double)(count / 2)));
                }
            }
            else
            {
                for (int i = 0; i < count; i++)
                {
                    _arImages1.Add(new ThumbElement(paths[i], (double)(i * (360.0f)) / (double)(count)));
                }
            }
            //初始化角度
            //InitOriginalAngle();
            //Refresh();
            timer.Enabled = true;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            _Alfa += _AlfaAccel;

            if (_Alfa > 360)
                _Alfa -= 360;

            if (_Alfa < 0)
                _Alfa += 360;

            //半径
            int nRadX = (Width / 2) * 7 / 10;
            int nRadY = (int)(nRadX / _Perspective);
            // 圆心
            int x01, y01, x02, y02;

            if (_arImages2.Count > 0)
            {
                x01 = Width / 2;
                y01 = Height / 4;

                x02 = Width / 2;
                y02 = 3 * Height / 4;
            }
            else
            {
                x01 = Width / 2;
                y01 = Height / 2;

                x02 = 0;
                y02 = 0;
            }

            RePositionImages(_arImages1, nRadX, nRadY, x01, y01);
            RePositionImages(_arImages2, nRadX, nRadY, x02, y02);

            //刷新
            Refresh();
        }

        public AlbumView()
        {
            InitializeComponent();

            this.SetStyle(
              ControlStyles.UserPaint |
              ControlStyles.AllPaintingInWmPaint |
              ControlStyles.DoubleBuffer, true);

            //Control.CheckForIllegalCrossThreadCalls = false;//允许跨线程操作(不安全)

            //Thread th = new Thread(new ThreadStart(LoadThumbs));
            //th.Priority = ThreadPriority.Highest;
            //th.Start();

            //EgoDevil.Utilities.BkWorker.BackgroundThread bt = new EgoDevil.Utilities.BkWorker.BackgroundThread(LoadThumbs);
            //bt.Start();

            LoadThumbs();
        }

        private void AlbumView_Paint(object sender, PaintEventArgs e)
        {
            Color c = Color.FromArgb(255, 0, 0, 0);

            e.Graphics.FillRectangle(new SolidBrush(c), 0, 0, Width, Height);

            //Drawing Items
            DrawImages(e.Graphics, c, _arImages1);

            DrawImages(e.Graphics, c, _arImages2);
        }

        private void apboxShowPicture_Paint(object sender, PaintEventArgs e)
        {
            FontFamily fontFamily = new FontFamily("Arial");
            Font font = new Font(fontFamily, 36, FontStyle.Regular, GraphicsUnit.Pixel);

            e.Graphics.DrawString(_SelectedObject.Name, font, Brushes.Red, new PointF(0, 0));
        }

        private void AlbumView_MouseDown(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                //显示选中的图片
                ShowSelectedImage();
            }
        }

        private void AlbumView_MouseMove(object sender, MouseEventArgs e)
        {
            int x0 = Width / 2;
            int y0 = Height / 2;

            _AlfaAccel = (((float)(e.X - x0)) * 3.0f) / ((float)x0);

            if ((e.Button & MouseButtons.Right) == MouseButtons.Right)
                _Perspective = 12 - (((float)(-e.Y + y0)) * 10.0f) / ((float)y0);

            HoverSelecting(e.Location);
        }

        private void apboxShowPicture_Click(object sender, EventArgs e)
        {
            apboxShowPicture.Visible = false;
        }
    }
}