using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using EgoDevil.Utilities.UI.EPanels;

namespace EAlbums
{
    partial class MainForm
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.ePanelTask = new EPanel();
            this.taskStrip = new TaskStrip();
            this.albumImageList = new AlbumImageList();
            this.albumView = new ImageViewer();
            this.ePanelTask.SuspendLayout();
            this.SuspendLayout();
            // 
            // ePanelTask
            // 
            this.ePanelTask.AssociatedSplitter = null;
            this.ePanelTask.BackColor = Color.Transparent;
            this.ePanelTask.CaptionFont = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.ePanelTask.CaptionHeight = 18;
            this.ePanelTask.Controls.Add(this.taskStrip);
            this.ePanelTask.CustomColors.BorderColor = Color.FromArgb(((int)(((byte)(156)))), ((int)(((byte)(163)))), ((int)(((byte)(157)))));
            this.ePanelTask.CustomColors.CaptionCloseIcon = SystemColors.ControlText;
            this.ePanelTask.CustomColors.CaptionExpandIcon = SystemColors.ControlText;
            this.ePanelTask.CustomColors.CaptionGradientBegin = Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(235)))), ((int)(((byte)(216)))));
            this.ePanelTask.CustomColors.CaptionGradientEnd = SystemColors.ButtonFace;
            this.ePanelTask.CustomColors.CaptionGradientMiddle = Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(238)))), ((int)(((byte)(226)))));
            this.ePanelTask.CustomColors.CaptionSelectedGradientBegin = Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(162)))), ((int)(((byte)(221)))));
            this.ePanelTask.CustomColors.CaptionSelectedGradientEnd = Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(162)))), ((int)(((byte)(221)))));
            this.ePanelTask.CustomColors.CaptionText = SystemColors.ControlText;
            this.ePanelTask.CustomColors.CollapsedCaptionText = SystemColors.ControlText;
            this.ePanelTask.CustomColors.ContentGradientBegin = SystemColors.ButtonFace;
            this.ePanelTask.CustomColors.ContentGradientEnd = Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(234)))), ((int)(((byte)(215)))));
            this.ePanelTask.CustomColors.InnerBorderColor = SystemColors.Window;
            this.ePanelTask.Dock = DockStyle.Bottom;
            this.ePanelTask.ForeColor = SystemColors.ControlText;
            this.ePanelTask.Image = null;
            this.ePanelTask.Location = new Point(0, 626);
            this.ePanelTask.MinimumSize = new Size(18, 18);
            this.ePanelTask.Name = "ePanelTask";
            this.ePanelTask.PanelStyle = PanelStyle.Office2007;
            this.ePanelTask.ShowExpandIcon = true;
            this.ePanelTask.ShowTransparentBackground = false;
            this.ePanelTask.ShowXPanderPanelProfessionalStyle = true;
            this.ePanelTask.Size = new Size(904, 85);
            this.ePanelTask.TabIndex = 0;
            this.ePanelTask.Text = "ePanelView";
            this.ePanelTask.ToolTipTextCloseIcon = null;
            this.ePanelTask.ToolTipTextExpandIconPanelCollapsed = null;
            this.ePanelTask.ToolTipTextExpandIconPanelExpanded = null;
            // 
            // taskStrip
            // 
            this.taskStrip.AssociatedAlbumImageList = this.albumImageList;
            this.taskStrip.AssociatedAlbumView = this.albumView;
            this.taskStrip.Location = new Point(12, 22);
            this.taskStrip.Name = "taskStrip";
            this.taskStrip.Size = new Size(457, 59);
            this.taskStrip.TabIndex = 0;
            // 
            // albumImageList
            // 
            this.albumImageList.AutoScroll = true;
            this.albumImageList.Dock = DockStyle.Right;
            this.albumImageList.Location = new Point(683, 0);
            this.albumImageList.Name = "albumImageList";
            this.albumImageList.Size = new Size(221, 626);
            this.albumImageList.TabIndex = 2;
            this.albumImageList.Visible = false;
            this.albumImageList.ImagesLoaded += new AlbumImageList.ImagesLoadedEventHandler(this.AlbumImageListImagesLoaded);
            // 
            // albumView
            // 
            this.albumView.Alpha = 0F;
            this.albumView.AutoScroll = true;
            this.albumView.BackColor = Color.Black;
            this.albumView.BackgroundColor = Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.albumView.Dock = DockStyle.Fill;
            this.albumView.Location = new Point(0, 0);
            this.albumView.Name = "albumView";
            this.albumView.Size = new Size(904, 626);
            this.albumView.Pattern = ViewPatterns.Ready;
            this.albumView.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new SizeF(6F, 12F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(904, 711);
            this.Controls.Add(this.albumImageList);
            this.Controls.Add(this.albumView);
            this.Controls.Add(this.ePanelTask);
            this.Name = "MainForm";
            this.Text = "E Albums";
            this.Load += new EventHandler(this.MainFormLoad);
            this.ePanelTask.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private EPanel ePanelTask;
        private ImageViewer albumView;
        private TaskStrip taskStrip;
        private AlbumImageList albumImageList;
  
    
     
       
    }
}

