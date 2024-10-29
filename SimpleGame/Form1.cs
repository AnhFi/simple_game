using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.Resources;
using WMPLib;
using System.Net.Sockets;
using System.Runtime.ExceptionServices;
using System.Drawing.Text;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Reflection.Emit;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;
using System.Threading;

// Khong nhan space duoc
namespace SimpleGame
{
    public partial class Form1   : Form
    {
       
        // Khai báo biến toàn cục để lưu lại kích thước form
        private int originalWidth;
        private int originalHeight;
        private string text;
        private bool pause;
        private bool gameIsOver;

        WindowsMediaPlayer gameMedia;
        WindowsMediaPlayer shootgMedia;
        WindowsMediaPlayer explosion;
        WindowsMediaPlayer boom;

        // Mảng lưu trữ đạn của đối thủ
        PictureBox[] enemiesMunition;
        int enemiesMunitionSpeed;

        // Mảng lưu trữ số lượng đối thủ
        PictureBox[] enemies;
        int enemiesSpeed;

        // Mảng lưu trữ các ngôi sao
        PictureBox[] stars;
        int backgroundSpeed, playerSpeed;
        Image star = Image.FromFile(@"asserts/stars.png");

        Random rnd;
        // Mảng lưu trữ đạn của player
        PictureBox[] munitions;
        int MunitionSpeed;

        // Mảng để lưu trữ các trái tim
        PictureBox[] hearts;
        int heartminus;
        Image heart1 = Image.FromFile(@"asserts/heart1.png");
        Image heart2 = Image.FromFile(@"asserts/heart2.png");
        int tam;

        // Mảng để lưu trữ các hộp quà
        PictureBox[] presents;
        int presentspeed;
        int tam2;
        int dem;

        // Tải hình ảnh hộp quà
        Image present = Image.FromFile(@"asserts/present.png");
        int score;
        int difficulty;
        int level;

        // Tải hình ảnh vụ nổ khi xảy ra va chạm
        PictureBox[] explodes; 
        Image explode = Image.FromFile(@"asserts/explode.png");

        // Tải hình ảnh đối thủ
        Image enemy1 = Image.FromFile(@"asserts/enemy1.png");
        Image enemy2 = Image.FromFile(@"asserts/ship1.png");
        Image enemy3 = Image.FromFile(@"asserts/ship2.png");
        Image enemy4 = Image.FromFile(@"asserts/ship3.png");
        Image enemy5 = Image.FromFile(@"asserts/ship4.png");

        // Tải hình ảnh trùm cuối
        int temp1 = 0;
        int hpboss1, bossspeed;
        Image shuriken = Image.FromFile(@"asserts/shuriken.png");
        Image boss1 = Image.FromFile(@"asserts/boss.png");
        PictureBox boss = new PictureBox();
        PictureBox[] BossMunition; 

        public Form1()
        {
            InitializeComponent();
            GameStart();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            // Biến kiểm tra trạng thái của game
            gameIsOver = false;
            pause = false;
            // Trong hàm Form1_Load
            originalWidth = this.Width;
            originalHeight = this.Height;

            // Biến tạm để hồi máu khi ăn quà
            tam = 0;
            dem = 0;
            // Hàm random
            rnd = new Random();

            // Máu của boss và tốc độ của boss
            hpboss1 = 20;
            bossspeed = 5;
            

            #region // Khởi tạo hình ảnh trái tim đại diện cho lượt chơi
            hearts = new PictureBox[3];
            for (int i = 0; i < hearts.Length; i++)
            {
                hearts[i] = new PictureBox();
                hearts[i].Size = new Size(25,30); // Kích cỡ trái tim
                hearts[i].Image = heart1;
                hearts[i].SizeMode = PictureBoxSizeMode.Zoom;
                hearts[i].BorderStyle = BorderStyle.None;
                hearts[i].Visible = true;
                hearts[i].Location = new Point((i + 1) * 24, this.Height - 70);
                this.Controls.Add(hearts[i]); // Thêm trái tim vào Background
            }
            #endregion

            #region // Khởi tạo ngôi sao trên background
            stars = new PictureBox[10]; // tạo một mảng có 10 ngôi sao
            for (int i = 0; i < stars.Length; i++)
            {
                stars[i] = new PictureBox();
                stars[i].Image = star;
                stars[i].SizeMode = PictureBoxSizeMode.Zoom;
                // Vị trí các ngôi sao
                stars[i].Location = new Point(rnd.Next(20, 400), rnd.Next(-10, 400));
                // Ngôi sao loại 1
                if (i % 2 == 0)
                {
                    stars[i].Size = new Size(10, 10);
                }
                // Ngôi sao loại 2 
                else
                {
                    stars[i].Size = new Size(10, 10);
                }
                this.Controls.Add(stars[i]); // Thêm các ngôi sao vào Background
            }
            #endregion

            #region // Khởi tạo tốc độ mặc định của các đối tượng
            score = 0; // điểm
            presentspeed = 2; // tốc độ hộp quà
            difficulty = 1; // độ khó ban đầu
            level = 1; // mực độ chơi ban đầu
            heartminus = 0; // máu bị mất ban đầu
            backgroundSpeed = 4; // tốc độ khung hình
            playerSpeed = 4; // tốc độ của người chơi
            enemiesSpeed = 2; // tốc độ của đối thủ
            enemiesMunitionSpeed = 2; // tốc độ đạn của enemies
            MunitionSpeed = 20; // tốc độ đạn của player
            #endregion

            #region// Tải hình ảnh đạn player
            Image munition = Image.FromFile(@"asserts\rocket.png");
            #endregion

            #region // Thiết lập thông số cho đạn player
            munitions = new PictureBox[3]; // số lượng đạn
            for (int i = 0; i < munitions.Length; i++)
            {
                munitions[i] = new PictureBox();
                munitions[i].Size = new Size(20, 20); // Kích cỡ viên đạn
                munitions[i].Image = munition;
                munitions[i].SizeMode = PictureBoxSizeMode.Zoom;
                munitions[i].BorderStyle = BorderStyle.None;
                this.Controls.Add(munitions[i]); // Thêm đạn vào Background
            }
            #endregion

            #region // Khởi tạo thông số đối thủ 
            enemies = new PictureBox[10]; // tạo số lượng đối thủ là 10 
            for (int i = 0; i< enemies.Length; i++)
            {
                enemies[i] = new PictureBox();
                enemies[i].Size = new Size(35, 35); // kích thước đối thủ
                enemies[i].SizeMode = PictureBoxSizeMode.Zoom; 
                enemies[i].BorderStyle = BorderStyle.None;
                enemies[i].Visible = false;
                enemies[i].Location = new Point((i + 1) * 38, -30); // vị trí xuất hiện của đối thủ
                this.Controls.Add (enemies[i]);
            }
            #endregion

            #region // Gán hình ảnh cho đối thủ
            enemies[0].Image = enemy4;
            enemies[1].Image = enemy1;
            enemies[2].Image = enemy3;
            enemies[3].Image = enemy5;
            enemies[4].Image = enemy1;
            enemies[5].Image = enemy3;
            enemies[6].Image = enemy1;
            enemies[7].Image = enemy5;
            enemies[8].Image = enemy2;
            enemies[9].Image = enemy4;

            #endregion

            #region // Khởi tạo hình ảnh hộp quà
            presents = new PictureBox[5];
            for (int i = 0; i < presents.Length; i++)
            {
                presents[i] = new PictureBox();
                presents[i].Size = new Size(35, 35); // kích thước hộp quà
                presents[i].Image = present;
                presents[i].SizeMode = PictureBoxSizeMode.Zoom;
                presents[i].BorderStyle = BorderStyle.None;
                presents[i].Visible = false;
                presents[i].Location = new Point(this.Height+10,this.Width+10); // vị trí xuất hiện của hộp quà
                this.Controls.Add(presents[i]);
            }

            #endregion

            #region // Khởi tạo đạn của đối thủ
            enemiesMunition = new PictureBox[10];
            for (int i = 0; i < enemiesMunition.Length; i++)
            {
                enemiesMunition[i] = new PictureBox();
                enemiesMunition[i].Size = new Size(1, 24);
                enemiesMunition[i].SizeMode = PictureBoxSizeMode.AutoSize;
                enemiesMunition[i].Visible = false;
                enemiesMunition[i].BackColor = Color.Yellow;
                enemiesMunition[i].Location = new Point(enemies[i].Location.X + 20, enemies[i].Location.Y + 30);
                this.Controls.Add(enemiesMunition[i]);
            }
            #endregion

            #region // Khởi tạo các vụ nổ
            explodes = new PictureBox[10];
            for (int i = 0; i < explodes.Length; i++)
            {
                explodes[i] = new PictureBox();
                explodes[i].Size = new Size(35, 35);
                explodes[i].SizeMode = PictureBoxSizeMode.Zoom;
                explodes[i].Image = explode;
                explodes[i].Location = new Point(1000, 1000);
                this.Controls.Add(explodes[i]);
            }
            #endregion

            #region // Khởi tạo đối tượng boss
            boss.Size = new Size(100, 100); // kích thước boss
            boss.Image = boss1;
            boss.SizeMode = PictureBoxSizeMode.Zoom;
            boss.BorderStyle = BorderStyle.None;
            boss.Visible = true;
            boss.Location = new Point(1000, 1000); // ẩn boss đi hoàn toàn
            this.Controls.Add(boss);
            #endregion

            #region // Khởi tạo đạn của boss
            BossMunition = new PictureBox[7];
            for (int i = 0;i < BossMunition.Length; i++)
            {
                BossMunition[i] = new PictureBox();
            }
            #endregion 

            #region // Khởi tạo đối tượng của lớp WMP
            gameMedia = new WindowsMediaPlayer();
            shootgMedia = new WindowsMediaPlayer();
            explosion = new WindowsMediaPlayer();
            boom = new WindowsMediaPlayer();
            #endregion

            #region // Tải âm thanh 
            gameMedia.URL = "songs\\GameSong.mp3";
            shootgMedia.URL = "songs\\shoot.mp3";
            explosion.URL = "songs\\boom.mp3";
            boom.URL = "songs\\bum.mp3";
            #endregion

            #region // Cài đặt âm lượng
            gameMedia.settings.setMode("loop", true);
            gameMedia.settings.volume = 5;
            shootgMedia.settings.volume = 6;
            explosion.settings.volume = 6;
            boom.settings.volume = 20;
            boom.controls.stop();
            #endregion
        }

        #region // Xử lý va chạm với hộp quà
        private void CollisionPresent()
        {
            for (int i = 0; i < presents.Length; i++)
            {
                if ((Player.Bounds.IntersectsWith(presents[i].Bounds))
                || ((Player.Bounds.IntersectsWith(presents[i].Bounds))
                || Player.Bounds.IntersectsWith(presents[i].Bounds)))
                {
                    heartminus--;
                    if (dem > 0)
                    {
                        hearts[dem - 1].Image = heart1;
                        dem--;
                    }
                    presents[i].Location = new Point(1000, 1000);
                }
            }
        }
        #endregion

        #region // Thiết lập tốc độ của ngôi sao 
        private void MoveBgTimer_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < stars.Length/2; i++)
            {
                stars[i].Top += backgroundSpeed;
                if (stars[i].Top >= this.Height)
                {
                    stars[i].Top = -stars[i].Height ;
                }
            }

            for (int i = stars.Length / 2; i < stars.Length; i++)
            {
                stars[i].Top += backgroundSpeed - 2 ;
                if (stars[i].Top >= this.Height)
                {
                    stars[i].Top = -stars[i].Height;
                }
            }
        }
        #endregion

        #region // Player di chuyển sang trái khi nhấn phím trái 
        private void LeftMoveTimer_Tick(object sender, EventArgs e)
        {
            if (Player.Left > 10) // Giới hạn phạm vi di chuyển cách mép trái 10 px
            {
                Player.Left -= playerSpeed; // Trừ đi playerSpeed (4) để di chuyển sang trái
                lbuser.Location = new Point(Player.Left - 8, Player.Location.Y + 40);
            }
        }
        #endregion

        #region // Player di chuyển sang phải khi nhấn phím phải 
        private void RightMoveTimer_Tick(object sender, EventArgs e)
        {
            if (Player.Right < 430) // Giới hạn phạm vi di chuyển cách mép phải < 430 px
            {
                Player.Left += playerSpeed; // Cộng thêm playerSpeed (4) để di chuyển sang phải
                lbuser.Location = new Point(Player.Left - 8, Player.Location.Y + 40);
            }
        }
        #endregion

        #region // Player di chuyển xuống khi nhấn phím xuống 
        private void DownMoveTimer_Tick(object sender, EventArgs e)
        {
            if (Player.Top < 320) // Giới hạn phạm vi di chuyển cách mép dưới < 320 px
            {
                Player.Top += playerSpeed; // Cộng thêm playerSpeed (4) để di chuyển xuống
                lbuser.Location = new Point(Player.Left - 8, Player.Top + 40);
            }
        }
        #endregion

        #region // Player di chuyển lên khi nhấn phím lên 
        private void UpMoveTimer_Tick(object sender, EventArgs e)
        {
            if (Player.Top > 10) // // Giới hạn phạm vi di chuyển cách mép trên > 10 px
            {
                Player.Top -= playerSpeed; // Trừ đi playerSpeed (4) để di chuyển lên trên
                lbuser.Location = new Point(Player.Left - 8, Player.Top + 40);
            }
        }
        #endregion

        #region // Thiết lập kích hoạt sự kiện khi nhấn phím
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (!gameIsOver)
            {
                if (!pause)
                {
                    // Khi nhấn phím -> thì bộ đếm phải sẽ đếm đủ 1ms thì sẽ thực hiện
                    // sự kiện Tick: RightMoveTimer_Tick
                    if (e.KeyCode == Keys.Right)
                    {
                        RightMoveTimer.Start();
                    }
                    // Khi nhấn phím <- thì bộ đếm trái sẽ đếm đủ 1ms thì sẽ thực hiện
                    // sự kiện Tick: LeftMoveTimer_Tick
                    if (e.KeyCode == Keys.Left)
                    {
                        LeftMoveTimer.Start();
                    }
                    // Khi nhấn phím ↓ thì bộ đếm xuống sẽ đếm đủ 1ms thì sẽ thực hiện
                    // sự kiện Tick: DownMoveTimer_Tick
                    if (e.KeyCode == Keys.Down)
                    {
                        DownMoveTimer.Start();
                    }
                    // Khi nhấn phím ↑ thì bộ đếm xuống sẽ đếm đủ 1ms thì sẽ thực hiện
                    // sự kiện Tick: UpMoveTimer_Tick
                    if (e.KeyCode == Keys.Up)
                    {
                        UpMoveTimer.Start();
                    }

                }
            }

        }
        #endregion  

        #region // Tốc độ và hướng của đạn player && kiểm tra va chạm 
        private void MoveMunitionTimer_Tick(object sender, EventArgs e)
        {
            shootgMedia.controls.play();
            for (int i = 0; i< munitions.Length; i++)
            {
                
                if (munitions[i].Top > 0)
                {
                    munitions[i].Visible = true;
                    munitions[i].Top -= MunitionSpeed;
                    Collision();
                    CollisionWithBoss();
                }
                else
                {
                    munitions[i].Visible = false;
                    munitions[i].Location = new Point(Player.Location.X + 10, Player.Location.Y - i * 30);
                }
            }
        }
        #endregion

        #region // Thay đổi vị trí của đối thủ
        private void MoveEnemiesTimer_Tick(object sender, EventArgs e)
        {
            MoveEnemies(enemies, enemiesSpeed);
        }
        private void MoveEnemies(PictureBox[] array,int speed)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i].Visible = true;
                array[i].Top += speed;

                if (array[i].Top > this.Height)
                {
                    array[i].Location = new Point((i + 1) * 50, -100);
                }
            }

        }
        #endregion

        #region // Xử lý va chạm giữa player - enemies , munition - enemies
        private void Collision()    
        {
            for (int i = 0; i < enemies.Length; i++)
            {
                
                if ((munitions[0].Bounds.IntersectsWith(enemies[i].Bounds))
                || ((munitions[1].  Bounds.IntersectsWith(enemies[i].Bounds))
                || munitions[2].Bounds.IntersectsWith(enemies[i].Bounds)))
                {
                    explodes[i].Location = enemies[i].Location;
                    explosion.controls.play();
                    if (enemies[i].Location.X > 0) // Khi kẻ địch trong khung background thì mới tăng điểm
                        score += 1;
                    scorelb1.Text = (score < 10) ? "Score: " + "0" + score.ToString() : "Score: " + score.ToString();
                    if (score % 10 == 0)
                    {
                        level += 1;
                        levellb1.Text = (level < 10) ? "Level: " + "0" + level.ToString() : "Level: " + level.ToString();
                        

                        if (enemiesSpeed <= 10 && enemiesMunitionSpeed <= 10 && difficulty <= 5)
                        {
                            difficulty++;
                            enemiesSpeed++;
                            enemiesMunitionSpeed++;
                        }

                        if (difficulty > 2 && tam < 5)
                        {
                            presents[tam].Location = new Point((tam + 1) * 100, 20);
                            tam++;
                        }
                            
                        if (level == 5)
                        {
                            EnemiesMunitionTimer.Stop();
                            MoveEnemiesTimer.Stop();
                            Remove(enemies, enemiesMunition);
                            boss.Location = new Point(180, 10);
                            MoveBossTimer.Start();
                            CreateBossMunition();
                        }
                        
                    }
                    else
                    {
                        levellb1.Text = (level < 10) ? "Level: " + "0" + level.ToString() : "Level: " + level.ToString();
                    }
                    enemies[i].Location = new Point((i + 1) * 50, -80); // Bắn trúng thì reset lại vị trí
                }
                
                if (Player.Bounds.IntersectsWith(enemies[i].Bounds))
                {
                    enemies[i].Visible = false;
                    GameOver("GameOver");
                }

            }
            
        }
        #endregion

        #region // Tạm dừng trò chơi khi nhấn phím space và hủy bằng cách nhấn nút bất kỳ
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            RightMoveTimer.Stop();
            LeftMoveTimer.Stop();
            DownMoveTimer.Stop();
            UpMoveTimer.Stop();

            if (!gameIsOver)
            {
                if (e.KeyCode == Keys.Space)
                {
                    if (pause == false)
                    {
                        StopTimer();
                        lbtt.Location = new Point(120, 120);
                        lbtt.Text = "PAUSED";
                        lbtt.Visible = true;
                        gameMedia.controls.pause();
                        pause = true;
                    }
                }
                else
                {
                    StartTimer();
                    lbtt.Visible = false;
                    gameMedia.controls.play();
                    pause = false;
                }
            }
        }
        #endregion

        #region // Thiết lập khi bắt đầu trò chơi
        private void GameStart()
        {
            StopTimer();
            lbtt.Text = "Hello Player";
            lbtt.Location = new Point(100, 61);
            PlayBtn.Location = new Point(120, 135);
            ExitBtn.Location = new Point(120, 210);
            scorelb1.Location = new Point(0, 0);
            levellb1.Location = new Point(350, 0);
            lbuser.Visible = false;
            lbtt.Visible = true;
            PlayBtn.Visible = true;
            ExitBtn.Visible = true;

        }
        #endregion

        #region // Kết thúc trò chơi khi xảy ra va chạm
        private void GameOver(string str)
        {
            StopTimer();
            RightMoveTimer.Stop();
            LeftMoveTimer.Stop();
            DownMoveTimer.Stop();
            UpMoveTimer.Stop();
            boom.controls.play();
            lbtt.Text = str;
            lbtt.Location = new Point(125, 61);
            lbtt.TextAlign = ContentAlignment.MiddleCenter;
            lbtt.Visible = true;
            ReplayBtn.Visible = true;
            ReplayBtn.Location = new Point(120, 185);
            btn_save.Visible = true;
            btn_save.Location = new Point(120, 125);
            ExitBtn.Visible = true;
            gameIsOver = true;
            //boss.Visible = true;
            lbuser.Visible = false;
            gameMedia.controls.stop();
     
        }
        #endregion

        #region // Ngừng chuyển động của toàn bộ đối tượng
        private void StopTimer()
        {
            MoveBossMunition.Stop();
            MoveBossTimer.Stop();
            MovePresentTimer.Stop();
            MoveBgTimer.Stop();
            MoveEnemiesTimer.Stop();
            MoveMunitionTimer.Stop();
            EnemiesMunitionTimer.Stop();
        }
        #endregion

        #region // Thiết lập thông số đạn của đối thủ
        private void EnemiesMunitionTimer_Tick(object sender, EventArgs e)
        {
            if (difficulty > 5) difficulty = 5;
            for (int i = 0; i < 5 + difficulty; i++)
            {
                if (enemiesMunition[i].Top < this.Height)
                {
                    enemiesMunition[i].Visible = true;
                    enemiesMunition[i].Top += enemiesMunitionSpeed;
                    CollisionWithEnemiesMunition();
                }

                else
                {
                    enemiesMunition[i].Visible = false;
                    enemiesMunition[i].Location = new Point(enemies[i].Location.X + 18, enemies[i].Location.Y + 1);
                }
            }
          
        }
        #endregion

        #region // Xử lý va chạm giữa đạn đối thủ và player
        private void CollisionWithEnemiesMunition()
        {
            for (int i = 0; i < 10; i++)
            {
                if (enemiesMunition[i].Bounds.IntersectsWith(Player.Bounds))
                {
                    heartminus++;
                    dem++;
                    enemiesMunition[i].Location = new Point(this.Height+10,10); // Làm viên đạn biến mất hoàn toàn khỏi background
                    if (heartminus == 1)
                    {
                        hearts[0].Image = heart2;
                    }

                    else if (heartminus == 2)
                    {

                        hearts[1].Image = heart2;
                    }

                    else if (heartminus == 3)
                    {
                        hearts[2].Image = heart2;
                        
                    }

                    else if (heartminus > 3)
                    {
                        gameIsOver = true;
                        Player.Image = explode;
                        GameOver("GameOver");
                    }
                }
            }
        }

        #endregion

        #region // Tạo các sự kiện khi nhấn nút
        private void ExitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ReplayBtn_Click(object sender, EventArgs e)
        {
            ResetGame();
        }

        private void PlayBtn_Click(object sender, EventArgs e)
        {
            ResetGame();
        }
        #endregion

        #region // Thay đổi vị trí hộp quà
        private void MovePresentTimer_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < presents.Length; i++)
            {
                if (presents[i].Top < this.Height)
                {
                    presents[i].Visible = true;
                    presents[i].Top += presentspeed;
                    CollisionPresent();
                }
            }
        }
        #endregion
   
        #region // Đặt lại bộ đếm thời gian cho toàn bộ đối tượng 
        private void StartTimer()
        {
            MovePresentTimer.Start();
            MoveBgTimer.Start();
            MoveEnemiesTimer.Start();
            MoveMunitionTimer.Start();
            EnemiesMunitionTimer.Start();
        }
        #endregion

        #region // Lưu lại dữ liệu người chơi
        private void btn_save_Click(object sender, EventArgs e)
        {
            boom.controls.stop();
            Form5 form5 = new Form5(score);
            form5.ShowDialog();
        }
        #endregion

        #region // Tạo ra vụ nổ khi xảy ra va chạm
        private void HideExplode_Tick(object sender, EventArgs e)
        {
            HideExplode1(explodes);
        }

        private void HideExplode1(PictureBox[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i].Location = new Point(1000, 1000);
            }

        }

        #endregion

        #region // Phạm vi di chuyển của boss 
        private void MoveBossTimer_Tick(object sender, EventArgs e)
        {
            MoveBoss(boss, bossspeed);
        }
        private void MoveBoss(PictureBox ptx, int bossspeed)
        {
            
            if (ptx.Top < this.Height)
            {
                if (temp1 == 0 && ptx.Left < 350)
                {
                    ptx.Left += bossspeed;
                    if (ptx.Left > 345) temp1 = 1;
                }
                else
                {
                    ptx.Left -= bossspeed;
                    if (ptx.Left < 20) temp1 = 0;
                }
            }

            else
            {
                ptx.Location = new Point(rnd.Next(20,100), rnd.Next(0,5));
            }

            
        }
        #endregion 

        #region // Xóa đi các tàu nhỏ và đạn của chúng khi boss xuất hiện
        private void Remove(PictureBox[] arr, PictureBox[] arr1 )
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i].Location = new Point(1000, 1000);
            }

            for (int i = 0; i < arr1.Length; i++)
            {
                arr1[i].Location = new Point(1000,1000);
            }
        }

        #endregion

        #region // Tạo boss và đạn boss khi đạt level yêu cầu
        private void MoveBossMunition_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < BossMunition.Length; i++)
            {
                if (BossMunition[i].Top < this.Height)
                {
                    BossMunition[i].Top += 3;
                    CollisionWithBossMunition();
                }
                else
                {
                    BossMunition[i].Location = new Point(boss.Location.X + rnd.Next(30, 40) * i, boss.Location.Y + 80);
                }
            }
        }
        private void CreateBossMunition()
        {
            for (int i = 0; i < BossMunition.Length; i++)
            {
                BossMunition[i].Size = new Size(20, 20);
                BossMunition[i].Image = shuriken;
                BossMunition[i].SizeMode = PictureBoxSizeMode.Zoom;
                BossMunition[i].Visible = true;
                BossMunition[i].Location = new Point(boss.Location.X + 10 + (i * 25), boss.Location.Y + 80);
                this.Controls.Add(BossMunition[i]);
            }
        }

        #endregion 

        #region // Xử lý va chạm khi trúng đạn boss
        private void CollisionWithBossMunition()
        {
            for (int i = 0; i < BossMunition.Length; i++)
            {
                if ((Player.Bounds.IntersectsWith(BossMunition[i].Bounds)))
                {
                    heartminus++;
                    dem++;
                    BossMunition[i].Location = new Point(1000,1000); // Làm viên đạn biến mất hoàn toàn khỏi background
                    if (heartminus == 1)
                    {
                        hearts[0].Image = heart2;
                    }

                    else if (heartminus == 2)
                    {

                        hearts[1].Image = heart2;
                    }

                    else if (heartminus == 3)
                    {
                        hearts[2].Image = heart2;

                    }

                    else if (heartminus > 3)
                    {
                        gameIsOver = true;
                        Player.Image = explode;
                        GameOver("Game Over");
                    }
                }
            }
        }
        #endregion

        #region // Xử lý va chạm với boss
        private void CollisionWithBoss()
        {
            for (int i = 0; i < munitions.Length; i++)
            {
                if ((munitions[i].Bounds.IntersectsWith(boss.Bounds)))
                {
                    score++;
                    scorelb1.Text = (score < 10) ? "Score: " + "0" + score.ToString() : "Score: " + score.ToString();
                    hpboss1--;
                    munitions[i].Location = new Point(-100, 100);
                }
                if (hpboss1 < 1)
                {
                    gameIsOver = true;
                    boss.Image = explode;
                    GameOver("You Win");
                }
            }
        }

        #endregion

        #region // Đặt lại các thông số trò chơi
        private void ResetGame()
        {
            RightMoveTimer.Stop();
            LeftMoveTimer.Stop();
            DownMoveTimer.Stop();
            UpMoveTimer.Stop();

            this.Controls.Clear();
            InitializeComponent();
            this.Width = originalWidth;
            this.Height = originalHeight;
            Form1_Load(this,new EventArgs());
        }
        #endregion 

    }
}
