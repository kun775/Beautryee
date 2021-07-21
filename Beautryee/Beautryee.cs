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
        private bool IsGameOver = true;     // 游戏是否结束
        private bool IsRelease = false;     // 上一个按键是否已经执行
        private bool IsApplePlus = false;   // 苹果超大杯
        private bool IsPause = false;        // 是否暂停游戏
        private readonly Color MapColor = SystemColors.Info;    // 地图颜色
        private readonly Color SnakeColor = Color.SaddleBrown;  // 蛇颜色
        private readonly Color ObstacleColor = Color.Black;     // 障碍物颜色
        private readonly Color GameOverColor = Color.DimGray;   // 游戏结束颜色
        private Direction direction = Direction.RIGHT;          // 移动方向
        private readonly Queue<Point> SnakeBody = new Queue<Point> { }; // 蛇身集合
        private readonly int [] GameOverPoint = new int[]     // 游戏结束
        {
            0,5,0,6,0,7,0,8,0,9,1,5,1,9,2,5,2,7,2,8,2,9,3,11,3,12,3,13,3,14,3,
            15,4,6,4,7,4,8,4,9,4,11,4,15,5,5,5,8,5,11,5,12,5,13,5,14,5,15,6,6,
            6,7,6,8,6,9,7,11,7,12,7,13,7,14,8,5,8,6,8,7,8,8,8,9,8,15,9,6,9,11,
            9,12,9,13,9,14,10,7,11,6,11,11,11,12,11,13,11,14,11,15,12,5,12,6,12,
            7,12,8,12,9,12,11,12,13,12,15,13,11,13,13,13,15,14,5,14,6,14,7,14,8,
            14,9,15,5,15,7,15,9,15,11,15,12,15,13,15,14,15,15,16,5,16,7,16,9,16,
            11,16,13,16,14,17,11,17,12,17,13,17,15,19,11,19,12,19,13,19,15
        };
        private int[] ObstaclePoint = new int[] {
            2,2,3,3,4,4,5,5,14,5,15,4,16,3,17,2,8,8,9,9,10,10,11,
            11,14,14,15,15,16,16,17,17,2,17,3,16,4,15,5,14,8,11,9,10,10,9,11,8
        };

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
            GameStart();
            Button_Start.Enabled = false;
        }
        // 新游戏
        private void GameStart()
        {
            for (int x = 0; x < Col; x++)
                for (int y = 0; y < Row; y++)
                    MapItems[x, y].BackColor = MapColor;

            IsGameOver = false;
            Score = 0;
            CheckBox2_Edit.Enabled = false;
            
            SnakeLenth = 3;
            direction = Direction.RIGHT;

            Label_Score.Text = $"{Score}";
            if (checkBox1.Checked)
                GenerateObstacle();
            GenerateSnake();
            GenerateApple();
            new Thread(new ThreadStart(Running)).Start();
        }
        // 游戏暂停
        private void GamePause()
        {
            if (IsGameOver)
                return;
            IsPause = !IsPause;
            Label_Pause.Visible = IsPause;
        }
        // 游戏结束
        private void GameOver()
        {
            Button_Start.Enabled = true;
            CheckBox2_Edit.Enabled = true;
            Print(GameOverPoint, GameOverColor);
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
                RegisterHotKey(Handle, 101, 0, Keys.PageUp);
                RegisterHotKey(Handle, 102, 0, Keys.PageDown);
                RegisterHotKey(Handle, 103, 0, Keys.Space);
            }
            catch (Exception ex)
            {
                MessageBox.Show("注册快捷键失败\n" + ex.Message);
            }
        }
        // 生成障碍物
        private void GenerateObstacle()
        {
            Print(ObstaclePoint, ObstacleColor);
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
                    };
                    item.Click += Item_Click;
                    MapItems[x,y] = item;
                    Controls.Add(item);
                }
            }
        }

        private void Item_Click(object sender, EventArgs e)
        {
            if (CheckBox2_Edit.Checked)
            {
                Panel panel = (Panel)sender;
                string name = panel.Name.Replace("Box", "");
                int x = int.Parse(name.Split('_')[0]);
                int y = int.Parse(name.Split('_')[1]);

                if (MapItems[x, y].BackColor == ObstacleColor)
                    MapItems[x, y].BackColor = MapColor;
                else
                    MapItems[x, y].BackColor = ObstacleColor;
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
                if (MapItems[x, y].BackColor == ObstacleColor)
                    continue;

                Apple = new Point(x, y);
                
                if (!SnakeBody.Contains(Apple))
                {
                    if (ran.Next(0, 10) == 1)
                    {
                        MapItems[x, y].BackColor = Color.Red;
                        IsApplePlus = true;
                    }
                    else
                    {
                        MapItems[x, y].BackColor = Color.Green;
                        IsApplePlus = false;
                    }
                    break;
                }
            }
        }
        // 移动
        private void Running()
        {
            while (!IsGameOver)
            {
                Thread.Sleep((int)Interval);
                if (IsPause)
                    continue;
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
                        IsGameOver = true;
                        break;
                    }
                    if (MapItems[SnakeHeader.X, SnakeHeader.Y].BackColor == ObstacleColor)
                    {
                        IsGameOver = true;
                        break;
                    }
                    MapItems[SnakeHeader.X, SnakeHeader.Y].BackColor = SnakeColor;
                    if (SnakeHeader == Apple)
                    {
                        SnakeBody.Enqueue(SnakeHeader);
                        if (IsApplePlus)
                            Score += 10;
                        else
                            Score += 1;
                        SnakeLenth++;
                        GenerateApple();
                        Label_Score.Text = $"{Score}";
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
                    IsGameOver = true;
                    break;
                }
            }
            GameOver();
        }
        
        // 打印点阵颜色
        private void Print(int[] Points, Color color)
        {
            int flag = 0, x = 0;
            try
            {
                foreach (var item in Points)
                {
                    if (flag % 2 == 0)
                        x = item;
                    else
                    {
                        int y = item;
                        MapItems[x, y].BackColor = color;
                    }
                    flag++;
                }
            }
            catch
            { }
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
                case (int)Direction.UP:     HotKey_Up();    break;
                case (int)Direction.RIGHT:  HotKey_Right(); break;
                case (int)Direction.DOWN:   HotKey_Down();  break;
                case (int)Direction.LEFT:   HotKey_Left();  break;
                case 101:   SpeedUp();      break;
                case 102:   SpeedDown();    break;
                case 103:   GamePause();    break;
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
            SpeedUp();
        }
        // 速度加
        private void SpeedUp()
        {
            if (Level < 10)
                Level++;

            Label_Level.Text = Level.ToString();
            Interval = 200 * Math.Pow(0.9, (double)Level - 1);
        }
        // 等级减
        private void Link_LevelDown_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SpeedDown();
        }
        // 速度减
        private void SpeedDown()
        {
            if (Level > 1)
                Level--;

            Label_Level.Text = Level.ToString();
            Interval = 200 * Math.Pow(0.9, (double)Level - 1);
        }
        
        // 进入编辑模式
        private void CheckBox2_Edit_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox2_Edit.Checked)
            {
                Button_Start.Enabled = false;
                Button_Save.Visible = true;
            }    
            else
            {
                Button_Start.Enabled = true;
                Button_Save.Visible = false;
            }
        }
        // 保存障碍物
        private void Button_Save_Click(object sender, EventArgs e)
        {
            CheckBox2_Edit.Checked = false;
            Button_Save.Visible = false;
            checkBox1.Checked = true;
            List<int> items = new List<int> { };
            foreach (var item in MapItems)
            {
                if (item.BackColor == ObstacleColor)
                {
                    string name = item.Name.Replace("Box", "");
                    int x = int.Parse(name.Split('_')[0]);
                    int y = int.Parse(name.Split('_')[1]);
                    items.Add(x);
                    items.Add(y);
                }
            }
            ObstaclePoint = items.ToArray();
            MessageBox.Show("保存成功");
        }
    }
}
