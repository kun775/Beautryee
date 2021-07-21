
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
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.CheckBox2_Edit = new System.Windows.Forms.CheckBox();
            this.Button_Save = new System.Windows.Forms.Button();
            this.Label_Pause = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Label_Score
            // 
            this.Label_Score.AutoSize = true;
            this.Label_Score.BackColor = System.Drawing.Color.Transparent;
            this.Label_Score.Font = new System.Drawing.Font("宋体", 12F);
            this.Label_Score.ForeColor = System.Drawing.Color.Black;
            this.Label_Score.Location = new System.Drawing.Point(466, 35);
            this.Label_Score.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label_Score.Name = "Label_Score";
            this.Label_Score.Size = new System.Drawing.Size(16, 16);
            this.Label_Score.TabIndex = 0;
            this.Label_Score.Text = "0";
            // 
            // Button_Start
            // 
            this.Button_Start.Location = new System.Drawing.Point(451, 343);
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
            this.label1.Location = new System.Drawing.Point(415, 64);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "速度";
            // 
            // Link_LevelDown
            // 
            this.Link_LevelDown.AutoSize = true;
            this.Link_LevelDown.Font = new System.Drawing.Font("宋体", 18F);
            this.Link_LevelDown.ForeColor = System.Drawing.Color.Black;
            this.Link_LevelDown.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.Link_LevelDown.LinkColor = System.Drawing.Color.Blue;
            this.Link_LevelDown.Location = new System.Drawing.Point(472, 60);
            this.Link_LevelDown.Name = "Link_LevelDown";
            this.Link_LevelDown.Size = new System.Drawing.Size(22, 24);
            this.Link_LevelDown.TabIndex = 3;
            this.Link_LevelDown.TabStop = true;
            this.Link_LevelDown.Text = "-";
            this.Link_LevelDown.VisitedLinkColor = System.Drawing.Color.Black;
            this.Link_LevelDown.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Link_LevelDown_LinkClicked);
            // 
            // Link_LevelUp
            // 
            this.Link_LevelUp.AutoSize = true;
            this.Link_LevelUp.Font = new System.Drawing.Font("宋体", 18F);
            this.Link_LevelUp.ForeColor = System.Drawing.Color.Black;
            this.Link_LevelUp.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.Link_LevelUp.LinkColor = System.Drawing.Color.Blue;
            this.Link_LevelUp.Location = new System.Drawing.Point(527, 60);
            this.Link_LevelUp.Name = "Link_LevelUp";
            this.Link_LevelUp.Size = new System.Drawing.Size(22, 24);
            this.Link_LevelUp.TabIndex = 4;
            this.Link_LevelUp.TabStop = true;
            this.Link_LevelUp.Text = "+";
            this.Link_LevelUp.VisitedLinkColor = System.Drawing.Color.Black;
            this.Link_LevelUp.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Link_LevelUp_LinkClicked);
            // 
            // Label_Level
            // 
            this.Label_Level.AutoSize = true;
            this.Label_Level.Location = new System.Drawing.Point(502, 66);
            this.Label_Level.Name = "Label_Level";
            this.Label_Level.Size = new System.Drawing.Size(11, 12);
            this.Label_Level.TabIndex = 5;
            this.Label_Level.Text = "1";
            this.Label_Level.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label2.Location = new System.Drawing.Point(481, 379);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "Version 1.1";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.panel1.Location = new System.Drawing.Point(415, 151);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(20, 20);
            this.panel1.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("宋体", 12F);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(441, 153);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "障碍物";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("宋体", 12F);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(441, 186);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 16);
            this.label4.TabIndex = 10;
            this.label4.Text = "普通苹果 1分";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Green;
            this.panel2.Location = new System.Drawing.Point(415, 184);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(20, 20);
            this.panel2.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("宋体", 12F);
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(441, 219);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 16);
            this.label5.TabIndex = 12;
            this.label5.Text = "特殊苹果 10分";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Red;
            this.panel3.Location = new System.Drawing.Point(415, 217);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(20, 20);
            this.panel3.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("宋体", 12F);
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(415, 35);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 16);
            this.label6.TabIndex = 13;
            this.label6.Text = "得分";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("宋体", 12F);
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(415, 93);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(136, 16);
            this.label7.TabIndex = 14;
            this.label7.Text = "PageUp:   速度加";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("宋体", 12F);
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(415, 122);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(136, 16);
            this.label8.TabIndex = 15;
            this.label8.Text = "PageDown: 速度减";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(415, 260);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(84, 16);
            this.checkBox1.TabIndex = 16;
            this.checkBox1.Text = "加入障碍物";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // CheckBox2_Edit
            // 
            this.CheckBox2_Edit.AutoSize = true;
            this.CheckBox2_Edit.Location = new System.Drawing.Point(415, 282);
            this.CheckBox2_Edit.Name = "CheckBox2_Edit";
            this.CheckBox2_Edit.Size = new System.Drawing.Size(84, 16);
            this.CheckBox2_Edit.TabIndex = 17;
            this.CheckBox2_Edit.Text = "编辑障碍物";
            this.CheckBox2_Edit.UseVisualStyleBackColor = true;
            this.CheckBox2_Edit.CheckedChanged += new System.EventHandler(this.CheckBox2_Edit_CheckedChanged);
            // 
            // Button_Save
            // 
            this.Button_Save.Location = new System.Drawing.Point(504, 279);
            this.Button_Save.Name = "Button_Save";
            this.Button_Save.Size = new System.Drawing.Size(47, 23);
            this.Button_Save.TabIndex = 18;
            this.Button_Save.Text = "保存";
            this.Button_Save.UseVisualStyleBackColor = true;
            this.Button_Save.Visible = false;
            this.Button_Save.Click += new System.EventHandler(this.Button_Save_Click);
            // 
            // Label_Pause
            // 
            this.Label_Pause.AutoSize = true;
            this.Label_Pause.BackColor = System.Drawing.Color.Transparent;
            this.Label_Pause.Font = new System.Drawing.Font("宋体", 12F);
            this.Label_Pause.ForeColor = System.Drawing.Color.Red;
            this.Label_Pause.Location = new System.Drawing.Point(452, 319);
            this.Label_Pause.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label_Pause.Name = "Label_Pause";
            this.Label_Pause.Size = new System.Drawing.Size(72, 16);
            this.Label_Pause.TabIndex = 19;
            this.Label_Pause.Text = "游戏暂停";
            this.Label_Pause.Visible = false;
            // 
            // Beautryee
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Menu;
            this.ClientSize = new System.Drawing.Size(564, 400);
            this.Controls.Add(this.Label_Pause);
            this.Controls.Add(this.Button_Save);
            this.Controls.Add(this.CheckBox2_Edit);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Label_Level);
            this.Controls.Add(this.Link_LevelUp);
            this.Controls.Add(this.Link_LevelDown);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Button_Start);
            this.Controls.Add(this.Label_Score);
            this.Font = new System.Drawing.Font("宋体", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Beautryee";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
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
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox CheckBox2_Edit;
        private System.Windows.Forms.Button Button_Save;
        private System.Windows.Forms.Label Label_Pause;
    }
}

