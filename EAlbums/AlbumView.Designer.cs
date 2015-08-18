namespace EAlbums
{
    partial class AlbumView
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
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.apboxShowPicture = new ExtendedPictureBoxLib.AnimatedPictureBox();
            this.SuspendLayout();
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 30;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // apboxShowPicture
            // 
            this.apboxShowPicture.Alpha = ((byte)(240));
            this.apboxShowPicture.AutoScroll = true;
            this.apboxShowPicture.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.apboxShowPicture.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.apboxShowPicture.BackColorGradientRotationAngle = -90F;
            this.apboxShowPicture.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.apboxShowPicture.BorderStyle = System.Windows.Forms.ButtonBorderStyle.None;
            this.apboxShowPicture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.apboxShowPicture.Location = new System.Drawing.Point(0, 0);
            this.apboxShowPicture.Name = "apboxShowPicture";
            this.apboxShowPicture.Size = new System.Drawing.Size(467, 381);
            this.apboxShowPicture.TabIndex = 0;
            this.apboxShowPicture.TabStop = false;
            this.apboxShowPicture.Visible = false;
            this.apboxShowPicture.Click += new System.EventHandler(this.apboxShowPicture_Click);
            this.apboxShowPicture.Paint += new System.Windows.Forms.PaintEventHandler(this.apboxShowPicture_Paint);
            // 
            // AlbumView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.apboxShowPicture);
            this.Name = "AlbumView";
            this.Size = new System.Drawing.Size(467, 381);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.AlbumView_Paint);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.AlbumView_MouseMove);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.AlbumView_MouseDown);
            this.ResumeLayout(false);

        }

        #endregion

        private ExtendedPictureBoxLib.AnimatedPictureBox apboxShowPicture;
        private System.Windows.Forms.Timer timer;
    }
}
