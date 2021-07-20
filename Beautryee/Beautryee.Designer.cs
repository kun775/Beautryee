
namespace Beautryee
{
    partial class Beautryee
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Beautryee));
            this.Label_Score = new System.Windows.Forms.Label();
            this.Button_Start = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Link_LevelDown = new System.Windows.Forms.LinkLabel();
            this.Link_LevelUp = new System.Windows.Forms.LinkLabel();
            this.Label_Level = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Label_Score
            // 
            this.Label_Score.AutoSize = true;
            this.Label_Score.BackColor = System.Drawing.Color.Transparent;
            this.Label_Score.Font = new System.Drawing.Font("宋体", 12F);
            this.Label_Score.ForeColor = System.Drawing.Color.Black;
            this.Label_Score.Location = new System.Drawing.Point(415, 35);
            this.Label_Score.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label_Score.Name = "Label_Score";
            this.Label_Score.Size = new System.Drawing.Size(72, 16);
            this.Label_Score.TabIndex = 0;
            this.Label_Score.Text = "Score: 0";
            // 
            // Button_Start
            // 
            this.Button_Start.Location = new System.Drawing.Point(451, 338);
            this.Button_Start.Name = "Button_Start";
            this.Button_Start.Size = new System.Drawing.Size(75, 23);
            this.Button_Start.TabIndex = 1;
            this.Button_Start.Text = "开始游戏";
            this.Button_Start.UseVisualStyleBackColor = true;
            this.Button_Start.Click += new System.EventHandler(this.Button_Start_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("宋体", 12F);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(415, 82);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Level";
            // 
            // Link_LevelDown
            // 
            this.Link_LevelDown.AutoSize = true;
            this.Link_LevelDown.Font = new System.Drawing.Font("宋体", 12F);
            this.Link_LevelDown.ForeColor = System.Drawing.Color.Black;
            this.Link_LevelDown.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.Link_LevelDown.LinkColor = System.Drawing.Color.Blue;
            this.Link_LevelDown.Location = new System.Drawing.Point(472, 82);
            this.Link_LevelDown.Name = "Link_LevelDown";
            this.Link_LevelDown.Size = new System.Drawing.Size(16, 16);
            this.Link_LevelDown.TabIndex = 3;
            this.Link_LevelDown.TabStop = true;
            this.Link_LevelDown.Text = "-";
            this.Link_LevelDown.VisitedLinkColor = System.Drawing.Color.Black;
            this.Link_LevelDown.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Link_LevelDown_LinkClicked);
            // 
            // Link_LevelUp
            // 
            this.Link_LevelUp.AutoSize = true;
            this.Link_LevelUp.Font = new System.Drawing.Font("宋体", 12F);
            this.Link_LevelUp.ForeColor = System.Drawing.Color.Black;
            this.Link_LevelUp.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.Link_LevelUp.LinkColor = System.Drawing.Color.Blue;
            this.Link_LevelUp.Location = new System.Drawing.Point(527, 82);
            this.Link_LevelUp.Name = "Link_LevelUp";
            this.Link_LevelUp.Size = new System.Drawing.Size(16, 16);
            this.Link_LevelUp.TabIndex = 4;
            this.Link_LevelUp.TabStop = true;
            this.Link_LevelUp.Text = "+";
            this.Link_LevelUp.VisitedLinkColor = System.Drawing.Color.Black;
            this.Link_LevelUp.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Link_LevelUp_LinkClicked);
            // 
            // Label_Level
            // 
            this.Label_Level.AutoSize = true;
            this.Label_Level.Location = new System.Drawing.Point(499, 84);
            this.Label_Level.Name = "Label_Level";
            this.Label_Level.Size = new System.Drawing.Size(11, 12);
            this.Label_Level.TabIndex = 5;
            this.Label_Level.Text = "1";
            this.Label_Level.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Beautryee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Menu;
            this.ClientSize = new System.Drawing.Size(564, 400);
            this.Controls.Add(this.Label_Level);
            this.Controls.Add(this.Link_LevelUp);
            this.Controls.Add(this.Link_LevelDown);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Button_Start);
            this.Controls.Add(this.Label_Score);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Beautryee";
            this.Text = "贪吃蛇";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Beautryee_FormClosing);
            this.Load += new System.EventHandler(this.Beautryee_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Label_Score;
        private System.Windows.Forms.Button Button_Start;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel Link_LevelDown;
        private System.Windows.Forms.LinkLabel Link_LevelUp;
        private System.Windows.Forms.Label Label_Level;
    }
}

