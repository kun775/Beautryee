using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace Beautryee
{
    public enum Direction
    {
        UP,
        RIGHT,
        DOWN,
        LEFT
    };
    public partial class Beautryee : Form
    {
        [DllImport("user32.dll")] //申明API函数
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, Keys vk);
        [DllImport("user32.dll")] //申明API函数
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);
        private Panel[,] MapItems;          // 地图集合
        private readonly int Row = 20;      // 格子行数
        private readonly int Col = 20;      // 格子列数
        private readonly int ItemSize = 20; // 格子边长
        private double Interval = 200;      // 移动速度
        private Random ran;                 // 随机生成苹果
        private Point Apple = new Point(0, 0);  // 苹果位置
        private Point SnakeHeader;          // 蛇头位置
        private int SnakeLenth = 3;         // 蛇身长度
        private int Score = 0;              // 分数
        private int Level = 1;              // 等级
        private bool GameOver = false;      // 游戏是否结束
        private bool IsRelease = false;     // 上一个按键是否已经执行
        private readonly Color MapColor = SystemColors.Info;    // 地图颜色
        private readonly Color SnakeColor = Color.SaddleBrown;  // 蛇颜色
        private Direction direction = Direction.RIGHT;          // 移动方向
        private readonly Queue<Point> SnakeBody = new Queue<Point> { }; // 蛇身集合

        public Beautryee()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private void Beautryee_Load(object sender, EventArgs e)
        {
            RegisterHotKey();
            ran = new Random((int)DateTime.Now.Ticks);
            GenerateMap();
        }
        // 开始游戏
        private void Button_Start_Click(object sender, EventArgs e)
        {
            NewGame();
            Button_Start.Enabled = false;
        }
        // 新游戏
        private void NewGame()
        {
            foreach (var item in SnakeBody)
                MapItems[item.X, item.Y].BackColor = MapColor;
            MapItems[Apple.X, Apple.Y].BackColor = MapColor;

            GameOver = false;
            Score = 0;
            Level = int.Parse(Label_Level.Text);
            Interval *= Math.Pow(0.9, (double)Level - 1);
            SnakeLenth = 3;
            direction = Direction.RIGHT;

            Label_Score.Text = $"Score: {Score}";

            GenerateSnake();
            GenerateApple();
            new Thread(new ThreadStart(Running)).Start();
        }
        // 注册快捷键
        private void RegisterHotKey()
        {
            try
            {
                RegisterHotKey(Handle, (int)Direction.UP, 0, Keys.Up);
                RegisterHotKey(Handle, (int)Direction.RIGHT, 0, Keys.Right);
                RegisterHotKey(Handle, (int)Direction.DOWN, 0, Keys.Down);
                RegisterHotKey(Handle, (int)Direction.LEFT, 0, Keys.Left);
            }
            catch (Exception ex)
            {
                MessageBox.Show("注册快捷键失败\n" + ex.Message);
            }
        }
        // 生成地图
        private void GenerateMap()
        {
            MapItems = new Panel[Col, Row];
            for (int x = 0; x < Col; x++)
            {
                for (int y = 0; y < Row; y++)
                {
                    Panel item = new Panel
                    {
                        Name = $"Box{x}_{y}",
                        Size = new Size(ItemSize, ItemSize),
                        Location = new Point(x * ItemSize, y * ItemSize),
                        BackColor = MapColor,
                        Enabled = false,
                    };
                    MapItems[x,y] = item;
                    Controls.Add(item);
                }
            }
        }
        // 生成蛇
        private void GenerateSnake()
        {
            SnakeBody.Clear();
            for (int i = 0; i < SnakeLenth; i++)
            {
                SnakeBody.Enqueue(new Point(i, 0));
                MapItems[i, 0].BackColor = SnakeColor;
            }

            SnakeHeader = new Point(SnakeLenth-1, 0);
        }
        // 生成苹果
        private void GenerateApple()
        {
            while (true)
            {
                int x = ran.Next(0, Col);
                int y = ran.Next(0, Row);
                Apple = new Point(x, y);
                if (!SnakeBody.Contains(Apple))
                {
                    MapItems[x, y].BackColor = Color.Red;
                    break;
                }
            }
        }
        // 移动
        private void Running()
        {
            while (!GameOver)
            {
                Thread.Sleep((int)Interval);
                IsRelease = true;
                try
                {
                    StartPosition:
                    if (direction == Direction.RIGHT)
                    {
                        SnakeHeader.Offset(1, 0);
                    }
                    else if (direction == Direction.DOWN)
                    {
                        SnakeHeader.Offset(0, 1);
                    }
                    else if (direction == Direction.LEFT)
                    {
                        SnakeHeader.Offset(-1, 0);
                    }
                    else if (direction == Direction.UP)
                    {
                        SnakeHeader.Offset(0, -1);
                    }
                    if (SnakeBody.Contains(SnakeHeader))
                    {
                        GameOver = true;
                    }
                    MapItems[SnakeHeader.X, SnakeHeader.Y].BackColor = SnakeColor;
                    if (SnakeHeader == Apple)
                    {
                        SnakeBody.Enqueue(SnakeHeader);
                        Score++;
                        SnakeLenth++;
                        GenerateApple();
                        Label_Score.Text = $"Score: {Score}";
                        goto StartPosition;
                    }
                    else
                    {
                        SnakeBody.Enqueue(SnakeHeader);
                        Point item = SnakeBody.Dequeue();
                        MapItems[item.X, item.Y].BackColor = MapColor;
                    }
                }
                catch (IndexOutOfRangeException)
                {
                    GameOver = true;
                }
            }
            MessageBox.Show($"游戏结束，分数:{Score}", "游戏结束");
            Button_Start.Enabled = true;
        }
        // 上
        private void HotKey_Up()
        {
            if (!IsRelease || direction != Direction.LEFT && direction != Direction.RIGHT)
                return;
            direction = Direction.UP;
            IsRelease = false;
        }
        // 右
        private void HotKey_Right()
        {
            if (!IsRelease || direction != Direction.UP && direction != Direction.DOWN)
                return;
            direction = Direction.RIGHT;
            IsRelease = false;
        }
        // 下
        private void HotKey_Down()
        {
            if (!IsRelease || direction != Direction.LEFT && direction != Direction.RIGHT)
                return;
            direction = Direction.DOWN;
            IsRelease = false;
        }
        // 左
        private void HotKey_Left()
        {
            if (!IsRelease || direction != Direction.UP && direction != Direction.DOWN)
                return;
            direction = Direction.LEFT;
            IsRelease = false;
        }
        // 按下设定的键时调用该函数
        private void ProcessHotkey(Message m)
        {
            int id = m.WParam.ToInt32();
            switch (id)
            {
                case (int)Direction.UP:     HotKey_Up(); break;
                case (int)Direction.RIGHT:  HotKey_Right(); break;
                case (int)Direction.DOWN:   HotKey_Down(); break;
                case (int)Direction.LEFT:   HotKey_Left(); break;
            }
        }
        //监视Windows消息
        protected override void WndProc(ref Message m)
        {
            const int WM_HOTKEY = 0x0312;
            switch (m.Msg)
            {
                case WM_HOTKEY:ProcessHotkey(m); break;
            }
            base.WndProc(ref m);
        }
        // 关闭窗体
        private void Beautryee_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }
        // 等级加
        private void Link_LevelUp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (Level < 10)
                Level++;

            Label_Level.Text = Level.ToString();
        }
        // 等级减
        private void Link_LevelDown_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (Level > 1)
                Level--;

            Label_Level.Text = Level.ToString();
        }
    }
}
