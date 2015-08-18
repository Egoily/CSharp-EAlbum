namespace EAlbums
{
    partial class TaskStrip
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TaskStrip));
            this.listViewAlbums = new System.Windows.Forms.ListView();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.ePanelOption = new EgoDevil.Utilities.UI.EPanels.EPanel();
            this.btnLookup = new System.Windows.Forms.Button();
            this.btnDeleteAlbum = new System.Windows.Forms.Button();
            this.btnInsertAlbum = new System.Windows.Forms.Button();
            this.apbtnDefaultAlbum = new ExtendedPictureBoxLib.AnimatedPictureButton();
            this.lbButtonStart = new EgoDevil.Utilities.UI.IndustrialCtrls.Buttons.LBButton();
            this.ePanelOption.SuspendLayout();
            this.SuspendLayout();
            // 
            // listViewAlbums
            // 
            this.listViewAlbums.Alignment = System.Windows.Forms.ListViewAlignment.SnapToGrid;
            this.listViewAlbums.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listViewAlbums.Cursor = System.Windows.Forms.Cursors.Hand;
            this.listViewAlbums.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listViewAlbums.LabelEdit = true;
            this.listViewAlbums.LabelWrap = false;
            this.listViewAlbums.LargeImageList = this.imageList;
            this.listViewAlbums.Location = new System.Drawing.Point(106, 5);
            this.listViewAlbums.MultiSelect = false;
            this.listViewAlbums.Name = "listViewAlbums";
            this.listViewAlbums.ShowItemToolTips = true;
            this.listViewAlbums.Size = new System.Drawing.Size(334, 52);
            this.listViewAlbums.StateImageList = this.imageList;
            this.listViewAlbums.TabIndex = 2;
            this.listViewAlbums.UseCompatibleStateImageBehavior = false;
            this.listViewAlbums.SelectedIndexChanged += new System.EventHandler(this.listViewAlbums_SelectedIndexChanged);
            this.listViewAlbums.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listViewAlbums_MouseDown);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "Dance.gif");
            this.imageList.Images.SetKeyName(1, "AlbumBK.jpg");
            // 
            // ePanelOption
            // 
            this.ePanelOption.AssociatedSplitter = null;
            this.ePanelOption.BackColor = System.Drawing.Color.Transparent;
            this.ePanelOption.CaptionFont = new System.Drawing.Font("Segoe UI", 11.75F, System.Drawing.FontStyle.Bold);
            this.ePanelOption.CaptionHeight = 27;
            this.ePanelOption.Controls.Add(this.btnLookup);
            this.ePanelOption.Controls.Add(this.btnDeleteAlbum);
            this.ePanelOption.Controls.Add(this.btnInsertAlbum);
            this.ePanelOption.CustomColors.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(163)))), ((int)(((byte)(157)))));
            this.ePanelOption.CustomColors.CaptionCloseIcon = System.Drawing.SystemColors.ControlText;
            this.ePanelOption.CustomColors.CaptionExpandIcon = System.Drawing.SystemColors.ControlText;
            this.ePanelOption.CustomColors.CaptionGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(235)))), ((int)(((byte)(216)))));
            this.ePanelOption.CustomColors.CaptionGradientEnd = System.Drawing.SystemColors.ButtonFace;
            this.ePanelOption.CustomColors.CaptionGradientMiddle = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(238)))), ((int)(((byte)(226)))));
            this.ePanelOption.CustomColors.CaptionSelectedGradientBegin = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(162)))), ((int)(((byte)(221)))));
            this.ePanelOption.CustomColors.CaptionSelectedGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(162)))), ((int)(((byte)(221)))));
            this.ePanelOption.CustomColors.CaptionText = System.Drawing.SystemColors.ControlText;
            this.ePanelOption.CustomColors.CollapsedCaptionText = System.Drawing.SystemColors.ControlText;
            this.ePanelOption.CustomColors.ContentGradientBegin = System.Drawing.SystemColors.ButtonFace;
            this.ePanelOption.CustomColors.ContentGradientEnd = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(234)))), ((int)(((byte)(215)))));
            this.ePanelOption.CustomColors.InnerBorderColor = System.Drawing.SystemColors.Window;
            this.ePanelOption.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ePanelOption.Image = null;
            this.ePanelOption.LinearGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.ePanelOption.Location = new System.Drawing.Point(106, 63);
            this.ePanelOption.MinimumSize = new System.Drawing.Size(27, 27);
            this.ePanelOption.Name = "ePanelOption";
            this.ePanelOption.PanelStyle = EgoDevil.Utilities.UI.EPanels.PanelStyle.Office2007;
            this.ePanelOption.ShowCaptionbar = false;
            this.ePanelOption.ShowTransparentBackground = false;
            this.ePanelOption.Size = new System.Drawing.Size(250, 27);
            this.ePanelOption.TabIndex = 4;
            this.ePanelOption.Text = "Option";
            this.ePanelOption.ToolTipTextCloseIcon = null;
            this.ePanelOption.ToolTipTextExpandIconPanelCollapsed = null;
            this.ePanelOption.ToolTipTextExpandIconPanelExpanded = null;
            // 
            // btnLookup
            // 
            this.btnLookup.Location = new System.Drawing.Point(165, 1);
            this.btnLookup.Name = "btnLookup";
            this.btnLookup.Size = new System.Drawing.Size(75, 23);
            this.btnLookup.TabIndex = 3;
            this.btnLookup.Text = "查看";
            this.btnLookup.UseVisualStyleBackColor = true;
            this.btnLookup.Click += new System.EventHandler(this.btnLookup_Click);
            // 
            // btnDeleteAlbum
            // 
            this.btnDeleteAlbum.Location = new System.Drawing.Point(84, 0);
            this.btnDeleteAlbum.Name = "btnDeleteAlbum";
            this.btnDeleteAlbum.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteAlbum.TabIndex = 3;
            this.btnDeleteAlbum.Text = "删除相册";
            this.btnDeleteAlbum.UseVisualStyleBackColor = true;
            this.btnDeleteAlbum.Click += new System.EventHandler(this.btnDeleteAlbum_Click);
            // 
            // btnInsertAlbum
            // 
            this.btnInsertAlbum.Location = new System.Drawing.Point(3, 0);
            this.btnInsertAlbum.Name = "btnInsertAlbum";
            this.btnInsertAlbum.Size = new System.Drawing.Size(75, 23);
            this.btnInsertAlbum.TabIndex = 3;
            this.btnInsertAlbum.Text = "添加相册";
            this.btnInsertAlbum.UseVisualStyleBackColor = true;
            this.btnInsertAlbum.Click += new System.EventHandler(this.btnInsertAlbum_Click);
            // 
            // apbtnDefaultAlbum
            // 
            this.apbtnDefaultAlbum.ForeColor = System.Drawing.Color.Black;
            this.apbtnDefaultAlbum.Location = new System.Drawing.Point(54, 5);
            this.apbtnDefaultAlbum.Name = "apbtnDefaultAlbum";
            this.apbtnDefaultAlbum.PushedProperties = ((ExtendedPictureBoxLib.PictureBoxStateProperties)((((((ExtendedPictureBoxLib.PictureBoxStateProperties.Alpha | ExtendedPictureBoxLib.PictureBoxStateProperties.RotationAngle)
                        | ExtendedPictureBoxLib.PictureBoxStateProperties.Zoom)
                        | ExtendedPictureBoxLib.PictureBoxStateProperties.ExtraImageRotationAngle)
                        | ExtendedPictureBoxLib.PictureBoxStateProperties.ShadowOffset)
                        | ExtendedPictureBoxLib.PictureBoxStateProperties.ImageOffset)));
            this.apbtnDefaultAlbum.Size = new System.Drawing.Size(46, 31);
            this.apbtnDefaultAlbum.TabIndex = 1;
            this.apbtnDefaultAlbum.Text = "默认相册";
            this.apbtnDefaultAlbum.Click += new System.EventHandler(this.apbtnDefaultAlbum_Click);
            // 
            // lbButtonStart
            // 
            this.lbButtonStart.AutoRebound = true;
            this.lbButtonStart.BackColor = System.Drawing.Color.Transparent;
            this.lbButtonStart.ButtonColor = System.Drawing.Color.Red;
            this.lbButtonStart.Label = "";
            this.lbButtonStart.Location = new System.Drawing.Point(3, 0);
            this.lbButtonStart.Name = "lbButtonStart";
            this.lbButtonStart.Renderer = null;
            this.lbButtonStart.RepeatInterval = 100;
            this.lbButtonStart.RepeatState = false;
            this.lbButtonStart.Size = new System.Drawing.Size(45, 43);
            this.lbButtonStart.StartRepeatInterval = 500;
            this.lbButtonStart.State = EgoDevil.Utilities.UI.IndustrialCtrls.Buttons.LBButton.ButtonState.Normal;
            this.lbButtonStart.Style = EgoDevil.Utilities.UI.IndustrialCtrls.Buttons.LBButton.ButtonStyle.Circular;
            this.lbButtonStart.TabIndex = 0;
            // 
            // TaskStrip
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ePanelOption);
            this.Controls.Add(this.listViewAlbums);
            this.Controls.Add(this.apbtnDefaultAlbum);
            this.Controls.Add(this.lbButtonStart);
            this.Name = "TaskStrip";
            this.Size = new System.Drawing.Size(582, 200);
            this.Load += new System.EventHandler(this.TaskStrip_Load);
            this.ePanelOption.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private EgoDevil.Utilities.UI.IndustrialCtrls.Buttons.LBButton lbButtonStart;
        private ExtendedPictureBoxLib.AnimatedPictureButton apbtnDefaultAlbum;
        private System.Windows.Forms.ListView listViewAlbums;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.Button btnInsertAlbum;
        private System.Windows.Forms.Button btnDeleteAlbum;
        private EgoDevil.Utilities.UI.EPanels.EPanel ePanelOption;
        private System.Windows.Forms.Button btnLookup;


    }
}
