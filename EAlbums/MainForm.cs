using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EAlbums
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void albumImageList_ImagesLoaded(object sender, AlbumImageList.ImagesLoadedEventArgs e)
        {
            this.albumView.ImagePaths = e.ImagePaths;
            this.albumView.LoadThumbs(e.ImagePaths);

            this.taskStrip.SetCurrentImagePaths(e.Name,e.ImagePaths);
           
        }
    }
}
