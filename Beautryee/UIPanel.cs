using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

// ReSharper disable All
#pragma warning disable 1591

namespace Beautryee
{

    [Designer("System.Windows.Forms.Design.ParentControlDesigner, System.Design", typeof(System.ComponentModel.Design.IDesigner))]
    [DefaultEvent("Click"), DefaultProperty("Text")]
    public partial class UIPanel : UserControl
    {
        private int radius = 5;
        protected Color rectColor = Color.Transparent;
        protected Color fillColor = Color.Transparent;
        protected Color foreColor = Color.White;

        public UIPanel()
        {
            InitializeComponent();

            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);
            SetStyle(ControlStyles.Selectable, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            base.DoubleBuffered = true;
            UpdateStyles();
            AutoScaleMode = AutoScaleMode.None;
            base.MinimumSize = new Size(1, 1);
        }

        private ToolStripStatusLabelBorderSides _rectSides = ToolStripStatusLabelBorderSides.All;

        [DefaultValue(ToolStripStatusLabelBorderSides.All), Description("边框显示位置"), Category("SunnyUI")]
        public ToolStripStatusLabelBorderSides RectSides
        {
            get => _rectSides;
            set
            {
                _rectSides = value;
                OnRectSidesChange();
                Invalidate();
            }
        }

        protected virtual void OnRadiusSidesChange()
        {
        }

        protected virtual void OnRectSidesChange()
        {
        }

        private UICornerRadiusSides _radiusSides = UICornerRadiusSides.All;

        [DefaultValue(UICornerRadiusSides.All), Description("圆角显示位置"), Category("SunnyUI")]
        public UICornerRadiusSides RadiusSides
        {
            get => _radiusSides;
            set
            {
                _radiusSides = value;
                OnRadiusSidesChange();
                Invalidate();
            }
        }

        /// <summary>
        /// 是否显示圆角
        /// </summary>
        [Description("是否显示圆角"), Category("SunnyUI")]
        protected bool ShowRadius => (int)RadiusSides > 0;

        //圆角角度
        [Description("圆角角度"), Category("SunnyUI")]
        [DefaultValue(5)]
        public int Radius
        {
            get
            {
                return radius;
            }
            set
            {
                if (radius != value)
                {
                    radius = Math.Max(0, value);
                    OnRadiusChanged(radius);
                    Invalidate();
                }
            }
        }

        /// <summary>
        /// 是否显示边框
        /// </summary>
        [Description("是否显示边框"), Category("SunnyUI")]
        [DefaultValue(true)]
        protected bool ShowRect => (int)RectSides > 0;

        /// <summary>
        /// 边框颜色
        /// </summary>
        [Description("边框颜色"), Category("SunnyUI")]
        [DefaultValue(typeof(Color), "80, 160, 255")]
        public Color RectColor
        {
            get
            {
                return rectColor;
            }
            set
            {
                if (rectColor != value)
                {
                    rectColor = value;
                    RectColorChanged?.Invoke(this, null);
                    Invalidate();
                }

                AfterSetRectColor(value);
            }
        }

        /// <summary>
        /// 填充颜色，当值为背景色或透明色或空值则不填充
        /// </summary>
        [Description("填充颜色，当值为背景色或透明色或空值则不填充"), Category("SunnyUI")]
        [DefaultValue(typeof(Color), "235, 243, 255")]
        public Color FillColor
        {
            get
            {
                return fillColor;
            }
            set
            {
                if (fillColor != value)
                {
                    fillColor = value;
                    FillColorChanged?.Invoke(this, null);
                    Invalidate();
                }

                AfterSetFillColor(value);
            }
        }

        protected void SetFillDisableColor(Color color)
        {
            fillDisableColor = color;
        }

        protected void SetRectDisableColor(Color color)
        {
            rectDisableColor = color;
        }

        protected void SetForeDisableColor(Color color)
        {
            foreDisableColor = color;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (!Visible || Width <= 0 || Height <= 0) return;

            Rectangle rect = new Rectangle(0, 0, Width - 1, Height - 1);
            GraphicsPath path = GDIEx.CreateRoundedRectanglePath(rect, radius, RadiusSides);

            //填充背景色
            if (fillColor.IsValid())
            {
                OnPaintFill(e.Graphics, path);
            }

            //填充边框色
            if (ShowRect)
            {
                OnPaintRect(e.Graphics, path);
            }

            PaintOther?.Invoke(this, e);

            path.Dispose();
        }

        public event PaintEventHandler PaintOther;

        protected virtual void OnPaintFore(Graphics g, GraphicsPath path)
        {
        }

        protected virtual void OnPaintRect(Graphics g, GraphicsPath path)
        {
            Color color = GetRectColor();

            //IsRadius为False时，显示左侧边线
            bool ShowRectLeft = RectSides.GetValue(ToolStripStatusLabelBorderSides.Left);
            //IsRadius为False时，显示上侧边线
            bool ShowRectTop = RectSides.GetValue(ToolStripStatusLabelBorderSides.Top);
            //IsRadius为False时，显示右侧边线
            bool ShowRectRight = RectSides.GetValue(ToolStripStatusLabelBorderSides.Right);
            //IsRadius为False时，显示下侧边线
            bool ShowRectBottom = RectSides.GetValue(ToolStripStatusLabelBorderSides.Bottom);

            //IsRadius为True时，显示左上圆角
            bool RadiusLeftTop = RadiusSides.GetValue(UICornerRadiusSides.LeftTop);
            //IsRadius为True时，显示左下圆角
            bool RadiusLeftBottom = RadiusSides.GetValue(UICornerRadiusSides.LeftBottom);
            //IsRadius为True时，显示右上圆角
            bool RadiusRightTop = RadiusSides.GetValue(UICornerRadiusSides.RightTop);
            //IsRadius为True时，显示右下圆角
            bool RadiusRightBottom = RadiusSides.GetValue(UICornerRadiusSides.RightBottom);

            if (RadiusSides == UICornerRadiusSides.None)
                g.DrawRectangle(new Pen(color), 0, 0, Width - 1, Height - 1);
            else
                g.DrawPath(color, path);

            using (Pen pen = new Pen(fillColor))
            using (Pen penR = new Pen(rectColor))
            {
                if (!ShowRadius || (ShowRadius && !RadiusLeftBottom && !RadiusLeftTop))
                {
                    g.DrawLine(penR, 0, 0, 0, Height - 1);
                }

                if (!ShowRadius || (ShowRadius && !RadiusRightTop && !RadiusLeftTop))
                {
                    g.DrawLine(penR, 0, 0, Width - 1, 0);
                }

                if (!ShowRadius || (ShowRadius && !RadiusRightTop && !RadiusRightBottom))
                {
                    g.DrawLine(penR, Width - 1, 0, Width - 1, Height - 1);
                }

                if (!ShowRectLeft)
                {
                    if (!ShowRadius || (ShowRadius && !RadiusLeftBottom && !RadiusLeftTop))
                    {
                        g.DrawLine(pen, 0, 1, 0, Height - 2);
                    }
                }

                if (!ShowRadius || (ShowRadius && !RadiusLeftBottom && !RadiusRightBottom))
                {
                    g.DrawLine(penR, 0, Height - 1, Width - 1, Height - 1);
                }

                if (!ShowRectTop)
                {
                    if (!ShowRadius || (ShowRadius && !RadiusRightTop && !RadiusLeftTop))
                    {
                        g.DrawLine(pen, 1, 0, Width - 2, 0);
                    }
                }

                if (!ShowRectRight)
                {
                    if (!ShowRadius || (ShowRadius && !RadiusRightTop && !RadiusRightBottom))
                    {
                        g.DrawLine(pen, Width - 1, 1, Width - 1, Height - 2);
                    }
                }

                if (!ShowRectBottom)
                {
                    if (!ShowRadius || (ShowRadius && !RadiusLeftBottom && !RadiusRightBottom))
                    {
                        g.DrawLine(pen, 1, Height - 1, Width - 2, Height - 1);
                    }
                }

                if (!ShowRectLeft && !ShowRectTop)
                {
                    if (!ShowRadius || (ShowRadius && !RadiusLeftBottom && !RadiusLeftTop))
                        g.DrawLine(pen, 0, 0, 0, 1);
                }

                if (!ShowRectRight && !ShowRectTop)
                {
                    if (!ShowRadius || (ShowRadius && !RadiusLeftBottom && !RadiusLeftTop))
                        g.DrawLine(pen, Width - 1, 0, Width - 1, 1);
                }

                if (!ShowRectLeft && !ShowRectBottom)
                {
                    if (!ShowRadius || (ShowRadius && !RadiusLeftBottom && !RadiusLeftTop))
                        g.DrawLine(pen, 0, Height - 1, 0, Height - 2);
                }

                if (!ShowRectRight && !ShowRectBottom)
                {
                    if (!ShowRadius || (ShowRadius && !RadiusLeftBottom && !RadiusLeftTop))
                        g.DrawLine(pen, Width - 1, Height - 1, Width - 1, Height - 2);
                }
            }
        }

        protected virtual void OnPaintFill(Graphics g, GraphicsPath path)
        {
            Color color = GetFillColor();

            if (RadiusSides == UICornerRadiusSides.None)
                g.Clear(color);
            else
                g.FillPath(color, path);
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg != 20)
            {
                base.WndProc(ref m);
            }
        }

        protected virtual void AfterSetFillColor(Color color)
        {
        }

        protected virtual void AfterSetRectColor(Color color)
        {
        }

        protected virtual void AfterSetForeColor(Color color)
        {
        }

        [DefaultValue(typeof(Color), "244, 244, 244")]
        [Description("不可用时填充颜色"), Category("SunnyUI")]
        public Color FillDisableColor
        {
            get => fillDisableColor;
            set => SetFillDisableColor(value);
        }

        [DefaultValue(typeof(Color), "173, 178, 181")]
        [Description("不可用时边框颜色"), Category("SunnyUI")]
        public Color RectDisableColor
        {
            get => rectDisableColor;
            set => SetRectDisableColor(value);
        }

        protected virtual void OnRadiusChanged(int value)
        {
        }

        protected Color foreDisableColor = Color.FromArgb(109, 109, 103);
        protected Color rectDisableColor = Color.FromArgb(173, 178, 181);
        protected Color fillDisableColor = Color.FromArgb(244, 244, 244);

        protected Color GetRectColor()
        {
            return Enabled ? rectColor : rectDisableColor;
        }

        protected Color GetForeColor()
        {
            return Enabled ? foreColor : foreDisableColor;
        }

        protected Color GetFillColor()
        {
            return Enabled ? fillColor : fillDisableColor;
        }

        /// <summary>
        /// 屏蔽原属性，获取或设置一个值，该值指示是否在 Windows 任务栏中显示窗体。
        /// </summary>
        /// <value><c>true</c> if [show in taskbar]; otherwise, <c>false</c>.</value>
        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("禁用该属性！", true)]
        public new BorderStyle BorderStyle => BorderStyle.None;

        public event EventHandler FillColorChanged;

        public event EventHandler RectColorChanged;
    }
}