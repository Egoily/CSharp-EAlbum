using System.Windows.Forms;

using EgoDevil.Utilities.BkWorker;

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

            this.taskStrip.SetCurrentImagePaths(e.Name, e.ImagePaths);
        }

        private void MainForm_Load(object sender, System.EventArgs e)
        {
            this.Visible = true;
            this.albumView.Loading();
        }
    }
}