namespace SimpleGame
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.MoveBgTimer = new System.Windows.Forms.Timer(this.components);
            this.Player = new System.Windows.Forms.PictureBox();
            this.LeftMoveTimer = new System.Windows.Forms.Timer(this.components);
            this.RightMoveTimer = new System.Windows.Forms.Timer(this.components);
            this.DownMoveTimer = new System.Windows.Forms.Timer(this.components);
            this.UpMoveTimer = new System.Windows.Forms.Timer(this.components);
            this.MoveMunitionTimer = new System.Windows.Forms.Timer(this.components);
            this.MoveEnemiesTimer = new System.Windows.Forms.Timer(this.components);
            this.EnemiesMunitionTimer = new System.Windows.Forms.Timer(this.components);
            this.lbtt = new System.Windows.Forms.Label();
            this.ExitBtn = new System.Windows.Forms.Button();
            this.ReplayBtn = new System.Windows.Forms.Button();
            this.scorelb1 = new System.Windows.Forms.Label();
            this.levellb1 = new System.Windows.Forms.Label();
            this.MovePresentTimer = new System.Windows.Forms.Timer(this.components);
            this.lbuser = new System.Windows.Forms.Label();
            this.PlayBtn = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.HideExplode = new System.Windows.Forms.Timer(this.components);
            this.MoveBossTimer = new System.Windows.Forms.Timer(this.components);
            this.MoveBossMunition = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.Player)).BeginInit();
            this.SuspendLayout();
            // 
            // MoveBgTimer
            // 
            this.MoveBgTimer.Enabled = true;
            this.MoveBgTimer.Interval = 10;
            this.MoveBgTimer.Tick += new System.EventHandler(this.MoveBgTimer_Tick);
            // 
            // Player
            // 
            this.Player.BackColor = System.Drawing.Color.Transparent;
            this.Player.Image = ((System.Drawing.Image)(resources.GetObject("Player.Image")));
            this.Player.Location = new System.Drawing.Point(256, 377);
            this.Player.Name = "Player";
            this.Player.Size = new System.Drawing.Size(59, 47);
            this.Player.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Player.TabIndex = 0;
            this.Player.TabStop = false;
            // 
            // LeftMoveTimer
            // 
            this.LeftMoveTimer.Interval = 1;
            this.LeftMoveTimer.Tick += new System.EventHandler(this.LeftMoveTimer_Tick);
            // 
            // RightMoveTimer
            // 
            this.RightMoveTimer.Interval = 1;
            this.RightMoveTimer.Tick += new System.EventHandler(this.RightMoveTimer_Tick);
            // 
            // DownMoveTimer
            // 
            this.DownMoveTimer.Interval = 1;
            this.DownMoveTimer.Tick += new System.EventHandler(this.DownMoveTimer_Tick);
            // 
            // UpMoveTimer
            // 
            this.UpMoveTimer.Interval = 1;
            this.UpMoveTimer.Tick += new System.EventHandler(this.UpMoveTimer_Tick);
            // 
            // MoveMunitionTimer
            // 
            this.MoveMunitionTimer.Enabled = true;
            this.MoveMunitionTimer.Interval = 20;
            this.MoveMunitionTimer.Tick += new System.EventHandler(this.MoveMunitionTimer_Tick);
            // 
            // MoveEnemiesTimer
            // 
            this.MoveEnemiesTimer.Enabled = true;
            this.MoveEnemiesTimer.Interval = 80;
            this.MoveEnemiesTimer.Tick += new System.EventHandler(this.MoveEnemiesTimer_Tick);
            // 
            // EnemiesMunitionTimer
            // 
            this.EnemiesMunitionTimer.Enabled = true;
            this.EnemiesMunitionTimer.Interval = 10;
            this.EnemiesMunitionTimer.Tick += new System.EventHandler(this.EnemiesMunitionTimer_Tick);
            // 
            // lbtt
            // 
            this.lbtt.AutoSize = true;
            this.lbtt.Font = new System.Drawing.Font("Monotype Corsiva", 31.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbtt.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lbtt.Location = new System.Drawing.Point(156, 9);
            this.lbtt.Name = "lbtt";
            this.lbtt.Size = new System.Drawing.Size(271, 64);
            this.lbtt.TabIndex = 5;
            this.lbtt.Text = "Hello Player";
            this.lbtt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbtt.Visible = false;
            // 
            // ExitBtn
            // 
            this.ExitBtn.Location = new System.Drawing.Point(161, 304);
            this.ExitBtn.Name = "ExitBtn";
            this.ExitBtn.Size = new System.Drawing.Size(262, 67);
            this.ExitBtn.TabIndex = 1;
            this.ExitBtn.Text = "Exit";
            this.ExitBtn.UseVisualStyleBackColor = true;
            this.ExitBtn.Visible = false;
            this.ExitBtn.Click += new System.EventHandler(this.ExitBtn_Click);
            // 
            // ReplayBtn
            // 
            this.ReplayBtn.Location = new System.Drawing.Point(161, 157);
            this.ReplayBtn.Name = "ReplayBtn";
            this.ReplayBtn.Size = new System.Drawing.Size(262, 67);
            this.ReplayBtn.TabIndex = 0;
            this.ReplayBtn.Text = "Replay";
            this.ReplayBtn.UseVisualStyleBackColor = true;
            this.ReplayBtn.Visible = false;
            this.ReplayBtn.Click += new System.EventHandler(this.ReplayBtn_Click);
            // 
            // scorelb1
            // 
            this.scorelb1.AutoSize = true;
            this.scorelb1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.scorelb1.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scorelb1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.scorelb1.Location = new System.Drawing.Point(26, 16);
            this.scorelb1.Name = "scorelb1";
            this.scorelb1.Size = new System.Drawing.Size(96, 37);
            this.scorelb1.TabIndex = 4;
            this.scorelb1.Text = "Score:";
            // 
            // levellb1
            // 
            this.levellb1.AutoSize = true;
            this.levellb1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.levellb1.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.levellb1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.levellb1.Location = new System.Drawing.Point(429, 19);
            this.levellb1.Name = "levellb1";
            this.levellb1.Size = new System.Drawing.Size(97, 34);
            this.levellb1.TabIndex = 5;
            this.levellb1.Text = "Level: ";
            // 
            // MovePresentTimer
            // 
            this.MovePresentTimer.Enabled = true;
            this.MovePresentTimer.Interval = 20;
            this.MovePresentTimer.Tick += new System.EventHandler(this.MovePresentTimer_Tick);
            // 
            // lbuser
            // 
            this.lbuser.AutoSize = true;
            this.lbuser.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lbuser.Location = new System.Drawing.Point(244, 421);
            this.lbuser.Name = "lbuser";
            this.lbuser.Size = new System.Drawing.Size(83, 16);
            this.lbuser.TabIndex = 6;
            this.lbuser.Text = "PlayerName";
            this.lbuser.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PlayBtn
            // 
            this.PlayBtn.Location = new System.Drawing.Point(161, 84);
            this.PlayBtn.Name = "PlayBtn";
            this.PlayBtn.Size = new System.Drawing.Size(262, 67);
            this.PlayBtn.TabIndex = 7;
            this.PlayBtn.Text = "Play";
            this.PlayBtn.UseVisualStyleBackColor = true;
            this.PlayBtn.Visible = false;
            this.PlayBtn.Click += new System.EventHandler(this.PlayBtn_Click);
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(161, 231);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(262, 67);
            this.btn_save.TabIndex = 8;
            this.btn_save.Text = "Save Score";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Visible = false;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // HideExplode
            // 
            this.HideExplode.Enabled = true;
            this.HideExplode.Interval = 700;
            this.HideExplode.Tick += new System.EventHandler(this.HideExplode_Tick);
            // 
            // MoveBossTimer
            // 
            this.MoveBossTimer.Tick += new System.EventHandler(this.MoveBossTimer_Tick);
            // 
            // MoveBossMunition
            // 
            this.MoveBossMunition.Enabled = true;
            this.MoveBossMunition.Interval = 10;
            this.MoveBossMunition.Tick += new System.EventHandler(this.MoveBossMunition_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MidnightBlue;
            this.ClientSize = new System.Drawing.Size(582, 453);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.PlayBtn);
            this.Controls.Add(this.lbuser);
            this.Controls.Add(this.scorelb1);
            this.Controls.Add(this.ReplayBtn);
            this.Controls.Add(this.ExitBtn);
            this.Controls.Add(this.lbtt);
            this.Controls.Add(this.Player);
            this.Controls.Add(this.levellb1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(600, 500);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Space Shooter";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.Player)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer MoveBgTimer;
        private System.Windows.Forms.PictureBox Player;
        private System.Windows.Forms.Timer LeftMoveTimer;
        private System.Windows.Forms.Timer RightMoveTimer;
        private System.Windows.Forms.Timer DownMoveTimer;
        private System.Windows.Forms.Timer UpMoveTimer;
        private System.Windows.Forms.Timer MoveMunitionTimer;
        private System.Windows.Forms.Timer MoveEnemiesTimer;
        private System.Windows.Forms.Timer EnemiesMunitionTimer;
        private System.Windows.Forms.Label lbtt;
        private System.Windows.Forms.Button ExitBtn;
        private System.Windows.Forms.Button ReplayBtn;
        private System.Windows.Forms.Label scorelb1;
        private System.Windows.Forms.Label levellb1;
        private System.Windows.Forms.Timer MovePresentTimer;
        private System.Windows.Forms.Label lbuser;
        private System.Windows.Forms.Button PlayBtn;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Timer HideExplode;
        private System.Windows.Forms.Timer MoveBossTimer;
        private System.Windows.Forms.Timer MoveBossMunition;
    }
}

