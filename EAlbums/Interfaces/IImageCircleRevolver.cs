using System.Collections.Generic;
using System.Drawing;

namespace EAlbums
{
    public interface IImageCircleRevolver
    {
        List<ImageCircle> Circles { get; set; }
        int CircleCapacity { get; set; }
        int Interval { get; set; }
        Point OrginalCenter { get; set; }
        float Alpha { get; set; }
        Color BackgroundColor { get; set; }
        ThumbElement SelectedObject { get; set; }

        void Load(List<string> filePaths);

        void SetAlpha();

        void SetAlphaAccel(float alphaAccel);

        void SetPerspective(float perspective);

        void Refresh();

        void ClearHover();

        void DrawImages(Graphics g);

        bool SelectHoverItem(Point location);

        void SetRevolveType(RevolveTypes revolveType);

        void SetOrginalCenter(Point orginalCenter);
    }
}