using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAlbums
{
    public class ImageCircleRevolver
    {
        public List<ImageCircle> Circles { get; set; }
        public int CircleCount { get; set; }

        public int Interval { get; set; }

        public Point OrginalCenter { get; set; }

        public float Alpha { get; set; }

        public Color BackgroundColor { get; set; }
        public ThumbElement SelectedObject { get; set; }
        public ImageCircleRevolver()
        {
            Circles = new List<ImageCircle>();
        }

        public void Load(List<string> filePaths)
        {

            for (var i = 0; i < CircleCount; i++)
            {
                var center = new Point(OrginalCenter.X, OrginalCenter.Y + i * Interval);
                var circle = new ImageCircle()
                {

                    BackgroundColor = BackgroundColor,
                    HoverColor = Color.White,
                    Perspective = 4,
                    CircleCenter = center,
                    Radius = new Point(400, 100),
                    FixedAlphaAccel = 0.1f,
                    MaxImageCount = 20,
                    RevolveType = RevolveTypes.Fixed,
                };
                Circles.Add(circle);

                var paths = new List<string>();
                for (int j = i * circle.MaxImageCount; j < (i + 1) * circle.MaxImageCount; j++)
                {
                    if (j >= filePaths.Count)
                        break;
                    paths.Add(filePaths[j]);
                }
                circle.Load(paths);

            }


        }

        public void SetAlpha()
        {
            System.Threading.Tasks.Parallel.ForEach(Circles, obj =>
            {
                obj.SetAlpha();
            });
        }

        public void SetAlphaAccel(float alphaAccel)
        {
            System.Threading.Tasks.Parallel.ForEach(Circles, obj =>
            {
                obj.AlphaAccel = alphaAccel;
            });
        }
        public void SetPerspective(float perspective)
        {
            System.Threading.Tasks.Parallel.ForEach(Circles, obj =>
            {
                obj.Perspective = perspective;
            });
        }
        public void Refresh()
        {
            System.Threading.Tasks.Parallel.ForEach(Circles, obj =>
            {
                obj.Refresh();
            });
        }

        public void ClearHover()
        {
            System.Threading.Tasks.Parallel.ForEach(Circles, obj =>
            {
                obj.ClearHover();
            });
        }

        public void DrawImages(Graphics g)
        {
            foreach (var obj in Circles)
            {
                obj.DrawImages(g);
            }
        }

        public bool SelectHoverItem(Point location)
        {
            SelectedObject = null;
            System.Threading.Tasks.Parallel.ForEach(Circles, obj =>
            {
                obj.SelectHoverItem(location);
            });
            SelectedObject = GetSelectedObject();
            return (SelectedObject != null);

        }

        public void SetRevolveType(RevolveTypes revolveType)
        {
            System.Threading.Tasks.Parallel.ForEach(Circles, obj =>
            {
                obj.RevolveType = revolveType;
            });
        }

        public void SetOrginalCenter(Point orginalCenter)
        {
            this.OrginalCenter = orginalCenter;
            if (Circles.Any())
            {
                for (var i = 0; i < CircleCount; i++)
                {
                    var center = new Point(OrginalCenter.X, OrginalCenter.Y + i * Interval);
                    Circles[i].CircleCenter = center;
                }
            }

        }

        private ThumbElement GetSelectedObject()
        {
            var circle = Circles.FirstOrDefault(x => x.SelectedObject != null);
            return circle != null ? circle.SelectedObject : null;
        }
    }
}
