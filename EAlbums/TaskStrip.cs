using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace EAlbums
{
    public partial class TaskStrip : UserControl
    {
        private ImageViewer _albumView = new ImageViewer();

        public ImageViewer AssociatedAlbumView
        {
            get { return _albumView; }
            set { this._albumView = value; }
        }

        private AlbumImageList _albumImageList = new AlbumImageList();

        public AlbumImageList AssociatedAlbumImageList
        {
            get
            {
                return _albumImageList;
            }
            set
            {
                _albumImageList = value;
            }
        }

        private const string _albumNewName = "新建相册";

        private string CurrentAlbumName;

        public List<AlbumItem> AlbumList = new List<AlbumItem>();

        private string CalNewName()
        {
            int index = 1;
            while (true)
            {
                string newName;
                if (index == 1)
                {
                    newName = _albumNewName;
                }
                else
                {
                    newName = _albumNewName + "(" + index.ToString() + ")";
                }
                bool flat = false;
                foreach (ListViewItem item in listViewAlbums.Items)
                {
                    if (item.Text == newName)
                    {
                        flat = true;
                        break;
                    }
                }
                if (!flat)
                {
                    return newName;
                }

                index++;
            }
        }

        private void InsertAlbum()
        {
            string newName = CalNewName();
            ListViewItem item = new ListViewItem(newName, 0);

            listViewAlbums.Items.Add(item);
            item.BeginEdit();
            AlbumList.Add(new AlbumItem(newName));
        }

        private void DeleteAlbum()
        {
            if (listViewAlbums.SelectedItems.Count > 0)
            {
                if (MessageBox.Show("确定要删除该相册?(Y/N)", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    foreach (AlbumItem item in AlbumList)
                    {
                        if (item.Name == listViewAlbums.SelectedItems[0].Text)
                        {
                            AlbumList.Remove(item);
                            break;
                        }
                    }
                    listViewAlbums.SelectedItems[0].Remove();
                }
            }
        }

        private void RepositionOptionPanel(Point pos, bool flt)
        {
            ePanelOption.Location = pos;
            if (flt)
            {
                btnInsertAlbum.Enabled = true;
                btnLookup.Enabled = btnDeleteAlbum.Enabled = false;
            }
            else
            {
                btnInsertAlbum.Enabled = false;
                btnLookup.Enabled = btnDeleteAlbum.Enabled = true;
            }
        }

        private void ShowAlbumImageList()
        {
            //ImageListForm frm = new ImageListForm(_albumView.ImagePaths);
            //frm.Loading += new ImageListForm.LoadingEventHandler(ImageListForm_Loading);
            //frm.ShowDialog();

            AssociatedAlbumImageList.Visible = true;
            AssociatedAlbumImageList.LoadImages(CurrentAlbumName, _albumView.ImagePaths);
        }

        public void SetCurrentImagePaths(string name, List<string> imagePaths)
        {
            foreach (AlbumItem item in AlbumList)
            {
                if (item.Name == name)
                {
                    item.ImagePaths = imagePaths;
                    break;
                }
            }
        }

        private void ImageListForm_Loading(object sender, ImageListForm.LoadingEventArgs e)
        {
            _albumView.LoadThumbs(e.Images);
        }

        public TaskStrip()
        {
            InitializeComponent();
        }

        private void TaskStrip_Load(object sender, EventArgs e)
        {
        }

        private void listViewAlbums_MouseDown(object sender, MouseEventArgs e)
        {
            ListView lv = sender as ListView;

            ListViewItem item = lv.GetItemAt(e.X, e.Y);

            Point pos = new Point(lv.Location.X + e.Location.X, lv.Location.Y - ePanelOption.Height / 2);

            if (item != null)
            {
                RepositionOptionPanel(pos, false);
            }
            else
            {
                RepositionOptionPanel(pos, true);
            }
        }

        private void apbtnDefaultAlbum_Click(object sender, EventArgs e)
        {
            ShowAlbumImageList();
        }

        private void btnInsertAlbum_Click(object sender, EventArgs e)
        {
            InsertAlbum();
        }

        private void btnDeleteAlbum_Click(object sender, EventArgs e)
        {
            DeleteAlbum();
        }

        private void btnLookup_Click(object sender, EventArgs e)
        {
            ShowAlbumImageList();
        }

        private void listViewAlbums_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewAlbums.SelectedItems.Count > 0)
            {
                foreach (AlbumItem item in AlbumList)
                {
                    CurrentAlbumName = listViewAlbums.SelectedItems[0].Text;
                    if (item.Name == CurrentAlbumName)
                    {
                        AssociatedAlbumView.ImagePaths = item.ImagePaths;
                        AssociatedAlbumView.LoadThumbs(item.ImagePaths);
                        break;
                    }
                }
            }
        }
    }

    public class AlbumItem
    {
        public List<string> ImagePaths = new List<string>();
        public string Name;

        public AlbumItem()
        {
        }

        public AlbumItem(string name)
        {
            Name = name;
        }

        public AlbumItem(string name, List<string> list)
        {
            Name = name;
            ImagePaths = list;
        }
    }
}