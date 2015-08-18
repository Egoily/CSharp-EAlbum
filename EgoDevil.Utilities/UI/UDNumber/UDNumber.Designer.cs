namespace EgoDevil.Utilities.UI.UDNumber
{
    partial class UDNumber
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
            this.txtNumber = new System.Windows.Forms.TextBox();
            this.btnMinus = new System.Windows.Forms.Button();
            this.btnPlus = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtNumber
            // 
            this.txtNumber.Location = new System.Drawing.Point(14, 0);
            this.txtNumber.Margin = new System.Windows.Forms.Padding(0);
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.Size = new System.Drawing.Size(38, 21);
            this.txtNumber.TabIndex = 0;
            this.txtNumber.Text = "0";
            this.txtNumber.TextChanged += new System.EventHandler(this.txtNumber_TextChanged);
            this.txtNumber.Leave += new System.EventHandler(this.UDNumber_Leave);
            this.txtNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
            this.txtNumber.Enter += new System.EventHandler(this.UDNumber_Enter);
            // 
            // btnMinus
            // 
            this.btnMinus.BackColor = System.Drawing.Color.Transparent;
            this.btnMinus.Cursor = System.Windows.Forms.Cursors.PanWest;
            this.btnMinus.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnMinus.Image = global::EgoDevil.Utilities.UI.UDNumber.Resources.down;
            this.btnMinus.Location = new System.Drawing.Point(0, 0);
            this.btnMinus.Margin = new System.Windows.Forms.Padding(0);
            this.btnMinus.Name = "btnMinus";
            this.btnMinus.Size = new System.Drawing.Size(14, 21);
            this.btnMinus.TabIndex = 1;
            this.btnMinus.UseVisualStyleBackColor = false;
            this.btnMinus.Click += new System.EventHandler(this.btnMinus_Click);
            this.btnMinus.Leave += new System.EventHandler(this.UDNumber_Leave);
            this.btnMinus.Enter += new System.EventHandler(this.UDNumber_Enter);
            // 
            // btnPlus
            // 
            this.btnPlus.BackColor = System.Drawing.Color.Transparent;
            this.btnPlus.Cursor = System.Windows.Forms.Cursors.PanEast;
            this.btnPlus.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPlus.Image = global::EgoDevil.Utilities.UI.UDNumber.Resources.up;
            this.btnPlus.Location = new System.Drawing.Point(52, 0);
            this.btnPlus.Margin = new System.Windows.Forms.Padding(0);
            this.btnPlus.Name = "btnPlus";
            this.btnPlus.Size = new System.Drawing.Size(14, 21);
            this.btnPlus.TabIndex = 1;
            this.btnPlus.UseVisualStyleBackColor = false;
            this.btnPlus.Click += new System.EventHandler(this.btnPlus_Click);
            this.btnPlus.Leave += new System.EventHandler(this.UDNumber_Leave);
            this.btnPlus.Enter += new System.EventHandler(this.UDNumber_Enter);
            // 
            // UDNumber
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnPlus);
            this.Controls.Add(this.btnMinus);
            this.Controls.Add(this.txtNumber);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "UDNumber";
            this.Size = new System.Drawing.Size(66, 19);
            this.Load += new System.EventHandler(this.UDNumber_Load);
            this.Leave += new System.EventHandler(this.UDNumber_Leave);
            this.Enter += new System.EventHandler(this.UDNumber_Enter);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNumber;
        private System.Windows.Forms.Button btnMinus;
        private System.Windows.Forms.Button btnPlus;
    }
}
