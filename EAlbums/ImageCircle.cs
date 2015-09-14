using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EgoDevil.Utilities.ThumbnailCreator;

namespace EAlbums
{
    public enum RevolveTypes
    {
        None = 0,
        Fixed = 1,
        Transformable = 2,
    }
    public class ImageCircle
    {

        private int maxImageCount = 10;

        public ImageCircle()
        {
            AlphaAccel = 0.0f;
            Images = new List<ThumbElement>();
        }

        public ImageCircle(Point circleCenter)
        {
            AlphaAccel = 0.0f;
            Images = new List<ThumbElement>();
            CircleCenter = circleCenter;
        }

        public float Alpha { get; set; }

        public float AlphaAccel { get; set; }

        public Color BackgroundColor { get; set; }

        public Point CircleCenter { get; set; }

        public float FixedAlphaAccel { get; set; }

        public Color HoverColor { get; set; }

        public List<ThumbElement> Images { get; set; }
        public int MaxImageCount
        {
            get { return maxImageCount; }
            set { maxImageCount = value; }
        }

        public float Perspective { get; set; }
        public Point Radius { get; set; }
        public RevolveTypes RevolveType { get; set; }
        public ThumbElement SelectedObject { get; set; }
        public void Clear()
        {
            if (Images != null)
            {
                Images.Clear();
            }

        }

        public void DrawImages(Graphics g)
        {
            foreach (var obj in Images)
            {
                obj.ThumbImage.DrawImage(g);
            }
        }

        public void Load(List<string> filePaths)
        {
            Clear();
            var count = filePaths.Count;

            if (count > MaxImageCount)
            {
                count = MaxImageCount;
            }
            for (var i = 0; i < count; i++)
            {
                var filePath = filePaths[i];
                var thumbnailCreation = new ThumbnailCreation();
                var bitmap = thumbnailCreation.CreateThumbnailImage(filePath);

                var angle = (double)((i * 360.0f) / count);
                var thumbImage = new ThumbImage(new Bitmap(bitmap), CircleCenter, angle)
                {
                    HoverColor = HoverColor
                };
                var thumbElement = new ThumbElement()
                {
                    FullPath = filePath,
                    Name = Path.GetFileNameWithoutExtension(filePaths[i]),
                    Description = string.Empty,
                    ThumbImage = thumbImage,
                };
                Images.Add(thumbElement);
            }
        }

        public void ClearHover()
        {
            foreach (var item in Images.Where(x => x.ThumbImage.IsHover))
            {
                item.ThumbImage.IsHover = false;
            }
        }
        public void Refresh()
        {
            System.Threading.Tasks.Parallel.ForEach(Images, obj =>
            {
                obj.ThumbImage.Alpha = Alpha;
                obj.ThumbImage.Radius = new Point(Radius.X, (int)(Radius.Y / Perspective));
                obj.ThumbImage.CircleCenter = CircleCenter;
                obj.ThumbImage.Refresh();
            });

            Images.Sort((p1, p2) => p2.ThumbImage.DistanceFromScreen.CompareTo(p1.ThumbImage.DistanceFromScreen));

        }

        public bool SelectHoverItem(Point location)
        {
            SelectedObject = null;
            System.Threading.Tasks.Parallel.ForEach(Images.Where(obj => obj.ThumbImage.CheckIsHover(location)), obj =>
            {
                SelectedObject = obj;
            });
            return (SelectedObject != null);

        }

        public void SetAlpha()
        {
            Alpha += GetAlphaAccel();

            if (Alpha > 360)
            {
                Alpha -= 360;
            }

            if (Alpha < 0)
            {
                Alpha += 360;
            }
        }

        private float GetAlphaAccel()
        {
            var result = 0.0f;
            switch (RevolveType)
            {
                case RevolveTypes.None:
                    result = 0;
                    break;
                case RevolveTypes.Fixed:
                    result = FixedAlphaAccel;
                    break;
                case RevolveTypes.Transformable:
                    result = AlphaAccel;
                    break;
                default:
                    result = 0;
                    break;
            }
            return result;
        }

        private void InitOriginalAngle()
        {
            for (var i = 0; i < Images.Count; i++)
            {
                Images[i].ThumbImage.OriginalAngle = (float)i * (360.0f) / (float)Images.Count;
            }

        }
    }
}
