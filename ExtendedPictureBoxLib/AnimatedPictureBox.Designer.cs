namespace ExtendedPictureBoxLib
{
    partial class AnimatedPictureBox
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
            this.SuspendLayout();
            // 
            // AnimatedPictureBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "AnimatedPictureBox";
            this.Size = new System.Drawing.Size(94, 78);
            this.ResumeLayout(false);

            this.components = new System.ComponentModel.Container();
            this._stateAnimator = new ExtendedPictureBoxLib.Animators.ExtendedPictureBoxStateAnimator(this.components);
            ((System.ComponentModel.ISupportInitialize)(this._stateAnimator)).BeginInit();
            // 
            // _stateAnimator
            // 
            this._stateAnimator.EndState = new ExtendedPictureBoxLib.PictureBoxState(
                ((System.Byte)(255)), 0F, 100F, 0F, 0F, 
                System.Drawing.SystemColors.Control,
                System.Drawing.SystemColors.Control, 
                System.Drawing.SystemColors.ControlText,
                System.Drawing.SystemColors.ControlText,
                0, 0F, 100F,
                System.Drawing.Point.Empty,
                System.Drawing.Point.Empty,
                System.Drawing.Point.Empty);
            this._stateAnimator.ExtendedPictureBox = this;
            this._stateAnimator.StartState = new ExtendedPictureBoxLib.PictureBoxState(
                ((System.Byte)(255)), 0F, 100F, 0F, 0F,
                System.Drawing.SystemColors.Control,
                System.Drawing.SystemColors.Control,
                System.Drawing.SystemColors.ControlText,
                System.Drawing.SystemColors.ControlText,
                0, 0F, 500F,
                System.Drawing.Point.Empty,
                System.Drawing.Point.Empty,
                System.Drawing.Point.Empty);
            this._stateAnimator.IntervallChanged += new System.EventHandler(this.OnAnimationIntervallChanged);
            this._stateAnimator.AnimationStopped += new System.EventHandler(this.OnAnimationStopped);
            this._stateAnimator.StepSizeChanged += new System.EventHandler(this.OnAnimationStepSizeChanged);
            this._stateAnimator.AnimationStarted += new System.EventHandler(this.OnAnimationStarted);
            this._stateAnimator.AnimationFinished += new System.EventHandler(this.OnAnimationFinished);
           


        }

        #endregion

        private ExtendedPictureBoxLib.Animators.ExtendedPictureBoxStateAnimator _stateAnimator;
    }
}
