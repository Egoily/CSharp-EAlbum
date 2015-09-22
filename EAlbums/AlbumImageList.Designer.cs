using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

using EgoDevil.Utilities.UI.EPanels;

namespace EAlbums
{
    partial class AlbumImageList
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            ComponentResourceManager resources = new ComponentResourceManager(typeof(AlbumImageList));
            this.dataGridView = new DataGridView();
            this.ImageThumb = new DataGridViewImageColumn();
            this.ImageName = new DataGridViewTextBoxColumn();
            this.Target = new DataGridViewTextBoxColumn();
            this.openFileDialog = new OpenFileDialog();
            this.toolStrip = new ToolStrip();
            this.tsbInsertImage = new ToolStripButton();
            this.ePanelAlbumImageList = new EPanel();
            ((ISupportInitialize)(this.dataGridView)).BeginInit();
            this.toolStrip.SuspendLayout();
            this.ePanelAlbumImageList.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView.BorderStyle = BorderStyle.None;
            this.dataGridView.CellBorderStyle = DataGridViewCellBorderStyle.None;
            this.dataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Sunken;
            this.dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new DataGridViewColumn[] {
            this.ImageThumb,
            this.ImageName,
            this.Target});
            this.dataGridView.Dock = DockStyle.Fill;
            this.dataGridView.EnableHeadersVisualStyles = false;
            this.dataGridView.Location = new Point(1, 19);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("宋体", 9F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            this.dataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView.RowHeadersWidth = 20;
            this.dataGridView.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView.RowTemplate.Height = 23;
            this.dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new Size(215, 286);
            this.dataGridView.TabIndex = 2;
            this.dataGridView.RowPostPaint += new DataGridViewRowPostPaintEventHandler(this.DataGridViewRowPostPaint);
            // 
            // ImageThumb
            // 
            this.ImageThumb.HeaderText = "缩略图";
            this.ImageThumb.Name = "ImageThumb";
            this.ImageThumb.Width = 47;
            // 
            // ImageName
            // 
            this.ImageName.HeaderText = "名称";
            this.ImageName.Name = "ImageName";
            this.ImageName.Width = 54;
            // 
            // Target
            // 
            this.Target.HeaderText = "目标";
            this.Target.Name = "Target";
            this.Target.Width = 54;
            // 
            // openFileDialog
            // 
            this.openFileDialog.Multiselect = true;
            this.openFileDialog.FileOk += new CancelEventHandler(this.OpenFileDialogFileOk);
            // 
            // toolStrip
            // 
            this.toolStrip.Dock = DockStyle.Bottom;
            this.toolStrip.Items.AddRange(new ToolStripItem[] {
            this.tsbInsertImage});
            this.toolStrip.Location = new Point(1, 280);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new Size(215, 25);
            this.toolStrip.TabIndex = 4;
            this.toolStrip.Text = "toolStrip1";
            this.toolStrip.ItemClicked += new ToolStripItemClickedEventHandler(this.ToolStripItemClicked);
            // 
            // tsbInsertImage
            // 
            this.tsbInsertImage.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.tsbInsertImage.Image = ((Image)(resources.GetObject("tsbInsertImage.Image")));
            this.tsbInsertImage.ImageTransparentColor = Color.Magenta;
            this.tsbInsertImage.Name = "tsbInsertImage";
            this.tsbInsertImage.Size = new Size(23, 22);
            this.tsbInsertImage.Text = "toolStripButton1";
            // 
            // ePanelAlbumImageList
            // 
            this.ePanelAlbumImageList.AssociatedSplitter = null;
            this.ePanelAlbumImageList.AutoScroll = true;
            this.ePanelAlbumImageList.BackColor = Color.Transparent;
            this.ePanelAlbumImageList.CaptionFont = new Font("Segoe UI", 11.75F, FontStyle.Bold);
            this.ePanelAlbumImageList.CaptionHeight = 18;
            this.ePanelAlbumImageList.Controls.Add(this.toolStrip);
            this.ePanelAlbumImageList.Controls.Add(this.dataGridView);
            this.ePanelAlbumImageList.CustomColors.BorderColor = Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(163)))), ((int)(((byte)(157)))));
            this.ePanelAlbumImageList.CustomColors.CaptionCloseIcon = SystemColors.ControlText;
            this.ePanelAlbumImageList.CustomColors.CaptionExpandIcon = SystemColors.ControlText;
            this.ePanelAlbumImageList.CustomColors.CaptionGradientBegin = Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(235)))), ((int)(((byte)(216)))));
            this.ePanelAlbumImageList.CustomColors.CaptionGradientEnd = SystemColors.ButtonFace;
            this.ePanelAlbumImageList.CustomColors.CaptionGradientMiddle = Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(238)))), ((int)(((byte)(226)))));
            this.ePanelAlbumImageList.CustomColors.CaptionSelectedGradientBegin = Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(162)))), ((int)(((byte)(221)))));
            this.ePanelAlbumImageList.CustomColors.CaptionSelectedGradientEnd = Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(162)))), ((int)(((byte)(221)))));
            this.ePanelAlbumImageList.CustomColors.CaptionText = SystemColors.ControlText;
            this.ePanelAlbumImageList.CustomColors.CollapsedCaptionText = SystemColors.ControlText;
            this.ePanelAlbumImageList.CustomColors.ContentGradientBegin = SystemColors.ButtonFace;
            this.ePanelAlbumImageList.CustomColors.ContentGradientEnd = Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(234)))), ((int)(((byte)(215)))));
            this.ePanelAlbumImageList.CustomColors.InnerBorderColor = SystemColors.Window;
            this.ePanelAlbumImageList.Dock = DockStyle.Left;
            this.ePanelAlbumImageList.ForeColor = SystemColors.ControlText;
            this.ePanelAlbumImageList.Image = null;
            this.ePanelAlbumImageList.LinearGradientMode = LinearGradientMode.Vertical;
            this.ePanelAlbumImageList.Location = new Point(0, 0);
            this.ePanelAlbumImageList.MinimumSize = new Size(27, 27);
            this.ePanelAlbumImageList.Name = "ePanelAlbumImageList";
            this.ePanelAlbumImageList.PanelStyle = PanelStyle.Office2007;
            this.ePanelAlbumImageList.ShowCloseIcon = true;
            this.ePanelAlbumImageList.Size = new Size(217, 306);
            this.ePanelAlbumImageList.TabIndex = 5;
            this.ePanelAlbumImageList.Text = "列表";
            this.ePanelAlbumImageList.ToolTipTextCloseIcon = null;
            this.ePanelAlbumImageList.ToolTipTextExpandIconPanelCollapsed = null;
            this.ePanelAlbumImageList.ToolTipTextExpandIconPanelExpanded = null;
            this.ePanelAlbumImageList.CloseClick += new EventHandler<EventArgs>(this.EPanelAlbumImageListCloseClick);
            // 
            // AlbumImageList
            // 
            this.AutoScaleDimensions = new SizeF(6F, 12F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.Controls.Add(this.ePanelAlbumImageList);
            this.DoubleBuffered = true;
            this.Name = "AlbumImageList";
            this.Size = new Size(221, 306);
            this.Load += new EventHandler(this.AlbumImageListLoad);
            ((ISupportInitialize)(this.dataGridView)).EndInit();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ePanelAlbumImageList.ResumeLayout(false);
            this.ePanelAlbumImageList.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView dataGridView;
        private DataGridViewImageColumn ImageThumb;
        private DataGridViewTextBoxColumn ImageName;
        private DataGridViewTextBoxColumn Target;
        private OpenFileDialog openFileDialog;
        private ToolStrip toolStrip;
        private ToolStripButton tsbInsertImage;
        private EPanel ePanelAlbumImageList;
    }
}
